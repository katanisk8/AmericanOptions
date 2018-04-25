namespace AmericanOptions.PutOptions
{
    internal class AmercianPut
    {
        internal double Calculate(double K, double S, double r, double t, double sigma, double n, double T, double Btksi)
        {
            double europeanPut = new EuropeanPut().Calculate(K, S, r, t, sigma);
            double putIntegralFunction = new PutIntegralFunction().Calculate(n, T, r, sigma, t, S, K, Btksi);

            return europeanPut + putIntegralFunction;
        }
    }
}
