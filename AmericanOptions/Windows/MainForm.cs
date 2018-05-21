using System;
using System.Windows.Forms;
using System.Windows.Threading;
using AmericanOptions.ClickHelpers;
using AmericanOptions.Helpers;

namespace AmericanOptions
{
    public partial class MainForm : Form
    {
        ICalculator calc;

        // Inputs
        private double riskFreeRate;
        private double volatilitySigma;
        private double tau;
        private double strikePrice;
        private double stockPrice;
        private int numberOfIterration;
        private int numberOfNodes;
        private double timeToMaturity;

        public MainForm(ICalculator _calc)
        {
            InitializeComponent();
            calc = _calc;
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
                    var results = calc.Calculate(
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
            Clean clear = new Clean();
            clear.CleanResultsLabels(ResultsPanel);
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

        private void ValidateInputs()
        {
            InputsValidator validator = new InputsValidator();
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
            ResultsCreator creator = new ResultsCreator();
            Label[] labels = new Label[results.Length];

            labels = creator.CreateResultsLabels(results, "Bt, k={0}: {1}   P, k={2}: {3}");

            ResultsPanel.Controls.AddRange(labels);
        }

        private void ClearAll()
        {
            Clean clear = new Clean();

            clear.CleanTextBoxes(InputsGroupBox);
            clear.CleanResultsLabels(ResultsPanel);
        }
    }
}
