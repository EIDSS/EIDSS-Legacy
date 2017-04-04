using System;
using bv.common.Core;

namespace eidss.model.Reports
{
    [Serializable]
    public class ReportResultParameters
    {
        private readonly byte[] m_FileContents;
        private readonly string m_FileName;
        private readonly string m_FileExtension;

        private readonly bool m_IsOpenInNewWindow;

        public ReportResultParameters(byte[] fileContents, string fileName, string fileExtension, bool isOpenInNewWindow)
        {
            Utils.CheckNotNull(fileContents, "fileContents");
            Utils.CheckNotNullOrEmpty(fileName, "fileName");
            Utils.CheckNotNullOrEmpty(fileExtension, "fileExtension");

            m_FileContents = fileContents;
            m_FileName = fileName;
            m_FileExtension = fileExtension;
            m_IsOpenInNewWindow = isOpenInNewWindow;
        }

        public byte[] FileContents
        {
            get { return m_FileContents; }
        }

        public string FileName
        {
            get { return m_FileName; }
        }

        public string FileExtension
        {
            get { return m_FileExtension; }
        }

        public bool IsOpenInNewWindow
        {
            get { return m_IsOpenInNewWindow; }
        }
    }
}