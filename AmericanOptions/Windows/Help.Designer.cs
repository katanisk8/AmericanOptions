namespace AmericanOptions.Windows
{
   partial class Help
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help));
         this.pDFDocumencation = new AxAcroPDFLib.AxAcroPDF();
         ((System.ComponentModel.ISupportInitialize)(this.pDFDocumencation)).BeginInit();
         this.SuspendLayout();
         // 
         // pDFDocumencation
         // 
         this.pDFDocumencation.Enabled = true;
         this.pDFDocumencation.Location = new System.Drawing.Point(12, 12);
         this.pDFDocumencation.Name = "pDFDocumencation";
         this.pDFDocumencation.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pDFDocumencation.OcxState")));
         this.pDFDocumencation.Size = new System.Drawing.Size(810, 737);
         this.pDFDocumencation.TabIndex = 0;
         this.pDFDocumencation.Enter += new System.EventHandler(this.axAcroPDF1_Enter);
         // 
         // Help
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(834, 761);
         this.Controls.Add(this.pDFDocumencation);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.Name = "Help";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Help";
         ((System.ComponentModel.ISupportInitialize)(this.pDFDocumencation)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private AxAcroPDFLib.AxAcroPDF pDFDocumencation;
   }
}