namespace AmericanOptions.Helpers
{
    public interface IIntegralPoints
    {
        double CalculateIntegralPointD1(double S, double B, double r, double sigma, double t);
        double CalculateIntegralPointD2(double d1, double sigma, double t);
    }
}