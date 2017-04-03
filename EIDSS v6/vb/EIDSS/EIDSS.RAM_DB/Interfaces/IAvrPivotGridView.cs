using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using DevExpress.Data.Filtering;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.Data;
using eidss.avr.db.Common;

namespace eidss.avr.db.Interfaces
{
    public interface IAvrPivotGridView : IBaseAvrView
    {
        bool LayoutRestoring { get; }

        IAvrPivotGridField GenderField { get; }
        IAvrPivotGridField AgeGroupField { get; }

        PivotGridFieldCollectionBase BaseFields { get; }

        List<IAvrPivotGridField> DataAreaFields { get; }
        List<IAvrPivotGridField> ColumnAreaFields { get; }
        List<IAvrPivotGridField> RowAreaFields { get; }

        void ClearCacheDataRowColumnAreaFields();

        CriteriaOperator Criteria { get; set; }
        string CriteriaString { get; set; }

        DisplayTextHandler DisplayTextHandler { get; }

        PivotGridCells Cells { get; }
        PivotGridViewInfoData PivotData { get; }
        AvrPivotGridData DataSource { get; set; }

        void SetDataSourceAndCreateFields(DataTable value);
        IDisposable BeginTransaction();

        void RestoreLayoutFromStream(Stream stream);
        void SaveLayoutToStream(Stream stream);
    }
}