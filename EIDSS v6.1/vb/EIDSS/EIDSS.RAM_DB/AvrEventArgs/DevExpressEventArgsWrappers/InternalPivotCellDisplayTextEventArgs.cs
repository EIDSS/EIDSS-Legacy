using DevExpress.XtraPivotGrid;
using eidss.avr.db.Common;

namespace eidss.avr.db.AvrEventArgs.DevExpressEventArgsWrappers
{
    public class InternalPivotCellDisplayTextEventArgs : BasePivotCellDisplayTextEventArgs
    {
        private readonly object m_Value;
        private readonly IAvrPivotGridField m_DataField;
        private string m_DisplayText;
        private readonly bool m_IsWeb;

        public InternalPivotCellDisplayTextEventArgs(object value, IAvrPivotGridField dataField, bool isWeb)
        {
            m_Value = value;
            m_DataField = dataField;
            m_IsWeb = isWeb;

            m_DisplayText = m_Value == null ? string.Empty : m_Value.ToString();
        }

        public override bool IsWeb
        {
            get { return m_IsWeb; }
        }

        public override object Value
        {
            get { return m_Value; }
        }

        public override PivotGroupInterval GroupInterval
        {
            get
            {
                return m_DataField != null
                    ? m_DataField.GroupInterval
                    : PivotGroupInterval.DateMonth;
            }
        }

        public override bool IsDataFieldNull
        {
            get { return m_DataField == null; }
        }

        public override int ColumnIndex
        {
            get { return 0; }
        }

        public override int RowIndex
        {
            get { return 0; }
        }

        public override string DisplayText
        {
            get { return m_DisplayText; }
            set { m_DisplayText = value; }
        }

        public override bool HasDrillDownDataSource
        {
            get { return false; }
        }

        public override object GetCellValue(int columnIndex, int rowIndex)
        {
            return null;
        }
    }
}