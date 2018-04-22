using System;

namespace AmericanOptions
{
    public class IntegralPoints
    {
        public double CalculateIntegralPointD1(double riskFreeRate, double volatilitySigma, double tau)
        {
            return CalculateD1Numerator(riskFreeRate, volatilitySigma, tau) / CalculateD1Denominator(volatilitySigma, tau);
        }

        public double CalculateIntegralPointD2(double integralPointD1, double volatilitySigma, double tau)
        {
            return integralPointD1 - CalculateD1Denominator(volatilitySigma, tau);
        }

        private double CalculateD1Numerator(double riskFreeRate, double volatilitySigma, double tau)
        {
            return (riskFreeRate + (0.5 * volatilitySigma * volatilitySigma)) * tau;
        }

        private double CalculateD1Denominator(double volatilitySigma, double tau)
        {
            return volatilitySigma * Math.Sqrt(tau);
        }
    }
}
