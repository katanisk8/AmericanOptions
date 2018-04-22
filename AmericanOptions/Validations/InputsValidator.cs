using System;
using System.Windows.Forms;

namespace AmericanOptions
{
    public class InputsValidator
    {
        internal void ValidateTextBoxInput(TextBox riskFreeRateTextBox)
        {
            string inputText = riskFreeRateTextBox.Text;

            if (string.IsNullOrEmpty(inputText) || string.IsNullOrWhiteSpace(inputText))
            {
                string message = string.Format("Input \"{0}\" cannot be empty!", riskFreeRateTextBox.Tag);
                throw new Exception(message);
            }
        }
    }
}
