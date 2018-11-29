using System;
using System.Drawing;
using System.Windows.Forms;

namespace AmericanOptions.Validations
{
   public class InputsValidator : IInputsValidator
   {
      public void ValidateInput(Control control)
      {
         ValidateText(control);
         ValidateNumber(control);
      }

      public void ValidateIterationNumber(Control control, int maxValue)
      {
         ValidateText(control);
         double numberOfIterration = ValidateNumber(control);

         if (numberOfIterration > maxValue)
         {
            SetControlInExceptionMode(control);
            throw new Exception($"Max value for \"{control.Tag}\" is {maxValue}");
         }

         SetControlInNormalMode(control);
      }

      private void ValidateText(Control control)
      {
         string inputText = control.Text;

         if (string.IsNullOrEmpty(inputText) || string.IsNullOrWhiteSpace(inputText))
         {
            string message = $"Input \"{control.Tag}\" cannot be empty!";
            SetControlInExceptionMode(control);
            throw new Exception(message);
         }

         SetControlInNormalMode(control);
      }

      private double ValidateNumber(Control control)
      {
         if (!double.TryParse(control.Text, out double result))
         {
            string message = $"Input \"{control.Tag}\" must be a number!";
            SetControlInExceptionMode(control);
            throw new Exception(message);
         }

         SetControlInNormalMode(control);

         return result;
      }

      private void SetControlInExceptionMode(Control control)
      {
         control.BackColor = Color.IndianRed;
         control.Select();
      }

      private void SetControlInNormalMode(Control control)
      {
         control.BackColor = Color.White;
      }
   }
}
