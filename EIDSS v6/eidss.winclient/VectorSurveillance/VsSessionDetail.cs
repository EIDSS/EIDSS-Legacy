using System;
using System.Collections.Generic;
using System.Windows.Forms;
using bv.common.Core;
using bv.common.Enums;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using bv.winclient.Layout;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.winclient.Core;
using eidss.winclient.Schema;
using System.Linq;

namespace eidss.winclient.VectorSurveillance
{
    public sealed partial class VsSessionDetail : BaseDetailPanel_VsSession
    {
        public VsSessionDetail()
        {
            InitializeComponent();

            //добавляем группу Pools/Vectors (она полностью строится динамически)
            VectorsPanel = panelPools.AddPoolsVectorsPanel();
            var layoutGroup = (LayoutGroup)VectorsPanel.GetLayout();
            layoutGroup.OnAfterActionExecuted += OnVectorsPanelAfterActionExecuted;
            layoutGroup.OnBeforeActionExecuting += OnVectorPanelBeforeActionExecuting;

            //добавляем панель сводной информации по samples
            VectorSampleListPanel.WorkMode = PanelWorkModes.SessionDetailMode;
            SamplesPanel = panelSamples.AddVectorSamplePanel();
            SamplesPanel.VectorsPanel = VectorsPanel;

            VectorFieldTestListPanel.WorkMode = PanelWorkModes.SessionDetailMode;
            FieldTestPanel = panelFieldTests.AddFieldTestPanel();
            FieldTestPanel.VectorsPanel = VectorsPanel;

            VectorLabTestListPanel.WorkMode = PanelWorkModes.SessionDetailMode;
            LabTestPanel = panelLabTests.AddLabTestPanel();
            LabTestPanel.VectorsPanel = VectorsPanel;

            SessionSummaryPanel = tpSummaryInfo.AddVsSessionSummaryPanel();
            layoutGroup = (LayoutGroup)SessionSummaryPanel.GetLayout();
            layoutGroup.OnAfterActionExecuted += OnSummaryPanelAfterActionExecuted;
        }

        void OnVectorPanelBeforeActionExecuting(IBasePanel panel, ActionMetaItem action, IObject bo, ref bool cancel)
        {
            ((Vector) bo).openMode = ((Vector) VectorsPanel.BusinessObject).openMode;
        }

        void OnNeedDiagnosesRefreshing()
        {
            RefreshDiagnoses();
        }

