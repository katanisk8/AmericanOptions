using AmericanOptions;
using AmericanOptions.Helpers;
using System.Linq;
using Xunit;

namespace AmericanOptionsUnitTest
{
    public class CalculationsUnitTests
    {
        // Inputs
        private double riskFreeRate = 0.05;
        private double volatilitySigma = 0.2;
        private double tau = 1;
        private double strikePrice = 45;
        private double stockPrice = 45;
        private int numberOfIterration = 16;
        private int numberOfNodes = 4;
        private double timeToMaturity = 1;

        [Fact]
        public void CalculateTest()
        {
            Result[] results = new Calculator().Calculate(
                       riskFreeRate,
                       volatilitySigma,
                       tau,
                       strikePrice,
                       stockPrice,
                       numberOfIterration,
                       numberOfNodes,
                       timeToMaturity);

            var x = results.ToArray();
            var y = results[0].
        }
    }
}