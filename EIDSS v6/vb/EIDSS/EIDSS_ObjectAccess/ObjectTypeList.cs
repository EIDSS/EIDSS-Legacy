using System;
using System.Data;
using System.Windows.Forms;
using bv.common;
using bv.common.Core;
using bv.common.win;
using bv.common.Objects;
using bv.winclient.BasePanel;
using DevExpress.Utils;
using System.Collections;
using bv.winclient.Core;
using eidss.model.Enums;

namespace EIDSS
{
	/// <summary>
	/// Summary description for ObjectTypeList.
	/// </summary>
	public class ObjectTypeList : BaseDetailForm
	{
		//private bool configuratorMode=false;
		private ObjectTypeList_DB typedDBLevel = null;
		//Hashtable relations=new Hashtable();
        private DataView MainView;
		//private Hashtable checks=new Hashtable();

		private static System.Windows.Forms.Control m_Parent = null;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit relationLookUpEdit;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;


		public ObjectTypeList()
		{
			InitializeComponent();
            this.AuditObject = new bv.common.Objects.AuditObject((long)EIDSSAuditObject.daoDataAccess, (long)AuditTable.tstObjectAccess);
            this.PermissionObject = eidss.model.Enums.EIDSSPermissionObject.DataAccess;
            this.Permissions = new StandardAccessPermissions(
                PermissionHelper.SelectPermission (eidss.model.Enums.EIDSSPermissionObject.DataAccess),
                PermissionHelper.SelectPermission (eidss.model.Enums.EIDSSPermissionObject.DataAccess),
                PermissionHelper.SelectPermission (eidss.model.Enums.EIDSSPermissionObject.DataAccess),
                PermissionHelper.DeletePermission (eidss.model.Enums.EIDSSPermissionObject.DataAccess),
                PermissionHelper.ExecutePermission (eidss.model.Enums.EIDSSPermissionObject.DataAccess)
                );
            //this.configuratorMode = eidss.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission(eidss.model.Enums.EIDSSPermissionObject.DataAccess));
            this.typedDBLevel = new ObjectTypeList_DB();
            this.DbService = this.typedDBLevel;
        }

