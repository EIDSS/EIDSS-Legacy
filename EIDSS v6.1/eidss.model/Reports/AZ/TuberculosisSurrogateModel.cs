using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eidss.model.Enums;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.AZ
{
    [Serializable]
    public class TuberculosisSurrogateModel : BaseModel
    {
        public const int MaxYearsCount = 5;

        public TuberculosisSurrogateModel()
        {
            YearCheckedItems = new string[0];
        }

        public TuberculosisSurrogateModel
            (string language, long? diagnosisId, string diagnosisName,
                string[] checkedYears, int? startMonth, int? endMonth,
                long? organizationId, List<PersonalDataGroup> forbiddenGroups, bool useArchive)
            : base(language, useArchive)
        {
            DiagnosisId = diagnosisId;
            DiagnosisName = diagnosisName;
            YearCheckedItems = checkedYears ?? new string[0];
            if (YearCheckedItems.Length > MaxYearsCount)
            {
                YearCheckedItems = new string[MaxYearsCount];
                if (checkedYears != null)
                {
                    for (int i = 0; i < MaxYearsCount; i++)
                    {
                        YearCheckedItems[i] = checkedYears[i];
                    }
                }
            }

            StartMonth = startMonth;
            EndMonth = endMonth;
            OrganizationId = organizationId;
            ForbiddenGroups = forbiddenGroups;
        }

        public long? DiagnosisId { get; set; }
        public string DiagnosisName { get; set; }

        public string[] YearCheckedItems { get; set; }
        public int? StartMonth { get; set; }
        public int? EndMonth { get; set; }

        public int MinYear
        {
            get
            {
                if (YearCheckedItems.Length == 0)
                {
                    return 2000;
                }
                return YearCheckedItems.Select(int.Parse).Min();
            }
        }

        public string YearsToXml()
        {
            return FilterHelper.GetXmlFromList(YearCheckedItems);
        }

        public string YearsToString()
        {
            if (YearCheckedItems.Length == 0)
            {
                return string.Empty;
            }
            if (YearCheckedItems.Length == 1)
            {
                return YearCheckedItems[0];
            }
            List<int> years = YearCheckedItems.Select(int.Parse).OrderBy(year => year).ToList();
            if (years[years.Count - 1] == years[0] + years.Count - 1)
            {
                return string.Format("{0} - {1}", years[0], years[years.Count - 1]);
            }
            var yearsBuilder = new StringBuilder();
            bool firstTime = true;
            foreach (int year in years)
            {
                if (firstTime)
                {
                    yearsBuilder.Append(year);
                }
                else
                {
                    yearsBuilder.AppendFormat(", {0}", year);
                }
                firstTime = false;
            }
            return yearsBuilder.ToString();
        }

        public override string ToString()
        {
            var years = new StringBuilder();
            if (YearCheckedItems!=null)
            foreach (string item in YearCheckedItems)
            {
                years.AppendFormat("{0},", item);
            }

            string result = string.Format("{0}, Diagnosis={1}, Years='{2}', StartMonth='{3}', EndMonth={4}",
                base.ToString(), DiagnosisName, years, StartMonth, EndMonth);
            return result;
        }
    }
}