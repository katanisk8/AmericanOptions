using System;

namespace AmericanOptions.Model
{
   [Serializable]
    public class Numerator
    {
        public Result Result;

        public Numerator()
        {
            Result = new Result();
        }
    }
}