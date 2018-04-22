using System;

namespace AmericanOptions.Calculations
{
    public class BtK1
    {
        public double Calculate(double volatilitySigma, double strikePrice, double distribution, double integralPointD1, double riskFreeRate, double tau, double integralPointD2)
        {
            double a = (1 / volatilitySigma * Math.Sqrt(2 * Math.PI * tau));

            return (strikePrice * (1 / (distribution + a) * Math.Exp(-0.5 * integralPointD1 * integralPointD1))) *
                (a * Math.Exp(-((riskFreeRate * tau) + (0.5 * integralPointD2 * integralPointD2)))) +
                (((2 * volatilitySigma * riskFreeRate) / ((2 * riskFreeRate) + (volatilitySigma * volatilitySigma))) * (2 * distribution) - 1);
        }
    }
}
