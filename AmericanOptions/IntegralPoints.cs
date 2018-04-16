using System;

namespace AmericanOptions
{
    public class IntegralPoints
    {
        public decimal CalculateD1Numerator(decimal riskFreeRate, decimal volatilitySigma, decimal tau)
        {
            return (riskFreeRate + ((decimal)0.5 * volatilitySigma * volatilitySigma)) * tau;
        }

        public decimal CalculateD1Denominator(decimal volatilitySigma, decimal tau)
        {
            return volatilitySigma * (decimal)Math.Sqrt((double)tau);
        }
    }
}
