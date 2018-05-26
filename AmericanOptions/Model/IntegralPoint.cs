using System;

namespace AmericanOptions.Model
{
    public class IntegralPoint
    {
        public Numerator Numerator;
        public Denominator Denominator;
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