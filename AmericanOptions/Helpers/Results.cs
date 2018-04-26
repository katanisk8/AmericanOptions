using System.Collections.Generic;
using System.Linq;

namespace AmericanOptions.Helpers
{
    internal class Results
    {
        internal List<Result> BtResults;
        internal List<Result> PutResults;

        public Results()
        {
            BtResults = new List<Result>();
            PutResults = new List<Result>();
        }
    }
}
