using System;

namespace AmericanOptions.Calculations
{
    public class IntegralFunction
    {
        internal double Calculate(double n, double T, double r, double sigma, double t, double d2)
        {
            double result = 0;

            for (int i = 0; i <= n; i++)
            {
                double h = (T / n);
                double ksi = i * h;

                result += CalculateUnderIntegral(r, sigma, t, ksi, d2) * h;
            }

            return result;
        }

        private double CalculateUnderIntegral(double r, double sigma, double t, double ksi, double d2)
        {
            return (r / sigma * Math.Sqrt(2 * Math.PI * (t - ksi))) *
                    Math.Exp(-(r * (t - ksi) + (0.5 * Math.Pow(d2, 2))));
        }
    }
}
