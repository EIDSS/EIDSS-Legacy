using System;
using System.Reflection;
using System.ServiceModel;
using System.Web;
using bv.common.Configuration;
using bv.common.Core;
using bv.model.BLToolkit;
using eidss.avr.db.CacheReceiver;
using eidss.model.AVR.Db;
using eidss.model.Resources;

namespace eidss.avr.db.Common
{
    public class AvrServiceAccessability
    {
        private AvrServiceAccessability()
        {
            IsOk = true;
            CanWorkAtYourOwnRisk = true;
        }

        private AvrServiceAccessability(string errorMessage, Exception innerException = null)
        {
            Utils.CheckNotNullOrEmpty(errorMessage, "errorMessage");

            IsOk = false;
            CanWorkAtYourOwnRisk = false;
            ErrorMessage = errorMessage;
            InnerException = innerException;
        }

        private AvrServiceAccessability(string errorMessage, bool canWorkAtYourOwnRisk)
        {
            Utils.CheckNotNullOrEmpty(errorMessage, "errorMessage");

            IsOk = false;
            CanWorkAtYourOwnRisk = canWorkAtYourOwnRisk;
            ErrorMessage = errorMessage;
        }

        public bool IsOk { get; private set; }
        public bool CanWorkAtYourOwnRisk { get; private set; }

        public string ErrorMessage { get; private set; }
        public Exception InnerException { get; private set; }

        public static AvrServiceAccessability Check(ServiceClientWrapper wrapper = null)
        {
            bool isWeb = HttpContext.Current != null;
            string msgNotAccessable = isWeb ? "msgAvrServiceNotAccessableWeb" : "msgAvrServiceNotAccessable";
            string msgWrongVersion = isWeb ? "msgWrongAvrServiceVersionWeb" : "msgWrongAvrServiceVersion";
            string msgWrongDb = isWeb ? "msgWrongAvrDatabaseWeb" : "msgWrongAvrDatabase";
            string msgWronArchiveDb = isWeb ? "msgWrongAvrArchiveDatabaseWeb" : "msgWrongAvrArchiveDatabase";

            bool ownWrapper = wrapper == null;
            if (ownWrapper)
            {
                wrapper = new ServiceClientWrapper();
            }

            try
            {
                string serviceVersion = wrapper.GetServiceVersion().ToString(3);

                string productVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
                if (String.Compare(serviceVersion, productVersion, StringComparison.OrdinalIgnoreCase) != 0)
                {
                    string msg = FormatResourcesMessage(msgWrongVersion, serviceVersion, productVersion,
                        "Version of the AVR Service differs from version of the EIDSS.");
                    return new AvrServiceAccessability(msg, true);
                }

                DatabaseNames databaseNames = wrapper.GetDatabaseName();

                using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
                {
                    string eidssDb = manager.Connection.Database;
                    string avrDb = databaseNames.EidssActualDbName;
                    if (String.Compare(eidssDb, avrDb, StringComparison.OrdinalIgnoreCase) != 0)
                    {
                        string msg = FormatResourcesMessage(msgWrongDb, avrDb, eidssDb,
                            "AVR Service Database differs from the EIDSS Database.");
                        return new AvrServiceAccessability(msg, true);
                    }
                }

                if (DbManagerFactory.Factory[DatabaseType.Archive] == null)
                {
                    DbManagerFactory.SetSqlFactory(new ConnectionCredentials(null, "Archive").ConnectionString, DatabaseType.Archive);
                }
                var credentials = new ConnectionCredentials(null, "Archive");
                if (credentials.IsCorrect)
                {
                    using (DbManagerProxy archiveManager = DbManagerFactory.Factory[DatabaseType.Archive].Create())
                    {
                        string eidssDb = archiveManager.Connection.Database;
                        string avrDb = databaseNames.EidssArchiveDbName;
                        if (string.IsNullOrEmpty(avrDb))
                        {
                            var msg = EidssMessages.Get("msgNoAvrServiceArvhive", "AVR Service Archive Database does not exist");
                            return new AvrServiceAccessability(msg, false);
                        }
                        if (String.Compare(eidssDb, avrDb, StringComparison.OrdinalIgnoreCase) != 0)
                        {
                            string msg = FormatResourcesMessage(msgWronArchiveDb, avrDb, eidssDb,
                                "AVR Service Archive Database differs from the EIDSS Database.");
                            return new AvrServiceAccessability(msg, true);
                        }
                    }
                }
            }

            catch (EndpointNotFoundException)
            {
                return new AvrServiceAccessability(EidssMessages.Get(msgNotAccessable));
            }
            catch (CommunicationException ex)
            {
                return new AvrServiceAccessability(EidssMessages.Get(msgNotAccessable) + Environment.NewLine + ex.Message);
            }
            catch (Exception ex)
            {
                return new AvrServiceAccessability(EidssMessages.Get(msgNotAccessable), ex);
            }
            finally
            {
                if (ownWrapper)
                {
                    wrapper.Dispose();
                }
            }

            return new AvrServiceAccessability();
        }

        private static string FormatResourcesMessage(string msgWrongVersion, string firstVal, string secondVal, string partialMsg)
        {
            const string wrongResources = " Besides, there is internal error in the EIDSS resources: ";
            string msg;
            try
            {
                var format = EidssMessages.Get(msgWrongVersion);
                msg = string.Format(format, firstVal, secondVal);
            }
            catch (Exception ex)
            {
                msg = partialMsg + wrongResources + ex;
            }
            return msg;
        }
    }
}