using AmericanOptions.Helpers;
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

      public double Calculate(double K, double S, double r, double t, double sigma)
      {
         double integralPointD1 = _integralPoints.CalculateIntegralPointD1(S, K, r, sigma, t);
         double integralPointD2 = _integralPoints.CalculateIntegralPointD2(integralPointD1, sigma, t);
         double distributionD1 = _dist.CumulativeDistribution(-integralPointD1);
         double distributionD2 = _dist.CumulativeDistribution(-integralPointD2);

         return K * Math.Exp(-r * t) * distributionD2 - (S * distributionD1);
      }
   }
}
