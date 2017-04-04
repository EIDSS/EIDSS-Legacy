using DevExpress.XtraPivotGrid;
using eidss.avr.db.AvrEventArgs.DevExpressEventArgsWrappers;
using PivotFieldDisplayTextEventArgs = DevExpress.Web.ASPxPivotGrid.PivotFieldDisplayTextEventArgs;

namespace eidss.avr.mweb.Utils
{
    public class WebPivotFieldDisplayTextEventArgs : BasePivotFieldDisplayTextEventArgs
    {
        private readonly PivotFieldDisplayTextEventArgs m_WebEventArgs;

        public WebPivotFieldDisplayTextEventArgs(PivotFieldDisplayTextEventArgs webEventArgs)
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

        public override bool IsPopulatingFilterDropdown
        {
            get { return m_WebEventArgs.IsPopulatingFilterDropdown; }
        }

        public override bool IsColumn
        {
            get { return m_WebEventArgs.IsColumn; }
        }

        public override PivotGridFieldBase DataField
        {
            get { return m_WebEventArgs.DataField; }
        }

        public override PivotGridValueType ValueType
        {
            get { return m_WebEventArgs.ValueType; }
        }

        public override string DisplayText
        {
            get { return m_WebEventArgs.DisplayText; }
            set { m_WebEventArgs.DisplayText = value; }
        }
    }
}