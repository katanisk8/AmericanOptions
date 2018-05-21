namespace AmericanOptions.PutOptions
{
    public interface IEuropeanPut
    {
        double Calculate(double K, double S, double r, double t, double sigma);
    }
}