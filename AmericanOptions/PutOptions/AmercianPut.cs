using AmericanOptions.Model;

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

        public PutResult Calculate(double K, double S, double r, double t, double sigma, int n, double T, BtResult Btksi)
        {
            PutResult put = new PutResult();

            put.EuropeanPut = _europeanPut.Calculate(K, S, r, t, sigma);
            put.PutIntegralFunction = _putIntegralFunction.Calculate(n, T, r, sigma, t, S, K, Btksi);
            put.Value = put.EuropeanPut.Value + put.PutIntegralFunction.Value;

            return put;
        }
    }
}