using AmericanOptions.Helpers;
using MathNet.Numerics.Distributions;
using System;

namespace AmericanOptions.PutOptions
{
    public class PutIntegralFunction : IPutIntegralFunction
    {
      private readonly IIntegralPoints _integralPoints;
      private readonly IUnivariateDistribution _dist;

        public PutIntegralFunction(IIntegralPoints integralPoints, IUnivariateDistribution dist)
        {
            _integralPoints = integralPoints;
            _dist = dist;
        }

        public double Calculate(int n, double T, double r, double sigma, double t, double S, double K, double Btksi)
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
            double integralPointD1 = _integralPoints.CalculateIntegralPointD1(S, Btksi, r, sigma, t - ksi);
            double integralPointD2 = _integralPoints.CalculateIntegralPointD2(integralPointD1, sigma, t - ksi);
            double distribution = _dist.CumulativeDistribution(-integralPointD2);

            return r * K * Math.Exp(-r * (t - ksi)) * distribution;
        }
    }
}
