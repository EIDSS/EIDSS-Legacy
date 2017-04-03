using bv.common.Core;
using DevExpress.Data.PivotGrid;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.Data;
using eidss.avr.db.AvrEventArgs.DevExpressEventArgsWrappers;
using eidss.avr.db.Common;
using PivotGridField = DevExpress.Web.ASPxPivotGrid.PivotGridField;

namespace eidss.avr.mweb.Utils
{
    public class WebPivotGridCustomSummaryEventArgs : BasePivotGridCustomSummaryEventArgs
    {
        private readonly PivotGridCustomSummaryEventArgsBase<PivotGridField> m_WebEventArgs;

        public WebPivotGridCustomSummaryEventArgs(PivotGridCustomSummaryEventArgsBase<PivotGridField> webEventArgs)
        {
            bv.common.Core.Utils.CheckNotNull(webEventArgs, "webEventArgs");
            m_WebEventArgs = webEventArgs;
        }

        public override bool IsWeb
        {
            get { return true; }
        }

        public override object CustomValue
        {
            get { return m_WebEventArgs.CustomValue; }
            set { m_WebEventArgs.CustomValue = value; }
        }

        public override PivotGridFieldBase DataField
        {
            get { return m_WebEventArgs.DataField; }
        }

        public override PivotGridFieldBase ColumnField
        {
            get { return m_WebEventArgs.ColumnField; }
        }

        public override PivotGridFieldBase RowField
        {
            get { return m_WebEventArgs.RowField; }
        }

        public override PivotSummaryValue SummaryValue
        {
            get { return m_WebEventArgs.SummaryValue; }
        }

        public override bool IsDataFieldNumeric
        {
            //todo: check that we really should use actualdata type
            get { return DataField.ActualDataType.IsNumeric(); }
        }

        public override PivotDrillDownDataSource CreateDrillDownDataSource()
        {
            return m_WebEventArgs.CreateDrillDownDataSource();
        }
    }
}