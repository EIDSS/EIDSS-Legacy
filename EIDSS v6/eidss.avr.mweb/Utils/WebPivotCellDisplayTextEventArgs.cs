using DevExpress.XtraPivotGrid;
using eidss.avr.db.AvrEventArgs.DevExpressEventArgsWrappers;
using PivotCellDisplayTextEventArgs = DevExpress.Web.ASPxPivotGrid.PivotCellDisplayTextEventArgs;

namespace eidss.avr.mweb.Utils
{
    public class WebPivotCellDisplayTextEventArgs : BasePivotCellDisplayTextEventArgs
    {
        private readonly PivotCellDisplayTextEventArgs m_WebEventArgs;

        public WebPivotCellDisplayTextEventArgs(PivotCellDisplayTextEventArgs webEventArgs)
        {
            bv.common.Core.Utils.CheckNotNull(webEventArgs, "webEventArgs");
            m_WebEventArgs = webEventArgs;
        }

        public override bool IsWeb
        {
            get { return true; }
        }

        public override object Value
        {
            get { return m_WebEventArgs.Value; }
        }

        public override PivotGroupInterval GroupInterval
        {
            get
            {
                return m_WebEventArgs.DataField != null
                    ? m_WebEventArgs.DataField.GroupInterval
                    : PivotGroupInterval.DateMonth;
            }
        }

        public override bool IsDataFieldNull
        {
            get { return m_WebEventArgs.DataField == null; }
        }

        public override int ColumnIndex
        {
            get { return m_WebEventArgs.ColumnIndex; }
        }

        public override int RowIndex
        {
            get { return m_WebEventArgs.RowIndex; }
        }

        public override string DisplayText
        {
            get { return m_WebEventArgs.DisplayText; }
            set { m_WebEventArgs.DisplayText = value; }
        }

        public override object GetCellValue(int columnIndex, int rowIndex)
        {
            return m_WebEventArgs.GetCellValue(columnIndex, rowIndex);
        }
    }
}