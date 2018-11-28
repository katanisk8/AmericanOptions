using System.Drawing;
using System.Windows.Forms;

namespace AmericanOptions.ClickHelpers
{
    public class Cleaner : ICleaner
    {
        public void CleanTextBoxes(GroupBox groupbox)
        {
            foreach (Control control in groupbox.Controls)
            {
                if (control is TextBox)
                {
                    control.ResetText();
                    control.BackColor = Color.White;
                }
            }
        }
    }
}
