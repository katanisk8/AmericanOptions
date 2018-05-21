using AmericanOptions.Model;
using System.Windows.Forms;

namespace AmericanOptions.ClickHelpers
{
    public interface IResultsCreator
    {
        Label[] CreateResultsLabels(Result[] results);
    }
}