using System.Threading.Tasks;

namespace AmericanOptions.OptimalExerciseBoundary
{
    public interface IBtCalculator
    {
       double CalculateBtK1(double r, double sigma, double t, double K, double S, int n, double T);
       Task<double> CalculateBtK(double r, double sigma, double t, double K, double S, int n, double T, double BtK_1);
    }
}