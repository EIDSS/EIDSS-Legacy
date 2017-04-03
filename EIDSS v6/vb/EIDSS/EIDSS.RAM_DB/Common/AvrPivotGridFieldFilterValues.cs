using System;
using DevExpress.XtraPivotGrid;
using eidss.model.Helpers;

namespace eidss.avr.db.Common
{
    [Serializable]
    public class AvrPivotGridFieldFilterValues
    {
        private static readonly EidssSerializer<AvrPivotGridFieldFilterValues> m_Serializer =
            new EidssSerializer<AvrPivotGridFieldFilterValues>();

        #region Properties

        public string DeferFilterString { get; set; }
        public bool ShowBlanks { get; set; }
        public PivotFilterType FilterType { get; set; }
        public object[] Values { get; set; }

        public bool IsDefaultValue
        {
            get
            {
                return ShowBlanks &&
                       FilterType == PivotFilterType.Excluded &&
                       Values != null && Values.Length == 0 &&
                       string.IsNullOrEmpty(DeferFilterString);
            }
        }

        #endregion

        public void CopyPropertiesTo(PivotGridFieldFilterValues filter)
        {
            filter.SetValues(Values, FilterType, ShowBlanks);
            filter.DeferFilterString = DeferFilterString;
        }

        public string Serialize()
        {
            return Serialize(this);
        }

        public static string Serialize(AvrPivotGridFieldFilterValues filter)
        {
            return m_Serializer.Serialize(filter);
        }

        public static AvrPivotGridFieldFilterValues Deserialize(string xml)
        {
            return m_Serializer.Deserialize(xml);
        }

        public static explicit operator AvrPivotGridFieldFilterValues(PivotGridFieldFilterValues filter)
        {
            var result = new AvrPivotGridFieldFilterValues
            {
                DeferFilterString = filter.DeferFilterString,
                ShowBlanks = filter.ShowBlanks,
                FilterType = filter.FilterType,
                Values = filter.Values
            };
            return result;
        }
    }
}