namespace AmericanOptions.Model
{
    public class UnderIntegral
    {
        public int ResultNumber;
        public double h;
        public double ksi;
        public IntegralPoint IntegralPointD1;
        public IntegralPoint IntegralPointD2;
        public double Distribution;
        public Result Result;

        public UnderIntegral()
        {
            Result = new Result();
        }
    }
}