using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AmericanOptions.Bt;
using AmericanOptions.ClickHelpers;

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
      private double stockPrice;
      private double numberOfIterration;
      private double numberOfNodes;
      private double timeToMaturity;

      public MainForm()
      {
         InitializeComponent();
         AssignDefaultVariables();
      }

      private async void CalculateButton_Click(object sender, EventArgs e)
      {
         try
         {
            Clean.CleanResultsLabels(ResultsPanel);
            ValidateInputs();
            AssignVariables();

            BtCalculator calculator = new BtCalculator();

            List<BtResult> results = await calculator.Calculate(
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

      private void DefaultButton_Click(object sender, EventArgs e)
      {
         AssignDefaultVariables();
      }

      private void ClearButton_Click(object sender, EventArgs e)
      {
         Clean.CleanTextBoxes(this);
         Clean.CleanResultsLabels(ResultsPanel);
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

      private void SetResultLabels(List<BtResult> results)
      {
         ResultsCreator creator = new ResultsCreator();

         foreach (var result in results)
         {
            creator.CreateResultsLabels(ResultsPanel, result);
         }
      }

      private async void NumberOfIterationTextBox_ValueChanged(object sender, EventArgs e)
      {
         Clean.CleanResultsLabels(ResultsPanel);
         AssignVariables();

         BtCalculator calculator = new BtCalculator();

         List<BtResult> results = await calculator.Calculate(
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

      private async void NumberOfNodesTextBox_ValueChanged(object sender, EventArgs e)
      {
         Clean.CleanResultsLabels(ResultsPanel);
         AssignVariables();

         BtCalculator calculator = new BtCalculator();

         List<BtResult> results = await calculator.Calculate(
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
   }
}
