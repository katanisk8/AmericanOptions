using AmericanOptions.Bt;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AmericanOptions.ClickHelpers
{
    internal class ResultsCreator
    {
        internal void CreateResultsLabels(Panel panel, BtResult result)
        {
            int x = result.ResultNumber;
            int y = x * 16 + 16;

            Label label = new Label();
            label.AutoSize = true;
            label.Size = new Size(60, 13);
            label.Location = new Point(6, y);
            label.Name = string.Format("LabelBtk={0}", x);
            label.Text = string.Format("Bt, k={0}:", x);

            Label resultLabel = new Label();
            resultLabel.Size = new Size(50, 13);
            resultLabel.Location = new Point(label.Size.Width, y);
            resultLabel.Name = string.Format("ResultLabelBtK={0}", x);
            resultLabel.Text = Math.Round(result.Value, 4).ToString();

            panel.Controls.Add(label);
            panel.Controls.Add(resultLabel);
        }
    }
}
