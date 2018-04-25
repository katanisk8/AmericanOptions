using AmericanOptions.CalculationHelpers;
using System;

namespace AmericanOptions.PutOptions
{
    internal class PutIntegralFunction
    {
        internal double Calculate(double n, double T, double r, double sigma, double t, double S, double K, double Btksi)
        {
            double result = 0;

            for (int i = 0; i < n; i++)
            {
                double h = (T / n);
                double ksi = i * h;

                result += CalculateUnderIntegral(r, S, K, t, ksi, Btksi, sigma) * h;
            }

            return result;
        }

        private double CalculateUnderIntegral(double r, double S, double K, double t, double ksi, double Btksi, double sigma)
        {
            double integralPointD1 = new IntegralPoints().CalculateIntegralPointD1(S, Btksi, r, sigma, t - ksi);
            double integralPointD2 = new IntegralPoints().CalculateIntegralPointD2(integralPointD1, sigma, t - ksi);
            double distribution = new StandardNormalDistribution().CalculatePDF(-integralPointD2);

            return r * K * Math.Exp(-r * (t - ksi)) * distribution;
        }
    }
}
