using Xunit;
using AmericanOptions.Helpers;

namespace AmericanOptionsTest
{
    public class IntegralPointsUnitTest
    {
        double S = 45;
        double B = 45;
        double r = 0.05;
        double sigma = 0.2;
        double t = 1;

        [Fact]
        public void CalculateIntegralPointD1Test()
        {
            IntegralPoints integralPoints = new IntegralPoints();

            double d1 = integralPoints.CalculateIntegralPointD1(S, B, r, sigma, t);

            Assert.Equal(0.35000000000000003, d1);
        }

        [Fact]
        public void CalculateIntegralPointD2Test()
        {
            IntegralPoints integralPoints = new IntegralPoints();

            double d1 = integralPoints.CalculateIntegralPointD1(S, B, r, sigma, t);
            double d2 = integralPoints.CalculateIntegralPointD2(d1, sigma, t);

            Assert.Equal(0.15000000000000002, d2);
        }
    }
}
