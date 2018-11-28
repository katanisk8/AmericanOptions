using System.Threading.Tasks;

namespace AmericanOptions.PutOptions
{
    public interface IAmercianPut
    {
       Task<double> Calculate(double K, double S, double r, double t, double sigma, int n, double T, double Btksi);
    }
}