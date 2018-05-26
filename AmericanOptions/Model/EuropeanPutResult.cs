using System;

namespace AmericanOptions.Model
{
    public class EuropeanPutResult
    {
        public IntegralPoint IntegralPointD1;
        public IntegralPoint IntegralPointD2;
        public double Distribution1;
        public double Distribution2;
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