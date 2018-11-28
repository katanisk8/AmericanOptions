using System.Threading.Tasks;

namespace AmericanOptions.PutOptions
{
   public class AmercianPut : IAmercianPut
   {
      private readonly IEuropeanPut _europeanPut;
      private readonly IPutIntegralFunction _putIntegralFunction;

      public AmercianPut(IEuropeanPut europeanPut, IPutIntegralFunction putIntegralFunction)
      {
         _europeanPut = europeanPut;
         _putIntegralFunction = putIntegralFunction;
      }

      public async Task<double> Calculate(double K, double S, double r, double t, double sigma, int n, double T, double Btksi)
      {
         double europeanPutValue = _europeanPut.Calculate(K, S, r, t, sigma);
         double putIntegralFunctionValue = await _putIntegralFunction.Calculate(n, T, r, sigma, t, S, K, Btksi);

         return europeanPutValue + putIntegralFunctionValue;
      }
   }
}