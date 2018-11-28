using AmericanOptions.Model;
using System.Threading.Tasks;

namespace AmericanOptions.OptimalExerciseBoundary
{
    public interface IBtIntegralFunction
    {
       Task<IntegralFunction> CalculateAsync(int n, double T, double r, double sigma, double t, IntegralPoint D2);
    }
}