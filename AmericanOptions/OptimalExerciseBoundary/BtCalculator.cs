using AmericanOptions.Helpers;
using AmericanOptions.Model;
using MathNet.Numerics.Distributions;
using System;

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

        public BtResult CalculateBtK0(double K)
        {
            BtResult bt = new BtResult();

            bt.Value = K;

            return bt;
        }

        public BtResult CalculateBtK1(double r, double sigma, double t, double K, double S, int n, double T)
        {
            BtResult bt = new BtResult();

            bt.IntegralPointD1 = _integralPoints.CalculateIntegralPointD1(K, K, r, sigma, t);
            bt.IntegralPointD2 = _integralPoints.CalculateIntegralPointD2(bt.IntegralPointD1, sigma, t);
            bt.Distribution = _dist.CumulativeDistribution(bt.IntegralPointD1.Value);
            bt.a = (1 / sigma * Math.Sqrt(2 * Math.PI * t));
            bt.Value = CalculateBtK1(sigma, K, r, t, bt);

            return bt;
        }

        public BtResult CalculateBtK(double r, double sigma, double t, double K, double S, int n, double T, BtResult BtK_1)
        {
            BtResult bt = new BtResult();

            bt.IntegralPointD1 = _integralPoints.CalculateIntegralPointD1(BtK_1.Value, K, r, sigma, t);
            bt.IntegralPointD2 = _integralPoints.CalculateIntegralPointD2(bt.IntegralPointD1, sigma, t);
            bt.Distribution = _dist.CumulativeDistribution(bt.IntegralPointD2.Value);
            bt.a = (1 / sigma * Math.Sqrt(2 * Math.PI * t));
            bt.IntegralFunction = _btIntegralFunction.Calculate(n, T, r, sigma, t, bt.IntegralPointD2);
            bt.Value = CalculateBtValue(sigma, K, r, t, bt);

            return bt;
        }

        private double CalculateBtK1(double sigma, double K, double r, double t, BtResult bt)
        {
            return (K * (1 / (bt.Distribution + bt.a * Math.Exp(-0.5 * Math.Pow(bt.IntegralPointD1.Value, 2))))) *
                (bt.a * Math.Exp(-((r * t) + (0.5 * Math.Pow(bt.IntegralPointD2.Value, 2))))) +
                (((2 * sigma * r) / ((2 * r) + (Math.Pow(sigma, 2))) * (2 * bt.Distribution) - 1));
        }

        private double CalculateBtValue(double sigma, double K, double r, double t, BtResult bt)
        {
            return (1 / (bt.Distribution + bt.a * Math.Exp(-0.5 * Math.Pow(bt.IntegralPointD1.Value, 2)))) *
                (bt.a * K * Math.Exp(-((r * t) + (0.5 * Math.Pow(bt.IntegralPointD2.Value, 2))))) +
                (r * K * bt.IntegralFunction.Value);
        }
    }
}
