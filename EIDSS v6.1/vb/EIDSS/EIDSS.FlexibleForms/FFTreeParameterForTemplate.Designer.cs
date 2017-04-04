namespace EIDSS.FlexibleForms
{
    partial class FFTreeParameterForTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FFTreeParameterForTemplate));
            this.treeParametersLibrary = new DevExpress.XtraTreeList.TreeList();
            this.trlcTreeListParametersColumn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imglstTree = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.treeParametersLibrary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imglstTree)).BeginInit();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(FFTreeParameterForTemplate), out resources);
            // Form Is Localizable: True
            // 
            // treeParametersLibrary
            // 
            this.treeParametersLibrary.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.trlcTreeListParametersColumn});
            resources.ApplyResources(this.treeParametersLibrary, "treeParametersLibrary");
            this.treeParametersLibrary.Name = "treeParametersLibrary";
            this.treeParametersLibrary.OptionsSelection.MultiSelect = true;
            this.treeParametersLibrary.SelectImageList = this.imglstTree;
            this.treeParametersLibrary.StateImageList = this.imglstTree;
            this.treeParametersLibrary.BeforeExpand += new DevExpress.XtraTreeList.BeforeExpandEventHandler(this.OnTreeParametersLibraryBeforeExpand);
            // 
            // trlcTreeListParametersColumn
            // 
            resources.ApplyResources(this.trlcTreeListParametersColumn, "trlcTreeListParametersColumn");
            this.trlcTreeListParametersColumn.Name = "trlcTreeListParametersColumn";
            this.trlcTreeListParametersColumn.OptionsColumn.AllowEdit = false;
            this.trlcTreeListParametersColumn.OptionsColumn.AllowMove = false;
            this.trlcTreeListParametersColumn.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.trlcTreeListParametersColumn.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // imglstTree
            // 
            this.imglstTree.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imglstTree.ImageStream")));
            this.imglstTree.Images.SetKeyName(0, "Books.bmp");
            this.imglstTree.Images.SetKeyName(1, "File Documents.bmp");
            this.imglstTree.Images.SetKeyName(2, "Window.bmp");
            this.imglstTree.Images.SetKeyName(3, "Report.png");
            this.imglstTree.Images.SetKeyName(6, "Calendar.bmp");
            // 
            // FFTreeParameterForTemplate
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.treeParametersLibrary);
            this.DefaultFormState = System.Windows.Forms.FormWindowState.Normal;
            this.FormID = "F04";
            this.HelpTopicID = "Form_Design";
            this.Name = "FFTreeParameterForTemplate";
            this.ShowDeleteButton = false;
            this.ShowSaveButton = false;
            this.Status = bv.common.win.FormStatus.Draft;
            this.Load += new System.EventHandler(this.OnFFTreeParameterForTemplateLoad);
            this.Controls.SetChildIndex(this.treeParametersLibrary, 0);
            ((System.ComponentModel.ISupportInitialize)(this.treeParametersLibrary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imglstTree)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeParametersLibrary;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trlcTreeListParametersColumn;
        private DevExpress.Utils.ImageCollection imglstTree;
    }
}
