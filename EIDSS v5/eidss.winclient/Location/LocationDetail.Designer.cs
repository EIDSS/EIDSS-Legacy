namespace eidss.winclient.Location
{
    partial class LocationDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocationDetail));
            this.cbLocationType = new DevExpress.XtraEditors.LookUpEdit();
            this.lblLocationType = new System.Windows.Forms.Label();
            this.pnExactLocation = new DevExpress.XtraEditors.GroupControl();
            this.lblLocDescription = new System.Windows.Forms.Label();
            this.ExactLocationGroupBox = new System.Windows.Forms.GroupBox();
            this.lbLocSettlement = new System.Windows.Forms.Label();
            this.cbLocSettlement = new DevExpress.XtraEditors.LookUpEdit();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.cbLocRegion = new DevExpress.XtraEditors.LookUpEdit();
            this.cbLocRayon = new DevExpress.XtraEditors.LookUpEdit();
            this.btnMAP = new DevExpress.XtraEditors.SimpleButton();
            this.seLongitude = new DevExpress.XtraEditors.SpinEdit();
            this.txtLocDescription = new DevExpress.XtraEditors.TextEdit();
            this.seLatitude = new DevExpress.XtraEditors.SpinEdit();
            this.lblLatitude = new System.Windows.Forms.Label();
            this.lblLongitude = new System.Windows.Forms.Label();
            this.pnRelativeLocation = new DevExpress.XtraEditors.GroupControl();
            this.seRelLongitude = new DevExpress.XtraEditors.SpinEdit();
            this.seRelLatitude = new DevExpress.XtraEditors.SpinEdit();
            this.lbRelLongitude = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.RelativeLocationGroupBox = new System.Windows.Forms.GroupBox();
            this.lblRegion = new System.Windows.Forms.Label();
            this.lblRayon = new System.Windows.Forms.Label();
            this.lblSettlment = new System.Windows.Forms.Label();
            this.cbRegion = new DevExpress.XtraEditors.LookUpEdit();
            this.cbRayon = new DevExpress.XtraEditors.LookUpEdit();
            this.cbSettlement = new DevExpress.XtraEditors.LookUpEdit();
            this.txtRelativeDescription = new DevExpress.XtraEditors.TextEdit();
            this.seDirection = new DevExpress.XtraEditors.SpinEdit();
            this.seDistance = new DevExpress.XtraEditors.SpinEdit();
            this.cbGroundType = new DevExpress.XtraEditors.LookUpEdit();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.lbRelLatitude = new System.Windows.Forms.Label();
            this.lblDistance = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cbLocationType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnExactLocation)).BeginInit();
            this.pnExactLocation.SuspendLayout();
            this.ExactLocationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbLocSettlement.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLocRegion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLocRayon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seLongitude.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seLatitude.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnRelativeLocation)).BeginInit();
            this.pnRelativeLocation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seRelLongitude.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seRelLatitude.Properties)).BeginInit();
            this.RelativeLocationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbRegion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbRayon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSettlement.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRelativeDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seDirection.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seDistance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGroundType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cbLocationType
            // 
            resources.ApplyResources(this.cbLocationType, "cbLocationType");
            this.cbLocationType.Name = "cbLocationType";
            this.cbLocationType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbLocationType.Properties.Buttons"))))});
            this.cbLocationType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbLocationType.Properties.Columns"), resources.GetString("cbLocationType.Properties.Columns1"))});
            this.cbLocationType.Properties.NullText = resources.GetString("cbLocationType.Properties.NullText");
            this.cbLocationType.Tag = "{M}";
            this.cbLocationType.EditValueChanged += new System.EventHandler(this.cbLocationType_EditValueChanged);
            // 
            // lblLocationType
            // 
            resources.ApplyResources(this.lblLocationType, "lblLocationType");
            this.lblLocationType.Name = "lblLocationType";
            // 
            // pnExactLocation
            // 
            this.pnExactLocation.Controls.Add(this.lblLocDescription);
            this.pnExactLocation.Controls.Add(this.ExactLocationGroupBox);
            this.pnExactLocation.Controls.Add(this.btnMAP);
            this.pnExactLocation.Controls.Add(this.seLongitude);
            this.pnExactLocation.Controls.Add(this.txtLocDescription);
            this.pnExactLocation.Controls.Add(this.seLatitude);
            this.pnExactLocation.Controls.Add(this.lblLatitude);
            this.pnExactLocation.Controls.Add(this.lblLongitude);
            resources.ApplyResources(this.pnExactLocation, "pnExactLocation");
            this.pnExactLocation.Name = "pnExactLocation";
            this.pnExactLocation.TabStop = true;
            // 
            // lblLocDescription
            // 
            resources.ApplyResources(this.lblLocDescription, "lblLocDescription");
            this.lblLocDescription.Name = "lblLocDescription";
            // 
            // ExactLocationGroupBox
            // 
            this.ExactLocationGroupBox.Controls.Add(this.lbLocSettlement);
            this.ExactLocationGroupBox.Controls.Add(this.cbLocSettlement);
            this.ExactLocationGroupBox.Controls.Add(this.Label7);
            this.ExactLocationGroupBox.Controls.Add(this.Label8);
            this.ExactLocationGroupBox.Controls.Add(this.cbLocRegion);
            this.ExactLocationGroupBox.Controls.Add(this.cbLocRayon);
            resources.ApplyResources(this.ExactLocationGroupBox, "ExactLocationGroupBox");
            this.ExactLocationGroupBox.Name = "ExactLocationGroupBox";
            this.ExactLocationGroupBox.TabStop = false;
            // 
            // lbLocSettlement
            // 
            resources.ApplyResources(this.lbLocSettlement, "lbLocSettlement");
            this.lbLocSettlement.Name = "lbLocSettlement";
            // 
            // cbLocSettlement
            // 
            resources.ApplyResources(this.cbLocSettlement, "cbLocSettlement");
            this.cbLocSettlement.Name = "cbLocSettlement";
            this.cbLocSettlement.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbLocSettlement.Properties.Buttons"))))});
            this.cbLocSettlement.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbLocSettlement.Properties.Columns"), resources.GetString("cbLocSettlement.Properties.Columns1"), ((int)(resources.GetObject("cbLocSettlement.Properties.Columns2"))), ((DevExpress.Utils.FormatType)(resources.GetObject("cbLocSettlement.Properties.Columns3"))), resources.GetString("cbLocSettlement.Properties.Columns4"), ((bool)(resources.GetObject("cbLocSettlement.Properties.Columns5"))), ((DevExpress.Utils.HorzAlignment)(resources.GetObject("cbLocSettlement.Properties.Columns6"))))});
            this.cbLocSettlement.Properties.NullText = resources.GetString("cbLocSettlement.Properties.NullText");
            this.cbLocSettlement.Tag = "";
            // 
            // Label7
            // 
            resources.ApplyResources(this.Label7, "Label7");
            this.Label7.Name = "Label7";
            // 
            // Label8
            // 
            resources.ApplyResources(this.Label8, "Label8");
            this.Label8.Name = "Label8";
            // 
            // cbLocRegion
            // 
            resources.ApplyResources(this.cbLocRegion, "cbLocRegion");
            this.cbLocRegion.Name = "cbLocRegion";
            this.cbLocRegion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbLocRegion.Properties.Buttons"))))});
            this.cbLocRegion.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbLocRegion.Properties.Columns"), resources.GetString("cbLocRegion.Properties.Columns1"), ((int)(resources.GetObject("cbLocRegion.Properties.Columns2"))), ((DevExpress.Utils.FormatType)(resources.GetObject("cbLocRegion.Properties.Columns3"))), resources.GetString("cbLocRegion.Properties.Columns4"), ((bool)(resources.GetObject("cbLocRegion.Properties.Columns5"))), ((DevExpress.Utils.HorzAlignment)(resources.GetObject("cbLocRegion.Properties.Columns6"))))});
            this.cbLocRegion.Properties.NullText = resources.GetString("cbLocRegion.Properties.NullText");
            this.cbLocRegion.Tag = "{M}";
            // 
            // cbLocRayon
            // 
            resources.ApplyResources(this.cbLocRayon, "cbLocRayon");
            this.cbLocRayon.Name = "cbLocRayon";
            this.cbLocRayon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbLocRayon.Properties.Buttons"))))});
            this.cbLocRayon.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbLocRayon.Properties.Columns"), resources.GetString("cbLocRayon.Properties.Columns1"), ((int)(resources.GetObject("cbLocRayon.Properties.Columns2"))), ((DevExpress.Utils.FormatType)(resources.GetObject("cbLocRayon.Properties.Columns3"))), resources.GetString("cbLocRayon.Properties.Columns4"), ((bool)(resources.GetObject("cbLocRayon.Properties.Columns5"))), ((DevExpress.Utils.HorzAlignment)(resources.GetObject("cbLocRayon.Properties.Columns6"))))});
            this.cbLocRayon.Properties.NullText = resources.GetString("cbLocRayon.Properties.NullText");
            this.cbLocRayon.Tag = "{M}";
            // 
            // btnMAP
            // 
            resources.ApplyResources(this.btnMAP, "btnMAP");
            this.btnMAP.Name = "btnMAP";
            this.btnMAP.Click += new System.EventHandler(this.btnMAP_Click);
            // 
            // seLongitude
            // 
            resources.ApplyResources(this.seLongitude, "seLongitude");
            this.seLongitude.Name = "seLongitude";
            this.seLongitude.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seLongitude.Properties.DisplayFormat.FormatString = "f5";
            this.seLongitude.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seLongitude.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seLongitude.Properties.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.seLongitude.Properties.Mask.EditMask = resources.GetString("seLongitude.Properties.Mask.EditMask");
            this.seLongitude.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("seLongitude.Properties.Mask.UseMaskAsDisplayFormat")));
            this.seLongitude.Properties.MaxValue = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.seLongitude.Properties.MinValue = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.seLongitude.Properties.ValidateOnEnterKey = true;
            // 
            // txtLocDescription
            // 
            resources.ApplyResources(this.txtLocDescription, "txtLocDescription");
            this.txtLocDescription.Name = "txtLocDescription";
            this.txtLocDescription.Properties.MaxLength = 255;
            // 
            // seLatitude
            // 
            resources.ApplyResources(this.seLatitude, "seLatitude");
            this.seLatitude.Name = "seLatitude";
            this.seLatitude.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seLatitude.Properties.DisplayFormat.FormatString = "f5";
            this.seLatitude.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seLatitude.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seLatitude.Properties.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.seLatitude.Properties.Mask.EditMask = resources.GetString("seLatitude.Properties.Mask.EditMask");
            this.seLatitude.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("seLatitude.Properties.Mask.UseMaskAsDisplayFormat")));
            this.seLatitude.Properties.MaxValue = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.seLatitude.Properties.MinValue = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            // 
            // lblLatitude
            // 
            resources.ApplyResources(this.lblLatitude, "lblLatitude");
            this.lblLatitude.Name = "lblLatitude";
            // 
            // lblLongitude
            // 
            resources.ApplyResources(this.lblLongitude, "lblLongitude");
            this.lblLongitude.Name = "lblLongitude";
            // 
            // pnRelativeLocation
            // 
            this.pnRelativeLocation.Controls.Add(this.seRelLongitude);
            this.pnRelativeLocation.Controls.Add(this.seRelLatitude);
            this.pnRelativeLocation.Controls.Add(this.lbRelLongitude);
            this.pnRelativeLocation.Controls.Add(this.Label5);
            this.pnRelativeLocation.Controls.Add(this.RelativeLocationGroupBox);
            this.pnRelativeLocation.Controls.Add(this.txtRelativeDescription);
            this.pnRelativeLocation.Controls.Add(this.seDirection);
            this.pnRelativeLocation.Controls.Add(this.seDistance);
            this.pnRelativeLocation.Controls.Add(this.cbGroundType);
            this.pnRelativeLocation.Controls.Add(this.Label2);
            this.pnRelativeLocation.Controls.Add(this.Label1);
            this.pnRelativeLocation.Controls.Add(this.lbRelLatitude);
            this.pnRelativeLocation.Controls.Add(this.lblDistance);
            resources.ApplyResources(this.pnRelativeLocation, "pnRelativeLocation");
            this.pnRelativeLocation.Name = "pnRelativeLocation";
            this.pnRelativeLocation.TabStop = true;
            // 
            // seRelLongitude
            // 
            resources.ApplyResources(this.seRelLongitude, "seRelLongitude");
            this.seRelLongitude.Name = "seRelLongitude";
            this.seRelLongitude.Properties.DisplayFormat.FormatString = "f5";
            this.seRelLongitude.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seRelLongitude.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seRelLongitude.Properties.Mask.EditMask = resources.GetString("seRelLongitude.Properties.Mask.EditMask");
            this.seRelLongitude.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("seRelLongitude.Properties.Mask.UseMaskAsDisplayFormat")));
            this.seRelLongitude.Properties.ValidateOnEnterKey = true;
            // 
            // seRelLatitude
            // 
            resources.ApplyResources(this.seRelLatitude, "seRelLatitude");
            this.seRelLatitude.Name = "seRelLatitude";
            this.seRelLatitude.Properties.DisplayFormat.FormatString = "f5";
            this.seRelLatitude.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seRelLatitude.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seRelLatitude.Properties.Mask.EditMask = resources.GetString("seRelLatitude.Properties.Mask.EditMask");
            this.seRelLatitude.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("seRelLatitude.Properties.Mask.UseMaskAsDisplayFormat")));
            // 
            // lbRelLongitude
            // 
            resources.ApplyResources(this.lbRelLongitude, "lbRelLongitude");
            this.lbRelLongitude.Name = "lbRelLongitude";
            // 
            // Label5
            // 
            resources.ApplyResources(this.Label5, "Label5");
            this.Label5.Name = "Label5";
            // 
            // RelativeLocationGroupBox
            // 
            this.RelativeLocationGroupBox.Controls.Add(this.lblRegion);
            this.RelativeLocationGroupBox.Controls.Add(this.lblRayon);
            this.RelativeLocationGroupBox.Controls.Add(this.lblSettlment);
            this.RelativeLocationGroupBox.Controls.Add(this.cbRegion);
            this.RelativeLocationGroupBox.Controls.Add(this.cbRayon);
            this.RelativeLocationGroupBox.Controls.Add(this.cbSettlement);
            resources.ApplyResources(this.RelativeLocationGroupBox, "RelativeLocationGroupBox");
            this.RelativeLocationGroupBox.Name = "RelativeLocationGroupBox";
            this.RelativeLocationGroupBox.TabStop = false;
            // 
            // lblRegion
            // 
            resources.ApplyResources(this.lblRegion, "lblRegion");
            this.lblRegion.Name = "lblRegion";
            // 
            // lblRayon
            // 
            resources.ApplyResources(this.lblRayon, "lblRayon");
            this.lblRayon.Name = "lblRayon";
            // 
            // lblSettlment
            // 
            resources.ApplyResources(this.lblSettlment, "lblSettlment");
            this.lblSettlment.Name = "lblSettlment";
            // 
            // cbRegion
            // 
            resources.ApplyResources(this.cbRegion, "cbRegion");
            this.cbRegion.Name = "cbRegion";
            this.cbRegion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbRegion.Properties.Buttons"))))});
            this.cbRegion.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbRegion.Properties.Columns"), resources.GetString("cbRegion.Properties.Columns1"), ((int)(resources.GetObject("cbRegion.Properties.Columns2"))), ((DevExpress.Utils.FormatType)(resources.GetObject("cbRegion.Properties.Columns3"))), resources.GetString("cbRegion.Properties.Columns4"), ((bool)(resources.GetObject("cbRegion.Properties.Columns5"))), ((DevExpress.Utils.HorzAlignment)(resources.GetObject("cbRegion.Properties.Columns6"))))});
            this.cbRegion.Properties.NullText = resources.GetString("cbRegion.Properties.NullText");
            this.cbRegion.Tag = "{M}";
            // 
            // cbRayon
            // 
            resources.ApplyResources(this.cbRayon, "cbRayon");
            this.cbRayon.Name = "cbRayon";
            this.cbRayon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbRayon.Properties.Buttons"))))});
            this.cbRayon.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbRayon.Properties.Columns"), resources.GetString("cbRayon.Properties.Columns1"), ((int)(resources.GetObject("cbRayon.Properties.Columns2"))), ((DevExpress.Utils.FormatType)(resources.GetObject("cbRayon.Properties.Columns3"))), resources.GetString("cbRayon.Properties.Columns4"), ((bool)(resources.GetObject("cbRayon.Properties.Columns5"))), ((DevExpress.Utils.HorzAlignment)(resources.GetObject("cbRayon.Properties.Columns6"))))});
            this.cbRayon.Properties.NullText = resources.GetString("cbRayon.Properties.NullText");
            this.cbRayon.Tag = "{M}";
            // 
            // cbSettlement
            // 
            resources.ApplyResources(this.cbSettlement, "cbSettlement");
            this.cbSettlement.Name = "cbSettlement";
            this.cbSettlement.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbSettlement.Properties.Buttons"))))});
            this.cbSettlement.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbSettlement.Properties.Columns"), resources.GetString("cbSettlement.Properties.Columns1"), ((int)(resources.GetObject("cbSettlement.Properties.Columns2"))), ((DevExpress.Utils.FormatType)(resources.GetObject("cbSettlement.Properties.Columns3"))), resources.GetString("cbSettlement.Properties.Columns4"), ((bool)(resources.GetObject("cbSettlement.Properties.Columns5"))), ((DevExpress.Utils.HorzAlignment)(resources.GetObject("cbSettlement.Properties.Columns6"))))});
            this.cbSettlement.Properties.NullText = resources.GetString("cbSettlement.Properties.NullText");
            this.cbSettlement.Tag = "{M}";
            // 
            // txtRelativeDescription
            // 
            resources.ApplyResources(this.txtRelativeDescription, "txtRelativeDescription");
            this.txtRelativeDescription.Name = "txtRelativeDescription";
            this.txtRelativeDescription.Properties.MaxLength = 255;
            // 
            // seDirection
            // 
            resources.ApplyResources(this.seDirection, "seDirection");
            this.seDirection.Name = "seDirection";
            this.seDirection.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seDirection.Properties.DisplayFormat.FormatString = "f2";
            this.seDirection.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seDirection.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seDirection.Properties.Mask.EditMask = resources.GetString("seDirection.Properties.Mask.EditMask");
            this.seDirection.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("seDirection.Properties.Mask.UseMaskAsDisplayFormat")));
            this.seDirection.Properties.MaxValue = new decimal(new int[] {
            360,
            0,
            0,
            0});
            // 
            // seDistance
            // 
            resources.ApplyResources(this.seDistance, "seDistance");
            this.seDistance.Name = "seDistance";
            this.seDistance.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seDistance.Properties.DisplayFormat.FormatString = "f2";
            this.seDistance.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seDistance.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seDistance.Properties.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.seDistance.Properties.Mask.EditMask = resources.GetString("seDistance.Properties.Mask.EditMask");
            this.seDistance.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("seDistance.Properties.Mask.UseMaskAsDisplayFormat")));
            this.seDistance.Properties.MaxValue = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // cbGroundType
            // 
            resources.ApplyResources(this.cbGroundType, "cbGroundType");
            this.cbGroundType.Name = "cbGroundType";
            this.cbGroundType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbGroundType.Properties.Buttons"))))});
            this.cbGroundType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbGroundType.Properties.Columns"), resources.GetString("cbGroundType.Properties.Columns1"), ((int)(resources.GetObject("cbGroundType.Properties.Columns2"))), ((DevExpress.Utils.FormatType)(resources.GetObject("cbGroundType.Properties.Columns3"))), resources.GetString("cbGroundType.Properties.Columns4"), ((bool)(resources.GetObject("cbGroundType.Properties.Columns5"))), ((DevExpress.Utils.HorzAlignment)(resources.GetObject("cbGroundType.Properties.Columns6"))))});
            this.cbGroundType.Properties.NullText = resources.GetString("cbGroundType.Properties.NullText");
            this.cbGroundType.Tag = "";
            // 
            // Label2
            // 
            resources.ApplyResources(this.Label2, "Label2");
            this.Label2.Name = "Label2";
            // 
            // Label1
            // 
            resources.ApplyResources(this.Label1, "Label1");
            this.Label1.Name = "Label1";
            // 
            // lbRelLatitude
            // 
            resources.ApplyResources(this.lbRelLatitude, "lbRelLatitude");
            this.lbRelLatitude.Name = "lbRelLatitude";
            // 
            // lblDistance
            // 
            resources.ApplyResources(this.lblDistance, "lblDistance");
            this.lblDistance.Name = "lblDistance";
            // 
            // LocationDetail
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.cbLocationType);
            this.Controls.Add(this.lblLocationType);
            this.Controls.Add(this.pnExactLocation);
            this.Controls.Add(this.pnRelativeLocation);
            this.Name = "LocationDetail";
            ((System.ComponentModel.ISupportInitialize)(this.cbLocationType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnExactLocation)).EndInit();
            this.pnExactLocation.ResumeLayout(false);
            this.ExactLocationGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbLocSettlement.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLocRegion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLocRayon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seLongitude.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seLatitude.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnRelativeLocation)).EndInit();
            this.pnRelativeLocation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.seRelLongitude.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seRelLatitude.Properties)).EndInit();
            this.RelativeLocationGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbRegion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbRayon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSettlement.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRelativeDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seDirection.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seDistance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGroundType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal DevExpress.XtraEditors.LookUpEdit cbLocationType;
        internal System.Windows.Forms.Label lblLocationType;
        internal DevExpress.XtraEditors.GroupControl pnExactLocation;
        internal System.Windows.Forms.Label lblLocDescription;
        internal System.Windows.Forms.GroupBox ExactLocationGroupBox;
        internal System.Windows.Forms.Label lbLocSettlement;
        internal DevExpress.XtraEditors.LookUpEdit cbLocSettlement;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label8;
        internal DevExpress.XtraEditors.LookUpEdit cbLocRegion;
        internal DevExpress.XtraEditors.LookUpEdit cbLocRayon;
        internal DevExpress.XtraEditors.SimpleButton btnMAP;
        internal DevExpress.XtraEditors.SpinEdit seLongitude;
        internal DevExpress.XtraEditors.TextEdit txtLocDescription;
        internal DevExpress.XtraEditors.SpinEdit seLatitude;
        internal System.Windows.Forms.Label lblLatitude;
        internal System.Windows.Forms.Label lblLongitude;
        internal DevExpress.XtraEditors.GroupControl pnRelativeLocation;
        internal DevExpress.XtraEditors.SpinEdit seRelLongitude;
        internal DevExpress.XtraEditors.SpinEdit seRelLatitude;
        internal System.Windows.Forms.Label lbRelLongitude;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.GroupBox RelativeLocationGroupBox;
        internal System.Windows.Forms.Label lblRegion;
        internal System.Windows.Forms.Label lblRayon;
        internal System.Windows.Forms.Label lblSettlment;
        internal DevExpress.XtraEditors.LookUpEdit cbRegion;
        internal DevExpress.XtraEditors.LookUpEdit cbRayon;
        internal DevExpress.XtraEditors.LookUpEdit cbSettlement;
        internal DevExpress.XtraEditors.TextEdit txtRelativeDescription;
        internal DevExpress.XtraEditors.SpinEdit seDirection;
        internal DevExpress.XtraEditors.SpinEdit seDistance;
        internal DevExpress.XtraEditors.LookUpEdit cbGroundType;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label lbRelLatitude;
        internal System.Windows.Forms.Label lblDistance;
    }
}
