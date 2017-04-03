using System;
using System.Data;
using System.Data.Common;
using bv.common;
using bv.common.db.Core;
using bv.common.Enums;
using bv.model.Model.Core;

namespace eidss.avr.db.DBService
{
    public class AvrSettings_DB : BaseAvrDbService
    {
        public const string TablePrecision = "Precision";
        public const string TableSearchField = "SearchField";
        public const string TableSearchObject = "SearchObject";

        public AvrSettings_DB()
        {
            ObjectName = "AvrSettings";
        }

        public override DataSet GetDetail(object id)
        {
            var dataSet = new DataSet();

            if (ConnectionManager.DefaultInstance.Connection.State != ConnectionState.Open)
            {
                ConnectionManager.DefaultInstance.Connection.Open();
            }
            using (IDbCommand cmd = CreateSPCommand("spAsAvrSettings_SelectLookup", ConnectionManager.DefaultInstance.Connection))
            {
                AddAndCheckParam(cmd, "@LangID", ModelUserContext.CurrentLanguage);
                DbDataAdapter da = CreateAdapter(cmd);
                da.Fill(dataSet);
                CorrectTable(dataSet.Tables[0], TablePrecision);
                CorrectTable(dataSet.Tables[1], TableSearchField);
                CorrectTable(dataSet.Tables[2], TableSearchObject);
                ClearColumnsAttibutes(dataSet);
            }
            AcceptChanges(dataSet);
            return dataSet;
        }

        public override bool PostDetail(DataSet dataSet, int postType, IDbTransaction transaction = null)
        {
            try
            {
                foreach (DataRow row in dataSet.Tables[TablePrecision].Rows)
                {
                    if (row.RowState == DataRowState.Modified)
                    {
                        ExecPostProcedure("spAsAggregateFunctionPrecision_Post", row, ConnectionManager.Connection, transaction);
                    }
                }
                foreach (DataRow row in dataSet.Tables[TableSearchField].Rows)
                {
                    if (row.RowState == DataRowState.Modified)
                    {
                        ExecPostProcedure("spAsDefaultAggregateFunction_Post", row, ConnectionManager.Connection, transaction);
                    }
                }
                LookupCache.NotifyChange("SearchField", transaction, ID);
                LookupCache.NotifyChange("QuerySearchField", transaction, ID);
                LookupCache.NotifyChange("AggregateFunction", transaction, ID);
                

                return true;
            }
            catch (Exception ex)
            {
                m_Error = new ErrorMessage(StandardError.PostError, ex);
                return false;
            }
        }
    }
}