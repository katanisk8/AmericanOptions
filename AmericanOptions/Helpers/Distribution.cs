using MathNet.Numerics.Distributions;

namespace AmericanOptions.Helpers
{
    public class Distribution
    {
        public double CDF(double val)
        {
            return new Normal().CumulativeDistribution(val);
        }
    }
}
