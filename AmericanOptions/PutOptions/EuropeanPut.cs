using AmericanOptions.Helpers;
using System;

namespace AmericanOptions.PutOptions
{
    public class EuropeanPut : IEuropeanPut
    {
        IIntegralPoints integralPoints;
        INormal normal;

        public EuropeanPut(IIntegralPoints _integralPoints, INormal _normal)
        {
            integralPoints = _integralPoints;
            normal = _normal;
        }

        public double Calculate(double K, double S, double r, double t, double sigma)
        {
            double integralPointD1 = integralPoints.CalculateIntegralPointD1(S, K, r, sigma, t);
            double integralPointD2 = integralPoints.CalculateIntegralPointD2(integralPointD1, sigma, t);
            double distributionD1 = normal.CDF(-integralPointD1);
            double distributionD2 = normal.CDF(-integralPointD2);

            return K * Math.Exp(-r * t) * distributionD2 - (S * distributionD1);
        }
    }
}
