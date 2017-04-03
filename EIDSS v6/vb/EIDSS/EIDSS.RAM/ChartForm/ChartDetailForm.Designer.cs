namespace eidss.avr.ChartForm
{
    partial class ChartDetailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

       

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartDetailForm));
            this.ChartDetail = new eidss.avr.ChartForm.ChartDetailPanel();
            this.PrintChartButton = new DevExpress.XtraEditors.SimpleButton();
            this.ExportChartButton = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(ChartDetailForm), out resources);
            // Form Is Localizable: True
            // 
            // ChartDetail
            // 
            resources.ApplyResources(this.ChartDetail, "ChartDetail");
            this.ChartDetail.ChartName = "";
            this.ChartDetail.DataSource = null;
            this.ChartDetail.FormID = null;
            this.ChartDetail.HelpTopicID = null;
            this.ChartDetail.KeyFieldName = null;
            this.ChartDetail.MultiSelect = false;
            this.ChartDetail.Name = "ChartDetail";
            this.ChartDetail.ObjectName = null;
            this.ChartDetail.SilenceMode = false;
            this.ChartDetail.TableName = null;
            // 
            // PrintChartButton
            // 
            resources.ApplyResources(this.PrintChartButton, "PrintChartButton");
            this.PrintChartButton.Name = "PrintChartButton";
            this.PrintChartButton.Click += new System.EventHandler(this.PrintChartButton_Click);
            // 
            // ExportChartButton
            // 
            resources.ApplyResources(this.ExportChartButton, "ExportChartButton");
            this.ExportChartButton.Name = "ExportChartButton";
            this.ExportChartButton.Click += new System.EventHandler(this.ExportChartButton_Click);
            // 
            // ChartDetailForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.PrintChartButton);
            this.Controls.Add(this.ExportChartButton);
            this.Controls.Add(this.ChartDetail);
            this.DefaultFormState = System.Windows.Forms.FormWindowState.Normal;
            this.HelpTopicID = "Chart_Editor";
            this.MinHeight = 620;
            this.MinWidth = 620;
            this.Name = "ChartDetailForm";
            this.ShowSaveButton = false;
            this.Sizable = true;
            this.Status = bv.common.win.FormStatus.Draft;
            this.Controls.SetChildIndex(this.ChartDetail, 0);
            this.Controls.SetChildIndex(this.ExportChartButton, 0);
            this.Controls.SetChildIndex(this.PrintChartButton, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private ChartDetailPanel ChartDetail;
        private DevExpress.XtraEditors.SimpleButton PrintChartButton;
        private DevExpress.XtraEditors.SimpleButton ExportChartButton;
    }
}
