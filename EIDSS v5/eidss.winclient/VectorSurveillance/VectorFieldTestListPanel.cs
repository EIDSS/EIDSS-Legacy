using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using bv.common.Enums;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.Layout;
using eidss.model.Schema;
using eidss.winclient.Core;
using eidss.winclient.Helpers;
using eidss.winclient.Schema;
using System.Linq;

namespace eidss.winclient.VectorSurveillance
{
    public partial class VectorFieldTestListPanel : BaseGroupPanel_VectorFieldTest
    {
        /// <summary>
        /// 
        /// </summary>
        private GridColumnCollection Columns { get { return Grid.GridView.Columns; } }

        private readonly VectorFieldTest m_VectorFieldTest;

        private readonly GridColumn m_ColumnTestResult;
        private readonly RepositoryItemLookUpEdit m_LookupTestResult;
        
        /// <summary>
        /// 
        /// </summary>
        public VectorFieldTestListPanel()
        {
            InitializeComponent();

            EditByDoubleClick = false;

            Grid.GridView.OptionsView.ShowGroupPanel = false;
            Grid.GridView.OptionsBehavior.Editable = true;
            Grid.GridView.OptionsBehavior.ReadOnly = false;
            Grid.GridView.GroupCount = 1;
            InlineMode = bv.winclient.BasePanel.InlineMode.UseCreateButton;
            //группировать по полю strPensideTestTypeName
            var column = Grid.GridView.Columns.ColumnByName("strPensideTestTypeName");
            if (column != null)
            {
                Grid.GridView.SortInfo.AddRange(new[] { new GridColumnSortInfo(column, ColumnSortOrder.Ascending) });
            }

            column = Grid.GridView.Columns.ColumnByName("strVectorID");
            if (column != null)
            {
                Grid.GridView.SortInfo.AddRange(new[] { new GridColumnSortInfo(column, ColumnSortOrder.Ascending) });
            }

            Columns.SetColumnState("SampleName", true);

            #region Установка редакторов для столбцов

            using (var manager = CreateDbManagerProxy())
            {
                var acc = VectorFieldTest.Accessor.Instance(null);
                m_VectorFieldTest = acc.CreateNewT(manager, null);
               
                //выставляем столбцы в readonly
                Columns.SetColumnState("strVectorID", true);
                Columns.SetColumnState("strFieldBarcode", true);
                Columns.SetColumnState("strSpecimenName", true);
                Columns.SetColumnState("datFieldCollectionDate", true);
                Columns.SetColumnState("strVectorTypeName", true);

                //TestCategory
                column = Grid.GridView.Columns.ColumnByName("idfsPensideTestCategory");
                if (column != null)
                    LookupBinder.BindBaseRepositoryLookup(column.SetLookupEditor(),
                                                          m_VectorFieldTest.PensideTestCategoryLookup);

                //Tested By
                column = Grid.GridView.Columns.ColumnByName("idfTestedByPerson");
                if (column != null)
                {
                    LookupBinder.BindPersonRepositoryLookup(column.SetLookupEditor(), m_VectorFieldTest.TestedByPersonLookup);
                }

                //Tested By Office
                column = Grid.GridView.Columns.ColumnByName("idfTestedByOffice");
                if (column != null)
                    LookupBinder.BindOrganizationRepositoryLookup(column.SetLookupEditor(),

                        m_VectorFieldTest.TestedByOfficeLookup);

                //Result
                m_ColumnTestResult = Grid.GridView.Columns.ColumnByName("idfsPensideTestResult");
                if (m_ColumnTestResult != null)
                {
                    m_LookupTestResult = m_ColumnTestResult.SetLookupEditor();
                    LookupBinder.BindTypeFieldTestToResultMatrixLookupRepository(m_LookupTestResult, m_VectorFieldTest.TypeFieldTestToResultMatrix);
                    m_LookupTestResult.QueryPopUp += OnLookupSampleTypeQueryPopUp;
                    m_LookupTestResult.QueryCloseUp += OnLookupSampleTypeQueryCloseUp;
                    m_LookupTestResult.EditValueChanged += OnLookupTestResultEditValueChanged;
                }
                //Diagnosis
                column = Grid.GridView.Columns.ColumnByName("idfsDiagnosis");
                if (column != null)
                {
                    var lookup = column.SetLookupEditor();
                    //LookupBinder.BindDiagnosisRepositoryLookup(lookup, m_VectorFieldTest.DiagnosisLookup, HACode.Vector);
                    LookupBinder.BindDiagnosis2PensideTestMatrixLookupRepository(lookup, m_VectorFieldTest.Diagnosis2PensideTestMatrix);
                    lookup.QueryPopUp += OnDiagnosisQueryPopUp;
                    lookup.QueryCloseUp += OnDiagnosisQueryCloseUp;
                    lookup.EditValueChanged += OnLookupDiagnosesEditValueChanged;
                }
            }


            #endregion

            AfterLayoutCreated += OnFieldTestAfterLayoutCreated;
        }

