using eidss.winclient.Schema;

namespace eidss.winclient.VectorSurveillance
{
    partial class VectorDetail : BaseDetailPanel_Vector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VectorDetail));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tcMain = new DevExpress.XtraTab.XtraTabControl();
            this.tpGeneral = new DevExpress.XtraTab.XtraTabPage();
            this.gcComment = new DevExpress.XtraEditors.GroupControl();
            this.memoComment = new DevExpress.XtraEditors.MemoEdit();
            this.gcAnimalsData = new DevExpress.XtraEditors.GroupControl();
            this.seQuantity = new DevExpress.XtraEditors.SpinEdit();
            this.dtIdentificationDate = new DevExpress.XtraEditors.DateEdit();
            this.leIdentificationMethod = new DevExpress.XtraEditors.LookUpEdit();
            this.leIdentifiedBy = new DevExpress.XtraEditors.LookUpEdit();
            this.leSex = new DevExpress.XtraEditors.LookUpEdit();
            this.leIdentifiedByInstitution = new DevExpress.XtraEditors.LookUpEdit();
            this.leSpecie = new DevExpress.XtraEditors.LookUpEdit();
            this.lblSpecie = new DevExpress.XtraEditors.LabelControl();
            this.lblIdentificationDate = new DevExpress.XtraEditors.LabelControl();
            this.lblIdentificationMethod = new DevExpress.XtraEditors.LabelControl();
            this.lblIdentifiedBy = new DevExpress.XtraEditors.LabelControl();
            this.lblIdentifiedByInstitution = new DevExpress.XtraEditors.LabelControl();
            this.lblSex = new DevExpress.XtraEditors.LabelControl();
            this.lblQuantity = new DevExpress.XtraEditors.LabelControl();
            this.gcCollectionData = new DevExpress.XtraEditors.GroupControl();
            this.leEctoparasitesCollected = new DevExpress.XtraEditors.LookUpEdit();
            this.bppLocation = new eidss.winclient.Location.LocationLookup();
            this.seElevation = new DevExpress.XtraEditors.SpinEdit();
            this.leBasisOfRecord = new DevExpress.XtraEditors.LookUpEdit();
            this.leHostGuestReference = new DevExpress.XtraEditors.LookUpEdit();
            this.leCollectionMethod = new DevExpress.XtraEditors.LookUpEdit();
            this.leCollectionTime = new DevExpress.XtraEditors.LookUpEdit();
            this.dtCollectionDateFrom = new DevExpress.XtraEditors.DateEdit();
            this.leCollector = new DevExpress.XtraEditors.LookUpEdit();
            this.leCollectedByInstitution = new DevExpress.XtraEditors.LookUpEdit();
            this.txtGeoReference = new DevExpress.XtraEditors.TextEdit();
            this.leSurrounding = new DevExpress.XtraEditors.LookUpEdit();
            this.lblBasisOfRecord = new DevExpress.XtraEditors.LabelControl();
            this.lblHostGuestReference = new DevExpress.XtraEditors.LabelControl();
            this.lblGeoReference = new DevExpress.XtraEditors.LabelControl();
            this.lvlElevation = new DevExpress.XtraEditors.LabelControl();
            this.lblSurrounding = new DevExpress.XtraEditors.LabelControl();
            this.lblLongitudeLatitude = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblCollectionMethod = new DevExpress.XtraEditors.LabelControl();
            this.lblCollectionTime = new DevExpress.XtraEditors.LabelControl();
            this.lblCollectionDate = new DevExpress.XtraEditors.LabelControl();
            this.lblCollector = new DevExpress.XtraEditors.LabelControl();
            this.lblInstitution = new DevExpress.XtraEditors.LabelControl();
            this.tpVectorSpecificData = new DevExpress.XtraTab.XtraTabPage();
            this.tpSamples = new DevExpress.XtraTab.XtraTabPage();
            this.remoteSqlConnection1 = new bv.model.BLToolkit.RemoteProvider.Client.RemoteSqlConnection();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtSessionID = new DevExpress.XtraEditors.TextEdit();
            this.txtFieldID = new DevExpress.XtraEditors.TextEdit();
            this.txtVectorType = new DevExpress.XtraEditors.TextEdit();
            this.txtPoolVectorID = new DevExpress.XtraEditors.TextEdit();
            this.lblVectorType = new DevExpress.XtraEditors.LabelControl();
            this.lblSessionID = new DevExpress.XtraEditors.LabelControl();
            this.lblPoolVectorID = new DevExpress.XtraEditors.LabelControl();
            this.lblFieldID = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).BeginInit();
            this.tcMain.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcComment)).BeginInit();
            this.gcComment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoComment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAnimalsData)).BeginInit();
            this.gcAnimalsData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIdentificationDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIdentificationDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leIdentificationMethod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leIdentifiedBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leSex.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leIdentifiedByInstitution.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leSpecie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCollectionData)).BeginInit();
            this.gcCollectionData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leEctoparasitesCollected.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bppLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seElevation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leBasisOfRecord.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leHostGuestReference.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leCollectionMethod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leCollectionTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCollectionDateFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCollectionDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leCollector.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leCollectedByInstitution.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGeoReference.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leSurrounding.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSessionID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFieldID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVectorType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPoolVectorID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.tcMain, "tcMain");
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedTabPage = this.tpGeneral;
            this.tcMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpGeneral,
            this.tpVectorSpecificData,
            this.tpSamples});
            // 
            // tpGeneral
            // 
            this.tpGeneral.Appearance.PageClient.Options.UseFont = true;
            this.tpGeneral.Controls.Add(this.gcComment);
            this.tpGeneral.Controls.Add(this.gcAnimalsData);
            this.tpGeneral.Controls.Add(this.gcCollectionData);
            this.tpGeneral.Name = "tpGeneral";
            resources.ApplyResources(this.tpGeneral, "tpGeneral");
            // 
            // gcComment
            // 
            this.gcComment.Appearance.Options.UseFont = true;
            this.gcComment.AppearanceCaption.Options.UseFont = true;
            this.gcComment.Controls.Add(this.memoComment);
            resources.ApplyResources(this.gcComment, "gcComment");
            this.gcComment.Name = "gcComment";
            // 
            // memoComment
            // 
            resources.ApplyResources(this.memoComment, "memoComment");
            this.memoComment.Name = "memoComment";
            this.memoComment.Properties.Appearance.Options.UseFont = true;
            this.memoComment.Properties.AppearanceDisabled.Options.UseFont = true;
            this.memoComment.Properties.AppearanceFocused.Options.UseFont = true;
            this.memoComment.Properties.AppearanceReadOnly.Options.UseFont = true;
            // 
            // gcAnimalsData
            // 
            this.gcAnimalsData.Appearance.Options.UseFont = true;
            this.gcAnimalsData.AppearanceCaption.Options.UseFont = true;
            this.gcAnimalsData.Controls.Add(this.seQuantity);
            this.gcAnimalsData.Controls.Add(this.dtIdentificationDate);
            this.gcAnimalsData.Controls.Add(this.leIdentificationMethod);
            this.gcAnimalsData.Controls.Add(this.leIdentifiedBy);
            this.gcAnimalsData.Controls.Add(this.leSex);
            this.gcAnimalsData.Controls.Add(this.leIdentifiedByInstitution);
            this.gcAnimalsData.Controls.Add(this.leSpecie);
            this.gcAnimalsData.Controls.Add(this.lblSpecie);
            this.gcAnimalsData.Controls.Add(this.lblIdentificationDate);
            this.gcAnimalsData.Controls.Add(this.lblIdentificationMethod);
            this.gcAnimalsData.Controls.Add(this.lblIdentifiedBy);
            this.gcAnimalsData.Controls.Add(this.lblIdentifiedByInstitution);
            this.gcAnimalsData.Controls.Add(this.lblSex);
            this.gcAnimalsData.Controls.Add(this.lblQuantity);
            resources.ApplyResources(this.gcAnimalsData, "gcAnimalsData");
            this.gcAnimalsData.Name = "gcAnimalsData";
            // 
            // seQuantity
            // 
            resources.ApplyResources(this.seQuantity, "seQuantity");
            this.seQuantity.Name = "seQuantity";
            this.seQuantity.Properties.Appearance.Options.UseFont = true;
            this.seQuantity.Properties.AppearanceDisabled.Options.UseFont = true;
            this.seQuantity.Properties.AppearanceFocused.Options.UseFont = true;
            this.seQuantity.Properties.AppearanceReadOnly.Options.UseFont = true;
            serializableAppearanceObject1.Options.UseFont = true;
            this.seQuantity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("seQuantity.Properties.Buttons"))), resources.GetString("seQuantity.Properties.Buttons1"), ((int)(resources.GetObject("seQuantity.Properties.Buttons2"))), ((bool)(resources.GetObject("seQuantity.Properties.Buttons3"))), ((bool)(resources.GetObject("seQuantity.Properties.Buttons4"))), ((bool)(resources.GetObject("seQuantity.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("seQuantity.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("seQuantity.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, resources.GetString("seQuantity.Properties.Buttons8"), ((object)(resources.GetObject("seQuantity.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("seQuantity.Properties.Buttons10"))), ((bool)(resources.GetObject("seQuantity.Properties.Buttons11"))))});
            // 
            // dtIdentificationDate
            // 
            resources.ApplyResources(this.dtIdentificationDate, "dtIdentificationDate");
            this.dtIdentificationDate.Name = "dtIdentificationDate";
            this.dtIdentificationDate.Properties.Appearance.Options.UseFont = true;
            this.dtIdentificationDate.Properties.AppearanceDisabled.Options.UseFont = true;
            this.dtIdentificationDate.Properties.AppearanceDropDown.Options.UseFont = true;
            this.dtIdentificationDate.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.dtIdentificationDate.Properties.AppearanceDropDownHeaderHighlight.Options.UseFont = true;
            this.dtIdentificationDate.Properties.AppearanceDropDownHighlight.Options.UseFont = true;
            this.dtIdentificationDate.Properties.AppearanceFocused.Options.UseFont = true;
            this.dtIdentificationDate.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.dtIdentificationDate.Properties.AppearanceWeekNumber.Options.UseFont = true;
            serializableAppearanceObject2.Options.UseFont = true;
            this.dtIdentificationDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("dtIdentificationDate.Properties.Buttons"))), resources.GetString("dtIdentificationDate.Properties.Buttons1"), ((int)(resources.GetObject("dtIdentificationDate.Properties.Buttons2"))), ((bool)(resources.GetObject("dtIdentificationDate.Properties.Buttons3"))), ((bool)(resources.GetObject("dtIdentificationDate.Properties.Buttons4"))), ((bool)(resources.GetObject("dtIdentificationDate.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("dtIdentificationDate.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("dtIdentificationDate.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, resources.GetString("dtIdentificationDate.Properties.Buttons8"), ((object)(resources.GetObject("dtIdentificationDate.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("dtIdentificationDate.Properties.Buttons10"))), ((bool)(resources.GetObject("dtIdentificationDate.Properties.Buttons11"))))});
            this.dtIdentificationDate.Properties.VistaTimeProperties.Appearance.Options.UseFont = true;
            this.dtIdentificationDate.Properties.VistaTimeProperties.AppearanceDisabled.Options.UseFont = true;
            this.dtIdentificationDate.Properties.VistaTimeProperties.AppearanceFocused.Options.UseFont = true;
            this.dtIdentificationDate.Properties.VistaTimeProperties.AppearanceReadOnly.Options.UseFont = true;
            serializableAppearanceObject3.Options.UseFont = true;
            this.dtIdentificationDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("dtIdentificationDate.Properties.VistaTimeProperties.Buttons"))), resources.GetString("dtIdentificationDate.Properties.VistaTimeProperties.Buttons1"), ((int)(resources.GetObject("dtIdentificationDate.Properties.VistaTimeProperties.Buttons2"))), ((bool)(resources.GetObject("dtIdentificationDate.Properties.VistaTimeProperties.Buttons3"))), ((bool)(resources.GetObject("dtIdentificationDate.Properties.VistaTimeProperties.Buttons4"))), ((bool)(resources.GetObject("dtIdentificationDate.Properties.VistaTimeProperties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("dtIdentificationDate.Properties.VistaTimeProperties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("dtIdentificationDate.Properties.VistaTimeProperties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, resources.GetString("dtIdentificationDate.Properties.VistaTimeProperties.Buttons8"), ((object)(resources.GetObject("dtIdentificationDate.Properties.VistaTimeProperties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("dtIdentificationDate.Properties.VistaTimeProperties.Buttons10"))), ((bool)(resources.GetObject("dtIdentificationDate.Properties.VistaTimeProperties.Buttons11"))))});
            // 
            // leIdentificationMethod
            // 
            resources.ApplyResources(this.leIdentificationMethod, "leIdentificationMethod");
            this.leIdentificationMethod.Name = "leIdentificationMethod";
            this.leIdentificationMethod.Properties.Appearance.Options.UseFont = true;
            this.leIdentificationMethod.Properties.AppearanceDisabled.Options.UseFont = true;
            this.leIdentificationMethod.Properties.AppearanceDropDown.Options.UseFont = true;
            this.leIdentificationMethod.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.leIdentificationMethod.Properties.AppearanceFocused.Options.UseFont = true;
            this.leIdentificationMethod.Properties.AppearanceReadOnly.Options.UseFont = true;
            serializableAppearanceObject4.Options.UseFont = true;
            this.leIdentificationMethod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leIdentificationMethod.Properties.Buttons"))), resources.GetString("leIdentificationMethod.Properties.Buttons1"), ((int)(resources.GetObject("leIdentificationMethod.Properties.Buttons2"))), ((bool)(resources.GetObject("leIdentificationMethod.Properties.Buttons3"))), ((bool)(resources.GetObject("leIdentificationMethod.Properties.Buttons4"))), ((bool)(resources.GetObject("leIdentificationMethod.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("leIdentificationMethod.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("leIdentificationMethod.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, resources.GetString("leIdentificationMethod.Properties.Buttons8"), ((object)(resources.GetObject("leIdentificationMethod.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("leIdentificationMethod.Properties.Buttons10"))), ((bool)(resources.GetObject("leIdentificationMethod.Properties.Buttons11"))))});
            this.leIdentificationMethod.Properties.NullText = resources.GetString("leIdentificationMethod.Properties.NullText");
            // 
            // leIdentifiedBy
            // 
            resources.ApplyResources(this.leIdentifiedBy, "leIdentifiedBy");
            this.leIdentifiedBy.Name = "leIdentifiedBy";
            this.leIdentifiedBy.Properties.Appearance.Options.UseFont = true;
            this.leIdentifiedBy.Properties.AppearanceDisabled.Options.UseFont = true;
            this.leIdentifiedBy.Properties.AppearanceDropDown.Options.UseFont = true;
            this.leIdentifiedBy.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.leIdentifiedBy.Properties.AppearanceFocused.Options.UseFont = true;
            this.leIdentifiedBy.Properties.AppearanceReadOnly.Options.UseFont = true;
            serializableAppearanceObject5.Options.UseFont = true;
            this.leIdentifiedBy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leIdentifiedBy.Properties.Buttons"))), resources.GetString("leIdentifiedBy.Properties.Buttons1"), ((int)(resources.GetObject("leIdentifiedBy.Properties.Buttons2"))), ((bool)(resources.GetObject("leIdentifiedBy.Properties.Buttons3"))), ((bool)(resources.GetObject("leIdentifiedBy.Properties.Buttons4"))), ((bool)(resources.GetObject("leIdentifiedBy.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("leIdentifiedBy.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("leIdentifiedBy.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, resources.GetString("leIdentifiedBy.Properties.Buttons8"), ((object)(resources.GetObject("leIdentifiedBy.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("leIdentifiedBy.Properties.Buttons10"))), ((bool)(resources.GetObject("leIdentifiedBy.Properties.Buttons11"))))});
            this.leIdentifiedBy.Properties.NullText = resources.GetString("leIdentifiedBy.Properties.NullText");
            // 
            // leSex
            // 
            resources.ApplyResources(this.leSex, "leSex");
            this.leSex.Name = "leSex";
            this.leSex.Properties.Appearance.Options.UseFont = true;
            this.leSex.Properties.AppearanceDisabled.Options.UseFont = true;
            this.leSex.Properties.AppearanceDropDown.Options.UseFont = true;
            this.leSex.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.leSex.Properties.AppearanceFocused.Options.UseFont = true;
            this.leSex.Properties.AppearanceReadOnly.Options.UseFont = true;
            serializableAppearanceObject6.Options.UseFont = true;
            this.leSex.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leSex.Properties.Buttons"))), resources.GetString("leSex.Properties.Buttons1"), ((int)(resources.GetObject("leSex.Properties.Buttons2"))), ((bool)(resources.GetObject("leSex.Properties.Buttons3"))), ((bool)(resources.GetObject("leSex.Properties.Buttons4"))), ((bool)(resources.GetObject("leSex.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("leSex.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("leSex.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, resources.GetString("leSex.Properties.Buttons8"), ((object)(resources.GetObject("leSex.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("leSex.Properties.Buttons10"))), ((bool)(resources.GetObject("leSex.Properties.Buttons11"))))});
            this.leSex.Properties.NullText = resources.GetString("leSex.Properties.NullText");
            // 
            // leIdentifiedByInstitution
            // 
            resources.ApplyResources(this.leIdentifiedByInstitution, "leIdentifiedByInstitution");
            this.leIdentifiedByInstitution.Name = "leIdentifiedByInstitution";
            this.leIdentifiedByInstitution.Properties.Appearance.Options.UseFont = true;
            this.leIdentifiedByInstitution.Properties.AppearanceDisabled.Options.UseFont = true;
            this.leIdentifiedByInstitution.Properties.AppearanceDropDown.Options.UseFont = true;
            this.leIdentifiedByInstitution.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.leIdentifiedByInstitution.Properties.AppearanceFocused.Options.UseFont = true;
            this.leIdentifiedByInstitution.Properties.AppearanceReadOnly.Options.UseFont = true;
            serializableAppearanceObject7.Options.UseFont = true;
            this.leIdentifiedByInstitution.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leIdentifiedByInstitution.Properties.Buttons"))), resources.GetString("leIdentifiedByInstitution.Properties.Buttons1"), ((int)(resources.GetObject("leIdentifiedByInstitution.Properties.Buttons2"))), ((bool)(resources.GetObject("leIdentifiedByInstitution.Properties.Buttons3"))), ((bool)(resources.GetObject("leIdentifiedByInstitution.Properties.Buttons4"))), ((bool)(resources.GetObject("leIdentifiedByInstitution.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("leIdentifiedByInstitution.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("leIdentifiedByInstitution.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7, resources.GetString("leIdentifiedByInstitution.Properties.Buttons8"), ((object)(resources.GetObject("leIdentifiedByInstitution.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("leIdentifiedByInstitution.Properties.Buttons10"))), ((bool)(resources.GetObject("leIdentifiedByInstitution.Properties.Buttons11"))))});
            this.leIdentifiedByInstitution.Properties.NullText = resources.GetString("leIdentifiedByInstitution.Properties.NullText");
            // 
            // leSpecie
            // 
            resources.ApplyResources(this.leSpecie, "leSpecie");
            this.leSpecie.Name = "leSpecie";
            this.leSpecie.Properties.Appearance.Options.UseFont = true;
            this.leSpecie.Properties.AppearanceDisabled.Options.UseFont = true;
            this.leSpecie.Properties.AppearanceDropDown.Options.UseFont = true;
            this.leSpecie.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.leSpecie.Properties.AppearanceFocused.Options.UseFont = true;
            this.leSpecie.Properties.AppearanceReadOnly.Options.UseFont = true;
            serializableAppearanceObject8.Options.UseFont = true;
            this.leSpecie.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leSpecie.Properties.Buttons"))), resources.GetString("leSpecie.Properties.Buttons1"), ((int)(resources.GetObject("leSpecie.Properties.Buttons2"))), ((bool)(resources.GetObject("leSpecie.Properties.Buttons3"))), ((bool)(resources.GetObject("leSpecie.Properties.Buttons4"))), ((bool)(resources.GetObject("leSpecie.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("leSpecie.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("leSpecie.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8, resources.GetString("leSpecie.Properties.Buttons8"), ((object)(resources.GetObject("leSpecie.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("leSpecie.Properties.Buttons10"))), ((bool)(resources.GetObject("leSpecie.Properties.Buttons11"))))});
            this.leSpecie.Properties.NullText = resources.GetString("leSpecie.Properties.NullText");
            // 
            // lblSpecie
            // 
            this.lblSpecie.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblSpecie.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblSpecie, "lblSpecie");
            this.lblSpecie.Name = "lblSpecie";
            // 
            // lblIdentificationDate
            // 
            this.lblIdentificationDate.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblIdentificationDate.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblIdentificationDate, "lblIdentificationDate");
            this.lblIdentificationDate.Name = "lblIdentificationDate";
            // 
            // lblIdentificationMethod
            // 
            this.lblIdentificationMethod.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblIdentificationMethod.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblIdentificationMethod, "lblIdentificationMethod");
            this.lblIdentificationMethod.Name = "lblIdentificationMethod";
            // 
            // lblIdentifiedBy
            // 
            this.lblIdentifiedBy.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblIdentifiedBy.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblIdentifiedBy, "lblIdentifiedBy");
            this.lblIdentifiedBy.Name = "lblIdentifiedBy";
            // 
            // lblIdentifiedByInstitution
            // 
            this.lblIdentifiedByInstitution.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblIdentifiedByInstitution.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblIdentifiedByInstitution, "lblIdentifiedByInstitution");
            this.lblIdentifiedByInstitution.Name = "lblIdentifiedByInstitution";
            // 
            // lblSex
            // 
            this.lblSex.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblSex.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblSex, "lblSex");
            this.lblSex.Name = "lblSex";
            // 
            // lblQuantity
            // 
            this.lblQuantity.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblQuantity.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblQuantity, "lblQuantity");
            this.lblQuantity.Name = "lblQuantity";
            // 
            // gcCollectionData
            // 
            this.gcCollectionData.Appearance.Options.UseFont = true;
            this.gcCollectionData.AppearanceCaption.Options.UseFont = true;
            this.gcCollectionData.Controls.Add(this.leEctoparasitesCollected);
            this.gcCollectionData.Controls.Add(this.bppLocation);
            this.gcCollectionData.Controls.Add(this.seElevation);
            this.gcCollectionData.Controls.Add(this.leBasisOfRecord);
            this.gcCollectionData.Controls.Add(this.leHostGuestReference);
            this.gcCollectionData.Controls.Add(this.leCollectionMethod);
            this.gcCollectionData.Controls.Add(this.leCollectionTime);
            this.gcCollectionData.Controls.Add(this.dtCollectionDateFrom);
            this.gcCollectionData.Controls.Add(this.leCollector);
            this.gcCollectionData.Controls.Add(this.leCollectedByInstitution);
            this.gcCollectionData.Controls.Add(this.txtGeoReference);
            this.gcCollectionData.Controls.Add(this.leSurrounding);
            this.gcCollectionData.Controls.Add(this.lblBasisOfRecord);
            this.gcCollectionData.Controls.Add(this.lblHostGuestReference);
            this.gcCollectionData.Controls.Add(this.lblGeoReference);
            this.gcCollectionData.Controls.Add(this.lvlElevation);
            this.gcCollectionData.Controls.Add(this.lblSurrounding);
            this.gcCollectionData.Controls.Add(this.lblLongitudeLatitude);
            this.gcCollectionData.Controls.Add(this.labelControl1);
            this.gcCollectionData.Controls.Add(this.lblCollectionMethod);
            this.gcCollectionData.Controls.Add(this.lblCollectionTime);
            this.gcCollectionData.Controls.Add(this.lblCollectionDate);
            this.gcCollectionData.Controls.Add(this.lblCollector);
            this.gcCollectionData.Controls.Add(this.lblInstitution);
            resources.ApplyResources(this.gcCollectionData, "gcCollectionData");
            this.gcCollectionData.Name = "gcCollectionData";
            // 
            // leEctoparasitesCollected
            // 
            resources.ApplyResources(this.leEctoparasitesCollected, "leEctoparasitesCollected");
            this.leEctoparasitesCollected.Name = "leEctoparasitesCollected";
            this.leEctoparasitesCollected.Properties.Appearance.Options.UseFont = true;
            this.leEctoparasitesCollected.Properties.AppearanceDisabled.Options.UseFont = true;
            this.leEctoparasitesCollected.Properties.AppearanceDropDown.Options.UseFont = true;
            this.leEctoparasitesCollected.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.leEctoparasitesCollected.Properties.AppearanceFocused.Options.UseFont = true;
            this.leEctoparasitesCollected.Properties.AppearanceReadOnly.Options.UseFont = true;
            serializableAppearanceObject9.Options.UseFont = true;
            this.leEctoparasitesCollected.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leEctoparasitesCollected.Properties.Buttons"))), resources.GetString("leEctoparasitesCollected.Properties.Buttons1"), ((int)(resources.GetObject("leEctoparasitesCollected.Properties.Buttons2"))), ((bool)(resources.GetObject("leEctoparasitesCollected.Properties.Buttons3"))), ((bool)(resources.GetObject("leEctoparasitesCollected.Properties.Buttons4"))), ((bool)(resources.GetObject("leEctoparasitesCollected.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("leEctoparasitesCollected.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("leEctoparasitesCollected.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, resources.GetString("leEctoparasitesCollected.Properties.Buttons8"), ((object)(resources.GetObject("leEctoparasitesCollected.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("leEctoparasitesCollected.Properties.Buttons10"))), ((bool)(resources.GetObject("leEctoparasitesCollected.Properties.Buttons11"))))});
            this.leEctoparasitesCollected.Properties.NullText = resources.GetString("leEctoparasitesCollected.Properties.NullText");
            // 
            // bppLocation
            // 
            resources.ApplyResources(this.bppLocation, "bppLocation");
            this.bppLocation.Name = "bppLocation";
            this.bppLocation.Properties.Appearance.Options.UseFont = true;
            this.bppLocation.Properties.AppearanceDisabled.Options.UseFont = true;
            this.bppLocation.Properties.AppearanceDropDown.Options.UseFont = true;
            this.bppLocation.Properties.AppearanceFocused.Options.UseFont = true;
            this.bppLocation.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.bppLocation.Properties.AutoHeight = ((bool)(resources.GetObject("bppLocation.Properties.AutoHeight")));
            this.bppLocation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("bppLocation.Properties.Buttons"))))});
            this.bppLocation.Properties.CloseOnOuterMouseClick = false;
            this.bppLocation.Properties.PopupFormMinSize = new System.Drawing.Size(416, 349);
            this.bppLocation.Properties.PopupFormSize = new System.Drawing.Size(420, 328);
            this.bppLocation.Properties.PopupSizeable = false;
            this.bppLocation.Properties.ReadOnly = true;
            this.bppLocation.Properties.ShowPopupCloseButton = false;
            // 
            // seElevation
            // 
            resources.ApplyResources(this.seElevation, "seElevation");
            this.seElevation.Name = "seElevation";
            this.seElevation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // leBasisOfRecord
            // 
            resources.ApplyResources(this.leBasisOfRecord, "leBasisOfRecord");
            this.leBasisOfRecord.Name = "leBasisOfRecord";
            this.leBasisOfRecord.Properties.Appearance.Options.UseFont = true;
            this.leBasisOfRecord.Properties.AppearanceDisabled.Options.UseFont = true;
            this.leBasisOfRecord.Properties.AppearanceDropDown.Options.UseFont = true;
            this.leBasisOfRecord.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.leBasisOfRecord.Properties.AppearanceFocused.Options.UseFont = true;
            this.leBasisOfRecord.Properties.AppearanceReadOnly.Options.UseFont = true;
            serializableAppearanceObject10.Options.UseFont = true;
            this.leBasisOfRecord.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leBasisOfRecord.Properties.Buttons"))), resources.GetString("leBasisOfRecord.Properties.Buttons1"), ((int)(resources.GetObject("leBasisOfRecord.Properties.Buttons2"))), ((bool)(resources.GetObject("leBasisOfRecord.Properties.Buttons3"))), ((bool)(resources.GetObject("leBasisOfRecord.Properties.Buttons4"))), ((bool)(resources.GetObject("leBasisOfRecord.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("leBasisOfRecord.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("leBasisOfRecord.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10, resources.GetString("leBasisOfRecord.Properties.Buttons8"), ((object)(resources.GetObject("leBasisOfRecord.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("leBasisOfRecord.Properties.Buttons10"))), ((bool)(resources.GetObject("leBasisOfRecord.Properties.Buttons11"))))});
            this.leBasisOfRecord.Properties.NullText = resources.GetString("leBasisOfRecord.Properties.NullText");
            // 
            // leHostGuestReference
            // 
            resources.ApplyResources(this.leHostGuestReference, "leHostGuestReference");
            this.leHostGuestReference.Name = "leHostGuestReference";
            this.leHostGuestReference.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leHostGuestReference.Properties.Buttons"))))});
            this.leHostGuestReference.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("leHostGuestReference.Properties.Columns"), resources.GetString("leHostGuestReference.Properties.Columns1"), ((int)(resources.GetObject("leHostGuestReference.Properties.Columns2"))), ((DevExpress.Utils.FormatType)(resources.GetObject("leHostGuestReference.Properties.Columns3"))), resources.GetString("leHostGuestReference.Properties.Columns4"), ((bool)(resources.GetObject("leHostGuestReference.Properties.Columns5"))), ((DevExpress.Utils.HorzAlignment)(resources.GetObject("leHostGuestReference.Properties.Columns6")))),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("leHostGuestReference.Properties.Columns7"), resources.GetString("leHostGuestReference.Properties.Columns8")),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("leHostGuestReference.Properties.Columns9"), resources.GetString("leHostGuestReference.Properties.Columns10")),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("leHostGuestReference.Properties.Columns11"), resources.GetString("leHostGuestReference.Properties.Columns12"))});
            this.leHostGuestReference.Properties.DisplayMember = "strFieldVectorID";
            this.leHostGuestReference.Properties.NullText = resources.GetString("leHostGuestReference.Properties.NullText");
            this.leHostGuestReference.Properties.ValueMember = "idfVector";
            // 
            // leCollectionMethod
            // 
            resources.ApplyResources(this.leCollectionMethod, "leCollectionMethod");
            this.leCollectionMethod.Name = "leCollectionMethod";
            this.leCollectionMethod.Properties.Appearance.Options.UseFont = true;
            this.leCollectionMethod.Properties.AppearanceDisabled.Options.UseFont = true;
            this.leCollectionMethod.Properties.AppearanceDropDown.Options.UseFont = true;
            this.leCollectionMethod.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.leCollectionMethod.Properties.AppearanceFocused.Options.UseFont = true;
            this.leCollectionMethod.Properties.AppearanceReadOnly.Options.UseFont = true;
            serializableAppearanceObject11.Options.UseFont = true;
            this.leCollectionMethod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leCollectionMethod.Properties.Buttons"))), resources.GetString("leCollectionMethod.Properties.Buttons1"), ((int)(resources.GetObject("leCollectionMethod.Properties.Buttons2"))), ((bool)(resources.GetObject("leCollectionMethod.Properties.Buttons3"))), ((bool)(resources.GetObject("leCollectionMethod.Properties.Buttons4"))), ((bool)(resources.GetObject("leCollectionMethod.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("leCollectionMethod.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("leCollectionMethod.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11, resources.GetString("leCollectionMethod.Properties.Buttons8"), ((object)(resources.GetObject("leCollectionMethod.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("leCollectionMethod.Properties.Buttons10"))), ((bool)(resources.GetObject("leCollectionMethod.Properties.Buttons11"))))});
            this.leCollectionMethod.Properties.NullText = resources.GetString("leCollectionMethod.Properties.NullText");
            // 
            // leCollectionTime
            // 
            resources.ApplyResources(this.leCollectionTime, "leCollectionTime");
            this.leCollectionTime.Name = "leCollectionTime";
            this.leCollectionTime.Properties.Appearance.Options.UseFont = true;
            this.leCollectionTime.Properties.AppearanceDisabled.Options.UseFont = true;
            this.leCollectionTime.Properties.AppearanceDropDown.Options.UseFont = true;
            this.leCollectionTime.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.leCollectionTime.Properties.AppearanceFocused.Options.UseFont = true;
            this.leCollectionTime.Properties.AppearanceReadOnly.Options.UseFont = true;
            serializableAppearanceObject12.Options.UseFont = true;
            this.leCollectionTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leCollectionTime.Properties.Buttons"))), resources.GetString("leCollectionTime.Properties.Buttons1"), ((int)(resources.GetObject("leCollectionTime.Properties.Buttons2"))), ((bool)(resources.GetObject("leCollectionTime.Properties.Buttons3"))), ((bool)(resources.GetObject("leCollectionTime.Properties.Buttons4"))), ((bool)(resources.GetObject("leCollectionTime.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("leCollectionTime.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("leCollectionTime.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12, resources.GetString("leCollectionTime.Properties.Buttons8"), ((object)(resources.GetObject("leCollectionTime.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("leCollectionTime.Properties.Buttons10"))), ((bool)(resources.GetObject("leCollectionTime.Properties.Buttons11"))))});
            this.leCollectionTime.Properties.NullText = resources.GetString("leCollectionTime.Properties.NullText");
            // 
            // dtCollectionDateFrom
            // 
            resources.ApplyResources(this.dtCollectionDateFrom, "dtCollectionDateFrom");
            this.dtCollectionDateFrom.Name = "dtCollectionDateFrom";
            this.dtCollectionDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("dtCollectionDateFrom.Properties.Buttons"))))});
            this.dtCollectionDateFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // leCollector
            // 
            resources.ApplyResources(this.leCollector, "leCollector");
            this.leCollector.Name = "leCollector";
            this.leCollector.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leCollector.Properties.Buttons"))))});
            this.leCollector.Properties.NullText = resources.GetString("leCollector.Properties.NullText");
            // 
            // leCollectedByInstitution
            // 
            resources.ApplyResources(this.leCollectedByInstitution, "leCollectedByInstitution");
            this.leCollectedByInstitution.Name = "leCollectedByInstitution";
            this.leCollectedByInstitution.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leCollectedByInstitution.Properties.Buttons"))))});
            this.leCollectedByInstitution.Properties.NullText = resources.GetString("leCollectedByInstitution.Properties.NullText");
            this.leCollectedByInstitution.Properties.PopupWidth = 250;
            // 
            // txtGeoReference
            // 
            resources.ApplyResources(this.txtGeoReference, "txtGeoReference");
            this.txtGeoReference.Name = "txtGeoReference";
            // 
            // leSurrounding
            // 
            resources.ApplyResources(this.leSurrounding, "leSurrounding");
            this.leSurrounding.Name = "leSurrounding";
            this.leSurrounding.Properties.Appearance.Options.UseFont = true;
            this.leSurrounding.Properties.AppearanceDisabled.Options.UseFont = true;
            this.leSurrounding.Properties.AppearanceDropDown.Options.UseFont = true;
            this.leSurrounding.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.leSurrounding.Properties.AppearanceFocused.Options.UseFont = true;
            this.leSurrounding.Properties.AppearanceReadOnly.Options.UseFont = true;
            serializableAppearanceObject13.Options.UseFont = true;
            this.leSurrounding.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leSurrounding.Properties.Buttons"))), resources.GetString("leSurrounding.Properties.Buttons1"), ((int)(resources.GetObject("leSurrounding.Properties.Buttons2"))), ((bool)(resources.GetObject("leSurrounding.Properties.Buttons3"))), ((bool)(resources.GetObject("leSurrounding.Properties.Buttons4"))), ((bool)(resources.GetObject("leSurrounding.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("leSurrounding.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("leSurrounding.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13, resources.GetString("leSurrounding.Properties.Buttons8"), ((object)(resources.GetObject("leSurrounding.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("leSurrounding.Properties.Buttons10"))), ((bool)(resources.GetObject("leSurrounding.Properties.Buttons11"))))});
            this.leSurrounding.Properties.NullText = resources.GetString("leSurrounding.Properties.NullText");
            // 
            // lblBasisOfRecord
            // 
            this.lblBasisOfRecord.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblBasisOfRecord.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblBasisOfRecord, "lblBasisOfRecord");
            this.lblBasisOfRecord.Name = "lblBasisOfRecord";
            // 
            // lblHostGuestReference
            // 
            this.lblHostGuestReference.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblHostGuestReference.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblHostGuestReference, "lblHostGuestReference");
            this.lblHostGuestReference.Name = "lblHostGuestReference";
            // 
            // lblGeoReference
            // 
            this.lblGeoReference.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblGeoReference.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblGeoReference, "lblGeoReference");
            this.lblGeoReference.Name = "lblGeoReference";
            // 
            // lvlElevation
            // 
            this.lvlElevation.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lvlElevation.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lvlElevation, "lvlElevation");
            this.lvlElevation.Name = "lvlElevation";
            // 
            // lblSurrounding
            // 
            this.lblSurrounding.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblSurrounding.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblSurrounding, "lblSurrounding");
            this.lblSurrounding.Name = "lblSurrounding";
            // 
            // lblLongitudeLatitude
            // 
            this.lblLongitudeLatitude.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblLongitudeLatitude.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblLongitudeLatitude, "lblLongitudeLatitude");
            this.lblLongitudeLatitude.Name = "lblLongitudeLatitude";
            // 
            // labelControl1
            // 
            resources.ApplyResources(this.labelControl1, "labelControl1");
            this.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl1.Name = "labelControl1";
            // 
            // lblCollectionMethod
            // 
            resources.ApplyResources(this.lblCollectionMethod, "lblCollectionMethod");
            this.lblCollectionMethod.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblCollectionMethod.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblCollectionMethod.Name = "lblCollectionMethod";
            // 
            // lblCollectionTime
            // 
            resources.ApplyResources(this.lblCollectionTime, "lblCollectionTime");
            this.lblCollectionTime.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblCollectionTime.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblCollectionTime.Name = "lblCollectionTime";
            // 
            // lblCollectionDate
            // 
            resources.ApplyResources(this.lblCollectionDate, "lblCollectionDate");
            this.lblCollectionDate.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblCollectionDate.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblCollectionDate.Name = "lblCollectionDate";
            // 
            // lblCollector
            // 
            resources.ApplyResources(this.lblCollector, "lblCollector");
            this.lblCollector.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblCollector.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblCollector.Name = "lblCollector";
            // 
            // lblInstitution
            // 
            resources.ApplyResources(this.lblInstitution, "lblInstitution");
            this.lblInstitution.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblInstitution.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblInstitution.Name = "lblInstitution";
            // 
            // tpVectorSpecificData
            // 
            this.tpVectorSpecificData.Name = "tpVectorSpecificData";
            resources.ApplyResources(this.tpVectorSpecificData, "tpVectorSpecificData");
            // 
            // tpSamples
            // 
            this.tpSamples.Name = "tpSamples";
            resources.ApplyResources(this.tpSamples, "tpSamples");
            // 
            // remoteSqlConnection1
            // 
            this.remoteSqlConnection1.ConnectionString = null;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtSessionID);
            this.panelControl1.Controls.Add(this.txtFieldID);
            this.panelControl1.Controls.Add(this.txtVectorType);
            this.panelControl1.Controls.Add(this.txtPoolVectorID);
            this.panelControl1.Controls.Add(this.lblVectorType);
            this.panelControl1.Controls.Add(this.lblSessionID);
            this.panelControl1.Controls.Add(this.lblPoolVectorID);
            this.panelControl1.Controls.Add(this.lblFieldID);
            resources.ApplyResources(this.panelControl1, "panelControl1");
            this.panelControl1.Name = "panelControl1";
            // 
            // txtSessionID
            // 
            resources.ApplyResources(this.txtSessionID, "txtSessionID");
            this.txtSessionID.Name = "txtSessionID";
            // 
            // txtFieldID
            // 
            resources.ApplyResources(this.txtFieldID, "txtFieldID");
            this.txtFieldID.Name = "txtFieldID";
            // 
            // txtVectorType
            // 
            resources.ApplyResources(this.txtVectorType, "txtVectorType");
            this.txtVectorType.Name = "txtVectorType";
            // 
            // txtPoolVectorID
            // 
            resources.ApplyResources(this.txtPoolVectorID, "txtPoolVectorID");
            this.txtPoolVectorID.Name = "txtPoolVectorID";
            // 
            // lblVectorType
            // 
            this.lblVectorType.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblVectorType.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblVectorType, "lblVectorType");
            this.lblVectorType.Name = "lblVectorType";
            // 
            // lblSessionID
            // 
            this.lblSessionID.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblSessionID.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblSessionID, "lblSessionID");
            this.lblSessionID.Name = "lblSessionID";
            // 
            // lblPoolVectorID
            // 
            this.lblPoolVectorID.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblPoolVectorID.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblPoolVectorID, "lblPoolVectorID");
            this.lblPoolVectorID.Name = "lblPoolVectorID";
            // 
            // lblFieldID
            // 
            this.lblFieldID.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFieldID.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblFieldID, "lblFieldID");
            this.lblFieldID.Name = "lblFieldID";
            // 
            // VectorDetail
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.panelControl1);
            this.Icon = global::eidss.winclient.Properties.Resources.Vector_05_;
            this.Name = "VectorDetail";
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).EndInit();
            this.tcMain.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcComment)).EndInit();
            this.gcComment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoComment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAnimalsData)).EndInit();
            this.gcAnimalsData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.seQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIdentificationDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIdentificationDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leIdentificationMethod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leIdentifiedBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leSex.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leIdentifiedByInstitution.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leSpecie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCollectionData)).EndInit();
            this.gcCollectionData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.leEctoparasitesCollected.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bppLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seElevation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leBasisOfRecord.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leHostGuestReference.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leCollectionMethod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leCollectionTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCollectionDateFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCollectionDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leCollector.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leCollectedByInstitution.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGeoReference.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leSurrounding.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSessionID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFieldID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVectorType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPoolVectorID.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tcMain;
        private DevExpress.XtraTab.XtraTabPage tpGeneral;
        private DevExpress.XtraTab.XtraTabPage tpVectorSpecificData;
        private DevExpress.XtraTab.XtraTabPage tpSamples;
        private DevExpress.XtraEditors.GroupControl gcComment;
        private DevExpress.XtraEditors.GroupControl gcAnimalsData;
        private DevExpress.XtraEditors.GroupControl gcCollectionData;
        private DevExpress.XtraEditors.MemoEdit memoComment;
        private DevExpress.XtraEditors.LabelControl lblLongitudeLatitude;
        private DevExpress.XtraEditors.TextEdit txtGeoReference;
        private DevExpress.XtraEditors.LabelControl lblGeoReference;
        private DevExpress.XtraEditors.LabelControl lvlElevation;
        private DevExpress.XtraEditors.LookUpEdit leSurrounding;
        private DevExpress.XtraEditors.LabelControl lblSurrounding;
        private DevExpress.XtraEditors.LabelControl lblCollector;
        private DevExpress.XtraEditors.LookUpEdit leCollector;
        private DevExpress.XtraEditors.LabelControl lblInstitution;
        private DevExpress.XtraEditors.LookUpEdit leCollectedByInstitution;
        private DevExpress.XtraEditors.LookUpEdit leBasisOfRecord;
        private DevExpress.XtraEditors.LabelControl lblBasisOfRecord;
        private DevExpress.XtraEditors.LabelControl lblHostGuestReference;
        private DevExpress.XtraEditors.LookUpEdit leHostGuestReference;
        private DevExpress.XtraEditors.LookUpEdit leCollectionMethod;
        private DevExpress.XtraEditors.LabelControl lblCollectionMethod;
        private DevExpress.XtraEditors.LookUpEdit leCollectionTime;
        private DevExpress.XtraEditors.LabelControl lblCollectionTime;
        private DevExpress.XtraEditors.LabelControl lblCollectionDate;
        private DevExpress.XtraEditors.DateEdit dtCollectionDateFrom;
        private DevExpress.XtraEditors.DateEdit dtIdentificationDate;
        private DevExpress.XtraEditors.LabelControl lblIdentificationDate;
        private DevExpress.XtraEditors.LookUpEdit leIdentificationMethod;
        private DevExpress.XtraEditors.LabelControl lblIdentificationMethod;
        private DevExpress.XtraEditors.LabelControl lblIdentifiedBy;
        private DevExpress.XtraEditors.LookUpEdit leIdentifiedBy;
        private DevExpress.XtraEditors.LabelControl lblIdentifiedByInstitution;
        private DevExpress.XtraEditors.LookUpEdit leSex;
        private DevExpress.XtraEditors.LookUpEdit leIdentifiedByInstitution;
        private DevExpress.XtraEditors.LabelControl lblSex;
        private DevExpress.XtraEditors.LookUpEdit leSpecie;
        private DevExpress.XtraEditors.LabelControl lblSpecie;
        private DevExpress.XtraEditors.LabelControl lblQuantity;
        private bv.model.BLToolkit.RemoteProvider.Client.RemoteSqlConnection remoteSqlConnection1;
        private DevExpress.XtraEditors.SpinEdit seQuantity;
        private DevExpress.XtraEditors.SpinEdit seElevation;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lblPoolVectorID;
        private DevExpress.XtraEditors.TextEdit txtSessionID;
        private DevExpress.XtraEditors.TextEdit txtFieldID;
        private DevExpress.XtraEditors.LabelControl lblVectorType;
        private DevExpress.XtraEditors.LabelControl lblFieldID;
        private DevExpress.XtraEditors.TextEdit txtVectorType;
        private DevExpress.XtraEditors.TextEdit txtPoolVectorID;
        private DevExpress.XtraEditors.LabelControl lblSessionID;
        private Location.LocationLookup bppLocation;
        private DevExpress.XtraEditors.LookUpEdit leEctoparasitesCollected;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
