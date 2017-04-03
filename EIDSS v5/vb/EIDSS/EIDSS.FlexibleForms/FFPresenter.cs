using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using DevExpress.XtraBars;
using bv.common;
using bv.common.Core;
using bv.common.db;
using bv.common.win;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.BandedGrid;
using EIDSS.FlexibleForms.Components;
using EIDSS.FlexibleForms.DataBase;
using EIDSS.FlexibleForms.Helpers;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using DevExpress.XtraGrid.Views.Base;
using bv.winclient.Layout;
using eidss.model.Core;
using System.Linq;
using ErrorForm = bv.common.win.ErrorForm;

[assembly: CLSCompliantAttribute(true)]

namespace EIDSS.FlexibleForms
{
    [Description("GUI for displaing Flexible Forms and user input")]
    [CLSCompliantAttribute(true)]
    public partial class FFPresenter : BaseDetailPanel
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public FFPresenter()
        {
            InitializeComponent();
            if (WinUtils.IsComponentInDesignMode(this)) return;
            DbService = new DbServiceUserData();
            baseDataSet = MainDbService.MainDataSet;
            ffRender = new FFRender((DbService)DbService, DesignerHostMain);
            ffRender.EditValueChanging += OnFlexibleFormEditorEditValueChanging;
            ffRender.EditValueChanged += OnFlexibleFormEditorEditValueChanged;
            ffRender.ParameterIsMandatory += SetControlMandatoryState;
            activityParametersBuffer = new ActivityParametersBuffer();
            ReadOnlyMode = false;
            DelayedLoadingNeeded = false;
            DynamicParameterEnabled = false;
            observationsDictionary = new Dictionary<long, long>();
            observationsGroupEditing = new List<long>();
        }

