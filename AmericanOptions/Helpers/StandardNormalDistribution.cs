using MathNet.Numerics.Distributions;

namespace AmericanOptions.Helpers
{
    internal class StandardNormalDistribution
    {
        internal double CalculatePDF(double integralPointD1)
        {
            return new Normal().Density(integralPointD1);
        }
    }
}
