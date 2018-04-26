using System;
using System.Windows.Forms;
using AmericanOptions.ClickHelpers;
using AmericanOptions.Helpers;

namespace AmericanOptions
{
   internal partial class MainForm : Form
    {
        // Inputs
        private double riskFreeRate;
        private double volatilitySigma;
        private double tau;
        private double strikePrice;
        private double stockPrice;
        private int numberOfIterration;
        private int numberOfNodes;
        private double timeToMaturity;

        internal MainForm()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        private void NumberOfIterationTextBox_ValueChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void NumberOfNodesTextBox_ValueChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void DefaultButton_Click(object sender, EventArgs e)
        {
            AssignDefaultVariables();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Clean.CleanTextBoxes(this);
            Clean.CleanResultsLabels(BtResultsPanel);
            Clean.CleanResultsLabels(PutResultsPanel);
        }

        private void AssignDefaultVariables()
        {
            RiskFreeRateTextBox.Text = "0,05";
            VolatilitySigmaTextBox.Text = "0,2";
            TauTextBox.Text = "1";
            StrikePriceTextBox.Text = "45";
            StockPriceTextBox.Text = "45";
            TimeToMaturityTextBox.Text = "1";
        }

        private void ValidateInputs()
        {
            InputsValidator validator = new InputsValidator();
            validator.ValidateTextBoxInput(RiskFreeRateTextBox);
            validator.ValidateTextBoxInput(VolatilitySigmaTextBox);
            validator.ValidateTextBoxInput(TauTextBox);
            validator.ValidateTextBoxInput(StrikePriceTextBox);
            validator.ValidateTextBoxInput(StockPriceTextBox);
            validator.ValidateTextBoxInput(TimeToMaturityTextBox);
        }

        private void AssignVariables()
        {
            riskFreeRate = Convert.ToDouble(RiskFreeRateTextBox.Text);
            volatilitySigma = Convert.ToDouble(VolatilitySigmaTextBox.Text);
            tau = Convert.ToDouble(TauTextBox.Text);
            strikePrice = Convert.ToDouble(StrikePriceTextBox.Text);
            stockPrice = Convert.ToDouble(StockPriceTextBox.Text);
            numberOfIterration = Convert.ToInt32(NumberOfIterationTextBox.Text);
            numberOfNodes = Convert.ToInt32(NumberOfNodesTextBox.Text);
            timeToMaturity = Convert.ToDouble(TimeToMaturityTextBox.Text);
        }

        private void SetResultLabels(Results results)
        {
            ResultsCreator creator = new ResultsCreator();
            
            creator.CreateResultsLabels(BtResultsPanel, results.BtResults, "Bt, k={0}:");            
            creator.CreateResultsLabels(PutResultsPanel, results.PutResults, "P, k={0}:");
        }

        private void Calculate()
        {
            try
            {
                Clean.CleanResultsLabels(BtResultsPanel);
                Clean.CleanResultsLabels(PutResultsPanel);
                ValidateInputs();
                AssignVariables();

                Results results = new Calculator().Calcluate(
                    riskFreeRate, 
                    volatilitySigma, 
                    tau,
                    strikePrice, 
                    stockPrice, 
                    numberOfIterration, 
                    numberOfNodes, 
                    timeToMaturity);

                SetResultLabels(results);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
