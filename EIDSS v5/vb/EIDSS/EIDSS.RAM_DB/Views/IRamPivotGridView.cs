using System;
using System.Collections.Generic;
using System.Data;
using DevExpress.Data.Filtering;
using DevExpress.XtraPivotGrid;
using EIDSS.RAM_DB.Common.EventHandlers;
using EIDSS.RAM_DB.Components;

namespace EIDSS.RAM_DB.Views
{
    public interface IRamPivotGridView : IView
    {
        event PivotFieldVisibleChangedEventHandler FieldVisibleChanged;
        bool LayoutRestoring { get; }

        PivotGridFieldBase GenderField { get; }
        PivotGridFieldBase AgeGroupField { get; }
       // PivotGridFieldBase EventTypeField { get; }

        PivotGridFieldCollectionBase BaseFields { get; }

        List<PivotGridFieldBase> DataAreaFields { get; }
        List<PivotGridFieldBase> ColumnAreaFields { get; }
        List<PivotGridFieldBase> RowAreaFields { get; }
        CriteriaOperator Criteria { get; set; }
        string CriteriaString { get; set; }

        DataTable DataSource { get; set; }
        DataTable DataSourceWithFields { get; set; }
        IList<CustomMapDataItem> GetSelectedCells(PivotGridFieldBase idFieldBase, PivotGridFieldBase typeFieldBase);

        UnitField GetIdUnitFieldName(string unitFieldName);
        IDisposable BeginTransaction();
    }
}