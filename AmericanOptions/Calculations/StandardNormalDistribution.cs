using MathNet.Numerics.Distributions;

namespace AmericanOptions.Calculations
{
    public class StandardNormalDistribution
    {
        public double CalculatePDF(double integralPointD1)
        {
            return new Normal().Density(integralPointD1);
        }
    }
}
