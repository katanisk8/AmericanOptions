using AmericanOptions.Helpers;
using AmericanOptions.Model;
using MathNet.Numerics.Distributions;
using System;

namespace AmericanOptions.PutOptions
{
    public class PutIntegralFunction : IPutIntegralFunction
    {
        private readonly IIntegralPoints _integralPoints;
        private readonly IUnivariateDistribution _dist;

        public PutIntegralFunction(IIntegralPoints integralPoints, IUnivariateDistribution dist)
        {
            _integralPoints = integralPoints;
            _dist = dist;
        }

        public PutIntegralFunctionResult Calculate(int n, double T, double r, double sigma, double t, double S, double K, BtResult Btksi)
        {
            PutIntegralFunctionResult result = new PutIntegralFunctionResult();
            UnderIntegral[] underIntegral = new UnderIntegral[n];

            for (int i = 0; i < n; i++)
            {
                UnderIntegral ui = new UnderIntegral();

                ui.h = (T / n);
                ui.ksi = i * ui.h;
                ui.IntegralPointD1 = _integralPoints.CalculateIntegralPointD1(S, Btksi.Value, r, sigma, t - ui.ksi);
                ui.IntegralPointD2 = _integralPoints.CalculateIntegralPointD2(ui.IntegralPointD1, sigma, t - ui.ksi);
                ui.Distribution = _dist.CumulativeDistribution(-ui.IntegralPointD2.Value);
                ui.Value = CalculateUnderIntegral(r, K, t, ui.ksi, ui.Distribution) * ui.h;

                underIntegral[i] = ui;
                result.Value += ui.Value;
            }

            result.UnderIntegral = underIntegral;

            return result;
        }

        private double CalculateUnderIntegral(double r, double K, double t, double ksi, double dist)
        {
            return r * K * Math.Exp(-r * (t - ksi)) * dist;
        }
    }
}
