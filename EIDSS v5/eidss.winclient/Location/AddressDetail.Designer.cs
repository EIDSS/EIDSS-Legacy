namespace eidss.winclient.Location
{
    partial class AddressDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddressDetail));
            this.lblPostalCode = new System.Windows.Forms.Label();
            this.txtApartment = new DevExpress.XtraEditors.TextEdit();
            this.cbStreet = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblRegion = new System.Windows.Forms.Label();
            this.lblRayon = new System.Windows.Forms.Label();
            this.lblSettlment = new System.Windows.Forms.Label();
            this.lblStreet = new System.Windows.Forms.Label();
            this.cbCountry = new DevExpress.XtraEditors.LookUpEdit();
            this.lblResidenceType = new System.Windows.Forms.Label();
            this.cbRegion = new DevExpress.XtraEditors.LookUpEdit();
            this.cbRayon = new DevExpress.XtraEditors.LookUpEdit();
            this.cbSettlement = new DevExpress.XtraEditors.LookUpEdit();
            this.lblHouse = new System.Windows.Forms.Label();
            this.txtBuilding = new DevExpress.XtraEditors.TextEdit();
            this.txtHouse = new DevExpress.XtraEditors.TextEdit();
            this.cbPostalCode = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbResidenceType = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbStreet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCountry.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbRegion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbRayon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSettlement.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBuilding.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHouse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPostalCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbResidenceType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPostalCode
            // 
            resources.ApplyResources(this.lblPostalCode, "lblPostalCode");
            this.lblPostalCode.Name = "lblPostalCode";
            // 
            // txtApartment
            // 
            resources.ApplyResources(this.txtApartment, "txtApartment");
            this.txtApartment.Name = "txtApartment";
            this.txtApartment.Properties.MaxLength = 254;
            // 
            // cbStreet
            // 
            resources.ApplyResources(this.cbStreet, "cbStreet");
            this.cbStreet.Name = "cbStreet";
            this.cbStreet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbStreet.Properties.Buttons"))))});
            // 
            // lblCountry
            // 
            resources.ApplyResources(this.lblCountry, "lblCountry");
            this.lblCountry.Name = "lblCountry";
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
            // lblStreet
            // 
            resources.ApplyResources(this.lblStreet, "lblStreet");
            this.lblStreet.Name = "lblStreet";
            // 
            // cbCountry
            // 
            resources.ApplyResources(this.cbCountry, "cbCountry");
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbCountry.Properties.Buttons"))))});
            this.cbCountry.Properties.NullText = resources.GetString("cbCountry.Properties.NullText");
            this.cbCountry.Tag = "";
            // 
            // lblResidenceType
            // 
            resources.ApplyResources(this.lblResidenceType, "lblResidenceType");
            this.lblResidenceType.Name = "lblResidenceType";
            // 
            // cbRegion
            // 
            resources.ApplyResources(this.cbRegion, "cbRegion");
            this.cbRegion.Name = "cbRegion";
            this.cbRegion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbRegion.Properties.Buttons"))))});
            this.cbRegion.Properties.NullText = resources.GetString("cbRegion.Properties.NullText");
            this.cbRegion.Tag = "";
            this.cbRegion.TextChanged += new System.EventHandler(this.Region_Changed);
            // 
            // cbRayon
            // 
            resources.ApplyResources(this.cbRayon, "cbRayon");
            this.cbRayon.Name = "cbRayon";
            this.cbRayon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbRayon.Properties.Buttons"))))});
            this.cbRayon.Properties.NullText = resources.GetString("cbRayon.Properties.NullText");
            this.cbRayon.Tag = "";
            this.cbRayon.TextChanged += new System.EventHandler(this.Rayon_Changed);
            // 
            // cbSettlement
            // 
            resources.ApplyResources(this.cbSettlement, "cbSettlement");
            this.cbSettlement.Name = "cbSettlement";
            this.cbSettlement.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbSettlement.Properties.Buttons"))))});
            this.cbSettlement.Properties.NullText = resources.GetString("cbSettlement.Properties.NullText");
            this.cbSettlement.Tag = "";
            // 
            // lblHouse
            // 
            resources.ApplyResources(this.lblHouse, "lblHouse");
            this.lblHouse.Name = "lblHouse";
            // 
            // txtBuilding
            // 
            resources.ApplyResources(this.txtBuilding, "txtBuilding");
            this.txtBuilding.Name = "txtBuilding";
            this.txtBuilding.Properties.MaxLength = 254;
            // 
            // txtHouse
            // 
            resources.ApplyResources(this.txtHouse, "txtHouse");
            this.txtHouse.Name = "txtHouse";
            this.txtHouse.Properties.MaxLength = 254;
            this.txtHouse.Tag = "";
            // 
            // cbPostalCode
            // 
            resources.ApplyResources(this.cbPostalCode, "cbPostalCode");
            this.cbPostalCode.Name = "cbPostalCode";
            this.cbPostalCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbPostalCode.Properties.Buttons"))))});
            // 
            // cbResidenceType
            // 
            resources.ApplyResources(this.cbResidenceType, "cbResidenceType");
            this.cbResidenceType.Name = "cbResidenceType";
            this.cbResidenceType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbResidenceType.Properties.Buttons"))))});
            this.cbResidenceType.Properties.NullText = resources.GetString("cbResidenceType.Properties.NullText");
            this.cbResidenceType.Tag = "";
            // 
            // AddressDetail
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.lblPostalCode);
            this.Controls.Add(this.txtApartment);
            this.Controls.Add(this.cbStreet);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.lblRegion);
            this.Controls.Add(this.lblRayon);
            this.Controls.Add(this.lblSettlment);
            this.Controls.Add(this.lblStreet);
            this.Controls.Add(this.cbCountry);
            this.Controls.Add(this.lblResidenceType);
            this.Controls.Add(this.cbRegion);
            this.Controls.Add(this.cbRayon);
            this.Controls.Add(this.cbSettlement);
            this.Controls.Add(this.lblHouse);
            this.Controls.Add(this.txtBuilding);
            this.Controls.Add(this.txtHouse);
            this.Controls.Add(this.cbPostalCode);
            this.Controls.Add(this.cbResidenceType);
            this.Name = "AddressDetail";
            this.Load += new System.EventHandler(this.AddressDetail_Load);
            this.Resize += new System.EventHandler(this.AddressLookup_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.txtApartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbStreet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCountry.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbRegion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbRayon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSettlement.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBuilding.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHouse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPostalCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbResidenceType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label lblPostalCode;
        internal DevExpress.XtraEditors.TextEdit txtApartment;
        internal DevExpress.XtraEditors.ComboBoxEdit cbStreet;
        internal System.Windows.Forms.Label lblCountry;
        internal System.Windows.Forms.Label lblRegion;
        internal System.Windows.Forms.Label lblRayon;
        internal System.Windows.Forms.Label lblSettlment;
        internal System.Windows.Forms.Label lblStreet;
        internal DevExpress.XtraEditors.LookUpEdit cbCountry;
        internal System.Windows.Forms.Label lblResidenceType;
        internal DevExpress.XtraEditors.LookUpEdit cbRegion;
        internal DevExpress.XtraEditors.LookUpEdit cbRayon;
        internal DevExpress.XtraEditors.LookUpEdit cbSettlement;
        internal System.Windows.Forms.Label lblHouse;
        internal DevExpress.XtraEditors.TextEdit txtBuilding;
        internal DevExpress.XtraEditors.TextEdit txtHouse;
        internal DevExpress.XtraEditors.ComboBoxEdit cbPostalCode;
        internal DevExpress.XtraEditors.LookUpEdit cbResidenceType;
    }
}
