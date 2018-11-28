using System;
using System.ComponentModel;
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

      public MainForm(ICalculator calculator, IInputsValidator validator, ICleaner cleaner)
      {
         InitializeComponent();

         _calculator = calculator;
         _validator = validator;
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

      private async void Calculate()
      {
         try
         {
            ClearResultView();
            ValidateInputs();
            AssignVariables();

            Result[] results = new Result[_numberOfIterration];
            CalculateProgressBar.Maximum = _numberOfIterration;

            results[0] = await _calculator.CalculateK0(_strikePrice, _stockPrice, _riskFreeRate,
            _tau, _volatilitySigma, _numberOfNodes, _timeToMaturity);

            string[] subItemsK0 = new string[] {
                    results[0].ResultNumber.ToString(),
                    results[0].BtRoundedValue.ToString(),
                    results[0].PutRoundedValue.ToString()
                    };

            ResultListView.Items.Add(new ListViewItem(subItemsK0));
            CalculateProgressBar.PerformStep();

            results[1] = await _calculator.CalculateBtK1(_strikePrice, _stockPrice, _riskFreeRate,
            _tau, _volatilitySigma, _numberOfNodes, _timeToMaturity);

            string[] subItemsK1 = new string[] {
                    results[1].ResultNumber.ToString(),
                    results[1].BtRoundedValue.ToString(),
                    results[1].PutRoundedValue.ToString()
                    };

            ResultListView.Items.Add(new ListViewItem(subItemsK1));
            CalculateProgressBar.PerformStep();

            for (int i = 2; i < _numberOfIterration; i++)
            {
               results[i] = await _calculator.CalculateBtK(_strikePrice, _stockPrice, _riskFreeRate,
               _tau, _volatilitySigma, _numberOfNodes, _timeToMaturity, i, results[i - 1].BtValue);

               string[] subItemsK = new string[] {
                        results[i].ResultNumber.ToString(),
                        results[i].BtRoundedValue.ToString(),
                        results[i].PutRoundedValue.ToString()
                        };

               ResultListView.Items.Add(new ListViewItem(subItemsK));
               CalculateProgressBar.PerformStep();

               if (double.IsNaN(results[i].BtValue))
               {
                  Array.Resize(ref results, i);
                  CalculateProgressBar.Maximum = results.Length;
                  break;
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      private void ClearResultView()
      {
         CalculateProgressBar.Value = 0;
         ResultListView.Items.Clear();
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

      private void ClearAll()
      {
         _cleaner.CleanTextBoxes(InputsGroupBox);
         ClearResultView();
      }
   }
}
