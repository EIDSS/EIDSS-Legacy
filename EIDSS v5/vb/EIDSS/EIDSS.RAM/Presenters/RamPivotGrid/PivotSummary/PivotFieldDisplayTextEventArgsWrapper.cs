using bv.common.Core;
using DevExpress.XtraPivotGrid;

namespace EIDSS.RAM.Presenters.RamPivotGrid.PivotSummary
{
    public class PivotFieldDisplayTextEventArgsWrapper
    {
        private readonly PivotFieldDisplayTextEventArgs m_WinEventArgs;
        private readonly DevExpress.Web.ASPxPivotGrid.PivotFieldDisplayTextEventArgs m_WebEventArgs;

        public PivotFieldDisplayTextEventArgsWrapper(PivotFieldDisplayTextEventArgs winEventArgs)
        {
            Utils.CheckNotNull(winEventArgs, "winEventArgs");
            m_WinEventArgs = winEventArgs;
        }

        public PivotFieldDisplayTextEventArgsWrapper
            (DevExpress.Web.ASPxPivotGrid.PivotFieldDisplayTextEventArgs webEventArgs)
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

        public bool IsPopulatingFilterDropdown
        {
            get
            {
                return IsWeb
                           ? m_WebEventArgs.IsPopulatingFilterDropdown
                           : m_WinEventArgs.IsPopulatingFilterDropdown;
            }
        }

        public bool IsColumn
        {
            get
            {
                return IsWeb
                           ? m_WebEventArgs.IsColumn
                           : m_WinEventArgs.IsColumn;
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

        public PivotGridValueType ValueType
        {
            get
            {
                return IsWeb
                           ? m_WebEventArgs.ValueType
                           : m_WinEventArgs.ValueType;
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
    }
} ;