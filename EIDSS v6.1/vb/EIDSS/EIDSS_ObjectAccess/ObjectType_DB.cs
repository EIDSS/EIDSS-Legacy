using System;
using System.Linq;
using System.Data;
using bv.common.db;

namespace EIDSS
{
    /// <summary>
    /// Summary description for CulturesTree_DB.
    /// </summary>
    public class ObjectType_DB : BaseDbService
    {
        public string ParentID { get; set; }

        public ObjectType_DB(string parentID)
        {
            ParentID = parentID;
            ObjectName = "ObjectType";
        }

        public override DataSet GetDetail(object ID)
        {
            var dataSet = new DataSet();
            var command = CreateSPCommand("spObjectType");
            if ((ID != null) && (ID.ToString().Length > 0))
            {
                AddParam(command, "@ID", ID, ref m_Error);
            }
            AddParam(command, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage, ref m_Error);
            FillDataset(command, dataSet, ObjectName);
            DataTable dataTable = dataSet.Tables[ObjectName];
            foreach (DataColumn column in dataTable.Columns.Cast<DataColumn>().Where(column => column.ReadOnly))
            {
                column.ReadOnly = false;
            }
            if (dataTable.Rows.Count == 0)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow["idfsReference"] = "";
                dataRow["idfsReference_Type"] = "rftObjectType";
                dataTable.Rows.Add(dataRow);
            }

            return (dataSet);
        }

        public override bool PostDetail(DataSet ds, int postType, IDbTransaction transaction = null)
        {
            DataTable dataTable = ds.Tables[ObjectName];
            if (dataTable == null)
            {
                throw new ApplicationException("Invalid dataset");
            }
            foreach (DataRow row in dataTable.Rows)
            {
                if (row.RowState == DataRowState.Unchanged)
                {
                    continue;
                }
                var command = CreateSPCommand("spObjectTypeTree_post");
                AddParam(command, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage, ref m_Error);
                AddParam(command, "@Action", row.RowState, ref m_Error);

                if (row.RowState == DataRowState.Deleted)
                {
                    AddParam(command, "@idfChild", row["idfsReference", DataRowVersion.Original], ref m_Error);
                }
                if ((row.RowState == DataRowState.Added) || (row.RowState == DataRowState.Modified))
                {
                    if (ParentID != null)
                    {
                        AddParam(command, "@idfsParent", ParentID, ref m_Error);
                    }
                    if (row["idfsReference"].ToString().Length > 0)
                    {
                        AddParam(command, "@idfChild", row["idfsReference"], ref m_Error);
                    }
                    AddParam(command, "@strDefaultName", row["strDefault"], ref m_Error);
                    AddParam(command, "@strNationalName", row["Name"], ref m_Error);
                }

                ExecCommand(command, Connection, transaction, true);
            }
            return (true);
        }
    }
}
