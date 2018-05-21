namespace AmericanOptions.OptimalExerciseBoundary
{
    public interface IBtIntegralFunction
    {
        double Calculate(int n, double T, double r, double sigma, double t, double d2);
    }
}