        /// <summary>
        /// 
        /// </summary>
        void OnFieldTestAfterLayoutCreated()
        {
            var layout = GetLayout() as LayoutGroup;
            if (layout != null)
            {
                var group = layout.TopGroupActionPanel.GetActionGroup("SetResult");
                if (group != null) group.OnBeforePopup += OnSetResultGroupBeforePopup;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnDiagnosisQueryCloseUp(object sender, CancelEventArgs e)
        {
            var fieldTest = FocusedItem as VectorFieldTest;
            if (fieldTest == null) return;
            var le = sender as LookUpEdit;
            if (le == null) return;
            le.Properties.DataSource = fieldTest.Diagnosis2PensideTestMatrix.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnDiagnosisQueryPopUp(object sender, CancelEventArgs e)
        {
            var fieldTest = FocusedItem as VectorFieldTest;
            if (fieldTest == null) return;
            var le = sender as LookUpEdit;
            if (le == null) return;
            le.Properties.DataSource = fieldTest.Diagnosis2PensideTestMatrix.Where(c => c.idfsPensideTestType == fieldTest.idfsPensideTestType).ToList();
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
        void OnLookupTestResultEditValueChanged(object sender, EventArgs e)
        {
            Grid.GridView.PostEditor();
            InvokeNeedDiagnosesRefreshing();
            InvokeNeedSummaryRefreshing();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnLookupSampleTypeQueryCloseUp(object sender, CancelEventArgs e)
        {
            var fieldTest = FocusedItem as VectorFieldTest;
            if (fieldTest == null) return;
            var le = sender as LookUpEdit;
            if (le == null) return;
            le.Properties.DataSource = fieldTest.TypeFieldTestToResultMatrix.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnLookupSampleTypeQueryPopUp(object sender, CancelEventArgs e)
        {
            var fieldTest = FocusedItem as VectorFieldTest;
            if (fieldTest == null) return;
            var le = sender as LookUpEdit;
            if (le == null) return;
            le.Properties.DataSource = fieldTest.TypeFieldTestToResultMatrix.Where(c => c.idfsPensideTestType == fieldTest.idfsPensideTestType).ToList();
        }

        public delegate void NeedRefreshDelegate();

        /// <summary>
        /// Событие, которое требует пересчёта Summary
        /// </summary>
        public event NeedRefreshDelegate NeedSummaryRefreshing;

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
        public void InvokeNeedSummaryRefreshing()
        {
            if (NeedSummaryRefreshing != null) NeedSummaryRefreshing();
        }

        
        private long? m_IdfsVectorType;

        /// <summary>
        /// 
        /// </summary>
        public long? idfsVectorType
        {
            get { return m_IdfsVectorType; }
            set
            {
                m_IdfsVectorType = value;
                RefreshDataset();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void RefreshDataset()
        {
            var format = String.Empty;

            if (idfsVectorType.HasValue)
            {
                format = String.Format("idfsVectorType={0}", idfsVectorType);
            }

            Refresh(DataSource, format);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SetCustomActions(List<ActionMetaItem> actions)
        {
            base.SetCustomActions(actions);
            SetActionFunction(actions, "SetResultEmpty", ActionSetResult, new List<object> {null});
            SetActionFunction(actions, "ClearTestResults", ActionClearTestResults);
        }

        /// <summary>
        /// Пересчёт действий в групповой кнопке раздачи результатов полевым тестам
        /// </summary>
        void OnSetResultGroupBeforePopup()
        {
            if (SelectedItems.Count == 0) return;
            var selectedFieldTests = SelectedItems.Cast<VectorFieldTest>().ToList();
            var testResults = new List<long>();
            //берем первый тест за образец и по остальным тестам определяем те результаты, которые совпадают у всех тестов
            var test = selectedFieldTests[0];
            testResults.AddRange(test.GetTestResults());
            if (selectedFieldTests.Count > 1)
            {
                for(var i = 1; i < selectedFieldTests.Count; i++)
                {
                    var res = selectedFieldTests[i].GetTestResults();
                    for (var j = testResults.Count - 1; j >= 0; j--)
                    {
                        if (res.Count(r => r == testResults[j]) == 0) testResults.RemoveAt(j);
                    }
                }
            }
            //модифицируем кнопки, представленные в выпадающем списке доступных действий
            if (testResults.Count > 0)
            {
                var layout = GetLayout() as LayoutGroup;
                if (layout != null)
                {
                    var group = layout.TopGroupActionPanel.GetActionGroup("SetResult");
                    if (group != null)
                    {
                        foreach (var testResult in testResults)
                        {
                            //если такого результата нет среди существующих, то добавим такую действие-кнопку
                            if (group.Actions.Count(a => a.HasParameterValue(testResult)) == 0)
                            {
                                #region Создание действия для результата

                                var idfsTestResult = testResult;
                                var resValue =
                                    test.TypeFieldTestToResultMatrix.FirstOrDefault(
                                        m => m.idfsPensideTestResult == idfsTestResult);
                                if (resValue == null) continue;

                                var action =
                                    new ActionMetaItem(
                                        String.Format("action{0}", testResult),
                                        ActionTypes.Action, 
                                        true,
                                        null,
                                        "SetResult", 
                                        (manager, c, pars) =>
                                            {
                                                VectorFieldTest.Accessor.Instance(null).SetResultEmpty(
                                                    manager, (VectorFieldTest) c,
                                                    pars);
                                                return true;
                                            },
                                        null,
                                        new ActionMetaItem.VisualItem(
                                            resValue.strPensideTestResultName,
                                            String.Empty,
                                            resValue.strPensideTestResultName,
                                            String.Empty,
                                            String.Empty,
                                            String.Empty,
                                            ActionsAlignment.Right,
                                            ActionsPanelType.Group,
                                            ActionsAppType.All
                                            )
                                        );
                                    /*
                                    new ActionMetaItem(
                                        String.Format("action{0}", testResult),
                                        resValue.strPensideTestResultName,
                                        String.Empty,
                                        resValue.strPensideTestResultName,
                                        String.Empty,
                                        String.Empty,
                                        String.Empty,
                                        String.Empty,
                                        null,
                                        ActionsAlignment.Right,
                                        ActionsPanelType.Group,
                                        ActionsAppType.All,
                                        true,
                                        true, false,
                                        (manager, c, pars) =>
                                            {
                                                VectorFieldTest.Accessor.Instance(null).SetResultEmpty(
                                                    manager, (VectorFieldTest) c,
                                                    pars);
                                                return true;
                                            },
                                        null,
                                        null,
                                        ActionTypes.Action,
                                        ActionTypes.Action,
                                        ActionTypes.Unknown,
                                        "SetResult"
                                        );
                                     */
                                //добавляем ему результат теста
                                action.AddFirstUIFunc(ActionSetResult, new List<object>{testResult});

                                #endregion

                                group.AddAction(action, true);
                            }

                            //просматриваем действия группы. Первое не трогаем, потому что это кнопка [Empty result]
                            for (var i = group.Actions.Count - 1; i >= 1; i--)
                            {
                                //если ранее созданного действия более нет среди выбранных, то его удаляем
                                //у них один параметр -- результат
                                var action = group.Actions[i];
                                if (action.Parameters.Count > 0)
                                {
                                    long idfTestResults;
                                    if (!Int64.TryParse(action.Parameters[0].ToString(), out idfTestResults)) continue;
                                    if (!testResults.Contains(idfTestResults)) group.DeleteAction(action);
                                }
                            }
                        }
                    }
                }
            }
        }

        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="bo"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private static ActResult ActionSetResult(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            if (parameters.Count < 4) return false;
            var listPanel = parameters[2] as VectorFieldTestListPanel;
            if (listPanel == null) return false;
            var selectedFieldTests = listPanel.SelectedItems.Cast<VectorFieldTest>().ToList();
            if (selectedFieldTests.Count == 0) return false;
            long? idfsTestResult = null;
            if (parameters[3] != null) idfsTestResult = Int64.Parse(parameters[3].ToString());
            
            foreach (var ft in selectedFieldTests)
            {
                ft.idfsPensideTestResult = idfsTestResult;
            }
            return true ;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="bo"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private ActResult ActionClearTestResults(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            ActResult ret = new ActResult { result = false };
            if (parameters.Count < 3) return ret;
            var listPanel = parameters[2] as VectorFieldTestListPanel;
            if (listPanel == null) return ret;
            var selectedFieldTests = listPanel.SelectedItems.Cast<VectorFieldTest>().ToList();
            if (selectedFieldTests.Count == 0) return ret;
            foreach (var ft in selectedFieldTests)
            {
                ft.datTestDate = null;
                ft.PensideTestCategory = null;
                ft.TestedByOffice = null;
                ft.TestedByPerson = null;
                ft.idfsPensideTestResult = null;
                ft.idfsDiagnosis = null;
            }
            //пересчитываем список диагнозов
            InvokeNeedDiagnosesRefreshing();
            ret.result = true;
            return ret;
        }
    }
}
