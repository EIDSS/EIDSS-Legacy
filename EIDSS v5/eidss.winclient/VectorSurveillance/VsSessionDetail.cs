using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using bv.common.Core;
using bv.common.Enums;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using bv.winclient.Layout;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraNavBar;
using eidss.model.Enums;
using eidss.model.Resources;
using eidss.model.Schema;
using eidss.winclient.Core;
using eidss.winclient.Schema;
using System.Linq;
using eidss.winclient.Helpers;

namespace eidss.winclient.VectorSurveillance
{
    public sealed partial class VsSessionDetail : BaseDetailPanel_VsSession
    {
        public VsSessionDetail()
        {
            InitializeComponent();

            //Width = 1000;
            //Height = 700;
            nvcFieldTestsSummary.Groups.Clear();
            nvcLabTestsSummary.Groups.Clear();

            //добавляем группу Pools/Vectors (она полностью строится динамически)
            VectorsPanel = panelPools.AddPoolsVectorsPanel();
            var layoutGroup = (LayoutGroup)VectorsPanel.GetLayout();
            layoutGroup.OnBeforeActionExecuting += OnVectorsPanelBeforeActionExecuting;
            layoutGroup.OnAfterActionExecuted += OnVectorsPanelAfterActionExecuted;
            layoutGroup.SearchPanelExpanded = false;

            //добавляем панель сводной информации по samples
            SamplesPanel = panelSamples.AddVectorSamplePanel(VectorSampleListPanel.Modes.SessionDetailMode);
            var layout = SamplesPanel.GetLayout();
            layout.OnBeforeActionExecuting += OnSamplesPanelBeforeActionExecuting;
            layout.OnAfterActionExecuted += OnSamplePanelAfterActionExecuted;
            //добавляем чекбокс на ActionPanel
            m_CbFilterSamples = new CheckEdit
                                  {
                                      Location = new Point(11, 5),
                                      Name = "cbFilterSamples",
                                      Size = new Size(211, 19),
                                      TabIndex = 0
                                  };
            m_CbFilterSamples.Properties.Caption = EidssFields.Get("cbFilterSamplesCaption", String.Empty);
            m_CbFilterSamples.CheckedChanged += OnFilterSamplesCheckedChanged;
            var size = m_CbFilterSamples.CalcBestSize();
            m_CbFilterSamples.Size = size;
            layout.AddCustomControlToActionPanel(m_CbFilterSamples, ActionsPanelType.Group);
            SamplesPanel.NeedFieldTestRefreshing += OnSamplesPanelNeedFieldTestRefreshing;

            FieldTestPanel = panelFieldTests.AddFieldTestPanel();
            FieldTestPanel.NeedSummaryRefreshing += OnFieldTestPanelNeedSummaryRefreshing;
            FieldTestPanel.NeedDiagnosesRefreshing += OnFieldTestPanelNeedDiagnosesRefreshing;
            var layoutFieldTest = FieldTestPanel.GetLayout() as LayoutGroup;
            if (layoutFieldTest != null) layoutFieldTest.TopPanelVisible = true;
            LabTestPanel = panelLabTests.AddLabTestPanel();
        }

        /// <summary>
        /// Смена данных в панели семплов. Запуск пересчёта полевых тестов
        /// </summary>
        void OnSamplesPanelNeedFieldTestRefreshing()
        {
            //TODO реализовать ситуацию, когда сохранённый семпл меняет родительский вектор и становится другого типа (Rodent->Mosquito).
            //TODO переделать, минимизировать кол-во методов
            var session = BusinessObject as VsSession;
            if (session == null) return;
            InvokeRecalculateFieldTests();
            session.RefreshFieldTestsSummary();
            FillSummary();
        }

        /// <summary>
        /// Обновление списка диагнозов после смены диагноза в FT-тесте
        /// </summary>
        void OnFieldTestPanelNeedDiagnosesRefreshing()
        {
            //TODO переделать, минимизировать кол-во методов
            //TODO использовать только индикативные диагнозы
            var session = BusinessObject as VsSession;
            if (session == null) return;
            session.RefreshDiagnoses();
            RefreshDiagnosesList();
        }

