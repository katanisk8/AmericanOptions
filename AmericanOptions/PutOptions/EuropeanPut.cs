using AmericanOptions.Helpers;
using AmericanOptions.Model;
using MathNet.Numerics.Distributions;
using System;

namespace AmericanOptions.PutOptions
{
    public class EuropeanPut : IEuropeanPut
    {
        private readonly IIntegralPoints _integralPoints;
        private readonly IUnivariateDistribution _distribution;

        public EuropeanPut(IIntegralPoints integralPoints, IUnivariateDistribution distribution)
        {
            _integralPoints = integralPoints;
            _distribution = distribution;
        }

        public EuropeanPutResult Calculate(double K, double S, double r, double t, double sigma)
        {
            EuropeanPutResult ePut = new EuropeanPutResult();

            ePut.IntegralPointD1 = _integralPoints.CalculateIntegralPointD1(S, K, r, sigma, t);
            ePut.IntegralPointD2 = _integralPoints.CalculateIntegralPointD2(ePut.IntegralPointD1, sigma, t);
            ePut.Distribution1 = _distribution.CumulativeDistribution(-ePut.IntegralPointD1.Result.Value);
            ePut.Distribution2 = _distribution.CumulativeDistribution(-ePut.IntegralPointD2.Result.Value);
            ePut.Result.Value = CalculateValue(K, S, r, t, ePut);

            return ePut;
        }

        private static double CalculateValue(double K, double S, double r, double t, EuropeanPutResult ePut)
        {
            return K * Math.Exp(-r * t) * ePut.Distribution2 - (S * ePut.Distribution1);
        }
    }
}
