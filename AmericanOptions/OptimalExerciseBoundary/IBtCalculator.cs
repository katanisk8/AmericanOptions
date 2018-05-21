namespace AmericanOptions.OptimalExerciseBoundary
{
    public interface IBtCalculator
    {
        double CalculateBtK1(double r, double sigma, double t, double K, double S, int n, double T);
        double CalculateBtK(double r, double sigma, double t, double K, double S, int n, double T, double BtK_1);
    }
}