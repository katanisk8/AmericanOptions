using System;
using AmericanOptions.Calculations;

namespace AmericanOptions.Bt
{
    public class BtCalculator
    {
        internal double CalculateBtK_1(double sigma, double K, double dist, double d1, double r, double tau, double d2)
        {
            double a = (1 / sigma * Math.Sqrt(2 * Math.PI * tau));

            return (K * (1 / (dist + a) * Math.Exp(-0.5 * Math.Pow(d1, 2)))) *
                (a * Math.Exp(-((r * tau) + (0.5 * Math.Pow(d2, 2))))) +
                (((2 * sigma * r) / ((2 * r) + (Math.Pow(sigma, 2))) * (2 * dist) - 1));
        }

        internal double CalculateBt(double sigma, double K, double dist, double d1, double r, double t, double d2, double n, double T)
        {
            double a = (1 / sigma * Math.Sqrt(2 * Math.PI * t));
            double integralFunction = new IntegralFunction().Calcualte(n, T, r, sigma, t, d2);

            return (1 / (dist + a * Math.Exp(-0.5 * Math.Pow(d1, 2)))) *
                (a * K * Math.Exp(-((r * t) + (0.5 * Math.Pow(d2, 2))))) +
                (r * K * integralFunction);
        }
    }
}
