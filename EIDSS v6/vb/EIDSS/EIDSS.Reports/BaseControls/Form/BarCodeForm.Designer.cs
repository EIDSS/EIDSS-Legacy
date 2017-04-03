namespace EIDSS.Reports.BaseControls.Form
{
    partial class BarCodeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BarCodeForm));
            this.baseBarcodeKeeper1 = new EIDSS.Reports.BaseControls.Keeper.BaseBarcodeKeeper();
            this.SuspendLayout();
            // 
            // baseBarcodeKeeper1
            // 
            resources.ApplyResources(this.baseBarcodeKeeper1, "baseBarcodeKeeper1");
            this.baseBarcodeKeeper1.MinimumSize = new System.Drawing.Size(320, 200);
            this.baseBarcodeKeeper1.Name = "baseBarcodeKeeper1";
            // 
            // BarCodeForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.baseBarcodeKeeper1);
            this.DoubleBuffered = true;
            this.HelpTopicId = "BarcodePrintDetailForm";
            this.Name = "BarCodeForm";
            this.ResumeLayout(false);

        }

        #endregion

        private EIDSS.Reports.BaseControls.Keeper.BaseBarcodeKeeper baseBarcodeKeeper1;
    }
}