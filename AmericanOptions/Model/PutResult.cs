using System;

namespace AmericanOptions.Model
{
    public class PutResult
    {
        public EuropeanPutResult EuropeanPut;
        public PutIntegralFunctionResult PutIntegralFunction;
        public double RoundedValue;

        public double Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
                RoundedValue = Math.Round(this.value, 4);
            }
        }
        private double value;
    }
}