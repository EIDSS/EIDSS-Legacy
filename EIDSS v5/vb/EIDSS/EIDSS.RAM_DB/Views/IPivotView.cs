using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraPivotGrid;
using EIDSS.RAM_DB.Common.EventHandlers;
using EIDSS.RAM_DB.Components;
using EIDSS.RAM_DB.DBService.DataSource;

namespace EIDSS.RAM_DB.Views
{
    public interface IPivotView : IRelatedObjectView
    {
        event EventHandler<PivotSelectionEventArgs> PivotSelected;
        event EventHandler<PivotDataEventArgs> PivotDataLoaded;
        event EventHandler<ComboBoxEventArgs> InitAdmUnit;
        event EventHandler<ComboBoxEventArgs> InitStatDate;
        event EventHandler<ComboBoxEventArgs> InitDenominator;

        string CorrectedLayoutName { get; }
        DataTable FilteredDataSource { get; }
        Form ParentForm { get; }
        IEnumerable<WinPivotGridField> WinFields { get; }
		PivotGridFieldCollectionBase BaseFields{ get; }

        LayoutDetailDataSet.AggregateRow SelectedRow { get; }
        
        DataTable DataSource { get; }

        void AddField(WinPivotGridField field);
        void RemoveField(WinPivotGridField field);
        WinPivotGridField GetField(string fieldName);
        IList<CustomMapDataItem> GetSelectedCells(PivotGridField idField, PivotGridField typeField);
        void InitFilterControlHelperAndRefreshFilter();
        

        void OnChangeOrientation(ChartChangeOrientationEventArgs e);
        void ShowFilterForm();
        void RaiseDataLoadedEvent();
        void RefreshData();
    }
}