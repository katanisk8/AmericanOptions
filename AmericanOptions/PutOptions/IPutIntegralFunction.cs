using AmericanOptions.Model;

namespace AmericanOptions.PutOptions
{
    public interface IPutIntegralFunction
    {
        PutIntegralFunctionResult Calculate(int n, double T, double r, double sigma, double t, double S, double K, BtResult Btksi);
    }
}