using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Threading;
using AmericanOptions.ClickHelpers;
using AmericanOptions.Model;
using AmericanOptions.Validations;

namespace AmericanOptions.Windows
{
    public partial class MainForm : Form
    {
        private readonly ICalculator _calculator;
        private readonly IInputsValidator _validator;
        private readonly IResultsCreator _resultCreator;
        private readonly ICleaner _cleaner;

        // Inputs
        private double _riskFreeRate;
        private double _volatilitySigma;
        private double _tau;
        private double _strikePrice;
        private double _stockPrice;
        private int _numberOfIterration;
        private int _numberOfNodes;
        private double _timeToMaturity;

        public MainForm(ICalculator calculator, IInputsValidator validator, IResultsCreator resultCreator, ICleaner cleaner)
        {
            InitializeComponent();

            _calculator = calculator;
            _validator = validator;
            _resultCreator = resultCreator;
            _cleaner = cleaner;
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
                    Result[] results = _calculator.Calculate(
                    _riskFreeRate,
                    _volatilitySigma,
                    _tau,
                    _strikePrice,
                    _stockPrice,
                    _numberOfIterration,
                    _numberOfNodes,
                    _timeToMaturity);

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

        }

        private void ValidateInputs()
        {
            _validator.ValidateInput(RiskFreeRateTextBox);
            _validator.ValidateInput(VolatilitySigmaTextBox);
            _validator.ValidateInput(TauTextBox);
            _validator.ValidateInput(StrikePriceTextBox);
            _validator.ValidateInput(StockPriceTextBox);
            _validator.ValidateInput(NumberOfIterationTextBox);
            _validator.ValidateInput(NumberOfNodesTextBox);
            _validator.ValidateInput(StockPriceTextBox);
            _validator.ValidateInput(TimeToMaturityTextBox);
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
            _riskFreeRate = Convert.ToDouble(RiskFreeRateTextBox.Text);
            _volatilitySigma = Convert.ToDouble(VolatilitySigmaTextBox.Text);
            _tau = Convert.ToDouble(TauTextBox.Text);
            _strikePrice = Convert.ToDouble(StrikePriceTextBox.Text);
            _stockPrice = Convert.ToDouble(StockPriceTextBox.Text);
            _numberOfIterration = Convert.ToInt32(NumberOfIterationTextBox.Text);
            _numberOfNodes = Convert.ToInt32(NumberOfNodesTextBox.Text);
            _timeToMaturity = Convert.ToDouble(TimeToMaturityTextBox.Text);
        }

        private void SetLabels(Result[] results)
        {
            CalculateProgressBar.Maximum = results.Length;

            for (int i = 0; i < results.Length; i++)
            {
                string[] subitems = new string[] {
                    results[i].ResultNumber.ToString(),
                    results[i].BtRoundedValue.ToString(),
                    results[i].PutRoundedValue.ToString()
                };

                ListViewItem item = new ListViewItem(subitems);
                ResultListView.Items.Add(item);
                CalculateProgressBar.PerformStep();
            }

            CalculateProgressBar.Hide();
        }

        private void ClearAll()
        {
            _cleaner.CleanTextBoxes(InputsGroupBox);
        }
    }
}
