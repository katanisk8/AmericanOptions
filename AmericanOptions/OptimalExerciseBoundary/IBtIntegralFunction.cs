using AmericanOptions.Model;

namespace AmericanOptions.OptimalExerciseBoundary
{
    public interface IBtIntegralFunction
    {
        BtIntegralFunctionResult Calculate(int n, double T, double r, double sigma, double t, IntegralPoint d2);
    }
}