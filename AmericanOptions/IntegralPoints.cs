using System;

namespace AmericanOptions
{
    public class IntegralPoints
    {
        public double CalculateD1Numerator(double riskFreeRate, double volatilitySigma, double tau)
        {
            return (riskFreeRate + (0.5 * volatilitySigma * volatilitySigma)) * tau;
        }

        public double CalculateD1Denominator(double volatilitySigma, double tau)
        {
            return volatilitySigma * Math.Sqrt(tau);
        }
    }
}
