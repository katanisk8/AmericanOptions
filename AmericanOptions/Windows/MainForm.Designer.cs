using System.Windows.Forms;

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
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this.CalculateButton = new System.Windows.Forms.Button();
         this.InputsGroupBox = new System.Windows.Forms.GroupBox();
         this.NumberOfNodesTextBox = new System.Windows.Forms.TextBox();
         this.NumberOfIterationTextBox = new System.Windows.Forms.TextBox();
         this.NumberOfNodesLabel = new System.Windows.Forms.Label();
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
         this.ResultListView = new System.Windows.Forms.ListView();
         this.IterationColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.BtColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.PutColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
         this.MemoryLabel = new System.Windows.Forms.ToolStripStatusLabel();
         this.CalculateProgressBar = new System.Windows.Forms.ToolStripProgressBar();
         this.StripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
         this.CancelButton = new System.Windows.Forms.Button();
         this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
         this.InputsGroupBox.SuspendLayout();
         this.MainStatusStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // CalculateButton
         // 
         this.CalculateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
         this.CalculateButton.Location = new System.Drawing.Point(114, 279);
         this.CalculateButton.Name = "CalculateButton";
         this.CalculateButton.Size = new System.Drawing.Size(95, 30);
         this.CalculateButton.TabIndex = 9;
         this.CalculateButton.Text = "Calculate";
         this.CalculateButton.UseVisualStyleBackColor = true;
         this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
         // 
         // InputsGroupBox
         // 
         this.InputsGroupBox.Controls.Add(this.NumberOfNodesTextBox);
         this.InputsGroupBox.Controls.Add(this.NumberOfIterationTextBox);
         this.InputsGroupBox.Controls.Add(this.NumberOfNodesLabel);
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
         // 
         // NumberOfIterationTextBox
         // 
         this.NumberOfIterationTextBox.Location = new System.Drawing.Point(127, 155);
         this.NumberOfIterationTextBox.Name = "NumberOfIterationTextBox";
         this.NumberOfIterationTextBox.Size = new System.Drawing.Size(60, 20);
         this.NumberOfIterationTextBox.TabIndex = 6;
         this.NumberOfIterationTextBox.Tag = "Number Of Iteration k";
         // 
         // NumberOfNodesLabel
         // 
         this.NumberOfNodesLabel.AutoSize = true;
         this.NumberOfNodesLabel.Location = new System.Drawing.Point(13, 184);
         this.NumberOfNodesLabel.Name = "NumberOfNodesLabel";
         this.NumberOfNodesLabel.Size = new System.Drawing.Size(100, 13);
         this.NumberOfNodesLabel.TabIndex = 17;
         this.NumberOfNodesLabel.Text = "Number of nodes n:";
         // 
         // VolatilitySigmaTextBox
         // 
         this.VolatilitySigmaTextBox.Location = new System.Drawing.Point(127, 51);
         this.VolatilitySigmaTextBox.Name = "VolatilitySigmaTextBox";
         this.VolatilitySigmaTextBox.Size = new System.Drawing.Size(60, 20);
         this.VolatilitySigmaTextBox.TabIndex = 2;
         this.VolatilitySigmaTextBox.Tag = "Volatility sigma";
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
         this.ClearButton.Size = new System.Drawing.Size(95, 20);
         this.ClearButton.TabIndex = 10;
         this.ClearButton.Text = "Clear";
         this.ClearButton.UseVisualStyleBackColor = true;
         this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
         // 
         // DefaultButton
         // 
         this.DefaultButton.Location = new System.Drawing.Point(114, 253);
         this.DefaultButton.Name = "DefaultButton";
         this.DefaultButton.Size = new System.Drawing.Size(95, 20);
         this.DefaultButton.TabIndex = 11;
         this.DefaultButton.Text = "Default";
         this.DefaultButton.UseVisualStyleBackColor = true;
         this.DefaultButton.Click += new System.EventHandler(this.DefaultButton_Click);
         // 
         // ResultListView
         // 
         this.ResultListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
         this.ResultListView.Alignment = System.Windows.Forms.ListViewAlignment.Default;
         this.ResultListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IterationColumn,
            this.BtColumn,
            this.PutColumn});
         this.ResultListView.Cursor = System.Windows.Forms.Cursors.Arrow;
         this.ResultListView.FullRowSelect = true;
         this.ResultListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
         this.ResultListView.Location = new System.Drawing.Point(215, 18);
         this.ResultListView.Name = "ResultListView";
         this.ResultListView.Size = new System.Drawing.Size(230, 291);
         this.ResultListView.TabIndex = 12;
         this.ResultListView.UseCompatibleStateImageBehavior = false;
         this.ResultListView.View = System.Windows.Forms.View.Details;
         // 
         // IterationColumn
         // 
         this.IterationColumn.Text = "Iteration";
         this.IterationColumn.Width = 53;
         // 
         // BtColumn
         // 
         this.BtColumn.Text = "Boundary";
         this.BtColumn.Width = 75;
         // 
         // PutColumn
         // 
         this.PutColumn.Text = "Put";
         this.PutColumn.Width = 75;
         // 
         // MainStatusStrip
         // 
         this.MainStatusStrip.Font = new System.Drawing.Font("Segoe UI", 8F);
         this.MainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MemoryLabel,
            this.CalculateProgressBar,
            this.StripStatusLabel});
         this.MainStatusStrip.Location = new System.Drawing.Point(0, 320);
         this.MainStatusStrip.Name = "MainStatusStrip";
         this.MainStatusStrip.Size = new System.Drawing.Size(451, 22);
         this.MainStatusStrip.SizingGrip = false;
         this.MainStatusStrip.TabIndex = 15;
         this.MainStatusStrip.Text = "statusStrip1";
         // 
         // MemoryLabel
         // 
         this.MemoryLabel.Name = "MemoryLabel";
         this.MemoryLabel.Size = new System.Drawing.Size(27, 17);
         this.MemoryLabel.Text = "Size";
         // 
         // CalculateProgressBar
         // 
         this.CalculateProgressBar.Name = "CalculateProgressBar";
         this.CalculateProgressBar.Size = new System.Drawing.Size(100, 16);
         // 
         // StripStatusLabel
         // 
         this.StripStatusLabel.Name = "StripStatusLabel";
         this.StripStatusLabel.Size = new System.Drawing.Size(39, 17);
         this.StripStatusLabel.Text = "Status";
         // 
         // CancelButton
         // 
         this.CancelButton.Location = new System.Drawing.Point(13, 279);
         this.CancelButton.Name = "CancelButton";
         this.CancelButton.Size = new System.Drawing.Size(95, 30);
         this.CancelButton.TabIndex = 16;
         this.CancelButton.Text = "Cancel";
         this.CancelButton.UseVisualStyleBackColor = true;
         this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
         // 
         // UpdateTimer
         // 
         this.UpdateTimer.Enabled = true;
         this.UpdateTimer.Interval = 1000;
         this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(451, 342);
         this.Controls.Add(this.CancelButton);
         this.Controls.Add(this.MainStatusStrip);
         this.Controls.Add(this.ResultListView);
         this.Controls.Add(this.DefaultButton);
         this.Controls.Add(this.ClearButton);
         this.Controls.Add(this.InputsGroupBox);
         this.Controls.Add(this.CalculateButton);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.HelpButton = true;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "American Options";
         this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.MainForm_HelpButtonClicked);
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.InputsGroupBox.ResumeLayout(false);
         this.InputsGroupBox.PerformLayout();
         this.MainStatusStrip.ResumeLayout(false);
         this.MainStatusStrip.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

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
      private System.Windows.Forms.Label NumberOfNodesLabel;
      private System.Windows.Forms.Button DefaultButton;
      private System.Windows.Forms.TextBox NumberOfNodesTextBox;
      private System.Windows.Forms.TextBox NumberOfIterationTextBox;
      private System.Windows.Forms.ColumnHeader IterationColumn;
      private System.Windows.Forms.ColumnHeader BtColumn;
      private System.Windows.Forms.ColumnHeader PutColumn;
      private System.Windows.Forms.ListView ResultListView;
      private System.Windows.Forms.StatusStrip MainStatusStrip;
      private System.Windows.Forms.ToolStripProgressBar CalculateProgressBar;
      private System.Windows.Forms.ToolStripStatusLabel StripStatusLabel;
      private System.Windows.Forms.Button CancelButton;
      private System.Windows.Forms.ToolStripStatusLabel MemoryLabel;
      private Timer UpdateTimer;
   }
}

