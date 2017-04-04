using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace bv.common.Core
{
    public class SqlExceptionMessage
    {


        public static string Get(Exception ex)
        {
            //process first sql exception in exceptions stack that is related with connection error
            //top inner exception can contain non sql exception
            while (ex != null)
            {
                if (ex is SqlException)
                {
                    switch ((ex as SqlException).Number)
                    {
                        case -2146233087:
                        case -1: // connection
                        case 2: // ?? I found this number when sql server is turned off
                        case 11:
                        case 19:
                        case 53:
                        case 17142:
                            return "errGeneralNetworkError";
                        case 17:
                            return "errSqlServerDoesntExist";
                        case -2: // timeout
                            return "msgTimeoutList";
                        case 1205: // deadlock
                            return "msgIdDeadlock";
                        case 15211:
                            return "InvalidOldPassword";
                        case 18456:
                        case 18450:
                        case 18452:
                        case 18458:
                        case 18459:
                        case 18460:
                            return "ErrInvalidLogin";
                        case 4060:
                            return "errSQLLoginError";
                        case 18470:
                            return "errLoginDisabled";
                            //default:
                            //    return null; BvMessages.Get("errSQLLoginError", "Cannot connect to SQL server. Check the correctness of SQL connection parameters in the SQL Server tab or SQL server accessibility.");
                    }
                }
                ex = ex.InnerException;
            }
            return null;

        }
    }
}
