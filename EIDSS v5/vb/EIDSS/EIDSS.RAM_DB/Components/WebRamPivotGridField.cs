using System;
using DevExpress.Web.ASPxPivotGrid;

namespace EIDSS.RAM_DB.Components
{
    public class WebPivotGridField : PivotGridField
    {
        private Type m_FieldDataType;
        private bool m_IsNumeric;

        public Type FieldDataType
        {
            get { return m_FieldDataType; }
            set
            {
                m_FieldDataType = value;
                m_IsNumeric = (
                                  value == typeof (long) ||
                                  value == typeof (int) ||
                                  value == typeof (decimal) ||
                                  value == typeof (float) ||
                                  value == typeof (double)
                              );
            }
        }

        /// <summary>
        /// Gets or sets the fields's Name
        /// DON'T USE IT IN YOUR CODE except single setting when new field creating. Use FieldName instead.
        /// </summary>
#pragma warning disable 612,618
        public override string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }
#pragma warning restore 612,618
        public bool IsNumeric
        {
            get { return m_IsNumeric; }
        }

        public CustomSummaryType GetSummaryType
        {
            get
            {
                CustomSummaryType summaryType = Configuration.GetSummaryTypeFor(FieldName, DataType);
                return summaryType;
            }
        }

        public string OriginalName
        {
            get { return RamPivotGridHelper.GetOriginalNameFromFieldName(FieldName); }
        }

        public long Id
        {
            get { return RamPivotGridHelper.GetIdFromFieldName(FieldName); }
        }
    }
}