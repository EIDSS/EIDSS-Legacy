namespace CustomActions
{
  internal static class Properties
  {
    internal const string WixUIInstallMode = "WixUI_InstallMode";
    internal const string RelatedProducts = "WIX_UPGRADE_DETECTED";

    internal const string DbUser = "DBUSER";
    internal const string DbPassword = "DBPASSWORD";
    internal const string DbServer = "DBSERVER";
    internal const string SqlDatabase = "SQLDATABASE";
    internal const string DbConnectionValid = "DbConnection_Valid";
    internal const string EncryptedDbPassword = "EncryptedDBPASSWORD";
    internal const string EncryptedDbUser = "EncryptedDBUSER";

    internal const string ArchUser = "ARCHUSER";
    internal const string ArchPassword = "ARCHPASSWORD";
    internal const string ArchDbServer = "ARCHDBSERVER";
    internal const string ArchDatabase = "ARCHDATABASE";
    internal const string ArchDbConnectionValid = "ArchDbConnection_Valid";
    internal const string EncryptedArchPassword = "EncryptedARCHPASSWORD";
    internal const string EncryptedArchUser = "EncryptedARCHUSER";

    internal const string DbUserForAvr = "DBUSER_FOR_AVR";
    internal const string DbPasswordForAvr = "DBPASSWORD_FOR_AVR";
    internal const string DbServerForAvr = "DBSERVER_FOR_AVR";
    internal const string SqlDatabaseForAvr = "SQLDATABASE_FOR_AVR";
    internal const string DbConnectionValidForAvr = "DbConnectionForAvr_Valid";
    internal const string EncryptedDbPasswordForAvr = "EncryptedDBPASSWORDForAvr";
    internal const string EncryptedDbUserForAvr = "EncryptedDBUSERForAvr";

    internal const string ServiceAccountName = "SERVICE_ACCOUNT_NAME";
    internal const string ServiceAccountDomain = "SERVICE_ACCOUNT_DOMAIN";
    internal const string ServiceAccountPassword = "SERVICE_ACCOUNT_PASSWORD";
    internal const string EncryptedServiceAccountName = "ENCRYPTED_SERVICE_ACCOUNT_NAME";
    internal const string EncryptedServiceAccountPassword = "ENCRYPTED_SERVICE_ACCOUNT_PASSWORD";
    internal const string ServiceAccountValid = "SERVICE_ACCOUNT_VALID";
    internal const string InvalidAccountText = "InvalidAccountText";
    internal const string BadDomain = "InvalidAccountText_BadDomain";
    internal const string EmptyLogin = "InvalidAccountText_EmptyLogin";
    internal const string NonExistentAccount = "InvalidAccountText_NonExistentAccount";
    internal const string InvalidAccount = "InvalidAccountText_InvalidAccount";
    internal const string AccountIsDisabled = "InvalidAccountText_AccountIsDisabled";

    internal const string PathToValidate = "PathToValidate";
    internal const string InvalidDirText = "InvalidDirText";
    internal const string DirIsEmpty = "InvalidDirText_Empty";
    internal const string DirDoesNotExist = "InvalidDirText_NotExists";
    internal const string DirValid = "DIR_VALID";

    internal const string ReportsServicePort = "REPORTS_SERVICE_PORT";
    internal const string ReportsServicePortValid = "REPORTS_SERVICE_PORT_VALID";
    internal const string WebSitePort = "WEBSITE_PORT";
    internal const string WebSitePortValid = "WEBSITE_PORT_VALID";
    internal const string AvrWebSitePort = "AVR_WEBSITE_PORT";
    internal const string AvrWebSitePortValid = "AVR_WEBSITE_PORT_VALID";
    internal const string MobileWebSitePort = "MOBILE_WEBSITE_PORT";
    internal const string MobileWebSitePortValid = "MOBILEWEBSITE_PORT_VALID";
    internal const string SmartphoneWebSitePort = "SMARTPHONE_WEBSITE_PORT";
    internal const string SmartphoneWebSitePortValid = "SMARTPHONE_WEBSITE_PORT_VALID";
    internal const string OpenApiWebSitePort = "OPEN_API_WEBSITE_PORT";
    internal const string OpenApiWebSitePortValid = "OPEN_API_WEBSITE_PORT_VALID";

    internal const string RequireAvrUrl = "RequireAvrUrl";
    internal const string AVRServiceHostUrl = "AVR_SERVICE_HOSTURL";
    internal const string AVRServiceHostUrlValid = "AVR_SERVICE_HOSTURL_VALID";

    internal const string BadServicePingText = "BadServicePingText";
    internal const string ServiceHostUrlIsEmpty = "BadServicePingText_ServiceHostUrlIsEmpty";
    internal const string VersionMismatch = "BadServicePingText_VersionMismatch";
    internal const string ServicePingFailed = "BadServicePingText_ServicePingFailed";
    internal const string BadUrl = "BadServicePingText_BadUrl";

    internal const string DefaultAppPoolIdleTimeoutInMinutes = "DEFAULT_APP_POOL_IDLE_TIMEOUT_IN_MINUTES";
    internal const string AppPoolIdleTimeoutInMinutes = "APP_POOL_IDLE_TIMEOUT_IN_MINUTES";
    internal const string AppPoolIdleTimeoutInSeconds = "AppPoolIdleTimeoutInSeconds";
    internal const string AppPool = "AppPool";
    internal const string AppPoolIdleTimeout = "AppPoolIdleTimeout";

    internal const string MajorVersion = "MajorVersion";
    internal const string MinorVersion = "MinorVersion";
    internal const string Build = "Build";

    internal const string BadNumber = "BadNumber";
    internal const string BadNumberText = "BadNumberText";
    internal const string EmptyNumber = "BadNumberText_Empty";
    internal const string NotOnlyNumber = "BadNumberText_NotNumber";
    internal const string TestNumber = "TestNumber";
    internal const string TestNumberSets = "TestNumberSets";
    internal const string TestNumberName = "TestNumberName";
    internal const string NumberLowerBound = "NumberLowerBound";
    internal const string NumberUpperBound = "NumberUpperBound";
    internal const string OutsideBounds = "BadNumberText_OutsideBounds";

    internal const string SharePorts = "SharePorts";
  }
}