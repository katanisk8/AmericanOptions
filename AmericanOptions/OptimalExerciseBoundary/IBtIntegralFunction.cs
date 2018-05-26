using AmericanOptions.Model;

namespace AmericanOptions.OptimalExerciseBoundary
{
    public interface IBtIntegralFunction
    {
        IntegralFunction Calculate(int n, double T, double r, double sigma, double t, IntegralPoint D2);
    }
}