        public override bool ReadOnly
        {
            get
            {
                return base.ReadOnly;
            }
            set
            {
                base.ReadOnly = value;
                if (!ReadOnly)
                {
                    var list = ffRender.ParameterList.Where(p => p.Value.IsMandatoryField()).ToList();
                    foreach (var keyValuePair in list)
                    {
                        LayoutCorrector.SetStyleController(keyValuePair.Value.ControlParameter, LayoutCorrector.MandatoryStyleController);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void BeforeDispose()
        {
            if (ffRender != null)
            {
                ffRender.ClearTemplate();
            }

            base.BeforeDispose();
        }

        private bool m_DynamicParameterEnabled;

        /// <summary>
        /// Доступна ли возможность добавлять динамические параметры
        /// </summary>
        [Browsable(true)]
        public bool DynamicParameterEnabled
        {
            get { return m_DynamicParameterEnabled; }
            set
            {
                m_DynamicParameterEnabled = value;
                RefreshVisibleDynamicParameters();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void RefreshVisibleDynamicParameters()
        {
            barDockControlTop.Visible = barDynamicParameters.Visible = DynamicParameterEnabled;
        }

        /// <summary>
        /// Изменилось значение управляющего контрола в одном из обычных параметров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnFlexibleFormEditorEditValueChanged(object sender, EventArgs e)
        {
            if (nowLoading || (!TemplateID.HasValue) || Closing) return;
            //закончим ввод редактируемого значения
            OnParameterEditValueChanged(sender, e);
            //
            var baseEdit = sender as BaseEdit;
            if (baseEdit == null) return;
            var parameter = baseEdit.Tag as Parameter;
            if (parameter == null) return;

            bool needCheckRules = (baseEdit.IsModified || (baseEdit.OldEditValue != baseEdit.EditValue));
            if (needCheckRules)
            {
                //если числовой параметр, то нужно отсечь лишнее срабатывание из-за накладывания маски
                if ((parameter.IdfsParameterType != null) && (parameter.IdfsParameter != null))
                {
                    if (MainDbService.IsParameterNumeric(parameter.IdfsParameter.Value))
                    {
                        int intvalue = 0;
                        if (!Utils.IsEmpty(baseEdit.EditValue)) Int32.TryParse(baseEdit.EditValue.ToString(), out intvalue);
                        needCheckRules = !((baseEdit.OldEditValue == null) && (intvalue == 0));
                    }
                }
            }

            if (needCheckRules)
            {
                //найдём правило (или правила), в котором участвует такой параметр, и выполним их
                RulesCheck(parameter.IdfsParameter, FFRuleCheckPointType.OnValueChanged);
            }
        }

        /// <summary>
        /// Выполняет функционал указанного правила
        /// </summary>
        /// <param name="rowRule"></param>
        private bool RuleExecute(FlexibleFormsDS.RulesRow rowRule)
        {
            if (!ObservationID.HasValue) return false;

            //TODO разобраться с табличными значениями

            //получаем параметры-аргументы этого правила
            var parameterForFunctionRows =
                    (FlexibleFormsDS.RuleParameterForFunctionRow[])
                    MainDbService.MainDataSet.RuleParameterForFunction.Select(DataHelper.Filter("idfsRule", rowRule.idfsRule));
            if (parameterForFunctionRows.Length == 0) return false;
            //получаем первый параметр
            var parameter1 = parameterForFunctionRows[0];
            var param1Value = MainDbService.GetActivityParametersRow(ObservationID.Value, parameter1.idfsParameter, null);
            //исключением является ситуация, когда параметру задаётся правило Is Empty, то ему не задавались значения вообще
            //потому для унификации создадим фиктивную строку, но не будем её добавлять в таблицу
            if (Utils.IsEmpty(param1Value))
            {
                param1Value = MainDbService.MainDataSet.ActivityParameters.NewActivityParametersRow();
                param1Value.varValue = null;
            }
            //если данное правило подразумевает два параметра, то получим и второй
            FlexibleFormsDS.RuleParameterForFunctionRow parameter2 = null;
            FlexibleFormsDS.ActivityParametersRow param2Value = null;
            if (rowRule.intNumberOfParameters == 2)
            {
                parameter2 = parameterForFunctionRows[1];
                param2Value = MainDbService.GetActivityParametersRow(ObservationID.Value, parameter2.idfsParameter, null);
            }
            //если хотя бы один из аргументов не задан, то правило не выполняется (то есть игнорируется)
            if (Utils.IsEmpty(param1Value.varValue) && (!rowRule.idfsRuleFunction.Equals((long)FFRuleFunctions.Empty))) return false;
            if (parameter2 != null)
            {
                if (Utils.IsEmpty(param2Value)) return false;
                if (Utils.IsEmpty(param2Value.varValue)) return false;
            }

            //получаем параметры-цели для этого правила
            var parameterForActionRows = MainDbService.GetRuleParameterForAction(rowRule.idfsRule);
            //если нет ни одной цели, то правило не запускается
            if (parameterForActionRows.Length == 0) return false;

            //метка того, что условия для срабатывания правила выполнились
            var ruleExecuted = false; //изначально не соблюдены
            //выполняем действия в зависимости от типа правила
            switch (rowRule.idfsRuleFunction)
            {
                case (long)FFRuleFunctions.CurrentDate:
                    if (param1Value.varValue != null)
                    {
                        DateTime dt = ((DateTime)param1Value.varValue).Date;
                        if (dt <= DateTime.Now.Date) ruleExecuted = true;
                    }
                    break;
                case (long)FFRuleFunctions.Empty:
                    if (Utils.IsEmpty(param1Value.varValue)) ruleExecuted = true;
                    break;
                case (long)FFRuleFunctions.Value:
                    //получаем перечень констант
                    var ruleConstantRows = (FlexibleFormsDS.RuleConstantRow[])MainDbService.MainDataSet.RuleConstant.Select(DataHelper.Filter("idfsRule", rowRule.idfsRule));
                    //если есть константы, с которыми надо сравнивать, то сравним с каждой из них
                    foreach (var row in ruleConstantRows)
                    {
                        //сравним как строки
                        if (param1Value.varValue != null)
                        {
                            if (!row.varConstant.ToString().Equals(param1Value.varValue.ToString())) continue;
                            ruleExecuted = true;
                        }
                        break;
                    }
                    break;
                case (long)FFRuleFunctions.Greater:
                    double d1;
                    double d2;
                    DateTime dt1;
                    DateTime dt2;
                    if ((param2Value != null) && (param1Value.varValue != null))
                    {
                        var p1 = param1Value.varValue.ToString();
                        var p2 = param2Value.varValue.ToString();

                        if (Double.TryParse(p1, out d1) &&
                            Double.TryParse(p2, out d2))
                        {
                            if (d1 > d2) ruleExecuted = true;
                        }
                        else if (DateTime.TryParse(p1, out dt1) &&
                            DateTime.TryParse(p2, out dt2))
                        {
                            if (dt1 > dt2) ruleExecuted = true;
                        }
                    }

                    break;
                case (long)FFRuleFunctions.GreaterEqual:
                    if ((param2Value != null) && (param1Value.varValue != null))
                    {
                        var p1 = param1Value.varValue.ToString();
                        var p2 = param2Value.varValue.ToString();

                        if (Double.TryParse(p1, out d1) &&
                            Double.TryParse(p2, out d2))
                        {
                            if (d1 >= d2) ruleExecuted = true;
                        }
                        else if (DateTime.TryParse(p1, out dt1) &&
                            DateTime.TryParse(p2, out dt2))
                        {
                            if (dt1 >= dt2) ruleExecuted = true;
                        }
                    }

                    break;

            }
            //накладываем условие отрицания, если оно есть
            if (rowRule.blnNot) ruleExecuted = !ruleExecuted;
            var result = ruleExecuted;
            //если условия не выполнились
            if (!ruleExecuted)
            {
                foreach (var rowAction in parameterForActionRows)
                {
                    switch (rowAction.idfsRuleAction)
                    {
                        case (long)FFRuleActions.Disabled:
                            RuleActionDisabled(rowAction.idfsParameter, false); //разблокируем контролы!
                            break;
                    }
                }
            }
            else
            {
                //если тип правило "Правило с ошибкой при сохранении", то покажем сообщение и укажем, что правило не выполнилось 
                //если тип правило "Правило с уведомлением при сохранении", то покажем запрос пользователю. Если тот скажет "нет", то правило не выполнилось, если "да", то выполнилось
                //в остальных случаях просто показываем сообщение
                if (rowRule.idfsCheckPoint.Equals(((long)FFRuleCheckPointType.OnSaveWithError).ToString()) || (rowRule.idfsCheckPoint.Equals(((long)FFRuleCheckPointType.OnSaveWithNotify).ToString())))
                {
                    var message = (!rowRule.IsMessageNationalTextNull()) ? rowRule.MessageNationalText.Length > 0 ? rowRule.MessageNationalText : "<No Message>" : "<No Message>";

                    if (rowRule.idfsCheckPoint.Equals(((long)FFRuleCheckPointType.OnSaveWithError).ToString()))
                    {
                        ErrorForm.ShowWarningDirect(message);
                    }
                    else if (rowRule.idfsCheckPoint.Equals(((long)FFRuleCheckPointType.OnSaveWithNotify).ToString()))
                    {
                        //пользователь сам решит продолжать проверки и сохранение или нет
                        result = !WinUtils.ConfirmMessage(message, String.Empty);
                    }
                    //если правило выполнилось при сохранении (то есть показало на ошибку), то сфокусируем на одном из параметров, участвующих в правиле
                    if (result)
                    {
                        //для обычных параметров (которые не в таблице)
                        var parameter = GetParameter(parameter1.idfsParameter);
                        if (parameter != null)
                        {
                            FocusOnField(parameter);
                        }
                    }
                }
                else
                {
                    if (!rowRule.IsMessageNationalTextNull() && (rowRule.MessageNationalText.Length > 0)) ErrorForm.ShowMessageDirect(rowRule.MessageNationalText);
                }
                //пройдём по всем параметрам, указанным в списке целей, и выполним действия для каждого из них
                foreach (FlexibleFormsDS.RuleParameterForActionRow rowAction in parameterForActionRows)
                {
                    switch (rowAction.idfsRuleAction)
                    {
                        case (long)FFRuleActions.Clear:
                            RuleActionClear(rowAction.idfsParameter);
                            break;
                        case (long)FFRuleActions.Disabled:
                            RuleActionDisabled(rowAction.idfsParameter, true);
                            break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Действие для правил (Disabled/ Enabled)
        /// </summary>
        /// <param name="idfsParameter"></param>
        /// <param name="disabled">true, если нужно заблокировать контрол, false, если разблокировать</param>
        private void RuleActionDisabled(long idfsParameter, bool disabled)
        {
            //если поле блокируется, то предварительно его надо очистить
            if (disabled) RuleActionClear(idfsParameter);
            //находим контрол для этого параметра
            //если параметра нет в библиотеке, то выходим
            //if (!flexibleFormEditor.ParameterList.ContainsKey(idfsParameter)) return;
            //Parameter parameter = flexibleFormEditor.ParameterList[idfsParameter];
            if (!ffRender.ParameterList.ContainsKey(idfsParameter)) return;
            var parameter = ffRender.ParameterList[idfsParameter];
            parameter.ControlParameter.Enabled = !disabled;
        }

        /// <summary>
        /// Действие для правил (Clear)
        /// </summary>
        /// <param name="idfsParameter"></param>
        private void RuleActionClear(long idfsParameter)
        {
            //находим контрол для этого параметра
            //если параметра нет в библиотеке, то выходим
            //Parameter parameter = flexibleFormEditor.GetParameter(idfsParameter);
            Parameter parameter = ffRender.GetParameter(idfsParameter);
            if (parameter == null) return;
            parameter.ControlParameter.EditValue = null;
        }

        /// <summary>
        /// Обработка изменения значения в одной из табличных секций
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnFlexibleFormEditorEditValueChanging(object sender, ChangingEventArgs e)
        {
            if ((EditValueChanging != null) && (!nowLoading) && (!Closing)) EditValueChanging(sender, e);
        }

        public delegate void EditValueChangingDelegate(object sender, ChangingEventArgs e);

        /// <summary>
        /// Событие срабатывает, когда меняется значение в ячейке в одной из табличных секций
        /// </summary>
        public event EditValueChangingDelegate EditValueChanging;

        private FFRender ffRender { get; set; }

        /// <summary>
        /// Отображает Flexible Form c данными
        /// </summary>
        /// <param name="idfsFormTemplate">ID шаблона</param>
        /// <param name="idfObservation">ID сущности (observation)</param>
        /// <param name="aformType">ID типа формы</param>
        /// <param name="bufferingUserData"></param>
        public void ShowFlexibleForm(long idfsFormTemplate, long idfObservation, FFType aformType, bool bufferingUserData)
        {
            ShowFlexibleForm(idfsFormTemplate, idfObservation, aformType, bufferingUserData, false);
        }

        /// <summary>
        /// Отображает Flexible Form c данными
        /// </summary>
        /// <param name="idfsFormTemplate">ID шаблона</param>
        /// <param name="idfObservation">ID сущности (observation)</param>
        /// <param name="aformType">ID типа формы</param>
        /// <param name="bufferingUserData">false -- каждый раз загружать пользовательские данные из БД (по умолчанию загружаются единожды)</param>
        /// <param name="runImmediatly">true -- не использовать отложенную загрузку (по умолчанию используется)</param>
        public void ShowFlexibleForm(long idfsFormTemplate, long idfObservation, FFType aformType, bool bufferingUserData, bool runImmediatly)
        {
            var observations = new List<long> { idfObservation };
            ShowFlexibleForm(idfsFormTemplate, observations, aformType, null, null, runImmediatly, bufferingUserData, false, false);
        }

        /// <summary>
        /// Отображает Flexible Form c данными
        /// </summary>
        /// <param name="idfsFormTemplate">ID шаблона</param>
        /// <param name="idfObservation">ID сущности (observation)</param>
        /// <param name="aformType">ID типа формы</param>
        public void ShowFlexibleForm(long idfsFormTemplate, long idfObservation, FFType aformType)
        {
            ShowFlexibleForm(idfsFormTemplate, idfObservation, aformType, false);
        }

        /// <summary>
        /// Находится ли компонент в режиме только для чтения
        /// </summary>
        public bool ReadOnlyMode { get; private set; }

        //хранилища значений параметров для отложенной загрузки шаблонов
        private long m_IdfsFormTemplateStored;
        private List<long> m_ObservationsStored;
        private FFType m_FormTypeStored;
        private List<AggregateCaseSection> m_PresetStubsStored;
        private long? m_IdfVersionStored;

        /// <summary>
        /// Признак отложенной загрузки
        /// </summary>
        public bool DelayedLoadingNeeded { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private long? idfsFormTemplatePrevious { get; set; }

        /// <summary>
        /// Отображает Flexible Form c данными
        /// </summary>
        /// <param name="idfsFormTemplate">ID шаблона</param>
        /// <param name="observations">Коллекция ID сущности (observation)</param>
        /// <param name="aformType">ID типа формы</param>
        /// <param name="idfVersion">Версия боковика (если не указана, то используется та, что установлена для данного observation)</param>
        /// <param name="presetStubs"></param>
        /// <param name="runImmediatly">Запускать показ шаблона, не обращая внимания на оптимизацию</param>
        /// <param name="bufferingUserData">True (по умолчанию) - буфферизировать пользовательские данные, False - каждый раз обращаться в БД за пользовательскими данными</param>
        /// <param name="isSummary"></param>
        /// <param name="isGroupEditing">Работает ли форма в режиме группового редактирования</param>
        public void ShowFlexibleForm(long idfsFormTemplate, List<long> observations, FFType aformType, List<AggregateCaseSection> presetStubs, long? idfVersion, bool runImmediatly, bool bufferingUserData, bool isSummary, bool isGroupEditing)
        {
            if (observations.Count == 0) return;
            nowLoading = true;
            try
            {

                IsGroupEditingRegime = isGroupEditing;
                TemplateID = MainDbService.TemplateID = idfsFormTemplate;
                if ((observations.Count == 1) && !isGroupEditing)
                {
                    ObservationID = observations[0];
                }
                else if (isGroupEditing)
                {
                    ObservationID = MainDbService.IdfObservationGroup;
                }
                else
                {
                    //одновременно в случаях агг.кейса и саммари
                    ObservationID = MainDbService.IdfObservationSummary;
                }

                FormTypeRow = MainDbService.GetFormType((long)aformType);
                if (FormTypeRow == null) return;
                VersionMatrixStub = idfVersion;
                ffRender.ReadOnly = ReadOnly;
                btnAddParameter.Enabled = !ReadOnly;
                btnRemoveAllDynamicParameter.Enabled = !ReadOnly;
                DynamicParameterEnabled = DynamicParameterEnabled && !ReadOnly;

                //заполняем переменные для отложенной загрузки
                DelayedLoadingNeeded = ((m_IdfsFormTemplateStored != idfsFormTemplate)
                                        || (m_ObservationsStored != observations)
                                        || (m_FormTypeStored != aformType)
                                        || (m_PresetStubsStored != presetStubs)
                                        || (m_IdfVersionStored != idfVersion));

                m_IdfsFormTemplateStored = idfsFormTemplate;
                m_ObservationsStored = observations;
                m_FormTypeStored = aformType;
                m_PresetStubsStored = presetStubs;
                m_IdfVersionStored = idfVersion;

                //если шаблон содержит обязательные поля, то нужно производить его загрузку без откладывания
                if (TemplateHasMandatoryFields(TemplateID.Value)) runImmediatly = true;

                //если в данный момент компонент не виден, то не нужно производить загрузку
                if (!runImmediatly && !Visible) return;

                //если загружаются данные с боковиком, то требуется вычислить версию боковика
                if (presetStubs != null)
                {
                    //если явно не задана версия боковика, то нужно взять активную
                    if (VersionMatrixStub == null)
                    {
                        var row = MainDbService.LoadMatrixStubInfo(ObservationID.Value);
                        if ((row != null) && (!row.IsidfVersionNull()))
                            VersionMatrixStub = row.idfVersion;
                    }
                    //если версию не удалось обнаружить, то дальше шаблон загружать нельзя
                    if (VersionMatrixStub == null) return;
                }

                //восстанавливаем шаблон
                ffRender.RestoreTemplate(idfsFormTemplate, FormTypeRow.idfsFormType, ModelUserContext.CurrentLanguage,
                                         presetStubs,
                                         VersionMatrixStub.HasValue ? VersionMatrixStub.Value : VersionMatrixStub, isSummary);

                //повесим на все параметры события изменения, чтобы сразу переливать данные в таблицу
                SetEventForParameters();
                //загрузим пользовательские данные
                foreach (var observation in observations)
                {
                    MainDbService.LoadUserData(observation, idfsFormTemplate, bufferingUserData);
                }

                #region Ressurection для параметров

                //если существуют данные, для которых в шаблоне больше нет параметров, то надо эти параметры создать и разместить их в нижней части их родителей
                //параметры создаём в штатном режиме, координаты для них вычисляем, исходя из положения родителя
                //определим какие параметры теперь удалены, но данные по ним не удалены
                var parametersTable = MainDbService.LoadParameterDeletedFromTemplate(
                    ObservationID.Value
                    , idfsFormTemplate
                    , idfsFormTemplatePrevious);
                
                if (parametersTable.Count > 0)
                {
                    //покажем панель, где нужно разместить динамические параметры
                    ffRender.ShowDynamicParametersGroupControl(idfsFormTemplate);
                }
                else
                {
                    ffRender.SetVisibleDynamicParametersGroupControl(false);
                }

                idfsFormTemplatePrevious = idfsFormTemplate;

                //создаем параметры и добавляем их в шаблон
                foreach (var row in parametersTable)
                {
                    //находим параметр-образец
                    var parametersRow = MainDbService.GetParameterRow(row.idfsParameter);
                    if (parametersRow == null) continue;
                    //создаём этот параметр на специальной панели
                    ffRender.CreateParameterInParameterDynamicParametersGroupControl(parametersRow, TemplateID.Value);
                }

                #endregion

                ReadOnlyMode = false;

                FlexibleFormsDS.PredefinedStubRow[] predefinedStubRows = null;
                //если есть предустановленный боковик, то дополним пользовательские данные его данными
                if (presetStubs != null) MainDbService.IncludeStubDataInUserData(TemplateID, ObservationID, VersionMatrixStub, out predefinedStubRows);

                //расставим значения по параметрам
                if (!isGroupEditing)
                {
                    SetValuesToParameters(predefinedStubRows);
                }
                else
                {
                    SetValuesToParametersGroupEditing();
                }

                //выставим всем пользовательским данным, что они не менялись, дабы предотвратить лишнее сохранение
                MainDbService.MainDataSet.ActivityParameters.AcceptChanges();

                //запустим проверку правил, которые должны срабатывать при загрузке шаблона
                //правила и их инфраструктура уже загружены выше в RestoreTemplate
                //(выполняем для всех параметров)
                RulesCheck(null, FFRuleCheckPointType.OnLoad);

                //раздадим содержимому шаблона правильные TabIndex'ы
                HelperFunctions.SetTabIndex(ffRender.ParameterList, ffRender.SectionList);

                DelayedLoadingNeeded = false;
                nowLoading = false;
                m_BindingDefined = true;
            }
            catch (SqlException e)
            {
                if(!SqlExceptionHandler.Handle(e))
                {
                    ErrorForm.ShowError(StandardError.FillDatasetError, e);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool LoadData(ref object id)
        {
            if (observationsDictionary != null) observationsDictionary.Clear();
            return true;
        }

        /// <summary>
        /// Отображает Flexible Form c данными
        /// </summary>
        /// <param name="idfsFormTemplate">ID шаблона</param>
        /// <param name="observations">Коллекция ID сущности (observation)</param>
        /// <param name="aformType">ID типа формы</param>
        /// <param name="idfVersion">Версия боковика (если не указана, то используется та, что установлена для данного observation)</param>
        /// <param name="presetStubs"></param>
        /// <param name="runImmediatly">Запускать показ шаблона, не обращая внимания на оптимизацию</param>
        /// <param name="isSummary"></param>
        public void ShowFlexibleForm(long idfsFormTemplate, List<long> observations, FFType aformType, List<AggregateCaseSection> presetStubs, long? idfVersion, bool runImmediatly, bool isSummary)
        {
            ShowFlexibleForm(idfsFormTemplate, observations, aformType, presetStubs, idfVersion, runImmediatly, true, isSummary, false);
        }

        /// <summary>
        /// Запускает проверку правил указанного типа
        /// </summary>
        /// <param name="idfsParameter">Если нужно выполнить правило для конкретного параметра</param>
        /// <param name="ffRuleCheckPointType"></param>
        private bool RulesCheck(long? idfsParameter, FFRuleCheckPointType ffRuleCheckPointType)
        {
            var result = true;
            if (!TemplateID.HasValue) return true;
            foreach (var row in MainDbService.MainDataSet.Rules)
            {
                if (!row.idfsFormTemplate.Equals(TemplateID.Value) || (!Convert.ToInt64(row.idfsCheckPoint).Equals((long)ffRuleCheckPointType))) continue;
                //если нужно выполнить только те правила, где участвует указанный параметр
                if (idfsParameter != null)
                {
                    var parameterForFunctionRows =
                        (FlexibleFormsDS.RuleParameterForFunctionRow[])
                        MainDbService.MainDataSet.RuleParameterForFunction.Select(DataHelper.Filter("idfsRule", row.idfsRule, "idfsParameter", idfsParameter));
                    if (parameterForFunctionRows.Length == 0) continue;
                }
                //если найдено вхождение данного параметра в правило, то выполняем функционал правила
                var res = RuleExecute(row);
                //если при сохранении какое-то правило выполнилось (сработало), то это повод остановить сохранение
                //при сохранении сработавшее правило обычно говорит о неверных данных
                if (res && (ffRuleCheckPointType.Equals(FFRuleCheckPointType.OnSaveWithError) || (ffRuleCheckPointType.Equals(FFRuleCheckPointType.OnSaveWithNotify))))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// Является ли используемый шаблон UNI-шаблоном
        /// </summary>
        public bool? IsUNITemplate { get; private set; }

        ///// <summary>
        ///// Удаляет пользовательские данные, которые касаются боковика
        ///// </summary>
        //private void DeleteStubData()
        //{
        //    //метод используется как предварительная очистка шаблона перед помещением туда нового боковика
        //    //это необходимо, когда при одном и том же observation меняется версия боковика в одном сеансе работы
        //    FlexibleFormsDS.ActivityParametersRow[] userData = (FlexibleFormsDS.ActivityParametersRow[])MainDbService.MainDataSet.ActivityParameters.Select(DataHelper.Filter("idfObservation", ObservationID));
        //    foreach (FlexibleFormsDS.ActivityParametersRow row in userData)
        //    {
        //        //если строка пользовательских данных относится к параметру с отрицательным порядковым номером, то это данные боковика
        //        if (!flexibleFormEditor.ParameterList.ContainsKey(row.idfsParameter)) continue;
        //        if (flexibleFormEditor.ParameterList[row.idfsParameter].ParameterTemplateRow.intOrder < 0)
        //        {
        //            row.Delete();
        //        }
        //    }
        //}

        /// <summary>
        /// Помещает значения в управляющие контролы параметров
        /// </summary>
        /// <param name="predefinedStubRows">Содержимое боковика, если таковой есть, или null, если его нет</param>
        private void SetValuesToParameters(FlexibleFormsDS.PredefinedStubRow[] predefinedStubRows)
        {
            if (MainDbService.MainDataSet.ActivityParameters.Rows.Count == 0) return;
            var userData = (FlexibleFormsDS.ActivityParametersRow[])MainDbService.MainDataSet.ActivityParameters.Select(DataHelper.Filter("idfObservation", ObservationID));
            foreach (var row in userData)
            {
                if (!row.IsRowAlive()) continue;
                //если не удалось свести с номером строки, то значит какие-то проблемы или изменения с матрицей, и игнорируем эту строку
                if (row.IsintNumRowNull()) continue;
                //если строка помечена на удаление, то также пропускаем
                if (!row.IsintRowStateNull() && (row.intRowState == 1)) continue;
                //если боковик задан, то не выводим те строки, которых нет в боковике
                if (predefinedStubRows != null)
                {
                    var idRow = row.idfRow;
                    if (predefinedStubRows.Count(r => r.idfRow == idRow) == 0) continue;
                }
                //пробуем найти такой параметр
                if (!ffRender.ParameterList.ContainsKey(row.idfsParameter)) continue;
                var parameter = ffRender.ParameterList[row.idfsParameter];
                //помещаем туда значение
                //если параметр относится к обычной секции или просто расположен в теле шаблона, то просто присвоим ему значение
                SetValueToEditor(parameter, row);
            }
        }

        /// <summary>
        /// Размещение значений в контролах в случае группового редактирования
        /// </summary>
        private void SetValuesToParametersGroupEditing()
        {
            foreach (var pl in ffRender.ParameterList)
            {
                var idParameter = pl.Key;
                var parameter = pl.Value;

                var userData = MainDbService.MainDataSet.ActivityParameters.Where(ap =>
                    (ap.idfObservation != MainDbService.IdfObservationGroup)
                    &&
                    (ap.idfsParameter == idParameter)
                    ).ToList();
                var enabled = true;
                //для редактирования значения во всех обсервациях должны быть одинаковыми
                //отсутствие введённых значений разрешает ввод (считается одинаковыми значениями)
                if (userData.Count > 0) enabled = userData.All(ap => ap.varValue.Equals(userData[0].varValue));
                if (enabled)
                {
                    if (userData.Count > 0)
                    {
                        SetValueToEditor(parameter, userData[0]);
                    }
                }
                if (!ReadOnly) parameter.ReadOnly = !enabled;
            }
        }

        /// <summary>
        /// Буфер для копирования пользовательских данных
        /// </summary>
        private ActivityParametersBuffer activityParametersBuffer { get; set; }

        /// <summary>
        /// Выставляет значение контролу параметра
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="rowData"></param>
        private void SetValueToEditor(Parameter parameter, FlexibleFormsDS.ActivityParametersRow rowData)
        {
            if (!parameter.IdfsParameter.HasValue) return;

            //помещаем туда значение
            //если параметр числовой, то переведём его значение к национальной культуре
            var value = rowData.varValue;
            //если параметр числовой, то нужно привести его к национальной культуре
            if (MainDbService.IsParameterNumeric(parameter.IdfsParameter.Value))
            {
                decimal decValue;
                if (Decimal.TryParse(value.ToString(), out decValue)) value = decValue;
            }

            //если параметр относится к обычной секции или просто расположен в теле шаблона, то просто присвоим ему значение
            if (parameter.RootSection == null)
            {
                parameter.SetValue(value);
                //parameter.ControlParameter.EditValue = value;
            }
            else
            {
                parameter.RootSection.SetTableValue(parameter, rowData.intNumRow, value);
            }
        }

        /// <summary>
        /// Задание событий для параметров
        /// </summary>
        private void SetEventForParameters()
        {
            //TODO проверить в смешанном режиме, когда одновременно и секции и параметры
            foreach (var parameter in ffRender.ParameterList.Values)
            {
                parameter.ControlParameter.EditValueChanged += OnParameterEditValueChanged;
            }
            
            foreach (var sectionTable in ffRender.SectionTableList.Values)
            {
                //чтобы не было множественного вызова, если есть несколько вложенных табличных секций
                //sectionTable.RootSection.GridViewMain.CellValueChanged -= OnSectionTableCellValueChanged;
                //sectionTable.RootSection.GridViewMain.CellValueChanged += OnSectionTableCellValueChanged;
                sectionTable.RootSection.CellValueChanged -= OnSectionTableCellValueChanged;
                sectionTable.RootSection.CellValueChanged += OnSectionTableCellValueChanged;
                sectionTable.RootSection.RemoveRow -= OnSectionTemplateRemoveRow;
                sectionTable.RootSection.RemoveRow += OnSectionTemplateRemoveRow;
            }
        }

        /// <summary>
        /// Удаление строки в табличной секции
        /// </summary>
        /// <param name="idfsSectionTemplate"></param>
        /// <param name="numRow"></param>
        void OnSectionTemplateRemoveRow(long idfsSectionTemplate, int numRow)
        {
            if (nowLoading || Closing || !ObservationID.HasValue || !TemplateID.HasValue) return;

            var rootSectionTable = ffRender.SectionTableList[idfsSectionTemplate];
            //не актуально для таблиц с фиксированными боковиками
            if (rootSectionTable.IsFixedStubSection) return;

            var idfRow = GetIdfRowTableParameter(ObservationID.Value, numRow, rootSectionTable);
            var pairkey = new Dictionary<string, long>
                              {
                                  {"idfObservation", ObservationID.Value},
                                  {"idfRow", idfRow}
                              };
            var rows = DataHelper.FindDataRows(pairkey, MainDbService.MainDataSet.ActivityParameters);
            foreach (FlexibleFormsDS.ActivityParametersRow dataRow in rows)
            {
                dataRow.intNumRow = dataRow.intNumRow == 0? -1000 : - dataRow.intNumRow;
                dataRow.varValue = DBNull.Value;
            }

            //пересчитывать номера строк у всех последующих после удаленной
            for (var i = 0; i < MainDbService.MainDataSet.ActivityParameters.Count; i++)
            {
                var row = MainDbService.MainDataSet.ActivityParameters[i];
                if (!row.IsRowAlive()) continue;
                if (row.intNumRow > numRow) row.intNumRow--;
            }
        }

        /// <summary>
        /// Возвращает табличную секцию, если таковая имеется в шаблоне
        /// </summary>
        /// <param name="idfsSection">ID табличной секции</param>
        /// <returns>возвращает табличную секцию, если таковая имеется в шаблоне, или null, если её нет</returns>
        public SectionTable GetSectionTable(long idfsSection)
        {
            return ffRender.GetSectionTable(idfsSection);
        }

        /// <summary>
        /// Возвращает параметр, если таковой имеется в шаблоне
        /// </summary>
        /// <param name="idfsParameter">ID параметра</param>
        /// <returns>Возвращает параметр, если таковой имеется в шаблоне, или null, если его нет</returns>
        public Parameter GetParameter(long idfsParameter)
        {
            return ffRender.GetParameter(idfsParameter);
        }

        /// <summary>
        /// Возвращает табличную секцию, если таковая имеется в шаблоне
        /// </summary>
        /// <param name="index">Порядковый номер табличной секции</param>
        /// <returns>возвращает табличную секцию, если таковая имеется в шаблоне, или null, если её нет</returns>
        public SectionTable GetSectionTableByIndex(int index)
        {
            return ffRender.GetSectionTableByIndex(index);
        }

        /// <summary>
        /// Когда меняется значение в ячейке таблицы табличной секции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnSectionTableCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (nowLoading || Closing || !ObservationID.HasValue || !TemplateID.HasValue) return;

            var column = e.Column as BandedGridColumn;
            if (column == null) return;
            var parameterTemplateRow = ((GridBand) column.Tag).Tag as FlexibleFormsDS.ParameterTemplateRow;
            if (parameterTemplateRow == null) return;
            var rootSectionTable = (SectionTable) ((AdvBandedGridView) sender).Tag;
            //из-за двойного режима добавления строк
            var d = e.RowHandle == -2147483647;
            var numRow = rootSectionTable.GridViewMain.IsNewItemRow(e.RowHandle)
                             ? rootSectionTable.GridViewMain.RowCount - (d ? 0 : 1)
                             : e.RowHandle;

            var idfRow = GetIdfRowTableParameter(ObservationID.Value, numRow, rootSectionTable);
            MainDbService.ChangeValue(ObservationID.Value, TemplateID.Value, parameterTemplateRow.idfsParameter, idfRow,
                                      numRow, e.Value, null);
        }

        /// <summary>
        /// Показывает, что в данный момент происходит загрузка компонента или какие-либо служебные действия
        /// </summary>
        private bool nowLoading { get; set; }

        /// <summary>
        /// Изменение значения параметра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnParameterEditValueChanged(object sender, EventArgs e)
        {
            if (nowLoading || Closing || !ObservationID.HasValue || !TemplateID.HasValue) return;
            var be = sender as BaseEdit;
            if (be == null) return;
            var parameter = (Parameter)be.Tag;
            if (!parameter.IdfsParameter.HasValue) return;
            var idfRow = GetIdfRowSimpleParameter(ObservationID.Value, parameter.IdfsParameter.Value);
            var varValue = be.EditValue;
            if (be.EditValue != null)
            {
                long longval;
                if (Int64.TryParse(be.EditValue.ToString(), out longval) && (longval == -1)) varValue = null;
            }
            MainDbService.ChangeValue(ObservationID.Value, TemplateID.Value, parameter.IdfsParameter.Value, idfRow, 0, varValue, null);
            if ((observationsGroupEditing.Count > 0) && IsGroupEditingRegime)
            {
                //раздаём это значение во все обсервации
                foreach (var obs in observationsGroupEditing)
                {
                    var idObs = obs;
                    //пробуем определить настоящий idfRow, который уже выдан этому значению
                    //если его нет (это новая запись), то берём только что созданный
                    var ap = MainDbService.MainDataSet.ActivityParameters.FirstOrDefault(a => (a.idfObservation == idObs) && (a.idfsParameter == parameter.IdfsParameter.Value));
                    var idr = ap != null ? ap.idfRow : idfRow;
                    MainDbService.ChangeValue(obs, TemplateID.Value, parameter.IdfsParameter.Value, idr, 0, varValue, null);
                }
            }
        }

        /// <summary>
        /// Получает или создаём idfRow для параметра, размещённого не в таблице
        /// </summary>
        /// <param name="observationid"></param>
        /// <param name="idfsParameter"></param>
        /// <returns></returns>
        private long GetIdfRowSimpleParameter(long observationid, long idfsParameter)
        {
            //пробует отыскать строку. Если строка не найдена, то возвращается null
            var userData = (FlexibleFormsDS.ActivityParametersRow[])MainDbService.MainDataSet.ActivityParameters.Select(DataHelper.Filter("idfObservation", observationid, "idfsParameter", idfsParameter), "[idfRow] ASC");
            return userData.Length == 1 ? userData[0].idfRow : BaseDbService.NewIntID();
        }

        /// <summary>
        /// Получает или создаём idfRow для параметра, размещённого в таблице
        /// </summary>
        /// <param name="observationid"></param>
        /// <param name="numRow"></param>
        /// <param name="sectionTable">Табличная секция, в которой произошли изменения</param>
        /// <returns></returns>
        private long GetIdfRowTableParameter(long observationid, int numRow, SectionTable sectionTable)
        {
            long result = -1;

            //среди всех параметров (читай столбцов), которые находятся в данной табличной секции, пробуем найти хотя бы один, который расположен на нужной строке
            //точнее, который имеет данные, связанные с этой строкой
            foreach (BandedGridColumn column in sectionTable.GridViewMain.Columns)
            {
                var parameterTemplateRow = ((GridBand)column.Tag).Tag as FlexibleFormsDS.ParameterTemplateRow;
                if (parameterTemplateRow == null) continue;
                var activityParametersRows = (FlexibleFormsDS.ActivityParametersRow[])MainDbService.MainDataSet.ActivityParameters.Select(DataHelper.Filter("idfObservation", observationid, "idfsParameter", parameterTemplateRow.idfsParameter, "intNumRow", numRow));
                if (activityParametersRows.Length > 0)
                {
                    result = activityParametersRows[0].idfRow;
                    break;
                }
            }
            //если не удалось найти, то создадим новую
            if (result == -1) result = BaseDbService.NewIntID();
            return result;
        }

        /// <summary>
        /// Ссылка на датасет для Flexible Forms
        /// </summary>
        public DbServiceUserData MainDbService { get { return (DbServiceUserData)DbService; } }

        /// <summary>
        /// Отображает Flexible Form c данными по агрегатному случаю
        /// </summary>
        /// <param name="aggregateCaseType"></param>
        /// <param name="idfVersionStub">Версия боковика (если не указана, то используется та, что установлена для данного observation)</param>
        /// <param name="idfObservation">ID сущности (observation)</param>
        /// <param name="aformType">ID типа формы</param>
        /// <param name="idfsFormTemplate">Шаблон, который требуется использовать для показа данного А.К.</param>
        /// <param name="runImmediatly">Загружать шаблон немедленно, не обращая внимания на оптимизацию</param>
        /// <param name="isSummary">Для показа пустого Summary. Для рабоыт с настоящим summary используйте ShowSummary</param>
        public void ShowAggregateCase(AggregateCaseSection aggregateCaseType, long idfObservation, long? idfsFormTemplate, long? idfVersionStub, FFType aformType, bool runImmediatly, bool isSummary)
        {
            var observations = new List<long>(1) { idfObservation };
            var presetStubs = new List<AggregateCaseSection>(1) { aggregateCaseType };

            #region Определение шаблона

            //приоритеты: переданный -> из observation -> из детерминантов

            TemplateID = idfsFormTemplate;
            IsUNITemplate = false;

            if (!TemplateID.HasValue)
            {
                //выявляем idfsFormTemplate из таблицы Observations
                var observationsRow = MainDbService.LoadObservations(idfObservation);
                if ((observationsRow != null) && (!observationsRow.IsidfsFormTemplateNull()))
                    TemplateID = observationsRow.idfsFormTemplate;

                if (!TemplateID.HasValue)
                {
                    SetActualTemplate(EidssSiteContext.Instance.CountryID, null, aformType);
                }
            }

            #endregion

            //если никак не удалось вычислить шаблон, то выходим
            if ((TemplateID.HasValue) && (TemplateID > 0))
            {
                ShowFlexibleForm(TemplateID.Value, observations, aformType, presetStubs, idfVersionStub, runImmediatly, isSummary);
            }
        }

        /// <summary>
        /// Позволяет осуществлять операции группового ввода в набор обсерваций
        /// </summary>
        /// <param name="observations"></param>
        /// <param name="aformType"> </param>
        public void ShowFlexibleFormGroupEditing(List<long> observations, FFType aformType)
        {
            if (observations.Count == 0) return;
            var observationsRows = MainDbService.LoadObservations(observations);
            if (observationsRows.Length == 0) return;
            if (observationsRows[0].IsidfsFormTemplateNull()) return;
            var idTemplate = observationsRows[0].idfsFormTemplate;
            //во всех переданных обсервациях должны совпадать шаблоны
            if (observationsRows.Any(o => o.IsidfsFormTemplateNull() || !o.idfsFormTemplate.Equals(idTemplate))) return;
            observationsGroupEditing.AddRange(observations);
            ShowFlexibleForm(idTemplate, observations, aformType, null, null, true, false, false, true);
        }

        /// <summary>
        /// Хранилище обсерваций, которые используются для группового редактирования (одноимённый режим)
        /// </summary>
        private List<long> observationsGroupEditing { get; set; }

        /// <summary>
        /// Находится ли презентер в режиме группового редактирования
        /// </summary>
        public bool IsGroupEditingRegime { get; private set; }

        /// <summary>
        /// Отображает Flexible Form c данными, заполняя табличные секции предустановленными боковиками, по текущей стране
        /// </summary>
        /// <param name="observations">Коллекция ID сущностей (observation)</param>
        /// <param name="aformType">ID типа формы</param>
        public bool ShowSummary(List<long> observations, FFType aformType)
        {
            nowLoading = ffRender.NowLoadingTemplate = true;
            IsGroupEditingRegime = false;
            var isEmptySummary = observations.Count == 0;

            if (isEmptySummary)
            {
                SetActualTemplate(EidssSiteContext.Instance.CountryID, null, aformType);
                if (TemplateID == null) return false;
            }
            else
            {
                TemplateID = MainDbService.IdfsFormTemplateSummary;
                //обнуляем эти свойства, потому что в саммари участвует несколько Observation и у каждого может быть своя версия боковика и шаблона
                VersionMatrixStub = null;
            }

            ObservationID = MainDbService.IdfObservationSummary;

            //загружаем структуру
            var isOk = ffRender.MergeTemplates(MainDbService.IdfsFormTemplateSummary, observations, aformType);

            if (!isEmptySummary && isOk)
            {
                var observationsRows = MainDbService.LoadObservations(observations);

                //загружаем данные
                //загрузим пользовательские данные
                MainDbService.LoadUserData(observations);


                //надо рассчитать сумму данных и заложить её в фиктивный ObservationSummary, а затем показывать его
                //суммировать можно только те параметры, у которых тип Numeric. Остальные игнорировать (Михаил, 11.01.2010).
                //суммируется только тело таблицы, боковик не учитывается
                //в дальнейшем суммированные данные не сохраняются

                //расчёт summary
                MainDbService.CalculateSummary(observations);

                var listStubInfo = MainDbService.GetListSectionsAndVersionsForStub(observationsRows, aformType);
                foreach (var stubInfo in listStubInfo)
                {
                    //каждый грид табл.секции делаем нередактируемым
                    var sectionTable = GetSectionTable(stubInfo.IdfsSectionTable);
                    if (sectionTable == null) continue;
                    sectionTable.GridViewMain.OptionsBehavior.Editable = false;
                }
            }
            //определяем режим компонента
            ReadOnlyMode = true;

            //если не удалось загрузить шаблоны, то и постобработка не нужна
            if (isOk)
            {
                FlexibleFormsDS.PredefinedStubRow[] predefinedStubRows;
                //добавим данные боковика к пользовательским данным
                MainDbService.IncludeStubDataInUserData(TemplateID, ObservationID, null, out predefinedStubRows);

                //расставим значения по параметрам
                SetValuesToParameters(predefinedStubRows);
            }

            nowLoading = ffRender.NowLoadingTemplate = false;

            return isOk;
        }

        /// <summary>
        /// Выставляет активный шаблон
        /// </summary>
        /// <param name="countryDeterminant">Детерминант-страна</param>
        /// <param name="secondDeterminant">Детерминант диагноз или тест</param>
        /// <param name="aformType"></param>
        private void SetActualTemplate(long countryDeterminant, long? secondDeterminant, FFType aformType)
        {
            MainDbService.LoadActualTemplate(countryDeterminant, secondDeterminant, (long)aformType);
            if (MainDbService.MainDataSet.ActualTemplate.Rows.Count != 1) return;
            var row = (FlexibleFormsDS.ActualTemplateRow)MainDbService.MainDataSet.ActualTemplate.Rows[0];
            TemplateID = row.idfsFormTemplate;
            IsUNITemplate = row.IsUNITemplate;
            //если шаблон не найден, то он будет -1
            if (TemplateID == -1) TemplateID = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="secondDeterminant"></param>
        /// <param name="aformType"></param>
        /// <returns></returns>
        public long? GetActualTemplate(long? secondDeterminant, FFType aformType)
        {
            MainDbService.LoadActualTemplate(EidssSiteContext.Instance.CountryID, secondDeterminant, (long)aformType);
            if (MainDbService.MainDataSet.ActualTemplate.Rows.Count != 1) return null;
            var row = (FlexibleFormsDS.ActualTemplateRow)MainDbService.MainDataSet.ActualTemplate.Rows[0];
            return row.idfsFormTemplate;
        }

        /// <summary>
        /// Отображает Flexible Form c данными
        /// </summary>
        /// <param name="countryDeterminant">Детерминант-страна</param>
        /// <param name="secondDeterminant">Детерминант диагноз или тест</param>
        /// <param name="idfObservation">ID сущности (observation)</param>
        /// <param name="aformType">ID типа формы</param>
        /// <param name="bufferingUserData">Нужно ли каждый раз обращаться в БД за пользовательскими данными</param>
        public void ShowFlexibleForm(long countryDeterminant, long? secondDeterminant, long idfObservation, FFType aformType, bool bufferingUserData)
        {
            TemplateID = null;
            IsUNITemplate = null;

            SetActualTemplate(countryDeterminant, secondDeterminant, aformType);

            if (TemplateID.HasValue && (TemplateID > 0))
            {
                ShowFlexibleForm(TemplateID.Value, idfObservation, aformType, bufferingUserData);
            }
            else
            {
                ffRender.ClearTemplate();
            }
        }

        /// <summary>
        /// Копирование пользовательских данных
        /// </summary>
        public void Copy()
        {
            if ((TemplateID == null) || (ObservationID == null)) return;

            //производим наполнение буфера данных
            activityParametersBuffer.IdfsFormTemplate = TemplateID;
            activityParametersBuffer.IdfsObservation = ObservationID;
            activityParametersBuffer.UserDataBuffer = (FlexibleFormsDS.ActivityParametersRow[])MainDbService.MainDataSet.ActivityParameters.Select(DataHelper.Filter("idfObservation", ObservationID));
        }

        /// <summary>
        /// Можно ли производить вставку данных
        /// </summary>
        public bool CanPaste()
        {
            //если буфер пуст, то данные вставлять нельзя
            bool result = !activityParametersBuffer.IsEmpty();
            if (result)
            {
                //если один и тот же шаблон, то данные вставлять можно 
                result = (activityParametersBuffer.IdfsFormTemplate.Equals(TemplateID));
                //а если один и тот же Observation, то нельзя (это вызовет ошибку)
                if (result)
                {
                    result = !activityParametersBuffer.IdfsObservation.Equals(ObservationID);
                }
            }

            return result;
        }

        /// <summary>
        /// Вставка пользовательских данных
        /// </summary>
        public void Paste()
        {
            if (!CanPaste()) return;

            if (ObservationID == null) return;
            if (activityParametersBuffer.UserDataBuffer.Length == 0) return;

            //предварительно очистим все данные, которые могли быть у observation, в который вставляются данные
            ClearUserData(ObservationID.Value);

            //для всех строк пользовательских данных, помещённых в буфер, создадим их копии
            CopyHelper.CopyActivityParameters(MainDbService, ObservationID.Value, activityParametersBuffer.UserDataBuffer);

            //отобразим вставленные данные в контролах
            SetValuesToParameters(null);
        }

        /// <summary>
        /// Очистка данных формы
        /// </summary>
        public void Clear()
        {
            if ((MainDbService.MainDataSet.ActivityParameters.Count == 0) || !ObservationID.HasValue) return;
            //если буфер копирования заполнен данными с данной формы и observation, то их также требуется очистить
            if (!activityParametersBuffer.IsEmpty() && (ObservationID.Equals(activityParametersBuffer.IdfsObservation)))
            {
                activityParametersBuffer.Clear();
            }
            //очищаем данные с формы
            for (var i = MainDbService.MainDataSet.ActivityParameters.Count - 1; i >= 0; i--)
            {
                DeleteValueRow(MainDbService.MainDataSet.ActivityParameters[i], ObservationID.Value);
            }
        }

        /// <summary>
        /// Очистка шаблона
        /// </summary>
        public void ClearTemplate()
        {
            ffRender.ClearTemplate();
        }

        /// <summary>
        /// Удаление данных только динамических параметров
        /// </summary>
        private void ClearUserDataOfDinamicParameters()
        {
            if ((MainDbService.MainDataSet.ActivityParameters.Count == 0) || (ObservationID == null)) return;
            for (var i = MainDbService.MainDataSet.ActivityParameters.Count - 1; i >= 0; i--)
            {
                var activityParametersRow = MainDbService.MainDataSet.ActivityParameters[i];
                if (!activityParametersRow.IsRowAlive()) continue;

                var parameterTemplateRow = MainDbService.GetParameterTemplateRow(activityParametersRow.idfsParameter, activityParametersRow.idfsFormTemplate);
                if (parameterTemplateRow == null) continue;
                if (!parameterTemplateRow.blnDynamicParameter) continue;

                //удаляем пользовательские данные
                DeleteValueRow(activityParametersRow, ObservationID.Value);

                //удаляем сам контрол
                var parameter = ffRender.ParameterList[parameterTemplateRow.idfsParameter];
                parameter.Delete();
            }

            //скрываем панель с динамическими параметрами
            ffRender.SetVisibleDynamicParametersGroupControl(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="idfsObservation"></param>
        private void DeleteValueRow(FlexibleFormsDS.ActivityParametersRow row, long? idfsObservation)
        {
            if (!row.IsRowAlive()) return;
            if ((idfsObservation != null) && (!row.idfObservation.Equals(idfsObservation))) return;
            //очищаем контрол
            if (ffRender.ParameterList.ContainsKey(row.idfsParameter))
            {
                var parameter = ffRender.ParameterList[row.idfsParameter];
                if (parameter != null) parameter.ControlParameter.EditValue = null;
            }
            row.SetvarValueNull();
            row.intRowState = 1; //удаляем таким образом
        }

        /// <summary>
        /// Очистка данных формы (полностью удаляются все данные)
        /// </summary>
        public void ClearUserData()
        {
            ClearUserData(null);
        }

        /// <summary>
        /// Очистка данных формы (по указанному observation)
        /// </summary>
        public void ClearUserData(long? idfsObservation)
        {
            if (MainDbService.MainDataSet.ActivityParameters.Count == 0) return;
            for (var i = MainDbService.MainDataSet.ActivityParameters.Count - 1; i >= 0; i--)
            {
                DeleteValueRow(MainDbService.MainDataSet.ActivityParameters[i], idfsObservation);
            }
        }


        /// <summary>
        /// Отображает  Flexible Form c данными по второму детерминанту (первый -- страна)
        /// </summary>
        /// <param name="diagnosisID">ID диагноза</param>
        /// <param name="idfObservation">ID сущности (observation)</param>
        /// <param name="aformType">ID типа формы</param>
        public void ShowFlexibleFormByDeterminant(long diagnosisID, long idfObservation, FFType aformType)
        {
            ShowFlexibleFormByDeterminant(diagnosisID, idfObservation, aformType, true);
        }

        /// <summary>
        /// Отображает  Flexible Form c данными по второму детерминанту (первый -- страна)
        /// </summary>
        /// <param name="diagnosisID">ID диагноза</param>
        /// <param name="idfObservation">ID сущности (observation)</param>
        /// <param name="aformType">ID типа формы</param>
        /// <param name="bufferingUserData"></param>
        public void ShowFlexibleFormByDeterminant(long diagnosisID, long idfObservation, FFType aformType, bool bufferingUserData)
        {
            TemplateID = null;
            IsUNITemplate = null;

            SetActualTemplate(EidssSiteContext.Instance.CountryID, diagnosisID, aformType);

            if (TemplateID.HasValue && (TemplateID > 0))
            {
                ShowFlexibleForm(TemplateID.Value, idfObservation, aformType, bufferingUserData);
            }
            else
            {
                ffRender.ClearTemplate();
            }
        }

        private long? m_ObservationID;

        /// <summary>
        /// idfsFormTemplate, который отображает данный компонент
        /// </summary>
        public long? TemplateID { get; private set; }

        /// <summary>
        /// Тип формы, с которым работает данный компонент
        /// </summary>
        public FlexibleFormsDS.FormTypesRow FormTypeRow { get; private set; }

        /// <summary>
        /// idfVersion шаблона, который используется в данный момент. Применяется только для Aggregate Case.
        /// </summary>
        public long? VersionMatrixStub { get; private set; }

        /// <summary>
        /// idfObservation, который отображает данный компонент
        /// </summary>
        public long? ObservationID
        {
            get { return m_ObservationID; }
            private set
            {
                m_ObservationID = value;
                if (m_ObservationID.HasValue && TemplateID.HasValue)
                {
                    if (!observationsDictionary.ContainsKey(m_ObservationID.Value))
                    {
                        observationsDictionary.Add(m_ObservationID.Value, TemplateID.Value);
                    }
                    else if (!observationsDictionary[m_ObservationID.Value].Equals(TemplateID.Value))
                    {
                        observationsDictionary[m_ObservationID.Value] = TemplateID.Value;
                    }

                }
            }
        }

        /// <summary>
        /// Хранилище пар observarionID-idfsFormTemplate, которые загружались во время работы данного FFPresenter
        /// </summary>
        private Dictionary<long, long> observationsDictionary { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool HasChanges()
        {
            //проверим, поменялось ли что-нибудь
            var result = ReadOnlyMode;
            if (!result)
            {
                var dataTable = (FlexibleFormsDS.ActivityParametersDataTable)MainDbService.MainDataSet.ActivityParameters.GetChanges();
                if (dataTable != null)
                {
                    foreach (var row in dataTable)
                    {
                        if (!row.IsRowAlive() || (row.intRowState == 1))
                        {
                            result = true;
                            break;
                        }
                        //проверим, является ли параметр, к которому относится данная строка, частью боковика. Если да, то эти изменения не считаются, потому что они служебные.
                        var parameterTemplateRow = MainDbService.GetParameterTemplateRow(row.idfsParameter, row.idfsFormTemplate);
                        //определим секцию, в которой находится параметр
                        if (parameterTemplateRow == null) continue;
                        //нужно ли проверять порядок сортировки параметра (актуально во время сохранения данных табличной секции, чтобы не сохранялись данные из боковика)
                        var needCheckOrder = false;
                        if (!parameterTemplateRow.IsidfsSectionNull())
                        {
                            //определим, является ли родительская секция табличной
                            var sectionsRow = MainDbService.GetSectionRow(parameterTemplateRow.idfsSection);
                            needCheckOrder = sectionsRow.blnGrid;
                        }
                        if (!needCheckOrder || (parameterTemplateRow.intOrder >= 0))
                        {
                            result = true;
                            break;
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Проверим данные
        /// </summary>
        /// <returns></returns>
        public override bool ValidateData()
        {
            //вызовем проверку правил
            //(выполняем для всех параметров)
            if (!RulesCheck(null, FFRuleCheckPointType.OnSaveWithNotify) ||
                !RulesCheck(null, FFRuleCheckPointType.OnSaveWithError)) return false;

            if (TemplateID.HasValue && !ReadOnly)
            {
                #region Проверка обязательных полей

                FlexibleFormsDS.ParameterTemplateRow parameterTemplateRow;
                if (!MainDbService.CheckMandatoryParameters(observationsDictionary, out parameterTemplateRow) && (parameterTemplateRow != null))
                {
                    //отыскиваем параметр, на который нужно встать (он может быть и в другой форме, которая сейчас не визуализирована, тогда не встаем)
                    if (ffRender.ParameterList.ContainsKey(parameterTemplateRow.idfsParameter))
                    {
                        var parameter = ffRender.ParameterList[parameterTemplateRow.idfsParameter];
                        ShowErrorAtValidateMandatoryFields(parameter, parameter.Text);
                        return false;
                    }
                }

                /*
                foreach (KeyValuePair<long, Parameter> pair in ffRender.ParameterList)
                {
                    Parameter parameter = pair.Value;
                    FlexibleFormsDS.ParameterTemplateRow parameterTemplateRow = parameter.ParameterTemplateRow;
                    if (parameterTemplateRow == null) continue;
                    //выберем обязательные поля и проверим по ним данные вне зависимости от шаблона
                    //не проверяем те параметры, которые не входят в текущий шаблон
                    if (parameterTemplateRow.idfsFormTemplate.Equals(TemplateID.Value) && parameter.IsMandatoryFieldEmpty())
                    {
                        ShowErrorAtValidateMandatoryFields(parameter, parameter.Text);
                        return false;
                    }
                }
                */

                #endregion
            }

            return base.ValidateData();
        }

        /// <summary>
        /// Данные, входящие в активный шаблон
        /// </summary>
        public FlexibleFormsDS.ActivityParametersDataTable ActivityParameters
        {
            get { return MainDbService.MainDataSet.ActivityParameters; }
        }

        /// <summary>
        /// Параметры, входящие в активный шаблон
        /// </summary>
        public FlexibleFormsDS.ParameterTemplateDataTable ParameterTemplate
        {
            get { return MainDbService.MainDataSet.ParameterTemplate; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnVisibleChanged(object sender, EventArgs e)
        {
            //если презентер стал виден и были сохранены параметры для отложенной загрузки, то выполним загрузку
            if (!Visible || !DelayedLoadingNeeded) return;
            ShowFlexibleForm(m_IdfsFormTemplateStored, m_ObservationsStored, m_FormTypeStored, m_PresetStubsStored, m_IdfVersionStored, false, false);
        }

        /// <summary>
        /// Добавление динамического параметра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnAddParameterItemClick(object sender, ItemClickEventArgs e)
        {
            if (!TemplateID.HasValue || (FormTypeRow == null)) return;
            if (!FormTypeRow.IsRowAlive()) return;

            //выбор параметра
            var form = new FFTreeParameterForTemplate(MainDbService, FormTypeRow, ffRender.ParameterList);
            BaseFormManager.ShowModal(form, FindForm());

            if (!form.SelectedParameter.HasValue) return;

            var idfsParameter = form.SelectedParameter.Value;
            var parametersRow = MainDbService.GetParameterRow(idfsParameter);
            //покажем панель динамических параметров, если она ещё не видна
            ffRender.ShowDynamicParametersGroupControl(TemplateID.Value);
            //добавим выбранный параметр на неё
            ffRender.CreateParameterInParameterDynamicParametersGroupControl(parametersRow, TemplateID.Value);
        }

        /// <summary>
        /// Удаление динамического параметра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnRemoveAllDynamicParameterItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ClearUserDataOfDinamicParameters();
        }

        /// <summary>
        /// Проверка возможности удаления пресета
        /// </summary>
        /// <param name="idfsFormTemplate"></param>
        /// <returns></returns>
        private bool TemplateHasMandatoryFields(long idfsFormTemplate)
        {
            bool result = true;

            string commandText = String.Format("Select [Result] from dbo.fnFFTemplateHasMandatoryFields({0})", idfsFormTemplate);
            var cmd = DbService.CreateCommand(commandText);
            ErrorMessage errMsg = null;
            var o = BaseDbService.ExecScalar(cmd, DbService.Connection, ref errMsg);
            //
            if (o is bool)
            {
                result = Convert.ToBoolean(o);
            }

            return result;
        }

        /// <summary>
        /// Показывать ли заголовки у табличных секций загруженного шаблона
        /// </summary>
        public bool SectionTableCaptionsIsVisible
        {
            get { return ffRender != null ? ffRender.SectionTableCaptionsIsVisible : true; }
            set { if (ffRender != null) ffRender.SectionTableCaptionsIsVisible = value; }
        }
    }
}
