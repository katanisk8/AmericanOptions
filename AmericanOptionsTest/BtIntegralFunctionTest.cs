using AmericanOptions.Model;
using AmericanOptions.OptimalExerciseBoundary;
using Xunit;

namespace AmericanOptionsTest
{
   public class BtIntegralFunctionTest
   {
      private int n = 4;
      private double T = 1;
      private double r = 0.05;
      private double sigma = 0.2;
      private double t = 1;
      private IntegralPoint d2 = new IntegralPoint { Result = new Result { Value = -0.81945721667909832 } };

      [Fact]
      public async void CalculateTest()
      {
         BtIntegralFunction integral = new BtIntegralFunction();

         var integralValue = await integral.CalculateAsync(n, T, r, sigma, t, d2);

         Assert.Equal(0.33245806127914307, integralValue.Result.Value);
      }
   }
}
