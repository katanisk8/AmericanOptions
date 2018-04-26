﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Threading;
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

        private bool ReCalculateFlag = true;

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
            if (ReCalculateFlag)
            {
                Calculate();
            }
        }

        private void NumberOfNodesTextBox_ValueChanged(object sender, EventArgs e)
        {
            if (ReCalculateFlag)
            {
                Calculate();
            }
        }

        private void DefaultButton_Click(object sender, EventArgs e)
        {
            ReCalculateFlag = false;
            AssignDefaultVariables();
            ReCalculateFlag = true;
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
                    Results results = new Calculator().Calculate(
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

            clear.CleanResultsLabels(BtResultsPanel);
            clear.CleanResultsLabels(PutResultsPanel);
        }

        private void AssignDefaultVariables()
        {
            RiskFreeRateTextBox.Text = "0,05";
            VolatilitySigmaTextBox.Text = "0,2";
            TauTextBox.Text = "1";
            StrikePriceTextBox.Text = "45";
            StockPriceTextBox.Text = "45";
            NumberOfIterationTextBox.Text = "20";
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

        private void SetLabels(Results results)
        {
            ResultsCreator creator = new ResultsCreator();
            List<Label> btResultsLabels = new List<Label>();
            List<Label> putResultsLabels = new List<Label>();

            btResultsLabels = creator.CreateResultsLabels(results.BtResults, "Bt, k={0}:");
            putResultsLabels = creator.CreateResultsLabels(results.PutResults, "P, k={0}:");

            BtResultsPanel.Controls.AddRange(btResultsLabels.Cast<Control>().ToArray());
            PutResultsPanel.Controls.AddRange(putResultsLabels.Cast<Control>().ToArray());
        }

        private void ClearAll()
        {
            Clean clear = new Clean();

            clear.CleanTextBoxes(InputsGroupBox);
            clear.CleanResultsLabels(BtResultsPanel);
            clear.CleanResultsLabels(PutResultsPanel);
        }
    }
}
