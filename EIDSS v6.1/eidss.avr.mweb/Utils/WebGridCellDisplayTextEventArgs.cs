using DevExpress.Web;
using eidss.avr.db.AvrEventArgs.DevExpressEventArgsWrappers;

namespace eidss.avr.mweb.Utils
{
    public class WebGridCellDisplayTextEventArgs : BaseGridViewCellDisplayTextEventArgs
    {
        private readonly ASPxGridViewTableDataCellEventArgs m_WebEventArgs;

        public WebGridCellDisplayTextEventArgs(ASPxGridViewTableDataCellEventArgs webEventArgs)
        {
            bv.common.Core.Utils.CheckNotNull(webEventArgs, "webEventArgs");
            m_WebEventArgs = webEventArgs;
        }

        public override object Value
        {
            get { return m_WebEventArgs.CellValue; }
        }

        public override string DisplayText
        {
            get { return m_WebEventArgs.Cell.Text; }
            set { m_WebEventArgs.Cell.Text = value; }
        }
    }
}