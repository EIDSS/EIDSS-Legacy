namespace EIDSS.RAM.Layout
{
    partial class LayoutInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LayoutInfo));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grcLayout = new DevExpress.XtraEditors.GroupControl();
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.layoutTreeListKeeper = new EIDSS.RAM.Layout.LayoutTreeListKeeper();
            this.pceLayout = new DevExpress.XtraEditors.PopupContainerEdit();
            this.memDescription = new DevExpress.XtraEditors.MemoEdit();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblLayout = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grcLayout)).BeginInit();
            this.grcLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            this.popupContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pceLayout.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grcLayout
            // 
            this.grcLayout.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.grcLayout.Appearance.Options.UseBackColor = true;
            this.grcLayout.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grcLayout.Controls.Add(this.popupContainerControl1);
            this.grcLayout.Controls.Add(this.pceLayout);
            this.grcLayout.Controls.Add(this.memDescription);
            this.grcLayout.Controls.Add(this.lblDescription);
            this.grcLayout.Controls.Add(this.lblLayout);
            resources.ApplyResources(this.grcLayout, "grcLayout");
            this.grcLayout.Name = "grcLayout";
            this.grcLayout.ShowCaption = false;
            // 
            // popupContainerControl1
            // 
            resources.ApplyResources(this.popupContainerControl1, "popupContainerControl1");
            this.popupContainerControl1.Controls.Add(this.layoutTreeListKeeper);
            this.popupContainerControl1.Name = "popupContainerControl1";
            // 
            // layoutTreeListKeeper
            // 
            resources.ApplyResources(this.layoutTreeListKeeper, "layoutTreeListKeeper");
            this.layoutTreeListKeeper.Name = "layoutTreeListKeeper";
            
            // 
            // pceLayout
            // 
            resources.ApplyResources(this.pceLayout, "pceLayout");
            this.pceLayout.Name = "pceLayout";
            this.pceLayout.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("pceLayout.Properties.Buttons"))), resources.GetString("pceLayout.Properties.Buttons1"), ((int)(resources.GetObject("pceLayout.Properties.Buttons2"))), ((bool)(resources.GetObject("pceLayout.Properties.Buttons3"))), ((bool)(resources.GetObject("pceLayout.Properties.Buttons4"))), ((bool)(resources.GetObject("pceLayout.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("pceLayout.Properties.Buttons6"))), null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, resources.GetString("pceLayout.Properties.Buttons7"), resources.GetString("pceLayout.Properties.Buttons8"), null, ((bool)(resources.GetObject("pceLayout.Properties.Buttons9")))),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.pceLayout.Properties.PopupControl = this.popupContainerControl1;
            this.pceLayout.Properties.PopupSizeable = false;
            this.pceLayout.Properties.ShowPopupCloseButton = false;
            this.pceLayout.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.pceLayout_ButtonClick);
            this.pceLayout.EditValueChanged += new System.EventHandler(this.pceLayout_EditValueChanged);
            this.pceLayout.QueryResultValue += new DevExpress.XtraEditors.Controls.QueryResultValueEventHandler(this.pceLayout_QueryResultValue);
            this.pceLayout.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.pceLayout_EditValueChanging);
            this.pceLayout.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.pceLayout_QueryPopUp);
            // 
            // memDescription
            // 
            resources.ApplyResources(this.memDescription, "memDescription");
            this.memDescription.Name = "memDescription";
            this.memDescription.Properties.ReadOnly = true;
            // 
            // lblDescription
            // 
            resources.ApplyResources(this.lblDescription, "lblDescription");
            this.lblDescription.Name = "lblDescription";
            // 
            // lblLayout
            // 
            resources.ApplyResources(this.lblLayout, "lblLayout");
            this.lblLayout.Name = "lblLayout";
            // 
            // LayoutInfo
            // 
            this.Controls.Add(this.grcLayout);
            this.Name = "LayoutInfo";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.grcLayout)).EndInit();
            this.grcLayout.ResumeLayout(false);
            this.grcLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pceLayout.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grcLayout;
        private DevExpress.XtraEditors.MemoEdit memDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblLayout;
        private DevExpress.XtraEditors.PopupContainerControl popupContainerControl1;
        private DevExpress.XtraEditors.PopupContainerEdit pceLayout;
        private LayoutTreeListKeeper layoutTreeListKeeper;
    }
}