using System;

namespace AmericanOptions.Model
{
    public class Result
    {
        public Result() { }
        public Result(double value)
        {
            Value = value;
        }

        public double Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
                roundedValue = Math.Round(this.Value, 4);
            }
        }
        public double RoundedValue
        {
            get
            {
                return roundedValue;
            }
            private set
            {

            }
        }

        private double value;
        private double roundedValue;
    }
}
