using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace bv.winclient.SearchPanel
{
    partial class BaseSearchPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseSearchPanel));
            this.mainPanelContainer = new DevExpress.XtraEditors.XtraScrollableControl();
            this.commonPanel2 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.commonPanel = new DevExpress.XtraEditors.PanelControl();
            this.btSearch = new DevExpress.XtraEditors.SimpleButton();
            this.btClear = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.commonPanel)).BeginInit();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(BaseSearchPanel), out resources);
            // Form Is Localizable: True
            // 
            // mainPanelContainer
            // 
            resources.ApplyResources(this.mainPanelContainer, "mainPanelContainer");
            this.mainPanelContainer.Name = "mainPanelContainer";
            this.mainPanelContainer.VisibleChanged += new System.EventHandler(this.mainPanelContainer_VisibleChanged);
            // 
            // commonPanel2
            // 
            resources.ApplyResources(this.commonPanel2, "commonPanel2");
            this.commonPanel2.Name = "commonPanel2";
            // 
            // commonPanel
            // 
            resources.ApplyResources(this.commonPanel, "commonPanel");
            this.commonPanel.Name = "commonPanel";
            // 
            // btSearch
            // 
            resources.ApplyResources(this.btSearch, "btSearch");
            this.btSearch.Name = "btSearch";
            this.btSearch.Click += new System.EventHandler(this.BtSearchClick);
            // 
            // btClear
            // 
            resources.ApplyResources(this.btClear, "btClear");
            this.btClear.Name = "btClear";
            this.btClear.Click += new System.EventHandler(this.BtClearClick);
            // 
            // BaseSearchPanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanelContainer);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.commonPanel2);
            this.Name = "BaseSearchPanel";
            ((System.ComponentModel.ISupportInitialize)(this.commonPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btSearch;
        private DevExpress.XtraEditors.SimpleButton btClear;
        //private DevExpress.XtraEditors.LabelControl lblFrom;
        //private DevExpress.XtraEditors.LabelControl lblTo;
        private XtraScrollableControl mainPanelContainer;
        private DevExpress.XtraEditors.PanelControl commonPanel;
        private XtraScrollableControl commonPanel2;
    }
}
