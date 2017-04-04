using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using bv.common.Core;
using bv.common.db;
using bv.common.win;
using bv.model.Model.Core;
using bv.winclient.BasePanel;

namespace EIDSS
{
    /// <summary>
    /// Summary description for ObjectAccessPanel.
    /// </summary>
    public partial class ObjectAccessPanel : BaseDetailPanel 
    {
        protected object m_CurrentActor;

        //protected DataView Objects;
        protected DataView m_SiteView;
        protected DataView m_UserView;
        private ImageList checkboxImageList;
        private GridColumn colAllow;
        private GridColumn colDeny;
        private GridColumn colName;
        private GridColumn colOperation;
        private GridColumn colSite;
        private GridColumn colType;
        private GridControl gridActors;
        private GridView gridActorsView;
        private GridControl gridPermissions;
        private GridView gridPermissionsView;
        private Label label1;
        private Label label2;
        private RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private SimpleButton simpleButton1;
        private SimpleButton simpleButton2;


        public ObjectAccessPanel()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            DbService = new ObjectAccessPanel_DB(ObjectType.None);
        }

        public ObjectType ObjectType
        {
            set
            {
                ((ObjectAccessPanel_DB) DbService).ObjectType = value;
            }
            get { return ((ObjectAccessPanel_DB) DbService).ObjectType; }
        }




        protected override void DefineBinding()
        {
            base.DefineBinding();

            m_SiteView = new DataView(baseDataSet.Tables["Actor"]);
            m_SiteView.Sort = "idfActor";

            m_UserView = new DataView(baseDataSet.Tables["Main"])
            {
                Sort = "idfsObjectOperation"
            };

            gridActors.DataSource = m_SiteView;
            ShowActors();
            gridPermissions.DataSource = baseDataSet.Tables["Operations"];

        }

        private void btnActorAdd_Click(object sender, EventArgs e)
        {
            var ugList = (IBaseListPanel) ClassLoader.LoadClass("UsersAndGroupsListPanel");

            var selection = BaseFormManager.ShowForMultiSelection(ugList, FindForm());
            if (selection != null)
            {
                var dataTable = (DataView) gridActors.DataSource;
                foreach (IObject ug in selection)
                {
                    try
                    {
                        object actorID = ug.Key;
                        DataRow newRow = dataTable.Table.NewRow();
                        newRow["idfActor"] = actorID;
                        newRow["strName"] = ug.GetValue("strName");
                        newRow["EmployeeTypeName"] = ug.GetValue("EmployeeTypeName");
                        newRow["strDescription"] = ug.GetValue("strDescription");
                        dataTable.Table.Rows.Add(newRow);
                    }
                    catch (ConstraintException)
                    {
                    }
                }
            }
            baseDataSet.Tables["Actor"].AcceptChanges();
        }

        private void btnActorDelete_Click(object sender, EventArgs e)
        {
            if (gridActorsView.SelectedRowsCount == 0) return;
            DataTable access = baseDataSet.Tables["Main"];
            foreach (int handle in gridActorsView.GetSelectedRows())
            {
                object actor = gridActorsView.GetDataRow(handle)["idfActor"];
                foreach (DataRow row in access.Select("idfActor=" + actor))
                {
                    row.Delete();
                }
            }
            baseDataSet.Tables["Actor"].AcceptChanges();
        }


        private void ShowPermissions()
        {
            if (gridActorsView.FocusedRowHandle == GridControl.InvalidRowHandle)
            {
                gridPermissionsView.OptionsBehavior.Editable = false;
                m_CurrentActor = null;
                m_UserView.RowFilter = "idfActor=-1"; //dummy id used
            }
            else
            {
                gridPermissionsView.OptionsBehavior.Editable = true;
                m_CurrentActor = gridActorsView.GetDataRow(gridActorsView.FocusedRowHandle)["idfActor"];
                m_UserView.RowFilter = "idfActor=" + m_CurrentActor;
            }
            gridPermissions.RefreshDataSource();
        }

        private void ShowActors()
        {
            gridActors.RefreshDataSource();
            ShowPermissions();
        }

        private void gridPermissionsView_CustomUnboundColumnData(object sender,
                                                                 CustomColumnDataEventArgs e)
        {
            DataRow row = gridPermissionsView.GetDataRow(e.ListSourceRowIndex);
            object operation = row["idfsObjectOperation"];
            if (e.IsGetData)
            {
                e.Value = false;
                if (m_CurrentActor == null) return;
                int found = m_UserView.Find(operation);
                if (found != -1)
                {
                    string t = m_UserView[found]["intPermission"].ToString();
                    if (e.Column == colAllow) e.Value = (t == "2");
                    if (e.Column == colDeny) e.Value = (t == "1");
                }
            }
        }

        private void gridActorsView_FocusedRowChanged(object sender,
                                                      FocusedRowChangedEventArgs e)
        {
            ShowPermissions();
        }

        private void gridPermissionsView_CellValueChanging(object sender,
                                                           CellValueChangedEventArgs e)
        {
            if (m_CurrentActor == null)
            {
                gridPermissionsView.RefreshRowCell(e.RowHandle, e.Column);
                return;
            }
            DataRow row = gridPermissionsView.GetDataRow(e.RowHandle);
            object operation = row["idfsObjectOperation"];

            DataRow action;
            int found = m_UserView.Find(operation);
            if (found == -1)
            {
                DataRow op = baseDataSet.Tables["Main"].NewRow();
                op["idfObjectAccess"] = BaseDbService.NewIntID();
                op["idfsObjectID"] = Utils.IsEmpty(DbService.ID) ? DBNull.Value : DbService.ID;
                op["idfsObjectOperation"] = operation;
                op["idfsObjectType"] = (long) ObjectType;
                if (((bool) e.Value)) op["intPermission"] = 2;
                op["idfActor"] = m_CurrentActor;
                baseDataSet.Tables["Main"].Rows.Add(op);
                action = op;
            }
            else action = m_UserView[found].Row;

            if (e.Column == colAllow)
            {
                if (((bool) e.Value))
                    action["intPermission"] = 2;
                else
                    action["intPermission"] = 0;
                gridPermissionsView.RefreshRowCell(e.RowHandle, colDeny);
            }
            if (e.Column == colDeny)
            {
                if (((bool) e.Value))
                    action["intPermission"] = 1;
                else
                    action["intPermission"] = 0;
                gridPermissionsView.RefreshRowCell(e.RowHandle, colAllow);
            }
        }
    }
}