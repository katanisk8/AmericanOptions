namespace AmericanOptions.PutOptions
{
    public class AmercianPut : IAmercianPut
    {
        IEuropeanPut europeanPut;
        IPutIntegralFunction putIntegralFunction;

        public AmercianPut(IEuropeanPut _europeanPut, IPutIntegralFunction _putIntegralFunction)
        {
            europeanPut = _europeanPut;
            putIntegralFunction = _putIntegralFunction;
        }

        public double Calculate(double K, double S, double r, double t, double sigma, int n, double T, double Btksi)
        {
            double europeanPutValue = europeanPut.Calculate(K, S, r, t, sigma);
            double putIntegralFunctionValue = putIntegralFunction.Calculate(n, T, r, sigma, t, S, K, Btksi);

            return europeanPutValue + putIntegralFunctionValue;
        }
    }
}