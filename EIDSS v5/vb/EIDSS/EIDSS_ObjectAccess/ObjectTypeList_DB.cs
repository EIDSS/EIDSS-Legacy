using System;
using System.Windows.Forms;
using System.Data;
using System.Data.Common;

using bv.common;
using bv.common.db;

namespace EIDSS
{
	/// <summary>
	/// Summary description for ObjectTypeList_DB.
	/// </summary>
	public class ObjectTypeList_DB : BaseDbService
	{
		public DbDataAdapter CultureTreeAdapter = null;
		public string ParentID = null;
		public string focusTable = "ObjectTypeTree";

		public ObjectTypeList_DB()
		{
			base.ObjectName = "ObjectTypeTree";
		}

		public override System.Data.DataSet GetDetail(object ID)
		{
			DataSet		dataSet = new DataSet();
            dataSet.EnforceConstraints = false;
			IDbCommand	command = null;
/*
			string relations=string.Format(@"select * from fnReference('{0}','rftBaseReferenceRelation') where idfsReference in ('brrObjectTypeINACTIVE','brrObjectTypeYES','brrObjectTypeNO')",bv.model.Model.Core.ModelUserContext.CurrentLanguage);
			command = CreateCommand(relations, null);
			DbDataAdapter adapter = CreateAdapter(command, false);
			adapter.Fill(dataSet, "RelationTypes");
*/
			// Types tree
			command = CreateSPCommand("spObjectTypeTree", null);
			AddParam(command, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage, ref m_Error, ParameterDirection.Input);
            DbDataAdapter Adapter = CreateAdapter(command, false);

            Adapter.Fill(dataSet, base.ObjectName);
            //dataSet.Tables[1].TableName = "RelationType";

            foreach(DataColumn col in dataSet.Tables[0].Columns)
                col.ReadOnly=false;

			// Types list
            //Lookup_Db.FillBaseLookup(dataSet, BaseReferenceType.rftObjectType, this.Connection, HACode.None, false);

            m_IsNewObject = false;
			return(dataSet);
		}

		public override bool PostDetail(DataSet ds, int PostType, IDbTransaction transaction)
		{
			DataTable	dataTable;
			IDbCommand	command = null;

			dataTable = ds.Tables[this.focusTable];
			if(dataTable == null)
			{
				throw new ApplicationException("Invalid dataset");
			}
			foreach(DataRow row in dataTable.Rows)
			{
/*				if(row["idfsBaseReferenceRelationType"].ToString()=="brrObjectTypeINACTIVE")
				{
					row.Delete();
				}*/
				if(row.RowState == DataRowState.Unchanged)
				{
					continue;
				}

				//	@Action 				AS int, -- 4 - Added, 8 - Deleted, 16 - Modified
				//	@LangID 			AS nvarchar(50) = NULL,
				//
				//	@idfsParent				AS varchar(36) = NULL,	
				//	@idfChild				AS varchar(36) = NULL,	
				//	@strDefaultName			AS nvarchar(200) = NULL,
				//	@strNationalName  		AS nvarchar(200) = NULL

				command = CreateSPCommand("spObjectTypeTree_post", null);
				//AddParam(command, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage, ref m_Error, ParameterDirection.Input);
				//AddParam(command, "@Action", row.RowState, ref m_Error, ParameterDirection.Input);
				if(row.RowState==DataRowState.Deleted)
				{
                    AddParam(command, "@idfsParentObjectType", row["idfsParentObjectType", DataRowVersion.Original], ref m_Error, ParameterDirection.Input);
                    AddParam(command, "@idfsRelatedObjectType", row["idfsRelatedObjectType", DataRowVersion.Original], ref m_Error, ParameterDirection.Input);
                    AddParam(command, "@idfsStatus", 10107001, ref m_Error, ParameterDirection.Input);//brrObjectTypeINACTIVE
				}
				else
				{
                    AddParam(command, "@idfsParentObjectType", row["idfsParentObjectType"], ref m_Error, ParameterDirection.Input);
                    AddParam(command, "@idfsRelatedObjectType", row["idfsRelatedObjectType"], ref m_Error, ParameterDirection.Input);
                    AddParam(command, "@idfsStatus", row["idfsStatus"], ref m_Error, ParameterDirection.Input);
				}
				ExecCommand(command, this.Connection, transaction, true);
			}
			return(true);
		}
	}
}
