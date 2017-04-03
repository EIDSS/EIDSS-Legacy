using System;
using System.Collections.Generic;
using System.Text;
using bv.common.Enums;
using bv.common.Resources;
using System.Linq;


namespace bv.common.Core
{
    public class StandardErrorHelper
    {
        public static string Error(StandardError errType)
        {
            switch(errType)
            {
                case StandardError.DatabaseError:
                    return BvMessages.Get("ErrDatabase", "Error during database operation.");
                case StandardError.DataValidationError:
                    return BvMessages.Get("ErrDataValidation", "Some field contains invalid data.");
                case StandardError.DataRetrievingError:
                    return BvMessages.Get("ErrFillDataset", "Error during retrieving data from database.");
                case StandardError.DataSavingtError:
                    return BvMessages.Get("ErrPost", "Error during saving data to database.");
                case StandardError.InvalidLogin:
                    return BvMessages.Get("ErrInvalidLogin", "Invalid login name/password.");
                case StandardError.SqlQueryError:
                    return BvMessages.Get("ErrSqlQuery", "Error during executing sql query.");
                case StandardError.StoredProcedureError:
                    return BvMessages.Get("ErrStoredProcedure", "Error during executing sql stored procedure.");
                case StandardError.UnprocessedError:
                    return BvMessages.Get("ErrUnprocessedError", "Some error occurs in the application. Please send information about this error to developers team.");
                case StandardError.PermissionError:
                    return BvMessages.Get("ErrPermissionError", "Current user have not permissions for this operation.");
                case StandardError.ParamsCountError:
                    return BvMessages.Get("ErrParamsCountError", "There is Params count error.");
                case StandardError.PostError:
                    return BvMessages.Get("ErrPost");
                case StandardError.CreateParameterError:
                    return BvMessages.Get("ErrCreateParameter");
                case StandardError.FillDatasetError:
                    return BvMessages.Get("ErrFillDataset");
                case StandardError.InvalidOldPassword:
                    return BvMessages.Get("ErrOldPassword");
               case StandardError.InvalidParameter:
                    return BvMessages.Get("ErrInvalidParameter");
                default:
                    return BvMessages.Get("ErrUndefinedStdError", "Some error occurs in the application. Please send information about this error to developers team.");
            }
        }
    }
}
