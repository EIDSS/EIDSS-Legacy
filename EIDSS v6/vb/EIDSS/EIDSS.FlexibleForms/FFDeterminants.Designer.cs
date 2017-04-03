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
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(FFDeterminants), out resources);
            // Form Is Localizable: True
            // 
            // treeDeterminant
            // 
            this.treeDeterminant.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colDeterminantName});
            resources.ApplyResources(this.treeDeterminant, "treeDeterminant");
            this.treeDeterminant.Name = "treeDeterminant";
            this.treeDeterminant.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.repositoryItemCheckedComboBoxEdit1});
            this.treeDeterminant.Click += new System.EventHandler(this.OnTreeDeterminantClick);
            this.treeDeterminant.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnTreeDeterminantKeyUp);
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
            resources.ApplyResources(this.repositoryItemLookUpEdit1, "repositoryItemLookUpEdit1");
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemLookUpEdit1.Buttons"))))});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.ShowFooter = false;
            this.repositoryItemLookUpEdit1.ShowHeader = false;
            // 
            // repositoryItemCheckedComboBoxEdit1
            // 
            resources.ApplyResources(this.repositoryItemCheckedComboBoxEdit1, "repositoryItemCheckedComboBoxEdit1");
            this.repositoryItemCheckedComboBoxEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemCheckedComboBoxEdit1.Buttons"))))});
            this.repositoryItemCheckedComboBoxEdit1.CloseOnLostFocus = false;
            this.repositoryItemCheckedComboBoxEdit1.CloseOnOuterMouseClick = false;
            this.repositoryItemCheckedComboBoxEdit1.Name = "repositoryItemCheckedComboBoxEdit1";
            this.repositoryItemCheckedComboBoxEdit1.ShowButtons = false;
            this.repositoryItemCheckedComboBoxEdit1.ValueMember = "Actions";
            // 
            // grpSearchParameter
            // 
            this.grpSearchParameter.Controls.Add(this.lbSearchParameterResults);
            this.grpSearchParameter.Controls.Add(this.pnlSearchParameters);
            resources.ApplyResources(this.grpSearchParameter, "grpSearchParameter");
            this.grpSearchParameter.Name = "grpSearchParameter";
            // 
            // lbSearchParameterResults
            // 
            this.lbSearchParameterResults.DisplayMember = "FullPathStr";
            resources.ApplyResources(this.lbSearchParameterResults, "lbSearchParameterResults");
            this.lbSearchParameterResults.Name = "lbSearchParameterResults";
            this.lbSearchParameterResults.ValueMember = "idfsParameterID";
            this.lbSearchParameterResults.Click += new System.EventHandler(this.OnLbSearchParameterResultsClick);
            // 
            // pnlSearchParameters
            // 
            this.pnlSearchParameters.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlSearchParameters.Controls.Add(this.cbSearchParameterCriteria);
            this.pnlSearchParameters.Controls.Add(this.lSearchParameterResults);
            this.pnlSearchParameters.Controls.Add(this.bSearchParameterStart);
            this.pnlSearchParameters.Controls.Add(this.labelControl1);
            resources.ApplyResources(this.pnlSearchParameters, "pnlSearchParameters");
            this.pnlSearchParameters.Name = "pnlSearchParameters";
            // 
            // cbSearchParameterCriteria
            // 
            resources.ApplyResources(this.cbSearchParameterCriteria, "cbSearchParameterCriteria");
            this.cbSearchParameterCriteria.Name = "cbSearchParameterCriteria";
            this.cbSearchParameterCriteria.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbSearchParameterCriteria.Properties.Buttons"))))});
            // 
            // lSearchParameterResults
            // 
            resources.ApplyResources(this.lSearchParameterResults, "lSearchParameterResults");
            this.lSearchParameterResults.Name = "lSearchParameterResults";
            // 
            // bSearchParameterStart
            // 
            resources.ApplyResources(this.bSearchParameterStart, "bSearchParameterStart");
            this.bSearchParameterStart.Name = "bSearchParameterStart";
            this.bSearchParameterStart.Click += new System.EventHandler(this.OnBSearchParameterStartClick);
            // 
            // labelControl1
            // 
            resources.ApplyResources(this.labelControl1, "labelControl1");
            this.labelControl1.Name = "labelControl1";
            // 
            // FFDeterminants
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.grpSearchParameter);
            this.Controls.Add(this.treeDeterminant);
            this.DefaultFormState = System.Windows.Forms.FormWindowState.Normal;
            this.FormID = "F03";
            this.HelpTopicID = "Form_Design";
            this.Name = "FFDeterminants";
            this.ShowDeleteButton = false;
            this.ShowSaveButton = false;
            this.Status = bv.common.win.FormStatus.Draft;
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
