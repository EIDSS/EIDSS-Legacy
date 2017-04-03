namespace EIDSS.FlexibleForms
{
    partial class FFDeterminants
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FFDeterminants));
            this.treeDeterminant = new DevExpress.XtraTreeList.TreeList();
            this.colDeterminantName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemCheckedComboBoxEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            this.grpSearchParameter = new DevExpress.XtraEditors.GroupControl();
            this.lbSearchParameterResults = new DevExpress.XtraEditors.ListBoxControl();
            this.pnlSearchParameters = new DevExpress.XtraEditors.PanelControl();
            this.cbSearchParameterCriteria = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lSearchParameterResults = new DevExpress.XtraEditors.LabelControl();
            this.bSearchParameterStart = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.treeDeterminant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpSearchParameter)).BeginInit();
            this.grpSearchParameter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbSearchParameterResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSearchParameters)).BeginInit();
            this.pnlSearchParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbSearchParameterCriteria.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // treeDeterminant
            // 
            this.treeDeterminant.AccessibleDescription = null;
            this.treeDeterminant.AccessibleName = null;
            resources.ApplyResources(this.treeDeterminant, "treeDeterminant");
            this.treeDeterminant.BackgroundImage = null;
            this.treeDeterminant.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colDeterminantName});
            this.treeDeterminant.Font = null;
            this.treeDeterminant.Name = "treeDeterminant";
            this.treeDeterminant.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.repositoryItemCheckedComboBoxEdit1});
            this.treeDeterminant.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnTreeDeterminantKeyUp);
            this.treeDeterminant.Click += new System.EventHandler(this.OnTreeDeterminantClick);
            // 
            // colDeterminantName
            // 
            resources.ApplyResources(this.colDeterminantName, "colDeterminantName");
            this.colDeterminantName.FieldName = "idfsParameter";
            this.colDeterminantName.Name = "colDeterminantName";
            this.colDeterminantName.OptionsColumn.AllowEdit = false;
            this.colDeterminantName.OptionsColumn.AllowMove = false;
            this.colDeterminantName.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.colDeterminantName.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AccessibleDescription = null;
            this.repositoryItemLookUpEdit1.AccessibleName = null;
            resources.ApplyResources(this.repositoryItemLookUpEdit1, "repositoryItemLookUpEdit1");
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemLookUpEdit1.Buttons"))))});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.ShowFooter = false;
            this.repositoryItemLookUpEdit1.ShowHeader = false;
            // 
            // repositoryItemCheckedComboBoxEdit1
            // 
            this.repositoryItemCheckedComboBoxEdit1.AccessibleDescription = null;
            this.repositoryItemCheckedComboBoxEdit1.AccessibleName = null;
            resources.ApplyResources(this.repositoryItemCheckedComboBoxEdit1, "repositoryItemCheckedComboBoxEdit1");
            this.repositoryItemCheckedComboBoxEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemCheckedComboBoxEdit1.Buttons"))))});
            this.repositoryItemCheckedComboBoxEdit1.CloseOnLostFocus = false;
            this.repositoryItemCheckedComboBoxEdit1.CloseOnOuterMouseClick = false;
            this.repositoryItemCheckedComboBoxEdit1.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("repositoryItemCheckedComboBoxEdit1.Mask.AutoComplete")));
            this.repositoryItemCheckedComboBoxEdit1.Mask.BeepOnError = ((bool)(resources.GetObject("repositoryItemCheckedComboBoxEdit1.Mask.BeepOnError")));
            this.repositoryItemCheckedComboBoxEdit1.Mask.EditMask = resources.GetString("repositoryItemCheckedComboBoxEdit1.Mask.EditMask");
            this.repositoryItemCheckedComboBoxEdit1.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("repositoryItemCheckedComboBoxEdit1.Mask.IgnoreMaskBlank")));
            this.repositoryItemCheckedComboBoxEdit1.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("repositoryItemCheckedComboBoxEdit1.Mask.MaskType")));
            this.repositoryItemCheckedComboBoxEdit1.Mask.PlaceHolder = ((char)(resources.GetObject("repositoryItemCheckedComboBoxEdit1.Mask.PlaceHolder")));
            this.repositoryItemCheckedComboBoxEdit1.Mask.SaveLiteral = ((bool)(resources.GetObject("repositoryItemCheckedComboBoxEdit1.Mask.SaveLiteral")));
            this.repositoryItemCheckedComboBoxEdit1.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("repositoryItemCheckedComboBoxEdit1.Mask.ShowPlaceHolders")));
            this.repositoryItemCheckedComboBoxEdit1.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("repositoryItemCheckedComboBoxEdit1.Mask.UseMaskAsDisplayFormat")));
            this.repositoryItemCheckedComboBoxEdit1.Name = "repositoryItemCheckedComboBoxEdit1";
            this.repositoryItemCheckedComboBoxEdit1.ShowButtons = false;
            this.repositoryItemCheckedComboBoxEdit1.ValueMember = "Actions";
            // 
            // grpSearchParameter
            // 
            this.grpSearchParameter.AccessibleDescription = null;
            this.grpSearchParameter.AccessibleName = null;
            resources.ApplyResources(this.grpSearchParameter, "grpSearchParameter");
            this.grpSearchParameter.Controls.Add(this.lbSearchParameterResults);
            this.grpSearchParameter.Controls.Add(this.pnlSearchParameters);
            this.grpSearchParameter.Name = "grpSearchParameter";
            // 
            // lbSearchParameterResults
            // 
            this.lbSearchParameterResults.AccessibleDescription = null;
            this.lbSearchParameterResults.AccessibleName = null;
            resources.ApplyResources(this.lbSearchParameterResults, "lbSearchParameterResults");
            this.lbSearchParameterResults.BackgroundImage = null;
            this.lbSearchParameterResults.DisplayMember = "FullPathStr";
            this.lbSearchParameterResults.Name = "lbSearchParameterResults";
            this.lbSearchParameterResults.ValueMember = "idfsParameterID";
            this.lbSearchParameterResults.Click += new System.EventHandler(this.OnLbSearchParameterResultsClick);
            // 
            // pnlSearchParameters
            // 
            this.pnlSearchParameters.AccessibleDescription = null;
            this.pnlSearchParameters.AccessibleName = null;
            resources.ApplyResources(this.pnlSearchParameters, "pnlSearchParameters");
            this.pnlSearchParameters.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlSearchParameters.Controls.Add(this.cbSearchParameterCriteria);
            this.pnlSearchParameters.Controls.Add(this.lSearchParameterResults);
            this.pnlSearchParameters.Controls.Add(this.bSearchParameterStart);
            this.pnlSearchParameters.Controls.Add(this.labelControl1);
            this.pnlSearchParameters.Name = "pnlSearchParameters";
            // 
            // cbSearchParameterCriteria
            // 
            resources.ApplyResources(this.cbSearchParameterCriteria, "cbSearchParameterCriteria");
            this.cbSearchParameterCriteria.BackgroundImage = null;
            this.cbSearchParameterCriteria.EditValue = null;
            this.cbSearchParameterCriteria.Name = "cbSearchParameterCriteria";
            this.cbSearchParameterCriteria.Properties.AccessibleDescription = null;
            this.cbSearchParameterCriteria.Properties.AccessibleName = null;
            this.cbSearchParameterCriteria.Properties.AutoHeight = ((bool)(resources.GetObject("cbSearchParameterCriteria.Properties.AutoHeight")));
            this.cbSearchParameterCriteria.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbSearchParameterCriteria.Properties.Buttons"))))});
            this.cbSearchParameterCriteria.Properties.NullValuePrompt = resources.GetString("cbSearchParameterCriteria.Properties.NullValuePrompt");
            this.cbSearchParameterCriteria.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cbSearchParameterCriteria.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // lSearchParameterResults
            // 
            this.lSearchParameterResults.AccessibleDescription = null;
            this.lSearchParameterResults.AccessibleName = null;
            resources.ApplyResources(this.lSearchParameterResults, "lSearchParameterResults");
            this.lSearchParameterResults.Name = "lSearchParameterResults";
            // 
            // bSearchParameterStart
            // 
            this.bSearchParameterStart.AccessibleDescription = null;
            this.bSearchParameterStart.AccessibleName = null;
            resources.ApplyResources(this.bSearchParameterStart, "bSearchParameterStart");
            this.bSearchParameterStart.BackgroundImage = null;
            this.bSearchParameterStart.Name = "bSearchParameterStart";
            this.bSearchParameterStart.Click += new System.EventHandler(this.OnBSearchParameterStartClick);
            // 
            // labelControl1
            // 
            this.labelControl1.AccessibleDescription = null;
            this.labelControl1.AccessibleName = null;
            resources.ApplyResources(this.labelControl1, "labelControl1");
            this.labelControl1.Name = "labelControl1";
            // 
            // FFDeterminants
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.grpSearchParameter);
            this.Controls.Add(this.treeDeterminant);
            this.FormID = "F03";
            this.Name = "FFDeterminants";
            this.ShowDeleteButton = false;
            this.ShowSaveButton = false;
            this.Load += new System.EventHandler(this.OnFFDeterminantsLoad);
            this.Controls.SetChildIndex(this.treeDeterminant, 0);
            this.Controls.SetChildIndex(this.grpSearchParameter, 0);
            ((System.ComponentModel.ISupportInitialize)(this.treeDeterminant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpSearchParameter)).EndInit();
            this.grpSearchParameter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbSearchParameterResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSearchParameters)).EndInit();
            this.pnlSearchParameters.ResumeLayout(false);
            this.pnlSearchParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbSearchParameterCriteria.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeDeterminant;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDeterminantName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit repositoryItemCheckedComboBoxEdit1;
        private DevExpress.XtraEditors.GroupControl grpSearchParameter;
        private DevExpress.XtraEditors.ListBoxControl lbSearchParameterResults;
        private DevExpress.XtraEditors.PanelControl pnlSearchParameters;
        private DevExpress.XtraEditors.LabelControl lSearchParameterResults;
        private DevExpress.XtraEditors.SimpleButton bSearchParameterStart;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cbSearchParameterCriteria;
    }
}
