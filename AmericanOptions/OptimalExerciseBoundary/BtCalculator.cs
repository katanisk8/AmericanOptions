using AmericanOptions.Helpers;
using AmericanOptions.Model;
using MathNet.Numerics.Distributions;
using System;
using System.Threading.Tasks;

namespace AmericanOptions.OptimalExerciseBoundary
{
    public class BtCalculator : IBtCalculator
    {
        private readonly IIntegralPoints _integralPoints;
        private readonly IBtIntegralFunction _btIntegralFunction;
        private readonly IUnivariateDistribution _distribution;

        public BtCalculator(IIntegralPoints integralPoints, IBtIntegralFunction btIntegralFunction, IUnivariateDistribution distribution)
        {
            _integralPoints = integralPoints;
            _btIntegralFunction = btIntegralFunction;
            _distribution = distribution;
        }

        public BtResult CalculateBtK0(double K)
        {
            BtResult bt = new BtResult();

            bt.Result.Value = K;

            return bt;
        }

        public BtResult CalculateBtK1(double r, double sigma, double t, double K, double S, int n, double T)
        {
            BtResult bt = new BtResult();

            bt.IntegralPointD1 = _integralPoints.CalculateIntegralPointD1(K, K, r, sigma, t);
            bt.IntegralPointD2 = _integralPoints.CalculateIntegralPointD2(bt.IntegralPointD1, sigma, t);
            bt.Distribution = _distribution.CumulativeDistribution(bt.IntegralPointD1.Result.Value);
            bt.a = CalculateAValue(sigma, t);
            bt.Result.Value = CalculateBtK1(sigma, K, r, t, bt);

            return bt;
        }

        public async Task<BtResult> CalculateBtKAsync(double r, double sigma, double t, double K, double S, int n, double T, BtResult BtK_1)
        {
            BtResult bt = new BtResult();

            bt.IntegralPointD1 = _integralPoints.CalculateIntegralPointD1(BtK_1.Result.Value, K, r, sigma, t);
            bt.IntegralPointD2 = _integralPoints.CalculateIntegralPointD2(bt.IntegralPointD1, sigma, t);
            bt.Distribution = _distribution.CumulativeDistribution(bt.IntegralPointD1.Result.Value);
            bt.a = CalculateAValue(sigma, t);
            bt.IntegralFunction = await _btIntegralFunction.CalculateAsync(n, T, r, sigma, t, bt.IntegralPointD2);
            bt.Result.Value = CalculateBtValue(sigma, K, r, t, bt);

            return bt;
        }

        private static double CalculateBtK1(double sigma, double K, double r, double t, BtResult Bt)
        {
            return (K * (1 / (Bt.Distribution + Bt.a * Math.Exp(-0.5 * Math.Pow(Bt.IntegralPointD1.Result.Value, 2))))) *
                (Bt.a * Math.Exp(-((r * t) + (0.5 * Math.Pow(Bt.IntegralPointD2.Result.Value, 2))))) +
                (((2 * sigma * r) / ((2 * r) + (Math.Pow(sigma, 2))) * (2 * Bt.Distribution) - 1));
        }

        private static double CalculateBtValue(double sigma, double K, double r, double t, BtResult Bt)
        {
            return (1 / (Bt.Distribution + Bt.a * Math.Exp(-0.5 * Math.Pow(Bt.IntegralPointD1.Result.Value, 2)))) *
                (Bt.a * K * Math.Exp(-((r * t) + (0.5 * Math.Pow(Bt.IntegralPointD2.Result.Value, 2))))) +
                (r * K * Bt.IntegralFunction.Result.Value);
        }

        private static double CalculateAValue(double sigma, double t)
        {
            return (1 / sigma * Math.Sqrt(2 * Math.PI * t));
        }
    }
}
