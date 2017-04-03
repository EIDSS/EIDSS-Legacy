using System;
using System.Collections.Generic;
using System.Text;
using bv.common.Core;
using eidss.model.Core;
using eidss.model.Enums;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class MultipleDiagnosisModel : IDisposable
    {
        private List<SelectListItemSurrogate> m_ItemsList;

        public MultipleDiagnosisModel()
        {
            CheckedItems = new string[0];
            HascCode = (int) HACode.Human;
            m_ItemsList = null;
            UsingType = DiagnosisUsingTypeEnum.StandardCase;
        }

        public MultipleDiagnosisModel(string[] checkedDiagnosis, int hacode)
        {
            CheckedItems = checkedDiagnosis ?? new string[0];

            HascCode = hacode;
            m_ItemsList = null;
            UsingType = DiagnosisUsingTypeEnum.StandardCase;
        }

        public int HascCode { get; set; }

        public bool IsRequired { get; set; }

        public DiagnosisUsingTypeEnum? UsingType { get; set; }

        [LocalizedDisplayName("DiagnosisName")]
        public string[] CheckedItems { get; set; }

        public List<SelectListItemSurrogate> ItemsList
        {
            get
            {
                return m_ItemsList ??
                       (m_ItemsList = FilterHelper.GetDiagnosisList(Localizer.CurrentCultureLanguageID, HascCode, UsingType));
            }
        }

        public override string ToString()
        {
            if (CheckedItems.Length == 0)
            {
                return string.Empty;
            }
            var result = new StringBuilder();
            foreach (var item in CheckedItems)
            {
                var found = ItemsList.Find(x => x.Value == item);
                if (found != null)
                {
                    result.AppendFormat("{0},", found.Text);
                }
                else
                {
                    result.AppendFormat("Could not find diagnosis with Id={0},", item);
                }
            }
            return result.ToString().TrimEnd(new[] {','});
        }

        public string ToXml()
        {
            return FilterHelper.GetXmlFromList(CheckedItems);
        }

        public void Dispose()
        {
            if (m_ItemsList != null)
            {
                m_ItemsList.Clear();
            }
            CheckedItems = null;
        }
    }
}