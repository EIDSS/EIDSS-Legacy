using System.ComponentModel;
using bv.common.Core;
using DevExpress.Data.PivotGrid;
using DevExpress.XtraPivotGrid;
using EIDSS.RAM_DB.Components;

namespace EIDSS.RAM.Presenters.RamPivotGrid.PivotSummary
{
    public class PivotGridCustomSummaryEventArgsWrapper
    {
        private readonly PivotGridCustomSummaryEventArgs m_WinEventArgs;
        private readonly DevExpress.Web.ASPxPivotGrid.PivotGridCustomSummaryEventArgs m_WebEventArgs;

        public PivotGridCustomSummaryEventArgsWrapper(PivotGridCustomSummaryEventArgs winEventArgs)
        {
            Utils.CheckNotNull(winEventArgs, "winEventArgs");
            m_WinEventArgs = winEventArgs;
        }

        public PivotGridCustomSummaryEventArgsWrapper
            (DevExpress.Web.ASPxPivotGrid.PivotGridCustomSummaryEventArgs webEventArgs)
        {
            Utils.CheckNotNull(webEventArgs, "webEventArgs");
            m_WebEventArgs = webEventArgs;
        }

        public bool IsWeb
        {
            get { return m_WinEventArgs == null; }
        }

        public object CustomValue
        {
            get
            {
                return IsWeb
                           ? m_WebEventArgs.CustomValue
                           : m_WinEventArgs.CustomValue;
            }
            set
            {
                if (IsWeb)
                    m_WebEventArgs.CustomValue = value;
                else
                    m_WinEventArgs.CustomValue = value;
            }
        }

        [Description("Gets the data field against which the summary is calculated.")]
        public PivotGridFieldBase DataField
        {
            get
            {
                return IsWeb
                           ? m_WebEventArgs.DataField
                           : m_WinEventArgs.DataField;
            }
        }

        [Description("Gets the column field which corresponds to the current cell.")]
        public PivotGridFieldBase ColumnField
        {
            get
            {
                return IsWeb
                           ? (PivotGridFieldBase)m_WebEventArgs.ColumnField
                           : m_WinEventArgs.ColumnField;
            }
        }

        [Description("Gets the row field which corresponds to the current cell.")]
        public PivotGridFieldBase RowField
        {
            get
            {
                return IsWeb
                           ? (PivotGridFieldBase)m_WebEventArgs.RowField
                           : m_WinEventArgs.RowField;
            }
        }

        public PivotSummaryValue SummaryValue
        {
            get
            {
                return IsWeb
                           ? m_WebEventArgs.SummaryValue
                           : m_WinEventArgs.SummaryValue;
            }
        }

        public bool IsDataFieldNumeric
        {
            get
            {
                return IsWeb
                           ? ((WebPivotGridField) DataField).IsNumeric
                           : ((WinPivotGridField) DataField).IsNumeric;
            }
        }

        public PivotDrillDownDataSource CreateDrillDownDataSource()
        {
            return IsWeb
                       ? m_WebEventArgs.CreateDrillDownDataSource()
                       : m_WinEventArgs.CreateDrillDownDataSource();
        }
    }
}