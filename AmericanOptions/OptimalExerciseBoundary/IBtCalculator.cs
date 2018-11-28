using AmericanOptions.Model;
using System.Threading.Tasks;

namespace AmericanOptions.OptimalExerciseBoundary
{
    public interface IBtCalculator
    {
        BtResult CalculateBtK0(double k);
        BtResult CalculateBtK1(double r, double sigma, double t, double K, double S, int n, double T);
        Task<BtResult> CalculateBtKAsync(double r, double sigma, double t, double K, double S, int n, double T, double BtK_1);
    }
}