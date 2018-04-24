using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AmericanOptions.ClickHelpers
{
    internal static class Clean
    {

        internal static void CleanResultsLabels(Panel resultsPanel)
        {
            List<Control> labelList = GetAll(resultsPanel, typeof(Label)).ToList();

            foreach (var control in labelList)
            {
                resultsPanel.Controls.Remove((Label)control);
            }
        }

        internal static void CleanTextBoxes(MainForm form)
        {
            List<Control> textBoxList = GetAll(form, typeof(TextBox)).ToList();

            foreach (Control c in textBoxList)
            {
                TextBox textBox = (TextBox)c;
                textBox.Text = string.Empty;
                textBox.BackColor = Color.White;
            }
        }

        private static IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }
    }
}
