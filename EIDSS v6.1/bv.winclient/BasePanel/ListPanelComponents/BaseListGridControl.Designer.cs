namespace bv.winclient.BasePanel.ListPanelComponents
{
    partial class BaseListGridControl
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
            this.m_TotalsLabel = new System.Windows.Forms.Label();
            this.m_GridControl = new BvGridControl();
            this.m_GridView = new BvGridView();
            ((System.ComponentModel.ISupportInitialize)(this.m_GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_GridView)).BeginInit();
            this.SuspendLayout();
            // Form Is Localizable: False
            // 
            // m_TotalsLabel
            // 
            this.m_TotalsLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_TotalsLabel.Location = new System.Drawing.Point(0, 346);
            this.m_TotalsLabel.Name = "m_TotalsLabel";
            this.m_TotalsLabel.Size = new System.Drawing.Size(447, 13);
            this.m_TotalsLabel.TabIndex = 1;
            this.m_TotalsLabel.Text = "Total";
            this.m_TotalsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_TotalsLabel.Visible = false;
            // 
            // m_GridControl
            // 
            this.m_GridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_GridControl.Location = new System.Drawing.Point(0, 0);
            this.m_GridControl.MainView = this.m_GridView;
            this.m_GridControl.Name = "m_GridControl";
            this.m_GridControl.Size = new System.Drawing.Size(447, 359);
            this.m_GridControl.TabIndex = 0;
            this.m_GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.m_GridView});
            // 
            // m_GridView
            // 
            this.m_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.m_GridView.GridControl = this.m_GridControl;
            this.m_GridView.Name = "m_GridView";
            this.m_GridView.OptionsBehavior.AutoSelectAllInEditor = false;
            this.m_GridView.OptionsBehavior.Editable = false;
            this.m_GridView.OptionsBehavior.ReadOnly = true;
            this.m_GridView.OptionsCustomization.AllowFilter = false;
            this.m_GridView.OptionsCustomization.AllowGroup = false;
            this.m_GridView.OptionsCustomization.AllowQuickHideColumns = false;
            this.m_GridView.OptionsDetail.AllowZoomDetail = false;
            this.m_GridView.OptionsDetail.EnableMasterViewMode = false;
            this.m_GridView.OptionsDetail.ShowDetailTabs = false;
            this.m_GridView.OptionsDetail.SmartDetailExpand = false;
            this.m_GridView.OptionsFilter.AllowColumnMRUFilterList = false;
            this.m_GridView.OptionsFilter.AllowFilterEditor = false;
            this.m_GridView.OptionsFilter.AllowMRUFilterList = false;
            this.m_GridView.OptionsFind.AllowFindPanel = false;
            this.m_GridView.OptionsMenu.EnableColumnMenu = false;
            this.m_GridView.OptionsMenu.EnableFooterMenu = false;
            this.m_GridView.OptionsMenu.EnableGroupPanelMenu = false;
            this.m_GridView.OptionsMenu.ShowAutoFilterRowItem = false;
            this.m_GridView.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            this.m_GridView.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.m_GridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.m_GridView.OptionsSelection.MultiSelect = true;
            this.m_GridView.OptionsView.ShowDetailButtons = false;
            this.m_GridView.OptionsView.ShowGroupPanel = false;
            this.m_GridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedRow;
            // 
            // BaseListGridControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_TotalsLabel);
            this.Controls.Add(this.m_GridControl);
            this.Name = "BaseListGridControl";
            this.Size = new System.Drawing.Size(447, 359);
            ((System.ComponentModel.ISupportInitialize)(this.m_GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_GridView)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Label m_TotalsLabel;
        private BvGridControl m_GridControl;
        private BvGridView m_GridView;
    }
}

