using System;
using System.Collections.Generic;
using System.Text;
using eidss.model.Core;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public abstract class BaseMultipleModel : IDisposable
    {
        private List<SelectListItemSurrogate> m_ItemsList;

        protected BaseMultipleModel()
        {
            CheckedItems = new string[0];
        }

        [LocalizedDisplayName("DiagnosisName")]
        public string[] CheckedItems { get; set; }

        public List<SelectListItemSurrogate> ItemsList
        {
            get { return m_ItemsList ?? (m_ItemsList = LoadItemList()); }
        }

        public abstract List<SelectListItemSurrogate> LoadItemList();

        public string ToXml()
        {
            return FilterHelper.GetXmlFromList(CheckedItems);
        }

        public override string ToString()
        {
            if (CheckedItems == null || CheckedItems.Length == 0)
            {
                return string.Empty;
            }
            var result = new StringBuilder();
            bool notFirst = false;
            foreach (string item in CheckedItems)
            {
                if (notFirst)
                {
                    result.Append(", ");
                }
                SelectListItemSurrogate found = ItemsList.Find(x => x.Value == item);
                if (found != null)
                {
                    result.Append(found.Text);
                }
                else
                {
                    result.AppendFormat("Could not find item with Id={0}", item);
                }
                notFirst = true;
            }
            return result.ToString().TrimEnd(',');
        }

        public virtual void Dispose()
        {
            if (m_ItemsList != null)
            {
                m_ItemsList.Clear();
            }
            CheckedItems = null;
        }
    }
}