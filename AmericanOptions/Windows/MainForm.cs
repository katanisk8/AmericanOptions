using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using AmericanOptions.ClickHelpers;
using AmericanOptions.Helpers;
using AmericanOptions.Model;
using AmericanOptions.Validations;
using Unity.Interception.Utilities;

namespace AmericanOptions.Windows
{
   public partial class MainForm : Form
   {
      private readonly ICalculator _calculator;
      private readonly IInputsValidator _validator;
      private readonly ICleaner _cleaner;
      private readonly IMemoryMeasurer _measurer;
      private readonly BackgroundWorker _worker;
      private readonly IList<Thread> _bgWorkersThreads;
      private bool _closePending;

      // Inputs
      private double riskFreeRate;
      private double volatilitySigma;
      private double tau;
      private double strikePrice;
      private double stockPrice;
      private int numberOfIterration;
      private int numberOfNodes;
      private double timeToMaturity;

      public MainForm(ICalculator calculator, IInputsValidator validator, ICleaner cleaner, IMemoryMeasurer measurer, BackgroundWorker worker)
      {
         _calculator = calculator;
         _validator = validator;
         _cleaner = cleaner;
         _measurer = measurer;
         _worker = worker;
         _bgWorkersThreads  = new List<Thread>();

         InitializeComponent();
         PrepareWorker();
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         AssignDefaultVariables();
         SetStatusLabel(Status.Ready);
         SetMemoryLabelAsync();
      }

      private void MainForm_HelpButtonClicked(object sender, CancelEventArgs e)
      {

      }

      private void CalculateButton_Click(object sender, EventArgs e)
      {
         try
         {
            if (_worker.IsBusy)
            {
               SetStatusLabel(_worker.CancellationPending ? Status.Canceling : Status.Running, "Worker is busy!");
            }
            else
            {
               ClearResults();
               ValidateInputs();
               AssignVariables();
               PrepareProgressBar();
               SetStatusLabel(Status.Running);

               _worker.RunWorkerAsync();
            }
         }
         catch (Exception ex)
         {
            SetStatusLabel(Status.Error, ex.Message);
         }
      }

      private void CancelButton_Click(object sender, EventArgs e)
      {
         if (_worker.IsBusy)
         {
            _worker.CancelAsync();
            SetStatusLabel(Status.Canceling);
         }
         else
         {
            SetStatusLabel("Nothing to canceled!");
         }
      }

      private void ClearButton_Click(object sender, EventArgs e)
      {
         ClearAll();
      }

      private void DefaultButton_Click(object sender, EventArgs e)
      {
         AssignDefaultVariables();
         SetStatusLabel(Status.Ready);
      }

      private void ProgressChanged(object sender, ProgressChangedEventArgs e)
      {
         if (e.UserState is CalculatorResult result)
         {
            string[] subItem = {
               result.ResultNumber.ToString(),
               result.BtResult.Result.RoundedValue.ToString(),
               result.PutResult.Result.RoundedValue.ToString()
            };

            ResultListView.Items.Add(new ListViewItem(subItem));
            CalculateProgressBar.Value = e.ProgressPercentage;
         }
      }

      private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         SetStatusLabel(e.Cancelled ? Status.Canceled : Status.Completed);
         EndProgressBar();

         if (e.Error != null) throw new Exception(e.Error.Message);
      }

      private void PrepareWorker()
      {
         _worker.WorkerReportsProgress = true;
         _worker.WorkerSupportsCancellation = true;
         _worker.ProgressChanged += ProgressChanged;
         _worker.RunWorkerCompleted += RunWorkerCompleted;
         _worker.DoWork += Calculate;
      }

      protected override void OnFormClosing(FormClosingEventArgs e)
      {
         _bgWorkersThreads.ForEach(x => x.Abort());
         base.OnFormClosing(e);
      }

      private async void Calculate(object sender, DoWorkEventArgs e)
      {
         _bgWorkersThreads.Add(Thread.CurrentThread);

         if (_worker.CancellationPending)
         {
            e.Cancel = true;
         }
         else
         {
            double Btk_1;
            CalculatorResult result;

            // k=0
            result = await _calculator.CalculateK0Async(
               strikePrice,
               stockPrice,
               riskFreeRate,
               tau,
               volatilitySigma,
               numberOfNodes,
               timeToMaturity);

            _worker.ReportProgress(0, result);

            if (_worker.CancellationPending)
            {
               e.Cancel = true;
               return;
            }

            // k=1
            result = await _calculator.CalculateBtK1Async(
               strikePrice,
               stockPrice,
               riskFreeRate,
               tau,
               volatilitySigma,
               numberOfNodes,
               timeToMaturity);

            Btk_1 = result.BtResult.Result.Value;
            _worker.ReportProgress(1, result);

            if (_worker.CancellationPending)
            {
               e.Cancel = true;
               return;
            }

            // k>1
            for (int i = 2; i < numberOfIterration; i++)
            {
               result = await _calculator.CalculateBtKiAsync(
                  strikePrice,
                  stockPrice,
                  riskFreeRate,
                  tau,
                  volatilitySigma,
                  numberOfNodes,
                  timeToMaturity,
                  i,
                  Btk_1);

               Btk_1 = result.BtResult.Result.Value;
               _worker.ReportProgress(i, result);

               if (_worker.CancellationPending ||
                   double.IsNaN(result.BtResult.Result.Value))
               {
                  e.Cancel = true;
                  return;
               }
            }
         }
      }

      private void ClearResults()
      {
         ResultListView.Items.Clear();
         CalculateProgressBar.Value = 0;
      }

      private void ValidateInputs()
      {
         SetStatusLabel(Status.Validating);
         _validator.ValidateInput(RiskFreeRateTextBox);
         _validator.ValidateInput(VolatilitySigmaTextBox);
         _validator.ValidateInput(TauTextBox);
         _validator.ValidateInput(StrikePriceTextBox);
         _validator.ValidateInput(StockPriceTextBox);
         _validator.ValidateIterationNumber(NumberOfIterationTextBox, 999999);
         _validator.ValidateIterationNumber(NumberOfNodesTextBox, 99999);
         _validator.ValidateInput(StockPriceTextBox);
         _validator.ValidateInput(TimeToMaturityTextBox);
         SetStatusLabel(Status.Validated);
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

      private void SetStatusLabel(Status status)
      {
         StripStatusLabel.Text = $@"{ProgramStatus.GetStatus(status)}...";
      }

      private void SetStatusLabel(string info)
      {
         StripStatusLabel.Text = info;
      }

      private void SetStatusLabel(Status status, string info)
      {
         StripStatusLabel.Text = $@"{ProgramStatus.GetStatus(status)}: {info}";
      }

      private async void SetMemoryLabelAsync()
      {
         MemoryLabel.Text = await _measurer.GetTotalMemoryWithSuffixAsync();
      }

      private void PrepareProgressBar()
      {
         CalculateProgressBar.Maximum = numberOfIterration * 2 - 1;
      }

      private void EndProgressBar()
      {
         CalculateProgressBar.Maximum = CalculateProgressBar.Value;
      }

      private void ClearAll()
      {
         SetStatusLabel(Status.Cleaning);
         _cleaner.CleanTextBoxes(InputsGroupBox);
         ClearResults();
         SetStatusLabel(Status.Cleaned);
      }

      private void UpdateTimer_Tick(object sender, EventArgs e)
      {
         SetMemoryLabelAsync();
      }
   }
}