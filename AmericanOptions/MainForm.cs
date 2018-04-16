using System;
using System.Windows.Forms;
using MathNet.Numerics.Distributions;

namespace AmericanOptions
{
   public partial class MainForm : Form
    {
        double riskFreeRate;
        double volatilitySigma;
        double tau;
        double integralPointD1;
        double integralPointD2;
        double distribution;
        double BtK1;
        double strikePrice;

        public MainForm()
        {
            InitializeComponent();
        }

        private void AssignVariables()
        {
            strikePrice = Convert.ToDouble(StrikePriceTextBox.Text);
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            AssignVariables();
            CalculateIntegralPoints();
            CalculateStandardNormalDistribution();
            CalculateBtK1();
        }

        private void CalculateIntegralPoints()
        {
            riskFreeRate = Convert.ToDouble(RiskFreeRateTextBox.Text);
            volatilitySigma = Convert.ToDouble(VolatilitySigmaTextBox.Text);
            tau = Convert.ToDouble(TauTextBox.Text);

            var integralPoints = new IntegralPoints();

            var numerator = integralPoints.CalculateD1Numerator(riskFreeRate, volatilitySigma, tau);
            var denominator = integralPoints.CalculateD1Denominator(volatilitySigma, tau);

            integralPointD1 = numerator / denominator;
            integralPointD2 = integralPointD1 - denominator;

            IntegralPointD1TextBox.Text = integralPointD1.ToString("F04");
            IntegralPointD2TextBox.Text = integralPointD2.ToString("F04");
        }
        
        private void CalculateStandardNormalDistribution()
        {
            distribution = new Normal().Density(integralPointD1);

            DistributionTextBox.Text = distribution.ToString("F04");
        }
        
        private void CalculateBtK1()
        {
            double a = (1 / volatilitySigma * Math.Sqrt(2 * Math.PI * tau));

            BtK1 = (strikePrice * (1 /(distribution + a) * Math.Exp(-0.5 * integralPointD1 * integralPointD1))) * 
                (a * Math.Exp(-((riskFreeRate * tau) + (0.5 * integralPointD2 * integralPointD2)))) + 
                (((2 * volatilitySigma * riskFreeRate)/((2 * riskFreeRate) + (volatilitySigma * volatilitySigma))) * (2 * distribution) - 1);

            BtK1TextBox.Text = BtK1.ToString("F04");
        }
    }
}