        private void OnSummaryPanelAfterActionExecuted(IBasePanel panel, ActionMetaItem action, IObject bo)
        {
            RefreshDiagnoses();
            //это для того, чтобы Vectors перерисовалось (перерасчиталось поле)
            if (Session == null) return;
            Session.strFieldSessionID = Session.strFieldSessionID;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="action"></param>
        /// <param name="bo"></param>
        private void OnVectorsPanelAfterActionExecuted(IBasePanel panel, ActionMetaItem action, IObject bo)
        {
            /*foreach (var vector in Session.Vectors)
            {
                vector.RecalculateLocation();
            }*/
            RefreshPanels();
            RefreshDiagnoses();
            //это для того, чтобы Vectors перерисовалось (перерасчиталось поле)
            if (Session == null) return;
            Session.strFieldSessionID = Session.strFieldSessionID;
        }

        /// <summary>
        /// 
        /// </summary>
        private VectorListPanel VectorsPanel { get; set; }

        private VectorSampleListPanel SamplesPanel { get; set; }
        private VectorFieldTestListPanel FieldTestPanel { get; set; }
        private VectorLabTestListPanel LabTestPanel { get; set; }
        private VsSessionSummaryPanel SessionSummaryPanel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentControl"></param>
        public static void Register(Control parentControl)
        {
            RegisterItem(MenuActionManager.Instance.Create, "MenuNewVector", 255, false, false, MenuGroup.CreateVss);
            //Toolbar menu
            RegisterItem(MenuActionManager.Instance.Journals, "ToolbarNewVector", 100140, true, false, MenuGroup.ToolbarCreate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuAction"></param>
        /// <param name="resourceKey"></param>
        /// <param name="order"></param>
        /// <param name="showInToolbar"></param>
        /// <param name="beginGroup"></param>
        private static void RegisterItem(IMenuAction menuAction, string resourceKey, int order, bool showInToolbar, bool beginGroup, MenuGroup group = MenuGroup.None)
        {
            new MenuAction(ShowMe, MenuActionManager.Instance, menuAction,
                           resourceKey, order, showInToolbar, (int)MenuIconsSmall.VsSessionDetail,
                           (int)MenuIcons.VsSession)
            {
                SelectPermission = PermissionHelper.InsertPermission(EIDSSPermissionObject.VsSession),
                BeginGroup = beginGroup,
                ShowInMenu = !showInToolbar,
                Group = (int)group
            };
        }

        /// <summary>
        /// 
        /// </summary>
        public static void ShowMe()
        {
            object id = null;
            BaseFormManager.ShowNormal(typeof(VsSessionDetail), ref id);
        }

        private VsSession Session { get { return BusinessObject as VsSession; } }

        /// <summary>
        /// 
        /// </summary>
        public override void DefineBinding()
        {
            if (Session == null) return;

            //Session.FieldTests.ListChanged += OnFieldTestsListChanged;
            FieldTestPanel.NeedDiagnosesRefreshing += OnNeedDiagnosesRefreshing;
            SessionSummaryPanel.DiagnosisPanel.NeedDiagnosesRefreshing += OnNeedDiagnosesRefreshing;
            //Session.Summaries.ListChanged += OnFieldTestsListChanged;

            LookupBinder.BindTextEdit(txtSessionID, Session, "strSessionID");
            LookupBinder.BindDate(dtStartDate, Session, "datStartDate");
            LookupBinder.BindDate(dtCloseDate, Session, "datCloseDate");
            LookupBinder.BindTextEdit(txtFieldSessionID, Session, "strFieldSessionID");
            LookupBinder.BindBaseLookup(leSessionStatus, Session, "VsStatus", Session.VsStatusLookup, false, false);
            LookupBinder.BindTextEdit(txtVectors, Session, "strVectorsCalculated");
            LookupBinder.BindSpinEdit(seCollectionEffort, Session, "intCollectionEffort");

            LookupBinder.BindOutbreakLookup(beOutbreakID, Session, "strOutbreakID");
            beOutbreakID.ButtonClick += OnBeOutbreakButtonClick;

            LookupBinder.BindTextEdit(txtDescription, Session, "strDescription");

            //вывод диагнозов
            RefreshDiagnoses();
        }

        /// <summary>
        /// 
        /// </summary>
        private void RefreshDiagnoses()
        {
            Session.RefreshDiagnoses();
            //диагнозы обновляются в VsSession.xml, при сборе FieldTests со всех векторов
            lbDiagnoses.Items.Clear();
            foreach (var diagnosis in Session.DiagnosisList)
            {
                if (lbDiagnoses.Items.Contains(diagnosis.NationalName)) continue;
                lbDiagnoses.Items.Add(diagnosis.NationalName);
            }
            //если диагнозов нет - запрещено связывать сессию с Outbreak-ом
            RefreshOutbreakIDButtons();
        }

        //если диагнозов нет - запрещено связывать сессию с Outbreak-ом
        private void RefreshOutbreakIDButtons()
        {
            if (lbDiagnoses.Items.Count > 0 && !BusinessObject.Environment.ReadOnly)
            {

                foreach (EditorButton btn in beOutbreakID.Properties.Buttons)
                {
                    if (btn.Kind == ButtonPredefines.Glyph || btn.Kind == ButtonPredefines.Ellipsis)
                        btn.Enabled = true;
                }
            }
            else
            {
                foreach (EditorButton btn in beOutbreakID.Properties.Buttons)
                {
                    if (btn.Kind == ButtonPredefines.Glyph || btn.Kind == ButtonPredefines.Ellipsis)
                        btn.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Обновление информации об индикативных диагнозах
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnFieldTestsListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            RefreshDiagnoses();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBeOutbreakButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (!(sender is ButtonEdit)) return;
            if (e.Button.Kind.Equals(ButtonPredefines.Glyph))
            {
                //PerformAction("Save");

                var bo = BaseFormManager.ShowForSelection((IBaseListPanel)ClassLoader.LoadClass("OutbreakListPanel"),
                                                          ((Control)sender).FindForm());
                if (bo != null)
                {
                    var outbreak = bo as OutbreakListItem;
                    if (outbreak != null)
                    {
                        Session.idfOutbreak = Convert.ToInt64(bo.Key);
                        //будет задано, если валидация прошла успешно
                        if (Session.idfOutbreak != null) Session.strOutbreakID = outbreak.strOutbreakID;
                        /*
                        Session.strOutbreakID = outbreak.strOutbreakID;
                        VsSession.Accessor.Instance(null).CheckOutbreak(Session);
                        
                        long idfsCaseDiagnosis = Session.CheckOutbreakDiagnosis(bo.Key);
                        if (idfsCaseDiagnosis == 0)
                        {
                            MessageForm.Show(
                                String.Format(EidssMessages.Get("msgOutbreakDiagnosisErrorCases", "Case/session {0} cannot be added to the outbreak {1}. Diagnosis of the case/session must be the same as the diagnosis of the outbreak or be included to the diagnoses group of the outbreak. Outbreak’s diagnosis/diagnoses group is {2}."), Session.strSessionID, outbreak.strOutbreakID, outbreak.strDiagnosisOrDiagnosisGroup),
                                EidssMessages.Get("ErrErrorFormCaption"), MessageBoxButtons.OK);
                            return;
                        }
                        if (idfsCaseDiagnosis > 0)
                        {
                            var caseDiagnosis = String.Empty;
                            foreach (var diag in Session.DiagnosisList)
                            {
                                if (diag.idfsDiagnosis == idfsCaseDiagnosis)
                                {
                                    caseDiagnosis = diag.NationalName;
                                    break;
                                }
                            }

                            if (!WinUtils.ConfirmMessage(
                                String.Format(EidssMessages.Get("msgUpOutbreakDiagnosisToGroup", "Outbreak diagnosis {0} and diagnosis of the case/session {1} {2} are not equal, but are included to the same diagnoses group {3}. Do you want to enter {3} as outbreak diagnosis?"), outbreak.strDiagnosisOrDiagnosisGroup, Session.strSessionID, caseDiagnosis, outbreak.strDiagnosisGroup))
                                ) return;
                            Session.ChangeOutbreakDiagnosis(bo.Key, outbreak.idfsDiagnosisGroup);
                        }
                        Session.idfOutbreak = Convert.ToInt64(bo.Key);
                        Session.strOutbreakID = outbreak.strOutbreakID;
                        */
                    }
                }
            }
            else if (e.Button.Kind.Equals(ButtonPredefines.Ellipsis))
            {
                //можно только просматривать существующий outbreak
                if (Session.idfOutbreak.HasValue)
                {
                    object id = Session.idfOutbreak.Value;
                    BaseFormManager.ShowModal(((IApplicationForm)(ClassLoader.LoadClass("OutbreakDetail"))),
                                              ((Control)sender).FindForm(), ref id, null, null);
                }
            }
            else if (e.Button.Kind.Equals(ButtonPredefines.Delete))
            {
                Session.idfOutbreak = null;
                Session.strOutbreakID = String.Empty;
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
                if (Session != null)
                {
                    bppLocation.PopupControl.BusinessObject = Session.Location;

                    VectorsPanel.SetDataSource(Session, Session.Vectors);
                    SessionSummaryPanel.SetDataSource(Session, Session.Summaries);
                    RefreshPanels();

                    var om = Session.GetAccessor() as IObjectMeta;
                    if (om != null)
                    {
                        om.Actions.First(c => c.ActionType == ActionTypes.Delete)
                        .AddEnablePredicate((o, p, r) => r && (o is VsSession) && (o as VsSession).ValidateOnDelete());
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actions"></param>
        public override void SetCustomActions(List<ActionMetaItem> actions)
        {
            base.SetCustomActions(actions);

            SetActionFunction(actions, "VsSessionReport", ShowReport);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="bo"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private ActResult ShowReport(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            if (Session == null) return false;
            parameters.Clear();
            parameters.Add(Session.idfVectorSurveillanceSession);
            EidssSiteContext.ReportFactory.VectorSurveillanceSessionSummary(Session.idfVectorSurveillanceSession);
            return true;
        }

        private void RefreshPanels()
        {
            using (new WaitDialog())
            {
                //вставим какой-то вектор, чтобы правильно списки отобразились
                var vector = Session.Vectors.Count > 0 ? Session.Vectors[0] : null;
                SamplesPanel.SetDataSource(vector, Session.Samples);
                FieldTestPanel.SetDataSource(vector, Session.FieldTests);
                LabTestPanel.SetDataSource(vector, Session.LabTests);
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
            if (Session != null) list = Session.GetParamsAction(o.GetType());

            return list;
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
            var isClosed = vsStatus == (long)VsStatusEnum.Closed;

            var readOnly = Session.ReadOnly || isClosed;
            //TODO
            VectorsPanel.ReadOnly = SamplesPanel.ReadOnly = FieldTestPanel.ReadOnly = LabTestPanel.ReadOnly = SessionSummaryPanel.ReadOnly = readOnly;             
        }

        public override bool ReadOnly
        {
            get
            {
                //if (((VsSession)BusinessObject).IsClosed)
                //    return true;
                return base.ReadOnly;
            }
            set
            {
                base.ReadOnly = value;
            }
        }

        public override void DisplayReadOnly(bool recursive)
        {
            base.DisplayReadOnly(recursive);
            if (recursive)
            {
                VectorsPanel.DisplayReadOnly(true);
                SamplesPanel.DisplayReadOnly(true);
                FieldTestPanel.DisplayReadOnly(true);
                LabTestPanel.DisplayReadOnly(true);
                SessionSummaryPanel.DisplayReadOnly(true);
            }
            //если диагнозов нет - запрещено связывать сессию с Outbreak-ом
            RefreshOutbreakIDButtons();
        }

        public override void Release()
        {
            base.Release();
            SamplesPanel.Cleanup();
            VectorsPanel.Cleanup();
            LabTestPanel.Cleanup();
            FieldTestPanel.Cleanup();
            SessionSummaryPanel.Cleanup();
        }
    }
}
