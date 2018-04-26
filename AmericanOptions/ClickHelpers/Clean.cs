using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AmericanOptions.ClickHelpers
{
    internal class Clean
    {

        internal void CleanResultsLabels(Panel panel)
        {
            panel.Controls.Clear();
        }

        internal void CleanTextBoxes(GroupBox groupbox)
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
