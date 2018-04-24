using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AmericanOptions.Calculations;
using AmericanOptions.Bt;

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

        private void AssignDefaultVariables()
        {
            RiskFreeRateTextBox.Text = "0,05";
            VolatilitySigmaTextBox.Text = "0,2";
            TauTextBox.Text = "1";
            StrikePriceTextBox.Text = "45";
            StockPriceTextBox.Text = "45";
            NumberOfIterationTextBox.Text = "10";
            NumberOfNodesTextBox.Text = "4";
            TimeToMaturityTextBox.Text = "1";
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                CleanResultsLabels();

                ValidateInputs();
                AssignVariables();

                Calculate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            CleanTextBoxes();
            CleanResultsLabels();
        }

        private void CleanResultsLabels()
        {
            List<Control> labelList = GetAllLabelControls(ResultsPanel);

            foreach (var control in labelList)
            {
                ResultsPanel.Controls.Remove((Label)control);
            }
        }

        private void CleanTextBoxes()
        {
            List<Control> textBoxList = GetAllTextBoxControls(this);

            foreach (Control c in textBoxList)
            {
                TextBox textBox = (TextBox)c;
                textBox.Text = string.Empty;
                textBox.BackColor = Color.White;
            }
        }

        private List<Control> GetAllTextBoxControls(Control container)
        {
            List<Control> controlList = new List<Control>();
            foreach (Control c in container.Controls)
            {
                controlList.AddRange(GetAllTextBoxControls(c));
                if (c is TextBox)
                    controlList.Add(c);
            }
            return controlList;
        }

        private List<Control> GetAllLabelControls(Control container)
        {
            List<Control> controlList = new List<Control>();
            foreach (Control c in container.Controls)
            {
                controlList.AddRange(GetAllLabelControls(c));
                if (c is Label)
                    controlList.Add(c);
            }
            return controlList;
        }

        private void ValidateInputs()
        {
            InputsValidator validator = new InputsValidator();
            validator.ValidateTextBoxInput(RiskFreeRateTextBox);
            validator.ValidateTextBoxInput(VolatilitySigmaTextBox);
            validator.ValidateTextBoxInput(TauTextBox);
            validator.ValidateTextBoxInput(StrikePriceTextBox);
            validator.ValidateTextBoxInput(StockPriceTextBox);
            validator.ValidateTextBoxInput(NumberOfIterationTextBox);
            validator.ValidateTextBoxInput(NumberOfNodesTextBox);
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

        private void Calculate()
        {
            BtCalculator bt = new BtCalculator();
            List<BtResult> btResults = new List<BtResult>();
            StandardNormalDistribution standardNormalDistribution = new StandardNormalDistribution();
            IntegralPoints integralPoints = new IntegralPoints();
            double integralPointD1;
            double integralPointD2;
            double distribution;

            // Results
            double BtK_1 = 0;
            double BtK;

            for (int i = 0; i <= numberOfIterration; i++)
            {
                if (i == 0)
                {
                    btResults.Add(new BtResult { NumberOfResult = i, Value = strikePrice });
                }
                else if (i == 1)
                {
                    integralPointD1 = integralPoints.CalculateIntegralPointD1(strikePrice, strikePrice, riskFreeRate, volatilitySigma, tau);
                    integralPointD2 = integralPoints.CalculateIntegralPointD2(integralPointD1, volatilitySigma, tau);
                    distribution = standardNormalDistribution.CalculatePDF(integralPointD1);
                    BtK_1 = bt.CalculateBtK_1(volatilitySigma, strikePrice, distribution, integralPointD1, riskFreeRate, tau, integralPointD2);


                    btResults.Add(new BtResult { NumberOfResult = i, Value = BtK_1 });
                }
                else
                {
                    integralPointD1 = integralPoints.CalculateIntegralPointD1(BtK_1, strikePrice, riskFreeRate, volatilitySigma, tau);
                    integralPointD2 = integralPoints.CalculateIntegralPointD2(integralPointD1, volatilitySigma, tau);
                    distribution = standardNormalDistribution.CalculatePDF(integralPointD1);
                    BtK = bt.CalculateBt(volatilitySigma, strikePrice, distribution, integralPointD1, riskFreeRate, tau, integralPointD2, numberOfNodes, timeToMaturity);
                    BtK_1 = BtK;

                    btResults.Add(new BtResult { NumberOfResult = i, Value = BtK });
                }
            }

            SetResultLabels(btResults);
        }

        private void SetResultLabels(List<BtResult> results)
        {
            foreach (var result in results)
            {
                CreateNewLabel(result);
            }
        }

        private void CreateNewLabel(BtResult result)
        {
            int x = result.NumberOfResult;

            Label label = new Label();
            label.Size = new Size(55, 13);
            label.Location = new Point(6, x * 16 + 16);
            label.Name = string.Format("LabelBtK={0}", x);
            label.Text = string.Format("Bt, K={0}:", x);

            Label resultLabel = new Label();
            resultLabel.Size = new Size(50, 13);
            resultLabel.Location = new Point(label.Location.X + 55, x * 16 + 16);
            resultLabel.Name = string.Format("ResultLabelBtK={0}", x);
            resultLabel.Text = Math.Round(result.Value, 4).ToString();

            ResultsPanel.Controls.Add(label);
            ResultsPanel.Controls.Add(resultLabel);
        }
    }
}
