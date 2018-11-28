using AmericanOptions.Helpers;
using AmericanOptions.Model;
using MathNet.Numerics.Distributions;
using System;

namespace AmericanOptions.PutOptions
{
    public class PutIntegralFunction : IPutIntegralFunction
    {
        private readonly IIntegralPoints _integralPoints;
        private readonly IUnivariateDistribution _distribution;

        public PutIntegralFunction(IIntegralPoints integralPoints, IUnivariateDistribution distribution)
        {
            _integralPoints = integralPoints;
            _distribution = distribution;
        }

        public IntegralFunction Calculate(int n, double T, double r, double sigma, double t, double S, double K, BtResult Btksi)
        {
            IntegralFunction integralFunction = new IntegralFunction();
            UnderIntegral[] underIntegral = new UnderIntegral[n];

            for (int i = 0; i < n; i++)
            {
                UnderIntegral ui = new UnderIntegral();

                ui.h = (T / n);
                ui.ksi = i * ui.h;
                ui.IntegralPointD1 = _integralPoints.CalculateIntegralPointD1(S, Btksi.Result.Value, r, sigma, t - ui.ksi);
                ui.IntegralPointD2 = _integralPoints.CalculateIntegralPointD2(ui.IntegralPointD1, sigma, t - ui.ksi);
                ui.Distribution = _distribution.CumulativeDistribution(-ui.IntegralPointD2.Result.Value);
                ui.Result.Value = CalculateUnderIntegral(r, K, t, ui.ksi, ui.Distribution) * ui.h;

                underIntegral[i] = ui;
                integralFunction.Result.Value += ui.Result.Value;
            }

            integralFunction.UnderIntegral = underIntegral;

            return integralFunction;
        }

        private static double CalculateUnderIntegral(double r, double K, double t, double ksi, double dist)
        {
            return r * K * Math.Exp(-r * (t - ksi)) * dist;
        }
    }
}
