using System.IO;
using System.Windows.Forms;

namespace AmericanOptions.Windows
{
   public partial class Help : Form
   {
      public Help()
      {
         InitializeComponent();
      }

      private void axAcroPDF1_Enter(object sender, System.EventArgs e)
      {
         pDFDocumencation.src = Path.GetFullPath(@"Source\Documentation.pdf");
      }
   }
}
