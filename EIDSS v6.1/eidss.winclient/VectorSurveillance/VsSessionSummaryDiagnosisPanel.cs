using System;
using System.Collections.Generic;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.winclient.Core;
using eidss.winclient.Helpers;
using eidss.winclient.Schema;

namespace eidss.winclient.VectorSurveillance
{
    public partial class VsSessionSummaryDiagnosisPanel : BaseGroupPanel_VsSessionSummaryDiagnosis
    {
        private GridColumnCollection Columns { get { return Grid.GridView.Columns; } }

        /// <summary>
        /// 
        /// </summary>
        public VsSessionSummaryDiagnosisPanel()
        {
            InitializeComponent();
            EditByDoubleClick = true;
            TopPanelVisible = true;
            SearchPanelVisible = false;
            InlineMode = InlineMode.UseNewRow;

            //скрываем столбцы, которые должны быть видны только в веб-варианте
            Columns.HideColumn("strDiagnosis");
            Field2LookupMap = new Dictionary<string, string> { { "idfsDiagnosis", "DiagnosesLookup" } };
        }

        void OnAfterActionExecuted(IBasePanel panel, ActionMetaItem action, IObject bo)
        {
            //if (action.ActionType == ActionTypes.Delete)
            //{
            //    InvokeNeedDiagnosesRefreshing();
            //    //у парента тоже заголовок пересчитаем
            //    var d = bo as VsSessionSummaryDiagnosis;
            //    if ((d != null) && (d.SessionSummary != null))
            //    {
            //        var s = d.SessionSummary.strDiagnosesSummary;
            //    }
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public override string GetDetailFormName(IObject o)
        {
            return "VsSessionSummaryDiagnosisPanel";
        }

        private VsSessionSummaryDiagnosis fakeSSD { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dummyObjectWithLookups"></param>
        /// <param name="manager"></param>
        public override void InitGridBehavior(IObject dummyObjectWithLookups, DbManagerProxy manager)
        {
            base.InitGridBehavior(dummyObjectWithLookups, manager);

            fakeSSD = dummyObjectWithLookups as VsSessionSummaryDiagnosis;
            if (fakeSSD == null) return;

            //idfsDiagnosis
            var column = Grid.GridView.Columns.ColumnByName("idfsDiagnosis");
            if (column != null)
            {
                DiagnosesLookup = column.SetLookupEditor();
                var lookup = DiagnosisLookup.Accessor.Instance(null).SelectLookupList(manager);
                LookupBinder.BindDiagnosisRepositoryLookup(DiagnosesLookup, lookup, HACode.All);
                DiagnosesLookup.EditValueChanged += OnDiagnosisEditValueChanged;
                column.Width = 80;
            }

            //intPositiveQuantity
            column = Grid.GridView.Columns.ColumnByName("intPositiveQuantity");
            if (column != null)
            {
                PositiveQuantitySpinEditor = column.SetSpinEditor();
                LookupBinder.BindRepositorySpinEdit(PositiveQuantitySpinEditor, 0, Int32.MaxValue);
                column.Width = 80;
            }
            Grid.GridView.RowCountChanged += OnRowCountChanged;
            var layout = GetLayout();
            if (layout != null) layout.OnAfterActionExecuted += OnAfterActionExecuted;
        }

        private void OnRowCountChanged(object sender, EventArgs e)
        {
            InvokeNeedDiagnosesRefreshing();
        }

        public void FinishEdit()
        {
            Grid.GridView.PostEditor();
        }

        public bool ValidateRow()
        {
            FinishEdit();
            var isValid = true;
            //проверяем, если есть строка, которая редактируется, и строка валидна, то оканчиваем её ввод
            //иначе ее ввод отменяем
            var row = Grid.GridView.GetFocusedRow() as VsSessionSummaryDiagnosis;
            if (row != null)
            {
                var acc = VsSessionSummaryDiagnosis.Accessor.Instance(null);
                try
                {
                    m_ValidatingRow = true;
                    using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        isValid = acc.Validate(manager, row, true, false, false);
                    }
                }
                finally
                {

                    m_ValidatingRow = false;
                }
            }
            
            return isValid;
        }

        RepositoryItemLookUpEdit DiagnosesLookup { get; set; }
        RepositoryItemSpinEdit PositiveQuantitySpinEditor { get; set; }

        void OnDiagnosisEditValueChanged(object sender, EventArgs e)
        {
            Grid.GridView.PostEditor();
            if (Grid.GridView.FocusedRowHandle != GridControl.NewItemRowHandle)
                InvokeNeedDiagnosesRefreshing();
        }

        public delegate void NeedRefreshDelegate();

        /// <summary>
        /// Событие, которое требует пересчёта диагнозов
        /// </summary>
        public event NeedRefreshDelegate NeedDiagnosesRefreshing;

        /// <summary>
        /// 
        /// </summary>
        public void InvokeNeedDiagnosesRefreshing()
        {
            if (NeedDiagnosesRefreshing != null) NeedDiagnosesRefreshing();
        }
    }
}
