using AmericanOptions.Helpers;
using System.Drawing;
using System.Windows.Forms;

namespace AmericanOptions.ClickHelpers
{
    public class ResultsCreator
    {
        public Label[] CreateResultsLabels(Result[] results, string text)
        {
            Label[] labels = new Label[results.Length];

            for (int i = 0; i < results.Length; i++)
            {
                int x = results[i].ResultNumber;
                int y = x * 16;

                Label label = new Label();
                label.AutoSize = true;
                label.Size = new Size(60, 13);
                label.Location = new Point(6, y);
                label.Text = string.Format(text, x, results[i].BtRoundedValue, x, results[i].PutRoundedValue);

                labels[i] = label;
            }

            return labels;
        }
    }
}
