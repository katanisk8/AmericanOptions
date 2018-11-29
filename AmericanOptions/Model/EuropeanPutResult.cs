using System;

namespace AmericanOptions.Model
{
   [Serializable]
    public class EuropeanPutResult
    {
        public IntegralPoint IntegralPointD1;
        public IntegralPoint IntegralPointD2;
        public double Distribution1;
        public double Distribution2;
        public Result Result;

        public EuropeanPutResult()
        {
            Result = new Result();
        }
    }
}