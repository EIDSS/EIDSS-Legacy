using bv.common.Core;
using bv.common.Enums;
using bv.common.Resources;

namespace eidss.model.Core
{
	public class SecurityMessages
	{
		
		
		public static string GetLoginErrorMessage(long code)
		{
			switch (code)
			{
				case 1:
					return BvMessages.Get("ErrEmptyUserLogin", "User login can\'t be empty");
				case 2:
                    return BvMessages.Get("ErrUserNotFound", "User with such login/password is not found.");
				case 3:
                    return BvMessages.Get("ErrLowClientVersion", "The application version doesn\'t correspond to database version. Please install the latest application version.");
				case 4:
                    return BvMessages.Get("ErrLowDatabaseVersion", "The application requires the newest database version. Please upgrade your database to latest database version.");
				case 5:
                    return BvMessages.Get("ErrIncorrectDatabaseVersion", "The database version is absent or in incorrect format. Please upgrade your database to latest database version.");
				case 6:
                    var sm = new Security.EidssSecurityManager();
                    return string.Format(BvMessages.Get("ErrLoginIsLocked", "You have exceeded the number of incorrect login attempts. Please try again in {0} minutes."), sm.GetAccountLockTimeout());
				case 7:
                    return BvMessages.Get("ErrInvalidParameter", "Invalid parameter specified.");
				case 8:
                    return BvMessages.Get("ErrPasswordPolicy", "Unable to update the password. The value provided for the new password does not meet the length, complexity, or history requirement.");
				case 9:
                    return BvMessages.Get("ErrPasswordExpired", "Your password is expired. Please change your password.");
				default:
                    return BvMessages.Get("ErrUnprocessedError");
			}
		}

        public static string GetLoginErrorMessage(long code, string organization, string userName)
        {
            switch (code)
            {
                case 6:
                    var sm = new Security.EidssSecurityManager();
                    return string.Format(BvMessages.Get("ErrLoginIsLocked", "You have exceeded the number of incorrect login attempts. Please try again in {0} minutes."), sm.GetAccountLockTimeout(organization, userName));
                default:
                    return BvMessages.Get("ErrUnprocessedError");
            }
        }
		
		public static string GetDBErrorMessage(int? sqlErrorNumber, string databaseName, string serverName)
		{
            switch (sqlErrorNumber)
			{
				case 15211:
					return BvMessages.Get("InvalidOldPassword");
				case 18456:
                case 18450:
                case 18452:
                case 18458:
                case 18459:
                case 18460:
                    return StandardErrorHelper.Error(StandardError.InvalidLogin);
				case 4060:
                    return string.Format(BvMessages.Get("errDatabaseNotFound", "Cannot open database \'{0}\' on server \'{1}\'. Check the correctness of database name."), databaseName, serverName);
				default:
			        return BvMessages.Get("errSQLLoginError", "Cannot connect to SQL server. Check the correctness of SQL connection parameters in the SQL Server tab or SQL server accessibility.");
			}
		}
        /*
         * SQL errors that concerns login to the system
         * 18450 Login failed for user '%ls'. Reason: Not defined as a valid user of a trusted SQL Server connection.
         * 18452 Login failed for user '%ls'. Reason: Not associated with a trusted SQL Server connection.
         * 18456 Login failed for user '%ls'.
         * 18457 Login failed for user '%ls'. Reason: User name contains a mapping character or is longer than 30 characters.
         * 18458 Login failed. The maximum simultaneous user count of %d licenses for this server has been exceeded. Additional licenses should be obtained and registered through the Licensing application in the Windows NT Control Panel.
         * 18459 Login failed. The maximum workstation licensing limit for SQL Server access has been exceeded.
         * 18460 Login failed. The maximum simultaneous user count of %d licenses for this '%ls' server has been exceeded. Additional licenses should be obtained and installed or you should upgrade to a full version.
         * 18482 Could not connect to server '%ls' because '%ls' is not defined as a remote server.
         * 18483 Could not connect to server '%ls' because '%ls' is not defined as a remote login at the server.
         * 18485 Could not connect to server '%ls' because it is not configured for remote access.
         * 4060  Cannot open database requested in login '%.*ls'. Login fails.
         * 4061  Cannot open either database requested in login (%.*ls) or user default database (%.*ls). Using master database instead.
         * 4062  Cannot open user default database '%.*ls'. Using master database instead.
         * 4063  Cannot open database requested in login (%.*ls). Using user default '%.*ls' instead.
         * 17142 SQL Server has been paused. No new connections will be allowed.
         * 1205  Your transaction (process ID #%d) was deadlocked with another process and has been chosen as the deadlock victim. Rerun your transaction.
 
 
 

 

     */


    }
	
}
