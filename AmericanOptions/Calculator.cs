using AmericanOptions.Helpers;
using AmericanOptions.OptimalExerciseBoundary;
using AmericanOptions.PutOptions;
using System;

namespace AmericanOptions
{
    public class Calculator
    {
        public Result[] Calculate(double r, double sigma, double t, double K, double S, int k, int n, double T)
        {
            Result[] results = new Result[k];
            BtCalculator btCalculator = new BtCalculator();
            AmercianPut putCalculator = new AmercianPut();


            for (int i = 0; i < k; i++)
            {
                if (i == 0) // Calulation for Bt, k=0 and Put, k=0
                {
                    Result result = new Result();

                    result.ResultNumber = i;

                    result.BtValue = K;
                    result.BtRoundedValue = Math.Round(K, 4);

                    result.PutValue = putCalculator.Calculate(K, S, r, t, sigma, n, T, K);
                    result.PutRoundedValue = Math.Round(result.PutValue, 4);

                    results[i] = result;

                }
                else if (i == 1) // Calulation for Bt, k=1 and Put, k=1
                {
                    Result result = new Result();

                    result.ResultNumber = i;

                    result.BtValue = btCalculator.CalculateBtK1(r, sigma, t, K, S, i, n, T);
                    result.BtRoundedValue = Math.Round(result.BtValue, 4);

                    result.PutValue = putCalculator.Calculate(K, S, r, t, sigma, n, T, result.BtValue);
                    result.PutRoundedValue = Math.Round(result.PutValue, 4);

                    results[i] = result;
                }
                else // Calulation for Bt, k=n and Put, k=n
                {
                    Result result = new Result();

                    result.ResultNumber = i;

                    result.BtValue = btCalculator.CalculateBtK(r, sigma, t, K, S, i, n, T, results[i - 1].BtValue);
                    result.BtRoundedValue = Math.Round(result.BtValue, 4);

                    result.PutValue = putCalculator.Calculate(K, S, r, t, sigma, n, T, result.BtValue);
                    result.PutRoundedValue = Math.Round(result.PutValue, 4);

                    if (double.IsNaN(result.BtValue))
                    {
                        Array.Resize(ref results, i);
                        break;
                    }

                    results[i] = result;

                }
            }

            return results;
        }
    }
}
