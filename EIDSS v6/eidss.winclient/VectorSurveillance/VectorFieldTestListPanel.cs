using System;
using System.Collections.Generic;
using System.ComponentModel;
using bv.common.Configuration;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.winclient.Core;
using eidss.winclient.Helpers;
using eidss.winclient.Schema;
using System.Linq;
using bv.winclient.BasePanel;

namespace eidss.winclient.VectorSurveillance
{
    public partial class VectorFieldTestListPanel : BaseGroupPanel_VectorFieldTest
    {
        /// <summary>
        /// 
        /// </summary>
        private GridColumnCollection Columns { get { return Grid.GridView.Columns; } }

        /// <summary>
        /// Текущий режим работы
        /// </summary>
        public static PanelWorkModes WorkMode { get; set; }
        
        private VectorFieldTest fakeFieldTest { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public VectorFieldTestListPanel()
        {
            InitializeComponent();

            if (BaseSettings.ScanFormsMode) return;
            
            EditByDoubleClick = false;
            TopPanelVisible = true;
            Grid.GridView.OptionsView.ColumnAutoWidth = false;
            SearchPanelVisible = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dummyObjectWithLookups"></param>
        public override void InitGridBehavior(IObject dummyObjectWithLookups)
        {
            base.InitGridBehavior(dummyObjectWithLookups);

            fakeFieldTest = dummyObjectWithLookups as VectorFieldTest;
            if (fakeFieldTest == null) return;
            
            fakeFieldTest.Samples.ListChanged += OnSamplesListChanged;

            //выбор семпла в отдельной таблице
            RefreshSamplesList();

            var column = Grid.GridView.Columns.ColumnByName("strVectorID");
            if (column != null)
            {
                Grid.GridView.SortInfo.AddRange(new[] { new GridColumnSortInfo(column, ColumnSortOrder.Ascending) });
            }

            column = Grid.GridView.Columns.ColumnByName("datFieldCollectionDate");
            if (column != null) GridHelper.SetColumnState(column, true);

            column = Grid.GridView.Columns.ColumnByName("strSampleName");
            if (column != null) GridHelper.SetColumnState(column, true);
            
            //Test name
            column = Grid.GridView.Columns.ColumnByName("idfsPensideTestName");
            if (column != null)
            {
                var le = column.SetLookupEditor();
                LookupBinder.BindFieldTestTestTypeRepository(le, fakeFieldTest.TestTypeLookup);
                le.QueryPopUp += OnTestNameQueryPopUp;
                le.QueryCloseUp += OnTestNameQueryCloseUp;
                column.Width = 80;
            }
                
            //Test Category
            column = Grid.GridView.Columns.ColumnByName("idfsPensideTestCategory");
            if (column != null)
            {
                LookupBinder.BindBaseRepositoryLookup(column.SetLookupEditor(), fakeFieldTest.TestCategoryLookup);
                column.Width = 80;
            }

            //Tested By
            column = Grid.GridView.Columns.ColumnByName("idfTestedByPerson");
            if (column != null)
            {
                var le = column.SetLookupEditor();
                LookupBinder.BindPersonRepositoryLookup(le, fakeFieldTest.TestedByPersonLookup);
                column.Width = 80;
                le.QueryPopUp += OnTestedByPersonQueryPopUp;
                le.QueryCloseUp += OnTestedByPersonQueryCloseUp;
            }

            //Tested By Office
            column = Grid.GridView.Columns.ColumnByName("idfTestedByOffice");
            if (column != null)
            {
                LookupBinder.BindOrganizationRepositoryLookup(column.SetLookupEditor(), fakeFieldTest.TestedByOfficeLookup, HACode.Vector);
                column.Width = 80;
            }
            
            column = Grid.GridView.Columns.ColumnByName("idfsPensideTestResult");
            if (column != null)
            {
                var le = column.SetLookupEditor();
                LookupBinder.BindFieldTestResultRepository(le, fakeFieldTest.TestResultLookup);
                le.QueryPopUp += OnTestResultQueryPopUp;
                le.QueryCloseUp += OnTestResultQueryCloseUp;
                le.EditValueChanged += OnTestResultEditValueChanged;
                column.Width = 80;
            }

            //Diagnosis
            column = Grid.GridView.Columns.ColumnByName("idfsDiagnosis");
            if (column != null)
            {
                var lookup = column.SetLookupEditor();
                LookupBinder.BindFieldTestDiagnosisRepository(lookup, fakeFieldTest.DiagnosisLookup);
                lookup.QueryPopUp += OnDiagnosisQueryPopUp;
                lookup.QueryCloseUp += OnDiagnosisQueryCloseUp;
                lookup.EditValueChanged += OnLookupDiagnosesEditValueChanged;
                column.Width = 80;
            }


            //устанавливаем видимость столбцов
            if (WorkMode == PanelWorkModes.VectorDetailMode)
            {
                Columns.HideColumn("strVectorID");
                Columns.HideColumn("strVectorTypeName");
                Columns.HideColumn("strVectorSubTypeName");
            }
            //скрываем столбцы, которые должны быть видны только в веб-варианте
            Columns.HideColumn("strSampleFieldBarcode");
            Columns.HideColumn("strPensideTestName");
            Columns.HideColumn("strPensideTestCategory");
            Columns.HideColumn("strTestedByOffice");
            Columns.HideColumn("strTestedByPerson");
            Columns.HideColumn("strPensideTestResult");
            Columns.HideColumn("strDiagnosis");

            var editable = (WorkMode == PanelWorkModes.VectorDetailMode) && !BusinessObject.Environment.ReadOnly;
            Grid.GridView.OptionsBehavior.Editable = editable;
            Grid.GridView.OptionsBehavior.ReadOnly = !editable;

            foreach (GridColumn clmn in Grid.GridView.Columns)
            {
                GridHelper.SetColumnState(clmn, !editable);
            }

            InlineMode = editable ? InlineMode.UseNewRow : InlineMode.None;

        }

        void OnTestedByPersonQueryCloseUp(object sender, CancelEventArgs e)
        {
            var fieldTest = Grid.GridView.GetFocusedRow() as VectorFieldTest;
            if (fieldTest == null) return;
            var le = sender as LookUpEdit;
            if (le == null) return;
            le.Properties.DataSource = fakeFieldTest.TestedByPersonLookup;
        }

        void OnTestedByPersonQueryPopUp(object sender, CancelEventArgs e)
        {
            var fieldTest = Grid.GridView.GetFocusedRow() as VectorFieldTest;
            if (fieldTest == null) return;
            if (fieldTest.TestedByOffice == null)
            {
                e.Cancel = true;
            }
            else
            {
                var le = sender as LookUpEdit;
                if (le == null) return;
                le.Properties.DataSource = fieldTest.TestedByPersonLookup;
            }
        }

        void OnTestNameQueryCloseUp(object sender, CancelEventArgs e)
        {
            var le = sender as LookUpEdit;
            if (le == null) return;
            le.Properties.DataSource = fakeFieldTest.TestTypeLookup;
        }

        void OnTestNameQueryPopUp(object sender, CancelEventArgs e)
        {
            var fieldTest = Grid.GridView.GetFocusedRow() as VectorFieldTest;
            if (fieldTest == null) return;
            if (fieldTest.idfsVectorType == 0)
            {
                e.Cancel = true;
                return;
            }
            var le = sender as LookUpEdit;
            if (le == null) return;
            le.Properties.DataSource = fieldTest.TestTypeLookup;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnSamplesListChanged(object sender, ListChangedEventArgs e)
        {
            RefreshSamplesList();
        }

        /// <summary>
        /// 
        /// </summary>
        private void RefreshSamplesList()
        {
            var column = Grid.GridView.Columns.ColumnByName("idfMaterial");
            if ((column != null) && (fakeFieldTest.Samples != null))
            {
                var ds = fakeFieldTest.Samples.Where(v => !v.IsMarkedToDelete).ToList();
                column.AddEditorForColumn(ds, "idfMaterial", "strFieldBarcode");
                column.Width = 120;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnDiagnosisQueryCloseUp(object sender, CancelEventArgs e)
        {
            var le = sender as LookUpEdit;
            if (le == null) return;
            le.Properties.DataSource = fakeFieldTest.DiagnosisLookup;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnDiagnosisQueryPopUp(object sender, CancelEventArgs e)
        {
            var fieldTest = Grid.GridView.GetFocusedRow() as VectorFieldTest;
            if (fieldTest == null) return;
            var le = sender as LookUpEdit;
            if (le == null) return;
            le.Properties.DataSource = fieldTest.DiagnosisLookup;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnLookupDiagnosesEditValueChanged(object sender, EventArgs e)
        {
            Grid.GridView.PostEditor();
            InvokeNeedDiagnosesRefreshing();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnTestResultEditValueChanged(object sender, EventArgs e)
        {
            Grid.GridView.PostEditor();
            InvokeNeedDiagnosesRefreshing();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnTestResultQueryCloseUp(object sender, CancelEventArgs e)
        {
            var le = sender as LookUpEdit;
            if (le == null) return;
            le.Properties.DataSource = fakeFieldTest.TestResultLookup;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnTestResultQueryPopUp(object sender, CancelEventArgs e)
        {
            var fieldTest = Grid.GridView.GetFocusedRow() as VectorFieldTest;
            if (fieldTest == null) return;
            var le = sender as LookUpEdit;
            if (le == null) return;
            le.Properties.DataSource = fieldTest.TestResultLookup;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actions"></param>
        public override void SetCustomActions(List<ActionMetaItem> actions)
        {
            base.SetCustomActions(actions);
            SetActionFunction(actions, "ViewOnDetailForm", ViewOnDetailForm);
        }

        public override void DefineBinding()
        {
            if (BusinessObject != null)
            {
                var meta = (IObjectMeta)BusinessObject.GetAccessor();
                var delete = meta.Actions.FirstOrDefault(a => a.Name == "Delete");
                var view = meta.Actions.FirstOrDefault(a => a.Name == "ViewOnDetailForm");
                var isSession = WorkMode == PanelWorkModes.SessionDetailMode;
                if (delete != null) delete.AddVisiblePredicate((arg1, arg2, arg3, arg4) => !isSession);
                if (view != null) view.AddVisiblePredicate((arg1, arg2, arg3, arg4) => isSession);
            }
            base.DefineBinding();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="bo"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private ActResult ViewOnDetailForm(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            if ((VectorsPanel != null) && (VectorsPanel.BusinessObject != null))
            {
                var ft = Grid.GridView.GetFocusedRow() as VectorFieldTest;
                if ((ft != null) && (ft.ParentVector != null))
                {
                    var index = ft.Vectors.IndexOf(ft.ParentVector);
                    var handle = VectorsPanel.Grid.GridView.GetRowHandle(index);
                    VectorsPanel.Grid.GridView.FocusedRowHandle = handle;
                    VectorsPanel.Grid.GridView.ClearSelection();
                    VectorsPanel.Grid.GridView.SelectRow(handle);

                    //VectorsPanel.BusinessObject = sample.ParentVector;
                    ft.ParentVector.openMode = 2;
                    VectorsPanel.PerformAction("Edit");
                    ft.ParentVector.openMode = 0;
                }
            }
            return true;
        }

        internal VectorListPanel VectorsPanel { get; set; }
        public override bool ReadOnly
        {
            get
            {
                var vsSessionPanel = ParentBasePanel as VsSessionDetail;
                if (vsSessionPanel != null && ((VsSession)vsSessionPanel.BusinessObject).IsClosed)
                    return true;
                return base.ReadOnly;
            }
            set
            {
                base.ReadOnly = value;
            }
        }

    }
}
