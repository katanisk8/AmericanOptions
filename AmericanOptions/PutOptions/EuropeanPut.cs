using AmericanOptions.Helpers;
using AmericanOptions.Model;
using MathNet.Numerics.Distributions;
using System;

namespace AmericanOptions.PutOptions
{
    public class EuropeanPut : IEuropeanPut
    {
        private readonly IIntegralPoints _integralPoints;
        private readonly IUnivariateDistribution _dist;

        public EuropeanPut(IIntegralPoints integralPoints, IUnivariateDistribution dist)
        {
            _integralPoints = integralPoints;
            _dist = dist;
        }

        public EuropeanPutResult Calculate(double K, double S, double r, double t, double sigma)
        {
            EuropeanPutResult ePut = new EuropeanPutResult();

            ePut.IntegralPointD1 = _integralPoints.CalculateIntegralPointD1(S, K, r, sigma, t);
            ePut.IntegralPointD2 = _integralPoints.CalculateIntegralPointD2(ePut.IntegralPointD1, sigma, t);
            ePut.Distribution1 = _dist.CumulativeDistribution(-ePut.IntegralPointD1.Value);
            ePut.Distribution2 = _dist.CumulativeDistribution(-ePut.IntegralPointD2.Value);
            ePut.Value = K * Math.Exp(-r * t) * ePut.Distribution2 - (S * ePut.Distribution1);

            return ePut;
        }
    }
}
