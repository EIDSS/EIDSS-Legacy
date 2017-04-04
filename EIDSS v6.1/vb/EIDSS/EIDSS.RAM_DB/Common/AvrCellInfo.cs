using DevExpress.XtraPivotGrid;

namespace eidss.avr.db.Common
{
    public class AvrCellInfo
    {
        public AvrCellInfo(PivotCellEventArgs info)
        {
            Info = info;
            Value = info.Value;
        }

        public PivotCellEventArgs Info { get; private set; }

        public object Value { get; private set; }
    }
}