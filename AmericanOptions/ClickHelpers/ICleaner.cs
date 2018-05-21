using System.Windows.Forms;

namespace AmericanOptions.ClickHelpers
{
    public interface ICleaner
    {
        void CleanResultsLabels(Panel panel);
        void CleanTextBoxes(GroupBox groupbox);
    }
}