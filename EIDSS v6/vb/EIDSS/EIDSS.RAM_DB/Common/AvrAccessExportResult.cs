using System;
using eidss.model.Helpers;

namespace eidss.avr.db.Common
{
    [Serializable]
    public class AvrAccessExportResult
    {
        private static readonly EidssSerializer<AvrAccessExportResult> m_Singletone = new EidssSerializer<AvrAccessExportResult>();

        public AvrAccessExportResult()
        {
            IsOk = false;
        }

        public AvrAccessExportResult(long queryId, string path)
        {
            IsOk = true;
            QueryId = queryId;
            ResultFilePath = path;
        }

        public AvrAccessExportResult(string errorMessage, string exceptionString = null)
        {
            IsOk = false;
            ErrorMessage = errorMessage;
            ExceptionString = exceptionString;
        }

        public bool IsOk { get; set; }
        public long QueryId { get; set; }
        public string ResultFilePath { get; set; }

        public string ErrorMessage { get; set; }
        public string ExceptionString { get; set; }

        public string Serialize()
        {
            return m_Singletone.Serialize(this);
        }

        public static string Serialize(AvrAccessExportResult exportResult)
        {
            return m_Singletone.Serialize(exportResult);
        }

        public static AvrAccessExportResult Deserialize(string xml)
        {
            return m_Singletone.Deserialize(xml);
        }

        public override string ToString()
        {
            return IsOk
                ? string.Format("File path: '{0}'", ResultFilePath)
                : string.Format("Error: '{0}'.{1}Exception:{1}{2}", ErrorMessage, Environment.NewLine, ExceptionString);
        }
    }
}