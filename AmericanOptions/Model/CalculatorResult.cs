using System;

namespace AmericanOptions.Model
{
   public class CalculatorResult : IDisposable
   {
      public int ResultNumber { get; set; }

      public BtResult BtResult { get; set; }
      public PutResult PutResult { get; set; }

      public void Dispose()
      {
         GC.SuppressFinalize(this);
      }
   }
}
