using System;
using bv.common.Core;
using eidss.model.Core;
using eidss.model.Enums;
using EIDSS.Reports.Parameterized.Human.GG.Report;

namespace eidss.model.Reports
{
    [Serializable]
    public class InfectiousDiseasesProcessor
    {
        private readonly ReportVersion m_Version;
        private readonly int[] m_AllMonthes = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};

        public InfectiousDiseasesProcessor(ReportVersion version)
        {
            m_Version = version;
        }

        public ReportVersion Version
        {
            get { return m_Version; }
        }

        public int[] AllMonthes
        {
            get { return m_AllMonthes; }
        }

        public bool AddSignature
        {
            get
            {
                return m_Version != ReportVersion.Version4 &&
                       EidssUserContext.User.HasPermission(
                           PermissionHelper.ExecutePermission(EIDSSPermissionObject.CanSignReport));
            }
        }

        public int MinYear
        {
            get
            {
                switch (m_Version)
                {
                    case ReportVersion.Version4:
                        return 2005;
                    case ReportVersion.Version5:
                        return 2012;
                    case ReportVersion.Version6:
                        return 2014;
                    case ReportVersion.Version61:
                        return 2016;
                    default:
                        throw new NotSupportedException(string.Format("Unsupported report version {0}", m_Version));
                }
            }
        }

        public int MaxYear
        {
            get
            {
                switch (m_Version)
                {
                    case ReportVersion.Version4:
                        return 2012;
                    case ReportVersion.Version5:
                        return 2014;
                    case ReportVersion.Version6:
                        return 2016;
                    case ReportVersion.Version61:
                        return 2100;
                    default:
                        throw new NotSupportedException(string.Format("Unsupported report version {0}", m_Version));
                }
            }
        }

        public int? DefaultYear
        {
            get
            {
                switch (m_Version)
                {
                    case ReportVersion.Version4:
                        return null;
                    case ReportVersion.Version5:
                        return null;
                    case ReportVersion.Version6:
                        return null;
                    case ReportVersion.Version61:
                        return DateTime.Now.Year;

                    default:
                        throw new NotSupportedException(string.Format("Unsupported report version {0}", m_Version));
                }
            }
        }

        public DateTime MinDate
        {
            get
            {
                switch (m_Version)
                {
                    case ReportVersion.Version4:
                        return new DateTime(2005, 04, 01);
                    case ReportVersion.Version5:
                        return new DateTime(2012, 06, 01);
                    case ReportVersion.Version6:
                        return new DateTime(2014, 12, 01);
                    case ReportVersion.Version61:
                        return new DateTime(2016, 02, 01);
                    default:
                        throw new NotSupportedException(string.Format("Unsupported report version {0}", m_Version));
                }
            }
        }

        public DateTime MaxDate
        {
            get
            {
                switch (m_Version)
                {
                    case ReportVersion.Version4:
                        return new DateTime(2012, 05, 31);
                    case ReportVersion.Version5:
                        return new DateTime(2012, 11, 30);
                    case ReportVersion.Version6:
                        return new DateTime(2016, 01, 31);
                    case ReportVersion.Version61:
                        return new DateTime(2100, 12, 31);
                    default:
                        throw new NotSupportedException(string.Format("Unsupported report version {0}", m_Version));
                }
            }
        }

        public int[] AllowedMinimumMonthes
        {
            get
            {
                switch (m_Version)
                {
                    case ReportVersion.Version4:
                        return new[] {4, 5, 6, 7, 8, 9, 10, 11, 12};
                    case ReportVersion.Version5:
                        return new[] {6, 7, 8, 9, 10, 11, 12};
                    case ReportVersion.Version6:
                        return new[] {12};
                    case ReportVersion.Version61:
                        return new[] {2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};

                    default:
                        throw new NotSupportedException(string.Format("Unsupported report version {0}", m_Version));
                }
            }
        }

        public int[] AllowedMaximumMonthes
        {
            get
            {
                switch (m_Version)
                {
                    case ReportVersion.Version4:
                        return new[] {1, 2, 3, 4, 5};
                    case ReportVersion.Version5:
                        return new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11};
                    case ReportVersion.Version6:
                        return new[] {1};
                    case ReportVersion.Version61:
                        return m_AllMonthes;

                    default:
                        throw new NotSupportedException(string.Format("Unsupported report version {0}", m_Version));
                }
            }
        }
    }
}