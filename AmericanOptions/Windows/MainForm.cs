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

        // Inputs
        private double riskFreeRate;
        private double volatilitySigma;
        private double tau;
        private double strikePrice;
        private double stockPrice;
        private int numberOfIterration;
        private int numberOfNodes;
        private double timeToMaturity;

        public MainForm(ICalculator calculator, IInputsValidator validator, ICleaner cleaner, BackgroundWorker worker)
        {
            _calculator = calculator;
            _validator = validator;
            _cleaner = cleaner;
            _worker = worker;

            InitializeComponent();
            PrepareWorker();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AssignDefaultVariables();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                ClearResults();
                ValidateInputs();
                AssignVariables();
                PrepareProgressBar();

                _worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void PrepareWorker()
        {
            _worker.WorkerSupportsCancellation = true;
            _worker.WorkerReportsProgress = true;
            _worker.DoWork += Calculate;
            _worker.ProgressChanged += ProgressChanged;
            _worker.RunWorkerCompleted += RunWorkerCompleted;
        }

        private void Calculate(object sender, DoWorkEventArgs e)
        {
            Result[] results = new Result[numberOfIterration];

            if (_worker.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                // k=0
                results[0] = _calculator.CalculateK0(
                             strikePrice,
                             stockPrice,
                             riskFreeRate,
                             tau,
                             volatilitySigma,
                             numberOfNodes,
                             timeToMaturity);
                _worker.ReportProgress(0);

                // k=1
                results[1] = _calculator.CalculateBtK1(
                             strikePrice,
                             stockPrice,
                             riskFreeRate,
                             tau,
                             volatilitySigma,
                             numberOfNodes,
                             timeToMaturity);
                _worker.ReportProgress(1);

                // k>1
                for (int i = 2; i < numberOfIterration; i++)
                {
                    results[i] = _calculator.CalculateBtKi(
                                 strikePrice,
                                 stockPrice,
                                 riskFreeRate,
                                 tau,
                                 volatilitySigma,
                                 numberOfNodes,
                                 timeToMaturity,
                                 i,
                                 results[i - 1].BtResult);
                    _worker.ReportProgress(i);

                    if (double.IsNaN(results[i].BtResult.Value))
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
                    result.BtResult.RoundedValue.ToString(),
                    result.PutResult.RoundedValue.ToString()
                };

                ResultListView.Items.Add(new ListViewItem(subItem));
                CalculateProgressBar.Value++;
            }

            CalculateProgressBar.Maximum = CalculateProgressBar.Value;
        }

        private void ClearResults()
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
            NumberOfIterationTextBox.Text = (16).ToString();
            NumberOfNodesTextBox.Text = (4).ToString();
            TimeToMaturityTextBox.Text = (1).ToString();
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

        private void PrepareProgressBar()
        {
            CalculateProgressBar.Maximum = numberOfIterration * 2 - 1;
        }

        private void ClearAll()
        {
            _cleaner.CleanTextBoxes(InputsGroupBox);
            ClearResults();
        }
    }
}
