using System;
//using System.Windows.Forms;
using System.Data;
using System.Data.Common;

using bv.common;
using bv.common.Enums;
using bv.common.db;



namespace EIDSS
{
	public class FreezerTree_DB : BaseDbService
	{
		public FreezerTree_DB() 
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public override System.Data.DataSet GetDetail(object ID)
		{
            m_ID = ID;
			DataSet		ds = new DataSet();
			//string		cmd = "";
			IDbCommand	command = null;
			DbDataAdapter FreezerTree_Adapter = null;

			try 
			{
//				command = CreateSPCommand("spCultureTree", null);
//				AddParam(command, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage, ref m_Error, ParameterDirection.Input);
//				CultureTreeAdapter = CreateAdapter(command, false);

				//cmd = "select * from fn_RepositorySchema()";
				command = CreateSPCommand("spFreezerTree",null);
				FreezerTree_Adapter = CreateAdapter(command, false);
				FreezerTree_Adapter.Fill(ds,"ContainerTree");
                CorrectTable(ds.Tables[0], "ContainerTree", "ID");
				return ds;
			}
			catch (Exception ex)
			{
				base.m_Error = new ErrorMessage(StandardError.FillDatasetError, ex);
			}
			return null;

		}

	}
}
