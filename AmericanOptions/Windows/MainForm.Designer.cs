namespace AmericanOptions.Windows
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
            this.NumberOfNodesTextBox = new System.Windows.Forms.TextBox();
            this.NumberOfIterationTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.VolatilitySigmaTextBox = new System.Windows.Forms.TextBox();
            this.VolatilitySigmaLabel = new System.Windows.Forms.Label();
            this.RiskFreeRateTextBox = new System.Windows.Forms.TextBox();
            this.RiskFreeRateLabel = new System.Windows.Forms.Label();
            this.TauTextBox = new System.Windows.Forms.TextBox();
            this.TauLabel = new System.Windows.Forms.Label();
            this.NumberOfIterationLabel = new System.Windows.Forms.Label();
            this.StockPriceTextBox = new System.Windows.Forms.TextBox();
            this.StockPriceLabel = new System.Windows.Forms.Label();
            this.TimeToMaturityTextBox = new System.Windows.Forms.TextBox();
            this.TimeToMaturityLabel = new System.Windows.Forms.Label();
            this.StrikePriceTextBox = new System.Windows.Forms.TextBox();
            this.StrikePriceLabel = new System.Windows.Forms.Label();
            this.ClearButton = new System.Windows.Forms.Button();
            this.DefaultButton = new System.Windows.Forms.Button();
            this.ResultsPanel = new System.Windows.Forms.Panel();
            this.ResultsGroupBox = new System.Windows.Forms.GroupBox();
            this.InputsGroupBox.SuspendLayout();
            this.ResultsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // CalculateButton
            // 
            this.CalculateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CalculateButton.Location = new System.Drawing.Point(12, 289);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(197, 30);
            this.CalculateButton.TabIndex = 9;
            this.CalculateButton.Text = "Calculate";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // InputsGroupBox
            // 
            this.InputsGroupBox.Controls.Add(this.NumberOfNodesTextBox);
            this.InputsGroupBox.Controls.Add(this.NumberOfIterationTextBox);
            this.InputsGroupBox.Controls.Add(this.label1);
            this.InputsGroupBox.Controls.Add(this.VolatilitySigmaTextBox);
            this.InputsGroupBox.Controls.Add(this.VolatilitySigmaLabel);
            this.InputsGroupBox.Controls.Add(this.RiskFreeRateTextBox);
            this.InputsGroupBox.Controls.Add(this.RiskFreeRateLabel);
            this.InputsGroupBox.Controls.Add(this.TauTextBox);
            this.InputsGroupBox.Controls.Add(this.TauLabel);
            this.InputsGroupBox.Controls.Add(this.NumberOfIterationLabel);
            this.InputsGroupBox.Controls.Add(this.StockPriceTextBox);
            this.InputsGroupBox.Controls.Add(this.StockPriceLabel);
            this.InputsGroupBox.Controls.Add(this.TimeToMaturityTextBox);
            this.InputsGroupBox.Controls.Add(this.TimeToMaturityLabel);
            this.InputsGroupBox.Controls.Add(this.StrikePriceTextBox);
            this.InputsGroupBox.Controls.Add(this.StrikePriceLabel);
            this.InputsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.InputsGroupBox.Name = "InputsGroupBox";
            this.InputsGroupBox.Size = new System.Drawing.Size(197, 235);
            this.InputsGroupBox.TabIndex = 2;
            this.InputsGroupBox.TabStop = false;
            this.InputsGroupBox.Text = "Input Data";
            // 
            // NumberOfNodesTextBox
            // 
            this.NumberOfNodesTextBox.Location = new System.Drawing.Point(127, 181);
            this.NumberOfNodesTextBox.Name = "NumberOfNodesTextBox";
            this.NumberOfNodesTextBox.Size = new System.Drawing.Size(60, 20);
            this.NumberOfNodesTextBox.TabIndex = 7;
            this.NumberOfNodesTextBox.Tag = "Number Of Nodes n";
            this.NumberOfNodesTextBox.Text = "4";
            // 
            // NumberOfIterationTextBox
            // 
            this.NumberOfIterationTextBox.Location = new System.Drawing.Point(127, 155);
            this.NumberOfIterationTextBox.Name = "NumberOfIterationTextBox";
            this.NumberOfIterationTextBox.Size = new System.Drawing.Size(60, 20);
            this.NumberOfIterationTextBox.TabIndex = 6;
            this.NumberOfIterationTextBox.Tag = "Number Of Iteration k";
            this.NumberOfIterationTextBox.Text = "16";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Number of nodes n:";
            // 
            // VolatilitySigmaTextBox
            // 
            this.VolatilitySigmaTextBox.Location = new System.Drawing.Point(127, 51);
            this.VolatilitySigmaTextBox.Name = "VolatilitySigmaTextBox";
            this.VolatilitySigmaTextBox.Size = new System.Drawing.Size(60, 20);
            this.VolatilitySigmaTextBox.TabIndex = 2;
            this.VolatilitySigmaTextBox.Tag = "Volatility sigma";
            this.VolatilitySigmaTextBox.Text = "0,2";
            // 
            // VolatilitySigmaLabel
            // 
            this.VolatilitySigmaLabel.AutoSize = true;
            this.VolatilitySigmaLabel.Location = new System.Drawing.Point(13, 54);
            this.VolatilitySigmaLabel.Name = "VolatilitySigmaLabel";
            this.VolatilitySigmaLabel.Size = new System.Drawing.Size(78, 13);
            this.VolatilitySigmaLabel.TabIndex = 15;
            this.VolatilitySigmaLabel.Text = "Volatility sigma:";
            // 
            // RiskFreeRateTextBox
            // 
            this.RiskFreeRateTextBox.Location = new System.Drawing.Point(127, 25);
            this.RiskFreeRateTextBox.Name = "RiskFreeRateTextBox";
            this.RiskFreeRateTextBox.Size = new System.Drawing.Size(60, 20);
            this.RiskFreeRateTextBox.TabIndex = 1;
            this.RiskFreeRateTextBox.Tag = "Risk free rate r";
            this.RiskFreeRateTextBox.Text = "0,05";
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
            this.TauTextBox.Size = new System.Drawing.Size(60, 20);
            this.TauTextBox.TabIndex = 3;
            this.TauTextBox.Tag = "Tau t";
            this.TauTextBox.Text = "1";
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
            // NumberOfIterationLabel
            // 
            this.NumberOfIterationLabel.AutoSize = true;
            this.NumberOfIterationLabel.Location = new System.Drawing.Point(13, 158);
            this.NumberOfIterationLabel.Name = "NumberOfIterationLabel";
            this.NumberOfIterationLabel.Size = new System.Drawing.Size(108, 13);
            this.NumberOfIterationLabel.TabIndex = 9;
            this.NumberOfIterationLabel.Text = "Number of iteration k:";
            // 
            // StockPriceTextBox
            // 
            this.StockPriceTextBox.Location = new System.Drawing.Point(127, 129);
            this.StockPriceTextBox.Name = "StockPriceTextBox";
            this.StockPriceTextBox.Size = new System.Drawing.Size(60, 20);
            this.StockPriceTextBox.TabIndex = 5;
            this.StockPriceTextBox.Tag = "Stock price S";
            this.StockPriceTextBox.Text = "45";
            // 
            // StockPriceLabel
            // 
            this.StockPriceLabel.AutoSize = true;
            this.StockPriceLabel.Location = new System.Drawing.Point(13, 132);
            this.StockPriceLabel.Name = "StockPriceLabel";
            this.StockPriceLabel.Size = new System.Drawing.Size(74, 13);
            this.StockPriceLabel.TabIndex = 7;
            this.StockPriceLabel.Text = "Stock price S:";
            // 
            // TimeToMaturityTextBox
            // 
            this.TimeToMaturityTextBox.Location = new System.Drawing.Point(127, 207);
            this.TimeToMaturityTextBox.Name = "TimeToMaturityTextBox";
            this.TimeToMaturityTextBox.Size = new System.Drawing.Size(60, 20);
            this.TimeToMaturityTextBox.TabIndex = 8;
            this.TimeToMaturityTextBox.Tag = "Time to maturity T";
            this.TimeToMaturityTextBox.Text = "1";
            // 
            // TimeToMaturityLabel
            // 
            this.TimeToMaturityLabel.AutoSize = true;
            this.TimeToMaturityLabel.Location = new System.Drawing.Point(13, 210);
            this.TimeToMaturityLabel.Name = "TimeToMaturityLabel";
            this.TimeToMaturityLabel.Size = new System.Drawing.Size(94, 13);
            this.TimeToMaturityLabel.TabIndex = 5;
            this.TimeToMaturityLabel.Text = "Time to maturity T:";
            // 
            // StrikePriceTextBox
            // 
            this.StrikePriceTextBox.Location = new System.Drawing.Point(127, 103);
            this.StrikePriceTextBox.Name = "StrikePriceTextBox";
            this.StrikePriceTextBox.Size = new System.Drawing.Size(60, 20);
            this.StrikePriceTextBox.TabIndex = 4;
            this.StrikePriceTextBox.Tag = "Strike price K";
            this.StrikePriceTextBox.Text = "45";
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
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(12, 253);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(95, 30);
            this.ClearButton.TabIndex = 10;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // DefaultButton
            // 
            this.DefaultButton.Location = new System.Drawing.Point(114, 253);
            this.DefaultButton.Name = "DefaultButton";
            this.DefaultButton.Size = new System.Drawing.Size(95, 30);
            this.DefaultButton.TabIndex = 11;
            this.DefaultButton.Text = "Default";
            this.DefaultButton.UseVisualStyleBackColor = true;
            this.DefaultButton.Click += new System.EventHandler(this.DefaultButton_Click);
            // 
            // ResultsPanel
            // 
            this.ResultsPanel.AutoScroll = true;
            this.ResultsPanel.Location = new System.Drawing.Point(6, 19);
            this.ResultsPanel.Name = "ResultsPanel";
            this.ResultsPanel.Size = new System.Drawing.Size(238, 281);
            this.ResultsPanel.TabIndex = 6;
            // 
            // ResultsGroupBox
            // 
            this.ResultsGroupBox.Controls.Add(this.ResultsPanel);
            this.ResultsGroupBox.Location = new System.Drawing.Point(215, 12);
            this.ResultsGroupBox.Name = "ResultsGroupBox";
            this.ResultsGroupBox.Size = new System.Drawing.Size(250, 306);
            this.ResultsGroupBox.TabIndex = 13;
            this.ResultsGroupBox.TabStop = false;
            this.ResultsGroupBox.Text = "Results";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 327);
            this.Controls.Add(this.ResultsGroupBox);
            this.Controls.Add(this.DefaultButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.InputsGroupBox);
            this.Controls.Add(this.CalculateButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "American Options";
            this.InputsGroupBox.ResumeLayout(false);
            this.InputsGroupBox.PerformLayout();
            this.ResultsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

      #endregion

      private System.Windows.Forms.Button CalculateButton;
      private System.Windows.Forms.GroupBox InputsGroupBox;
        private System.Windows.Forms.TextBox TimeToMaturityTextBox;
        private System.Windows.Forms.Label TimeToMaturityLabel;
        private System.Windows.Forms.TextBox StrikePriceTextBox;
        private System.Windows.Forms.Label StrikePriceLabel;
        private System.Windows.Forms.Label NumberOfIterationLabel;
        private System.Windows.Forms.TextBox StockPriceTextBox;
        private System.Windows.Forms.Label StockPriceLabel;
        private System.Windows.Forms.TextBox TauTextBox;
        private System.Windows.Forms.Label TauLabel;
        private System.Windows.Forms.TextBox RiskFreeRateTextBox;
        private System.Windows.Forms.Label RiskFreeRateLabel;
        private System.Windows.Forms.TextBox VolatilitySigmaTextBox;
        private System.Windows.Forms.Label VolatilitySigmaLabel;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DefaultButton;
        private System.Windows.Forms.Panel ResultsPanel;
        private System.Windows.Forms.GroupBox ResultsGroupBox;
        private System.Windows.Forms.TextBox NumberOfNodesTextBox;
        private System.Windows.Forms.TextBox NumberOfIterationTextBox;
    }
}

