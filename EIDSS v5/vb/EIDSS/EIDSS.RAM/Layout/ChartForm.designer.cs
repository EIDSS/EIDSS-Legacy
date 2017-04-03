namespace EIDSS.RAM.Layout
{
    partial class ChartForm
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
            
            m_ChartPresenter.SharedPresenter.UnregisterView(this);
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            nbContainerSettings = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartForm));
            this.grcChartMain = new DevExpress.XtraEditors.GroupControl();
            this.grcChartSettings = new DevExpress.XtraEditors.GroupControl();
            this.memFilter = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblFilter = new System.Windows.Forms.Label();
            this.tbChartName = new DevExpress.XtraEditors.TextEdit();
            this.checkPivotAxes = new DevExpress.XtraEditors.CheckEdit();
            this.cbChart = new DevExpress.XtraEditors.LookUpEdit();
            this.checkShowXAxesLabels = new DevExpress.XtraEditors.CheckEdit();
            this.checkPointLabels = new DevExpress.XtraEditors.CheckEdit();
            this.labelChartType = new DevExpress.XtraEditors.LabelControl();
            this.grcMain = new DevExpress.XtraEditors.GroupControl();
            this.grcChart = new DevExpress.XtraEditors.GroupControl();
            this.nbControlChart = new DevExpress.XtraNavBar.NavBarControl();
            this.nbGroupSettings = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbContainerSettings = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.printingSystem = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grcChartMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcChartSettings)).BeginInit();
            this.grcChartSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbChartName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkPivotAxes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbChart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkShowXAxesLabels.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkPointLabels.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcMain)).BeginInit();
            this.grcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcChart)).BeginInit();
            this.grcChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbControlChart)).BeginInit();
            this.nbControlChart.SuspendLayout();
            this.nbContainerSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).BeginInit();
            this.SuspendLayout();
            // 
            // grcChartMain
            // 
            resources.ApplyResources(this.grcChartMain, "grcChartMain");
            this.grcChartMain.Name = "grcChartMain";
            // 
            // grcChartSettings
            // 
            this.grcChartSettings.Controls.Add(this.memFilter);
            this.grcChartSettings.Controls.Add(this.labelControl1);
            this.grcChartSettings.Controls.Add(this.lblFilter);
            this.grcChartSettings.Controls.Add(this.tbChartName);
            this.grcChartSettings.Controls.Add(this.checkPivotAxes);
            this.grcChartSettings.Controls.Add(this.cbChart);
            this.grcChartSettings.Controls.Add(this.checkShowXAxesLabels);
            this.grcChartSettings.Controls.Add(this.checkPointLabels);
            this.grcChartSettings.Controls.Add(this.labelChartType);
            resources.ApplyResources(this.grcChartSettings, "grcChartSettings");
            this.grcChartSettings.Name = "grcChartSettings";
            this.grcChartSettings.ShowCaption = false;
            // 
            // memFilter
            // 
            resources.ApplyResources(this.memFilter, "memFilter");
            this.memFilter.Name = "memFilter";
            this.memFilter.Properties.Appearance.Options.UseFont = true;
            this.memFilter.Properties.AppearanceDisabled.Options.UseFont = true;
            this.memFilter.Properties.AppearanceFocused.Options.UseFont = true;
            this.memFilter.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.memFilter.Tag = "{alwayseditable}";
            this.memFilter.EditValueChanged += new System.EventHandler(this.memFilter_EditValueChanged);
            // 
            // labelControl1
            // 
            resources.ApplyResources(this.labelControl1, "labelControl1");
            this.labelControl1.Name = "labelControl1";
            // 
            // lblFilter
            // 
            resources.ApplyResources(this.lblFilter, "lblFilter");
            this.lblFilter.Name = "lblFilter";
            // 
            // tbChartName
            // 
            resources.ApplyResources(this.tbChartName, "tbChartName");
            this.tbChartName.Name = "tbChartName";
            this.tbChartName.Properties.Appearance.Options.UseFont = true;
            this.tbChartName.Properties.AppearanceDisabled.Options.UseFont = true;
            this.tbChartName.Properties.AppearanceFocused.Options.UseFont = true;
            this.tbChartName.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.tbChartName.Tag = "{alwayseditable}";
            this.tbChartName.EditValueChanged += new System.EventHandler(this.tbMapName_EditValueChanged);
            // 
            // checkPivotAxes
            // 
            resources.ApplyResources(this.checkPivotAxes, "checkPivotAxes");
            this.checkPivotAxes.Name = "checkPivotAxes";
            this.checkPivotAxes.Properties.Caption = resources.GetString("checkPivotAxes.Properties.Caption");
            this.checkPivotAxes.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.checkPivotAxes.Tag = "{alwayseditable}";
            this.checkPivotAxes.CheckedChanged += new System.EventHandler(this.checkPivotAxes_CheckedChanged);
            // 
            // cbChart
            // 
            resources.ApplyResources(this.cbChart, "cbChart");
            this.cbChart.Name = "cbChart";
            this.cbChart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbChart.Properties.Buttons"))))});
            this.cbChart.Properties.NullText = resources.GetString("cbChart.Properties.NullText");
            this.cbChart.Tag = "{alwayseditable}";
            this.cbChart.EditValueChanged += new System.EventHandler(this.cbChart_EditValueChanged);
            // 
            // checkShowXAxesLabels
            // 
            resources.ApplyResources(this.checkShowXAxesLabels, "checkShowXAxesLabels");
            this.checkShowXAxesLabels.Name = "checkShowXAxesLabels";
            this.checkShowXAxesLabels.Properties.Caption = resources.GetString("checkShowXAxesLabels.Properties.Caption");
            this.checkShowXAxesLabels.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.checkShowXAxesLabels.Tag = "{alwayseditable}";
            this.checkShowXAxesLabels.CheckedChanged += new System.EventHandler(this.checkShowXAxesLabels_CheckedChanged);
            // 
            // checkPointLabels
            // 
            resources.ApplyResources(this.checkPointLabels, "checkPointLabels");
            this.checkPointLabels.Name = "checkPointLabels";
            this.checkPointLabels.Properties.Caption = resources.GetString("checkPointLabels.Properties.Caption");
            this.checkPointLabels.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.checkPointLabels.Tag = "{alwayseditable}";
            this.checkPointLabels.CheckedChanged += new System.EventHandler(this.checkPointLabels_CheckedChanged);
            // 
            // labelChartType
            // 
            resources.ApplyResources(this.labelChartType, "labelChartType");
            this.labelChartType.Name = "labelChartType";
            // 
            // grcMain
            // 
            this.grcMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grcMain.Controls.Add(this.grcChart);
            resources.ApplyResources(this.grcMain, "grcMain");
            this.grcMain.Name = "grcMain";
            this.grcMain.ShowCaption = false;
            // 
            // grcChart
            // 
            this.grcChart.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grcChart.Controls.Add(this.grcChartMain);
            this.grcChart.Controls.Add(this.nbControlChart);
            resources.ApplyResources(this.grcChart, "grcChart");
            this.grcChart.MinimumSize = new System.Drawing.Size(400, 300);
            this.grcChart.Name = "grcChart";
            this.grcChart.ShowCaption = false;
            // 
            // nbControlChart
            // 
            this.nbControlChart.ActiveGroup = this.nbGroupSettings;
            this.nbControlChart.ContentButtonHint = null;
            this.nbControlChart.Controls.Add(this.nbContainerSettings);
            resources.ApplyResources(this.nbControlChart, "nbControlChart");
            this.nbControlChart.ExplorerBarGroupInterval = 1;
            this.nbControlChart.ExplorerBarGroupOuterIndent = 0;
            this.nbControlChart.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.nbGroupSettings});
            this.nbControlChart.LookAndFeel.SkinName = "Black";
            this.nbControlChart.LookAndFeel.UseDefaultLookAndFeel = false;
            this.nbControlChart.Name = "nbControlChart";
            this.nbControlChart.OptionsNavPane.ExpandedWidth = 781;
            this.nbControlChart.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinExplorerBarViewInfoRegistrator("Blue");
            this.nbControlChart.GroupExpanded += new DevExpress.XtraNavBar.NavBarGroupEventHandler(this.nbControlChart_GroupExpanded);
            this.nbControlChart.GroupCollapsed += new DevExpress.XtraNavBar.NavBarGroupEventHandler(this.nbControlChart_GroupCollapsed);
            // 
            // nbGroupSettings
            // 
            resources.ApplyResources(this.nbGroupSettings, "nbGroupSettings");
            this.nbGroupSettings.ControlContainer = this.nbContainerSettings;
            this.nbGroupSettings.Expanded = true;
            this.nbGroupSettings.GroupClientHeight = 89;
            this.nbGroupSettings.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.nbGroupSettings.Name = "nbGroupSettings";
            // 
            // nbContainerSettings
            // 
            this.nbContainerSettings.Controls.Add(this.grcChartSettings);
            this.nbContainerSettings.Name = "nbContainerSettings";
            resources.ApplyResources(this.nbContainerSettings, "nbContainerSettings");
            // 
            // ChartForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grcMain);
            this.HelpTopicID = "AVR_Chart_Management";
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "ChartForm";
            ((System.ComponentModel.ISupportInitialize)(this.grcChartMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcChartSettings)).EndInit();
            this.grcChartSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbChartName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkPivotAxes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbChart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkShowXAxesLabels.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkPointLabels.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcMain)).EndInit();
            this.grcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcChart)).EndInit();
            this.grcChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nbControlChart)).EndInit();
            this.nbControlChart.ResumeLayout(false);
            this.nbContainerSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grcMain;
        private DevExpress.XtraEditors.GroupControl grcChart;
        private DevExpress.XtraEditors.GroupControl grcChartMain;
        private DevExpress.XtraEditors.GroupControl grcChartSettings;
        private DevExpress.XtraEditors.LabelControl labelChartType;
        private DevExpress.XtraEditors.CheckEdit checkPointLabels;
        private DevExpress.XtraEditors.CheckEdit checkShowXAxesLabels;
        private DevExpress.XtraEditors.LookUpEdit cbChart;
        private DevExpress.XtraEditors.CheckEdit checkPivotAxes;
        private DevExpress.XtraPrinting.PrintingSystem printingSystem;
        private DevExpress.XtraNavBar.NavBarControl nbControlChart;
        private DevExpress.XtraNavBar.NavBarGroup nbGroupSettings;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer nbContainerSettings;
        private System.Windows.Forms.Label lblFilter;
        private DevExpress.XtraEditors.MemoEdit memFilter;
        private DevExpress.XtraEditors.TextEdit tbChartName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        
    }
}