using AmericanOptions.Helpers;
using MathNet.Numerics.Distributions;
using System;
using System.Threading.Tasks;

namespace AmericanOptions.OptimalExerciseBoundary
{
    public class BtCalculator : IBtCalculator
    {
      private readonly IIntegralPoints _integralPoints;
      private readonly IBtIntegralFunction _btIntegralFunction;
      private readonly IUnivariateDistribution _dist;

        public BtCalculator(IIntegralPoints integralPoints, IBtIntegralFunction btIntegralFunction, IUnivariateDistribution dist)
        {
            _integralPoints = integralPoints;
            _btIntegralFunction = btIntegralFunction;
            _dist = dist;
        }

        public double CalculateBtK1(double r, double sigma, double t, double K, double S, int n, double T)
        {
            double integralPointD1 = _integralPoints.CalculateIntegralPointD1(K, K, r, sigma, t);
            double integralPointD2 = _integralPoints.CalculateIntegralPointD2(integralPointD1, sigma, t);
            double distribution = _dist.CumulativeDistribution(integralPointD1);

            return CalculateBtK1(sigma, K, distribution, integralPointD1, r, t, integralPointD2);
        }

        public async Task<double> CalculateBtK(double r, double sigma, double t, double K, double S, int n, double T, double BtK_1)
        {
           double integralPointD1 = _integralPoints.CalculateIntegralPointD1(BtK_1, K, r, sigma, t);
           double integralPointD2 = _integralPoints.CalculateIntegralPointD2(integralPointD1, sigma, t);
           double distribution = _dist.CumulativeDistribution(integralPointD1);

            return  await CalculateBt(sigma, K, distribution, integralPointD1, r, t, integralPointD2, n, T);
        }

        private static double CalculateBtK1(double sigma, double K, double dist, double d1, double r, double tau, double d2)
        {
            double a = (1 / sigma * Math.Sqrt(2 * Math.PI * tau));

            return (K * (1 / (dist + a * Math.Exp(-0.5 * Math.Pow(d1, 2))))) *
                (a * Math.Exp(-((r * tau) + (0.5 * Math.Pow(d2, 2))))) +
                (((2 * sigma * r) / ((2 * r) + (Math.Pow(sigma, 2))) * (2 * dist) - 1));
        }

        private async Task<double> CalculateBt(double sigma, double K, double dist, double d1, double r, double t, double d2, int n, double T)
        {
            double a = (1 / sigma * Math.Sqrt(2 * Math.PI * t));
            double integralFunction = await _btIntegralFunction.Calculate(n, T, r, sigma, t, d2);

            return (1 / (dist + a * Math.Exp(-0.5 * Math.Pow(d1, 2)))) *
                (a * K * Math.Exp(-((r * t) + (0.5 * Math.Pow(d2, 2))))) +
                (r * K * integralFunction);
        }
    }
}
