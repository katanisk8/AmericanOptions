using AmericanOptions;
using AmericanOptions.Model;
using AmericanOptions.OptimalExerciseBoundary;
using AmericanOptions.PutOptions;
using Moq;
using Xunit;

namespace AmericanOptionsTest
{
    public class CalculatorTest
    {
        double r = 0.05;
        double sigma = 0.02;
        double t = 1;
        double K = 45;
        double S = 45;
        int k = 100;
        int n = 4;
        double T = 1;

        [Fact]
        public void CalculateTest()
        {
            Mock<BtCalculator> btCalculator = new Mock<BtCalculator>();
            Mock<AmercianPut> putCalculator = new Mock<AmercianPut>();

            Calculator calculator = new Calculator(btCalculator.Object, putCalculator.Object);
            
            var watch = System.Diagnostics.Stopwatch.StartNew();

            Result[] integralValue = calculator.Calculate(r, sigma, t, K, S, k, n, T);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

        }
    }
}
