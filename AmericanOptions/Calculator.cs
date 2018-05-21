using AmericanOptions.Model;
using AmericanOptions.OptimalExerciseBoundary;
using AmericanOptions.PutOptions;
using System;

namespace AmericanOptions
{
    public class Calculator : ICalculator
    {
        IBtCalculator btCalculator;
        IAmercianPut putCalculator;

        public Calculator(IBtCalculator _btCalculator, IAmercianPut _putCalculator)
        {
            btCalculator = _btCalculator;
            putCalculator = _putCalculator;
        }

        public Result[] Calculate(double r, double sigma, double t, double K, double S, int k, int n, double T)
        {
            Result[] results = new Result[k];

            results[0] = CalculateK0(K, S, r, t, sigma, n, T);
            results[1] = CalculateBtK1(K, S, r, t, sigma, n, T);

            for (int i = 2; i < k; i++)
            {
                results[i] = CalculateBtK(K, S, r, t, sigma, n, T, i, results[i - 1].BtValue);

                if (double.IsNaN(results[i].BtValue))
                {
                    Array.Resize(ref results, i);
                    break;
                }
            }

            return results;
        }

        private Result CalculateK0(double K, double S, double r, double t, double sigma, int n, double T)
        {
            Result result = new Result();

            result.ResultNumber = 0;

            result.BtValue = K;
            result.BtRoundedValue = Math.Round(K, 4);

            result.PutValue = putCalculator.Calculate(K, S, r, t, sigma, n, T, K);
            result.PutRoundedValue = Math.Round(result.PutValue, 4);

            return result;
        }

        private Result CalculateBtK1(double K, double S, double r, double t, double sigma, int n, double T)
        {
            Result result = new Result();

            result.ResultNumber = 1;

            result.BtValue = btCalculator.CalculateBtK1(r, sigma, t, K, S, n, T);
            result.BtRoundedValue = Math.Round(result.BtValue, 4);

            result.PutValue = putCalculator.Calculate(K, S, r, t, sigma, n, T, result.BtValue);
            result.PutRoundedValue = Math.Round(result.PutValue, 4);

            return result;
        }

        private Result CalculateBtK(double K, double S, double r, double t, double sigma, int n, double T, int i, double BtK_1)
        {
            Result result = new Result();

            result.ResultNumber = i;

            result.BtValue = btCalculator.CalculateBtK(r, sigma, t, K, S, n, T, BtK_1);
            result.BtRoundedValue = Math.Round(result.BtValue, 4);

            result.PutValue = putCalculator.Calculate(K, S, r, t, sigma, n, T, result.BtValue);
            result.PutRoundedValue = Math.Round(result.PutValue, 4);

            return result;
        }
    }
}
