using System;

namespace AmericanOptions.Model
{
    public class BtResult
    {
        public IntegralPoint IntegralPointD1;
        public IntegralPoint IntegralPointD2;
        public double Distribution;
        public BtIntegralFunctionResult IntegralFunction;
        public double a;
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