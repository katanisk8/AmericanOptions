using System;

namespace AmericanOptions.Model
{
   [Serializable]
    public class Denominator
    {
        public Result Result;

        public Denominator()
        {
            Result = new Result();
        }
    }
}