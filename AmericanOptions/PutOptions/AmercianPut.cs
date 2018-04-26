using AmericanOptions.Helpers;
using System.Collections.Generic;

namespace AmericanOptions.PutOptions
{
   internal class AmercianPut
   {
      internal Result Calculate(double K, double S, double r, double t, double sigma, int n, double T, double Btksi, int k)
      {

         double europeanPut = new EuropeanPut().Calculate(K, S, r, t, sigma);
         double putIntegralFunction = new PutIntegralFunction().Calculate(n, T, r, sigma, t, S, K, Btksi);
         double result = europeanPut + putIntegralFunction;
         
         return new Result { ResultNumber = k, Value = result };
      }
   }
}