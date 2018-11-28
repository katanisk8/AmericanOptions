using AmericanOptions.Model;
using System.Threading.Tasks;

namespace AmericanOptions.PutOptions
{
    public interface IPutIntegralFunction
    {
        Task<IntegralFunction> CalculateAsync(int n, double T, double r, double sigma, double t, double S, double K, BtResult Btksi);
    }
}