		#region Designer
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectTypeList));
            this.label1 = new System.Windows.Forms.Label();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.relationLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.relationLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(ObjectTypeList), out resources);
            // Form Is Localizable: True
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lookUpEdit1
            // 
            resources.ApplyResources(this.lookUpEdit1, "lookUpEdit1");
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("lookUpEdit1.Properties.Buttons"))))});
            this.lookUpEdit1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lookUpEdit1.Properties.Columns"), resources.GetString("lookUpEdit1.Properties.Columns1"), ((int)(resources.GetObject("lookUpEdit1.Properties.Columns2"))), ((DevExpress.Utils.FormatType)(resources.GetObject("lookUpEdit1.Properties.Columns3"))), resources.GetString("lookUpEdit1.Properties.Columns4"), ((bool)(resources.GetObject("lookUpEdit1.Properties.Columns5"))), ((DevExpress.Utils.HorzAlignment)(resources.GetObject("lookUpEdit1.Properties.Columns6"))), ((DevExpress.Data.ColumnSortOrder)(resources.GetObject("lookUpEdit1.Properties.Columns7"))))});
            this.lookUpEdit1.Properties.DisplayMember = "ParentName";
            this.lookUpEdit1.Properties.ShowHeader = false;
            this.lookUpEdit1.Properties.ValueMember = "idfsParentBaseReference";
            this.lookUpEdit1.Tag = "{alwayseditable}";
            this.lookUpEdit1.EditValueChanged += new System.EventHandler(this.lookUpEdit1_EditValueChanged);
            // 
            // simpleButton2
            // 
            resources.ApplyResources(this.simpleButton2, "simpleButton2");
            this.simpleButton2.Image = global::EIDSS_ObjectAccess.Properties.Resources.Permissions__small__67_;
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // gridControl1
            // 
            resources.ApplyResources(this.gridControl1, "gridControl1");
            this.gridControl1.MainView = this.gridView2;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.relationLookUpEdit});
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn4});
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Font = ((System.Drawing.Font)(resources.GetObject("gridColumn1.AppearanceHeader.Font")));
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            resources.ApplyResources(this.gridColumn1, "gridColumn1");
            this.gridColumn1.FieldName = "ChildName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Font = ((System.Drawing.Font)(resources.GetObject("gridColumn4.AppearanceHeader.Font")));
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            resources.ApplyResources(this.gridColumn4, "gridColumn4");
            this.gridColumn4.ColumnEdit = this.relationLookUpEdit;
            this.gridColumn4.FieldName = "idfsStatus";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // relationLookUpEdit
            // 
            resources.ApplyResources(this.relationLookUpEdit, "relationLookUpEdit");
            this.relationLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("relationLookUpEdit.Buttons"))))});
            this.relationLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("relationLookUpEdit.Columns"), resources.GetString("relationLookUpEdit.Columns1"))});
            this.relationLookUpEdit.DisplayMember = "Name";
            this.relationLookUpEdit.Name = "relationLookUpEdit";
            this.relationLookUpEdit.ShowHeader = false;
            this.relationLookUpEdit.ValueMember = "idfsReference";
            // 
            // repositoryItemComboBox1
            // 
            resources.ApplyResources(this.repositoryItemComboBox1, "repositoryItemComboBox1");
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemComboBox1.Buttons"))))});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.repositoryItemComboBox1.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.DoubleClick;
            this.repositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // ObjectTypeList
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.lookUpEdit1);
            this.Controls.Add(this.label1);
            this.DefaultFormState = System.Windows.Forms.FormWindowState.Normal;
            this.FormID = "A18";
            this.HelpTopicID = "Administration_Configuration";
            this.LeftIcon = global::EIDSS_ObjectAccess.Properties.Resources.Data_Access_Types__large__30_1_;
            this.Name = "ObjectTypeList";
            this.ShowDeleteButton = false;
            this.Status = bv.common.win.FormStatus.Draft;
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lookUpEdit1, 0);
            this.Controls.SetChildIndex(this.simpleButton2, 0);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.relationLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		protected override void DefineBinding()
		{
			base.DefineBinding();
            //this.State = BusinessObjectState.EditObject;

            Core.LookupBinder.BindBaseRepositoryLookup(relationLookUpEdit, bv.common.db.BaseReferenceType.rftObjectTypeRelation, false);

			DataTable main=this.baseDataSet.Tables["ObjectTypeTree"];
            MainView = new DataView(main);
            this.gridControl1.DataSource = MainView;
            //this.relationLookUpEdit.DataSource = baseDataSet.Tables["RelationType"];

            Core.LookupBinder.BindBaseLookup(this.lookUpEdit1, this.baseDataSet, null, bv.common.db.BaseReferenceType.rftObjectType, false, false);
            DataView types = (DataView)this.lookUpEdit1.Properties.DataSource;
            types.RowFilter = "idfsReference in (10060001, 10060011)";
			//Core.LookupBinder.SetDataSource(this.lookUpEdit1, types.DefaultView, "ParentName", "idfsParentBaseReference");
            if(types.Count>0)
                this.lookUpEdit1.EditValue = types[0]["idfsReference"];

		}
        //TODO:(Mike) Check that Object access rights are working
        //public static void Register(System.Windows.Forms.Control parentControl)
        //{
        //    if (BaseFormManager.ArchiveMode)
        //        return;
        //    m_Parent = parentControl;
        //    MenuAction menuAction = new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Security, "MenuObjectTypeList", 1020, false, (int)MenuIconsSmall.DataAccessTypes, -1);
        //    menuAction.SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.DataAccess);
        //}

		public static void ShowMe()
		{
		    object id = null;
			BaseFormManager.ShowClient(new ObjectTypeList(), m_Parent, ref id);
		}

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			base.DoClose();
		}

        private void lookUpEdit1_EditValueChanged(object sender, System.EventArgs e)
		{
            if(Utils.IsEmpty(this.lookUpEdit1.EditValue))return;
            MainView.RowFilter = "idfsParentObjectType=" + this.lookUpEdit1.EditValue.ToString();
		}

		private void simpleButton2_Click(object sender, System.EventArgs e)
		{
            if (Utils.IsEmpty(lookUpEdit1.EditValue))
                return;
			ObjectType current= (ObjectType)lookUpEdit1.EditValue;

            object empty = current;
			ObjectAccessDetail objectAccessDetail = new ObjectAccessDetail(current);
            BaseFormManager.ShowModal(objectAccessDetail, FindForm(), ref empty, null, null, 0, 0);
		}

	}
}
