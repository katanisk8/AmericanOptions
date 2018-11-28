using AmericanOptions.Model;
using System.Threading.Tasks;

namespace AmericanOptions.PutOptions
{
    public interface IAmercianPut
    {
       Task<PutResult> CalculateAsync(double K, double S, double r, double t, double sigma, int n, double T, BtResult Btksi);
    }
}