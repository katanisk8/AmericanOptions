using System;

namespace AmericanOptions.Model
{
   [Serializable]
    public class Result
    {
        private double value;
        private double roundedValue;

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

        public Result() { }
        public Result(double value)
        {
            Value = value;
        }
    }
}
