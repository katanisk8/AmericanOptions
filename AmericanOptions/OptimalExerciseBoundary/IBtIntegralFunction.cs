using System.Threading.Tasks;

namespace AmericanOptions.OptimalExerciseBoundary
{
    public interface IBtIntegralFunction
    {
       Task<double> Calculate(int n, double T, double r, double sigma, double t, double d2);
    }
}