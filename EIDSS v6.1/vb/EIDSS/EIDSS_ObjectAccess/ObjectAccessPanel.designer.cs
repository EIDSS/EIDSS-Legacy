using System.ComponentModel;
using System.Windows.Forms;

namespace EIDSS
{
    public partial  class ObjectAccessPanel
    {

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectAccessPanel));
            this.label1 = new System.Windows.Forms.Label();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.checkboxImageList = new System.Windows.Forms.ImageList(this.components);
            this.gridActors = new DevExpress.XtraGrid.GridControl();
            this.gridActorsView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSite = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridPermissions = new DevExpress.XtraGrid.GridControl();
            this.gridPermissionsView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDeny = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAllow = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colOperation = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridActors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridActorsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPermissions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPermissionsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(ObjectAccessPanel), out resources);
            // Form Is Localizable: True
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // simpleButton1
            // 
            resources.ApplyResources(this.simpleButton1, "simpleButton1");
            this.simpleButton1.Image = global::EIDSS_ObjectAccess.Properties.Resources.add;
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.btnActorAdd_Click);
            // 
            // simpleButton2
            // 
            resources.ApplyResources(this.simpleButton2, "simpleButton2");
            this.simpleButton2.Image = global::EIDSS_ObjectAccess.Properties.Resources.Delete_Remove;
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Click += new System.EventHandler(this.btnActorDelete_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // checkboxImageList
            // 
            this.checkboxImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("checkboxImageList.ImageStream")));
            this.checkboxImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.checkboxImageList.Images.SetKeyName(0, "");
            this.checkboxImageList.Images.SetKeyName(1, "");
            // 
            // gridActors
            // 
            resources.ApplyResources(this.gridActors, "gridActors");
            this.gridActors.MainView = this.gridActorsView;
            this.gridActors.Name = "gridActors";
            this.gridActors.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridActorsView});
            // 
            // gridActorsView
            // 
            this.gridActorsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSite,
            this.colType,
            this.colName});
            this.gridActorsView.GridControl = this.gridActors;
            this.gridActorsView.Name = "gridActorsView";
            this.gridActorsView.OptionsBehavior.Editable = false;
            this.gridActorsView.OptionsView.ShowGroupPanel = false;
            this.gridActorsView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridActorsView_FocusedRowChanged);
            // 
            // colSite
            // 
            resources.ApplyResources(this.colSite, "colSite");
            this.colSite.FieldName = "strSiteID";
            this.colSite.Name = "colSite";
            // 
            // colType
            // 
            resources.ApplyResources(this.colType, "colType");
            this.colType.FieldName = "EmployeeTypeName";
            this.colType.Name = "colType";
            // 
            // colName
            // 
            resources.ApplyResources(this.colName, "colName");
            this.colName.FieldName = "strName";
            this.colName.Name = "colName";
            // 
            // gridPermissions
            // 
            resources.ApplyResources(this.gridPermissions, "gridPermissions");
            this.gridPermissions.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridPermissions.MainView = this.gridPermissionsView;
            this.gridPermissions.Name = "gridPermissions";
            this.gridPermissions.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridPermissions.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridPermissionsView});
            // 
            // gridPermissionsView
            // 
            this.gridPermissionsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDeny,
            this.colAllow,
            this.colOperation});
            this.gridPermissionsView.GridControl = this.gridPermissions;
            this.gridPermissionsView.Name = "gridPermissionsView";
            this.gridPermissionsView.OptionsView.ShowGroupPanel = false;
            this.gridPermissionsView.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridPermissionsView_CellValueChanging);
            this.gridPermissionsView.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridPermissionsView_CustomUnboundColumnData);
            // 
            // colDeny
            // 
            resources.ApplyResources(this.colDeny, "colDeny");
            this.colDeny.FieldName = "colDeny";
            this.colDeny.Name = "colDeny";
            this.colDeny.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            // 
            // colAllow
            // 
            resources.ApplyResources(this.colAllow, "colAllow");
            this.colAllow.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colAllow.FieldName = "colAllow";
            this.colAllow.Name = "colAllow";
            this.colAllow.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            // 
            // repositoryItemCheckEdit1
            // 
            resources.ApplyResources(this.repositoryItemCheckEdit1, "repositoryItemCheckEdit1");
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // colOperation
            // 
            resources.ApplyResources(this.colOperation, "colOperation");
            this.colOperation.FieldName = "name";
            this.colOperation.Name = "colOperation";
            this.colOperation.OptionsColumn.AllowEdit = false;
            // 
            // ObjectAccessPanel
            // 
            this.Controls.Add(this.gridPermissions);
            this.Controls.Add(this.gridActors);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.label1);
            this.DefaultFormState = System.Windows.Forms.FormWindowState.Normal;
            this.Name = "ObjectAccessPanel";
            resources.ApplyResources(this, "$this");
            this.Status = bv.common.win.FormStatus.Draft;
            ((System.ComponentModel.ISupportInitialize)(this.gridActors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridActorsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPermissions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPermissionsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private IContainer components;
       
    }
}