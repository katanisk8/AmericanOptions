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
      private double d2 = -0.81945721667909832;


        [Fact]
        public void CalculateTest()
        {
            BtIntegralFunction integral = new BtIntegralFunction();

            double integralValue = integral.Calculate(n, T, r, sigma, t, d2);

            Assert.Equal(0.33245806127914307, integralValue);
        }
    }
}
