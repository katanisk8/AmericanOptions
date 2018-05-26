using AmericanOptions.Model;

namespace AmericanOptions.Helpers
{
    public interface IIntegralPoints
    {
        IntegralPoint CalculateIntegralPointD1(double S, double B, double r, double sigma, double t);
        IntegralPoint CalculateIntegralPointD2(IntegralPoint d1, double sigma, double t);
    }
}