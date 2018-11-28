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

      public Result CalculateK0(double K, double S, double r, double t, double sigma, int n, double T)
      {
         Result result = new Result();

         result.ResultNumber = 0;

         result.BtValue = K;
         result.BtRoundedValue = Math.Round(K, 4);

         result.PutValue = _putCalculator.Calculate(K, S, r, t, sigma, n, T, K);
         result.PutRoundedValue = Math.Round(result.PutValue, 4);

         return result;
      }

      public Result CalculateBtK1(double K, double S, double r, double t, double sigma, int n, double T)
      {
         Result result = new Result();

         result.ResultNumber = 1;

         result.BtValue = _btCalculator.CalculateBtK1(r, sigma, t, K, S, n, T);
         result.BtRoundedValue = Math.Round(result.BtValue, 4);

         result.PutValue = _putCalculator.Calculate(K, S, r, t, sigma, n, T, result.BtValue);
         result.PutRoundedValue = Math.Round(result.PutValue, 4);

         return result;
      }

      public Result CalculateBtK(double K, double S, double r, double t, double sigma, int n, double T, int i, double BtK_1)
      {
         Result result = new Result();

         result.ResultNumber = i;

         result.BtValue = _btCalculator.CalculateBtK(r, sigma, t, K, S, n, T, BtK_1);
         result.BtRoundedValue = Math.Round(result.BtValue, 4);

         result.PutValue = _putCalculator.Calculate(K, S, r, t, sigma, n, T, result.BtValue);
         result.PutRoundedValue = Math.Round(result.PutValue, 4);

         return result;
      }
   }
}
