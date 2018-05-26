using System;
using AmericanOptions.Model;

namespace AmericanOptions.OptimalExerciseBoundary
{
    public class BtIntegralFunction : IBtIntegralFunction
    {
        public BtIntegralFunctionResult Calculate(int n, double T, double r, double sigma, double t, IntegralPoint d2)
        {
            BtIntegralFunctionResult result = new BtIntegralFunctionResult();
            UnderIntegral[] underIntegral = new UnderIntegral[n];

            for (int i = 0; i < n; i++)
            {
                UnderIntegral ui = new UnderIntegral();

                ui.h = (T / n);
                ui.ksi = i * ui.h;
                ui.Value = CalculateUnderIntegral(r, sigma, t, ui.ksi, d2) * ui.h;

                underIntegral[i] = ui;
                result.Value += ui.Value;
            }

            result.UnderIntegral = underIntegral;

            return result;
        }

        private static double CalculateUnderIntegral(double r, double sigma, double t, double ksi, IntegralPoint d2)
        {
            return (r / sigma * Math.Sqrt(2 * Math.PI * (t - ksi))) *
                    Math.Exp(-(r * (t - ksi) + (0.5 * Math.Pow(d2.Value, 2))));
        }
    }
}
