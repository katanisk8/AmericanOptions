using AmericanOptions.Model;

namespace AmericanOptions
{
    public interface ICalculator
    {
        Result CalculateK0(double K, double S, double r, double t, double sigma, int n, double T);
        Result CalculateBtK1(double K, double S, double r, double t, double sigma, int n, double T);
        Result CalculateBtK(double K, double S, double r, double t, double sigma, int n, double T, int i, double BtK_1);
    }
}