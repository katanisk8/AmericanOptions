using AmericanOptions.Model;
using System.Drawing;
using System.Windows.Forms;

namespace AmericanOptions.ClickHelpers
{
    public class ResultsCreator : IResultsCreator
    {
        public Label[] CreateResultsLabels(Result[] results)
        {
            Label[] labels = new Label[results.Length];
            string text = "k = {0}   Bt = {1}   P = {2}";

            for (int i = 0; i < results.Length; i++)
            {
                int x = results[i].ResultNumber;
                int y = x * 16;

                Label label = new Label();
                label.AutoSize = true;
                label.Size = new Size(60, 13);
                label.Location = new Point(6, y);
                label.Text = string.Format(text, x, results[i].BtRoundedValue, results[i].PutRoundedValue);

                labels[i] = label;
            }

            return labels;
        }
    }
}
