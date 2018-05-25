using System;
using System.ComponentModel;

namespace AmericanOptions.Model
{
    public class Result
    {
        public int ResultNumber;

        public double BtValue;
        public double BtRoundedValue;

        public double PutValue;
        public double PutRoundedValue;

        public static explicit operator Result(ProgressChangedEventArgs v)
        {
            throw new NotImplementedException();
        }
    }
}
