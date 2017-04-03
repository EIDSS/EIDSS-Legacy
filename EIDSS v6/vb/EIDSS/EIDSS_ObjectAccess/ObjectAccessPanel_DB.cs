using System;
using System.Data;
using System.Data.Common;

namespace EIDSS
{
    /// <summary>
    /// 
    /// </summary>
    public class ObjectAccessPanel_DB : bv.common.db.BaseDbService
    {
        /*		public ObjectAccessPanel_DB()
                {
                }*/
        //public string DefaultGroupID="DEFA0000-0000-0000-0000-000000000000";//"CC2DDB9F-EEB2-4916-8724-600D78FD8160";

        public ObjectType ObjectType = EIDSS.ObjectType.None;
        //public string OnSite = null;

        /*public ObjectAccessDetail_DB()
        {
            base.ObjectName = "ObjectAccessDetail";
        }*/

        public ObjectAccessPanel_DB(ObjectType objectType/*,string onSite*/)
        {
            this.ObjectType = objectType;
            //this.OnSite=onSite;
            base.ObjectName = "ObjectAccessPanel";
        }

        public override System.Data.DataSet GetDetail(object ID)
        {
            DbDataAdapter adapter = null;
            DataSet dataSet = new DataSet();
            IDbCommand command = null;

            m_ID = ID;
            command = CreateSPCommand("spObjectAccess", null);
            AddParam(command, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage);
            AddParam(command, "@ID", this.ID);
            AddParam(command, "@ObjectType", (long)ObjectType);
            adapter = CreateAdapter(command);
            adapter.Fill(dataSet, "Main");

            DataTable dataTable = dataSet.Tables["Main"];
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["idfObjectAccess"] };
            //DataTable MainTable=dataSet.Tables["Main"];

            dataSet.Tables["Main2"].TableName = "Operations";
            dataTable = dataSet.Tables["Operations"];
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["idfsObjectOperation"] };
            /*
                        dataTable = dataSet.Tables["Main2"];
                        dataTable.TableName = "Site";
                        dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["idfsSite"]};
            */
            dataTable = dataSet.Tables["Main1"];
            dataTable.TableName = "Actor";
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["idfActor"], dataTable.Columns["idfsOnSite"] };

            foreach (DataColumn column in dataTable.Columns)
            {
                if (column.ReadOnly == true)
                {
                    column.ReadOnly = false;
                }
            }
            return dataSet;
        }

        public override bool PostDetail(DataSet ds, int postType, IDbTransaction transaction)
        {
            DataTable dataTable;
            IDbCommand command = null;

            // Content
            dataTable = ds.Tables["Main"];
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
                //	@Action 				AS int, -- 4 - Added, 8 - Deleted, 16 - Modified
                //
                //	@idfObjectAccess		AS uniqueidentifier,
                //	@ObjectID				AS varchar(36),
                //	@ObjectType				AS nvarchar(200) = NULL,
                //	@ActorID				AS uniqueidentifier,
                //	@ActorTypeID			AS varchar(36),
                //	@idfsObjectOperationID	AS varchar(36),
                //	@Permission				AS int
                //	@idfsOnSite				AS varchar(36)

                command = CreateSPCommand("spObjectAccess_Post");

                //AddParam(command, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage, ref m_Error, ParameterDirection.Input);
                AddParam(command, "@idfsObjectID", this.ID, ref m_Error, ParameterDirection.Input);
                AddParam(command, "@idfsSite", row["idfsOnSite", state == DataRowState.Deleted ? DataRowVersion.Original : DataRowVersion.Current], ref m_Error);
                AddParam(command, "@idfObjectAccess", row["idfObjectAccess", state == DataRowState.Deleted ? DataRowVersion.Original : DataRowVersion.Current], ref m_Error);
                AddParam(command, "@idfEmployee", row["idfActor", state == DataRowState.Deleted ? DataRowVersion.Original : DataRowVersion.Current], ref m_Error);
                var permission = (int)row["intPermission", state == DataRowState.Deleted ? DataRowVersion.Original : DataRowVersion.Current];
                AddParam(command, "@isAllow", permission == 2, ref m_Error);
                AddParam(command, "@isDeny", permission == 1, ref m_Error);

                if ((state == DataRowState.Added) || (state == DataRowState.Modified))
                {
                    if (row["idfsObjectOperation"] == DBNull.Value) continue;
                    
                    AddParam(command, "@idfsObjectType", this.ObjectType);
                    //AddParam(command, "@idfEmployee", row["idfActor"], ref m_Error);
                    AddParam(command, "@idfsObjectOperation", row["idfsObjectOperation"]);
                    //AddParam(command, "@isAllow", permission == 2);
                    //AddParam(command, "@isDeny", permission == 1);
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
