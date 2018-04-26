using AmericanOptions.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AmericanOptions.ClickHelpers
{
   internal class ResultsCreator
   {
      internal List<Label> CreateResultsLabels(List<Result> results, string text)
      {
         List<Label> labels = new List<Label>();

         foreach (var result in results)
         {
            int x = result.ResultNumber;
            int y = x * 16 + 16;

            Label label = new Label();
            label.AutoSize = true;
            label.Size = new Size(60, 13);
            label.Location = new Point(6, y);
            label.Text = string.Format(text, x);

            Label resultLabel = new Label();
            resultLabel.Size = new Size(50, 13);
            resultLabel.Location = new Point(label.Size.Width, y);
            resultLabel.Text = Math.Round(result.Value, 4).ToString();

            labels.Add(label);
            labels.Add(resultLabel);
         }


         return labels;
      }
   }
}
