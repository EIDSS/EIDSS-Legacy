using System.Windows.Forms;
using DevExpress.XtraEditors;
using bv.winclient.Core;

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
            this.mainPanelContainer = new BvScrollableControl();
            this.commonPanel2 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.btSearch = new DevExpress.XtraEditors.SimpleButton();
            this.btClear = new DevExpress.XtraEditors.SimpleButton();
            this.commonPanel2.SuspendLayout();
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
            this.commonPanel2.Controls.Add(this.btSearch);
            this.commonPanel2.Controls.Add(this.btClear);
            this.commonPanel2.Name = "commonPanel2";
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
            this.Controls.Add(this.commonPanel2);
            this.Name = "BaseSearchPanel";
            this.commonPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btSearch;
        private DevExpress.XtraEditors.SimpleButton btClear;
        private BvScrollableControl mainPanelContainer;
        private XtraScrollableControl commonPanel2;
    }
}
