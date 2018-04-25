using System.Collections.Generic;

namespace AmericanOptions.Helpers
{
    internal class Results
    {
        internal IEnumerable<Result> BtResults;
        internal IEnumerable<Result> PutResults;

        public Results()
        {
            BtResults = new List<Result>();
            PutResults = new List<Result>();
        }
    }
}
