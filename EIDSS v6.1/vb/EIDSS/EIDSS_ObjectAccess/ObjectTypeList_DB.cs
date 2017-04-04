using System;
using System.Data;

using bv.common.db;

namespace EIDSS
{
    /// <summary>
    /// Summary description for ObjectTypeList_DB.
    /// </summary>
    public class ObjectTypeList_DB : BaseDbService
    {
        public string ParentID { get; set; }
        public const string ObjectTypeTreeTable = "ObjectTypeTree";

        public ObjectTypeList_DB()
        {
            ObjectName = "ObjectTypeTree";
        }

        public override DataSet GetDetail(object ID)
        {
            var dataSet = new DataSet { EnforceConstraints = false };
            var command = CreateSPCommand("spObjectTypeTree");
            AddParam(command, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage, ref m_Error);
            FillDataset(command, dataSet, ObjectName);

            foreach (DataColumn col in dataSet.Tables[0].Columns)
                col.ReadOnly = false;

            m_IsNewObject = false;
            return (dataSet);
        }

        public override bool PostDetail(DataSet ds, int postType, IDbTransaction transaction = null)
        {
            DataTable dataTable = ds.Tables[ObjectTypeTreeTable];
            if (dataTable == null)
            {
                throw new ApplicationException("Invalid dataset");
            }
            foreach (DataRow row in dataTable.Rows)
            {
                /*				if(row["idfsBaseReferenceRelationType"].ToString()=="brrObjectTypeINACTIVE")
                                {
                                    row.Delete();
                                }*/
                if (row.RowState == DataRowState.Unchanged)
                {
                    continue;
                }


                IDbCommand command = CreateSPCommand("spObjectTypeTree_post");
                if (row.RowState == DataRowState.Deleted)
                {
                    AddParam(command, "@idfsParentObjectType", row["idfsParentObjectType", DataRowVersion.Original], ref m_Error);
                    AddParam(command, "@idfsRelatedObjectType", row["idfsRelatedObjectType", DataRowVersion.Original], ref m_Error);
                    AddParam(command, "@idfsStatus", 10107001, ref m_Error);//brrObjectTypeINACTIVE
                }
                else
                {
                    AddParam(command, "@idfsParentObjectType", row["idfsParentObjectType"], ref m_Error);
                    AddParam(command, "@idfsRelatedObjectType", row["idfsRelatedObjectType"], ref m_Error);
                    AddParam(command, "@idfsStatus", row["idfsStatus"], ref m_Error);
                }
                ExecCommand(command, Connection, transaction, true);
            }
            return (true);
        }
    }
}
