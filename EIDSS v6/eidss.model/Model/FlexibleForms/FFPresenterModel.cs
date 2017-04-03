using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using BLToolkit.DataAccess;
using BLToolkit.EditableObjects;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.model.Model.Extenders;
using bv.model.Model.Validators;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.FlexibleForms.Helpers;
using eidss.model.Model.FlexibleForms.FlexNodes;
using System.Collections.Specialized;
using eidss.model.Model.FlexibleForms.Helpers;
using DataException = BLToolkit.Data.DataException;

namespace eidss.model.Schema
{
    public sealed class FFPresenterModel :
        EditableObject<FFPresenterModel>
        , IObject
        , IDisposable
    {
        internal const string _str_CurrentObservation = "CurrentObservation";

        public Template CurrentTemplate { get; set; }

        public long? CurrentObservation { get; set; }
        
        /// <summary>
        /// Дополнительные настройки
        /// </summary>
        public FFSettings Settings { get; set; }

        public bool DynamicParameterEnabled { get; set; }

        /// <summary>
        /// Пользовательские данные (единое хранилище)
        /// </summary>
        public EditableList<ActivityParameter> ActivityParameters { get; set; }

        /// <summary>
        /// Матрица версий для агрегатных форм
        /// </summary>
        public EditableList<AggregateMatrixVersionLookup> AggregateMatrixVersions { get; set; }

        /// <summary>
        /// Перечень всех обсерваций, которые используются для показа данной FF (требуется для режима Summary)
        /// </summary>
        public List<long> Observations { get; set; }

        /// <summary>
        /// Содержимое боковика (перечень строк боковика)
        /// </summary>
        public List<PredefinedStub> PredefinedStubRows { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public FFPresenterModel()
        {
            Init();
        }

        /// <summary>
        /// 
        /// </summary>
        public FFPresenterModel(long formType)
        {
            FormType = formType;
            Init();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Init()
        {
            ParameterList = new List<ParameterTemplate>();
            SectionList = new List<SectionTemplate>();
            ActivityParameters = new EditableList<ActivityParameter>();
            Observations = new List<long>();
            Settings = new FFSettings {WindowMode = true};
            AggregateMatrixVersions = new EditableList<AggregateMatrixVersionLookup>();
        }

        [XmlIgnore]
        public IObject Parent
        {
            get { return m_Parent; }
            set { m_Parent = value; OnPropertyChanged("Parent"); }
        }
        private IObject m_Parent;

        public IObject CloneWithSetup(DbManagerProxy manager, bool bRestricted = false)
        {
            var ret = Clone() as FFPresenterModel;
            if (ret == null) return null;
            ret.Init();
            ret.m_Parent = Parent;
            ret.m_ObjectName = m_ObjectName;

            if (!bRestricted)
            {
                ret.ParameterList.AddRange(ParameterList.Select(c => c.CloneWithSetup(manager, bRestricted) as ParameterTemplate).ToList());
                ret.SectionList.AddRange(SectionList.Select(c => c.CloneWithSetup(manager, bRestricted) as SectionTemplate).ToList());
                ret.ActivityParameters.AddRange(ActivityParameters.Select(c => c.CloneWithSetup(manager, bRestricted) as ActivityParameter).ToList());
                ret.Observations.AddRange(Observations);
                ret.AggregateMatrixVersions.AddRange(AggregateMatrixVersions.Select(c => c.CloneWithSetup(manager, bRestricted) as AggregateMatrixVersionLookup).ToList());
            }

            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsSummary { get; set; }

        /// <summary>
        /// Тип формы
        /// </summary>
        public long FormType { get; set; }

        /// <summary>
        /// Содержит перечень отрендеренных параметров
        /// </summary>
        public List<ParameterTemplate> ParameterList { get; set; }

        /// <summary>
        /// Содержит перечень отрендеренных секций
        /// </summary>
        public List<SectionTemplate> SectionList { get; set; }

        [XmlIgnore]
        public FlexNode TemplateFlexNode { get; set; }

        /// <summary>
        /// Фейковый ID для summary-режима
        /// </summary>
        public long IdfObservationSummary{get{ return 0; }}

        /// <summary>
        /// 
        /// </summary>
        public void SetProperties(Template template, long idfObservation, long rootKeyID)
        {
            SetProperties(template, new List<long> { idfObservation }, rootKeyID);
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetProperties(Template template, long rootKeyID)
        {
            SetProperties(template, null, rootKeyID);
        }

        public void SetProperties(long idfsFormTemplate, long rootKeyID)
        {
            SetProperties(LoadActualTemplate(idfsFormTemplate), null, rootKeyID);
        }

        /// <summary>
        /// 
        /// </summary>
        public void RefreshPresetStub(AggregateCaseSectionEnum matrixID, string versionList)
        {
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                PredefinedStubRows = PredefinedStub.Accessor.Instance(null).SelectList(manager, (long)matrixID, versionList, null); // TODO idfsFormTemplate
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void RefreshAggregateMatrixVersion()
        {
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                AggregateMatrixVersions.AddRange(AggregateMatrixVersionLookup.Accessor.Instance(null).SelectLookupList(manager, null));
            }
        }

        /// <summary>
        /// Подготавливает модель к показу аггрегатного случая
        /// </summary>
        /// <param name="matrixID"></param>
        /// <param name="idfVersion"></param>
        public void PrepareAggregateCase(AggregateCaseSectionEnum matrixID, long idfVersion)
        {
            RefreshPresetStub(matrixID, idfVersion.ToString());
            IncludeStubDataInUserData();
            //пересчитываем node шаблона с учётом боковика
            RebuildTemplateFlexNode();
        }

        /// <summary>
        /// ID фиктивного Form Template, который содержит слитую (merged) структуру по всем Observation, которые входят в сводный отчёт
        /// </summary>
        public long IdfsFormTemplateSummary{get { return 0; }}

        /// <summary>
        /// Подготавливает модель для показа сводных данных по кейсам (summary)
        /// </summary>
        /// <param name="observations"></param>
        public void PrepareSummary(List<long> observations)
        {
            IsSummary = true;
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var accTemplate = Template.Accessor.Instance(null);
                //выставляем в фиктивные значения
                CurrentTemplate = accTemplate.CreateNewT(manager, this);
                CurrentTemplate.idfsFormTemplate = IdfsFormTemplateSummary;
                CurrentTemplate.idfsFormType = Schema.FormType.Accessor.Instance(null).SelectByKey(manager, FormType).idfsFormType;
                CurrentObservation = IdfObservationSummary;
                Observations = observations;

                //если нет ни одной обсервации, то показываем агрегатный шаблон для данного типа формы
                if (observations.Count == 0)
                {
                    #region Вычисляем параметры для агрегатного кейса

                    var matrix = AggregateCaseSectionEnum.Unknown;
                    var ffType = FFTypeEnum.None;
                    switch (CurrentTemplate.idfsFormType)
                    {
                        case (long)FFTypeEnum.HumanAggregateCase:
                            matrix = AggregateCaseSectionEnum.HumanCase;
                            ffType = FFTypeEnum.HumanAggregateCase;
                            break;
                        case (long)FFTypeEnum.VetAggregateCase:
                            matrix = AggregateCaseSectionEnum.VetCase;
                            ffType = FFTypeEnum.VetAggregateCase;
                            break;
                        case (long)FFTypeEnum.VetEpizooticAction:
                            matrix = AggregateCaseSectionEnum.SanitaryAction;
                            ffType = FFTypeEnum.VetEpizooticAction;
                            break;
                        case (long)FFTypeEnum.VetEpizooticActionDiagnosisInv:
                            matrix = AggregateCaseSectionEnum.DiagnosticAction;
                            ffType = FFTypeEnum.VetEpizooticActionDiagnosisInv;
                            break;
                        case (long)FFTypeEnum.VetEpizooticActionTreatment:
                            matrix = AggregateCaseSectionEnum.ProphylacticAction;
                            ffType = FFTypeEnum.VetEpizooticActionTreatment;
                            break;
                    }
                    
                    //загружаем нужный шаблон
                    CurrentTemplate = LoadActualTemplate(EidssSiteContext.Instance.CountryID, 0, ffType);
                    //по матрице определяем версию
                    RefreshAggregateMatrixVersion();
                    long idfVersion = 0;
                    var lp = AggregateMatrixVersions.FirstOrDefault(m => (m.idfsAggrCaseSection == (long)matrix) && (m.intState == 2));
                    if (lp != null) idfVersion = lp.idfVersion;

                    #endregion

                    PrepareAggregateCase(matrix, idfVersion);
                }
                else
                {
                    #region Загрузка шаблонов

                    //загружаем шаблоны по всем обсервациям и помещаем их в текущий шаблон
                    var observObjs = Observation.Accessor.Instance(null).SelectList(manager,
                                                                                    Observations.GetObservations());
                    foreach (var observation in observObjs)
                    {
                        if (!observation.idfsFormTemplate.HasValue) continue;
                        var template = accTemplate.SelectByKey(manager, observation.idfsFormTemplate.Value, FormType);
                        if (template == null) continue;

                        foreach (var sectionTemplate in template.SectionTemplates)
                        {
                            var idSection = sectionTemplate.idfsSection;
                            if (CurrentTemplate.SectionTemplates.Count(s => s.idfsSection == idSection) == 0) CurrentTemplate.SectionTemplates.Add(sectionTemplate);
                        }
                        foreach (var parameterTemplate in template.ParameterTemplates)
                        {
                            //нечисловые параметры не участвуют в summary
                            if (!parameterTemplate.IsParameterNumeric()) continue;
                            var idParameter = parameterTemplate.idfsParameter;
                            if (CurrentTemplate.ParameterTemplates.Count(s => s.idfsParameter == idParameter) == 0) CurrentTemplate.ParameterTemplates.Add(parameterTemplate);
                        }
                    }

                    #endregion

                    #region Загрузка боковиков

                    var matrixID = AggregateCaseSectionEnum.HumanCase;
                    switch (FormType)
                    {
                        case (long) FFTypeEnum.HumanAggregateCase:
                            matrixID = AggregateCaseSectionEnum.HumanCase;
                            break;
                        case (long) FFTypeEnum.VetAggregateCase:
                            matrixID = AggregateCaseSectionEnum.VetCase;
                            break;
                        case (long) FFTypeEnum.VetEpizooticAction:
                            matrixID = AggregateCaseSectionEnum.SanitaryAction;
                            break;
                        case (long) FFTypeEnum.VetEpizooticActionDiagnosisInv:
                            matrixID = AggregateCaseSectionEnum.DiagnosticAction;
                            break;
                        case (long) FFTypeEnum.VetEpizooticActionTreatment:
                            matrixID = AggregateCaseSectionEnum.ProphylacticAction;
                            break;
                    }

                    var versions = new StringBuilder();
                    foreach (var observation in Observations)
                    {
                        var version = LoadObservationVersion(observation);
                        if (!version.HasValue) continue; //version = 3021340000000;
                        if (!versions.ToString().Contains(version.Value.ToString()))
                            versions.AppendFormat("{0};", version);
                    }

                    RefreshPresetStub(matrixID, versions.ToString());
                    IncludeStubDataInUserData();

                    #endregion

                    #region Загружаем и считаем данные
                    
                    var idfRows = new List<long>();
                    foreach (var row in PredefinedStubRows)
                    {
                        if (!row.idfRow.HasValue) continue;
                        if (!idfRows.Contains(row.idfRow.Value)) idfRows.Add(row.idfRow.Value);
                    }

                    var apAll = ActivityParameters.LoadActivityParameters(Observations, false);
                    foreach (var parameter in CurrentTemplate.ParameterTemplates)
                    {
                        if (!parameter.IsParameterNumeric()) continue;
                        var idParameter = parameter.idfsParameter;
                        foreach (var idfRow in idfRows)
                        {
                            var idRow = idfRow;
                            var activityParameters = apAll.Where
                                (
                                    ap =>
                                    (ap.idfObservation != IdfObservationSummary)
                                    && (ap.idfsParameter == idParameter)
                                    && (ap.idfRow == idRow)
                                ).ToList();
                            if (activityParameters.Count == 0) continue;
                            double summ = 0;
                            foreach (var activityParameter in activityParameters)
                            {
                                double value;
                                if (Double.TryParse(activityParameter.varValue.ToString(), out value)) summ += value;
                            }
                            //находим номер строки по id строки
                            var row = ActivityParameters.FirstOrDefault(ap => ap.idfRow == idRow);
                            if (row == null) continue;
                            if (!row.intNumRow.HasValue) continue;
                            ActivityParameters.SetActivityParameterValue(CurrentTemplate, CurrentObservation.Value
                                                                         , idParameter, idfRow, row.intNumRow.Value, summ,
                                                                         String.Empty);
                        }
                    }
                    

                    #endregion

                    //пересчитываем node шаблона с учётом боковика
                    RebuildTemplateFlexNode();
                }
            }
        }

        /// <summary>
        /// Помещает в таблицу пользовательских данных данные боковика
        /// </summary>
        public void IncludeStubDataInUserData()
        {
            if (!CurrentObservation.HasValue) return;

            //TODO удалять данные боковика
            //очистим старый боковик (на случай смены версии боковика в одном сеансе работы для одного observation
            /*
            mainDbService.DeleteStubData(templateID.Value, observationID.Value);
            predefinedStubRows =
                versionMatrixStub.HasValue
                    ? mainDbService.GetPredefinedStubRows(versionMatrixStub.Value)
                    : (FlexibleFormsDS.PredefinedStubRow[])mainDbService.MainDataSet.PredefinedStub.Select();
            */
            
            //данные по боковику уже должны быть загружены, поскольку по ним он визуализировался
            foreach (var predefinedStubRow in PredefinedStubRows)
            {
                if (!predefinedStubRow.idfsParameter.HasValue) continue;
                if (!predefinedStubRow.idfRow.HasValue) continue;
                if (!predefinedStubRow.NumRow.HasValue) continue;

                //TODO сделать перенумеровку
                //перенумеруем строки данных в соответствии с новыми номерами строк боковика
                //это на случай, если данные уже были загружены и пронумерованы, а потом изменился боковик
                //mainDbService.MainDataSet.ActivityParameters.RenumActivityParameters(predefinedStubRow, observationID.Value);

                //выставляем загруженным пользовательским данным тот же номер строки, что у соответствующей строки боковика
                foreach (var ap in ActivityParameters)
                {
                    if (ap.idfRow == predefinedStubRow.idfRow) ap.intNumRow = predefinedStubRow.NumRow;
                }

                //выставим данные по боковику
                ActivityParameters.SetActivityParameterValue(
                    CurrentTemplate
                    , CurrentObservation.Value
                    , predefinedStubRow.idfsParameter.Value
                    , predefinedStubRow.idfRow.Value
                    , predefinedStubRow.NumRow.Value
                    , predefinedStubRow.idfsParameterValue
                    , predefinedStubRow.strNameValue
                    );
            }

            ActivityParameters.AcceptChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetProperties(Template template, List<long> observations, long rootKeyID)
        {
            if (template == null) return;
            CurrentTemplate = template;
            CurrentTemplate.RootKeyID = rootKeyID;
            if (observations != null)
            {
                Observations = observations;
                if (observations.Count == 1)
                {
                    CurrentObservation = Observations[0];
                }
                else if (observations.Count > 1)
                {
                    CurrentObservation = IdfObservationSummary;
                }
                ActivityParameters.LoadActivityParameters(observations, true);
            }

            //для саммари бизнес-правила не работают
            if (CurrentObservation.HasValue)
            {
                #region Проверка бизнес-правил

                List<Rule> executedRules;
                List<Rule> enablingRules;

                //правила с запретом сохранять данные
                var rules =
                    CurrentTemplate.Rules.Where(
                        c =>
                        c.idfsCheckPoint.HasValue &&
                        (c.idfsCheckPoint.Value == (long)FFRuleCheckPointType.OnLoad)).ToList();
                CurrentTemplate.RulesCheckRoutines(rules, this, out executedRules, out enablingRules);
                //разблокировочные правила тут не учитываются
                //TODO определиться, надо ли показывать сообщения при загрузке
                foreach (var rule in executedRules)
                {
                    foreach (var action in rule.Actions)
                    {
                        var needClear = action.idfsRuleAction == (long)FFRuleActions.Clear;
                        var needDisable = action.idfsRuleAction == (long)FFRuleActions.Disabled;
                        //TODO а нужны ли тут каскады? Или в реальности применяются только блокирующие правила?
                        if (needClear)
                        {
                            ActivityParameters.SetActivityParameterValue(CurrentTemplate, CurrentObservation.Value, action.idfsParameter, null);
                        }
                        else if (needDisable)
                        {
                            var parameter = CurrentTemplate.ParameterTemplates.FirstOrDefault(c => c.idfsParameter == action.idfsParameter);
                            if (parameter != null) parameter.ReadOnly = true;
                        }
                    }
                }

                #endregion
            }

            TemplateFlexNode = template.CreateFlexNodeForTemplate(CurrentObservation, ActivityParameters, PredefinedStubRows, this);
            RefreshParameterList();
        }
        
        public void RebuildTemplateFlexNode()
        {
            if (CurrentTemplate != null)
                TemplateFlexNode = CurrentTemplate.CreateFlexNodeForTemplate(CurrentObservation, ActivityParameters, PredefinedStubRows, this);
        }

        public void SetProperties(long countryDeterminant, long? secondDeterminant, FFTypeEnum ffType, long idObservation, long rootKeyID)
        {
            SetProperties(countryDeterminant, secondDeterminant, ffType, new List<long> { idObservation }, rootKeyID);
        }
        
        public void SetProperties(long countryDeterminant, long? secondDeterminant, FFTypeEnum ffType, List<long> observations, long rootKeyID)
        {
            SetProperties(LoadActualTemplate(countryDeterminant, secondDeterminant, ffType), observations, rootKeyID);
        }
       
        public static Template LoadActualTemplate(long idfsFormTemplate)
        {
            Template template;

            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var acc = Template.Accessor.Instance(null);
                template = acc.SelectByKey(manager, idfsFormTemplate, null);
            }

            return template;
        }

        /// <summary>
        /// Получает сведения о матрице боковика
        /// </summary>
        /// <param name="idfObservation"></param>
        /// <returns></returns>
        public static long? LoadObservationVersion(long idfObservation)
        {
            long? result;

            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                result = manager.SetSpCommand("dbo.spAggregateObservation_GetMatrixVersion"
                    , manager.Parameter("idfObservation", idfObservation)
                    ).ExecuteScalar<long?>();
            }

            return result;
        }

        /// <summary>
        /// Получает сведения о шаблоне, который связан с данной обсервацией
        /// </summary>
        /// <param name="idfObservation"></param>
        /// <returns></returns>
        public static Template LoadTemplate(long idfObservation)
        {
            Template template = null;

            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var table = manager.SetSpCommand("dbo.spFFGetObservations"
                    , manager.Parameter("observationList", idfObservation.ToString())
                    ).ExecuteDataTable();
                foreach (DataRow row in table.Rows)
                {
                    if (row ["idfObservation"].ToString().Equals(idfObservation.ToString()))
                    {
                        var idTemplate = row["idfsFormTemplate"];
                        if (idTemplate is long) template = LoadActualTemplate(Convert.ToInt64(idTemplate));
                    }
                }
            }

            return template;
        }

        /// <summary>
        /// Имеется ли в загруженном шаблоне хотя бы одна табличная секция
        /// </summary>
        /// <returns></returns>
        public bool HasSectionTable()
        {
            var result = false;
            if (CurrentTemplate != null)
            {
                result = CurrentTemplate.SectionTemplates.Any(s => s.blnGrid);
            }

            return result;
        }

        /// <summary>
        /// Сохраняет обсервацию в БД (использовать только для тестов!)
        /// </summary>
        public void SaveObservation()
        {
            if (!CurrentObservation.HasValue) return;
            if (CurrentTemplate == null) return;

            SaveObservation(CurrentObservation.Value, CurrentTemplate.idfsFormTemplate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idfObservation"></param>
        /// <param name="idfsFormTemplate"></param>
        public void SaveObservation(long idfObservation, long idfsFormTemplate)
        {
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                manager.SetSpCommand("dbo.spObservation_Post"
                                     , manager.Parameter("idfObservation", idfObservation)
                                     , manager.Parameter("idfsFormTemplate", idfsFormTemplate)
                    ).ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="countryDeterminant"></param>
        /// <param name="secondDeterminant"></param>
        /// <param name="ffType"></param>
        /// <returns></returns>
        public static Template LoadActualTemplate(long countryDeterminant, long? secondDeterminant, FFTypeEnum ffType)
        {
            //TODO может быть вынести в отдельный хелпер

            Template template = null;

            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var idfsFormTemplate = manager.SetSpCommand("dbo.spFFGetActualTemplate"
                                                            , manager.Parameter("idfsGISBaseReference", countryDeterminant)
                                                            , secondDeterminant.HasValue ? manager.Parameter("idfsBaseReference", secondDeterminant.Value) : null
                                                            , manager.Parameter("idfsFormType", ffType)
                    ).ExecuteScalar<long?>();
                
                if (idfsFormTemplate != null)
                {
                    template = LoadActualTemplate(idfsFormTemplate.Value);
                }
            }

            return template;
        }

        /// <summary>
        /// Производит очистку пользовательских данных
        /// </summary>
        /// <param name="idfObservation"></param>
        public void Clear(long idfObservation)
        {
            if (ActivityParameters.Count(ap => ap.idfObservation == idfObservation) == 0) return;
            for(var i = ActivityParameters.Count - 1; i >= 0; i--)
            {
                var ap = ActivityParameters[i];
                if (ap.idfObservation != idfObservation) continue;
                ActivityParameters.Remove(ap);
            }
        }

        public void DeleteDynamicParametersNode()
        {
            DeleteDynamicParametersNodeRoutines(TemplateFlexNode);
        }

        public void AddDynamicParameterNode(Parameter parameter, long idfObservation, EditableList<ActivityParameter> activityParameters)
        {
            //отыскиваем секцию с динамическими параметрами
            var dynamicSectNode = GetDynamicSectionNode(TemplateFlexNode);
            if (dynamicSectNode == null) return;
            //создаём нод и размещаем последним в этой секции
            var ap = activityParameters.FirstOrDefault(c => c.idfsParameter == parameter.idfsParameter);
            if ((ap != null) && ap.idfsFormTemplate.HasValue)
            {
                ap.IsDynamicParameter = true;
                var dp = FFHelper.CreateDeletedParameter(parameter, idfObservation, ap.idfsFormTemplate.Value);
                var order = dynamicSectNode.ChildListCount + 1;
                var node = dynamicSectNode.Add(dp, activityParameters, this);
                node.FormKey = dynamicSectNode.FormKey;
                node.Order = order;
            }
        }

        private FlexNode GetDynamicSectionNode(FlexNode parentNode)
        {
            if (parentNode.IsString()) return parentNode;
            foreach (var node in parentNode.ChildList)
            {
                var sn = GetDynamicSectionNode(node);
                if (sn != null) return sn;
            }
            return null;
        }

        private void DeleteDynamicParametersNodeRoutines(FlexNode parentNode)
        {
            foreach (var node in parentNode.ChildList)
            {
                DeleteDynamicParametersNodeRoutines(node);
            }
            var nodes = parentNode.ChildList.Where(c => (c.IsString() && !DynamicParameterEnabled) || c.IsParametersDeletedFromTemplate()).ToList();
            for (var i = nodes.Count - 1; i >= 0; i--)
            {
                parentNode.DeleteNode(nodes[i]);
            }
        }

        /// <summary>
        /// Удаление строки данных
        /// </summary>
        /// <param name="idfRow"></param>
        public void RemoveRow(long idfRow)
        {
            if ((CurrentTemplate != null)
                && (CurrentObservation.HasValue)
                && (ActivityParameters != null)
                )
            {
                for (var i = ActivityParameters.Count - 1; i >= 0; i--)
                {
                    var ap = ActivityParameters[i];
                    if (ap.IsMarkedToDelete) continue;
                    if (ap.idfRow.Equals(idfRow))
                    {
                        ap.MarkToDelete();
                        //TODO убрать, когда исправится движок и будет нормально ловить HasChanges
                        ap.IncreaseFakeField();
                    }
                }
                //TODO пересчитать у оставшихся номера строк. См. desktop версию
            }
        }

        /// <summary>
        /// Копирование строки данных
        /// </summary>
        /// <param name="idfsSection">Корневая секция-таблица, к которой принадлежит строка-основа</param>
        /// <param name="idfRow">Строка, данные которой принимаются за основу</param>
        public void CopyRow(long idfsSection, long idfRow)
        {
            if ((CurrentTemplate != null)
                && (CurrentObservation.HasValue)
                && (ActivityParameters != null)
                )
            {
                //если нет данных по этой строке, то нечего и копировать
                var aps = ActivityParameters.Where(c => c.idfRow == idfRow).ToList();
                if (aps.Count == 0) return;
                //вычисляем новый номер строки
                var sectionNode = TemplateFlexNode.FindChildNodeSection(idfsSection);
                var numRow = sectionNode.GetNumForNewRow(ActivityParameters);

                long idfRowNew;
                using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    idfRowNew = (new GetNewIDExtender<ActivityParameter>()).GetScalar(manager, null);
                }
                foreach (var activityParameter in aps)
                {
                    if (!activityParameter.idfsParameter.HasValue) continue;
                    ActivityParameters.SetActivityParameterValue(
                        CurrentTemplate
                        , CurrentObservation.Value
                        , activityParameter.idfsParameter.Value
                        , idfRowNew
                        , numRow
                        , activityParameter.varValue
                        , activityParameter.strNameValue
                        );
                }
            }
        }

        /// <summary>
        /// Производит копирование пользовательских данных
        /// </summary>
        /// <param name="ffPresenterFrom">Откуда взять данные</param>
        /// <param name="ffPresenterTo">Куда скопировать</param>
        public static void Paste(FFPresenterModel ffPresenterFrom, FFPresenterModel ffPresenterTo)
        {
            if (!ffPresenterFrom.CurrentObservation.HasValue) return;
            if (!ffPresenterTo.CurrentObservation.HasValue) return;
            var idfObservationFrom = ffPresenterFrom.CurrentObservation.Value;
            var idfObservationTo = ffPresenterTo.CurrentObservation.Value;
            var aps = ffPresenterFrom.ActivityParameters.Where(ap => ap.idfObservation == idfObservationFrom).ToList();
            if (aps.Count == 0) return;
            //считаем, что вставка идёт в тот же шаблон, откуда было копирование
            foreach (var ap in aps)
            {
                if (!ap.idfsParameter.HasValue) continue;
                var numRow = ap.intNumRow.HasValue ? ap.intNumRow.Value : 0;
                if (!ap.idfRow.HasValue) continue;
                ffPresenterTo.ActivityParameters.SetActivityParameterValue(
                                                                ffPresenterTo.CurrentTemplate
                                                                 , idfObservationTo
                                                                 , ap.idfsParameter.Value
                                                                 , ap.idfRow.Value
                                                                 , numRow
                                                                 , ap.varValue
                                                                 , ap.strNameValue);
            }
        }


        public bool HasAnyValue
        {
            get
            {
                return ActivityParameters != null && ActivityParameters.Any(c => c.varValue != null);
            }
        }

        /// <summary>
        /// Рассчитывает перечень изменений после применения бизнес-правил шаблона
        /// </summary>
        /// <returns></returns>
        public void GetChangesAfterRules(ref CompareModel data, long idObservation, long idParameter, long idRow, long idKey, object value, FFRuleCheckPointType checkPoint)
        {
            //поместим только что введённое значение в хранилище пользовательских данных
            ActivityParameters.SetActivityParameterValue(
                                                    CurrentTemplate
                                                    , idObservation
                                                    , idParameter
                                                    , idRow
                                                    , UnassignedValue
                                                    , value
                                                    , String.Empty);
            //проверим все правила, с которыми связан этот параметр.
            //сформируем перечень изменений и поместим их в общую коллекцию CompareModel
            //перечень правил, которые выполнились
            List<Rule> executedRules;
            //правила, которые не выполнились, но по которым надо открыть контролы
            List<Rule> enablingRules;
            CurrentTemplate.RulesCheck(ActivityParameters, idObservation, idParameter, idRow, checkPoint, out executedRules, out enablingRules);
            //для каждого выполнившегося правила составим перечень заявок на изменение
            foreach (var rule in executedRules)
            {
                DataAdd(ref data, idObservation, idRow, idKey, rule, true, checkPoint);
            }

            //отберем те правила, которые не выполнились и для которых есть действие-блокировка
            //контролы из этих действий надо автоматически разблокировать
            foreach (var rule in enablingRules)
            {
                DataAdd(ref data, idObservation, idRow, idKey, rule, false, checkPoint);
            }
        }

        private void DataAdd(ref CompareModel data, long idObservation, long idRow, long idKey, Rule rule, bool isExecutedRule, FFRuleCheckPointType checkPoint)
        {
            foreach (var action in rule.Actions)
            {
                var needClear = action.idfsRuleAction == (long)FFRuleActions.Clear;
                var needDisable = isExecutedRule && action.idfsRuleAction == (long)FFRuleActions.Disabled;

                //если обрабатывается "обратное" правило, то для него актуальны только действия по разблокировке
                if (!isExecutedRule && needClear) continue;

                var controlName = HelperFunctions.GetParameterKey(idObservation, action.idfsParameter, idRow, idKey);

                //определяем, обязательный ли это параметр
                var pt = CurrentTemplate.ParameterTemplates.FirstOrDefault(c => c.idfsParameter == action.idfsParameter);
                if (pt == null) continue;

                //если это команда на очистку, то обнулим значение параметра
                if (needClear)
                {
                    //TODO с табличными значениями разобраться
                    //каскадный расчёт для правил, которые зависят от этого параметра
                    GetChangesAfterRules(ref data, idObservation, action.idfsParameter, idRow, idKey, null, checkPoint);
                }

                var ap = ActivityParameters.GetActivityParameter(false, idObservation, action.idfsParameter, idRow);
                if (Utils.IsEmpty(ap.varValue)) ap.varValue = String.Empty;

                var strType = "String";
                switch (pt.ParameterType)
                {
                    case FFParameterTypes.DateTime:
                    case FFParameterTypes.Date:
                        strType = "DateTime";
                        break;
                    case FFParameterTypes.NumericPositive:
                    case FFParameterTypes.NumericNatural:
                    case FFParameterTypes.NumericInteger:
                    case FFParameterTypes.Numeric:
                        strType = "int";
                        break;
                    case FFParameterTypes.Boolean:
                        strType = "Boolean?";
                        break;
                }

                if (pt.Editor == FFParameterEditors.ComboBox) strType = "Lookup";

                data.Add(
                    controlName
                    , controlName
                    , strType
                    , ap.varValue.ToString()//bv.common.Core.Utils.IsEmpty(ap.strNameValue) ? ap.varValue.ToString() : ap.strNameValue //rule.MessageNationalText
                    , needDisable
                    , false
                    , pt.IsMandatory());
            }

            //если это исполнившееся правило, то покажем его сообщение
            if (isExecutedRule)
            {
                var message = rule.MessageNationalText.Length > 0 ? rule.MessageNationalText : rule.MessageText;
                if (message.Length > 0)
                {
                    if (data.Values.ContainsKey("ErrorMessage"))
                    {
                        data.Values["ErrorMessage"].value += "</br>" + message;
                    }
                    else
                    {
                        data.Add(
                        rule.idfsRule.ToString()//"ErrorMessage"
                        , "ErrorMessage"
                        , "ErrorMessage"
                        , message
                        , false
                        , false
                        , false);
                    }
                }
            }
        }

        #region IObject

        public object Key
        {
            get { return CurrentObservation; }
        }

        public long KeyLong
        {
            get { return CurrentObservation ?? 0; }
        }

        public string KeyName { get { return "CurrentObservation"; } }
        public string ToStringProp { get { return ToString(); } }

        public Dictionary<string, string> GetFieldTags(string name)
        {
            return null;
        }

        public bool IsNew
        {
            get { return false; }
        }

        public bool HasChanges
        {
            get {
                //TODO также см. ActivityParameter.FakeField. Это workaround, потому что не ловится HasChanges
                /*
                return 
                    ActivityParameters.IsDirty
                    ||
                    ActivityParameters.Any(ap => ap.HasRealChanges)
                    ;
                */
                return ActivityParameters.Any(ap => ap.HasRealChanges);
            }
        }
        public override void RejectChanges()
        {
            base.RejectChanges();
            ActivityParameters.ForEach(c =>
            {
                c.HasRealChanges = false;
                c.RejectChanges();
            });
        }

        public void DeepRejectChanges()
        {
            RejectChanges();
        }
        public void DeepAcceptChanges()
        {
            AcceptChanges();
        }

        private bool m_bForceDirty;
        public override void AcceptChanges()
		{
            m_bForceDirty = false;
            base.AcceptChanges();
            ActivityParameters.ForEach(c =>
                {
                    c.HasRealChanges = false;
                    c.AcceptChanges();
                });
		}
        public override bool IsDirty
        {
            get { return m_bForceDirty || base.IsDirty; }
        }
        public void SetChange()
        { 
            m_bForceDirty = true;
        }
        public void DeepSetChange()
        { 
            SetChange();
        }

        public bool MarkToDelete(){return false;}

        public string ObjectName{get { return "FFPresenterModel"; }
        }

        public string ObjectIdent
        {
            get { return ObjectName + "_" + Key + "_"; }
        }

        public IObjectAccessor GetAccessor()
        {
            return Accessor.Instance(null);
        }

        private IObjectPermissions m_Permissions = Accessor.Instance(null) as IObjectPermissions;
        internal IObjectPermissions _permissions { get { return m_Permissions; } set { m_Permissions = value; } }
        public IObjectPermissions GetPermissions() 
        { 
            return _permissions; 
        }

        public IObjectEnvironment Environment { get; set; }

        public bool ReadOnly { get; set; }

        public bool IsReadOnly(string name)
        {
            return ReadOnly;
        }

        public bool IsInvisible(string name)
        {
            return false;
        }

        public bool IsRequired(string name)
        {
            return false;
        }
        public bool IsHiddenPersonalData(string name)
        {
            return false;
        }

        public string GetType(string name)
        {
            return GetType().ToString();
        }

        public object GetValue(string name)
        {
            return null;
        }

        public void SetValue(string name, string val)
        {
            
        }

        public void SetValues(IObject o)
        {
            
        }

        public CompareModel Compare(IObject o)
        {
            return new CompareModel();
        }

        public BvSelectList GetList(string name)
        {
            return null;
        }

        //public event PropertyChangedEventHandler PropertyChanged;
        
        public event ValidationEvent Validation;
        public event ValidationEvent ValidationEnd;
        public event AfterPostEvent AfterPost;

        public void OnValidation(ValidationEventArgs args)
        {
            ValidationEvent handler = Validation;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        public void OnValidationEnd(ValidationEventArgs args)
        {
            ValidationEvent handler = ValidationEnd;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        public void OnAfterPost(EventArgs args)
        {
            var handler = AfterPost;
            if (handler != null)
            {
                handler(this, args);
            }
        }
 
        #endregion

        #region IDisposable Members

        ~FFPresenterModel()
        {
            Dispose();
        }
        private bool bIsDisposed;
        public void Dispose()
        {
            if (!bIsDisposed)
            {
                bIsDisposed = true;

                if (CurrentTemplate != null)
                    CurrentTemplate.Dispose();

                ParameterList.ForEach(c => c.Dispose());
                SectionList.ForEach(c => c.Dispose());
                ActivityParameters.ForEach(c => c.Dispose());
                AggregateMatrixVersions.ForEach(c => c.Dispose());
            }
        }

        #endregion

        #region Generation support

        internal string m_ObjectName = "FFPresenterModel";

        internal CompareModel _compare(IObject o, CompareModel ret)
        {
            return new CompareModel();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        /// <param name="bParseLookups"> </param>
        /// <param name="bParseRelations"> </param>
        public void ParseFormCollection(NameValueCollection form, bool bParseLookups = true, bool bParseRelations = true)
        {
            if (!CurrentObservation.HasValue) return;
            if (CurrentTemplate == null) return;
           
            var idfObservation = CurrentObservation.Value;
            //определяем параметры, которые были удалены с формы (динамические параметры)
            /*
            List<ParametersDeletedFromTemplate> deletedParameters;
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var accessor = ParametersDeletedFromTemplate.Accessor.Instance(null);
                deletedParameters = accessor.SelectList(manager, idfObservation).ToList();
            }
             */
            var deletedParameters = FFHelper.GetDeletedParameters(ActivityParameters, idfObservation, CurrentTemplate);
            //здесь будем хранить ссылки на шаблоны для динамических параметров
            var templates = new List<Template>(); 
            //отберём те контролы с формы, которые относятся к нужному ключу
            var obsKey = HelperFunctions.GetParameterKeyObservationPart(idfObservation);
            var accParameter = Parameter.Accessor.Instance(null);
            List<Parameter> parameters = null;
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                parameters = accParameter.SelectDetailList(manager, null, CurrentTemplate.idfsFormType);
            }

            foreach (string key in form.Keys)
            {
                if (!key.Contains(obsKey)) continue;
                //вынимаем из ключа параметр и ID строки
                var parts = key.Split(new[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 4) continue;
                var idfsParameter = Convert.ToInt64(parts[1].Substring(1));
                //определяем id строки
                long idfRow;
                if (!Int64.TryParse(parts[2].Substring(1), out idfRow)) continue;//idfRow = UnassignedValue;
                var value = form[key];
                //проверяем, правильно ли введено значение, исходя из типа данных
                var parameter = CurrentTemplate.ParameterTemplates.FirstOrDefault(p => p.idfsParameter == idfsParameter);
                if (parameter != null)
                {
                    if (parameter.IsCorrectDataType(value))
                    {
                        ActivityParameters.SetActivityParameterValue(CurrentTemplate, idfObservation, idfsParameter,
                                                                     idfRow,
                                                                     UnassignedValue, value, String.Empty);
                    }
                    else
                    {
                        InvokeErrorValueType(parameter.NationalName);
                    }
                }
                else
                {
                    ParametersDeletedFromTemplate deletedParameter = null;

                    if (deletedParameters.Count > 0)
                    {
                        //пробуем отыскать параметр среди динамических
                        deletedParameter = deletedParameters.FirstOrDefault(p => p.idfsParameter == idfsParameter);
                    }
                    if (deletedParameter == null)
                    {
                        var p = parameters.FirstOrDefault(c => c.idfsParameter == idfsParameter);
                        if (p != null)
                        {
                            //создаем новый параметр
                            deletedParameter = FFHelper.CreateDeletedParameter(p, idfObservation,
                                                                               CurrentTemplate.idfsFormTemplate);
                        }
                    }
                    if (deletedParameter != null)
                    {
                        if (deletedParameter.IsCorrectDataType(value))
                        {
                            //каждый динамический параметр может быть из своего шаблона
                            //за сеанс работы шаблон может быть переключен много раз
                            var dynamicTemplate = templates.FirstOrDefault(c => c.idfsFormTemplate == deletedParameter.idfsFormTemplate);
                            if (dynamicTemplate == null)
                            {
                                var acc = Template.Accessor.Instance(null);
                                using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                                {
                                    dynamicTemplate = acc.SelectByKey(manager, deletedParameter.idfsFormTemplate, null);
                                    templates.Add(dynamicTemplate);
                                }
                            }

                            if (dynamicTemplate != null)
                            {
                                ActivityParameters.SetActivityParameterValue(dynamicTemplate
                                                                             , idfObservation
                                                                             , idfsParameter
                                                                             , idfRow
                                                                             , UnassignedValue
                                                                             , value
                                                                             , String.Empty
                                                                             , deletedParameters);
                            }
                        }
                        else
                        {
                            InvokeErrorValueType(deletedParameter.NationalName);
                        }
                    }
                }
            }
            OnPropertyChanged("ActivityParameters");
        }

        public delegate void ErrorValueTypeHandler(string parameterName);

        /// <summary>
        /// Событие срабатывает, когда происходит попытка ввести данные неверного типа
        /// </summary>
        public event ErrorValueTypeHandler ErrorValueType;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameterName">Национальное название параметра, для которого неверно введены данные</param>
        private void InvokeErrorValueType(string parameterName)
        {
            if (ErrorValueType != null) ErrorValueType(parameterName);
        }

        /// <summary>
        /// Не выставленное значение
        /// </summary>
        public static int UnassignedValue { get { return -1; } }
        

        public bool IsMarkedToDelete { get { return false; } }

        private void AddParameters(IEnumerable<FlexNode> nodes)
        {
            foreach (var n in nodes)
            {
                AddParameters(n.ChildList);
                if (!n.IsParameter()) continue;
                var param = n.GetParameterTemplate();
                if (param == null) continue;
                if (!ParameterList.Contains(param)) ParameterList.Add(param);
            }
        }

        public void RefreshParameterList()
        {
            ParameterList.Clear();
            AddParameters(TemplateFlexNode.ChildList);
        }

        #endregion

        #region Accessor

        public abstract class Accessor
            : DataAccessor<FFPresenterModel>
            , IObjectAccessor
            , IObjectPost
            , IObjectMeta
        {
            public string KeyName
            {
                get { return "CurrentObservation"; }
            }

            private static readonly Accessor m_GInstance = CreateInstance<Accessor>();
            public static Accessor Instance(CacheScope cs)
            {
                return m_GInstance;
            }

            /*
            public virtual List<ActivityParameter> SelectDetailList(DbManagerProxy manager
                , EditableList<ActivityParameter> mainActivityParameters
                , String observationList
                )
            {
                return _SelectList(manager
                    , mainActivityParameters
                    , observationList
                    );
            }

            private List<ActivityParameter> _SelectList(DbManagerProxy manager
                , EditableList<ActivityParameter> mainActivityParameters
                , String observationList
                )
            {
                try
                {
                    var sets = new MapResultSet[1];
                    var objs = new List<ActivityParameter>();
                    sets[0] = new MapResultSet(typeof(ActivityParameter), objs);

                    manager
                        .SetSpCommand("spFFGetActivityParameters"
                            , manager.Parameter("@observationList", observationList)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)

                            )
                        .ExecuteResultSet(sets);
                    foreach (var obj in objs)
                    {
                        ActivityParameter.Accessor.Instance(null)._SetupLoad(manager, obj);
                    }

                    //производим слияние с существующим датасетом
                    mainActivityParameters.Merge(objs);

                    return objs;
                }
                catch (DataException e)
                {
                    throw DbModelException.Create(e);
                }
            }

            [SprocName("spFFRemoveActivityParameters")]
            protected abstract void _postDelete(DbManagerProxy manager
                , Int64? idfsParameter
                , Int64? idfObservation
                , Int64? idfRow
                );

            [SprocName("spFFSaveActivityParameters")]
            protected abstract void _post(DbManagerProxy manager,
                [Direction.InputOutput("idfRow", "idfActivityParameters")] ActivityParameter obj);
            */

            public virtual FFPresenterModel SelectByKey(DbManagerProxy manager
                , Int64? idfObservation
                )
            {
                var ffPresenter = new FFPresenterModel();
                if (idfObservation.HasValue)
                {
                    ffPresenter.CurrentObservation = idfObservation;
                    ffPresenter.ActivityParameters.LoadActivityParameters(idfObservation.Value);
                    var template = LoadTemplate(idfObservation.Value);
                    ffPresenter.SetProperties(template, 0);
                    if ((ffPresenter.CurrentTemplate != null) 
                        && (ffPresenter.CurrentTemplate.idfsFormType.HasValue) 
                        && (ffPresenter.CurrentTemplate.idfsFormTemplate > 0))
                    {
                        ffPresenter.FormType = ffPresenter.CurrentTemplate.idfsFormType.Value;
                    }
                }
                return ffPresenter;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="manager"></param>
            /// <param name="obj"></param>
            /// <param name="bPostValidation"></param>
            /// <param name="bChangeValidation"></param>
            /// <param name="bDeepValidation"></param>
            /// <param name="bThrowException"> </param>
            /// <returns></returns>
            public bool Validate(DbManagerProxy manager, FFPresenterModel obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bThrowException = false)
            {
                //
                if (obj == null) return true;
                if (!obj.CurrentObservation.HasValue) return true;

                #region Обязательные поля

                for (var i = 0; i < obj.ParameterList.Count; i++)
                {
                    var par = obj.ParameterList[i];
                    if (par.IsMandatory())
                    {
                        var parameterInSectionTable = DataHelper.IsParameterInSectionTable(par, obj.CurrentTemplate);
                        if (parameterInSectionTable)
                        {
                            var idfRowsList = new List<long>();
                            foreach (var a in obj.ActivityParameters)
                            {
                                if (a.idfsParameter != par.idfsParameter) continue;
                                if (a.idfRow.HasValue && !idfRowsList.Contains(a.idfRow.Value))
                                    idfRowsList.Add(a.idfRow.Value);
                            }

                            //TODO idfRow в таблицах бывают обязательные поля
                            foreach (var idfRow in idfRowsList)
                            {
                                var ap = obj.ActivityParameters.GetActivityParameter(true, obj.CurrentObservation.Value, par.idfsParameter, idfRow);
                                if ((ap == null) || Utils.IsEmpty(ap))
                                {
                                    throw new ValidationModelException("ErrMandatoryFieldRequired", par.NationalName, par.NationalName, new object[] { par.NationalName }, typeof(RequiredValidator), false, obj);
                                }
                            }
                        }
                        else
                        {
                            var ap = obj.ActivityParameters.GetActivityParameter(false, obj.CurrentObservation.Value, par.idfsParameter, 0);
                            if ((ap == null) || Utils.IsEmpty(ap))
                            {
                                throw new ValidationModelException("ErrMandatoryFieldRequired", par.NationalName, par.NationalName, new object[] { par.NationalName }, typeof(RequiredValidator), false, obj);
                            }
                        }
                    }
                }

                #endregion

                #region Проверка бизнес-правил
                if (obj.CurrentTemplate != null)
                {
                    List<Rule> executedRules;
                    List<Rule> enablingRules;

                    //правила с запретом сохранять данные
                    var rules = obj.CurrentTemplate.Rules.Where(c => c.idfsCheckPoint.HasValue && (c.idfsCheckPoint.Value == (long)FFRuleCheckPointType.OnSaveWithError)).ToList();
                    obj.CurrentTemplate.RulesCheckRoutines(rules, obj, out executedRules, out enablingRules);
                    //разблокировочные правила тут не учитываются. Показываем сообщения только по выполненным.
                    if (executedRules.Count > 0)
                    {
                        var rule = executedRules[0];
                        //берем только первое
                        var nn = rule.Parameters[0].NationalName;
                        throw new ValidationModelException(rule.MessageNationalText, nn, nn, new object[] { }, null, false, obj);
                    }

                    //правила с предупреждением
                    rules = obj.CurrentTemplate.Rules.Where(c => c.idfsCheckPoint.HasValue && (c.idfsCheckPoint.Value == (long)FFRuleCheckPointType.OnSaveWithNotify)).ToList();
                    obj.CurrentTemplate.RulesCheckRoutines(rules, obj, out executedRules, out enablingRules);
                    //разблокировочные правила тут не учитываются. Показываем сообщения только по выполненным.
                    if (executedRules.Count > 0)
                    {
                        //собираем сообщения со всех правил и показываем его один раз (особенность движка)
                        var sb = new StringBuilder();
                        foreach (var rule in executedRules)
                        {
                            sb.AppendFormat("{0}</br>", rule.MessageNationalText);
                        }
                        var rl = executedRules[0];
                        if (rl.Parameters.Count > 0)
                        {
                            var nn = rl.Parameters[0].NationalName;
                            throw new ValidationModelException(sb.ToString(), nn, nn, new object[] { }, null, true, obj);
                        }
                    }
                }

                #endregion

                return true;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="manager"></param>
            /// <param name="obj"></param>
            /// <param name="bChildObject"> </param>
            /// <returns></returns>
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                var bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    var ffPresenter = obj as FFPresenterModel;
                    if (ffPresenter == null) return false;

                    if (!manager.IsTransactionStarted)
                    {
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }

                    bSuccess = _PostNonTransaction(manager, ffPresenter);
                    
                    if (bTransactionStarted)
                    {
                        if (bSuccess)
                        {
                            manager.CommitTransaction();
                            //bo.OnAfterPost();
                        }
                        else
                        {
                            manager.RollbackTransaction();
                        }

                    }
                }
                catch (Exception e)
                {
                    if (bTransactionStarted) manager.RollbackTransaction();
                    if (e is DataException)
                    {
                        throw DbModelException.Create(e as DataException);
                    }
                    throw;
                }
                return bSuccess;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="manager"></param>
            /// <param name="ffPresenter"></param>
            /// <returns></returns>
            private bool _PostNonTransaction(DbManagerProxy manager, FFPresenterModel ffPresenter)
            {
                if (ffPresenter.HasChanges)
                {
                    //сохраняем пользовательские данные
                    var acc = ActivityParameter.Accessor.Instance(null);
                    foreach (var activityParameter in ffPresenter.ActivityParameters)
                    {
                        //если у параметра нулловое значение, то он должен быть помечен на удаление
                        if (activityParameter.varValue == null) activityParameter.MarkToDelete();
                        acc.Post(manager, activityParameter, true);
                    }
                }

                ffPresenter.AcceptChanges();

                return true;
            }

            internal void _SetPermitions(IObjectPermissions permissions, FFPresenterModel ffPresenter)
            {
            }


            public int? MaxSize(string name)
            {
                return 0;
            }

            public bool RequiredByField(string name, IObject obj)
            {
                return false;
            }

            public bool RequiredByProperty(string name, IObject obj)
            {
                return false;
            }

            public List<SearchPanelMetaItem> SearchPanelMeta
            {
                get { return new List<SearchPanelMetaItem>(); }
            }

            public List<GridMetaItem> GridMeta
            {
                get { return new List<GridMetaItem>(); }
            }

            public List<ActionMetaItem> Actions
            {
                get { return new List<ActionMetaItem>(); }
            }

            public string DetailPanel
            {
                get { return String.Empty; }
            }

            public string HelpIdWin { get { return String.Empty; } }
            public string HelpIdWeb { get { return String.Empty; } }
            public string HelpIdHh { get { return String.Empty; } }

        }

        #endregion


    }
}
