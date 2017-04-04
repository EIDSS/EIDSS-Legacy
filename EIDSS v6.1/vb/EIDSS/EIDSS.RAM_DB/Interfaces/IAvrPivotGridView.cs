using System;
using System.IO;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.Data;
using eidss.avr.db.Common;
using eidss.model.AVR.SourceData;

namespace eidss.avr.db.Interfaces
{
    public interface IAvrPivotGridView : IAvrBasePivotGridView, IBaseAvrView
    {
        void ClearCacheDataRowColumnAreaFields();

        DisplayTextHandler DisplayTextHandler { get; }

        PivotGridCells Cells { get; }
        PivotGridViewInfoData PivotData { get; }
        AvrPivotGridData DataSource { get; set; }

        void SetDataSourceAndCreateFields(AvrDataTable value);
        IDisposable BeginTransaction();

        void RestoreLayoutFromStream(Stream stream);
        void SaveLayoutToStream(Stream stream);
    }
}