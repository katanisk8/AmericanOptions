using System;

namespace AmericanOptions.Model
{
    public class UnderIntegral
    {
        public int ResultNumber;
        public double h;
        public double ksi;
        public IntegralPoint IntegralPointD1;
        public IntegralPoint IntegralPointD2;
        public double Distribution;
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