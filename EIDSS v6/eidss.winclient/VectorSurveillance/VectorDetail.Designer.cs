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
            this.leSpecies = new DevExpress.XtraEditors.LookUpEdit();
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
            this.tpFieldTests = new DevExpress.XtraTab.XtraTabPage();
            this.tpLabTests = new DevExpress.XtraTab.XtraTabPage();
            this.remoteSqlConnection1 = new bv.model.BLToolkit.RemoteProvider.Client.RemoteSqlConnection();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.leVectorType = new DevExpress.XtraEditors.LookUpEdit();
            this.txtSessionID = new DevExpress.XtraEditors.TextEdit();
            this.txtFieldID = new DevExpress.XtraEditors.TextEdit();
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
            ((System.ComponentModel.ISupportInitialize)(this.dtIdentificationDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIdentificationDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leIdentificationMethod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leIdentifiedBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leSex.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leIdentifiedByInstitution.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leSpecies.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCollectionData)).BeginInit();
            this.gcCollectionData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leEctoparasitesCollected.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bppLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seElevation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leBasisOfRecord.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leHostGuestReference.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leCollectionMethod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leCollectionTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCollectionDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCollectionDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leCollector.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leCollectedByInstitution.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGeoReference.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leSurrounding.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leVectorType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSessionID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFieldID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPoolVectorID.Properties)).BeginInit();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(VectorDetail), out resources);
            // Form Is Localizable: True
            // 
            // tcMain
            // 
            resources.ApplyResources(this.tcMain, "tcMain");
            this.tcMain.Appearance.FontSizeDelta = ((int)(resources.GetObject("tcMain.Appearance.FontSizeDelta")));
            this.tcMain.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("tcMain.Appearance.FontStyleDelta")));
            this.tcMain.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("tcMain.Appearance.GradientMode")));
            this.tcMain.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("tcMain.Appearance.Image")));
            this.tcMain.Appearance.Options.UseFont = true;
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedTabPage = this.tpGeneral;
            this.tcMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpGeneral,
            this.tpVectorSpecificData,
            this.tpSamples,
            this.tpFieldTests,
            this.tpLabTests});
            // 
            // tpGeneral
            // 
            resources.ApplyResources(this.tpGeneral, "tpGeneral");
            this.tpGeneral.Appearance.PageClient.FontSizeDelta = ((int)(resources.GetObject("tpGeneral.Appearance.PageClient.FontSizeDelta")));
            this.tpGeneral.Appearance.PageClient.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("tpGeneral.Appearance.PageClient.FontStyleDelta")));
            this.tpGeneral.Appearance.PageClient.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("tpGeneral.Appearance.PageClient.GradientMode")));
            this.tpGeneral.Appearance.PageClient.Image = ((System.Drawing.Image)(resources.GetObject("tpGeneral.Appearance.PageClient.Image")));
            this.tpGeneral.Appearance.PageClient.Options.UseFont = true;
            this.tpGeneral.Controls.Add(this.gcComment);
            this.tpGeneral.Controls.Add(this.gcAnimalsData);
            this.tpGeneral.Controls.Add(this.gcCollectionData);
            this.tpGeneral.Name = "tpGeneral";
            // 
            // gcComment
            // 
            resources.ApplyResources(this.gcComment, "gcComment");
            this.gcComment.Appearance.FontSizeDelta = ((int)(resources.GetObject("gcComment.Appearance.FontSizeDelta")));
            this.gcComment.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("gcComment.Appearance.FontStyleDelta")));
            this.gcComment.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("gcComment.Appearance.GradientMode")));
            this.gcComment.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("gcComment.Appearance.Image")));
            this.gcComment.Appearance.Options.UseFont = true;
            this.gcComment.AppearanceCaption.FontSizeDelta = ((int)(resources.GetObject("gcComment.AppearanceCaption.FontSizeDelta")));
            this.gcComment.AppearanceCaption.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("gcComment.AppearanceCaption.FontStyleDelta")));
            this.gcComment.AppearanceCaption.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("gcComment.AppearanceCaption.GradientMode")));
            this.gcComment.AppearanceCaption.Image = ((System.Drawing.Image)(resources.GetObject("gcComment.AppearanceCaption.Image")));
            this.gcComment.AppearanceCaption.Options.UseFont = true;
            this.gcComment.Controls.Add(this.memoComment);
            this.gcComment.Name = "gcComment";
            // 
            // memoComment
            // 
            resources.ApplyResources(this.memoComment, "memoComment");
            this.memoComment.Name = "memoComment";
            this.memoComment.Properties.AccessibleDescription = resources.GetString("memoComment.Properties.AccessibleDescription");
            this.memoComment.Properties.AccessibleName = resources.GetString("memoComment.Properties.AccessibleName");
            this.memoComment.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("memoComment.Properties.Appearance.FontSizeDelta")));
            this.memoComment.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("memoComment.Properties.Appearance.FontStyleDelta")));
            this.memoComment.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("memoComment.Properties.Appearance.GradientMode")));
            this.memoComment.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("memoComment.Properties.Appearance.Image")));
            this.memoComment.Properties.Appearance.Options.UseFont = true;
            this.memoComment.Properties.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("memoComment.Properties.AppearanceDisabled.FontSizeDelta")));
            this.memoComment.Properties.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("memoComment.Properties.AppearanceDisabled.FontStyleDelta")));
            this.memoComment.Properties.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("memoComment.Properties.AppearanceDisabled.GradientMode")));
            this.memoComment.Properties.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("memoComment.Properties.AppearanceDisabled.Image")));
            this.memoComment.Properties.AppearanceDisabled.Options.UseFont = true;
            this.memoComment.Properties.AppearanceFocused.FontSizeDelta = ((int)(resources.GetObject("memoComment.Properties.AppearanceFocused.FontSizeDelta")));
            this.memoComment.Properties.AppearanceFocused.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("memoComment.Properties.AppearanceFocused.FontStyleDelta")));
            this.memoComment.Properties.AppearanceFocused.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("memoComment.Properties.AppearanceFocused.GradientMode")));
            this.memoComment.Properties.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("memoComment.Properties.AppearanceFocused.Image")));
            this.memoComment.Properties.AppearanceFocused.Options.UseFont = true;
            this.memoComment.Properties.AppearanceReadOnly.FontSizeDelta = ((int)(resources.GetObject("memoComment.Properties.AppearanceReadOnly.FontSizeDelta")));
            this.memoComment.Properties.AppearanceReadOnly.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("memoComment.Properties.AppearanceReadOnly.FontStyleDelta")));
            this.memoComment.Properties.AppearanceReadOnly.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("memoComment.Properties.AppearanceReadOnly.GradientMode")));
            this.memoComment.Properties.AppearanceReadOnly.Image = ((System.Drawing.Image)(resources.GetObject("memoComment.Properties.AppearanceReadOnly.Image")));
            this.memoComment.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.memoComment.Properties.NullValuePrompt = resources.GetString("memoComment.Properties.NullValuePrompt");
            this.memoComment.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("memoComment.Properties.NullValuePromptShowForEmptyValue")));
            this.memoComment.UseOptimizedRendering = true;
            // 
            // gcAnimalsData
            // 
            resources.ApplyResources(this.gcAnimalsData, "gcAnimalsData");
            this.gcAnimalsData.Appearance.FontSizeDelta = ((int)(resources.GetObject("gcAnimalsData.Appearance.FontSizeDelta")));
            this.gcAnimalsData.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("gcAnimalsData.Appearance.FontStyleDelta")));
            this.gcAnimalsData.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("gcAnimalsData.Appearance.GradientMode")));
            this.gcAnimalsData.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("gcAnimalsData.Appearance.Image")));
            this.gcAnimalsData.Appearance.Options.UseFont = true;
            this.gcAnimalsData.AppearanceCaption.FontSizeDelta = ((int)(resources.GetObject("gcAnimalsData.AppearanceCaption.FontSizeDelta")));
            this.gcAnimalsData.AppearanceCaption.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("gcAnimalsData.AppearanceCaption.FontStyleDelta")));
            this.gcAnimalsData.AppearanceCaption.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("gcAnimalsData.AppearanceCaption.GradientMode")));
            this.gcAnimalsData.AppearanceCaption.Image = ((System.Drawing.Image)(resources.GetObject("gcAnimalsData.AppearanceCaption.Image")));
            this.gcAnimalsData.AppearanceCaption.Options.UseFont = true;
            this.gcAnimalsData.Controls.Add(this.seQuantity);
            this.gcAnimalsData.Controls.Add(this.dtIdentificationDate);
            this.gcAnimalsData.Controls.Add(this.leIdentificationMethod);
            this.gcAnimalsData.Controls.Add(this.leIdentifiedBy);
            this.gcAnimalsData.Controls.Add(this.leSex);
            this.gcAnimalsData.Controls.Add(this.leIdentifiedByInstitution);
            this.gcAnimalsData.Controls.Add(this.leSpecies);
            this.gcAnimalsData.Controls.Add(this.lblSpecie);
            this.gcAnimalsData.Controls.Add(this.lblIdentificationDate);
            this.gcAnimalsData.Controls.Add(this.lblIdentificationMethod);
            this.gcAnimalsData.Controls.Add(this.lblIdentifiedBy);
            this.gcAnimalsData.Controls.Add(this.lblIdentifiedByInstitution);
            this.gcAnimalsData.Controls.Add(this.lblSex);
            this.gcAnimalsData.Controls.Add(this.lblQuantity);
            this.gcAnimalsData.Name = "gcAnimalsData";
            // 
            // seQuantity
            // 
            resources.ApplyResources(this.seQuantity, "seQuantity");
            this.seQuantity.Name = "seQuantity";
            this.seQuantity.Properties.AccessibleDescription = resources.GetString("seQuantity.Properties.AccessibleDescription");
            this.seQuantity.Properties.AccessibleName = resources.GetString("seQuantity.Properties.AccessibleName");
            this.seQuantity.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("seQuantity.Properties.Appearance.FontSizeDelta")));
            this.seQuantity.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("seQuantity.Properties.Appearance.FontStyleDelta")));
            this.seQuantity.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("seQuantity.Properties.Appearance.GradientMode")));
            this.seQuantity.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("seQuantity.Properties.Appearance.Image")));
            this.seQuantity.Properties.Appearance.Options.UseFont = true;
            this.seQuantity.Properties.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("seQuantity.Properties.AppearanceDisabled.FontSizeDelta")));
            this.seQuantity.Properties.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("seQuantity.Properties.AppearanceDisabled.FontStyleDelta")));
            this.seQuantity.Properties.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("seQuantity.Properties.AppearanceDisabled.GradientMode")));
            this.seQuantity.Properties.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("seQuantity.Properties.AppearanceDisabled.Image")));
            this.seQuantity.Properties.AppearanceDisabled.Options.UseFont = true;
            this.seQuantity.Properties.AppearanceFocused.FontSizeDelta = ((int)(resources.GetObject("seQuantity.Properties.AppearanceFocused.FontSizeDelta")));
            this.seQuantity.Properties.AppearanceFocused.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("seQuantity.Properties.AppearanceFocused.FontStyleDelta")));
            this.seQuantity.Properties.AppearanceFocused.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("seQuantity.Properties.AppearanceFocused.GradientMode")));
            this.seQuantity.Properties.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("seQuantity.Properties.AppearanceFocused.Image")));
            this.seQuantity.Properties.AppearanceFocused.Options.UseFont = true;
            this.seQuantity.Properties.AppearanceReadOnly.FontSizeDelta = ((int)(resources.GetObject("seQuantity.Properties.AppearanceReadOnly.FontSizeDelta")));
            this.seQuantity.Properties.AppearanceReadOnly.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("seQuantity.Properties.AppearanceReadOnly.FontStyleDelta")));
            this.seQuantity.Properties.AppearanceReadOnly.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("seQuantity.Properties.AppearanceReadOnly.GradientMode")));
            this.seQuantity.Properties.AppearanceReadOnly.Image = ((System.Drawing.Image)(resources.GetObject("seQuantity.Properties.AppearanceReadOnly.Image")));
            this.seQuantity.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.seQuantity.Properties.AutoHeight = ((bool)(resources.GetObject("seQuantity.Properties.AutoHeight")));
            resources.ApplyResources(serializableAppearanceObject1, "serializableAppearanceObject1");
            serializableAppearanceObject1.Options.UseFont = true;
            this.seQuantity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("seQuantity.Properties.Buttons"))), resources.GetString("seQuantity.Properties.Buttons1"), ((int)(resources.GetObject("seQuantity.Properties.Buttons2"))), ((bool)(resources.GetObject("seQuantity.Properties.Buttons3"))), ((bool)(resources.GetObject("seQuantity.Properties.Buttons4"))), ((bool)(resources.GetObject("seQuantity.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("seQuantity.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("seQuantity.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, resources.GetString("seQuantity.Properties.Buttons8"), ((object)(resources.GetObject("seQuantity.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("seQuantity.Properties.Buttons10"))), ((bool)(resources.GetObject("seQuantity.Properties.Buttons11"))))});
            this.seQuantity.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("seQuantity.Properties.Mask.AutoComplete")));
            this.seQuantity.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("seQuantity.Properties.Mask.BeepOnError")));
            this.seQuantity.Properties.Mask.EditMask = resources.GetString("seQuantity.Properties.Mask.EditMask");
            this.seQuantity.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("seQuantity.Properties.Mask.IgnoreMaskBlank")));
            this.seQuantity.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("seQuantity.Properties.Mask.MaskType")));
            this.seQuantity.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("seQuantity.Properties.Mask.PlaceHolder")));
            this.seQuantity.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("seQuantity.Properties.Mask.SaveLiteral")));
            this.seQuantity.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("seQuantity.Properties.Mask.ShowPlaceHolders")));
            this.seQuantity.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("seQuantity.Properties.Mask.UseMaskAsDisplayFormat")));
            this.seQuantity.Properties.NullValuePrompt = resources.GetString("seQuantity.Properties.NullValuePrompt");
            this.seQuantity.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("seQuantity.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // dtIdentificationDate
            // 
            resources.ApplyResources(this.dtIdentificationDate, "dtIdentificationDate");
            this.dtIdentificationDate.Name = "dtIdentificationDate";
            this.dtIdentificationDate.Properties.AccessibleDescription = resources.GetString("dtIdentificationDate.Properties.AccessibleDescription");
            this.dtIdentificationDate.Properties.AccessibleName = resources.GetString("dtIdentificationDate.Properties.AccessibleName");
            this.dtIdentificationDate.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("dtIdentificationDate.Properties.Appearance.FontSizeDelta")));
            this.dtIdentificationDate.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("dtIdentificationDate.Properties.Appearance.FontStyleDelta")));
            this.dtIdentificationDate.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("dtIdentificationDate.Properties.Appearance.GradientMode")));
            this.dtIdentificationDate.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("dtIdentificationDate.Properties.Appearance.Image")));
            this.dtIdentificationDate.Properties.Appearance.Options.UseFont = true;
            this.dtIdentificationDate.Properties.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("dtIdentificationDate.Properties.AppearanceDisabled.FontSizeDelta")));
            this.dtIdentificationDate.Properties.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("dtIdentificationDate.Properties.AppearanceDisabled.FontStyleDelta")));
            this.dtIdentificationDate.Properties.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("dtIdentificationDate.Properties.AppearanceDisabled.GradientMode")));
            this.dtIdentificationDate.Properties.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("dtIdentificationDate.Properties.AppearanceDisabled.Image")));
            this.dtIdentificationDate.Properties.AppearanceDisabled.Options.UseFont = true;
            this.dtIdentificationDate.Properties.AppearanceDropDown.FontSizeDelta = ((int)(resources.GetObject("dtIdentificationDate.Properties.AppearanceDropDown.FontSizeDelta")));
            this.dtIdentificationDate.Properties.AppearanceDropDown.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("dtIdentificationDate.Properties.AppearanceDropDown.FontStyleDelta")));
            this.dtIdentificationDate.Properties.AppearanceDropDown.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("dtIdentificationDate.Properties.AppearanceDropDown.GradientMode")));
            this.dtIdentificationDate.Properties.AppearanceDropDown.Image = ((System.Drawing.Image)(resources.GetObject("dtIdentificationDate.Properties.AppearanceDropDown.Image")));
            this.dtIdentificationDate.Properties.AppearanceDropDown.Options.UseFont = true;
            this.dtIdentificationDate.Properties.AppearanceDropDownHeader.FontSizeDelta = ((int)(resources.GetObject("dtIdentificationDate.Properties.AppearanceDropDownHeader.FontSizeDelta")));
            this.dtIdentificationDate.Properties.AppearanceDropDownHeader.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("dtIdentificationDate.Properties.AppearanceDropDownHeader.FontStyleDelta")));
            this.dtIdentificationDate.Properties.AppearanceDropDownHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("dtIdentificationDate.Properties.AppearanceDropDownHeader.GradientMode")));
            this.dtIdentificationDate.Properties.AppearanceDropDownHeader.Image = ((System.Drawing.Image)(resources.GetObject("dtIdentificationDate.Properties.AppearanceDropDownHeader.Image")));
            this.dtIdentificationDate.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.dtIdentificationDate.Properties.AppearanceDropDownHeaderHighlight.FontSizeDelta = ((int)(resources.GetObject("dtIdentificationDate.Properties.AppearanceDropDownHeaderHighlight.FontSizeDelta")));
            this.dtIdentificationDate.Properties.AppearanceDropDownHeaderHighlight.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("dtIdentificationDate.Properties.AppearanceDropDownHeaderHighlight.FontStyleDelta")));
            this.dtIdentificationDate.Properties.AppearanceDropDownHeaderHighlight.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("dtIdentificationDate.Properties.AppearanceDropDownHeaderHighlight.GradientMode")));
            this.dtIdentificationDate.Properties.AppearanceDropDownHeaderHighlight.Image = ((System.Drawing.Image)(resources.GetObject("dtIdentificationDate.Properties.AppearanceDropDownHeaderHighlight.Image")));
            this.dtIdentificationDate.Properties.AppearanceDropDownHeaderHighlight.Options.UseFont = true;
            this.dtIdentificationDate.Properties.AppearanceDropDownHighlight.FontSizeDelta = ((int)(resources.GetObject("dtIdentificationDate.Properties.AppearanceDropDownHighlight.FontSizeDelta")));
            this.dtIdentificationDate.Properties.AppearanceDropDownHighlight.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("dtIdentificationDate.Properties.AppearanceDropDownHighlight.FontStyleDelta")));
            this.dtIdentificationDate.Properties.AppearanceDropDownHighlight.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("dtIdentificationDate.Properties.AppearanceDropDownHighlight.GradientMode")));
            this.dtIdentificationDate.Properties.AppearanceDropDownHighlight.Image = ((System.Drawing.Image)(resources.GetObject("dtIdentificationDate.Properties.AppearanceDropDownHighlight.Image")));
            this.dtIdentificationDate.Properties.AppearanceDropDownHighlight.Options.UseFont = true;
            this.dtIdentificationDate.Properties.AppearanceFocused.FontSizeDelta = ((int)(resources.GetObject("dtIdentificationDate.Properties.AppearanceFocused.FontSizeDelta")));
            this.dtIdentificationDate.Properties.AppearanceFocused.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("dtIdentificationDate.Properties.AppearanceFocused.FontStyleDelta")));
            this.dtIdentificationDate.Properties.AppearanceFocused.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("dtIdentificationDate.Properties.AppearanceFocused.GradientMode")));
            this.dtIdentificationDate.Properties.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("dtIdentificationDate.Properties.AppearanceFocused.Image")));
            this.dtIdentificationDate.Properties.AppearanceFocused.Options.UseFont = true;
            this.dtIdentificationDate.Properties.AppearanceReadOnly.FontSizeDelta = ((int)(resources.GetObject("dtIdentificationDate.Properties.AppearanceReadOnly.FontSizeDelta")));
            this.dtIdentificationDate.Properties.AppearanceReadOnly.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("dtIdentificationDate.Properties.AppearanceReadOnly.FontStyleDelta")));
            this.dtIdentificationDate.Properties.AppearanceReadOnly.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("dtIdentificationDate.Properties.AppearanceReadOnly.GradientMode")));
            this.dtIdentificationDate.Properties.AppearanceReadOnly.Image = ((System.Drawing.Image)(resources.GetObject("dtIdentificationDate.Properties.AppearanceReadOnly.Image")));
            this.dtIdentificationDate.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.dtIdentificationDate.Properties.AppearanceWeekNumber.FontSizeDelta = ((int)(resources.GetObject("dtIdentificationDate.Properties.AppearanceWeekNumber.FontSizeDelta")));
            this.dtIdentificationDate.Properties.AppearanceWeekNumber.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("dtIdentificationDate.Properties.AppearanceWeekNumber.FontStyleDelta")));
            this.dtIdentificationDate.Properties.AppearanceWeekNumber.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("dtIdentificationDate.Properties.AppearanceWeekNumber.GradientMode")));
            this.dtIdentificationDate.Properties.AppearanceWeekNumber.Image = ((System.Drawing.Image)(resources.GetObject("dtIdentificationDate.Properties.AppearanceWeekNumber.Image")));
            this.dtIdentificationDate.Properties.AppearanceWeekNumber.Options.UseFont = true;
            this.dtIdentificationDate.Properties.AutoHeight = ((bool)(resources.GetObject("dtIdentificationDate.Properties.AutoHeight")));
            resources.ApplyResources(serializableAppearanceObject2, "serializableAppearanceObject2");
            serializableAppearanceObject2.Options.UseFont = true;
            this.dtIdentificationDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("dtIdentificationDate.Properties.Buttons"))), resources.GetString("dtIdentificationDate.Properties.Buttons1"), ((int)(resources.GetObject("dtIdentificationDate.Properties.Buttons2"))), ((bool)(resources.GetObject("dtIdentificationDate.Properties.Buttons3"))), ((bool)(resources.GetObject("dtIdentificationDate.Properties.Buttons4"))), ((bool)(resources.GetObject("dtIdentificationDate.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("dtIdentificationDate.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("dtIdentificationDate.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, resources.GetString("dtIdentificationDate.Properties.Buttons8"), ((object)(resources.GetObject("dtIdentificationDate.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("dtIdentificationDate.Properties.Buttons10"))), ((bool)(resources.GetObject("dtIdentificationDate.Properties.Buttons11"))))});
            this.dtIdentificationDate.Properties.CalendarTimeProperties.AccessibleDescription = resources.GetString("dtIdentificationDate.Properties.CalendarTimeProperties.AccessibleDescription");
            this.dtIdentificationDate.Properties.CalendarTimeProperties.AccessibleName = resources.GetString("dtIdentificationDate.Properties.CalendarTimeProperties.AccessibleName");
            this.dtIdentificationDate.Properties.CalendarTimeProperties.Appearance.FontSizeDelta = ((int)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.Appearance.FontSizeDelta")));
            this.dtIdentificationDate.Properties.CalendarTimeProperties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.Appearance.FontStyleDelta")));
            this.dtIdentificationDate.Properties.CalendarTimeProperties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.Appearance.GradientMode")));
            this.dtIdentificationDate.Properties.CalendarTimeProperties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.Appearance.Image")));
            this.dtIdentificationDate.Properties.CalendarTimeProperties.Appearance.Options.UseFont = true;
            this.dtIdentificationDate.Properties.CalendarTimeProperties.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.AppearanceDisabled.FontSiz" +
        "eDelta")));
            this.dtIdentificationDate.Properties.CalendarTimeProperties.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.AppearanceDisabled.FontSty" +
        "leDelta")));
            this.dtIdentificationDate.Properties.CalendarTimeProperties.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.AppearanceDisabled.Gradien" +
        "tMode")));
            this.dtIdentificationDate.Properties.CalendarTimeProperties.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.AppearanceDisabled.Image")));
            this.dtIdentificationDate.Properties.CalendarTimeProperties.AppearanceDisabled.Options.UseFont = true;
            this.dtIdentificationDate.Properties.CalendarTimeProperties.AppearanceFocused.FontSizeDelta = ((int)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.AppearanceFocused.FontSize" +
        "Delta")));
            this.dtIdentificationDate.Properties.CalendarTimeProperties.AppearanceFocused.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.AppearanceFocused.FontStyl" +
        "eDelta")));
            this.dtIdentificationDate.Properties.CalendarTimeProperties.AppearanceFocused.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.AppearanceFocused.Gradient" +
        "Mode")));
            this.dtIdentificationDate.Properties.CalendarTimeProperties.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.AppearanceFocused.Image")));
            this.dtIdentificationDate.Properties.CalendarTimeProperties.AppearanceFocused.Options.UseFont = true;
            this.dtIdentificationDate.Properties.CalendarTimeProperties.AppearanceReadOnly.FontSizeDelta = ((int)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.AppearanceReadOnly.FontSiz" +
        "eDelta")));
            this.dtIdentificationDate.Properties.CalendarTimeProperties.AppearanceReadOnly.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.AppearanceReadOnly.FontSty" +
        "leDelta")));
            this.dtIdentificationDate.Properties.CalendarTimeProperties.AppearanceReadOnly.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.AppearanceReadOnly.Gradien" +
        "tMode")));
            this.dtIdentificationDate.Properties.CalendarTimeProperties.AppearanceReadOnly.Image = ((System.Drawing.Image)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.AppearanceReadOnly.Image")));
            this.dtIdentificationDate.Properties.CalendarTimeProperties.AppearanceReadOnly.Options.UseFont = true;
            this.dtIdentificationDate.Properties.CalendarTimeProperties.AutoHeight = ((bool)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.AutoHeight")));
            resources.ApplyResources(serializableAppearanceObject3, "serializableAppearanceObject3");
            serializableAppearanceObject3.Options.UseFont = true;
            this.dtIdentificationDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.Buttons"))), resources.GetString("dtIdentificationDate.Properties.CalendarTimeProperties.Buttons1"), ((int)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.Buttons2"))), ((bool)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.Buttons3"))), ((bool)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.Buttons4"))), ((bool)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, resources.GetString("dtIdentificationDate.Properties.CalendarTimeProperties.Buttons8"), ((object)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.Buttons10"))), ((bool)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.Buttons11"))))});
            this.dtIdentificationDate.Properties.CalendarTimeProperties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.Mask.AutoComplete")));
            this.dtIdentificationDate.Properties.CalendarTimeProperties.Mask.BeepOnError = ((bool)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.Mask.BeepOnError")));
            this.dtIdentificationDate.Properties.CalendarTimeProperties.Mask.EditMask = resources.GetString("dtIdentificationDate.Properties.CalendarTimeProperties.Mask.EditMask");
            this.dtIdentificationDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank")));
            this.dtIdentificationDate.Properties.CalendarTimeProperties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.Mask.MaskType")));
            this.dtIdentificationDate.Properties.CalendarTimeProperties.Mask.PlaceHolder = ((char)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.Mask.PlaceHolder")));
            this.dtIdentificationDate.Properties.CalendarTimeProperties.Mask.SaveLiteral = ((bool)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.Mask.SaveLiteral")));
            this.dtIdentificationDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders")));
            this.dtIdentificationDate.Properties.CalendarTimeProperties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.Mask.UseMaskAsDisplayForma" +
        "t")));
            this.dtIdentificationDate.Properties.CalendarTimeProperties.NullValuePrompt = resources.GetString("dtIdentificationDate.Properties.CalendarTimeProperties.NullValuePrompt");
            this.dtIdentificationDate.Properties.CalendarTimeProperties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("dtIdentificationDate.Properties.CalendarTimeProperties.NullValuePromptShowForEmpt" +
        "yValue")));
            this.dtIdentificationDate.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("dtIdentificationDate.Properties.Mask.AutoComplete")));
            this.dtIdentificationDate.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("dtIdentificationDate.Properties.Mask.BeepOnError")));
            this.dtIdentificationDate.Properties.Mask.EditMask = resources.GetString("dtIdentificationDate.Properties.Mask.EditMask");
            this.dtIdentificationDate.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("dtIdentificationDate.Properties.Mask.IgnoreMaskBlank")));
            this.dtIdentificationDate.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("dtIdentificationDate.Properties.Mask.MaskType")));
            this.dtIdentificationDate.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("dtIdentificationDate.Properties.Mask.PlaceHolder")));
            this.dtIdentificationDate.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("dtIdentificationDate.Properties.Mask.SaveLiteral")));
            this.dtIdentificationDate.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("dtIdentificationDate.Properties.Mask.ShowPlaceHolders")));
            this.dtIdentificationDate.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("dtIdentificationDate.Properties.Mask.UseMaskAsDisplayFormat")));
            this.dtIdentificationDate.Properties.NullValuePrompt = resources.GetString("dtIdentificationDate.Properties.NullValuePrompt");
            this.dtIdentificationDate.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("dtIdentificationDate.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // leIdentificationMethod
            // 
            resources.ApplyResources(this.leIdentificationMethod, "leIdentificationMethod");
            this.leIdentificationMethod.Name = "leIdentificationMethod";
            this.leIdentificationMethod.Properties.AccessibleDescription = resources.GetString("leIdentificationMethod.Properties.AccessibleDescription");
            this.leIdentificationMethod.Properties.AccessibleName = resources.GetString("leIdentificationMethod.Properties.AccessibleName");
            this.leIdentificationMethod.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("leIdentificationMethod.Properties.Appearance.FontSizeDelta")));
            this.leIdentificationMethod.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leIdentificationMethod.Properties.Appearance.FontStyleDelta")));
            this.leIdentificationMethod.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leIdentificationMethod.Properties.Appearance.GradientMode")));
            this.leIdentificationMethod.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("leIdentificationMethod.Properties.Appearance.Image")));
            this.leIdentificationMethod.Properties.Appearance.Options.UseFont = true;
            this.leIdentificationMethod.Properties.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("leIdentificationMethod.Properties.AppearanceDisabled.FontSizeDelta")));
            this.leIdentificationMethod.Properties.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leIdentificationMethod.Properties.AppearanceDisabled.FontStyleDelta")));
            this.leIdentificationMethod.Properties.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leIdentificationMethod.Properties.AppearanceDisabled.GradientMode")));
            this.leIdentificationMethod.Properties.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("leIdentificationMethod.Properties.AppearanceDisabled.Image")));
            this.leIdentificationMethod.Properties.AppearanceDisabled.Options.UseFont = true;
            this.leIdentificationMethod.Properties.AppearanceDropDown.FontSizeDelta = ((int)(resources.GetObject("leIdentificationMethod.Properties.AppearanceDropDown.FontSizeDelta")));
            this.leIdentificationMethod.Properties.AppearanceDropDown.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leIdentificationMethod.Properties.AppearanceDropDown.FontStyleDelta")));
            this.leIdentificationMethod.Properties.AppearanceDropDown.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leIdentificationMethod.Properties.AppearanceDropDown.GradientMode")));
            this.leIdentificationMethod.Properties.AppearanceDropDown.Image = ((System.Drawing.Image)(resources.GetObject("leIdentificationMethod.Properties.AppearanceDropDown.Image")));
            this.leIdentificationMethod.Properties.AppearanceDropDown.Options.UseFont = true;
            this.leIdentificationMethod.Properties.AppearanceDropDownHeader.FontSizeDelta = ((int)(resources.GetObject("leIdentificationMethod.Properties.AppearanceDropDownHeader.FontSizeDelta")));
            this.leIdentificationMethod.Properties.AppearanceDropDownHeader.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leIdentificationMethod.Properties.AppearanceDropDownHeader.FontStyleDelta")));
            this.leIdentificationMethod.Properties.AppearanceDropDownHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leIdentificationMethod.Properties.AppearanceDropDownHeader.GradientMode")));
            this.leIdentificationMethod.Properties.AppearanceDropDownHeader.Image = ((System.Drawing.Image)(resources.GetObject("leIdentificationMethod.Properties.AppearanceDropDownHeader.Image")));
            this.leIdentificationMethod.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.leIdentificationMethod.Properties.AppearanceFocused.FontSizeDelta = ((int)(resources.GetObject("leIdentificationMethod.Properties.AppearanceFocused.FontSizeDelta")));
            this.leIdentificationMethod.Properties.AppearanceFocused.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leIdentificationMethod.Properties.AppearanceFocused.FontStyleDelta")));
            this.leIdentificationMethod.Properties.AppearanceFocused.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leIdentificationMethod.Properties.AppearanceFocused.GradientMode")));
            this.leIdentificationMethod.Properties.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("leIdentificationMethod.Properties.AppearanceFocused.Image")));
            this.leIdentificationMethod.Properties.AppearanceFocused.Options.UseFont = true;
            this.leIdentificationMethod.Properties.AppearanceReadOnly.FontSizeDelta = ((int)(resources.GetObject("leIdentificationMethod.Properties.AppearanceReadOnly.FontSizeDelta")));
            this.leIdentificationMethod.Properties.AppearanceReadOnly.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leIdentificationMethod.Properties.AppearanceReadOnly.FontStyleDelta")));
            this.leIdentificationMethod.Properties.AppearanceReadOnly.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leIdentificationMethod.Properties.AppearanceReadOnly.GradientMode")));
            this.leIdentificationMethod.Properties.AppearanceReadOnly.Image = ((System.Drawing.Image)(resources.GetObject("leIdentificationMethod.Properties.AppearanceReadOnly.Image")));
            this.leIdentificationMethod.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.leIdentificationMethod.Properties.AutoHeight = ((bool)(resources.GetObject("leIdentificationMethod.Properties.AutoHeight")));
            resources.ApplyResources(serializableAppearanceObject4, "serializableAppearanceObject4");
            serializableAppearanceObject4.Options.UseFont = true;
            this.leIdentificationMethod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leIdentificationMethod.Properties.Buttons"))), resources.GetString("leIdentificationMethod.Properties.Buttons1"), ((int)(resources.GetObject("leIdentificationMethod.Properties.Buttons2"))), ((bool)(resources.GetObject("leIdentificationMethod.Properties.Buttons3"))), ((bool)(resources.GetObject("leIdentificationMethod.Properties.Buttons4"))), ((bool)(resources.GetObject("leIdentificationMethod.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("leIdentificationMethod.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("leIdentificationMethod.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, resources.GetString("leIdentificationMethod.Properties.Buttons8"), ((object)(resources.GetObject("leIdentificationMethod.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("leIdentificationMethod.Properties.Buttons10"))), ((bool)(resources.GetObject("leIdentificationMethod.Properties.Buttons11"))))});
            this.leIdentificationMethod.Properties.NullText = resources.GetString("leIdentificationMethod.Properties.NullText");
            this.leIdentificationMethod.Properties.NullValuePrompt = resources.GetString("leIdentificationMethod.Properties.NullValuePrompt");
            this.leIdentificationMethod.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("leIdentificationMethod.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // leIdentifiedBy
            // 
            resources.ApplyResources(this.leIdentifiedBy, "leIdentifiedBy");
            this.leIdentifiedBy.Name = "leIdentifiedBy";
            this.leIdentifiedBy.Properties.AccessibleDescription = resources.GetString("leIdentifiedBy.Properties.AccessibleDescription");
            this.leIdentifiedBy.Properties.AccessibleName = resources.GetString("leIdentifiedBy.Properties.AccessibleName");
            this.leIdentifiedBy.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("leIdentifiedBy.Properties.Appearance.FontSizeDelta")));
            this.leIdentifiedBy.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leIdentifiedBy.Properties.Appearance.FontStyleDelta")));
            this.leIdentifiedBy.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leIdentifiedBy.Properties.Appearance.GradientMode")));
            this.leIdentifiedBy.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("leIdentifiedBy.Properties.Appearance.Image")));
            this.leIdentifiedBy.Properties.Appearance.Options.UseFont = true;
            this.leIdentifiedBy.Properties.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("leIdentifiedBy.Properties.AppearanceDisabled.FontSizeDelta")));
            this.leIdentifiedBy.Properties.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leIdentifiedBy.Properties.AppearanceDisabled.FontStyleDelta")));
            this.leIdentifiedBy.Properties.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leIdentifiedBy.Properties.AppearanceDisabled.GradientMode")));
            this.leIdentifiedBy.Properties.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("leIdentifiedBy.Properties.AppearanceDisabled.Image")));
            this.leIdentifiedBy.Properties.AppearanceDisabled.Options.UseFont = true;
            this.leIdentifiedBy.Properties.AppearanceDropDown.FontSizeDelta = ((int)(resources.GetObject("leIdentifiedBy.Properties.AppearanceDropDown.FontSizeDelta")));
            this.leIdentifiedBy.Properties.AppearanceDropDown.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leIdentifiedBy.Properties.AppearanceDropDown.FontStyleDelta")));
            this.leIdentifiedBy.Properties.AppearanceDropDown.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leIdentifiedBy.Properties.AppearanceDropDown.GradientMode")));
            this.leIdentifiedBy.Properties.AppearanceDropDown.Image = ((System.Drawing.Image)(resources.GetObject("leIdentifiedBy.Properties.AppearanceDropDown.Image")));
            this.leIdentifiedBy.Properties.AppearanceDropDown.Options.UseFont = true;
            this.leIdentifiedBy.Properties.AppearanceDropDownHeader.FontSizeDelta = ((int)(resources.GetObject("leIdentifiedBy.Properties.AppearanceDropDownHeader.FontSizeDelta")));
            this.leIdentifiedBy.Properties.AppearanceDropDownHeader.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leIdentifiedBy.Properties.AppearanceDropDownHeader.FontStyleDelta")));
            this.leIdentifiedBy.Properties.AppearanceDropDownHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leIdentifiedBy.Properties.AppearanceDropDownHeader.GradientMode")));
            this.leIdentifiedBy.Properties.AppearanceDropDownHeader.Image = ((System.Drawing.Image)(resources.GetObject("leIdentifiedBy.Properties.AppearanceDropDownHeader.Image")));
            this.leIdentifiedBy.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.leIdentifiedBy.Properties.AppearanceFocused.FontSizeDelta = ((int)(resources.GetObject("leIdentifiedBy.Properties.AppearanceFocused.FontSizeDelta")));
            this.leIdentifiedBy.Properties.AppearanceFocused.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leIdentifiedBy.Properties.AppearanceFocused.FontStyleDelta")));
            this.leIdentifiedBy.Properties.AppearanceFocused.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leIdentifiedBy.Properties.AppearanceFocused.GradientMode")));
            this.leIdentifiedBy.Properties.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("leIdentifiedBy.Properties.AppearanceFocused.Image")));
            this.leIdentifiedBy.Properties.AppearanceFocused.Options.UseFont = true;
            this.leIdentifiedBy.Properties.AppearanceReadOnly.FontSizeDelta = ((int)(resources.GetObject("leIdentifiedBy.Properties.AppearanceReadOnly.FontSizeDelta")));
            this.leIdentifiedBy.Properties.AppearanceReadOnly.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leIdentifiedBy.Properties.AppearanceReadOnly.FontStyleDelta")));
            this.leIdentifiedBy.Properties.AppearanceReadOnly.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leIdentifiedBy.Properties.AppearanceReadOnly.GradientMode")));
            this.leIdentifiedBy.Properties.AppearanceReadOnly.Image = ((System.Drawing.Image)(resources.GetObject("leIdentifiedBy.Properties.AppearanceReadOnly.Image")));
            this.leIdentifiedBy.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.leIdentifiedBy.Properties.AutoHeight = ((bool)(resources.GetObject("leIdentifiedBy.Properties.AutoHeight")));
            resources.ApplyResources(serializableAppearanceObject5, "serializableAppearanceObject5");
            serializableAppearanceObject5.Options.UseFont = true;
            this.leIdentifiedBy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leIdentifiedBy.Properties.Buttons"))), resources.GetString("leIdentifiedBy.Properties.Buttons1"), ((int)(resources.GetObject("leIdentifiedBy.Properties.Buttons2"))), ((bool)(resources.GetObject("leIdentifiedBy.Properties.Buttons3"))), ((bool)(resources.GetObject("leIdentifiedBy.Properties.Buttons4"))), ((bool)(resources.GetObject("leIdentifiedBy.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("leIdentifiedBy.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("leIdentifiedBy.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, resources.GetString("leIdentifiedBy.Properties.Buttons8"), ((object)(resources.GetObject("leIdentifiedBy.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("leIdentifiedBy.Properties.Buttons10"))), ((bool)(resources.GetObject("leIdentifiedBy.Properties.Buttons11"))))});
            this.leIdentifiedBy.Properties.NullText = resources.GetString("leIdentifiedBy.Properties.NullText");
            this.leIdentifiedBy.Properties.NullValuePrompt = resources.GetString("leIdentifiedBy.Properties.NullValuePrompt");
            this.leIdentifiedBy.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("leIdentifiedBy.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // leSex
            // 
            resources.ApplyResources(this.leSex, "leSex");
            this.leSex.Name = "leSex";
            this.leSex.Properties.AccessibleDescription = resources.GetString("leSex.Properties.AccessibleDescription");
            this.leSex.Properties.AccessibleName = resources.GetString("leSex.Properties.AccessibleName");
            this.leSex.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("leSex.Properties.Appearance.FontSizeDelta")));
            this.leSex.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leSex.Properties.Appearance.FontStyleDelta")));
            this.leSex.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leSex.Properties.Appearance.GradientMode")));
            this.leSex.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("leSex.Properties.Appearance.Image")));
            this.leSex.Properties.Appearance.Options.UseFont = true;
            this.leSex.Properties.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("leSex.Properties.AppearanceDisabled.FontSizeDelta")));
            this.leSex.Properties.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leSex.Properties.AppearanceDisabled.FontStyleDelta")));
            this.leSex.Properties.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leSex.Properties.AppearanceDisabled.GradientMode")));
            this.leSex.Properties.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("leSex.Properties.AppearanceDisabled.Image")));
            this.leSex.Properties.AppearanceDisabled.Options.UseFont = true;
            this.leSex.Properties.AppearanceDropDown.FontSizeDelta = ((int)(resources.GetObject("leSex.Properties.AppearanceDropDown.FontSizeDelta")));
            this.leSex.Properties.AppearanceDropDown.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leSex.Properties.AppearanceDropDown.FontStyleDelta")));
            this.leSex.Properties.AppearanceDropDown.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leSex.Properties.AppearanceDropDown.GradientMode")));
            this.leSex.Properties.AppearanceDropDown.Image = ((System.Drawing.Image)(resources.GetObject("leSex.Properties.AppearanceDropDown.Image")));
            this.leSex.Properties.AppearanceDropDown.Options.UseFont = true;
            this.leSex.Properties.AppearanceDropDownHeader.FontSizeDelta = ((int)(resources.GetObject("leSex.Properties.AppearanceDropDownHeader.FontSizeDelta")));
            this.leSex.Properties.AppearanceDropDownHeader.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leSex.Properties.AppearanceDropDownHeader.FontStyleDelta")));
            this.leSex.Properties.AppearanceDropDownHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leSex.Properties.AppearanceDropDownHeader.GradientMode")));
            this.leSex.Properties.AppearanceDropDownHeader.Image = ((System.Drawing.Image)(resources.GetObject("leSex.Properties.AppearanceDropDownHeader.Image")));
            this.leSex.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.leSex.Properties.AppearanceFocused.FontSizeDelta = ((int)(resources.GetObject("leSex.Properties.AppearanceFocused.FontSizeDelta")));
            this.leSex.Properties.AppearanceFocused.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leSex.Properties.AppearanceFocused.FontStyleDelta")));
            this.leSex.Properties.AppearanceFocused.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leSex.Properties.AppearanceFocused.GradientMode")));
            this.leSex.Properties.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("leSex.Properties.AppearanceFocused.Image")));
            this.leSex.Properties.AppearanceFocused.Options.UseFont = true;
            this.leSex.Properties.AppearanceReadOnly.FontSizeDelta = ((int)(resources.GetObject("leSex.Properties.AppearanceReadOnly.FontSizeDelta")));
            this.leSex.Properties.AppearanceReadOnly.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leSex.Properties.AppearanceReadOnly.FontStyleDelta")));
            this.leSex.Properties.AppearanceReadOnly.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leSex.Properties.AppearanceReadOnly.GradientMode")));
            this.leSex.Properties.AppearanceReadOnly.Image = ((System.Drawing.Image)(resources.GetObject("leSex.Properties.AppearanceReadOnly.Image")));
            this.leSex.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.leSex.Properties.AutoHeight = ((bool)(resources.GetObject("leSex.Properties.AutoHeight")));
            resources.ApplyResources(serializableAppearanceObject6, "serializableAppearanceObject6");
            serializableAppearanceObject6.Options.UseFont = true;
            this.leSex.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leSex.Properties.Buttons"))), resources.GetString("leSex.Properties.Buttons1"), ((int)(resources.GetObject("leSex.Properties.Buttons2"))), ((bool)(resources.GetObject("leSex.Properties.Buttons3"))), ((bool)(resources.GetObject("leSex.Properties.Buttons4"))), ((bool)(resources.GetObject("leSex.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("leSex.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("leSex.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, resources.GetString("leSex.Properties.Buttons8"), ((object)(resources.GetObject("leSex.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("leSex.Properties.Buttons10"))), ((bool)(resources.GetObject("leSex.Properties.Buttons11"))))});
            this.leSex.Properties.NullText = resources.GetString("leSex.Properties.NullText");
            this.leSex.Properties.NullValuePrompt = resources.GetString("leSex.Properties.NullValuePrompt");
            this.leSex.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("leSex.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // leIdentifiedByInstitution
            // 
            resources.ApplyResources(this.leIdentifiedByInstitution, "leIdentifiedByInstitution");
            this.leIdentifiedByInstitution.Name = "leIdentifiedByInstitution";
            this.leIdentifiedByInstitution.Properties.AccessibleDescription = resources.GetString("leIdentifiedByInstitution.Properties.AccessibleDescription");
            this.leIdentifiedByInstitution.Properties.AccessibleName = resources.GetString("leIdentifiedByInstitution.Properties.AccessibleName");
            this.leIdentifiedByInstitution.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("leIdentifiedByInstitution.Properties.Appearance.FontSizeDelta")));
            this.leIdentifiedByInstitution.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leIdentifiedByInstitution.Properties.Appearance.FontStyleDelta")));
            this.leIdentifiedByInstitution.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leIdentifiedByInstitution.Properties.Appearance.GradientMode")));
            this.leIdentifiedByInstitution.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("leIdentifiedByInstitution.Properties.Appearance.Image")));
            this.leIdentifiedByInstitution.Properties.Appearance.Options.UseFont = true;
            this.leIdentifiedByInstitution.Properties.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("leIdentifiedByInstitution.Properties.AppearanceDisabled.FontSizeDelta")));
            this.leIdentifiedByInstitution.Properties.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leIdentifiedByInstitution.Properties.AppearanceDisabled.FontStyleDelta")));
            this.leIdentifiedByInstitution.Properties.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leIdentifiedByInstitution.Properties.AppearanceDisabled.GradientMode")));
            this.leIdentifiedByInstitution.Properties.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("leIdentifiedByInstitution.Properties.AppearanceDisabled.Image")));
            this.leIdentifiedByInstitution.Properties.AppearanceDisabled.Options.UseFont = true;
            this.leIdentifiedByInstitution.Properties.AppearanceDropDown.FontSizeDelta = ((int)(resources.GetObject("leIdentifiedByInstitution.Properties.AppearanceDropDown.FontSizeDelta")));
            this.leIdentifiedByInstitution.Properties.AppearanceDropDown.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leIdentifiedByInstitution.Properties.AppearanceDropDown.FontStyleDelta")));
            this.leIdentifiedByInstitution.Properties.AppearanceDropDown.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leIdentifiedByInstitution.Properties.AppearanceDropDown.GradientMode")));
            this.leIdentifiedByInstitution.Properties.AppearanceDropDown.Image = ((System.Drawing.Image)(resources.GetObject("leIdentifiedByInstitution.Properties.AppearanceDropDown.Image")));
            this.leIdentifiedByInstitution.Properties.AppearanceDropDown.Options.UseFont = true;
            this.leIdentifiedByInstitution.Properties.AppearanceDropDownHeader.FontSizeDelta = ((int)(resources.GetObject("leIdentifiedByInstitution.Properties.AppearanceDropDownHeader.FontSizeDelta")));
            this.leIdentifiedByInstitution.Properties.AppearanceDropDownHeader.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leIdentifiedByInstitution.Properties.AppearanceDropDownHeader.FontStyleDelta")));
            this.leIdentifiedByInstitution.Properties.AppearanceDropDownHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leIdentifiedByInstitution.Properties.AppearanceDropDownHeader.GradientMode")));
            this.leIdentifiedByInstitution.Properties.AppearanceDropDownHeader.Image = ((System.Drawing.Image)(resources.GetObject("leIdentifiedByInstitution.Properties.AppearanceDropDownHeader.Image")));
            this.leIdentifiedByInstitution.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.leIdentifiedByInstitution.Properties.AppearanceFocused.FontSizeDelta = ((int)(resources.GetObject("leIdentifiedByInstitution.Properties.AppearanceFocused.FontSizeDelta")));
            this.leIdentifiedByInstitution.Properties.AppearanceFocused.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leIdentifiedByInstitution.Properties.AppearanceFocused.FontStyleDelta")));
            this.leIdentifiedByInstitution.Properties.AppearanceFocused.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leIdentifiedByInstitution.Properties.AppearanceFocused.GradientMode")));
            this.leIdentifiedByInstitution.Properties.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("leIdentifiedByInstitution.Properties.AppearanceFocused.Image")));
            this.leIdentifiedByInstitution.Properties.AppearanceFocused.Options.UseFont = true;
            this.leIdentifiedByInstitution.Properties.AppearanceReadOnly.FontSizeDelta = ((int)(resources.GetObject("leIdentifiedByInstitution.Properties.AppearanceReadOnly.FontSizeDelta")));
            this.leIdentifiedByInstitution.Properties.AppearanceReadOnly.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leIdentifiedByInstitution.Properties.AppearanceReadOnly.FontStyleDelta")));
            this.leIdentifiedByInstitution.Properties.AppearanceReadOnly.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leIdentifiedByInstitution.Properties.AppearanceReadOnly.GradientMode")));
            this.leIdentifiedByInstitution.Properties.AppearanceReadOnly.Image = ((System.Drawing.Image)(resources.GetObject("leIdentifiedByInstitution.Properties.AppearanceReadOnly.Image")));
            this.leIdentifiedByInstitution.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.leIdentifiedByInstitution.Properties.AutoHeight = ((bool)(resources.GetObject("leIdentifiedByInstitution.Properties.AutoHeight")));
            resources.ApplyResources(serializableAppearanceObject7, "serializableAppearanceObject7");
            serializableAppearanceObject7.Options.UseFont = true;
            this.leIdentifiedByInstitution.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leIdentifiedByInstitution.Properties.Buttons"))), resources.GetString("leIdentifiedByInstitution.Properties.Buttons1"), ((int)(resources.GetObject("leIdentifiedByInstitution.Properties.Buttons2"))), ((bool)(resources.GetObject("leIdentifiedByInstitution.Properties.Buttons3"))), ((bool)(resources.GetObject("leIdentifiedByInstitution.Properties.Buttons4"))), ((bool)(resources.GetObject("leIdentifiedByInstitution.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("leIdentifiedByInstitution.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("leIdentifiedByInstitution.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7, resources.GetString("leIdentifiedByInstitution.Properties.Buttons8"), ((object)(resources.GetObject("leIdentifiedByInstitution.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("leIdentifiedByInstitution.Properties.Buttons10"))), ((bool)(resources.GetObject("leIdentifiedByInstitution.Properties.Buttons11"))))});
            this.leIdentifiedByInstitution.Properties.NullText = resources.GetString("leIdentifiedByInstitution.Properties.NullText");
            this.leIdentifiedByInstitution.Properties.NullValuePrompt = resources.GetString("leIdentifiedByInstitution.Properties.NullValuePrompt");
            this.leIdentifiedByInstitution.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("leIdentifiedByInstitution.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // leSpecies
            // 
            resources.ApplyResources(this.leSpecies, "leSpecies");
            this.leSpecies.Name = "leSpecies";
            this.leSpecies.Properties.AccessibleDescription = resources.GetString("leSpecies.Properties.AccessibleDescription");
            this.leSpecies.Properties.AccessibleName = resources.GetString("leSpecies.Properties.AccessibleName");
            this.leSpecies.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("leSpecies.Properties.Appearance.FontSizeDelta")));
            this.leSpecies.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leSpecies.Properties.Appearance.FontStyleDelta")));
            this.leSpecies.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leSpecies.Properties.Appearance.GradientMode")));
            this.leSpecies.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("leSpecies.Properties.Appearance.Image")));
            this.leSpecies.Properties.Appearance.Options.UseFont = true;
            this.leSpecies.Properties.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("leSpecies.Properties.AppearanceDisabled.FontSizeDelta")));
            this.leSpecies.Properties.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leSpecies.Properties.AppearanceDisabled.FontStyleDelta")));
            this.leSpecies.Properties.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leSpecies.Properties.AppearanceDisabled.GradientMode")));
            this.leSpecies.Properties.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("leSpecies.Properties.AppearanceDisabled.Image")));
            this.leSpecies.Properties.AppearanceDisabled.Options.UseFont = true;
            this.leSpecies.Properties.AppearanceDropDown.FontSizeDelta = ((int)(resources.GetObject("leSpecies.Properties.AppearanceDropDown.FontSizeDelta")));
            this.leSpecies.Properties.AppearanceDropDown.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leSpecies.Properties.AppearanceDropDown.FontStyleDelta")));
            this.leSpecies.Properties.AppearanceDropDown.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leSpecies.Properties.AppearanceDropDown.GradientMode")));
            this.leSpecies.Properties.AppearanceDropDown.Image = ((System.Drawing.Image)(resources.GetObject("leSpecies.Properties.AppearanceDropDown.Image")));
            this.leSpecies.Properties.AppearanceDropDown.Options.UseFont = true;
            this.leSpecies.Properties.AppearanceDropDownHeader.FontSizeDelta = ((int)(resources.GetObject("leSpecies.Properties.AppearanceDropDownHeader.FontSizeDelta")));
            this.leSpecies.Properties.AppearanceDropDownHeader.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leSpecies.Properties.AppearanceDropDownHeader.FontStyleDelta")));
            this.leSpecies.Properties.AppearanceDropDownHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leSpecies.Properties.AppearanceDropDownHeader.GradientMode")));
            this.leSpecies.Properties.AppearanceDropDownHeader.Image = ((System.Drawing.Image)(resources.GetObject("leSpecies.Properties.AppearanceDropDownHeader.Image")));
            this.leSpecies.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.leSpecies.Properties.AppearanceFocused.FontSizeDelta = ((int)(resources.GetObject("leSpecies.Properties.AppearanceFocused.FontSizeDelta")));
            this.leSpecies.Properties.AppearanceFocused.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leSpecies.Properties.AppearanceFocused.FontStyleDelta")));
            this.leSpecies.Properties.AppearanceFocused.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leSpecies.Properties.AppearanceFocused.GradientMode")));
            this.leSpecies.Properties.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("leSpecies.Properties.AppearanceFocused.Image")));
            this.leSpecies.Properties.AppearanceFocused.Options.UseFont = true;
            this.leSpecies.Properties.AppearanceReadOnly.FontSizeDelta = ((int)(resources.GetObject("leSpecies.Properties.AppearanceReadOnly.FontSizeDelta")));
            this.leSpecies.Properties.AppearanceReadOnly.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leSpecies.Properties.AppearanceReadOnly.FontStyleDelta")));
            this.leSpecies.Properties.AppearanceReadOnly.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leSpecies.Properties.AppearanceReadOnly.GradientMode")));
            this.leSpecies.Properties.AppearanceReadOnly.Image = ((System.Drawing.Image)(resources.GetObject("leSpecies.Properties.AppearanceReadOnly.Image")));
            this.leSpecies.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.leSpecies.Properties.AutoHeight = ((bool)(resources.GetObject("leSpecies.Properties.AutoHeight")));
            resources.ApplyResources(serializableAppearanceObject8, "serializableAppearanceObject8");
            serializableAppearanceObject8.Options.UseFont = true;
            this.leSpecies.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leSpecies.Properties.Buttons"))), resources.GetString("leSpecies.Properties.Buttons1"), ((int)(resources.GetObject("leSpecies.Properties.Buttons2"))), ((bool)(resources.GetObject("leSpecies.Properties.Buttons3"))), ((bool)(resources.GetObject("leSpecies.Properties.Buttons4"))), ((bool)(resources.GetObject("leSpecies.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("leSpecies.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("leSpecies.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8, resources.GetString("leSpecies.Properties.Buttons8"), ((object)(resources.GetObject("leSpecies.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("leSpecies.Properties.Buttons10"))), ((bool)(resources.GetObject("leSpecies.Properties.Buttons11"))))});
            this.leSpecies.Properties.NullText = resources.GetString("leSpecies.Properties.NullText");
            this.leSpecies.Properties.NullValuePrompt = resources.GetString("leSpecies.Properties.NullValuePrompt");
            this.leSpecies.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("leSpecies.Properties.NullValuePromptShowForEmptyValue")));
            this.leSpecies.EditValueChanged += new System.EventHandler(this.OnleVectorTypeSubTypeEditValueChanged);
            // 
            // lblSpecie
            // 
            resources.ApplyResources(this.lblSpecie, "lblSpecie");
            this.lblSpecie.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblSpecie.Appearance.DisabledImage")));
            this.lblSpecie.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblSpecie.Appearance.FontSizeDelta")));
            this.lblSpecie.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblSpecie.Appearance.FontStyleDelta")));
            this.lblSpecie.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblSpecie.Appearance.GradientMode")));
            this.lblSpecie.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblSpecie.Appearance.HoverImage")));
            this.lblSpecie.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblSpecie.Appearance.Image")));
            this.lblSpecie.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblSpecie.Appearance.PressedImage")));
            this.lblSpecie.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblSpecie.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblSpecie.Name = "lblSpecie";
            // 
            // lblIdentificationDate
            // 
            resources.ApplyResources(this.lblIdentificationDate, "lblIdentificationDate");
            this.lblIdentificationDate.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblIdentificationDate.Appearance.DisabledImage")));
            this.lblIdentificationDate.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblIdentificationDate.Appearance.FontSizeDelta")));
            this.lblIdentificationDate.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblIdentificationDate.Appearance.FontStyleDelta")));
            this.lblIdentificationDate.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblIdentificationDate.Appearance.GradientMode")));
            this.lblIdentificationDate.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblIdentificationDate.Appearance.HoverImage")));
            this.lblIdentificationDate.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblIdentificationDate.Appearance.Image")));
            this.lblIdentificationDate.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblIdentificationDate.Appearance.PressedImage")));
            this.lblIdentificationDate.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblIdentificationDate.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblIdentificationDate.Name = "lblIdentificationDate";
            // 
            // lblIdentificationMethod
            // 
            resources.ApplyResources(this.lblIdentificationMethod, "lblIdentificationMethod");
            this.lblIdentificationMethod.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblIdentificationMethod.Appearance.DisabledImage")));
            this.lblIdentificationMethod.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblIdentificationMethod.Appearance.FontSizeDelta")));
            this.lblIdentificationMethod.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblIdentificationMethod.Appearance.FontStyleDelta")));
            this.lblIdentificationMethod.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblIdentificationMethod.Appearance.GradientMode")));
            this.lblIdentificationMethod.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblIdentificationMethod.Appearance.HoverImage")));
            this.lblIdentificationMethod.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblIdentificationMethod.Appearance.Image")));
            this.lblIdentificationMethod.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblIdentificationMethod.Appearance.PressedImage")));
            this.lblIdentificationMethod.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblIdentificationMethod.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblIdentificationMethod.Name = "lblIdentificationMethod";
            // 
            // lblIdentifiedBy
            // 
            resources.ApplyResources(this.lblIdentifiedBy, "lblIdentifiedBy");
            this.lblIdentifiedBy.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblIdentifiedBy.Appearance.DisabledImage")));
            this.lblIdentifiedBy.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblIdentifiedBy.Appearance.FontSizeDelta")));
            this.lblIdentifiedBy.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblIdentifiedBy.Appearance.FontStyleDelta")));
            this.lblIdentifiedBy.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblIdentifiedBy.Appearance.GradientMode")));
            this.lblIdentifiedBy.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblIdentifiedBy.Appearance.HoverImage")));
            this.lblIdentifiedBy.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblIdentifiedBy.Appearance.Image")));
            this.lblIdentifiedBy.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblIdentifiedBy.Appearance.PressedImage")));
            this.lblIdentifiedBy.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblIdentifiedBy.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblIdentifiedBy.Name = "lblIdentifiedBy";
            // 
            // lblIdentifiedByInstitution
            // 
            resources.ApplyResources(this.lblIdentifiedByInstitution, "lblIdentifiedByInstitution");
            this.lblIdentifiedByInstitution.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblIdentifiedByInstitution.Appearance.DisabledImage")));
            this.lblIdentifiedByInstitution.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblIdentifiedByInstitution.Appearance.FontSizeDelta")));
            this.lblIdentifiedByInstitution.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblIdentifiedByInstitution.Appearance.FontStyleDelta")));
            this.lblIdentifiedByInstitution.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblIdentifiedByInstitution.Appearance.GradientMode")));
            this.lblIdentifiedByInstitution.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblIdentifiedByInstitution.Appearance.HoverImage")));
            this.lblIdentifiedByInstitution.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblIdentifiedByInstitution.Appearance.Image")));
            this.lblIdentifiedByInstitution.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblIdentifiedByInstitution.Appearance.PressedImage")));
            this.lblIdentifiedByInstitution.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblIdentifiedByInstitution.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblIdentifiedByInstitution.Name = "lblIdentifiedByInstitution";
            // 
            // lblSex
            // 
            resources.ApplyResources(this.lblSex, "lblSex");
            this.lblSex.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblSex.Appearance.DisabledImage")));
            this.lblSex.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblSex.Appearance.FontSizeDelta")));
            this.lblSex.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblSex.Appearance.FontStyleDelta")));
            this.lblSex.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblSex.Appearance.GradientMode")));
            this.lblSex.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblSex.Appearance.HoverImage")));
            this.lblSex.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblSex.Appearance.Image")));
            this.lblSex.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblSex.Appearance.PressedImage")));
            this.lblSex.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblSex.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblSex.Name = "lblSex";
            // 
            // lblQuantity
            // 
            resources.ApplyResources(this.lblQuantity, "lblQuantity");
            this.lblQuantity.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblQuantity.Appearance.DisabledImage")));
            this.lblQuantity.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblQuantity.Appearance.FontSizeDelta")));
            this.lblQuantity.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblQuantity.Appearance.FontStyleDelta")));
            this.lblQuantity.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblQuantity.Appearance.GradientMode")));
            this.lblQuantity.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblQuantity.Appearance.HoverImage")));
            this.lblQuantity.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblQuantity.Appearance.Image")));
            this.lblQuantity.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblQuantity.Appearance.PressedImage")));
            this.lblQuantity.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblQuantity.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblQuantity.Name = "lblQuantity";
            // 
            // gcCollectionData
            // 
            resources.ApplyResources(this.gcCollectionData, "gcCollectionData");
            this.gcCollectionData.Appearance.FontSizeDelta = ((int)(resources.GetObject("gcCollectionData.Appearance.FontSizeDelta")));
            this.gcCollectionData.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("gcCollectionData.Appearance.FontStyleDelta")));
            this.gcCollectionData.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("gcCollectionData.Appearance.GradientMode")));
            this.gcCollectionData.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("gcCollectionData.Appearance.Image")));
            this.gcCollectionData.Appearance.Options.UseFont = true;
            this.gcCollectionData.AppearanceCaption.FontSizeDelta = ((int)(resources.GetObject("gcCollectionData.AppearanceCaption.FontSizeDelta")));
            this.gcCollectionData.AppearanceCaption.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("gcCollectionData.AppearanceCaption.FontStyleDelta")));
            this.gcCollectionData.AppearanceCaption.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("gcCollectionData.AppearanceCaption.GradientMode")));
            this.gcCollectionData.AppearanceCaption.Image = ((System.Drawing.Image)(resources.GetObject("gcCollectionData.AppearanceCaption.Image")));
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
            this.gcCollectionData.Name = "gcCollectionData";
            // 
            // leEctoparasitesCollected
            // 
            resources.ApplyResources(this.leEctoparasitesCollected, "leEctoparasitesCollected");
            this.leEctoparasitesCollected.Name = "leEctoparasitesCollected";
            this.leEctoparasitesCollected.Properties.AccessibleDescription = resources.GetString("leEctoparasitesCollected.Properties.AccessibleDescription");
            this.leEctoparasitesCollected.Properties.AccessibleName = resources.GetString("leEctoparasitesCollected.Properties.AccessibleName");
            this.leEctoparasitesCollected.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("leEctoparasitesCollected.Properties.Appearance.FontSizeDelta")));
            this.leEctoparasitesCollected.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leEctoparasitesCollected.Properties.Appearance.FontStyleDelta")));
            this.leEctoparasitesCollected.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leEctoparasitesCollected.Properties.Appearance.GradientMode")));
            this.leEctoparasitesCollected.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("leEctoparasitesCollected.Properties.Appearance.Image")));
            this.leEctoparasitesCollected.Properties.Appearance.Options.UseFont = true;
            this.leEctoparasitesCollected.Properties.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("leEctoparasitesCollected.Properties.AppearanceDisabled.FontSizeDelta")));
            this.leEctoparasitesCollected.Properties.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leEctoparasitesCollected.Properties.AppearanceDisabled.FontStyleDelta")));
            this.leEctoparasitesCollected.Properties.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leEctoparasitesCollected.Properties.AppearanceDisabled.GradientMode")));
            this.leEctoparasitesCollected.Properties.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("leEctoparasitesCollected.Properties.AppearanceDisabled.Image")));
            this.leEctoparasitesCollected.Properties.AppearanceDisabled.Options.UseFont = true;
            this.leEctoparasitesCollected.Properties.AppearanceDropDown.FontSizeDelta = ((int)(resources.GetObject("leEctoparasitesCollected.Properties.AppearanceDropDown.FontSizeDelta")));
            this.leEctoparasitesCollected.Properties.AppearanceDropDown.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leEctoparasitesCollected.Properties.AppearanceDropDown.FontStyleDelta")));
            this.leEctoparasitesCollected.Properties.AppearanceDropDown.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leEctoparasitesCollected.Properties.AppearanceDropDown.GradientMode")));
            this.leEctoparasitesCollected.Properties.AppearanceDropDown.Image = ((System.Drawing.Image)(resources.GetObject("leEctoparasitesCollected.Properties.AppearanceDropDown.Image")));
            this.leEctoparasitesCollected.Properties.AppearanceDropDown.Options.UseFont = true;
            this.leEctoparasitesCollected.Properties.AppearanceDropDownHeader.FontSizeDelta = ((int)(resources.GetObject("leEctoparasitesCollected.Properties.AppearanceDropDownHeader.FontSizeDelta")));
            this.leEctoparasitesCollected.Properties.AppearanceDropDownHeader.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leEctoparasitesCollected.Properties.AppearanceDropDownHeader.FontStyleDelta")));
            this.leEctoparasitesCollected.Properties.AppearanceDropDownHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leEctoparasitesCollected.Properties.AppearanceDropDownHeader.GradientMode")));
            this.leEctoparasitesCollected.Properties.AppearanceDropDownHeader.Image = ((System.Drawing.Image)(resources.GetObject("leEctoparasitesCollected.Properties.AppearanceDropDownHeader.Image")));
            this.leEctoparasitesCollected.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.leEctoparasitesCollected.Properties.AppearanceFocused.FontSizeDelta = ((int)(resources.GetObject("leEctoparasitesCollected.Properties.AppearanceFocused.FontSizeDelta")));
            this.leEctoparasitesCollected.Properties.AppearanceFocused.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leEctoparasitesCollected.Properties.AppearanceFocused.FontStyleDelta")));
            this.leEctoparasitesCollected.Properties.AppearanceFocused.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leEctoparasitesCollected.Properties.AppearanceFocused.GradientMode")));
            this.leEctoparasitesCollected.Properties.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("leEctoparasitesCollected.Properties.AppearanceFocused.Image")));
            this.leEctoparasitesCollected.Properties.AppearanceFocused.Options.UseFont = true;
            this.leEctoparasitesCollected.Properties.AppearanceReadOnly.FontSizeDelta = ((int)(resources.GetObject("leEctoparasitesCollected.Properties.AppearanceReadOnly.FontSizeDelta")));
            this.leEctoparasitesCollected.Properties.AppearanceReadOnly.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leEctoparasitesCollected.Properties.AppearanceReadOnly.FontStyleDelta")));
            this.leEctoparasitesCollected.Properties.AppearanceReadOnly.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leEctoparasitesCollected.Properties.AppearanceReadOnly.GradientMode")));
            this.leEctoparasitesCollected.Properties.AppearanceReadOnly.Image = ((System.Drawing.Image)(resources.GetObject("leEctoparasitesCollected.Properties.AppearanceReadOnly.Image")));
            this.leEctoparasitesCollected.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.leEctoparasitesCollected.Properties.AutoHeight = ((bool)(resources.GetObject("leEctoparasitesCollected.Properties.AutoHeight")));
            resources.ApplyResources(serializableAppearanceObject9, "serializableAppearanceObject9");
            serializableAppearanceObject9.Options.UseFont = true;
            this.leEctoparasitesCollected.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leEctoparasitesCollected.Properties.Buttons"))), resources.GetString("leEctoparasitesCollected.Properties.Buttons1"), ((int)(resources.GetObject("leEctoparasitesCollected.Properties.Buttons2"))), ((bool)(resources.GetObject("leEctoparasitesCollected.Properties.Buttons3"))), ((bool)(resources.GetObject("leEctoparasitesCollected.Properties.Buttons4"))), ((bool)(resources.GetObject("leEctoparasitesCollected.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("leEctoparasitesCollected.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("leEctoparasitesCollected.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, resources.GetString("leEctoparasitesCollected.Properties.Buttons8"), ((object)(resources.GetObject("leEctoparasitesCollected.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("leEctoparasitesCollected.Properties.Buttons10"))), ((bool)(resources.GetObject("leEctoparasitesCollected.Properties.Buttons11"))))});
            this.leEctoparasitesCollected.Properties.NullText = resources.GetString("leEctoparasitesCollected.Properties.NullText");
            this.leEctoparasitesCollected.Properties.NullValuePrompt = resources.GetString("leEctoparasitesCollected.Properties.NullValuePrompt");
            this.leEctoparasitesCollected.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("leEctoparasitesCollected.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // bppLocation
            // 
            resources.ApplyResources(this.bppLocation, "bppLocation");
            this.bppLocation.Name = "bppLocation";
            this.bppLocation.Properties.AccessibleDescription = resources.GetString("bppLocation.Properties.AccessibleDescription");
            this.bppLocation.Properties.AccessibleName = resources.GetString("bppLocation.Properties.AccessibleName");
            this.bppLocation.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("bppLocation.Properties.Appearance.FontSizeDelta")));
            this.bppLocation.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("bppLocation.Properties.Appearance.FontStyleDelta")));
            this.bppLocation.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("bppLocation.Properties.Appearance.GradientMode")));
            this.bppLocation.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("bppLocation.Properties.Appearance.Image")));
            this.bppLocation.Properties.Appearance.Options.UseFont = true;
            this.bppLocation.Properties.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("bppLocation.Properties.AppearanceDisabled.FontSizeDelta")));
            this.bppLocation.Properties.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("bppLocation.Properties.AppearanceDisabled.FontStyleDelta")));
            this.bppLocation.Properties.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("bppLocation.Properties.AppearanceDisabled.GradientMode")));
            this.bppLocation.Properties.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("bppLocation.Properties.AppearanceDisabled.Image")));
            this.bppLocation.Properties.AppearanceDisabled.Options.UseFont = true;
            this.bppLocation.Properties.AppearanceDropDown.FontSizeDelta = ((int)(resources.GetObject("bppLocation.Properties.AppearanceDropDown.FontSizeDelta")));
            this.bppLocation.Properties.AppearanceDropDown.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("bppLocation.Properties.AppearanceDropDown.FontStyleDelta")));
            this.bppLocation.Properties.AppearanceDropDown.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("bppLocation.Properties.AppearanceDropDown.GradientMode")));
            this.bppLocation.Properties.AppearanceDropDown.Image = ((System.Drawing.Image)(resources.GetObject("bppLocation.Properties.AppearanceDropDown.Image")));
            this.bppLocation.Properties.AppearanceDropDown.Options.UseFont = true;
            this.bppLocation.Properties.AppearanceFocused.FontSizeDelta = ((int)(resources.GetObject("bppLocation.Properties.AppearanceFocused.FontSizeDelta")));
            this.bppLocation.Properties.AppearanceFocused.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("bppLocation.Properties.AppearanceFocused.FontStyleDelta")));
            this.bppLocation.Properties.AppearanceFocused.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("bppLocation.Properties.AppearanceFocused.GradientMode")));
            this.bppLocation.Properties.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("bppLocation.Properties.AppearanceFocused.Image")));
            this.bppLocation.Properties.AppearanceFocused.Options.UseFont = true;
            this.bppLocation.Properties.AppearanceReadOnly.FontSizeDelta = ((int)(resources.GetObject("bppLocation.Properties.AppearanceReadOnly.FontSizeDelta")));
            this.bppLocation.Properties.AppearanceReadOnly.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("bppLocation.Properties.AppearanceReadOnly.FontStyleDelta")));
            this.bppLocation.Properties.AppearanceReadOnly.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("bppLocation.Properties.AppearanceReadOnly.GradientMode")));
            this.bppLocation.Properties.AppearanceReadOnly.Image = ((System.Drawing.Image)(resources.GetObject("bppLocation.Properties.AppearanceReadOnly.Image")));
            this.bppLocation.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.bppLocation.Properties.AutoHeight = ((bool)(resources.GetObject("bppLocation.Properties.AutoHeight")));
            this.bppLocation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("bppLocation.Properties.Buttons"))))});
            this.bppLocation.Properties.CloseOnOuterMouseClick = false;
            this.bppLocation.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("bppLocation.Properties.Mask.AutoComplete")));
            this.bppLocation.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("bppLocation.Properties.Mask.BeepOnError")));
            this.bppLocation.Properties.Mask.EditMask = resources.GetString("bppLocation.Properties.Mask.EditMask");
            this.bppLocation.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("bppLocation.Properties.Mask.IgnoreMaskBlank")));
            this.bppLocation.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("bppLocation.Properties.Mask.MaskType")));
            this.bppLocation.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("bppLocation.Properties.Mask.PlaceHolder")));
            this.bppLocation.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("bppLocation.Properties.Mask.SaveLiteral")));
            this.bppLocation.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("bppLocation.Properties.Mask.ShowPlaceHolders")));
            this.bppLocation.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("bppLocation.Properties.Mask.UseMaskAsDisplayFormat")));
            this.bppLocation.Properties.NullValuePrompt = resources.GetString("bppLocation.Properties.NullValuePrompt");
            this.bppLocation.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("bppLocation.Properties.NullValuePromptShowForEmptyValue")));
            this.bppLocation.Properties.PopupSizeable = false;
            this.bppLocation.Properties.ReadOnly = true;
            this.bppLocation.Properties.ShowPopupCloseButton = false;
            // 
            // seElevation
            // 
            resources.ApplyResources(this.seElevation, "seElevation");
            this.seElevation.Name = "seElevation";
            this.seElevation.Properties.AccessibleDescription = resources.GetString("seElevation.Properties.AccessibleDescription");
            this.seElevation.Properties.AccessibleName = resources.GetString("seElevation.Properties.AccessibleName");
            this.seElevation.Properties.AutoHeight = ((bool)(resources.GetObject("seElevation.Properties.AutoHeight")));
            this.seElevation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seElevation.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("seElevation.Properties.Mask.AutoComplete")));
            this.seElevation.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("seElevation.Properties.Mask.BeepOnError")));
            this.seElevation.Properties.Mask.EditMask = resources.GetString("seElevation.Properties.Mask.EditMask");
            this.seElevation.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("seElevation.Properties.Mask.IgnoreMaskBlank")));
            this.seElevation.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("seElevation.Properties.Mask.MaskType")));
            this.seElevation.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("seElevation.Properties.Mask.PlaceHolder")));
            this.seElevation.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("seElevation.Properties.Mask.SaveLiteral")));
            this.seElevation.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("seElevation.Properties.Mask.ShowPlaceHolders")));
            this.seElevation.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("seElevation.Properties.Mask.UseMaskAsDisplayFormat")));
            this.seElevation.Properties.NullValuePrompt = resources.GetString("seElevation.Properties.NullValuePrompt");
            this.seElevation.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("seElevation.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // leBasisOfRecord
            // 
            resources.ApplyResources(this.leBasisOfRecord, "leBasisOfRecord");
            this.leBasisOfRecord.Name = "leBasisOfRecord";
            this.leBasisOfRecord.Properties.AccessibleDescription = resources.GetString("leBasisOfRecord.Properties.AccessibleDescription");
            this.leBasisOfRecord.Properties.AccessibleName = resources.GetString("leBasisOfRecord.Properties.AccessibleName");
            this.leBasisOfRecord.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("leBasisOfRecord.Properties.Appearance.FontSizeDelta")));
            this.leBasisOfRecord.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leBasisOfRecord.Properties.Appearance.FontStyleDelta")));
            this.leBasisOfRecord.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leBasisOfRecord.Properties.Appearance.GradientMode")));
            this.leBasisOfRecord.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("leBasisOfRecord.Properties.Appearance.Image")));
            this.leBasisOfRecord.Properties.Appearance.Options.UseFont = true;
            this.leBasisOfRecord.Properties.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("leBasisOfRecord.Properties.AppearanceDisabled.FontSizeDelta")));
            this.leBasisOfRecord.Properties.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leBasisOfRecord.Properties.AppearanceDisabled.FontStyleDelta")));
            this.leBasisOfRecord.Properties.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leBasisOfRecord.Properties.AppearanceDisabled.GradientMode")));
            this.leBasisOfRecord.Properties.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("leBasisOfRecord.Properties.AppearanceDisabled.Image")));
            this.leBasisOfRecord.Properties.AppearanceDisabled.Options.UseFont = true;
            this.leBasisOfRecord.Properties.AppearanceDropDown.FontSizeDelta = ((int)(resources.GetObject("leBasisOfRecord.Properties.AppearanceDropDown.FontSizeDelta")));
            this.leBasisOfRecord.Properties.AppearanceDropDown.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leBasisOfRecord.Properties.AppearanceDropDown.FontStyleDelta")));
            this.leBasisOfRecord.Properties.AppearanceDropDown.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leBasisOfRecord.Properties.AppearanceDropDown.GradientMode")));
            this.leBasisOfRecord.Properties.AppearanceDropDown.Image = ((System.Drawing.Image)(resources.GetObject("leBasisOfRecord.Properties.AppearanceDropDown.Image")));
            this.leBasisOfRecord.Properties.AppearanceDropDown.Options.UseFont = true;
            this.leBasisOfRecord.Properties.AppearanceDropDownHeader.FontSizeDelta = ((int)(resources.GetObject("leBasisOfRecord.Properties.AppearanceDropDownHeader.FontSizeDelta")));
            this.leBasisOfRecord.Properties.AppearanceDropDownHeader.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leBasisOfRecord.Properties.AppearanceDropDownHeader.FontStyleDelta")));
            this.leBasisOfRecord.Properties.AppearanceDropDownHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leBasisOfRecord.Properties.AppearanceDropDownHeader.GradientMode")));
            this.leBasisOfRecord.Properties.AppearanceDropDownHeader.Image = ((System.Drawing.Image)(resources.GetObject("leBasisOfRecord.Properties.AppearanceDropDownHeader.Image")));
            this.leBasisOfRecord.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.leBasisOfRecord.Properties.AppearanceFocused.FontSizeDelta = ((int)(resources.GetObject("leBasisOfRecord.Properties.AppearanceFocused.FontSizeDelta")));
            this.leBasisOfRecord.Properties.AppearanceFocused.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leBasisOfRecord.Properties.AppearanceFocused.FontStyleDelta")));
            this.leBasisOfRecord.Properties.AppearanceFocused.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leBasisOfRecord.Properties.AppearanceFocused.GradientMode")));
            this.leBasisOfRecord.Properties.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("leBasisOfRecord.Properties.AppearanceFocused.Image")));
            this.leBasisOfRecord.Properties.AppearanceFocused.Options.UseFont = true;
            this.leBasisOfRecord.Properties.AppearanceReadOnly.FontSizeDelta = ((int)(resources.GetObject("leBasisOfRecord.Properties.AppearanceReadOnly.FontSizeDelta")));
            this.leBasisOfRecord.Properties.AppearanceReadOnly.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leBasisOfRecord.Properties.AppearanceReadOnly.FontStyleDelta")));
            this.leBasisOfRecord.Properties.AppearanceReadOnly.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leBasisOfRecord.Properties.AppearanceReadOnly.GradientMode")));
            this.leBasisOfRecord.Properties.AppearanceReadOnly.Image = ((System.Drawing.Image)(resources.GetObject("leBasisOfRecord.Properties.AppearanceReadOnly.Image")));
            this.leBasisOfRecord.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.leBasisOfRecord.Properties.AutoHeight = ((bool)(resources.GetObject("leBasisOfRecord.Properties.AutoHeight")));
            resources.ApplyResources(serializableAppearanceObject10, "serializableAppearanceObject10");
            serializableAppearanceObject10.Options.UseFont = true;
            this.leBasisOfRecord.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leBasisOfRecord.Properties.Buttons"))), resources.GetString("leBasisOfRecord.Properties.Buttons1"), ((int)(resources.GetObject("leBasisOfRecord.Properties.Buttons2"))), ((bool)(resources.GetObject("leBasisOfRecord.Properties.Buttons3"))), ((bool)(resources.GetObject("leBasisOfRecord.Properties.Buttons4"))), ((bool)(resources.GetObject("leBasisOfRecord.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("leBasisOfRecord.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("leBasisOfRecord.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10, resources.GetString("leBasisOfRecord.Properties.Buttons8"), ((object)(resources.GetObject("leBasisOfRecord.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("leBasisOfRecord.Properties.Buttons10"))), ((bool)(resources.GetObject("leBasisOfRecord.Properties.Buttons11"))))});
            this.leBasisOfRecord.Properties.NullText = resources.GetString("leBasisOfRecord.Properties.NullText");
            this.leBasisOfRecord.Properties.NullValuePrompt = resources.GetString("leBasisOfRecord.Properties.NullValuePrompt");
            this.leBasisOfRecord.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("leBasisOfRecord.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // leHostGuestReference
            // 
            resources.ApplyResources(this.leHostGuestReference, "leHostGuestReference");
            this.leHostGuestReference.Name = "leHostGuestReference";
            this.leHostGuestReference.Properties.AccessibleDescription = resources.GetString("leHostGuestReference.Properties.AccessibleDescription");
            this.leHostGuestReference.Properties.AccessibleName = resources.GetString("leHostGuestReference.Properties.AccessibleName");
            this.leHostGuestReference.Properties.AutoHeight = ((bool)(resources.GetObject("leHostGuestReference.Properties.AutoHeight")));
            this.leHostGuestReference.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leHostGuestReference.Properties.Buttons"))))});
            this.leHostGuestReference.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("leHostGuestReference.Properties.Columns"), resources.GetString("leHostGuestReference.Properties.Columns1"), ((int)(resources.GetObject("leHostGuestReference.Properties.Columns2"))), ((DevExpress.Utils.FormatType)(resources.GetObject("leHostGuestReference.Properties.Columns3"))), resources.GetString("leHostGuestReference.Properties.Columns4"), ((bool)(resources.GetObject("leHostGuestReference.Properties.Columns5"))), ((DevExpress.Utils.HorzAlignment)(resources.GetObject("leHostGuestReference.Properties.Columns6")))),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("leHostGuestReference.Properties.Columns7"), resources.GetString("leHostGuestReference.Properties.Columns8")),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("leHostGuestReference.Properties.Columns9"), resources.GetString("leHostGuestReference.Properties.Columns10")),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("leHostGuestReference.Properties.Columns11"), resources.GetString("leHostGuestReference.Properties.Columns12"))});
            this.leHostGuestReference.Properties.DisplayMember = "strFieldVectorID";
            this.leHostGuestReference.Properties.NullText = resources.GetString("leHostGuestReference.Properties.NullText");
            this.leHostGuestReference.Properties.NullValuePrompt = resources.GetString("leHostGuestReference.Properties.NullValuePrompt");
            this.leHostGuestReference.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("leHostGuestReference.Properties.NullValuePromptShowForEmptyValue")));
            this.leHostGuestReference.Properties.ValueMember = "idfVector";
            // 
            // leCollectionMethod
            // 
            resources.ApplyResources(this.leCollectionMethod, "leCollectionMethod");
            this.leCollectionMethod.Name = "leCollectionMethod";
            this.leCollectionMethod.Properties.AccessibleDescription = resources.GetString("leCollectionMethod.Properties.AccessibleDescription");
            this.leCollectionMethod.Properties.AccessibleName = resources.GetString("leCollectionMethod.Properties.AccessibleName");
            this.leCollectionMethod.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("leCollectionMethod.Properties.Appearance.FontSizeDelta")));
            this.leCollectionMethod.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leCollectionMethod.Properties.Appearance.FontStyleDelta")));
            this.leCollectionMethod.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leCollectionMethod.Properties.Appearance.GradientMode")));
            this.leCollectionMethod.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("leCollectionMethod.Properties.Appearance.Image")));
            this.leCollectionMethod.Properties.Appearance.Options.UseFont = true;
            this.leCollectionMethod.Properties.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("leCollectionMethod.Properties.AppearanceDisabled.FontSizeDelta")));
            this.leCollectionMethod.Properties.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leCollectionMethod.Properties.AppearanceDisabled.FontStyleDelta")));
            this.leCollectionMethod.Properties.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leCollectionMethod.Properties.AppearanceDisabled.GradientMode")));
            this.leCollectionMethod.Properties.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("leCollectionMethod.Properties.AppearanceDisabled.Image")));
            this.leCollectionMethod.Properties.AppearanceDisabled.Options.UseFont = true;
            this.leCollectionMethod.Properties.AppearanceDropDown.FontSizeDelta = ((int)(resources.GetObject("leCollectionMethod.Properties.AppearanceDropDown.FontSizeDelta")));
            this.leCollectionMethod.Properties.AppearanceDropDown.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leCollectionMethod.Properties.AppearanceDropDown.FontStyleDelta")));
            this.leCollectionMethod.Properties.AppearanceDropDown.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leCollectionMethod.Properties.AppearanceDropDown.GradientMode")));
            this.leCollectionMethod.Properties.AppearanceDropDown.Image = ((System.Drawing.Image)(resources.GetObject("leCollectionMethod.Properties.AppearanceDropDown.Image")));
            this.leCollectionMethod.Properties.AppearanceDropDown.Options.UseFont = true;
            this.leCollectionMethod.Properties.AppearanceDropDownHeader.FontSizeDelta = ((int)(resources.GetObject("leCollectionMethod.Properties.AppearanceDropDownHeader.FontSizeDelta")));
            this.leCollectionMethod.Properties.AppearanceDropDownHeader.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leCollectionMethod.Properties.AppearanceDropDownHeader.FontStyleDelta")));
            this.leCollectionMethod.Properties.AppearanceDropDownHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leCollectionMethod.Properties.AppearanceDropDownHeader.GradientMode")));
            this.leCollectionMethod.Properties.AppearanceDropDownHeader.Image = ((System.Drawing.Image)(resources.GetObject("leCollectionMethod.Properties.AppearanceDropDownHeader.Image")));
            this.leCollectionMethod.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.leCollectionMethod.Properties.AppearanceFocused.FontSizeDelta = ((int)(resources.GetObject("leCollectionMethod.Properties.AppearanceFocused.FontSizeDelta")));
            this.leCollectionMethod.Properties.AppearanceFocused.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leCollectionMethod.Properties.AppearanceFocused.FontStyleDelta")));
            this.leCollectionMethod.Properties.AppearanceFocused.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leCollectionMethod.Properties.AppearanceFocused.GradientMode")));
            this.leCollectionMethod.Properties.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("leCollectionMethod.Properties.AppearanceFocused.Image")));
            this.leCollectionMethod.Properties.AppearanceFocused.Options.UseFont = true;
            this.leCollectionMethod.Properties.AppearanceReadOnly.FontSizeDelta = ((int)(resources.GetObject("leCollectionMethod.Properties.AppearanceReadOnly.FontSizeDelta")));
            this.leCollectionMethod.Properties.AppearanceReadOnly.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leCollectionMethod.Properties.AppearanceReadOnly.FontStyleDelta")));
            this.leCollectionMethod.Properties.AppearanceReadOnly.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leCollectionMethod.Properties.AppearanceReadOnly.GradientMode")));
            this.leCollectionMethod.Properties.AppearanceReadOnly.Image = ((System.Drawing.Image)(resources.GetObject("leCollectionMethod.Properties.AppearanceReadOnly.Image")));
            this.leCollectionMethod.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.leCollectionMethod.Properties.AutoHeight = ((bool)(resources.GetObject("leCollectionMethod.Properties.AutoHeight")));
            resources.ApplyResources(serializableAppearanceObject11, "serializableAppearanceObject11");
            serializableAppearanceObject11.Options.UseFont = true;
            this.leCollectionMethod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leCollectionMethod.Properties.Buttons"))), resources.GetString("leCollectionMethod.Properties.Buttons1"), ((int)(resources.GetObject("leCollectionMethod.Properties.Buttons2"))), ((bool)(resources.GetObject("leCollectionMethod.Properties.Buttons3"))), ((bool)(resources.GetObject("leCollectionMethod.Properties.Buttons4"))), ((bool)(resources.GetObject("leCollectionMethod.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("leCollectionMethod.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("leCollectionMethod.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11, resources.GetString("leCollectionMethod.Properties.Buttons8"), ((object)(resources.GetObject("leCollectionMethod.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("leCollectionMethod.Properties.Buttons10"))), ((bool)(resources.GetObject("leCollectionMethod.Properties.Buttons11"))))});
            this.leCollectionMethod.Properties.NullText = resources.GetString("leCollectionMethod.Properties.NullText");
            this.leCollectionMethod.Properties.NullValuePrompt = resources.GetString("leCollectionMethod.Properties.NullValuePrompt");
            this.leCollectionMethod.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("leCollectionMethod.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // leCollectionTime
            // 
            resources.ApplyResources(this.leCollectionTime, "leCollectionTime");
            this.leCollectionTime.Name = "leCollectionTime";
            this.leCollectionTime.Properties.AccessibleDescription = resources.GetString("leCollectionTime.Properties.AccessibleDescription");
            this.leCollectionTime.Properties.AccessibleName = resources.GetString("leCollectionTime.Properties.AccessibleName");
            this.leCollectionTime.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("leCollectionTime.Properties.Appearance.FontSizeDelta")));
            this.leCollectionTime.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leCollectionTime.Properties.Appearance.FontStyleDelta")));
            this.leCollectionTime.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leCollectionTime.Properties.Appearance.GradientMode")));
            this.leCollectionTime.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("leCollectionTime.Properties.Appearance.Image")));
            this.leCollectionTime.Properties.Appearance.Options.UseFont = true;
            this.leCollectionTime.Properties.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("leCollectionTime.Properties.AppearanceDisabled.FontSizeDelta")));
            this.leCollectionTime.Properties.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leCollectionTime.Properties.AppearanceDisabled.FontStyleDelta")));
            this.leCollectionTime.Properties.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leCollectionTime.Properties.AppearanceDisabled.GradientMode")));
            this.leCollectionTime.Properties.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("leCollectionTime.Properties.AppearanceDisabled.Image")));
            this.leCollectionTime.Properties.AppearanceDisabled.Options.UseFont = true;
            this.leCollectionTime.Properties.AppearanceDropDown.FontSizeDelta = ((int)(resources.GetObject("leCollectionTime.Properties.AppearanceDropDown.FontSizeDelta")));
            this.leCollectionTime.Properties.AppearanceDropDown.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leCollectionTime.Properties.AppearanceDropDown.FontStyleDelta")));
            this.leCollectionTime.Properties.AppearanceDropDown.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leCollectionTime.Properties.AppearanceDropDown.GradientMode")));
            this.leCollectionTime.Properties.AppearanceDropDown.Image = ((System.Drawing.Image)(resources.GetObject("leCollectionTime.Properties.AppearanceDropDown.Image")));
            this.leCollectionTime.Properties.AppearanceDropDown.Options.UseFont = true;
            this.leCollectionTime.Properties.AppearanceDropDownHeader.FontSizeDelta = ((int)(resources.GetObject("leCollectionTime.Properties.AppearanceDropDownHeader.FontSizeDelta")));
            this.leCollectionTime.Properties.AppearanceDropDownHeader.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leCollectionTime.Properties.AppearanceDropDownHeader.FontStyleDelta")));
            this.leCollectionTime.Properties.AppearanceDropDownHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leCollectionTime.Properties.AppearanceDropDownHeader.GradientMode")));
            this.leCollectionTime.Properties.AppearanceDropDownHeader.Image = ((System.Drawing.Image)(resources.GetObject("leCollectionTime.Properties.AppearanceDropDownHeader.Image")));
            this.leCollectionTime.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.leCollectionTime.Properties.AppearanceFocused.FontSizeDelta = ((int)(resources.GetObject("leCollectionTime.Properties.AppearanceFocused.FontSizeDelta")));
            this.leCollectionTime.Properties.AppearanceFocused.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leCollectionTime.Properties.AppearanceFocused.FontStyleDelta")));
            this.leCollectionTime.Properties.AppearanceFocused.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leCollectionTime.Properties.AppearanceFocused.GradientMode")));
            this.leCollectionTime.Properties.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("leCollectionTime.Properties.AppearanceFocused.Image")));
            this.leCollectionTime.Properties.AppearanceFocused.Options.UseFont = true;
            this.leCollectionTime.Properties.AppearanceReadOnly.FontSizeDelta = ((int)(resources.GetObject("leCollectionTime.Properties.AppearanceReadOnly.FontSizeDelta")));
            this.leCollectionTime.Properties.AppearanceReadOnly.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leCollectionTime.Properties.AppearanceReadOnly.FontStyleDelta")));
            this.leCollectionTime.Properties.AppearanceReadOnly.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leCollectionTime.Properties.AppearanceReadOnly.GradientMode")));
            this.leCollectionTime.Properties.AppearanceReadOnly.Image = ((System.Drawing.Image)(resources.GetObject("leCollectionTime.Properties.AppearanceReadOnly.Image")));
            this.leCollectionTime.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.leCollectionTime.Properties.AutoHeight = ((bool)(resources.GetObject("leCollectionTime.Properties.AutoHeight")));
            resources.ApplyResources(serializableAppearanceObject12, "serializableAppearanceObject12");
            serializableAppearanceObject12.Options.UseFont = true;
            this.leCollectionTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leCollectionTime.Properties.Buttons"))), resources.GetString("leCollectionTime.Properties.Buttons1"), ((int)(resources.GetObject("leCollectionTime.Properties.Buttons2"))), ((bool)(resources.GetObject("leCollectionTime.Properties.Buttons3"))), ((bool)(resources.GetObject("leCollectionTime.Properties.Buttons4"))), ((bool)(resources.GetObject("leCollectionTime.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("leCollectionTime.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("leCollectionTime.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12, resources.GetString("leCollectionTime.Properties.Buttons8"), ((object)(resources.GetObject("leCollectionTime.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("leCollectionTime.Properties.Buttons10"))), ((bool)(resources.GetObject("leCollectionTime.Properties.Buttons11"))))});
            this.leCollectionTime.Properties.NullText = resources.GetString("leCollectionTime.Properties.NullText");
            this.leCollectionTime.Properties.NullValuePrompt = resources.GetString("leCollectionTime.Properties.NullValuePrompt");
            this.leCollectionTime.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("leCollectionTime.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // dtCollectionDateFrom
            // 
            resources.ApplyResources(this.dtCollectionDateFrom, "dtCollectionDateFrom");
            this.dtCollectionDateFrom.Name = "dtCollectionDateFrom";
            this.dtCollectionDateFrom.Properties.AccessibleDescription = resources.GetString("dtCollectionDateFrom.Properties.AccessibleDescription");
            this.dtCollectionDateFrom.Properties.AccessibleName = resources.GetString("dtCollectionDateFrom.Properties.AccessibleName");
            this.dtCollectionDateFrom.Properties.AutoHeight = ((bool)(resources.GetObject("dtCollectionDateFrom.Properties.AutoHeight")));
            this.dtCollectionDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("dtCollectionDateFrom.Properties.Buttons"))))});
            this.dtCollectionDateFrom.Properties.CalendarTimeProperties.AccessibleDescription = resources.GetString("dtCollectionDateFrom.Properties.CalendarTimeProperties.AccessibleDescription");
            this.dtCollectionDateFrom.Properties.CalendarTimeProperties.AccessibleName = resources.GetString("dtCollectionDateFrom.Properties.CalendarTimeProperties.AccessibleName");
            this.dtCollectionDateFrom.Properties.CalendarTimeProperties.AutoHeight = ((bool)(resources.GetObject("dtCollectionDateFrom.Properties.CalendarTimeProperties.AutoHeight")));
            this.dtCollectionDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtCollectionDateFrom.Properties.CalendarTimeProperties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("dtCollectionDateFrom.Properties.CalendarTimeProperties.Mask.AutoComplete")));
            this.dtCollectionDateFrom.Properties.CalendarTimeProperties.Mask.BeepOnError = ((bool)(resources.GetObject("dtCollectionDateFrom.Properties.CalendarTimeProperties.Mask.BeepOnError")));
            this.dtCollectionDateFrom.Properties.CalendarTimeProperties.Mask.EditMask = resources.GetString("dtCollectionDateFrom.Properties.CalendarTimeProperties.Mask.EditMask");
            this.dtCollectionDateFrom.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("dtCollectionDateFrom.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank")));
            this.dtCollectionDateFrom.Properties.CalendarTimeProperties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("dtCollectionDateFrom.Properties.CalendarTimeProperties.Mask.MaskType")));
            this.dtCollectionDateFrom.Properties.CalendarTimeProperties.Mask.PlaceHolder = ((char)(resources.GetObject("dtCollectionDateFrom.Properties.CalendarTimeProperties.Mask.PlaceHolder")));
            this.dtCollectionDateFrom.Properties.CalendarTimeProperties.Mask.SaveLiteral = ((bool)(resources.GetObject("dtCollectionDateFrom.Properties.CalendarTimeProperties.Mask.SaveLiteral")));
            this.dtCollectionDateFrom.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("dtCollectionDateFrom.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders")));
            this.dtCollectionDateFrom.Properties.CalendarTimeProperties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("dtCollectionDateFrom.Properties.CalendarTimeProperties.Mask.UseMaskAsDisplayForma" +
        "t")));
            this.dtCollectionDateFrom.Properties.CalendarTimeProperties.NullValuePrompt = resources.GetString("dtCollectionDateFrom.Properties.CalendarTimeProperties.NullValuePrompt");
            this.dtCollectionDateFrom.Properties.CalendarTimeProperties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("dtCollectionDateFrom.Properties.CalendarTimeProperties.NullValuePromptShowForEmpt" +
        "yValue")));
            this.dtCollectionDateFrom.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("dtCollectionDateFrom.Properties.Mask.AutoComplete")));
            this.dtCollectionDateFrom.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("dtCollectionDateFrom.Properties.Mask.BeepOnError")));
            this.dtCollectionDateFrom.Properties.Mask.EditMask = resources.GetString("dtCollectionDateFrom.Properties.Mask.EditMask");
            this.dtCollectionDateFrom.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("dtCollectionDateFrom.Properties.Mask.IgnoreMaskBlank")));
            this.dtCollectionDateFrom.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("dtCollectionDateFrom.Properties.Mask.MaskType")));
            this.dtCollectionDateFrom.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("dtCollectionDateFrom.Properties.Mask.PlaceHolder")));
            this.dtCollectionDateFrom.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("dtCollectionDateFrom.Properties.Mask.SaveLiteral")));
            this.dtCollectionDateFrom.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("dtCollectionDateFrom.Properties.Mask.ShowPlaceHolders")));
            this.dtCollectionDateFrom.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("dtCollectionDateFrom.Properties.Mask.UseMaskAsDisplayFormat")));
            this.dtCollectionDateFrom.Properties.NullValuePrompt = resources.GetString("dtCollectionDateFrom.Properties.NullValuePrompt");
            this.dtCollectionDateFrom.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("dtCollectionDateFrom.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // leCollector
            // 
            resources.ApplyResources(this.leCollector, "leCollector");
            this.leCollector.Name = "leCollector";
            this.leCollector.Properties.AccessibleDescription = resources.GetString("leCollector.Properties.AccessibleDescription");
            this.leCollector.Properties.AccessibleName = resources.GetString("leCollector.Properties.AccessibleName");
            this.leCollector.Properties.AutoHeight = ((bool)(resources.GetObject("leCollector.Properties.AutoHeight")));
            this.leCollector.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leCollector.Properties.Buttons"))))});
            this.leCollector.Properties.NullText = resources.GetString("leCollector.Properties.NullText");
            this.leCollector.Properties.NullValuePrompt = resources.GetString("leCollector.Properties.NullValuePrompt");
            this.leCollector.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("leCollector.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // leCollectedByInstitution
            // 
            resources.ApplyResources(this.leCollectedByInstitution, "leCollectedByInstitution");
            this.leCollectedByInstitution.Name = "leCollectedByInstitution";
            this.leCollectedByInstitution.Properties.AccessibleDescription = resources.GetString("leCollectedByInstitution.Properties.AccessibleDescription");
            this.leCollectedByInstitution.Properties.AccessibleName = resources.GetString("leCollectedByInstitution.Properties.AccessibleName");
            this.leCollectedByInstitution.Properties.AutoHeight = ((bool)(resources.GetObject("leCollectedByInstitution.Properties.AutoHeight")));
            this.leCollectedByInstitution.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leCollectedByInstitution.Properties.Buttons"))))});
            this.leCollectedByInstitution.Properties.NullText = resources.GetString("leCollectedByInstitution.Properties.NullText");
            this.leCollectedByInstitution.Properties.NullValuePrompt = resources.GetString("leCollectedByInstitution.Properties.NullValuePrompt");
            this.leCollectedByInstitution.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("leCollectedByInstitution.Properties.NullValuePromptShowForEmptyValue")));
            this.leCollectedByInstitution.Properties.PopupWidth = 250;
            // 
            // txtGeoReference
            // 
            resources.ApplyResources(this.txtGeoReference, "txtGeoReference");
            this.txtGeoReference.Name = "txtGeoReference";
            this.txtGeoReference.Properties.AccessibleDescription = resources.GetString("txtGeoReference.Properties.AccessibleDescription");
            this.txtGeoReference.Properties.AccessibleName = resources.GetString("txtGeoReference.Properties.AccessibleName");
            this.txtGeoReference.Properties.AutoHeight = ((bool)(resources.GetObject("txtGeoReference.Properties.AutoHeight")));
            this.txtGeoReference.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtGeoReference.Properties.Mask.AutoComplete")));
            this.txtGeoReference.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtGeoReference.Properties.Mask.BeepOnError")));
            this.txtGeoReference.Properties.Mask.EditMask = resources.GetString("txtGeoReference.Properties.Mask.EditMask");
            this.txtGeoReference.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtGeoReference.Properties.Mask.IgnoreMaskBlank")));
            this.txtGeoReference.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtGeoReference.Properties.Mask.MaskType")));
            this.txtGeoReference.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtGeoReference.Properties.Mask.PlaceHolder")));
            this.txtGeoReference.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtGeoReference.Properties.Mask.SaveLiteral")));
            this.txtGeoReference.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtGeoReference.Properties.Mask.ShowPlaceHolders")));
            this.txtGeoReference.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtGeoReference.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtGeoReference.Properties.NullValuePrompt = resources.GetString("txtGeoReference.Properties.NullValuePrompt");
            this.txtGeoReference.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtGeoReference.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // leSurrounding
            // 
            resources.ApplyResources(this.leSurrounding, "leSurrounding");
            this.leSurrounding.Name = "leSurrounding";
            this.leSurrounding.Properties.AccessibleDescription = resources.GetString("leSurrounding.Properties.AccessibleDescription");
            this.leSurrounding.Properties.AccessibleName = resources.GetString("leSurrounding.Properties.AccessibleName");
            this.leSurrounding.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("leSurrounding.Properties.Appearance.FontSizeDelta")));
            this.leSurrounding.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leSurrounding.Properties.Appearance.FontStyleDelta")));
            this.leSurrounding.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leSurrounding.Properties.Appearance.GradientMode")));
            this.leSurrounding.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("leSurrounding.Properties.Appearance.Image")));
            this.leSurrounding.Properties.Appearance.Options.UseFont = true;
            this.leSurrounding.Properties.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("leSurrounding.Properties.AppearanceDisabled.FontSizeDelta")));
            this.leSurrounding.Properties.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leSurrounding.Properties.AppearanceDisabled.FontStyleDelta")));
            this.leSurrounding.Properties.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leSurrounding.Properties.AppearanceDisabled.GradientMode")));
            this.leSurrounding.Properties.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("leSurrounding.Properties.AppearanceDisabled.Image")));
            this.leSurrounding.Properties.AppearanceDisabled.Options.UseFont = true;
            this.leSurrounding.Properties.AppearanceDropDown.FontSizeDelta = ((int)(resources.GetObject("leSurrounding.Properties.AppearanceDropDown.FontSizeDelta")));
            this.leSurrounding.Properties.AppearanceDropDown.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leSurrounding.Properties.AppearanceDropDown.FontStyleDelta")));
            this.leSurrounding.Properties.AppearanceDropDown.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leSurrounding.Properties.AppearanceDropDown.GradientMode")));
            this.leSurrounding.Properties.AppearanceDropDown.Image = ((System.Drawing.Image)(resources.GetObject("leSurrounding.Properties.AppearanceDropDown.Image")));
            this.leSurrounding.Properties.AppearanceDropDown.Options.UseFont = true;
            this.leSurrounding.Properties.AppearanceDropDownHeader.FontSizeDelta = ((int)(resources.GetObject("leSurrounding.Properties.AppearanceDropDownHeader.FontSizeDelta")));
            this.leSurrounding.Properties.AppearanceDropDownHeader.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leSurrounding.Properties.AppearanceDropDownHeader.FontStyleDelta")));
            this.leSurrounding.Properties.AppearanceDropDownHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leSurrounding.Properties.AppearanceDropDownHeader.GradientMode")));
            this.leSurrounding.Properties.AppearanceDropDownHeader.Image = ((System.Drawing.Image)(resources.GetObject("leSurrounding.Properties.AppearanceDropDownHeader.Image")));
            this.leSurrounding.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.leSurrounding.Properties.AppearanceFocused.FontSizeDelta = ((int)(resources.GetObject("leSurrounding.Properties.AppearanceFocused.FontSizeDelta")));
            this.leSurrounding.Properties.AppearanceFocused.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leSurrounding.Properties.AppearanceFocused.FontStyleDelta")));
            this.leSurrounding.Properties.AppearanceFocused.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leSurrounding.Properties.AppearanceFocused.GradientMode")));
            this.leSurrounding.Properties.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("leSurrounding.Properties.AppearanceFocused.Image")));
            this.leSurrounding.Properties.AppearanceFocused.Options.UseFont = true;
            this.leSurrounding.Properties.AppearanceReadOnly.FontSizeDelta = ((int)(resources.GetObject("leSurrounding.Properties.AppearanceReadOnly.FontSizeDelta")));
            this.leSurrounding.Properties.AppearanceReadOnly.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leSurrounding.Properties.AppearanceReadOnly.FontStyleDelta")));
            this.leSurrounding.Properties.AppearanceReadOnly.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leSurrounding.Properties.AppearanceReadOnly.GradientMode")));
            this.leSurrounding.Properties.AppearanceReadOnly.Image = ((System.Drawing.Image)(resources.GetObject("leSurrounding.Properties.AppearanceReadOnly.Image")));
            this.leSurrounding.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.leSurrounding.Properties.AutoHeight = ((bool)(resources.GetObject("leSurrounding.Properties.AutoHeight")));
            resources.ApplyResources(serializableAppearanceObject13, "serializableAppearanceObject13");
            serializableAppearanceObject13.Options.UseFont = true;
            this.leSurrounding.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leSurrounding.Properties.Buttons"))), resources.GetString("leSurrounding.Properties.Buttons1"), ((int)(resources.GetObject("leSurrounding.Properties.Buttons2"))), ((bool)(resources.GetObject("leSurrounding.Properties.Buttons3"))), ((bool)(resources.GetObject("leSurrounding.Properties.Buttons4"))), ((bool)(resources.GetObject("leSurrounding.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("leSurrounding.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("leSurrounding.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13, resources.GetString("leSurrounding.Properties.Buttons8"), ((object)(resources.GetObject("leSurrounding.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("leSurrounding.Properties.Buttons10"))), ((bool)(resources.GetObject("leSurrounding.Properties.Buttons11"))))});
            this.leSurrounding.Properties.NullText = resources.GetString("leSurrounding.Properties.NullText");
            this.leSurrounding.Properties.NullValuePrompt = resources.GetString("leSurrounding.Properties.NullValuePrompt");
            this.leSurrounding.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("leSurrounding.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // lblBasisOfRecord
            // 
            resources.ApplyResources(this.lblBasisOfRecord, "lblBasisOfRecord");
            this.lblBasisOfRecord.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblBasisOfRecord.Appearance.DisabledImage")));
            this.lblBasisOfRecord.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblBasisOfRecord.Appearance.FontSizeDelta")));
            this.lblBasisOfRecord.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblBasisOfRecord.Appearance.FontStyleDelta")));
            this.lblBasisOfRecord.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblBasisOfRecord.Appearance.GradientMode")));
            this.lblBasisOfRecord.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblBasisOfRecord.Appearance.HoverImage")));
            this.lblBasisOfRecord.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblBasisOfRecord.Appearance.Image")));
            this.lblBasisOfRecord.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblBasisOfRecord.Appearance.PressedImage")));
            this.lblBasisOfRecord.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblBasisOfRecord.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblBasisOfRecord.Name = "lblBasisOfRecord";
            // 
            // lblHostGuestReference
            // 
            resources.ApplyResources(this.lblHostGuestReference, "lblHostGuestReference");
            this.lblHostGuestReference.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblHostGuestReference.Appearance.DisabledImage")));
            this.lblHostGuestReference.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblHostGuestReference.Appearance.FontSizeDelta")));
            this.lblHostGuestReference.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblHostGuestReference.Appearance.FontStyleDelta")));
            this.lblHostGuestReference.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblHostGuestReference.Appearance.GradientMode")));
            this.lblHostGuestReference.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblHostGuestReference.Appearance.HoverImage")));
            this.lblHostGuestReference.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblHostGuestReference.Appearance.Image")));
            this.lblHostGuestReference.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblHostGuestReference.Appearance.PressedImage")));
            this.lblHostGuestReference.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblHostGuestReference.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblHostGuestReference.Name = "lblHostGuestReference";
            // 
            // lblGeoReference
            // 
            resources.ApplyResources(this.lblGeoReference, "lblGeoReference");
            this.lblGeoReference.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblGeoReference.Appearance.DisabledImage")));
            this.lblGeoReference.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblGeoReference.Appearance.FontSizeDelta")));
            this.lblGeoReference.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblGeoReference.Appearance.FontStyleDelta")));
            this.lblGeoReference.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblGeoReference.Appearance.GradientMode")));
            this.lblGeoReference.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblGeoReference.Appearance.HoverImage")));
            this.lblGeoReference.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblGeoReference.Appearance.Image")));
            this.lblGeoReference.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblGeoReference.Appearance.PressedImage")));
            this.lblGeoReference.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblGeoReference.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblGeoReference.Name = "lblGeoReference";
            // 
            // lvlElevation
            // 
            resources.ApplyResources(this.lvlElevation, "lvlElevation");
            this.lvlElevation.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lvlElevation.Appearance.DisabledImage")));
            this.lvlElevation.Appearance.FontSizeDelta = ((int)(resources.GetObject("lvlElevation.Appearance.FontSizeDelta")));
            this.lvlElevation.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lvlElevation.Appearance.FontStyleDelta")));
            this.lvlElevation.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lvlElevation.Appearance.GradientMode")));
            this.lvlElevation.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lvlElevation.Appearance.HoverImage")));
            this.lvlElevation.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lvlElevation.Appearance.Image")));
            this.lvlElevation.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lvlElevation.Appearance.PressedImage")));
            this.lvlElevation.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lvlElevation.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lvlElevation.Name = "lvlElevation";
            // 
            // lblSurrounding
            // 
            resources.ApplyResources(this.lblSurrounding, "lblSurrounding");
            this.lblSurrounding.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblSurrounding.Appearance.DisabledImage")));
            this.lblSurrounding.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblSurrounding.Appearance.FontSizeDelta")));
            this.lblSurrounding.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblSurrounding.Appearance.FontStyleDelta")));
            this.lblSurrounding.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblSurrounding.Appearance.GradientMode")));
            this.lblSurrounding.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblSurrounding.Appearance.HoverImage")));
            this.lblSurrounding.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblSurrounding.Appearance.Image")));
            this.lblSurrounding.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblSurrounding.Appearance.PressedImage")));
            this.lblSurrounding.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblSurrounding.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblSurrounding.Name = "lblSurrounding";
            // 
            // lblLongitudeLatitude
            // 
            resources.ApplyResources(this.lblLongitudeLatitude, "lblLongitudeLatitude");
            this.lblLongitudeLatitude.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblLongitudeLatitude.Appearance.DisabledImage")));
            this.lblLongitudeLatitude.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblLongitudeLatitude.Appearance.FontSizeDelta")));
            this.lblLongitudeLatitude.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblLongitudeLatitude.Appearance.FontStyleDelta")));
            this.lblLongitudeLatitude.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblLongitudeLatitude.Appearance.GradientMode")));
            this.lblLongitudeLatitude.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblLongitudeLatitude.Appearance.HoverImage")));
            this.lblLongitudeLatitude.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblLongitudeLatitude.Appearance.Image")));
            this.lblLongitudeLatitude.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblLongitudeLatitude.Appearance.PressedImage")));
            this.lblLongitudeLatitude.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblLongitudeLatitude.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblLongitudeLatitude.Name = "lblLongitudeLatitude";
            // 
            // labelControl1
            // 
            resources.ApplyResources(this.labelControl1, "labelControl1");
            this.labelControl1.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("labelControl1.Appearance.DisabledImage")));
            this.labelControl1.Appearance.FontSizeDelta = ((int)(resources.GetObject("labelControl1.Appearance.FontSizeDelta")));
            this.labelControl1.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("labelControl1.Appearance.FontStyleDelta")));
            this.labelControl1.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("labelControl1.Appearance.GradientMode")));
            this.labelControl1.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("labelControl1.Appearance.HoverImage")));
            this.labelControl1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("labelControl1.Appearance.Image")));
            this.labelControl1.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("labelControl1.Appearance.PressedImage")));
            this.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl1.Name = "labelControl1";
            // 
            // lblCollectionMethod
            // 
            resources.ApplyResources(this.lblCollectionMethod, "lblCollectionMethod");
            this.lblCollectionMethod.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblCollectionMethod.Appearance.DisabledImage")));
            this.lblCollectionMethod.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblCollectionMethod.Appearance.FontSizeDelta")));
            this.lblCollectionMethod.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblCollectionMethod.Appearance.FontStyleDelta")));
            this.lblCollectionMethod.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblCollectionMethod.Appearance.GradientMode")));
            this.lblCollectionMethod.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblCollectionMethod.Appearance.HoverImage")));
            this.lblCollectionMethod.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblCollectionMethod.Appearance.Image")));
            this.lblCollectionMethod.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblCollectionMethod.Appearance.PressedImage")));
            this.lblCollectionMethod.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblCollectionMethod.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblCollectionMethod.Name = "lblCollectionMethod";
            // 
            // lblCollectionTime
            // 
            resources.ApplyResources(this.lblCollectionTime, "lblCollectionTime");
            this.lblCollectionTime.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblCollectionTime.Appearance.DisabledImage")));
            this.lblCollectionTime.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblCollectionTime.Appearance.FontSizeDelta")));
            this.lblCollectionTime.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblCollectionTime.Appearance.FontStyleDelta")));
            this.lblCollectionTime.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblCollectionTime.Appearance.GradientMode")));
            this.lblCollectionTime.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblCollectionTime.Appearance.HoverImage")));
            this.lblCollectionTime.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblCollectionTime.Appearance.Image")));
            this.lblCollectionTime.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblCollectionTime.Appearance.PressedImage")));
            this.lblCollectionTime.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblCollectionTime.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblCollectionTime.Name = "lblCollectionTime";
            // 
            // lblCollectionDate
            // 
            resources.ApplyResources(this.lblCollectionDate, "lblCollectionDate");
            this.lblCollectionDate.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblCollectionDate.Appearance.DisabledImage")));
            this.lblCollectionDate.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblCollectionDate.Appearance.FontSizeDelta")));
            this.lblCollectionDate.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblCollectionDate.Appearance.FontStyleDelta")));
            this.lblCollectionDate.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblCollectionDate.Appearance.GradientMode")));
            this.lblCollectionDate.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblCollectionDate.Appearance.HoverImage")));
            this.lblCollectionDate.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblCollectionDate.Appearance.Image")));
            this.lblCollectionDate.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblCollectionDate.Appearance.PressedImage")));
            this.lblCollectionDate.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblCollectionDate.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblCollectionDate.Name = "lblCollectionDate";
            // 
            // lblCollector
            // 
            resources.ApplyResources(this.lblCollector, "lblCollector");
            this.lblCollector.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblCollector.Appearance.DisabledImage")));
            this.lblCollector.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblCollector.Appearance.FontSizeDelta")));
            this.lblCollector.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblCollector.Appearance.FontStyleDelta")));
            this.lblCollector.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblCollector.Appearance.GradientMode")));
            this.lblCollector.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblCollector.Appearance.HoverImage")));
            this.lblCollector.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblCollector.Appearance.Image")));
            this.lblCollector.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblCollector.Appearance.PressedImage")));
            this.lblCollector.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblCollector.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblCollector.Name = "lblCollector";
            // 
            // lblInstitution
            // 
            resources.ApplyResources(this.lblInstitution, "lblInstitution");
            this.lblInstitution.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblInstitution.Appearance.DisabledImage")));
            this.lblInstitution.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblInstitution.Appearance.FontSizeDelta")));
            this.lblInstitution.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblInstitution.Appearance.FontStyleDelta")));
            this.lblInstitution.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblInstitution.Appearance.GradientMode")));
            this.lblInstitution.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblInstitution.Appearance.HoverImage")));
            this.lblInstitution.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblInstitution.Appearance.Image")));
            this.lblInstitution.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblInstitution.Appearance.PressedImage")));
            this.lblInstitution.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblInstitution.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblInstitution.Name = "lblInstitution";
            // 
            // tpVectorSpecificData
            // 
            resources.ApplyResources(this.tpVectorSpecificData, "tpVectorSpecificData");
            this.tpVectorSpecificData.Name = "tpVectorSpecificData";
            // 
            // tpSamples
            // 
            resources.ApplyResources(this.tpSamples, "tpSamples");
            this.tpSamples.Name = "tpSamples";
            // 
            // tpFieldTests
            // 
            resources.ApplyResources(this.tpFieldTests, "tpFieldTests");
            this.tpFieldTests.Name = "tpFieldTests";
            // 
            // tpLabTests
            // 
            resources.ApplyResources(this.tpLabTests, "tpLabTests");
            this.tpLabTests.Name = "tpLabTests";
            // 
            // remoteSqlConnection1
            // 
            this.remoteSqlConnection1.ConnectionString = null;
            // 
            // panelControl1
            // 
            resources.ApplyResources(this.panelControl1, "panelControl1");
            this.panelControl1.Controls.Add(this.leVectorType);
            this.panelControl1.Controls.Add(this.txtSessionID);
            this.panelControl1.Controls.Add(this.txtFieldID);
            this.panelControl1.Controls.Add(this.txtPoolVectorID);
            this.panelControl1.Controls.Add(this.lblVectorType);
            this.panelControl1.Controls.Add(this.lblSessionID);
            this.panelControl1.Controls.Add(this.lblPoolVectorID);
            this.panelControl1.Controls.Add(this.lblFieldID);
            this.panelControl1.Name = "panelControl1";
            // 
            // leVectorType
            // 
            resources.ApplyResources(this.leVectorType, "leVectorType");
            this.leVectorType.Name = "leVectorType";
            this.leVectorType.Properties.AccessibleDescription = resources.GetString("leVectorType.Properties.AccessibleDescription");
            this.leVectorType.Properties.AccessibleName = resources.GetString("leVectorType.Properties.AccessibleName");
            this.leVectorType.Properties.AutoHeight = ((bool)(resources.GetObject("leVectorType.Properties.AutoHeight")));
            this.leVectorType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leVectorType.Properties.Buttons"))))});
            this.leVectorType.Properties.NullText = resources.GetString("leVectorType.Properties.NullText");
            this.leVectorType.Properties.NullValuePrompt = resources.GetString("leVectorType.Properties.NullValuePrompt");
            this.leVectorType.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("leVectorType.Properties.NullValuePromptShowForEmptyValue")));
            this.leVectorType.Properties.PopupWidth = 250;
            this.leVectorType.EditValueChanged += new System.EventHandler(this.OnleVectorTypeSubTypeEditValueChanged);
            // 
            // txtSessionID
            // 
            resources.ApplyResources(this.txtSessionID, "txtSessionID");
            this.txtSessionID.Name = "txtSessionID";
            this.txtSessionID.Properties.AccessibleDescription = resources.GetString("txtSessionID.Properties.AccessibleDescription");
            this.txtSessionID.Properties.AccessibleName = resources.GetString("txtSessionID.Properties.AccessibleName");
            this.txtSessionID.Properties.AutoHeight = ((bool)(resources.GetObject("txtSessionID.Properties.AutoHeight")));
            this.txtSessionID.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtSessionID.Properties.Mask.AutoComplete")));
            this.txtSessionID.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtSessionID.Properties.Mask.BeepOnError")));
            this.txtSessionID.Properties.Mask.EditMask = resources.GetString("txtSessionID.Properties.Mask.EditMask");
            this.txtSessionID.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtSessionID.Properties.Mask.IgnoreMaskBlank")));
            this.txtSessionID.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtSessionID.Properties.Mask.MaskType")));
            this.txtSessionID.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtSessionID.Properties.Mask.PlaceHolder")));
            this.txtSessionID.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtSessionID.Properties.Mask.SaveLiteral")));
            this.txtSessionID.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtSessionID.Properties.Mask.ShowPlaceHolders")));
            this.txtSessionID.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtSessionID.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtSessionID.Properties.NullValuePrompt = resources.GetString("txtSessionID.Properties.NullValuePrompt");
            this.txtSessionID.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtSessionID.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // txtFieldID
            // 
            resources.ApplyResources(this.txtFieldID, "txtFieldID");
            this.txtFieldID.Name = "txtFieldID";
            this.txtFieldID.Properties.AccessibleDescription = resources.GetString("txtFieldID.Properties.AccessibleDescription");
            this.txtFieldID.Properties.AccessibleName = resources.GetString("txtFieldID.Properties.AccessibleName");
            this.txtFieldID.Properties.AutoHeight = ((bool)(resources.GetObject("txtFieldID.Properties.AutoHeight")));
            this.txtFieldID.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtFieldID.Properties.Mask.AutoComplete")));
            this.txtFieldID.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtFieldID.Properties.Mask.BeepOnError")));
            this.txtFieldID.Properties.Mask.EditMask = resources.GetString("txtFieldID.Properties.Mask.EditMask");
            this.txtFieldID.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtFieldID.Properties.Mask.IgnoreMaskBlank")));
            this.txtFieldID.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtFieldID.Properties.Mask.MaskType")));
            this.txtFieldID.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtFieldID.Properties.Mask.PlaceHolder")));
            this.txtFieldID.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtFieldID.Properties.Mask.SaveLiteral")));
            this.txtFieldID.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtFieldID.Properties.Mask.ShowPlaceHolders")));
            this.txtFieldID.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtFieldID.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtFieldID.Properties.NullValuePrompt = resources.GetString("txtFieldID.Properties.NullValuePrompt");
            this.txtFieldID.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtFieldID.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // txtPoolVectorID
            // 
            resources.ApplyResources(this.txtPoolVectorID, "txtPoolVectorID");
            this.txtPoolVectorID.Name = "txtPoolVectorID";
            this.txtPoolVectorID.Properties.AccessibleDescription = resources.GetString("txtPoolVectorID.Properties.AccessibleDescription");
            this.txtPoolVectorID.Properties.AccessibleName = resources.GetString("txtPoolVectorID.Properties.AccessibleName");
            this.txtPoolVectorID.Properties.AutoHeight = ((bool)(resources.GetObject("txtPoolVectorID.Properties.AutoHeight")));
            this.txtPoolVectorID.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtPoolVectorID.Properties.Mask.AutoComplete")));
            this.txtPoolVectorID.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtPoolVectorID.Properties.Mask.BeepOnError")));
            this.txtPoolVectorID.Properties.Mask.EditMask = resources.GetString("txtPoolVectorID.Properties.Mask.EditMask");
            this.txtPoolVectorID.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtPoolVectorID.Properties.Mask.IgnoreMaskBlank")));
            this.txtPoolVectorID.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtPoolVectorID.Properties.Mask.MaskType")));
            this.txtPoolVectorID.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtPoolVectorID.Properties.Mask.PlaceHolder")));
            this.txtPoolVectorID.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtPoolVectorID.Properties.Mask.SaveLiteral")));
            this.txtPoolVectorID.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtPoolVectorID.Properties.Mask.ShowPlaceHolders")));
            this.txtPoolVectorID.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtPoolVectorID.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtPoolVectorID.Properties.NullValuePrompt = resources.GetString("txtPoolVectorID.Properties.NullValuePrompt");
            this.txtPoolVectorID.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtPoolVectorID.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // lblVectorType
            // 
            resources.ApplyResources(this.lblVectorType, "lblVectorType");
            this.lblVectorType.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblVectorType.Appearance.DisabledImage")));
            this.lblVectorType.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblVectorType.Appearance.FontSizeDelta")));
            this.lblVectorType.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblVectorType.Appearance.FontStyleDelta")));
            this.lblVectorType.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblVectorType.Appearance.GradientMode")));
            this.lblVectorType.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblVectorType.Appearance.HoverImage")));
            this.lblVectorType.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblVectorType.Appearance.Image")));
            this.lblVectorType.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblVectorType.Appearance.PressedImage")));
            this.lblVectorType.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblVectorType.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblVectorType.Name = "lblVectorType";
            // 
            // lblSessionID
            // 
            resources.ApplyResources(this.lblSessionID, "lblSessionID");
            this.lblSessionID.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblSessionID.Appearance.DisabledImage")));
            this.lblSessionID.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblSessionID.Appearance.FontSizeDelta")));
            this.lblSessionID.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblSessionID.Appearance.FontStyleDelta")));
            this.lblSessionID.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblSessionID.Appearance.GradientMode")));
            this.lblSessionID.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblSessionID.Appearance.HoverImage")));
            this.lblSessionID.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblSessionID.Appearance.Image")));
            this.lblSessionID.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblSessionID.Appearance.PressedImage")));
            this.lblSessionID.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblSessionID.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblSessionID.Name = "lblSessionID";
            // 
            // lblPoolVectorID
            // 
            resources.ApplyResources(this.lblPoolVectorID, "lblPoolVectorID");
            this.lblPoolVectorID.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblPoolVectorID.Appearance.DisabledImage")));
            this.lblPoolVectorID.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblPoolVectorID.Appearance.FontSizeDelta")));
            this.lblPoolVectorID.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblPoolVectorID.Appearance.FontStyleDelta")));
            this.lblPoolVectorID.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblPoolVectorID.Appearance.GradientMode")));
            this.lblPoolVectorID.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblPoolVectorID.Appearance.HoverImage")));
            this.lblPoolVectorID.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblPoolVectorID.Appearance.Image")));
            this.lblPoolVectorID.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblPoolVectorID.Appearance.PressedImage")));
            this.lblPoolVectorID.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblPoolVectorID.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblPoolVectorID.Name = "lblPoolVectorID";
            // 
            // lblFieldID
            // 
            resources.ApplyResources(this.lblFieldID, "lblFieldID");
            this.lblFieldID.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblFieldID.Appearance.DisabledImage")));
            this.lblFieldID.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblFieldID.Appearance.FontSizeDelta")));
            this.lblFieldID.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblFieldID.Appearance.FontStyleDelta")));
            this.lblFieldID.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblFieldID.Appearance.GradientMode")));
            this.lblFieldID.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblFieldID.Appearance.HoverImage")));
            this.lblFieldID.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblFieldID.Appearance.Image")));
            this.lblFieldID.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblFieldID.Appearance.PressedImage")));
            this.lblFieldID.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFieldID.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
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
            ((System.ComponentModel.ISupportInitialize)(this.dtIdentificationDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIdentificationDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leIdentificationMethod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leIdentifiedBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leSex.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leIdentifiedByInstitution.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leSpecies.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCollectionData)).EndInit();
            this.gcCollectionData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.leEctoparasitesCollected.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bppLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seElevation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leBasisOfRecord.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leHostGuestReference.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leCollectionMethod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leCollectionTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCollectionDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCollectionDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leCollector.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leCollectedByInstitution.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGeoReference.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leSurrounding.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.leVectorType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSessionID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFieldID.Properties)).EndInit();
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
        private DevExpress.XtraEditors.LookUpEdit leSpecies;
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
        private DevExpress.XtraEditors.TextEdit txtPoolVectorID;
        private DevExpress.XtraEditors.LabelControl lblSessionID;
        private Location.LocationLookup bppLocation;
        private DevExpress.XtraEditors.LookUpEdit leEctoparasitesCollected;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit leVectorType;
        private DevExpress.XtraTab.XtraTabPage tpFieldTests;
        private DevExpress.XtraTab.XtraTabPage tpLabTests;
    }
}
