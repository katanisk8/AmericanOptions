using System.Drawing;
using System.Windows.Forms;

namespace AmericanOptions.ClickHelpers
{
    public class Cleaner : ICleaner
    {

        public void CleanResultsLabels(Panel panel)
        {
            panel.Controls.Clear();
        }

        public void CleanTextBoxes(GroupBox groupbox)
        {
            foreach (Control control in groupbox.Controls)
            {
                if (control is TextBox || control is NumericUpDown)
                {
                    control.ResetText();
                    control.BackColor = Color.White;
                }
            }
        }
    }
}
