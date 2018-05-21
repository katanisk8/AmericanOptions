using AmericanOptions.Model;

namespace AmericanOptions
{
    public interface ICalculator
    {
        Result[] Calculate(double r, double sigma, double t, double K, double S, int k, int n, double T);
    }
}