using System;
using System.Data.SqlClient;
using bv.common.Core;
using bv.common.Resources;
using bv.model.Model.Core;

namespace bv.winclient.Core
{
    public class SqlExceptionHandler
    {
        public static bool Handle(Exception ex)
        {
            if (ex is DbModelException)
            {
                var ex1 = ex as DbModelException;
                if (string.IsNullOrEmpty(ex1.MessageId))
                {
                    string msgId = SqlExceptionMessage.Get(ex);
                    if (msgId != null)
                        ErrorForm.ShowError(msgId);//, null, ex);
                    else
                        ErrorForm.ShowError(ex1.Message, ex1);
                }
                else
                {
                    ErrorForm.ShowError(ex1.MessageId);
                }
                return true;
            }
            if (ex is SqlException)
            {
                string msgId = SqlExceptionMessage.Get(ex as SqlException);
                if(msgId!=null)
                {
                    ErrorForm.ShowError(msgId);//, null, ex);
                        return true;
                }
            }
            return false;
        }

        public static string GetExceptionDescription(Exception ex)
        {
            SqlException sqlException = TryGetSqlException(ex);
            string msgId = SqlExceptionMessage.Get(sqlException);
            if (msgId != null)
                return BvMessages.Get(msgId);
            if (sqlException != null)
                return ex.Message;
            return string.Empty;
        }

        private static SqlException TryGetSqlException(Exception ex)
        {
            if (ex == null)
            {
                return null;
            }
            if (ex is SqlException)
            {
                return (SqlException) ex;
            }

            return TryGetSqlException(ex.InnerException);
        }
    }
}
