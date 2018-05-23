using System.Windows.Forms;

namespace AmericanOptions.Validations
{
    public interface IInputsValidator
    {
        void ValidateInput(Control control);
    }
}