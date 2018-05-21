using System;
using System.Windows.Forms;
using System.Windows.Threading;
using AmericanOptions.ClickHelpers;
using AmericanOptions.Model;

namespace AmericanOptions
{
    public partial class MainForm : Form
    {
        ICalculator calculator;
        IInputsValidator validator;
        IResultsCreator resultCreator;
        ICleaner cleaner;

        // Inputs
        private double riskFreeRate;
        private double volatilitySigma;
        private double tau;
        private double strikePrice;
        private double stockPrice;
        private int numberOfIterration;
        private int numberOfNodes;
        private double timeToMaturity;

        public MainForm(ICalculator _calculator, IInputsValidator _validator, IResultsCreator _resultCreator, ICleaner _cleaner)
        {
            InitializeComponent();

            calculator = _calculator;
            validator = _validator;
            resultCreator = _resultCreator;
            cleaner = _cleaner;
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        private void DefaultButton_Click(object sender, EventArgs e)
        {
            AssignDefaultVariables();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void Calculate()
        {
            try
            {
                ClearResultsLabels();
                ValidateInputs();
                AssignVariables();

                Dispatcher.CurrentDispatcher.Invoke(() =>
                {
                    Result[] results = calculator.Calculate(
                    riskFreeRate,
                    volatilitySigma,
                    tau,
                    strikePrice,
                    stockPrice,
                    numberOfIterration,
                    numberOfNodes,
                    timeToMaturity);

                    SetLabels(results);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         }

        private void ClearResultsLabels()
        {
            cleaner.CleanResultsLabels(ResultsPanel);
        }

        private void ValidateInputs()
        {
            validator.ValidateInput(RiskFreeRateTextBox);
            validator.ValidateInput(VolatilitySigmaTextBox);
            validator.ValidateInput(TauTextBox);
            validator.ValidateInput(StrikePriceTextBox);
            validator.ValidateInput(StockPriceTextBox);
            validator.ValidateInput(NumberOfIterationTextBox);
            validator.ValidateInput(NumberOfNodesTextBox);
            validator.ValidateInput(StockPriceTextBox);
            validator.ValidateInput(TimeToMaturityTextBox);
        }

        private void AssignDefaultVariables()
        {
            RiskFreeRateTextBox.Text = "0,05";
            VolatilitySigmaTextBox.Text = "0,2";
            TauTextBox.Text = "1";
            StrikePriceTextBox.Text = "45";
            StockPriceTextBox.Text = "45";
            NumberOfIterationTextBox.Text = "16";
            NumberOfNodesTextBox.Text = "4";
            TimeToMaturityTextBox.Text = "1";
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

        private void SetLabels(Result[] results)
        {
            Label[] labels = resultCreator.CreateResultsLabels(results);
            ResultsPanel.Controls.AddRange(labels);
        }

        private void ClearAll()
        {
            cleaner.CleanTextBoxes(InputsGroupBox);
            cleaner.CleanResultsLabels(ResultsPanel);
        }
    }
}
