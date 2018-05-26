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
            integralPoint.Value = integralPoint.Numerator.Value / integralPoint.Denominator.Value;

            return integralPoint;
        }

        public IntegralPoint CalculateIntegralPointD2(IntegralPoint d1, double sigma, double t)
        {
            IntegralPoint integralPoint = new IntegralPoint();

            integralPoint.Numerator = CalculateNumerator(d1);
            integralPoint.Denominator = CalculateDenominator(sigma, t);
            integralPoint.Value = integralPoint.Numerator.Value - integralPoint.Denominator.Value;

            return integralPoint;
        }

        private static Numerator CalculateNumerator(double S, double B, double r, double sigma, double t)
        {
            Numerator numerator = new Numerator();

            numerator.Value = Math.Log(S / B) + (r + (0.5 * Math.Pow(sigma, 2))) * t;

            return numerator;
        }

        private Numerator CalculateNumerator(IntegralPoint d1)
        {
            Numerator numerator = new Numerator();

            numerator.Value = d1.Value;

            return numerator;
        }

        private static Denominator CalculateDenominator(double sigma, double t)
        {
            Denominator denominator = new Denominator();

            denominator.Value = sigma * Math.Sqrt(t);

            return denominator;
        }
    }
}
