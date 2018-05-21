using AmericanOptions.Helpers;
using MathNet.Numerics.Distributions;
using System;

namespace AmericanOptions.PutOptions
{
    public class EuropeanPut : IEuropeanPut
    {
        IIntegralPoints integralPoints;
        IUnivariateDistribution dist;

        public EuropeanPut(IIntegralPoints _integralPoints, IUnivariateDistribution _dist)
        {
            integralPoints = _integralPoints;
            dist = _dist;
        }

        public double Calculate(double K, double S, double r, double t, double sigma)
        {
            double integralPointD1 = integralPoints.CalculateIntegralPointD1(S, K, r, sigma, t);
            double integralPointD2 = integralPoints.CalculateIntegralPointD2(integralPointD1, sigma, t);
            double distributionD1 = dist.CumulativeDistribution(-integralPointD1);
            double distributionD2 = dist.CumulativeDistribution(-integralPointD2);

            return K * Math.Exp(-r * t) * distributionD2 - (S * distributionD1);
        }
    }
}
