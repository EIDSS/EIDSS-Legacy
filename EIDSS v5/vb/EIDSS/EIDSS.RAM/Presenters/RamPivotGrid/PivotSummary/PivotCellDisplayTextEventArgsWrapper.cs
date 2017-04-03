using bv.common.Core;
using DevExpress.XtraPivotGrid;

namespace EIDSS.RAM.Presenters.RamPivotGrid.PivotSummary
{
    public class PivotCellDisplayTextEventArgsWrapper
    {
        private readonly PivotCellDisplayTextEventArgs m_WinEventArgs;
        private readonly DevExpress.Web.ASPxPivotGrid.PivotCellDisplayTextEventArgs m_WebEventArgs;

        public PivotCellDisplayTextEventArgsWrapper(PivotCellDisplayTextEventArgs winEventArgs)
        {
            Utils.CheckNotNull(winEventArgs, "winEventArgs");
            m_WinEventArgs = winEventArgs;
        }

        public PivotCellDisplayTextEventArgsWrapper
            (DevExpress.Web.ASPxPivotGrid.PivotCellDisplayTextEventArgs webEventArgs)
        {
            Utils.CheckNotNull(webEventArgs, "webEventArgs");
            m_WebEventArgs = webEventArgs;
        }

        public bool IsWeb
        {
            get { return m_WinEventArgs == null; }
        }

        public object Value
        {
            get
            {
                return IsWeb
                           ? m_WebEventArgs.Value
                           : m_WinEventArgs.Value;
            }
        }

        public PivotGridFieldBase DataField
        {
            get
            {
                return IsWeb
                           ? (PivotGridFieldBase) m_WebEventArgs.DataField
                           : m_WinEventArgs.DataField;
            }
        }
        public int ColumnIndex
        {
            get
            {
                return IsWeb
                           ? m_WebEventArgs.ColumnIndex
                           : m_WinEventArgs.ColumnIndex;
            }
        }
        public int RowIndex
        {
            get
            {
                return IsWeb
                           ? m_WebEventArgs.RowIndex
                           : m_WinEventArgs.RowIndex;
            }
        }


        public string DisplayText
        {
            get
            {
                return IsWeb
                           ? m_WebEventArgs.DisplayText
                           : m_WinEventArgs.DisplayText;
            }
            set
            {
                if (IsWeb)
                    m_WebEventArgs.DisplayText = value;
                else
                    m_WinEventArgs.DisplayText = value;
            }
        }

        public object GetCellValue(int columnIndex, int rowIndex)
        {
            return IsWeb
                          ? m_WebEventArgs.GetCellValue(columnIndex, rowIndex)
                          : m_WinEventArgs.GetCellValue(columnIndex, rowIndex);
        }
    }
} ;