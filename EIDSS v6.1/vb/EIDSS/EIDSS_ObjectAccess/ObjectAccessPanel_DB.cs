using System;
using System.Data;
using eidss.model.Core;

namespace EIDSS
{
    /// <summary>
    /// 
    /// </summary>
    public class ObjectAccessPanel_DB : bv.common.db.BaseDbService
    {
 
        public ObjectType ObjectType { get; set; }

 
        public ObjectAccessPanel_DB(ObjectType objectType)
        {
            ObjectType = objectType;
            ObjectName = "ObjectAccessPanel";
        }

        public override DataSet GetDetail(object id)
        {
            var dataSet = new DataSet();
            m_ID = id;

            IDbCommand command = CreateSPCommand("spObjectAccess");
            AddParam(command, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage);
            AddParam(command, "@ID", id);
            AddParam(command, "@ObjectType", (long)ObjectType);
            FillDataset(command, dataSet, "Main");
            DataTable dataTable = dataSet.Tables["Main"];
            dataTable.PrimaryKey = new[] { dataTable.Columns["idfObjectAccess"] };
            dataTable.Columns["idfsOnSite"].DefaultValue = EidssSiteContext.Instance.PermissionSiteID;

            dataSet.Tables["Main2"].TableName = "Operations";
            dataTable = dataSet.Tables["Operations"];
            dataTable.PrimaryKey = new[] { dataTable.Columns["idfsObjectOperation"] };
            dataTable = dataSet.Tables["Main1"];
            dataTable.TableName = "Actor";
            dataTable.PrimaryKey = new[] { dataTable.Columns["idfActor"], dataTable.Columns["idfsOnSite"] };
            dataTable.Columns["idfsOnSite"].DefaultValue = EidssSiteContext.Instance.PermissionSiteID;

            foreach (DataColumn column in dataTable.Columns)
            {
                if (column.ReadOnly)
                {
                    column.ReadOnly = false;
                }
            }
            return dataSet;
        }

        public override bool PostDetail(DataSet ds, int postType, IDbTransaction transaction = null)
        {
            // Content
            var dataTable = ds.Tables["Main"];
            if (dataTable == null)
            {
                throw new ApplicationException("Invalid dataset");
            }
            foreach (DataRow row in dataTable.Rows)
            {
                DataRowState state = row.RowState;
                if (state == DataRowState.Unchanged)
                {
                    continue;
                }

                var command = CreateSPCommand("spObjectAccess_Post");

                AddParam(command, "@idfsObjectID", ID, ref m_Error);
                AddParam(command, "@idfObjectAccess", row["idfObjectAccess", state == DataRowState.Deleted ? DataRowVersion.Original : DataRowVersion.Current], ref m_Error);
                AddParam(command, "@idfEmployee", row["idfActor", state == DataRowState.Deleted ? DataRowVersion.Original : DataRowVersion.Current], ref m_Error);
                var permission = (int)row["intPermission", state == DataRowState.Deleted ? DataRowVersion.Original : DataRowVersion.Current];
                AddParam(command, "@isAllow", permission == 2, ref m_Error);
                AddParam(command, "@isDeny", permission == 1, ref m_Error);

                if ((state == DataRowState.Added) || (state == DataRowState.Modified))
                {
                    if (row["idfsObjectOperation"] == DBNull.Value) continue;
                    
                    AddParam(command, "@idfsObjectType", ObjectType);
                    AddParam(command, "@idfsObjectOperation", row["idfsObjectOperation"]);
                    if (permission == 0)
                    {
                        state = DataRowState.Deleted;
                    }

                }
                AddParam(command, "@Action", state, ref m_Error);
                ExecCommand(command, Connection, transaction, true);
            }
            return (true);
        }
    }
}
