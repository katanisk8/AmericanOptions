using System;

namespace AmericanOptions.Model
{
   [Serializable]
    public class IntegralPoint
    {
        public Numerator Numerator;
        public Denominator Denominator;
        public Result Result;

        public IntegralPoint()
        {
            Result = new Result();
        }
    }
}