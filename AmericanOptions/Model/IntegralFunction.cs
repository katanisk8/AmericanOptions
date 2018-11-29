using System;

namespace AmericanOptions.Model
{
   [Serializable]
    public class IntegralFunction
    {
        public UnderIntegral[] UnderIntegral;
        public Result Result;

        public IntegralFunction()
        {
            Result = new Result();
        }
    }
}