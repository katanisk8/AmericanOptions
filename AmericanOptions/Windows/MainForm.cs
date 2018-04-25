using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AmericanOptions.ClickHelpers;
using AmericanOptions.OptimalExerciseBoundary;
using AmericanOptions.PutOptions;

namespace AmericanOptions
{
    internal partial class MainForm : Form
    {
        private const string numberFormat = "F06";

        // Inputs
        private double riskFreeRate;
        private double volatilitySigma;
        private double tau;
        private double strikePrice;
        private double stockPrice;
        private double numberOfIterration;
        private double numberOfNodes;
        private double timeToMaturity;

        internal MainForm()
        {
            InitializeComponent();
        }

        private async void CalculateButton_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        private async void NumberOfIterationTextBox_ValueChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private async void NumberOfNodesTextBox_ValueChanged(object sender, EventArgs e)
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
            numberOfIterration = Convert.ToDouble(NumberOfIterationTextBox.Text);
            numberOfNodes = Convert.ToDouble(NumberOfNodesTextBox.Text);
            timeToMaturity = Convert.ToDouble(TimeToMaturityTextBox.Text);
        }

        private void SetResultLabels(List<Result> btResults, List<Result> putResults)
        {
            ResultsCreator creator = new ResultsCreator();
            
            creator.CreateResultsLabels(BtResultsPanel, btResults, "Bt, k={0}:");            
            creator.CreateResultsLabels(PutResultsPanel, putResults, "P, k={0}:");
        }

        private async void Calculate()
        {
            try
            {
                Clean.CleanResultsLabels(BtResultsPanel);
                Clean.CleanResultsLabels(PutResultsPanel);
                ValidateInputs();
                AssignVariables();

                BtCalculator calculator = new BtCalculator();
                AmercianPut putCalculator = new AmercianPut();

                List<Result> BtResults = await calculator.Calculate(
                    riskFreeRate,
                    volatilitySigma,
                    tau,
                    strikePrice,
                    stockPrice,
                    numberOfIterration,
                    numberOfNodes,
                    timeToMaturity);

                List<Result> PutResults = new List<Result>();

                foreach (var result in BtResults)
                {
                    double putResult = putCalculator.Calculate(
                       strikePrice,
                       stockPrice,
                       riskFreeRate,
                       tau,
                       volatilitySigma,
                       numberOfNodes,
                       timeToMaturity,
                       result.Value);

                    PutResults.Add(new Result { ResultNumber = result.ResultNumber, Value = putResult });
                }

                SetResultLabels(BtResults, PutResults);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
