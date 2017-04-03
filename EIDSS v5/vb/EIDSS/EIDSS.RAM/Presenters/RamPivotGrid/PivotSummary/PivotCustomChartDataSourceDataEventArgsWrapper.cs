using bv.common.Core;
using DevExpress.XtraPivotGrid;
using PivotGridField = DevExpress.Web.ASPxPivotGrid.PivotGridField;

namespace EIDSS.RAM.Presenters.RamPivotGrid.PivotSummary
{
    public class PivotCustomChartDataSourceDataEventArgsWrapper
    {
        private readonly PivotCustomChartDataSourceDataEventArgs m_WinEventArgs;
        private readonly DevExpress.Web.ASPxPivotGrid.PivotCustomChartDataSourceDataEventArgs m_WebEventArgs;

        public PivotCustomChartDataSourceDataEventArgsWrapper(PivotCustomChartDataSourceDataEventArgs winEventArgs)
        {
            Utils.CheckNotNull(winEventArgs, "winEventArgs");
            m_WinEventArgs = winEventArgs;
        }

        public PivotCustomChartDataSourceDataEventArgsWrapper
            (DevExpress.Web.ASPxPivotGrid.PivotCustomChartDataSourceDataEventArgs webEventArgs)
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
            set
            {
                if (IsWeb)
                {
                    m_WebEventArgs.Value = value;
                }
                else
                {
                    m_WinEventArgs.Value = value;
                }
            }
        }

        public double DoubleValue
        {
            get { return PivotPresenter.ConvertValueToDouble(Value); }
        }

        public PivotChartItemType ItemType
        {
            get
            {
                return IsWeb
                           ? m_WebEventArgs.ItemType
                           : m_WinEventArgs.ItemType;
            }
        }

        public PivotChartItemDataMember ItemDataMember
        {
            get
            {
                return IsWeb
                           ? m_WebEventArgs.ItemDataMember
                           : m_WinEventArgs.ItemDataMember;
            }
        }

        public PivotGridFieldBase DataField
        {
            get
            {
                return IsWeb
                           ? m_WebEventArgs.CellInfo.DataField
                           : (PivotGridFieldBase)m_WinEventArgs.CellInfo.DataField;
               

            }
        }

        public PivotDrillDownDataSource CellInfoCreateDrillDownDataSource()
        {
            return IsWeb
                       ? m_WebEventArgs.CellInfo.CreateDrillDownDataSource()
                       : m_WinEventArgs.CellInfo.CreateDrillDownDataSource();
        }
    }
} ;