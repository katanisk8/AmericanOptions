using System;
using System.ComponentModel;
using System.Windows.Forms;
using AmericanOptions.ClickHelpers;
using AmericanOptions.Model;
using AmericanOptions.Validations;

namespace AmericanOptions.Windows
{
    public partial class MainForm : Form
    {
        private readonly ICalculator _calculator;
        private readonly IInputsValidator _validator;
        private readonly ICleaner _cleaner;
        private BackgroundWorker _worker;
        private int _iterations;

        // Inputs
        private double _riskFreeRate;
        private double _volatilitySigma;
        private double _tau;
        private double _strikePrice;
        private double _stockPrice;
        private int _numberOfIterration;
        private int _numberOfNodes;
        private double _timeToMaturity;

        public MainForm(ICalculator calculator, IInputsValidator validator, ICleaner cleaner)
        {
            InitializeComponent();

            _calculator = calculator;
            _validator = validator;
            _cleaner = cleaner;
            _worker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };


            _worker.DoWork += Calculate;
            _worker.ProgressChanged += ProgressChanged;
            _worker.RunWorkerCompleted += RunWorkerCompleted;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AssignDefaultVariables();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                ClearResultView();
                ValidateInputs();
                AssignVariables();
                CalculateProgressBar.Maximum = _numberOfIterration * 2 - 1;

                if (_worker != null)
                {
                    _worker.Dispose();
                }

                _worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            CalculateProgressBar.Value = e.ProgressPercentage;
        }

        void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Calulation has been canceled.");
            }
            else if (e.Error != null)
            {
                throw new Exception(e.Error.Message);
            }

            DisplayResults(e.Result as Result[]);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            _worker.CancelAsync();
            ClearAll();
        }

        private void DefaultButton_Click(object sender, EventArgs e)
        {
            AssignDefaultVariables();
        }

        private void Calculate(object sender, DoWorkEventArgs e)
        {
            Result[] results = new Result[_numberOfIterration];

            if (_worker.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                results[0] = _calculator.CalculateK0(_strikePrice, _stockPrice, _riskFreeRate,
                _tau, _volatilitySigma, _numberOfNodes, _timeToMaturity);
                _iterations++;

                _worker.ReportProgress(0);

                results[1] = _calculator.CalculateBtK1(_strikePrice, _stockPrice, _riskFreeRate,
                _tau, _volatilitySigma, _numberOfNodes, _timeToMaturity);
                _iterations++;

                _worker.ReportProgress(1);

                for (int i = 2; i < _numberOfIterration; i++)
                {
                    results[i] = _calculator.CalculateBtKi(_strikePrice, _stockPrice, _riskFreeRate,
                    _tau, _volatilitySigma, _numberOfNodes, _timeToMaturity, i, results[i - 1].BtValue);
                    _iterations++;

                    _worker.ReportProgress(i);

                    if (double.IsNaN(results[i].BtValue))
                    {
                        Array.Resize(ref results, i);
                        break;
                    }
                }
            }

            e.Result = results;
        }

        private void DisplayResults(Result[] results)
        {
            foreach (var result in results)
            {
                string[] subItem = new string[] {
                    result.ResultNumber.ToString(),
                    result.BtRoundedValue.ToString(),
                    result.PutRoundedValue.ToString()
                    };

                ResultListView.Items.Add(new ListViewItem(subItem));
                CalculateProgressBar.Value++;
            }

            CalculateProgressBar.Maximum = CalculateProgressBar.Value;
        }

        private void ClearResultView()
        {
            ResultListView.Items.Clear();
            CalculateProgressBar.Value = 0;
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
            RiskFreeRateTextBox.Text = (0.05).ToString();
            VolatilitySigmaTextBox.Text = (0.2).ToString();
            TauTextBox.Text = (1).ToString();
            StrikePriceTextBox.Text = (45).ToString();
            StockPriceTextBox.Text = (45).ToString();
            NumberOfIterationTextBox.Text = (500).ToString();
            NumberOfNodesTextBox.Text = (5000).ToString();
            TimeToMaturityTextBox.Text = (1).ToString();
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

        private void ClearAll()
        {
            _cleaner.CleanTextBoxes(InputsGroupBox);
            ClearResultView();
        }
    }
}
