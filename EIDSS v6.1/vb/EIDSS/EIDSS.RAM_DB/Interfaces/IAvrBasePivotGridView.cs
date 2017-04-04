using System.Collections.Generic;
using DevExpress.XtraPivotGrid;
using eidss.avr.db.Common;

namespace eidss.avr.db.Interfaces
{
    public interface IAvrBasePivotGridView
    {
        bool LayoutRestoring { get; }

        IAvrPivotGridField GenderField { get; }
        IAvrPivotGridField AgeGroupField { get; }

        PivotGridFieldCollectionBase BaseFields { get; }

        List<IAvrPivotGridField> DataAreaFields { get; }
        List<IAvrPivotGridField> ColumnAreaFields { get; }
        List<IAvrPivotGridField> RowAreaFields { get; }

        bool SingleSearchObject { get; }
    }
}