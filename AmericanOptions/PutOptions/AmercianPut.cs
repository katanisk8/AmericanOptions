using AmericanOptions.Helpers;
using System.Collections.Generic;

namespace AmericanOptions.PutOptions
{
    internal class AmercianPut
    {
        internal List<Result> Calculate(double K, double S, double r, double t, double sigma, double n, double T, double Btksi, double k)
        {
            List<Result> results = new List<Result>();

            for (int i = 0; i < k; i++)
            {
                double europeanPut = new EuropeanPut().Calculate(K, S, r, t, sigma);
                double putIntegralFunction = new PutIntegralFunction().Calculate(n, T, r, sigma, t, S, K, Btksi);
                double result = europeanPut + putIntegralFunction;

                results.Add(new Result { ResultNumber = i, Value = result });
            }

            return results;
        }

    }
}