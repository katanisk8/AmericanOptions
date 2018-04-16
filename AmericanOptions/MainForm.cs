using System;
using System.Windows.Forms;

namespace AmericanOptions
{
   public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            CalculateIntegralPoints();
        }

        private void CalculateIntegralPoints()
        {
            var riskFreeRate = Convert.ToDecimal(RiskFreeRateTextBox.Text);
            var volatilitySigma = Convert.ToDecimal(VolatilitySigmaTextBox.Text);
            var tau = Convert.ToDecimal(TauTextBox.Text);

            var integralPoints = new IntegralPoints();

            var numerator = integralPoints.CalculateD1Numerator(riskFreeRate, volatilitySigma, tau);
            var denominator = integralPoints.CalculateD1Denominator(volatilitySigma, tau);

            var integralPointD1 = numerator / denominator;
            var integralPointD2 = integralPointD1 - denominator;

            IntegralPointD1TextBox.Text = integralPointD1.ToString("E04");
            IntegralPointD2TextBox.Text = integralPointD2.ToString("E04");
        }
    }
}
