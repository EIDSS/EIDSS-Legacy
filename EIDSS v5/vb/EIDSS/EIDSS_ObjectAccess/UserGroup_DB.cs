using System;
using System.Data;
using System.Data.Common;
using bv.common.db;

namespace EIDSS
{
	/// <summary>
	/// Summary description for CulturesTree_DB.
	/// </summary>
	public class UserGroup_DB : BaseDbService
	{
		public DbDataAdapter CultureAdapter = null;
		public string ParentID = null;

		public UserGroup_DB(string parentID)
		{
			this.ParentID = parentID;
			base.ObjectName = "UserGroup";
		}

        public override DataSet GetDetail(object id)
        {
            m_ID = id;
            var dataSet = new DataSet();
            IDbCommand command = null;

            if (m_ID == null) m_IsNewObject = true;

            command = CreateSPCommand("spUserGroup", null);
            if ((m_ID != null) && (m_ID.ToString().Length > 0))
            {
                AddParam(command, "@ID", m_ID);
            }
            AddParam(command, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage);

            CultureAdapter = CreateAdapter(command);
            CultureAdapter.Fill(dataSet, "Main");

            command = CreateSPCommand("spUserGroupContent");
            if ((m_ID != null) && (m_ID.ToString().Length > 0))
            {
                AddParam(command, "@ID", m_ID, ref m_Error);
            }
            CultureAdapter = CreateAdapter(command);
            CultureAdapter.Fill(dataSet, "Content");

            DataTable dataTable = dataSet.Tables["Main"];
            foreach (DataColumn column in dataTable.Columns)
            {
                if (column.ReadOnly)
                {
                    column.ReadOnly = false;
                }
            }
            if (dataTable.Rows.Count == 0)
            {
                DataRow dataRow = dataTable.NewRow();
                m_ID = NewIntID();
                dataRow["idfEmployeeGroup"] = m_ID;
                //dataRow["idfsEmployeeType"] = "emtGroup";
                dataTable.Rows.Add(dataRow);
            }

            dataTable = dataSet.Tables["Content"];
            foreach (DataColumn column in dataTable.Columns)
            {
                if (column.ReadOnly) column.ReadOnly = false;
            }
            dataTable.PrimaryKey = new[] { dataTable.Columns["idfEmployee"] };
            return (dataSet);
        }

		public override bool PostDetail(DataSet ds, int PostType, IDbTransaction transaction)
		{
			DataTable	dataTable;
			DataRow		mainRow;
			//object		ID		= null;

			// Get ID:
			dataTable = ds.Tables["Main"];
			if(dataTable == null)
			{
				throw new ApplicationException("Invalid dataset");
			}
			mainRow = dataTable.Rows[0];
			if(mainRow.RowState != DataRowState.Unchanged)
			{
				//ID = mainRow["idfEmployeeGroup", DataRowVersion.Original];
				//PostDetailContent(ds, PostType, transaction, ID);
				PostDetailMain(ds, PostType, transaction, ID);
			}
			/*
            if((mainRow.RowState == DataRowState.Added) || (mainRow.RowState == DataRowState.Modified))
			{
				ID = mainRow["idfEmployeeGroup"];
				PostDetailMain(ds, PostType, transaction, ID);
				PostDetailContent(ds, PostType, transaction, ID);
			}
            */
            PostDetailContent(ds, PostType, transaction, ID);

			return(true);
		}

		public  bool PostDetailMain(DataSet ds, int PostType, IDbTransaction transaction, object ID)
		{
			DataTable	dataTable;
			DataRow		mainRow;
			IDbCommand	command = null;

			// Main
			dataTable = ds.Tables["Main"];
			if(dataTable == null)
			{
				throw new ApplicationException("Invalid dataset");
			}
			mainRow = dataTable.Rows[0];

			//	@Action 				AS int, -- 4 - Added, 8 - Deleted, 16 - Modified
			//
			//	@ID						AS uniqueidentifier = NULL,	
			//	@Name					AS nvarchar(200) = NULL,
			//	@Description			AS nvarchar(200) = NULL

			command = CreateSPCommand("spUserGroup_Post", null);
			AddParam(command, "@Action", mainRow.RowState, ref m_Error, ParameterDirection.Input);

			if(mainRow.RowState == DataRowState.Deleted)
			{
				AddParam(command, "@ID", ID, ref m_Error, ParameterDirection.Input);
			}
			if((mainRow.RowState == DataRowState.Added) || (mainRow.RowState == DataRowState.Modified))
			{
				AddParam(command, "@ID", ID, ref m_Error, ParameterDirection.Input);
				AddParam(command, "@strName", mainRow["strName"], ref m_Error, ParameterDirection.Input);
                AddParam(command, "@strNationalName", mainRow["strNationalName"], ref m_Error, ParameterDirection.Input);
                AddParam(command, "@strDescription", mainRow["strDescription"], ref m_Error, ParameterDirection.Input);
                AddParam(command, "@idfsEmployeeGroupName", mainRow["idfsEmployeeGroupName"], ref m_Error, ParameterDirection.Input);
                AddParam(command, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage, ref m_Error, ParameterDirection.Input);
			}
			ExecCommand(command, this.Connection, transaction, true);

			return(true);
		}
		public bool PostDetailContent(DataSet ds, int PostType, IDbTransaction transaction, object ID)
		{
			DataTable	dataTable;
			IDbCommand	command = null;

			// Content
			dataTable = ds.Tables["Content"];
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
				//
				//	@ID						AS uniqueidentifier,
				//	@MemberID				AS uniqueidentifier

				command = CreateSPCommand("spUserGroupContent_Post", null);
				AddParam(command, "@Action", row.RowState, ref m_Error, ParameterDirection.Input);
				AddParam(command, "@ID", ID, ref m_Error, ParameterDirection.Input);

				if(row.RowState == DataRowState.Deleted)
				{
					AddParam(command, "@MemberID", row["idfEmployee", DataRowVersion.Original], ref m_Error, ParameterDirection.Input);
				}
				if((row.RowState == DataRowState.Added) || (row.RowState == DataRowState.Modified))
				{
					AddParam(command, "@MemberID", row["idfEmployee"], ref m_Error, ParameterDirection.Input);
				}
				ExecCommand(command, this.Connection, transaction, true);
			}
			return(true);
		}
	}
}
