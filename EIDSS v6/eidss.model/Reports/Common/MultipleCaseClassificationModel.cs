using System;
using System.Collections.Generic;
using System.Text;
using bv.common.Core;
using eidss.model.Core;
using eidss.model.Enums;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class MultipleCaseClassificationModel : IDisposable
    {
        private readonly int m_HACode;
        private readonly bool m_IsInitial;
        private readonly bool m_IsFinal;
        private List<SelectListItemSurrogate> m_ItemsList;

        public MultipleCaseClassificationModel()
        {
            CheckedItems = new string[0];
            m_HACode = (int) HACode.Human;
            m_IsInitial = false;
            m_IsFinal = false;
            m_ItemsList = null;
        }

        public MultipleCaseClassificationModel(string[] checkedItems, int haCode, bool isInitial, bool isFinal)
        {
            CheckedItems = checkedItems ?? new string[0];
            m_HACode = haCode;
            m_IsInitial = isInitial;
            m_IsFinal = isFinal;
            m_ItemsList = null;
        }

        [LocalizedDisplayName("CaseClassificationsName")]
        public string[] CheckedItems { get; set; }

        public List<SelectListItemSurrogate> ItemsList
        {
            get
            {
                if (m_ItemsList == null)
                {
                    m_ItemsList = FilterHelper.GetCaseClassificationsList(Localizer.CurrentCultureLanguageID, m_HACode, m_IsInitial,
                        m_IsFinal);
                    m_ItemsList.Add(new SelectListItemSurrogate {Text = "<no classification>", Value = "0"});
                }
                return m_ItemsList;
            }
        }

        public override string ToString()
        {
            if (CheckedItems.Length == 0)
            {
                return "";
            }
            var result = new StringBuilder();
            foreach (string item in CheckedItems)
            {
                if (ItemsList.Find(x => x.Value == item) != null)
                {
                    result.AppendFormat("{0},", ItemsList.Find(x => x.Value == item).Text);
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
        }
    }
}