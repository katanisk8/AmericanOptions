using MathNet.Numerics.Distributions;

namespace AmericanOptions.CalculationHelpers
{
    internal class StandardNormalDistribution
    {
        internal double CalculatePDF(double integralPointD1)
        {
            return new Normal().Density(integralPointD1);
        }
    }
}
