using AmericanOptions.Helpers;
using System;

namespace AmericanOptions.OptimalExerciseBoundary
{
   internal class BtCalculator
   {
      internal Result CalculateBtK0(int k, double K)
      {
         return new Result { ResultNumber = k, Value = K };
      }

      internal Result CalculateBtK1(double r, double sigma, double t, double K, double S, int k, int n, double T)
      {
         IntegralPoints integralPoints = new IntegralPoints();
         StandardNormalDistribution standardNormalDistribution = new StandardNormalDistribution();
         BtCalculator bt = new BtCalculator();

         var integralPointD1 = integralPoints.CalculateIntegralPointD1(K, K, r, sigma, t);
         var integralPointD2 = integralPoints.CalculateIntegralPointD2(integralPointD1, sigma, t);
         var distribution = standardNormalDistribution.CalculatePDF(integralPointD1);
         var BtK_1 = bt.CalculateBtK_1(sigma, K, distribution, integralPointD1, r, t, integralPointD2);

         return new Result { ResultNumber = k, Value = BtK_1 };
      }

      internal Result CalculateBtK(double r, double sigma, double t, double K, double S, int k, int n, double T, double BtK_1)
      {
         IntegralPoints integralPoints = new IntegralPoints();
         StandardNormalDistribution standardNormalDistribution = new StandardNormalDistribution();
         BtCalculator bt = new BtCalculator();

         var integralPointD1 = integralPoints.CalculateIntegralPointD1(BtK_1, K, r, sigma, t);
         var integralPointD2 = integralPoints.CalculateIntegralPointD2(integralPointD1, sigma, t);
         var distribution = standardNormalDistribution.CalculatePDF(integralPointD1);
         var BtK = bt.CalculateBt(sigma, K, distribution, integralPointD1, r, t, integralPointD2, n, T);

         return new Result { ResultNumber = k, Value = BtK };
      }

      private double CalculateBtK_1(double sigma, double K, double dist, double d1, double r, double tau, double d2)
      {
         double a = (1 / sigma * Math.Sqrt(2 * Math.PI * tau));

         return (K * (1 / (dist + a) * Math.Exp(-0.5 * Math.Pow(d1, 2)))) *
             (a * Math.Exp(-((r * tau) + (0.5 * Math.Pow(d2, 2))))) +
             (((2 * sigma * r) / ((2 * r) + (Math.Pow(sigma, 2))) * (2 * dist) - 1));
      }

      private double CalculateBt(double sigma, double K, double dist, double d1, double r, double t, double d2, int n, double T)
      {
         double a = (1 / sigma * Math.Sqrt(2 * Math.PI * t));
         double integralFunction = new BtIntegralFunction().Calculate(n, T, r, sigma, t, d2);

         return (1 / (dist + a * Math.Exp(-0.5 * Math.Pow(d1, 2)))) *
             (a * K * Math.Exp(-((r * t) + (0.5 * Math.Pow(d2, 2))))) +
             (r * K * integralFunction);
      }
   }
}
