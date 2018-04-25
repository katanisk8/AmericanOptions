using System;
using System.Drawing;
using System.Windows.Forms;

namespace AmericanOptions
{
   public class InputsValidator
   {
      internal void ValidateTextBoxInput(TextBox textBox)
      {
         ValidateText(textBox);
         ValidateNumber(textBox);
      }

      private void ValidateText(TextBox textBox)
      {
         string inputText = textBox.Text;

         if (string.IsNullOrEmpty(inputText) || string.IsNullOrWhiteSpace(inputText))
         {
            string message = string.Format("Input \"{0}\" cannot be empty!", textBox.Tag);
            SetTextBoxInExceptionMode(textBox);
            throw new Exception(message);
         }
         else
         {
            SetTextBoxInNormalMode(textBox);
         }
      }

      private void ValidateNumber(TextBox textBox)
      {
         string inputText = textBox.Text;

         if (!double.TryParse(inputText, out double result))
         {
            string message = string.Format("Input \"{0}\" must be a number!", textBox.Tag);
            SetTextBoxInExceptionMode(textBox);
            throw new Exception(message);
         }
         else
         {
            SetTextBoxInNormalMode(textBox);
         }
      }

      private void SetTextBoxInExceptionMode(TextBox textBox)
      {
         textBox.BackColor = Color.IndianRed;
         textBox.Select();
      }

      private void SetTextBoxInNormalMode(TextBox textBox)
      {
         textBox.BackColor = Color.White;
      }
   }
}
