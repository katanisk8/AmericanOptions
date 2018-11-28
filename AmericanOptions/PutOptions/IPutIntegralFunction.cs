using System.Threading.Tasks;

namespace AmericanOptions.PutOptions
{
    public interface IPutIntegralFunction
    {
       Task<double> Calculate(int n, double T, double r, double sigma, double t, double S, double K, double Btksi);
    }
}