using M = MathNet.Numerics.Distributions;

namespace AmericanOptions.Helpers
{
    public class Normal : INormal
    {
        public double CDF(double val)
        {
            return new M.Normal().CumulativeDistribution(val);
        }
    }
}
