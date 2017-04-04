using System;
using System.Collections.Generic;
using System.Linq;
using EIDSS.Reports.Parameterized.Human.GG.Report;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class VersionedDateModel : BaseDateModel
    {
        private InfectiousDiseasesProcessor m_Processor;
        private ReportVersion m_Version = ReportVersion.Version61;

        public VersionedDateModel()
        {
            Version = ReportVersion.Version61;
        }

        public VersionedDateModel(string language, int year, int? month, bool useArchive)
            : base(language, year, month, useArchive)
        {
            Version = ReportVersion.Version61;
        }

        public VersionedDateModel(string language, int year, int? month, int? monthEnd, bool useArchive)
            : base(language, year, month, monthEnd, useArchive)
        {
            Version = ReportVersion.Version61;
        }

        public ReportVersion Version
        {
            get { return m_Version; }
            set
            {
                m_Version = value;
                m_Processor = new InfectiousDiseasesProcessor(value);
            }
        }

        public override int MinYear
        {
            get
            {
                if (m_Processor == null)
                {
                    return base.MinYear;
                }
                return m_Processor.MinYear;
            }
        }

        public override int MaxYear
        {
            get
            {
                if (m_Processor == null)
                {
                    return base.MaxYear;
                }
                return m_Processor.MaxYear;
            }
        }

        public override List<SelectListItemSurrogate> SelectedMonthList
        {
            get
            {
                var list = base.SelectedMonthList;
                if (Year > MinYear && Year < MaxYear)
                {
                    return list;
                }
                if (m_Processor != null)
                {
                    IEnumerable<SelectListItemSurrogate> filteredList = null;
                    if (Year == MaxYear)
                    {
                        filteredList =
                            list.Where(
                                l =>
                                    (!IsMonthMandatory && l.Value == null) ||
                                    (l.Value != null && m_Processor.AllowedMaximumMonthes.Contains(int.Parse(l.Value))));
                    }
                    else if (Year == MinYear)
                    {
                        filteredList =
                            list.Where(
                                l =>
                                    (!IsMonthMandatory && l.Value == null) ||
                                    (l.Value != null && m_Processor.AllowedMinimumMonthes.Contains(int.Parse(l.Value))));
                    }
                    if (filteredList != null)
                    {
                        return filteredList.ToList();
                    }
                }
                return list;
            }
        }
    }
}