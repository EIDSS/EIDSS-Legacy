using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraPivotGrid;
using eidss.avr.db.Common;
using eidss.avr.db.Interfaces;
using eidss.model.Avr.Commands.Layout;

namespace eidss.avr.BaseComponents.Views
{
    public interface IPivotDetailView : IRelatedObjectView
    {
        IAvrPivotGridView PivotGridView { get; }
        string CorrectedLayoutName { get; }
        
        Form ParentForm { get; }
        IEnumerable<IAvrPivotGridField> AvrFields { get; }
        PivotGridFieldCollectionBase BaseFields { get; }

        IAvrPivotGridField SelectedField { get; }

        AvrPivotGridData DataSource { get; }

        bool ShowData { get; }

        void RejectChangesAddMissingValues(bool getNewData = false);
        void AddField(IAvrPivotGridField field);
        void RemoveField(IAvrPivotGridField field);
        IAvrPivotGridField GetField(string fieldName);

        void InitFilterControlHelperAndRefreshFilter();

        void FillDataSourceWithAbsentValues();

        void ClickOnFocusedCell(bool forceClick);
       

        void ShowFilterForm();
        void RaisePivotGridDataLoadedCommand();
        PivotGridDataLoadedCommand CreatePivotDataLoadedCommand();
        void RefreshPivotData();
    }
}