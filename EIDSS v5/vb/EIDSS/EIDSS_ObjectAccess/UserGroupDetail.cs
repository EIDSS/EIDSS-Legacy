using System;
using System.Windows.Forms;
using bv.common;
using bv.common.Core;
using bv.common.win;
using bv.common.db;

using System.Data;
using bv.winclient.BasePanel;
using bv.model.Model.Core;

namespace EIDSS
{
    /// <summary>
    /// Summary description for UserGroupDetail.
    /// </summary>
    public class UserGroupDetail : BaseDetailForm
    {
        private DataView deleted;
        private static System.Windows.Forms.Control m_Parent = null;
        private DevExpress.XtraEditors.TextEdit txtEnglishName;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraGrid.GridControl gridContent;
        private DevExpress.XtraGrid.Views.Grid.GridView gridGroupContentView;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.TextEdit ctlDescription;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtNationalName;
        private Label lbNationalName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnName;

        public UserGroupDetail()
        {
            InitializeComponent();
            this.ShowDeleteButton = false;
            this.DbService = new UserGroup_DB(null);
            this.AuditObject = new bv.common.Objects.AuditObject((long)EIDSSAuditObject.daoUserGroup, (long)AuditTable.tlbEmployeeGroup);
            this.PermissionObject = eidss.model.Enums.EIDSSPermissionObject.UserGroup;
            this.m_RelatedLists = new[] { "UserGroupListItem" };
            ;
        }

        #region Designer
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserGroupDetail));
            this.txtEnglishName = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.gridContent = new DevExpress.XtraGrid.GridControl();
            this.gridGroupContentView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.ctlDescription = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNationalName = new DevExpress.XtraEditors.TextEdit();
            this.lbNationalName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtEnglishName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGroupContentView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNationalName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdOk
            // 
            resources.ApplyResources(this.cmdOk, "cmdOk");
            // 
            // txtEnglishName
            // 
            resources.ApplyResources(this.txtEnglishName, "txtEnglishName");
            this.txtEnglishName.Name = "txtEnglishName";
            this.txtEnglishName.Tag = "{M}[en]";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // gridContent
            // 
            resources.ApplyResources(this.gridContent, "gridContent");
            this.gridContent.MainView = this.gridGroupContentView;
            this.gridContent.Name = "gridContent";
            this.gridContent.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridGroupContentView});
            // 
            // gridGroupContentView
            // 
            this.gridGroupContentView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnName});
            this.gridGroupContentView.GridControl = this.gridContent;
            this.gridGroupContentView.Name = "gridGroupContentView";
            this.gridGroupContentView.OptionsBehavior.Editable = false;
            this.gridGroupContentView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnName
            // 
            this.gridColumnName.AppearanceHeader.Options.UseFont = true;
            resources.ApplyResources(this.gridColumnName, "gridColumnName");
            this.gridColumnName.FieldName = "strName";
            this.gridColumnName.Name = "gridColumnName";
            // 
            // btnAdd
            // 
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ctlDescription
            // 
            resources.ApplyResources(this.ctlDescription, "ctlDescription");
            this.ctlDescription.Name = "ctlDescription";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtNationalName
            // 
            resources.ApplyResources(this.txtNationalName, "txtNationalName");
            this.txtNationalName.Name = "txtNationalName";
            this.txtNationalName.Tag = "[def]";
            // 
            // lbNationalName
            // 
            resources.ApplyResources(this.lbNationalName, "lbNationalName");
            this.lbNationalName.Name = "lbNationalName";
            // 
            // UserGroupDetail
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.txtNationalName);
            this.Controls.Add(this.lbNationalName);
            this.Controls.Add(this.ctlDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gridContent);
            this.Controls.Add(this.txtEnglishName);
            this.Controls.Add(this.label3);
            this.FormID = "A40";
            this.HelpTopicID = "UserGroupForm";
            this.KeyFieldName = "idfEmployeeGroup";
            this.LeftIcon = global::EIDSS_ObjectAccess.Properties.Resources.User_Group_133_;
            this.Name = "UserGroupDetail";
            this.ShowDeleteButton = false;
            this.Sizable = true;
            
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtEnglishName, 0);
            this.Controls.SetChildIndex(this.gridContent, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.ctlDescription, 0);
            this.Controls.SetChildIndex(this.lbNationalName, 0);
            this.Controls.SetChildIndex(this.txtNationalName, 0);
            ((System.ComponentModel.ISupportInitialize)(this.txtEnglishName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridContent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGroupContentView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNationalName.Properties)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        public static void ShowMe()
        {
            object id = null;
            BaseFormManager.ShowClient(new UserGroupDetail(), m_Parent, ref id);
        }


        protected override void DefineBinding()
        {
            Core.LookupBinder.BindTextEdit(txtEnglishName, this.baseDataSet, "Main.strName");
            Core.LookupBinder.BindTextEdit(txtNationalName, this.baseDataSet, "Main.strNationalName");
            Core.LookupBinder.BindTextEdit(ctlDescription, this.baseDataSet, "Main.strDescription");
            this.gridContent.DataSource = this.baseDataSet.Tables["Content"];
            deleted = new DataView(this.baseDataSet.Tables["Content"], null, "idfEmployee", DataViewRowState.Deleted);
            if (bv.model.Model.Core.ModelUserContext.CurrentLanguage == Localizer.lngEn)
            {
                this.txtNationalName.Visible = false;
                this.lbNationalName.Visible = false;
            }

        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            //object obstub = null;
            //UsersAndGroupsList UsersAndGroupsList = new UsersAndGroupsList();
            //UsersAndGroupsList.DbService.ListFilterCondition = string.Format("idfEmployee<>{0}", GetKey(null, null));
            IBaseListPanel UGList = (IBaseListPanel)ClassLoader.LoadClass("UserGroupMemberListPanel"); //TODO UsersAndGroupsListPanel
            var selection = BaseFormManager.ShowForMultiSelection(UGList, FindForm(), null, 0, 0);
            if (selection != null)
            {
                DataTable dataTable = this.baseDataSet.Tables["Content"];
                foreach (IObject ug in selection)
                {
                    try
                    {
                        object id = ug.Key;
                        if (id.Equals( this.GetKey(null,null)))
                            continue;
                        DataRowView[] recover = deleted.FindRows(id);
                        if (recover != null && recover.Length > 0)
                        {
                            recover[0].Row.RejectChanges();
                        }
                        else
                        {
                            DataRow newRow = dataTable.NewRow();
                            newRow["idfEmployee"] = ug.Key;
                            newRow["strName"] = ug.GetValue("strName");
                            newRow["strDescription"] = ug.GetValue("strDescription");
                            newRow["idfsEmployeeType"] = ug.GetValue("idfsEmployeeType");
                            dataTable.Rows.Add(newRow);
                        }
                    }
                    catch (ConstraintException)
                    {
                        //not a error, just duplicate
                    }
                }
                //dataTable = this.baseDataSet.Tables["Main"];
                //newRow = dataTable.Rows[0];
                //newRow["strName"] = newRow["strName"];
            }
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            int nRow;
            DataRow dataRow = null;
            DataTable dataTable = null;

            nRow = this.gridGroupContentView.FocusedRowHandle;
            dataRow = this.gridGroupContentView.GetDataRow(nRow);
            if (dataRow == null) return;
            dataRow.Delete();

            dataTable = this.baseDataSet.Tables["Main"];
            dataRow = dataTable.Rows[0];
            dataRow["strName"] = dataRow["strName"];

            //this.DbService.Post(this.baseDataSet, (int)PostType.FinalPosting);
            //this.LoadData(this.DbService.ID);
        }

    }
}
