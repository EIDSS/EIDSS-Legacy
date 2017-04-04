using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.winclient.Core;
using eidss.winclient.Helpers;
using eidss.winclient.Schema;

namespace eidss.winclient.Administration
{
    public partial class CustomReportRowsDetail : BaseGroupPanel_CustomReportRow
    {
        public CustomReportRowsDetail()
        {
            InitializeComponent();
            Field2LookupMap = new Dictionary<string, string>
                {
                    {"idfsDiagnosisOrGroup", "DiagnosisOrReportGroupLookup"},
                    {"idfsDiagnosisOrReportDiagnosisGroup", "DiagnosisLookup"}
                };

        }

        private CustomReportRow fakeCustomReportRow { get; set; }

        public override void InitGridBehavior(IObject dummyObjectWithLookups, DbManagerProxy manager)
        {
            fakeCustomReportRow = dummyObjectWithLookups as CustomReportRow;
            if (fakeCustomReportRow == null) return;

            var column = Grid.GridView.Columns.ColumnByName("intRowOrder");
            if (column != null)
            {
                column.SortOrder = ColumnSortOrder.Ascending;
                column.OptionsColumn.AllowSort = DefaultBoolean.False;
            }

            column = Grid.GridView.Columns.ColumnByName("idfsDiagnosisOrGroup");
            if (column != null)
            {
                //Diagnosis or Report Group Diagnoses
                var lookup = DiagnosisOrReportGroupLookup.Accessor.Instance(null).SelectLookupList(manager);
                LookupBinder.BindRepositoryLookup(column.SetLookupEditor(), "idfsReference", "name", lookup);
            }

            column = Grid.GridView.Columns.ColumnByName("idfsDiagnosisOrReportDiagnosisGroup");
            if (column != null)
            {
                var le = column.SetLookupEditor();
                var lookup = DiagnosesAndGroupsLookup.Accessor.Instance(null)
                                                     .SelectLookupList(manager, null, null, (long)BaseReferenceType.rftReportDiagnosisGroup);
                LookupBinder.BindRepositoryLookup(le, "idfsDiagnosisOrDiagnosisGroup", "name", lookup);
            }

            column = Grid.GridView.Columns.ColumnByName("strUsingType");
            if (column != null) GridHelper.SetColumnState(column, true);

            column = Grid.GridView.Columns.ColumnByName("idfsReportAdditionalText");
            if (column != null)
            {
                LookupBinder.BindBaseRepositoryLookup(column.SetLookupEditor(), fakeCustomReportRow.ReportAdditionalTextLookup);
            }

            column = Grid.GridView.Columns.ColumnByName("idfsICDReportAdditionalText");
            if (column != null)
            {
                LookupBinder.BindBaseRepositoryLookup(column.SetLookupEditor(), fakeCustomReportRow.ICDReportAdditionalTextLookup);
            }

            Grid.GridView.InitNewRow += InitNewMatrixRow;
            Grid.GridView.RowUpdated += GridView_RowUpdated;
            TopPanelVisible = false;
        }

        void GridView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            var crr = e.Row as CustomReportRow;
            if ((crr == null) || (crr.Master == null)) return;
            crr.Master.RecalculateRowNumber(crr);
        }

 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitNewMatrixRow(object sender, InitNewRowEventArgs e)
        {
            var obj = Grid.GridView.GetRow(e.RowHandle);
            var rd = obj as CustomReportRow;
            if (rd == null) return;
            if (IdfsSummaryReportType.HasValue)
                rd.idfsCustomReportType = IdfsSummaryReportType.Value;
        }

        private long? m_IdfsSummaryReportType;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(false)]
        public long? IdfsSummaryReportType
        {
            get { return m_IdfsSummaryReportType; }
            set
            {
                m_IdfsSummaryReportType = value;
                Refresh(DataSource, m_IdfsSummaryReportType.HasValue
                    ? String.Format("idfsCustomReportType={0}", m_IdfsSummaryReportType.Value)
                    : "idfsCustomReportType=-1");
            }
        }
    }
}
