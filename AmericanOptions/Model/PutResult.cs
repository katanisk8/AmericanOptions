namespace AmericanOptions.Model
{
    public class PutResult
    {
        public EuropeanPutResult EuropeanPut;
        public IntegralFunction PutIntegralFunction;
        public Result Result;

        public PutResult()
        {
            Result = new Result();
        }
    }
}