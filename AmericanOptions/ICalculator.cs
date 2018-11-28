using System.Threading.Tasks;
using AmericanOptions.Model;

namespace AmericanOptions
{
    public interface ICalculator
    {
       Task<Result> CalculateK0(double K, double S, double r, double t, double sigma, int n, double T);
       Task<Result> CalculateBtK1(double K, double S, double r, double t, double sigma, int n, double T);
       Task<Result> CalculateBtK(double K, double S, double r, double t, double sigma, int n, double T, int i, double BtK_1);
    }
}