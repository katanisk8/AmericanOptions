using AmericanOptions.OptimalExerciseBoundary;
using Moq;
using Xunit;

namespace AmericanOptionsTest
{
    public class BtIntegralFunctionTest
    {
        int n = 4;
        double T = 1;
        double r = 0.05;
        double sigma = 0.2;
        double t = 1;
        double d2 = -0.81945721667909832;


        [Fact]
        public void CalculateTest()
        {
            Mock<BtIntegralFunction> integral = new Mock<BtIntegralFunction>();

            double integralValue = integral.Object.Calculate(n, T, r, sigma, t, d2);

            Assert.Equal(0.33245806127914307, integralValue);
        }
    }
}
