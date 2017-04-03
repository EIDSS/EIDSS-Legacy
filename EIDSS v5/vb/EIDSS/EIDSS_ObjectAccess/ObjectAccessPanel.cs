using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using EIDSS.Core;
using bv.common.Core;
using bv.common.Objects;
using bv.common.db;
using bv.common.win;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using eidss.model.Core;
using eidss.model.Enums;

namespace EIDSS
{
    /// <summary>
    /// Summary description for ObjectAccessPanel.
    /// </summary>
    public partial class ObjectAccessPanel : BaseDetailPanel //BaseForm//System.Windows.Forms.UserControl
    {
        //public string CurrentSite="";
        //public string ObjectType="";
        protected object CurrentActor;
        protected long CurrentSite = EidssSiteContext.Instance.SiteID;

        protected bool ShowSites =
            new StandardAccessPermissions(EIDSSPermissionObject.ManageRightsRemotely).CanExecute;

        //protected DataView Objects;
        protected DataView SiteView;
        protected DataView UserView;
        private LookUpEdit cbSite;
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
        private Label lblSite;
        private RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private SimpleButton simpleButton1;
        private SimpleButton simpleButton2;


        public ObjectAccessPanel()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            DbService = new ObjectAccessPanel_DB(ObjectType.None
                /*,EIDSS.model.Core.EidssSiteContext.Instance.get_SiteID(null)*/);
        }

        public ObjectType ObjectType
        {
            set
            {
                (DbService as ObjectAccessPanel_DB).ObjectType = value;
                    //=new ObjectAccessPanel_DB(value,this.OnSite);
            }
            get { return (DbService as ObjectAccessPanel_DB).ObjectType; }
        }

        public long OnSite
        {
            set
            {
                //(this.DbService as ObjectAccessPanel_DB).OnSite=value;//=new ObjectAccessPanel_DB(value,this.OnSite);
                CurrentSite = value;
            }
            get
            {
                //return (this.DbService as ObjectAccessPanel_DB).OnSite;
                return CurrentSite;
            }
        }


        protected override void DefineBinding()
        {
            base.DefineBinding();

            SiteView = new DataView(baseDataSet.Tables["Actor"]);
            SiteView.RowFilter = "idfsOnSite=" + OnSite;
            SiteView.Sort = "idfActor";

            UserView = new DataView(baseDataSet.Tables["Main"]);
            UserView.RowFilter = "idfsOnSite=" + OnSite;
            UserView.Sort = "idfsObjectOperation";

            gridActors.DataSource = SiteView;
            ShowActors();
            //baseDataSet.Tables["Main"];
            //Objects = new DataView(this.baseDataSet.Tables["Main"]);
            //Objects.Sort = "idfActor";
            //Objects.RowFilter = "idfsOnSite=" + this.OnSite + "";

            gridPermissions.DataSource = baseDataSet.Tables["Operations"];

            if (ShowSites)
            {
                long current = OnSite;
                //Lookup_Db.FillSiteLookup(this.baseDataSet, this.DbService.Connection);
                //Core.LookupBinder.BindBaseLookup(this.cbSite,this.baseDataSet,null, bv.common.db.BaseReferenceType.)
                //LookupBinder.BindSiteLookup(this.cbSite, this.baseDataSet, null);
                //foreach (DevExpress.XtraEditors.Controls.EditorButton btn in this.cbSite.Properties.Buttons)
                //if (btn.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete) btn.Visible = false;
                //this.cbSite.Properties.DataSource = baseDataSet.Tables["Site"];
                LookupBinder.BindSiteLookup(cbSite, null, null, false);
                cbSite.EditValue = current;
            }
            else
            {
                int shift = gridActors.Top - label1.Top;
                label1.Top = lblSite.Top;
                gridActors.Top = label1.Top + shift;
            }
            lblSite.Visible = ShowSites;
            cbSite.Visible = ShowSites;
        }

        private void btnActorAdd_Click(object sender, EventArgs e)
        {
            IList<IObject> selection = null;
            var UGList = (IBaseListPanel) ClassLoader.LoadClass("UsersAndGroupsListPanel");

            selection = BaseFormManager.ShowForMultiSelection(UGList, FindForm(), null, 0, 0);
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
                        newRow["idfsOnSite"] = OnSite;
                        newRow["strName"] = ug.GetValue("strName");
                        newRow["EmployeeTypeName"] = ug.GetValue("EmployeeTypeName");
                        newRow["strDescription"] = ug.GetValue("strDescription");
                        dataTable.Table.Rows.Add(newRow);
                    }
                    catch (ConstraintException)
                    {
                    }
                }
                //RefreshActors();
            }
            baseDataSet.Tables["Actor"].AcceptChanges();
        }

        private void btnActorDelete_Click(object sender, EventArgs e)
        {
            if (gridActorsView.SelectedRowsCount == 0) return;
            DataTable access = baseDataSet.Tables["Main"];
            var find = new object[] {OnSite, null};
            foreach (int handle in gridActorsView.GetSelectedRows())
            {
                object actor = gridActorsView.GetDataRow(handle)["idfActor"];
                foreach (DataRowView v in SiteView.FindRows(actor))
                    v.Delete();
                foreach (DataRow row in access.Select("idfsOnSite=" + OnSite + " and idfActor=" + actor))
                {
                    row.Delete();
                }
            }
            baseDataSet.Tables["Actor"].AcceptChanges();
        }


