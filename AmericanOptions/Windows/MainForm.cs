using System;
using System.Windows.Forms;
using AmericanOptions.Calculations;

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

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateInputs();
                AssignVariables();
                CalculateIntegralPoints();
                CalculateStandardNormalDistribution();
                CalculateBtK1();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ValidateInputs()
        {
            var validator = new InputsValidator();

            validator.ValidateTextBoxInput(RiskFreeRateTextBox);
            validator.ValidateTextBoxInput(VolatilitySigmaTextBox);
            validator.ValidateTextBoxInput(TauTextBox);
            validator.ValidateTextBoxInput(StrikePriceTextBox);
            validator.ValidateTextBoxInput(NumberOfIterationTextBox);
            validator.ValidateTextBoxInput(TimeToMaturityTextBox);
            validator.ValidateTextBoxInput(StockPriceTextBox);
        }

        private void AssignVariables()
        {
            strikePrice = Convert.ToDouble(StrikePriceTextBox.Text);
            riskFreeRate = Convert.ToDouble(RiskFreeRateTextBox.Text);
            volatilitySigma = Convert.ToDouble(VolatilitySigmaTextBox.Text);
            tau = Convert.ToDouble(TauTextBox.Text);
        }

        private void CalculateIntegralPoints()
        {
            var integralPoints = new IntegralPoints();
            
            integralPointD1 = integralPoints.CalculateIntegralPointD1(riskFreeRate, volatilitySigma, tau);
            integralPointD2 = integralPoints.CalculateIntegralPointD2(integralPointD1, volatilitySigma, tau);

            IntegralPointD1TextBox.Text = integralPointD1.ToString("F04");
            IntegralPointD2TextBox.Text = integralPointD2.ToString("F04");
        }
        
        private void CalculateStandardNormalDistribution()
        {
            distribution = new StandardNormalDistribution().CalculatePDF(integralPointD1);

            DistributionTextBox.Text = distribution.ToString("F04");
        }
        
        private void CalculateBtK1()
        {
            BtK1 = new BtK1().Calculate(volatilitySigma, strikePrice, distribution, integralPointD1, riskFreeRate, tau, integralPointD2);

            BtK1TextBox.Text = BtK1.ToString("F04");
        }
    }
}
