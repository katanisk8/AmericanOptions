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

            results[0] = CalculateK0(putCalculator, K, S, r, t, sigma, n, T);
            results[1] = CalculateK1(btCalculator, putCalculator, K, S, r, t, sigma, n, T);

            for (int i = 2; i < k; i++)
            {
                Result result = new Result();

                result.ResultNumber = i;

                result.BtValue = btCalculator.CalculateBtK(r, sigma, t, K, S, n, T, results[i - 1].BtValue);
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

            return results;
        }

        private Result CalculateK0(AmercianPut putCalculator, double K, double S, double r, double t, double sigma, int n, double T)
        {
            Result result = new Result();

            result.ResultNumber = 0;

            result.BtValue = K;
            result.BtRoundedValue = Math.Round(K, 4);

            result.PutValue = putCalculator.Calculate(K, S, r, t, sigma, n, T, K);
            result.PutRoundedValue = Math.Round(result.PutValue, 4);

            return result;
        }

        private Result CalculateK1(BtCalculator btCalculator, AmercianPut putCalculator, double K, double S, double r, double t, double sigma, int n, double T)
        {
            Result result = new Result();

            result.ResultNumber = 1;

            result.BtValue = btCalculator.CalculateBtK1(r, sigma, t, K, S, n, T);
            result.BtRoundedValue = Math.Round(result.BtValue, 4);

            result.PutValue = putCalculator.Calculate(K, S, r, t, sigma, n, T, result.BtValue);
            result.PutRoundedValue = Math.Round(result.PutValue, 4);

            return result;
        }
    }
}
