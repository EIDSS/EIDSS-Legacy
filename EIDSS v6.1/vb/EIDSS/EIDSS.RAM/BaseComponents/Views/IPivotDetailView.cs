using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Data.Filtering;
using DevExpress.XtraPivotGrid;
using eidss.avr.db.Common;
using eidss.avr.db.Interfaces;
using eidss.model.Avr.Commands.Layout;

namespace eidss.avr.BaseComponents.Views
{
    public interface IPivotDetailView : IRelatedObjectView, IAvrInvokable
    {
        IAvrPivotGridView PivotGridView { get; }
        string CorrectedLayoutName { get; }

        Form ParentForm { get; }
        IEnumerable<IAvrPivotGridField> AvrFields { get; }
        PivotGridFieldCollectionBase BaseFields { get; }

        IAvrPivotGridField SelectedField { get; }

        AvrPivotGridData DataSource { get; }

        bool ShowData { get; set; }
        bool ShowMissedValues { get; set; }

        CriteriaOperator FilterCriteria { get; set; }

        void FillAbsentAndMissingValues();
        void AddField(IAvrPivotGridField field);
        void RemoveField(IAvrPivotGridField field);
        IAvrPivotGridField GetField(string fieldName);

        void ClickOnFocusedCell(bool forceClick);

        
        void RaisePivotGridDataLoadedCommand();
        PivotGridDataLoadedCommand CreatePivotDataLoadedCommand();
        void RefreshPivotData();
        IDisposable BeginTransaction();
    }
}