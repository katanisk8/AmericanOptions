namespace AmericanOptions
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.CalculateButton = new System.Windows.Forms.Button();
            this.InputsGroupBox = new System.Windows.Forms.GroupBox();
            this.VolatilitySigmaTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RiskFreeRateTextBox = new System.Windows.Forms.TextBox();
            this.RiskFreeRateLabel = new System.Windows.Forms.Label();
            this.TauTextBox = new System.Windows.Forms.TextBox();
            this.TauLabel = new System.Windows.Forms.Label();
            this.NumberOfIterationTextBox = new System.Windows.Forms.TextBox();
            this.NumberOfIterationLabel = new System.Windows.Forms.Label();
            this.StockPriceTextBox = new System.Windows.Forms.TextBox();
            this.StockPriceLabel = new System.Windows.Forms.Label();
            this.TimeToMaturityTextBox = new System.Windows.Forms.TextBox();
            this.TimeToMaturityLabel = new System.Windows.Forms.Label();
            this.StrikePriceTextBox = new System.Windows.Forms.TextBox();
            this.StrikePriceLabel = new System.Windows.Forms.Label();
            this.ResultGroupBox = new System.Windows.Forms.GroupBox();
            this.IntegralPointD2TextBox = new System.Windows.Forms.TextBox();
            this.IntegralPointD2Label = new System.Windows.Forms.Label();
            this.IntegralPointD1TextBox = new System.Windows.Forms.TextBox();
            this.IntegralPointD1Label = new System.Windows.Forms.Label();
            this.BtK1TextBox = new System.Windows.Forms.TextBox();
            this.BtK1Label = new System.Windows.Forms.Label();
            this.DistributionTextBox = new System.Windows.Forms.TextBox();
            this.DistributionLabel = new System.Windows.Forms.Label();
            this.InputsGroupBox.SuspendLayout();
            this.ResultGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // CalculateButton
            // 
            this.CalculateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CalculateButton.Location = new System.Drawing.Point(572, 319);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(100, 30);
            this.CalculateButton.TabIndex = 1;
            this.CalculateButton.Text = "Calculate";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // InputsGroupBox
            // 
            this.InputsGroupBox.Controls.Add(this.VolatilitySigmaTextBox);
            this.InputsGroupBox.Controls.Add(this.label2);
            this.InputsGroupBox.Controls.Add(this.RiskFreeRateTextBox);
            this.InputsGroupBox.Controls.Add(this.RiskFreeRateLabel);
            this.InputsGroupBox.Controls.Add(this.TauTextBox);
            this.InputsGroupBox.Controls.Add(this.TauLabel);
            this.InputsGroupBox.Controls.Add(this.NumberOfIterationTextBox);
            this.InputsGroupBox.Controls.Add(this.NumberOfIterationLabel);
            this.InputsGroupBox.Controls.Add(this.StockPriceTextBox);
            this.InputsGroupBox.Controls.Add(this.StockPriceLabel);
            this.InputsGroupBox.Controls.Add(this.TimeToMaturityTextBox);
            this.InputsGroupBox.Controls.Add(this.TimeToMaturityLabel);
            this.InputsGroupBox.Controls.Add(this.StrikePriceTextBox);
            this.InputsGroupBox.Controls.Add(this.StrikePriceLabel);
            this.InputsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.InputsGroupBox.Name = "InputsGroupBox";
            this.InputsGroupBox.Size = new System.Drawing.Size(287, 337);
            this.InputsGroupBox.TabIndex = 2;
            this.InputsGroupBox.TabStop = false;
            this.InputsGroupBox.Text = "Inputs Data";
            // 
            // VolatilitySigmaTextBox
            // 
            this.VolatilitySigmaTextBox.Location = new System.Drawing.Point(127, 51);
            this.VolatilitySigmaTextBox.Name = "VolatilitySigmaTextBox";
            this.VolatilitySigmaTextBox.Size = new System.Drawing.Size(100, 20);
            this.VolatilitySigmaTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Volatility sigma:";
            // 
            // RiskFreeRateTextBox
            // 
            this.RiskFreeRateTextBox.Location = new System.Drawing.Point(127, 25);
            this.RiskFreeRateTextBox.Name = "RiskFreeRateTextBox";
            this.RiskFreeRateTextBox.Size = new System.Drawing.Size(100, 20);
            this.RiskFreeRateTextBox.TabIndex = 1;
            // 
            // RiskFreeRateLabel
            // 
            this.RiskFreeRateLabel.AutoSize = true;
            this.RiskFreeRateLabel.Location = new System.Drawing.Point(13, 28);
            this.RiskFreeRateLabel.Name = "RiskFreeRateLabel";
            this.RiskFreeRateLabel.Size = new System.Drawing.Size(79, 13);
            this.RiskFreeRateLabel.TabIndex = 13;
            this.RiskFreeRateLabel.Text = "Risk free rate r:";
            // 
            // TauTextBox
            // 
            this.TauTextBox.Location = new System.Drawing.Point(127, 77);
            this.TauTextBox.Name = "TauTextBox";
            this.TauTextBox.Size = new System.Drawing.Size(100, 20);
            this.TauTextBox.TabIndex = 3;
            // 
            // TauLabel
            // 
            this.TauLabel.AutoSize = true;
            this.TauLabel.Location = new System.Drawing.Point(13, 80);
            this.TauLabel.Name = "TauLabel";
            this.TauLabel.Size = new System.Drawing.Size(35, 13);
            this.TauLabel.TabIndex = 11;
            this.TauLabel.Text = "Tau t:";
            // 
            // NumberOfIterationTextBox
            // 
            this.NumberOfIterationTextBox.Location = new System.Drawing.Point(127, 129);
            this.NumberOfIterationTextBox.Name = "NumberOfIterationTextBox";
            this.NumberOfIterationTextBox.Size = new System.Drawing.Size(100, 20);
            this.NumberOfIterationTextBox.TabIndex = 8;
            // 
            // NumberOfIterationLabel
            // 
            this.NumberOfIterationLabel.AutoSize = true;
            this.NumberOfIterationLabel.Location = new System.Drawing.Point(13, 132);
            this.NumberOfIterationLabel.Name = "NumberOfIterationLabel";
            this.NumberOfIterationLabel.Size = new System.Drawing.Size(108, 13);
            this.NumberOfIterationLabel.TabIndex = 9;
            this.NumberOfIterationLabel.Text = "Number of iteration n:";
            // 
            // StockPriceTextBox
            // 
            this.StockPriceTextBox.Location = new System.Drawing.Point(127, 181);
            this.StockPriceTextBox.Name = "StockPriceTextBox";
            this.StockPriceTextBox.Size = new System.Drawing.Size(100, 20);
            this.StockPriceTextBox.TabIndex = 6;
            // 
            // StockPriceLabel
            // 
            this.StockPriceLabel.AutoSize = true;
            this.StockPriceLabel.Location = new System.Drawing.Point(13, 184);
            this.StockPriceLabel.Name = "StockPriceLabel";
            this.StockPriceLabel.Size = new System.Drawing.Size(74, 13);
            this.StockPriceLabel.TabIndex = 7;
            this.StockPriceLabel.Text = "Stock price S:";
            // 
            // TimeToMaturityTextBox
            // 
            this.TimeToMaturityTextBox.Location = new System.Drawing.Point(127, 155);
            this.TimeToMaturityTextBox.Name = "TimeToMaturityTextBox";
            this.TimeToMaturityTextBox.Size = new System.Drawing.Size(100, 20);
            this.TimeToMaturityTextBox.TabIndex = 4;
            // 
            // TimeToMaturityLabel
            // 
            this.TimeToMaturityLabel.AutoSize = true;
            this.TimeToMaturityLabel.Location = new System.Drawing.Point(13, 158);
            this.TimeToMaturityLabel.Name = "TimeToMaturityLabel";
            this.TimeToMaturityLabel.Size = new System.Drawing.Size(94, 13);
            this.TimeToMaturityLabel.TabIndex = 5;
            this.TimeToMaturityLabel.Text = "Time to maturity T:";
            // 
            // StrikePriceTextBox
            // 
            this.StrikePriceTextBox.Location = new System.Drawing.Point(127, 103);
            this.StrikePriceTextBox.Name = "StrikePriceTextBox";
            this.StrikePriceTextBox.Size = new System.Drawing.Size(100, 20);
            this.StrikePriceTextBox.TabIndex = 3;
            // 
            // StrikePriceLabel
            // 
            this.StrikePriceLabel.AutoSize = true;
            this.StrikePriceLabel.Location = new System.Drawing.Point(13, 106);
            this.StrikePriceLabel.Name = "StrikePriceLabel";
            this.StrikePriceLabel.Size = new System.Drawing.Size(73, 13);
            this.StrikePriceLabel.TabIndex = 3;
            this.StrikePriceLabel.Text = "Strike price K:";
            // 
            // ResultGroupBox
            // 
            this.ResultGroupBox.Controls.Add(this.DistributionTextBox);
            this.ResultGroupBox.Controls.Add(this.DistributionLabel);
            this.ResultGroupBox.Controls.Add(this.IntegralPointD2TextBox);
            this.ResultGroupBox.Controls.Add(this.IntegralPointD2Label);
            this.ResultGroupBox.Controls.Add(this.IntegralPointD1TextBox);
            this.ResultGroupBox.Controls.Add(this.IntegralPointD1Label);
            this.ResultGroupBox.Controls.Add(this.BtK1TextBox);
            this.ResultGroupBox.Controls.Add(this.BtK1Label);
            this.ResultGroupBox.Location = new System.Drawing.Point(305, 12);
            this.ResultGroupBox.Name = "ResultGroupBox";
            this.ResultGroupBox.Size = new System.Drawing.Size(233, 256);
            this.ResultGroupBox.TabIndex = 3;
            this.ResultGroupBox.TabStop = false;
            this.ResultGroupBox.Text = "Result";
            // 
            // IntegralPointD2TextBox
            // 
            this.IntegralPointD2TextBox.Location = new System.Drawing.Point(105, 51);
            this.IntegralPointD2TextBox.Name = "IntegralPointD2TextBox";
            this.IntegralPointD2TextBox.ReadOnly = true;
            this.IntegralPointD2TextBox.Size = new System.Drawing.Size(100, 20);
            this.IntegralPointD2TextBox.TabIndex = 16;
            // 
            // IntegralPointD2Label
            // 
            this.IntegralPointD2Label.AutoSize = true;
            this.IntegralPointD2Label.Location = new System.Drawing.Point(13, 54);
            this.IntegralPointD2Label.Name = "IntegralPointD2Label";
            this.IntegralPointD2Label.Size = new System.Drawing.Size(86, 13);
            this.IntegralPointD2Label.TabIndex = 17;
            this.IntegralPointD2Label.Text = "Integral point d2:";
            // 
            // IntegralPointD1TextBox
            // 
            this.IntegralPointD1TextBox.Location = new System.Drawing.Point(105, 22);
            this.IntegralPointD1TextBox.Name = "IntegralPointD1TextBox";
            this.IntegralPointD1TextBox.ReadOnly = true;
            this.IntegralPointD1TextBox.Size = new System.Drawing.Size(100, 20);
            this.IntegralPointD1TextBox.TabIndex = 10;
            // 
            // IntegralPointD1Label
            // 
            this.IntegralPointD1Label.AutoSize = true;
            this.IntegralPointD1Label.Location = new System.Drawing.Point(13, 25);
            this.IntegralPointD1Label.Name = "IntegralPointD1Label";
            this.IntegralPointD1Label.Size = new System.Drawing.Size(86, 13);
            this.IntegralPointD1Label.TabIndex = 11;
            this.IntegralPointD1Label.Text = "Integral point d1:";
            // 
            // BtK1TextBox
            // 
            this.BtK1TextBox.Location = new System.Drawing.Point(105, 106);
            this.BtK1TextBox.Name = "BtK1TextBox";
            this.BtK1TextBox.ReadOnly = true;
            this.BtK1TextBox.Size = new System.Drawing.Size(100, 20);
            this.BtK1TextBox.TabIndex = 8;
            // 
            // BtK1Label
            // 
            this.BtK1Label.AutoSize = true;
            this.BtK1Label.Location = new System.Drawing.Point(13, 109);
            this.BtK1Label.Name = "BtK1Label";
            this.BtK1Label.Size = new System.Drawing.Size(45, 13);
            this.BtK1Label.TabIndex = 9;
            this.BtK1Label.Text = "Bt, K=1:";
            // 
            // DistributionTextBox
            // 
            this.DistributionTextBox.Location = new System.Drawing.Point(105, 80);
            this.DistributionTextBox.Name = "DistributionTextBox";
            this.DistributionTextBox.ReadOnly = true;
            this.DistributionTextBox.Size = new System.Drawing.Size(100, 20);
            this.DistributionTextBox.TabIndex = 18;
            // 
            // DistributionLabel
            // 
            this.DistributionLabel.AutoSize = true;
            this.DistributionLabel.Location = new System.Drawing.Point(13, 83);
            this.DistributionLabel.Name = "DistributionLabel";
            this.DistributionLabel.Size = new System.Drawing.Size(62, 13);
            this.DistributionLabel.TabIndex = 19;
            this.DistributionLabel.Text = "Distribution:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.Controls.Add(this.ResultGroupBox);
            this.Controls.Add(this.InputsGroupBox);
            this.Controls.Add(this.CalculateButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "American Options";
            this.InputsGroupBox.ResumeLayout(false);
            this.InputsGroupBox.PerformLayout();
            this.ResultGroupBox.ResumeLayout(false);
            this.ResultGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

      #endregion

      private System.Windows.Forms.Button CalculateButton;
      private System.Windows.Forms.GroupBox InputsGroupBox;
        private System.Windows.Forms.TextBox TimeToMaturityTextBox;
        private System.Windows.Forms.Label TimeToMaturityLabel;
        private System.Windows.Forms.TextBox StrikePriceTextBox;
        private System.Windows.Forms.Label StrikePriceLabel;
        private System.Windows.Forms.TextBox NumberOfIterationTextBox;
        private System.Windows.Forms.Label NumberOfIterationLabel;
        private System.Windows.Forms.TextBox StockPriceTextBox;
        private System.Windows.Forms.Label StockPriceLabel;
        private System.Windows.Forms.GroupBox ResultGroupBox;
        private System.Windows.Forms.TextBox BtK1TextBox;
        private System.Windows.Forms.Label BtK1Label;
        private System.Windows.Forms.TextBox TauTextBox;
        private System.Windows.Forms.Label TauLabel;
        private System.Windows.Forms.TextBox IntegralPointD1TextBox;
        private System.Windows.Forms.Label IntegralPointD1Label;
        private System.Windows.Forms.TextBox RiskFreeRateTextBox;
        private System.Windows.Forms.Label RiskFreeRateLabel;
        private System.Windows.Forms.TextBox VolatilitySigmaTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IntegralPointD2TextBox;
        private System.Windows.Forms.Label IntegralPointD2Label;
        private System.Windows.Forms.TextBox DistributionTextBox;
        private System.Windows.Forms.Label DistributionLabel;
    }
}

