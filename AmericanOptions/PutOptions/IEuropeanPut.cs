using AmericanOptions.Model;

namespace AmericanOptions.PutOptions
{
    public interface IEuropeanPut
    {
        EuropeanPutResult Calculate(double K, double S, double r, double t, double sigma);
    }
}