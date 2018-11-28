using AmericanOptions.Model;
using AmericanOptions.OptimalExerciseBoundary;
using AmericanOptions.PutOptions;
using System;

namespace AmericanOptions
{
    public class Calculator : ICalculator
    {
        private readonly IBtCalculator _btCalculator;
        private readonly IAmercianPut _putCalculator;

        public Calculator(IBtCalculator btCalculator, IAmercianPut putCalculator)
        {
            _btCalculator = btCalculator;
            _putCalculator = putCalculator;
        }

        public CalculatorResult[] Calculate(double r, double sigma, double t, double K, double S, int k, int n, double T)
        {
            CalculatorResult[] results = new CalculatorResult[k];

            results[0] = CalculateK0(K, S, r, t, sigma, n, T);
            results[1] = CalculateBtK1(K, S, r, t, sigma, n, T);

            for (int i = 2; i < k; i++)
            {
                results[i] = CalculateBtKi(K, S, r, t, sigma, n, T, i, results[i - 1].BtResult);

                if (double.IsNaN(results[i].BtResult.Result.Value))
                {
                    Array.Resize(ref results, i);
                    break;
                }
            }

            return results;
        }

        public CalculatorResult CalculateK0(double K, double S, double r, double t, double sigma, int n, double T)
        {
            CalculatorResult result = new CalculatorResult();

            result.ResultNumber = 0;
            result.BtResult = _btCalculator.CalculateBtK0(K);
            result.PutResult = _putCalculator.Calculate(K, S, r, t, sigma, n, T, result.BtResult);

            return result;
        }

        public CalculatorResult CalculateBtK1(double K, double S, double r, double t, double sigma, int n, double T)
        {
            CalculatorResult result = new CalculatorResult();

            result.ResultNumber = 1;
            result.BtResult = _btCalculator.CalculateBtK1(r, sigma, t, K, S, n, T);
            result.PutResult = _putCalculator.Calculate(K, S, r, t, sigma, n, T, result.BtResult);

            return result;
        }

        public CalculatorResult CalculateBtKi(double K, double S, double r, double t, double sigma, int n, double T, int i, BtResult BtK_1)
        {
            CalculatorResult result = new CalculatorResult();

            result.ResultNumber = i;
            result.BtResult = _btCalculator.CalculateBtK(r, sigma, t, K, S, n, T, BtK_1);
            result.PutResult = _putCalculator.Calculate(K, S, r, t, sigma, n, T, result.BtResult);

            return result;
        }
    }
}
