using System.ComponentModel;
using System.Windows.Forms;
using bv.common.Resources;
using bv.common.win;
using eidss.avr.ChartForm;

namespace eidss.avr.MapForm
{
    partial class MapDetailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

       

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapDetailForm));
            this.ExportMapButton = new DevExpress.XtraEditors.SimpleButton();
            this.PrintMapButton = new DevExpress.XtraEditors.SimpleButton();
            this.ChangeCaptionTimer = new System.Windows.Forms.Timer(this.components);
            this.MapDetail = new eidss.avr.MapForm.MapDetailPanel();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(MapDetailForm), out resources);
            // Form Is Localizable: True
            // 
            // ExportMapButton
            // 
            resources.ApplyResources(this.ExportMapButton, "ExportMapButton");
            this.ExportMapButton.Name = "ExportMapButton";
            this.ExportMapButton.Click += new System.EventHandler(this.ExportMapButton_Click);
            // 
            // PrintMapButton
            // 
            resources.ApplyResources(this.PrintMapButton, "PrintMapButton");
            this.PrintMapButton.Name = "PrintMapButton";
            this.PrintMapButton.Click += new System.EventHandler(this.PrintMapButton_Click);
            // 
            // ChangeCaptionTimer
            // 
            this.ChangeCaptionTimer.Enabled = true;
            this.ChangeCaptionTimer.Interval = 200;
            this.ChangeCaptionTimer.Tick += new System.EventHandler(this.ChangeCaptionTimer_Tick);
            // 
            // MapDetail
            // 
            resources.ApplyResources(this.MapDetail, "MapDetail");
            this.MapDetail.FormID = null;
            this.MapDetail.HelpTopicID = null;
            this.MapDetail.KeyFieldName = null;
            this.MapDetail.MultiSelect = false;
            this.MapDetail.Name = "MapDetail";
            this.MapDetail.ObjectName = null;
            this.MapDetail.TableName = null;
            this.MapDetail.UseParentDataset = true;
            // 
            // MapDetailForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.PrintMapButton);
            this.Controls.Add(this.ExportMapButton);
            this.Controls.Add(this.MapDetail);
            this.DefaultFormState = System.Windows.Forms.FormWindowState.Normal;
            this.HelpTopicID = "Map_Editor";
            this.MinHeight = 620;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.MinWidth = 620;
            this.Name = "MapDetailForm";
            this.ShowSaveButton = false;
            this.Sizable = true;
            this.Status = bv.common.win.FormStatus.Draft;
            this.Controls.SetChildIndex(this.MapDetail, 0);
            this.Controls.SetChildIndex(this.ExportMapButton, 0);
            this.Controls.SetChildIndex(this.PrintMapButton, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private MapDetailPanel MapDetail;
        private DevExpress.XtraEditors.SimpleButton ExportMapButton;
        private DevExpress.XtraEditors.SimpleButton PrintMapButton;
        private Timer ChangeCaptionTimer;
    }
}
