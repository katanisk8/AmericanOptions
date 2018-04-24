using AmericanOptions.Bt;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AmericanOptions.ClickHelpers
{
    internal class ResultsCreator
    {
        internal void CreateResultLabel(Panel panel, BtResult result)
        {
            int x = result.NumberOfResult;

            Label label = new Label();
            label.Size = new Size(55, 13);
            label.Location = new Point(6, x * 16 + 16);
            label.Name = string.Format("LabelBtK={0}", x);
            label.Text = string.Format("Bt, K={0}:", x);

            Label resultLabel = new Label();
            resultLabel.Size = new Size(50, 13);
            resultLabel.Location = new Point(label.Location.X + 60, x * 16 + 16);
            resultLabel.Name = string.Format("ResultLabelBtK={0}", x);
            resultLabel.Text = Math.Round(result.Value, 4).ToString();

            panel.Controls.Add(label);
            panel.Controls.Add(resultLabel);
        }
    }
}
