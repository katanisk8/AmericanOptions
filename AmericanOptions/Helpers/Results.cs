using System.Collections.Generic;
using System.Linq;

namespace AmericanOptions.Helpers
{
    public class Results
    {
        internal List<Result> BtResults;
        internal List<Result> PutResults;

       internal Results()
        {
            BtResults = new List<Result>();
            PutResults = new List<Result>();
        }
    }
}