/*
		DataRowView[] FindActorRows(string ActorID)
		{
            return this.SiteView.FindRows(ActorID);
		}
*/

        private void cbSite_EditValueChanged(object sender, EventArgs e)
        {
            if (Utils.IsEmpty(cbSite.EditValue)) return;
            OnSite = (long) cbSite.EditValue;
            ShowActors();
        }

        private void ShowPermissions()
        {
            if (gridActorsView.FocusedRowHandle == GridControl.InvalidRowHandle)
            {
                //this.gridPermissions.Enabled = false;
                gridPermissionsView.OptionsBehavior.Editable = false;
                CurrentActor = null;
                UserView.RowFilter = "idfsOnSite=" + CurrentSite + " and idfActor=-1"; //dummy id used
            }
            else
            {
                //this.gridPermissions.Enabled = true;
                gridPermissionsView.OptionsBehavior.Editable = true;
                CurrentActor = gridActorsView.GetDataRow(gridActorsView.FocusedRowHandle)["idfActor"];
                UserView.RowFilter = "idfsOnSite=" + CurrentSite + " and idfActor=" + CurrentActor;
            }
            gridPermissions.RefreshDataSource();
        }

        private void ShowActors()
        {
            //DataTable table = SiteView.ToTable(true, new string[] { "idfActor", "strName", "strSiteID", "strDescription", "Type" });
            //if (this.gridActors.DataSource is DataTable)
            //((DataTable)this.gridActors.DataSource).Dispose();
            //this.CurrentActor = null;
            //this.gridActors.DataSource = table;
            SiteView.RowFilter = "idfsOnSite=" + OnSite + "";
            gridActors.RefreshDataSource();
            ShowPermissions();
            //this.gridPermissions.RefreshDataSource();
            //this.gridPermissionsView.RefreshData();
        }

        private void gridPermissionsView_CustomUnboundColumnData(object sender,
                                                                 CustomColumnDataEventArgs e)
        {
            DataRow row = gridPermissionsView.GetDataRow(e.ListSourceRowIndex); //e.RowHandle replaced as obsolete
            object operation = row["idfsObjectOperation"];
            if (e.IsGetData)
            {
                e.Value = false;
                if (CurrentActor == null) return;
                int found = UserView.Find(operation);
                if (found != -1)
                {
                    string t = UserView[found]["intPermission"].ToString();
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
            if (CurrentActor == null)
            {
                gridPermissionsView.RefreshRowCell(e.RowHandle, e.Column);
                return;
            }
            DataRow row = gridPermissionsView.GetDataRow(e.RowHandle);
            object operation = row["idfsObjectOperation"];

            DataRow action;
            int found = UserView.Find(operation);
            if (found == -1)
            {
                //DataRow actorRow = this.gridActorsView.GetDataRow(gridActorsView.FocusedRowHandle);
                DataRow op = baseDataSet.Tables["Main"].NewRow();
                op["idfObjectAccess"] = BaseDbService.NewIntID(null);
                op["idfsObjectID"] = Utils.IsEmpty(DbService.ID) ? DBNull.Value : DbService.ID;
                op["idfsObjectOperation"] = operation;
                op["idfsObjectType"] = (long) ObjectType;
                op["idfsOnSite"] = CurrentSite;
                if (((bool) e.Value)) op["intPermission"] = 2;

                op["idfActor"] = CurrentActor;
                //op["strName"] = CurrentActor["strName"];
                //op["strSiteID"] = CurrentActor["strSiteID"];
                //op["strDescription"] = CurrentActor["strDescription"];
                //op["Type"] = CurrentActor["Type"];
                //op["ActorName"] = actorRow["ActorName"];
                //op["idfsActorType"] = actorRow["idfsActorType"];
                //            newRow["ActorType"] = actorRow["ActorType"];
                //            newRow["ActorDescription"] = actorRow["ActorDescription"];
                //            newRow["idfsSite"] = actorRow["idfsSite"];
                //if (UserView[found]["intPermission"].ToString() == "2") e.Value = true;
                baseDataSet.Tables["Main"].Rows.Add(op);
                action = op;
            }
            else action = UserView[found].Row;

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