using AmericanOptions.Model;
using System.Threading.Tasks;

namespace AmericanOptions.PutOptions
{
    public class AmercianPut : IAmercianPut
    {
        private readonly IEuropeanPut _europeanPut;
        private readonly IPutIntegralFunction _putIntegralFunction;

        public AmercianPut(IEuropeanPut europeanPut, IPutIntegralFunction putIntegralFunction)
        {
            _europeanPut = europeanPut;
            _putIntegralFunction = putIntegralFunction;
        }

        public async Task<PutResult> CalculateAsync(double K, double S, double r, double t, double sigma, int n, double T, BtResult Btksi)
        {
            PutResult put = new PutResult();

            put.EuropeanPut = _europeanPut.Calculate(K, S, r, t, sigma);
            put.PutIntegralFunction = await _putIntegralFunction.CalculateAsync(n, T, r, sigma, t, S, K, Btksi);
            put.Result.Value = put.EuropeanPut.Result.Value + put.PutIntegralFunction.Result.Value;

            return put;
        }
    }
}