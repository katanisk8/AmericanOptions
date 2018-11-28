using AmericanOptions.Model;

namespace AmericanOptions.PutOptions
{
    public interface IAmercianPut
    {
        PutResult Calculate(double K, double S, double r, double t, double sigma, int n, double T, BtResult Btksi);
    }
}