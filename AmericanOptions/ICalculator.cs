using AmericanOptions.Model;

namespace AmericanOptions
{
    public interface ICalculator
    {
        CalculatorResult[] Calculate(double r, double sigma, double t, double K, double S, int k, int n, double T);
        CalculatorResult CalculateK0(double K, double S, double r, double t, double sigma, int n, double T);
        CalculatorResult CalculateBtK1(double K, double S, double r, double t, double sigma, int n, double T);
        CalculatorResult CalculateBtKi(double K, double S, double r, double t, double sigma, int n, double T, int i, BtResult BtK_1);
    }
}