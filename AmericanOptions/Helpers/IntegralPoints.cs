using AmericanOptions.Model;
using System;

namespace AmericanOptions.Helpers
{
    public class IntegralPoints : IIntegralPoints
    {
        public IntegralPoint CalculateIntegralPointD1(double S, double B, double r, double sigma, double t)
        {
            IntegralPoint integralPoint = new IntegralPoint();

            integralPoint.Numerator = CalculateNumerator(S, B, r, sigma, t);
            integralPoint.Denominator = CalculateDenominator(sigma, t);
            integralPoint.Result = new Result(integralPoint.Numerator.Result.Value / integralPoint.Denominator.Result.Value);

            return integralPoint;
        }

        public IntegralPoint CalculateIntegralPointD2(IntegralPoint D1, double sigma, double t)
        {
            IntegralPoint integralPoint = new IntegralPoint();

            integralPoint.Numerator = CalculateNumerator(D1);
            integralPoint.Denominator = CalculateDenominator(sigma, t);
            integralPoint.Result = new Result(integralPoint.Numerator.Result.Value - integralPoint.Denominator.Result.Value);

            return integralPoint;
        }

        private static Numerator CalculateNumerator(double S, double B, double r, double sigma, double t)
        {
            Numerator numerator = new Numerator();

            numerator.Result = new Result(Math.Log(S / B) + (r + (0.5 * Math.Pow(sigma, 2))) * t);

            return numerator;
        }

        private Numerator CalculateNumerator(IntegralPoint D1)
        {
            Numerator numerator = new Numerator();

            numerator.Result = D1.Result;

            return numerator;
        }

        private static Denominator CalculateDenominator(double sigma, double t)
        {
            Denominator denominator = new Denominator();

            denominator.Result = new Result(sigma * Math.Sqrt(t));

            return denominator;
        }
    }
}
