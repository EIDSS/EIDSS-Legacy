using bv.common.Core;
using DevExpress.XtraPivotGrid;
using eidss.avr.db.AvrEventArgs.DevExpressEventArgsWrappers;

namespace eidss.avr.Handlers.DevExpressEventArgsWrappers
{
    public class WinPivotGridCellBaseEventArgs : BasePivotGridCellBaseEventArgs
    {
        private readonly PivotCellEventArgs m_WinEventArgs;

        public WinPivotGridCellBaseEventArgs(PivotCellEventArgs winEventArgs)
        {
            Utils.CheckNotNull(winEventArgs, "winEventArgs");
            m_WinEventArgs = winEventArgs;
        }

        public override bool IsWeb
        {
            get { return false; }
        }

        public override object Value
        {
            get { return m_WinEventArgs.Value; }
        }

        public override bool Selected
        {
            get { return m_WinEventArgs.Selected; }
        }

        public override bool Focused
        {
            get { return m_WinEventArgs.Focused; }
        }

        public override PivotGridFieldBase DataField
        {
            get { return m_WinEventArgs.DataField; }
        }

        public override PivotDrillDownDataSource CreateDrillDownDataSource()
        {
            return m_WinEventArgs.CreateDrillDownDataSource();
        }

        public override object GetFieldValue(PivotGridFieldBase idFieldBase)
        {
            Utils.CheckNotNull(idFieldBase, "idFieldBase");

            var idField = (PivotGridField) idFieldBase;
            if (idField == null)
            {
                throw new AvrException(
                    "This method should be called from WebForms only. Parameter idFieldBase should has type DevExpress.Web.ASPxPivotGrid.PivotGridField");
            }
            return m_WinEventArgs.GetFieldValue(idField);
        }
    }
}