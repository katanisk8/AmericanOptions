using AmericanOptions.Model;
using AmericanOptions.OptimalExerciseBoundary;
using AmericanOptions.PutOptions;
using System;
using System.Threading.Tasks;

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

        public async Task<CalculatorResult[]> CalculateAsync(double r, double sigma, double t, double K, double S, int k, int n, double T)
        {
            CalculatorResult[] results = new CalculatorResult[k];

            results[0] = await CalculateK0Async(K, S, r, t, sigma, n, T);
            results[1] = await CalculateBtK1Async(K, S, r, t, sigma, n, T);

            for (int i = 2; i < k; i++)
            {
                results[i] = await CalculateBtKiAsync(K, S, r, t, sigma, n, T, i, results[i - 1].BtResult);

                if (double.IsNaN(results[i].BtResult.Result.Value))
                {
                    Array.Resize(ref results, i);
                    break;
                }
            }

            return results;
        }

        public async Task<CalculatorResult> CalculateK0Async(double K, double S, double r, double t, double sigma, int n, double T)
        {
            CalculatorResult result = new CalculatorResult();

            result.ResultNumber = 0;
            result.BtResult = _btCalculator.CalculateBtK0(K);
            result.PutResult = await _putCalculator.CalculateAsync(K, S, r, t, sigma, n, T, result.BtResult);

            return result;
        }

        public async Task<CalculatorResult> CalculateBtK1Async(double K, double S, double r, double t, double sigma, int n, double T)
        {
            CalculatorResult result = new CalculatorResult();

            result.ResultNumber = 1;
            result.BtResult = _btCalculator.CalculateBtK1(r, sigma, t, K, S, n, T);
            result.PutResult = await _putCalculator.CalculateAsync(K, S, r, t, sigma, n, T, result.BtResult);

            return result;
        }

        public async Task<CalculatorResult> CalculateBtKiAsync(double K, double S, double r, double t, double sigma, int n, double T, int i, BtResult BtK_1)
        {
            CalculatorResult result = new CalculatorResult();

            result.ResultNumber = i;
            result.BtResult = await _btCalculator.CalculateBtKAsync(r, sigma, t, K, S, n, T, BtK_1);
            result.PutResult = await _putCalculator.CalculateAsync(K, S, r, t, sigma, n, T, result.BtResult);

            return result;
        }
    }
}
