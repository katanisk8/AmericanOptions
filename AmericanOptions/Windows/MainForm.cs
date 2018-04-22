using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AmericanOptions.Calculations;

namespace AmericanOptions
{
    public partial class MainForm : Form
    {
        private const string numberFormat = "F06";

        // Inputs
        private double riskFreeRate;
        private double volatilitySigma;
        private double tau;
        private double strikePrice;
        private double numberOfIterration;
        private double timeToMaturity;
        private double stockPrice;


        // Help Results
        private double integralPointD1;
        private double integralPointD2;
        private double distribution;
        private double BtK1;


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

                Calculate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CleanButton_Click(object sender, EventArgs e)
        {
            List<Control> textBoxList = GetAllTextBoxControls(this);

            foreach (Control c in textBoxList)
            {
                TextBox textBox = (TextBox)c;
                textBox.Text = string.Empty;
            }
        }

        private List<Control> GetAllTextBoxControls(Control container)
        {
            List<Control> controlList = new List<Control>();
            foreach (Control c in container.Controls)
            {
                controlList.AddRange(GetAllTextBoxControls(c));
                if (c is TextBox)
                    controlList.Add(c);
            }
            return controlList;
        }

        private void Calculate()
        {
            CalculateIntegralPoints();
            CalculateStandardNormalDistribution();
            CalculateBtK1();
        }

        private void ValidateInputs()
        {
            InputsValidator validator = new InputsValidator();
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
            riskFreeRate = Convert.ToDouble(RiskFreeRateTextBox.Text);
            volatilitySigma = Convert.ToDouble(VolatilitySigmaTextBox.Text);
            tau = Convert.ToDouble(TauTextBox.Text);
            strikePrice = Convert.ToDouble(StrikePriceTextBox.Text);
            numberOfIterration = Convert.ToDouble(StrikePriceTextBox.Text);
            timeToMaturity = Convert.ToDouble(StrikePriceTextBox.Text);
            stockPrice = Convert.ToDouble(StrikePriceTextBox.Text);
        }

        private void CalculateIntegralPoints()
        {
            IntegralPoints integralPoints = new IntegralPoints();

            integralPointD1 = integralPoints.CalculateIntegralPointD1(riskFreeRate, volatilitySigma, tau);
            integralPointD2 = integralPoints.CalculateIntegralPointD2(integralPointD1, volatilitySigma, tau);

            IntegralPointD1TextBox.Text = integralPointD1.ToString(numberFormat);
            IntegralPointD2TextBox.Text = integralPointD2.ToString(numberFormat);
        }

        private void CalculateStandardNormalDistribution()
        {
            distribution = new StandardNormalDistribution().CalculatePDF(integralPointD1);

            DistributionTextBox.Text = distribution.ToString(numberFormat);
        }

        private void CalculateBtK1()
        {
            BtK1 = new BtK1().Calculate(volatilitySigma, strikePrice, distribution, integralPointD1, riskFreeRate, tau, integralPointD2);

            BtK1TextBox.Text = BtK1.ToString(numberFormat);
        }
    }
}
