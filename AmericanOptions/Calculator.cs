using System.Linq;
using AmericanOptions.Helpers;
using AmericanOptions.OptimalExerciseBoundary;
using AmericanOptions.PutOptions;

namespace AmericanOptions
{
   public class Calculator
   {
      public Results Calcluate(double r, double sigma, double t, double K, double S, int k, int n, double T)
      {
         Results results = new Results();
         BtCalculator btCalculator = new BtCalculator();
         AmercianPut putCalculator = new AmercianPut();

         Result btk1 = new Result();
         Result btk = new Result();
         
         for (int i = 0; i < k; i++)
         {
            if (i == 0)
            {
               Result btk0 = btCalculator.CalculateBtK0(i, K);

               results.BtResults.Add(btk0);
               results.PutResults.Add(putCalculator.Calculate(K, S, r, t, sigma, n, T, btk0.Value, i));
            }
            else if (i == 1)
            {
               btk1 = btCalculator.CalculateBtK1(r, sigma, t, K, S, i, n, T);

               results.BtResults.Add(btk1);
               results.PutResults.Add(putCalculator.Calculate(K, S, r, t, sigma, n, T, btk1.Value, i));
            }
            else
            {
               btk = btCalculator.CalculateBtK(r, sigma, t, K, S, i, n, T, btk1.Value);

               if (double.IsNaN(btk.Value))
               {
                  break;
               }

               results.BtResults.Add(btk);
               results.PutResults.Add(putCalculator.Calculate(K, S, r, t, sigma, n, T, btk.Value, i));
  
               btk1 = btk;
            }
         }

         return results;
      }
   }
}
