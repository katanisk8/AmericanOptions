using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace AmericanOptions.Helpers
{
   public class MemoryMeter
   {
      static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

      public static async Task<string> GetTotalMemoryWithSuffixAsync()
      {
         var totalMemory = GC.GetTotalMemory(true);
         var totalMemory64 = Convert.ToInt64(totalMemory);
         return await SizeSuffix(totalMemory64, 2);
      }

      public static async Task<string> GetObjectSizeWithSuffixAsync(object obj)
      {
         var objSize = GetObjectSize(obj);
         var objSize64 = Convert.ToInt64(objSize);
         return await SizeSuffix(objSize64, 2);
      }

      private static int GetObjectSize(object obj)
      {
         using (MemoryStream ms = new MemoryStream())
         {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, obj);

            return ms.ToArray().Length;
         }
      }

      private static async Task<string> SizeSuffix(Int64 value, int decimalPlaces = 1)
      {
         if (decimalPlaces < 0) { throw new ArgumentOutOfRangeException("decimalPlaces"); }
         if (value < 0) { return "-" + SizeSuffix(-value); }
         if (value == 0) { return string.Format("{0:n" + decimalPlaces + "} bytes", 0); }

         // mag is 0 for bytes, 1 for KB, 2, for MB, etc.
         int mag = (int)Math.Log(value, 1024);

         // 1L << (mag * 10) == 2 ^ (10 * mag) 
         // [i.e. the number of bytes in the unit corresponding to mag]
         decimal adjustedSize = (decimal)value / (1L << (mag * 10));

         // make adjustment when the value is large enough that
         // it would round up to 1000 or more
         if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
         {
            mag += 1;
            adjustedSize /= 1024;
         }

         return string.Format("{0:n" + decimalPlaces + "} {1}", adjustedSize, SizeSuffixes[mag]);
      }
   }
}
