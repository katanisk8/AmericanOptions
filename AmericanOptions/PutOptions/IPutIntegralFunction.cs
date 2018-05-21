namespace AmericanOptions.PutOptions
{
    public interface IPutIntegralFunction
    {
        double Calculate(int n, double T, double r, double sigma, double t, double S, double K, double Btksi);
    }
}