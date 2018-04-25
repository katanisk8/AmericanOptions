using AmericanOptions.Helpers;
using AmericanOptions.OptimalExerciseBoundary;
using AmericanOptions.PutOptions;

namespace AmericanOptions
{
    internal class Calculator
    {
        internal Results Calcluate(double r, double sigma, double t, double K, double S, double k, double n, double T)
        {
            Results results = new Results();
            BtCalculator btCalculator = new BtCalculator();
            AmercianPut putCalculator = new AmercianPut();

            results.BtResults = btCalculator.Calculate(r, sigma, t, K, S, k, n, T);
            results.PutResults = putCalculator.Calculate(K, S, r, t, sigma, n, T, 1, k);

            return results;

        }
    }
}
