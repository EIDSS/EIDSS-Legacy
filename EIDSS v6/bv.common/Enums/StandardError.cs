
namespace bv.common.Enums
{
    ///<summary>
    ///</summary>
    public enum StandardError
    {

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Displays the text 'Error during database operation'. Should be used for common database errors.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[Mike]	28.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DatabaseError,
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Displays the text 'Some field contains invalid data'. Should be used for common displaying data validation errors.
        /// </summary>
        /// <history>
        /// 	[Mike]	28.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DataValidationError,
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Displays the text 'Error during retrieving data from dataset'. Should be used when error occurs during retrieving data from database and filling form <b>DataSet</b> with this data.
        /// </summary>
        /// <history>
        /// 	[Mike]	28.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DataRetrievingError,
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Displays the text 'Error during saving data to database'. Should be used when errors occur during saving data to database.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[Mike]	28.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DataSavingtError,
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Displays the text 'Invalid login name/password'. Should be used when user tried to login with invalid credentials.
        /// </summary>
        /// <history>
        /// 	[Mike]	28.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        InvalidLogin,
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Displays the text 'Error during executing sql query'. Should be used when sql error occurs other then <i>FillDatasetError</i>, <i>PostError</i> or <i>StoredProcedureError</i>.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[Mike]	28.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        SqlQueryError,
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Displays the text 'Error during executing sql stored procedure'. Should be used when error during stored procedure execution occurs.
        /// </summary>
        /// <history>
        /// 	[Mike]	28.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StoredProcedureError,
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Displays the text 'Some error occurs in the application. Please send information about this error to developers team.'. Should be used when unprocessed error occur in application.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[Mike]	28.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        UnprocessedError,
        /// <summary>
        /// Displays the text 'Current user have not permissions for this operation'
        /// </summary>
        PermissionError,
        /// <summary>
        /// Displays the text 'There is Params count error'
        /// </summary>
        ParamsCountError,
        PostError,
        CreateParameterError,
        FillDatasetError,
        InvalidOldPassword,
        InvalidParameter
    }
}