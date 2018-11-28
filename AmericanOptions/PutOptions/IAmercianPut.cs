namespace AmericanOptions.PutOptions
{
    public interface IAmercianPut
    {
        double Calculate(double K, double S, double r, double t, double sigma, int n, double T, double Btksi);
    }
}