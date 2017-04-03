namespace EIDSS.FlexibleForms
{
    partial class FFPresenter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FFPresenter));
            this.DesignerHostMain = new EIDSS.FlexibleForms.DesignerHosting.DesignerHost();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDynamicParameters = new DevExpress.XtraBars.Bar();
            this.btnAddParameter = new DevExpress.XtraBars.BarButtonItem();
            this.btnRemoveAllDynamicParameter = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // DesignerHostMain
            // 
            resources.ApplyResources(this.DesignerHostMain, "DesignerHostMain");
            this.DesignerHostMain.IsDesignMode = false;
            this.DesignerHostMain.Name = "DesignerHostMain";
            this.DesignerHostMain.ReadOnly = false;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barDynamicParameters});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAddParameter,
            this.btnRemoveAllDynamicParameter});
            this.barManager1.MaxItemId = 2;
            // 
            // barDynamicParameters
            // 
            this.barDynamicParameters.BarName = "Dynamic Parameters";
            this.barDynamicParameters.DockCol = 0;
            this.barDynamicParameters.DockRow = 0;
            this.barDynamicParameters.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barDynamicParameters.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAddParameter),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRemoveAllDynamicParameter)});
            this.barDynamicParameters.OptionsBar.AllowQuickCustomization = false;
            resources.ApplyResources(this.barDynamicParameters, "barDynamicParameters");
            // 
            // btnAddParameter
            // 
            resources.ApplyResources(this.btnAddParameter, "btnAddParameter");
            this.btnAddParameter.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAddParameter.Glyph")));
            this.btnAddParameter.Id = 0;
            this.btnAddParameter.Name = "btnAddParameter";
            this.btnAddParameter.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnAddParameter.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.OnBtnAddParameterItemClick);
            // 
            // btnRemoveAllDynamicParameter
            // 
            resources.ApplyResources(this.btnRemoveAllDynamicParameter, "btnRemoveAllDynamicParameter");
            this.btnRemoveAllDynamicParameter.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRemoveAllDynamicParameter.Glyph")));
            this.btnRemoveAllDynamicParameter.Id = 1;
            this.btnRemoveAllDynamicParameter.Name = "btnRemoveAllDynamicParameter";
            this.btnRemoveAllDynamicParameter.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnRemoveAllDynamicParameter.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.OnBtnRemoveAllDynamicParameterItemClick);
            // 
            // barDockControlTop
            // 
            resources.ApplyResources(this.barDockControlTop, "barDockControlTop");
            // 
            // barDockControlBottom
            // 
            resources.ApplyResources(this.barDockControlBottom, "barDockControlBottom");
            // 
            // barDockControlLeft
            // 
            resources.ApplyResources(this.barDockControlLeft, "barDockControlLeft");
            // 
            // barDockControlRight
            // 
            resources.ApplyResources(this.barDockControlRight, "barDockControlRight");
            // 
            // FFPresenter
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.DesignerHostMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FFPresenter";
            this.VisibleChanged += new System.EventHandler(this.OnVisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DesignerHosting.DesignerHost DesignerHostMain;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar barDynamicParameters;
        private DevExpress.XtraBars.BarButtonItem btnAddParameter;
        private DevExpress.XtraBars.BarButtonItem btnRemoveAllDynamicParameter;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;

    }
}