        /// <summary>
        /// Обновление FieldTests summary после смены результата FT-теста
        /// </summary>
        void OnFieldTestPanelNeedSummaryRefreshing()
        {
            //TODO переделать, минимизировать кол-во методов
            var session = BusinessObject as VsSession;
            if (session == null) return;
            session.RefreshFieldTestsSummary();
            FillSummary();
        }

        private readonly CheckEdit m_CbFilterSamples;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="action"></param>
        /// <param name="bo"></param>
        void OnSamplePanelAfterActionExecuted(IBasePanel panel, ActionMetaItem action, IObject bo)
        {
            if (action.ActionType.Equals(ActionTypes.Create))
            {
                var sample = bo as VectorSample;
                if (sample != null) sample.isJustCreated = false;
            }
            SamplesPanel.RefreshDataset();
            ShowFieldTestsSummary();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="action"></param>
        /// <param name="bo"></param>
        /// <param name="cancel"></param>
        void OnSamplesPanelBeforeActionExecuting(IBasePanel panel, ActionMetaItem action, IObject bo, ref bool cancel)
        {
            //нельзя создавать Sample отсюда если нет ни одного вектора
            var session = BusinessObject as VsSession;
            if (session == null) return;
            if (session.PoolsVectors.Count == 0)
            {
                MessageForm.Show(EidssMessages.Get("VS Session add sample"));
                cancel = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="action"></param>
        /// <param name="bo"></param>
        void OnVectorsPanelAfterActionExecuted(IBasePanel panel, ActionMetaItem action, IObject bo)
        {
            var session = BusinessObject as VsSession;
            if (session == null) return;
            foreach (var vector in session.PoolsVectors)
            {
                vector.RecalculateLocation();
                vector.RecalculateVectorSpecificData();
            }
            ShowFieldTestsSummary();
            RefreshCalculatedFields();
            SamplesPanel.Vectors = session.PoolsVectors;
            SamplesPanel.RefreshDataset();
            RefreshSummarySpecies();
        }

        /// <summary>
        /// 
        /// </summary>
        private void RefreshCalculatedFields()
        {
            var session = BusinessObject as VsSession;
            if (session == null) return;
            //нужно, чтобы сработал перерасчёт полей в модели и binding с контролами
            session.blnNeedRecalculateFields = !session.blnNeedRecalculateFields;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="action"></param>
        /// <param name="bo"></param>
        /// <param name="cancel"></param>
        void OnVectorsPanelBeforeActionExecuting(IBasePanel panel, ActionMetaItem action, IObject bo, ref bool cancel)
        {
            if (action.ActionType == ActionTypes.Create)
            {
                //проверим, чтобы был выбран какой-то тип вектора
                var session = BusinessObject as VsSession;
                if (session == null) return;
                if (session.idfsVectorType == null)
                {
                    MessageForm.Show(EidssMessages.Get("VS Session add vector"));
                    cancel = true;
                }
            }
            else if (action.ActionType == ActionTypes.Edit)
            {
                //нельзя редактировать вектор, если у него есть невалидированные семплы
                var vector = bo as Vector;
                if (vector == null) return;
                var session = BusinessObject as VsSession;
                if (session == null) return;
                var samples = session.Samples.Where(s => s.idfVector == vector.idfVector).ToList();
                var sampleAccessor = VectorSample.Accessor.Instance(null);
                using (var manager = CreateDbManagerProxy())
                {
                    foreach (var sample in samples)
                    {
                        if (!sampleAccessor.Validate(manager, sample, true, true, true))
                        {
                            MessageForm.Show(EidssMessages.Get("VS Session add vector check samples"));
                            cancel = true;
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private VectorListPanel VectorsPanel { get; set; }
        private VectorSampleListPanel SamplesPanel { get; set; }
        private VectorFieldTestListPanel FieldTestPanel { get; set; }
        private VectorLabTestListPanel LabTestPanel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentControl"></param>
        public static void Register(Control parentControl)
        {
            RegisterItem(MenuActionManager.Instance.Create, "MenuNewVector", 1110, false, true);
            RegisterItem(MenuActionManager.Instance.Journals, "ToolbarNewVector", 207, true, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuAction"></param>
        /// <param name="resourceKey"></param>
        /// <param name="order"></param>
        /// <param name="showInToolbar"></param>
        /// <param name="beginGroup"></param>
        private static void RegisterItem(IMenuAction menuAction, string resourceKey, int order, bool showInToolbar, bool beginGroup)
        {
            new MenuAction(ShowMe, MenuActionManager.Instance, menuAction,
                           resourceKey, order, showInToolbar, (int)MenuIconsSmall.VsSessionDetail,
                           (int)MenuIcons.VsSession)
            {
                SelectPermission = PermissionHelper.InsertPermission(EIDSSPermissionObject.VsSession),
                BeginGroup = beginGroup,
                ShowInMenu = !showInToolbar,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        public static void ShowMe()
        {
            object id = null;
            BaseFormManager.ShowNormal(typeof (VsSessionDetail), ref id);
        }

        /// <summary>
        /// Обновляет список SessionToVectorType
        /// </summary>
        private void RefreshVectorTypeList()
        {
            var session = BusinessObject as VsSession;
            if (session == null) return;
            var oldEditValue = leVectorTypes.EditValue;
            var list = session.SessionToVectorType.Where(c => c.Checked).ToList();
            leVectorTypes.Properties.DataSource = list;
            if (oldEditValue != null)
            {
                long idfsVectorType;
                if (Int64.TryParse(oldEditValue.ToString(), out idfsVectorType))
                {
                    leVectorTypes.EditValue = list.Count(c => c.idfsVectorType == idfsVectorType) > 0
                                                  ? oldEditValue
                                                  : null;
                }
            }
            else
            {
                if (list.Count > 0) leVectorTypes.EditValue = list[0].idfsVectorType;
            }
            RefreshCalculatedFields();
        }

        /// <summary>
        /// 
        /// </summary>
        private void RefreshSummarySpecies()
        {
            var session = BusinessObject as VsSession;
            if (session == null) return;

            var vectorTypeDict = new Dictionary<long, TreeListNode>();
            var vectorSubTypeDict = new Dictionary<long, TreeListNode>();
            treeSummarySpecies.ClearNodes();
            foreach (var vector in session.PoolsVectors)
            {
                if (vector.IsMarkedToDelete) continue;
                if (!vectorTypeDict.ContainsKey(vector.idfsVectorType))
                {
                    var node = treeSummarySpecies.AppendNode(vector, null, vector);
                    node[0] = vector.strVectorType;
                    vectorTypeDict.Add(vector.idfsVectorType, node);
                }
                if (!vectorSubTypeDict.ContainsKey(vector.idfsVectorSubType))
                {
                    if (vectorTypeDict.ContainsKey(vector.idfsVectorType))
                    {
                        var parentNode = vectorTypeDict[vector.idfsVectorType];
                        if (parentNode != null)
                        {
                            var node = treeSummarySpecies.AppendNode(vector, parentNode, vector);
                            node[0] = vector.strSpecies;
                            vectorSubTypeDict.Add(vector.idfsVectorSubType, node);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void DefineBinding()
        {
            var session = BusinessObject as VsSession;
            if (session == null) return;

            LookupBinder.BindTextEdit(txtSessionID, session, "strSessionID");
            LookupBinder.BindDate(dtStartDate, session, "datStartDate");
            LookupBinder.BindDate(dtCloseDate, session, "datCloseDate");
            LookupBinder.BindTextEdit(txtFieldSessionID, session, "strFieldSessionID");
            LookupBinder.BindBaseLookup(leSessionStatus, session, "VsStatus", session.VsStatusLookup, false, false);
            LookupBinder.BindTextEdit(txtVectors, session, "strVectorsCalculated");
            LookupBinder.BindSpinEdit(seCollectionEffort, session, "intCollectionEffort");
            
            LookupBinder.BindOutbreakLookup(beOutbreakID, session, "strOutbreakID");
            beOutbreakID.ButtonClick += OnBeOutbreakButtonClick;

            LookupBinder.BindTextEdit(txtDescription, session, "strDescription");
            //обновления списка типов векторов, которые редактируются в данной форме
            RefreshVectorTypeList();
            //вывод диагнозов
            RefreshDiagnosesList();

            #region Pools

            //добавляем кнопки на панель
            //TODO определиться с permissions для Vector (он не BusinessObject)
            var meta = (IObjectMeta) Vector.Accessor.Instance(null);
            //poolsGroupActionPanel.AddActionsRoutines(meta.Actions, ActionsPanelType.Group);

            //TODO IsExtended -- это что?
            //var action1 = new ActionMetaItem("Create","strCreate_Id","add","tooltipCreate_Id",
            //          ActionsAlignment.Right, ActionsPanelType.Group, false, true, false, null
            //          , 
            //          (manager, c, pars) => ObjectAccessor.PostInterface<Vector>().Post(manager, (Address)c),

            //          null,
            //          ActionTypes.Create,
            //          String.Empty);


            #endregion

            #region Summary

            //выводим список Species (все, что встречаются в пулах/векторах
            RefreshSummarySpecies();

            LookupBinder.BindTextEdit(txtQuantity, session, "intSummaryQuantity");
            LookupBinder.BindTextEdit(dtCollectionDateFrom, session, "datSummaryCollectionFrom");
            LookupBinder.BindTextEdit(dtCollectionDateTo, session, "datSummaryCollectionTo");

            #endregion

            ShowFieldTestsSummary();
            ShowLabTestsSummary();

            //выставляем редактируемость
            //SetSessionState(session.VsStatus.idfsBaseReference);
        }

        /// <summary>
        /// Вывод диагнозов
        /// </summary>
        private void RefreshDiagnosesList()
        {
            var session = BusinessObject as VsSession;
            if (session == null) return;
            lbDiagnoses.Items.Clear();
            foreach (var diagnosis in session.Diagnosis)
            {
                if (lbDiagnoses.Items.Contains(diagnosis.NationalName)) continue;
                lbDiagnoses.Items.Add(diagnosis.NationalName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnBeOutbreakButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (!(sender is ButtonEdit)) return;
            var session = BusinessObject as VsSession;
            if (session == null) return;
            if (e.Button.Kind.Equals(ButtonPredefines.Glyph))
            {
                var bo = BaseFormManager.ShowForSelection((IBaseListPanel)ClassLoader.LoadClass("OutbreakListPanel"), ((Control)sender).FindForm());
                if (bo != null)
                {
                    var outbreak = bo as OutbreakListItem;
                    if (outbreak != null)
                    {
                        session.idfOutbreak = Convert.ToInt64(bo.Key);
                        session.strOutbreakID = outbreak.strOutbreakID;
                    }
                }
            }
            else if (e.Button.Kind.Equals(ButtonPredefines.Ellipsis))
            {
                //можно только просматривать существующий outbreak
                if (session.idfOutbreak.HasValue)
                {
                    object id = session.idfOutbreak.Value;
                    BaseFormManager.ShowModal(((IApplicationForm)(ClassLoader.LoadClass("OutbreakDetail"))),
                                              ((Control)sender).FindForm(), ref id, null, null);
                }
            }
            else if (e.Button.Kind.Equals(ButtonPredefines.Delete))
            {
                session.idfOutbreak = null;
                session.strOutbreakID = String.Empty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void InitChildren()
        {
            if (BusinessObject == null)
            {
                bppLocation.PopupControl.BusinessObject = null;
            }
            else
            {
                var session = BusinessObject as VsSession;
                if (session != null)
                {
                    bppLocation.PopupControl.BusinessObject = session.Location;
                    RefreshVectorTypeList();
                    VectorsPanel.SetDataSource(session, session.PoolsVectors);
                    //RefreshVectorTypeForChildren(session.idfsVectorType);
                    SamplesPanel.SetDataSource(session, session.Samples);
                    SamplesPanel.Vectors = session.PoolsVectors;
                    SamplesPanel.IsPoolVectorType = session.IsPoolVectorType; //TODO определиться как быть с этим режимом, если могут быть семплы разного типа
                    SamplesPanel.FieldTests = session.FieldTests;
                    FieldTestPanel.SetDataSource(session, session.FieldTests);
                    LabTestPanel.SetDataSource(session, session.LabTests);
                    RefreshVectorTypeForChildren(session.idfsVectorType);

                    var om = session.GetAccessor() as IObjectMeta;
                    if (om != null)
                    {
                        om.Actions.First(c => c.ActionType == ActionTypes.Delete)
                        .AddEnablePredicate((o, p, r) => r && (o as VsSession).ValidateOnDelete());
                    }
                        
                    //var b = session.HasChanges;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o">Объект, который запрашивает набор входных параметров для своего создания</param>
        /// <returns></returns>
        public override List<object> GetParamsAction(IObject o)
        {
            var list = new List<object>();
            var session = BusinessObject as VsSession;
            if ((session != null) && (session.idfsVectorType != null))
            {
                if (o is Vector)
                {
                    list.Add(session.idfVectorSurveillanceSession);
                    list.Add(session.idfsVectorType);
                    list.Add(session.strVectorType);
                    list.Add(session.datStartDate);
                    //дата начала сбора векторов совпадает с датой начала сессии по умолчанию 
                    list.Add(session.strSessionID);
                    list.Add(session.PoolsVectors);
                    list.Add(session.Samples);
                    list.Add(session.Location);
                    list.Add(session.FieldTests);
                    list.Add(session.LabTests);
                }
                else if (o is VectorSample)
                {
                    var vectorList = session.PoolsVectors.Where(v => v.idfsVectorType == session.idfsVectorType).ToList();
                    //уже есть проверка на наличие векторов
                    var vector = vectorList.Count > 0 ? vectorList[0] : session.PoolsVectors[0];
                    VectorDetail.FillParamsAction(vector, ref list);
                }
            }
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnVectorTypeButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind.Equals(ButtonPredefines.Ellipsis))
            {
                var session = BusinessObject as VsSession;
                if (session == null) return;
                session.ShowSessionToVectorTypeForm();
                RefreshVectorTypeList();
                RefreshDiagnosesList();
                InvokeRecalculateFieldTests();
            }
        }

        /// <summary>
        /// Отрисовывает полевые тесты
        /// </summary>
        private void ShowFieldTestsSummary()
        {
            InvokeRecalculateFieldTests();
            FillSummary();
        }

        /// <summary>
        /// 
        /// </summary>
        private void FillSummary()
        {
            var session = BusinessObject as VsSession;
            if (session == null) return;
            //TODO разобраться с избыточностью методов
            nvcFieldTestsSummary.FillTestSummary(session.FieldTestsSummary);
            nvcFieldTestsSummary.RecalculateHeight();
        }

        /// <summary>
        /// Отрисовывает лабораторные тесты
        /// </summary>
        private void ShowLabTestsSummary()
        {
            var session = BusinessObject as VsSession;
            if (session == null) return;
            nvcLabTestsSummary.FillTestSummary(session.LabTestsSummary);
            nvcLabTestsSummary.RecalculateHeight();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnVectorTypesEditValueChanged(object sender, EventArgs e)
        {
            var session = BusinessObject as VsSession;
            if (session == null) return;
            if (leVectorTypes.EditValue == null)
            {
                session.idfsVectorType = null;
                return;
            }
            session.idfsVectorType = (long)leVectorTypes.EditValue;
            //SamplesPanel.IsPoolVectorType = session.IsPoolVectorType; //TODO определиться как быть с этим режимом, если могут быть семплы разного типа
            RefreshVectorTypeForChildren(session.idfsVectorType);
            InvokeRecalculateFieldTests();
        }

        /// <summary>
        /// Запускает пересчёт полевых тестов
        /// </summary>
        private void InvokeRecalculateFieldTests()
        {
            var session = BusinessObject as VsSession;
            if (session == null) return;
            session.blnNeedRecalculateFieldTests = !session.blnNeedRecalculateFieldTests;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idfsVectorType"></param>
        private void RefreshVectorTypeForChildren(long? idfsVectorType)
        {
            var session = BusinessObject as VsSession;
            if ((session == null) || !idfsVectorType.HasValue) return;
            VectorsPanel.idfsVectorType = SamplesPanel.idfsVectorType = 
                FieldTestPanel.idfsVectorType = LabTestPanel.idfsVectorType = idfsVectorType;
            VectorsPanel.IsPoolVectorType = session.IsPoolVectorType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFilterSamplesCheckedChanged(object sender, EventArgs e)
        {
            //TODO сделать в соответствии с Caliber
            SamplesPanel.NeedFilterByVectorType = m_CbFilterSamples.Checked;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFieldTestsSummaryGroupExpandedCollapsed(object sender, NavBarGroupEventArgs e)
        {
            nvcFieldTestsSummary.RecalculateHeight();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnVsSessionDetailLoad(object sender, EventArgs e)
        {
            LayoutCorrector.SetStyleController(bppLocation, LayoutCorrector.MandatoryStyleController);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSessionStatusEditValueChanged(object sender, EventArgs e)
        {
            var be = sender as ButtonEdit;
            if (be == null) return;
            var value = be.EditValue as BaseReference;
            if (value == null) return;
            
            SetSessionState(value.idfsBaseReference);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vsStatus"></param>
        private void SetSessionState(long vsStatus)
        {
            var session = BusinessObject as VsSession;
            if (session == null) return;

            var isClosed = vsStatus == (long)VsStatusEnum.Closed;

            var readOnly = session.ReadOnly || isClosed;
            leVectorTypes.Properties.Buttons[1].Enabled = !readOnly;
            VectorsPanel.ReadOnly = SamplesPanel.ReadOnly = FieldTestPanel.ReadOnly = LabTestPanel.ReadOnly = readOnly;             
            GetLayout().RefreshActionButtons(readOnly);
            m_CbFilterSamples.Enabled = !readOnly;

        }
        public override void DisplayReadOnly()
        {
            base.DisplayReadOnly();
            if (ReadOnly)
            {
                leVectorTypes.Properties.Buttons[1].Enabled = false;
                return;
            }
            var session = BusinessObject as VsSession;
            if (session == null) return;
            var isClosed = session.idfsVectorSurveillanceStatus == (long)VsStatusEnum.Closed;
            var readOnly = session.ReadOnly || isClosed;
            leVectorTypes.Properties.Buttons[1].Enabled = !readOnly;
            m_CbFilterSamples.Enabled = !readOnly;

        }
        public override bool ReadOnly
        {
            get {return base.ReadOnly; }
            set
            {
                base.ReadOnly = value;
                var vsStatus = (long) VsStatusEnum.InProgress;
                if(BusinessObject!=null)
                {
                    vsStatus = ((VsSession) BusinessObject).idfsVectorSurveillanceStatus;
                }
                var readOnly = value || (vsStatus == (long)VsStatusEnum.Closed);
                VectorsPanel.ReadOnly = SamplesPanel.ReadOnly = FieldTestPanel.ReadOnly = LabTestPanel.ReadOnly = readOnly;
                m_CbFilterSamples.Enabled = !readOnly;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLabTestsSummaryGroupExpanded(object sender, NavBarGroupEventArgs e)
        {
            nvcLabTestsSummary.RecalculateHeight();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTreeSummarySpeciesClick(object sender, EventArgs e)
        {
            if (treeSummarySpecies.Selection.Count == 0) return;
            var session = BusinessObject as VsSession;
            if (session == null) return;

            var treeListNode = treeSummarySpecies.Selection[0];
            if (treeListNode.Tag == null) return;
            var vector = treeListNode.Tag as Vector;
            if (vector == null) return;
            //если клик по корневому узлу, то надо считать типы векторов
            //иначе подтипы векторов

            lblQuantity.Text =
                vector.IsPoolVectorType
                    ? EidssFields.Get("captionNumberOfPools", "Number of pools")
                    : EidssFields.Get("captionNumberOfVectors", "Number of vectors");

            if (treeSummarySpecies.Selection[0].ParentNode == null)
            {
                var vectors = session.PoolsVectors.Where(v => v.idfsVectorType == vector.idfsVectorType).ToList();
                //сводка по типу вектора
                session.intSummaryQuantity = vectors.Count;
                session.datSummaryCollectionFrom = vectors.Min(v => v.datCollectionDateTime);
                session.datSummaryCollectionTo = vectors.Max(v => v.datCollectionDateTime);
            }
            else
            {
                //сводка по виду
                var species = session.PoolsVectors.Where(v => v.idfsVectorSubType == vector.idfsVectorSubType).ToList();
                session.intSummaryQuantity = species.Count;
                session.datSummaryCollectionFrom = species.Min(v => v.datCollectionDateTime);
                session.datSummaryCollectionTo = species.Max(v => v.datCollectionDateTime);
            }
        }
    }
}
