using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AmericanOptions.Helpers
{
   public class MemoryMeter
   {
      static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

      public static int GetObjectSize(object obj)
      {
         using (MemoryStream ms = new MemoryStream())
         {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, obj);

            return ms.ToArray().Length;
         }
      }
      public static string GetObjectSizeWithSuffix()
      {
         var objSize = GC.GetTotalMemory(true);
         var objSize64 = Convert.ToInt64(objSize);
         return SizeSuffix(objSize64, 2);
      }

      public static string GetObjectSizeWithSuffix(object obj)
      {
         var objSize = GetObjectSize(obj);
         var objSize64 = Convert.ToInt64(objSize);
         return SizeSuffix(objSize64, 2);
      }

      private static string SizeSuffix(Int64 value, int decimalPlaces = 1)
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
