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
      private double r = 0.05;
      private double sigma = 0.02;
      private double t = 1;
      private double K = 45;
      private double S = 45;
      private int k = 3;
      private int n = 4;
      private double T = 1;

        [Fact]
        public void CalculateTest()
        {
            Mock<IBtCalculator> btCalculator = new Mock<IBtCalculator>();
            Mock<IAmercianPut> putCalculator = new Mock<IAmercianPut>();
         
            Calculator calculator = new Calculator(btCalculator.Object, putCalculator.Object);
            
            var watch = System.Diagnostics.Stopwatch.StartNew();

            Result[] results = calculator.Calculate(r, sigma, t, K, S, k, n, T);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
        }
    }
}
