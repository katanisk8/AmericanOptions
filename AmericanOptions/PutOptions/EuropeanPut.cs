using AmericanOptions.Helpers;
using System;

namespace AmericanOptions.PutOptions
{
    internal class EuropeanPut
    {
        internal double Calculate(double K, double S, double r, double t, double sigma)
        {
            StandardNormalDistribution standardNormalDistribution = new StandardNormalDistribution();
            IntegralPoints integralPoints = new IntegralPoints();

            double integralPointD1 = integralPoints.CalculateIntegralPointD1(S, K, r, sigma, t);
            double integralPointD2 = integralPoints.CalculateIntegralPointD2(integralPointD1, sigma, t);
            double distributionD1 = standardNormalDistribution.CalculatePDF(-integralPointD1);
            double distributionD2 = standardNormalDistribution.CalculatePDF(-integralPointD2);

            return K * Math.Exp(-r * t) * distributionD2 - (S * distributionD1);
        }
    }
}
