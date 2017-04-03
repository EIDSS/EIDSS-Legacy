using System;
using System.Windows.Forms;
using System.Data;
using System.Data.Common;

using bv.common;
using bv.common.db;

namespace EIDSS
{
	/// <summary>
	/// Summary description for CulturesTree_DB.
	/// </summary>
	public class ObjectType_DB : BaseDbService
	{
		public DbDataAdapter CultureAdapter = null;
		public string ParentID = null;

		public ObjectType_DB(string parentID)
		{
			this.ParentID = parentID;
			base.ObjectName = "ObjectType";
		}

		public override System.Data.DataSet GetDetail(object ID)
		{
			DataTable	dataTable;
			DataRow		dataRow;
			DataSet		dataSet = new DataSet();
			IDbCommand	command = null;

			command = CreateSPCommand("spObjectType", null);
			if((ID != null) && (ID.ToString().Length > 0))
			{
				AddParam(command, "@ID", ID, ref m_Error, ParameterDirection.Input);
			}
			AddParam(command, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage, ref m_Error, ParameterDirection.Input);
			CultureAdapter = CreateAdapter(command, false);

			CultureAdapter.Fill(dataSet, base.ObjectName);

			dataTable = dataSet.Tables[base.ObjectName];
			foreach(DataColumn column in dataTable.Columns)
			{
				if(column.ReadOnly == true)
				{
					column.ReadOnly = false;
				}
			}
			if(dataTable.Rows.Count == 0)
			{
				dataRow = dataTable.NewRow();
				dataRow["idfsReference"] = "";
				dataRow["idfsReference_Type"] = "rftObjectType";
				dataTable.Rows.Add(dataRow);
			}

			return(dataSet);
		}

		public override bool PostDetail(DataSet ds, int postType, IDbTransaction transaction)
		{
			DataTable	dataTable;
			IDbCommand	command = null;

			dataTable = ds.Tables[base.ObjectName];
			if(dataTable == null)
			{
				throw new ApplicationException("Invalid dataset");
			}
			foreach(DataRow row in dataTable.Rows)
			{
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
				AddParam(command, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage, ref m_Error, ParameterDirection.Input);
				AddParam(command, "@Action", row.RowState, ref m_Error, ParameterDirection.Input);

				if(row.RowState == DataRowState.Deleted)
				{
					AddParam(command, "@idfChild", row["idfsReference", DataRowVersion.Original], ref m_Error, ParameterDirection.Input);
				}
				if((row.RowState == DataRowState.Added) || (row.RowState == DataRowState.Modified))
				{
					if(this.ParentID != null)
					{
						AddParam(command, "@idfsParent", this.ParentID, ref m_Error, ParameterDirection.Input);
					}
					if(row["idfsReference"].ToString().Length > 0)
					{
						AddParam(command, "@idfChild", row["idfsReference"], ref m_Error, ParameterDirection.Input);
					}
					AddParam(command, "@strDefaultName", row["strDefault"], ref m_Error, ParameterDirection.Input);
					AddParam(command, "@strNationalName", row["Name"], ref m_Error, ParameterDirection.Input);
				}

				ExecCommand(command, this.Connection, transaction, true);
			}
			return(true);
		}
	}
}
