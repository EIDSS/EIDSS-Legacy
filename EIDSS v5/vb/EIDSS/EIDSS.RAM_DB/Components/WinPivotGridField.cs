using System;
using System.ComponentModel;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraReports.UI.PivotGrid;
using EIDSS.RAM.Presenters.RamPivotGrid;
using bv.common.Core;

namespace EIDSS.RAM_DB.Components
{
    public class WinPivotGridField : XRPivotGridField
    {
        private Type m_FieldDataType;
        private bool m_IsNumeric;
        private bool m_IsFilter;

        public Type FieldDataType
        {
            get { return m_FieldDataType; }
            set
            {
                m_FieldDataType = value;
                m_IsNumeric = (
                                  value == typeof(long) ||
                                  value == typeof(int) ||
                                  value == typeof(decimal) ||
                                  value == typeof(float) ||
                                  value == typeof(double)
                              );
            }
        }

        /// <summary>
        /// Gets or sets the fields's Name
        /// DON'T USE IT IN YOUR CODE except single setting when new field creating. Use FieldName instead.
        /// </summary>
        public override string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }

        public bool IsNumeric
        {
            get { return m_IsNumeric; }
        }


        public bool IsFilter
        {
            get { return m_IsFilter; }
            set { m_IsFilter = value;

                Area = (m_IsFilter)
                           ? PivotArea.FilterArea
                           : PivotArea.RowArea;
                AllowedAreas = (m_IsFilter)
                                   ? PivotGridAllowedAreas.FilterArea
                                   : PivotGridAllowedAreas.All ^ PivotGridAllowedAreas.FilterArea;
            }
        }

        public CustomSummaryType GetSummaryType
        {
            get
            {
                CustomSummaryType summaryType = Configuration.GetSummaryTypeFor(FieldName, DataType);
                return summaryType;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DateGroupIntervalChanging { get; set; }

        public string OriginalName
        {
            get { return RamPivotGridHelper.GetOriginalNameFromFieldName(FieldName); }
        }

        public long Id
        {
            get { return RamPivotGridHelper.GetIdFromFieldName(FieldName); }
        }

        public void UpdateFieldGroupInterval(PivotGroupInterval groupInterval)
        {
            if (!Visible || IsFilter)
            {
                return;
            }

            if ((DataType == typeof(DateTime)) || GroupInterval.IsDate())
            {
                GroupInterval = groupInterval;
            }
        }
    }
}
