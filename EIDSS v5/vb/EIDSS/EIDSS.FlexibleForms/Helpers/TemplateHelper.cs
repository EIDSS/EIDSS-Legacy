using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using bv.common.Core;
using EIDSS.FlexibleForms.DataBase;
using EIDSS.FlexibleForms.Helpers.ReportHelper.DataItems;
using EIDSS.FlexibleForms.Helpers.ReportHelper.Tree;
using eidss.model.Core;
using eidss.model.Resources;

namespace EIDSS.FlexibleForms.Helpers
{
    public class TemplateHelper
    {
        private DbServiceUserData mainDbService { get; set; }
        private FlexibleFormsDS.TemplatesRow actualTemplate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TemplateHelper()
        {
            mainDbService = new DbServiceUserData();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbService"></param>
        internal TemplateHelper(DbServiceUserData dbService)
        {
            mainDbService = dbService;
        }

        /// <summary>
        /// ID активного шаблона
        /// </summary>
        public long? IdfsFormTemplate { get; private set; }

        /// <summary>
        /// Является ли активный шаблон UNI-шаблоном
        /// </summary>
        public bool? IsUNITemplate { get; private set; }

        /// <summary>
        /// ID фиктивного Observation, которое содержит суммированные данные
        /// </summary>
        public long IdfObservationSummary
        {
            get { return mainDbService.IdfObservationSummary; }
        }

        /// <summary>
        /// ID фиктивного Form Template, который содержит слитую (merged) структуру по всем Observation, которые входят в сводный отчёт
        /// </summary>
        public long IdfsFormTemplateSummary
        {
            get { return mainDbService.IdfsFormTemplateSummary; }
        }

        /// <summary>
        /// idfVersion шаблона, который используется в данный момент. Применяется только для Aggregate Case.
        /// </summary>
        public long? VersionMatrixStub { get; private set; }

        /// <summary>
        /// Секции, входящие в активный шаблон
        /// </summary>
        public FlexibleFormsDS.SectionTemplateDataTable SectionTemplate
        {
            get { return mainDbService.MainDataSet.SectionTemplate; }
        }

        /// <summary>
        /// Параметры, входящие в активный шаблон
        /// </summary>
        public FlexibleFormsDS.ParameterTemplateDataTable ParameterTemplate
        {
            get { return mainDbService.MainDataSet.ParameterTemplate; }
        }

        /// <summary>
        /// Данные, входящие в активный шаблон
        /// </summary>
        public FlexibleFormsDS.ActivityParametersDataTable ActivityParameters
        {
            get { return mainDbService.MainDataSet.ActivityParameters; }
        }

        /// <summary>
        /// Полная информация об активном шаблоне
        /// </summary>
        public FlexibleFormsDS.TemplatesRow ActualTemplate
        {
            get { return actualTemplate; }
        }

        /// <summary>
        /// Осуществляет слияние шаблонов и боковиков, которые относятся к указанным observation
        /// </summary>
        /// <param name="observations"></param>
        /// <param name="formType"></param>
        /// <param name="idfsFormTemplateMerged">ID шаблона, в который нужно поместить совокупный шаблон</param>
        private void MergeTemplates(long idfsFormTemplateMerged, IEnumerable<long> observations, FFType formType)
        {
            var idfsFormType = (long)formType;

            //если по данному типу формы, к которому относится шаблон, не загружены мета-данные по секциям, то дозагрузим их
            //(проверка уже внутри)
            mainDbService.LoadSections(idfsFormType, null, null);
            mainDbService.LoadParameters(idfsFormType, null);

            //каждому observation может соответствовать свой шаблон, потому надо загрузить их все
            var observationsRows = mainDbService.LoadObservations(observations);
            if (observationsRows.Length == 0) return;

            #region Загрузка данных по телу таблицы

            //нужно сначало тело, потому что боковик проверяет наличие нужных табличных секций в шаблоне
            foreach (var observationsRow in observationsRows)
            {
                if (observationsRow.IsidfsFormTemplateNull()) continue;
                //загружаем данные по каждому шаблону (если они до сих пор не загружены)
                mainDbService.LoadSectionTemplate(observationsRow.idfsFormTemplate);
                mainDbService.LoadParameterTemplate(observationsRow.idfsFormTemplate);
            }

            #endregion

            //порядок именно такой, потому что боковик заносит признаки загрузки боковика и в тело шаблона

            #region Слияние структуры по шапке таблицы

            //очищаем данные предыдущего слияния
            mainDbService.DeleteSummaryTemplate();

            //копируем секции в саммари-шаблон
            foreach (var observationsRow in observationsRows)
            {
                if (observationsRow.IsidfsFormTemplateNull()) continue;

                //Копия секций в шаблоне
                CopyHelper.CopySectionTemplate(mainDbService, observationsRow.idfsFormTemplate, idfsFormTemplateMerged, bv.model.Model.Core.ModelUserContext.CurrentLanguage);

                //Копия параметров в шаблоне
                CopyHelper.CopyParameterTemplate(mainDbService, observationsRow.idfsFormTemplate, idfsFormTemplateMerged, bv.model.Model.Core.ModelUserContext.CurrentLanguage);
            }

            #endregion

            #region Слияние структуры по боковику

            var listStubInfo = mainDbService.GetListSectionsAndVersionsForStub(observationsRows, formType);
            //получаем информацию о версии матрицы боковика
            //загружаем данные по боковику и сразу вставляем их в шаблон
            mainDbService.IncludeStub(idfsFormTemplateMerged, listStubInfo);

            #endregion
        }

        /// <summary>
        /// Выставляет актуальный шаблон
        /// </summary>
        /// <param name="formType"></param>
        private void SetActualTemplate(long formType)
        {
            //получим информацию по всему шаблону
            mainDbService.LoadTemplates(formType);
            var templatesRows = (FlexibleFormsDS.TemplatesRow[])mainDbService.MainDataSet.Templates.Select(DataHelper.Filter("idfsFormTemplate", IdfsFormTemplate));
            if (templatesRows.Length == 1)
            {
                actualTemplate = templatesRows[0];
                IsUNITemplate = actualTemplate.blnUNI;
            }
        }

        /// <summary>
        /// Получение содержимого шаблона, расположенного по вертикали
        /// </summary>
        public List<DataRow> GetReportView()
        {
            return IdfsFormTemplate.HasValue ? GetReportView(mainDbService, IdfsFormTemplate.Value) : new List<DataRow>();
        }

        /// <summary>
        /// Получение содержимого шаблона, расположенного по вертикали
        /// </summary>
        /// <param name="mainDbService"></param>
        /// <param name="templateID"></param>
        /// <returns></returns>
        public static List<DataRow> GetReportView(DbService mainDbService, long templateID)
        {
            var result = new List<DataRow>();

            string filter = DataHelper.Filter("idfsFormTemplate", templateID);

            //вычисляем значение поля TopAbsolute у всех секций, параметров, лейблов и линий
            CalculateTopAbsolute(mainDbService, mainDbService.MainDataSet.SectionTemplate.Select(filter), "idfsParentSection", result);
            CalculateTopAbsolute(mainDbService, mainDbService.MainDataSet.ParameterTemplate.Select(filter), "idfsSection", result);
            CalculateTopAbsolute(mainDbService, mainDbService.MainDataSet.Labels.Select(filter), "idfsSection", result);
            CalculateTopAbsolute(mainDbService, mainDbService.MainDataSet.Lines.Select(filter), "idfsSection", result);

            //сортируем по возрастанию поля TopAbsolute
            result.Sort(CompareParameterHostDataRows);

            return result;
        }

        /// <summary>
        /// Вычисляет параметр 
        /// </summary>
        /// <param name="mainDbService"></param>
        /// <param name="rows"></param>
        /// <param name="parentSectionColumnName"></param>
        /// <param name="resultList"></param>
        private static void CalculateTopAbsolute(DbService mainDbService, IEnumerable<DataRow> rows, string parentSectionColumnName, List<DataRow> resultList)
        {
            foreach (var row in rows)
            {
                int intTop = Convert.ToInt32(row["intTop"]);
                int intAdditionalTop = 0;
                if (!Utils.IsEmpty(row[parentSectionColumnName]))
                {
                    long idfsSection = Convert.ToInt64(row[parentSectionColumnName]);
                    long idfsformTemplate = Convert.ToInt64(row["idfsFormTemplate"]);
                    intAdditionalTop = GetTopParentSection(mainDbService, idfsSection, idfsformTemplate);
                }
                row[TopAbsoluteColumnName] = intTop + intAdditionalTop;
                resultList.Add(row);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row1"></param>
        /// <param name="row2"></param>
        /// <returns></returns>
        private static int CompareParameterHostDataRows(DataRow row1, DataRow row2)
        {
            return (Convert.ToInt32(row1[TopAbsoluteColumnName]) - Convert.ToInt32(row2[TopAbsoluteColumnName]));
        }

        private const string TopAbsoluteColumnName = "TopAbsolute";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mainDbService"></param>
        /// <param name="idfsSection"></param>
        /// <param name="idfsformTemplate"></param>
        /// <returns></returns>
        private static int GetTopParentSection(DbService mainDbService, long idfsSection, long idfsformTemplate)
        {
            int result = 0;
            var sectionTemplateRow = mainDbService.GetSectionTemplateRow(idfsSection, idfsformTemplate);
            if (sectionTemplateRow != null)
            {
                result = sectionTemplateRow.intTop;
                if (!sectionTemplateRow.IsidfsParentSectionNull())
                {
                    result += GetTopParentSection(mainDbService, sectionTemplateRow.idfsParentSection, sectionTemplateRow.idfsFormTemplate);
                }
            }
            return result;
        }

        /// <summary>
        /// Рассчитывает сводные данные, заполняя табличные секции предустановленными боковиками, по текущей стране
        /// </summary>
        /// <param name="observations">Коллекция ID сущностей (observation)</param>
        /// <param name="formType">ID типа формы</param>
        public void LoadSummary(List<long> observations, FFType formType)
        {
            if (observations == null) return;

            IdfsFormTemplate = IdfsFormTemplateSummary;
            //обнуляем эти свойства, потому что в саммари участвует несколько Observation и у каждого может быть своя версия боковика и шаблона
            VersionMatrixStub = null;

            var idfsFormType = (long) formType;

            //получим информацию по всему шаблону
            SetActualTemplate(idfsFormType);

            //загружаем структуру
            MergeTemplates(mainDbService.IdfsFormTemplateSummary, observations, formType);
            var observationsRows = mainDbService.LoadObservations(observations);
            
            //загружаем данные
            //загрузим пользовательские данные
            foreach (var observationsRow in observationsRows)
            {
                if (observationsRow.IsidfsFormTemplateNull()) continue;
                mainDbService.LoadUserData(observationsRow.idfObservation, observationsRow.idfsFormTemplate, true);
            }

            //надо рассчитать сумму данных и заложить её в фиктивный ObservationSummary, а затем показывать его
            //суммировать можно только те параметры, у которых тип Numeric. Остальные игнорировать (Михаил, 11.01.2010).
            //суммируется только тело таблицы, боковик не учитывается
            //в дальнейшем суммированные данные не сохраняются

            //расчёт summary
            var lst = new List<long>();
            lst.AddRange(observations);
            mainDbService.CalculateSummary(lst);
            FlexibleFormsDS.PredefinedStubRow[] predefinedStubRows;

            mainDbService.IncludeStubDataInUserData(IdfsFormTemplate, IdfObservationSummary, null, out predefinedStubRows);

            //загружаем структуру шаблона
            mainDbService.LoadSections(idfsFormType, null, null);
            mainDbService.LoadParameters(idfsFormType, null);
            mainDbService.LoadSectionTemplate(IdfsFormTemplate);
            mainDbService.LoadParameterTemplate(IdfsFormTemplate);
        }

        /// <summary>
        /// Загружает инфраструктуру шаблона
        /// </summary>
        /// <param name="idFormTemplate"></param>
        /// <param name="presetStub"></param>
        /// <param name="observation"></param>
        /// <param name="formType"></param>
        public void LoadAggregateTemplate(long idFormTemplate, AggregateCaseSection presetStub, long observation, FFType formType)
        {
            LoadTemplate(formType, idFormTemplate, new List<long> {observation}, new[] {presetStub});
        }

        /// <summary>
        /// Загружает инфраструктуру шаблона
        /// </summary>
        /// <param name="presetStub">Перечень наборов [табличная секция - матрица] для указания размещения матриц в табличных секция</param>
        /// <param name="observation"></param>
        /// <param name="formType"></param>
        public void LoadAggregateTemplate(AggregateCaseSection presetStub, long observation, FFType formType)
        {
            LoadTemplate(formType, EidssSiteContext.Instance.CountryID, null, new List<long> { observation }, new[] { presetStub });
        }

        /// <summary>
        /// Загружает инфраструктуру шаблона
        /// </summary>
        /// <param name="observations"></param>
        /// <param name="formType"></param>
        /// <param name="secondDeterminant">Диагноз или Тип теста</param>
        public void LoadTemplate(List<long> observations, long? secondDeterminant, FFType formType)
        {
            LoadTemplate(formType, EidssSiteContext.Instance.CountryID, secondDeterminant, observations, null);
        }

        /// <summary>
        /// Загружает инфраструктуру шаблона
        /// </summary>
        /// <param name="formType">Тип формы</param>
        /// <param name="countryDeterminant">Детерминант-страна</param>
        /// <param name="secondDeterminant">Детерминант диагноз или тест</param>
        /// <param name="observationList">Перечень observation</param>
        /// <param name="presetStubs">Боковик</param>
        private void LoadTemplate(FFType formType, long countryDeterminant, long? secondDeterminant, List<long> observationList,IEnumerable<AggregateCaseSection> presetStubs)
        {
            IdfsFormTemplate = null;
            if (observationList.Count > 1)
            {
                mainDbService.LoadActualTemplate(countryDeterminant, secondDeterminant, (long) formType);

                //если нет ни одной строки, то никакого шаблона не удалось найти (ни обычного, ни UNI)
                if (mainDbService.MainDataSet.ActualTemplate.Rows.Count == 0) return;
                var actualTemplateRow =
                    (FlexibleFormsDS.ActualTemplateRow) mainDbService.MainDataSet.ActualTemplate.Rows[0];
                IdfsFormTemplate = actualTemplateRow.idfsFormTemplate != -1
                                       ? (long?) actualTemplateRow.idfsFormTemplate
                                       : null;
            }
            else
            {
                var observationsRows = mainDbService.LoadObservations(observationList);
                if (observationsRows.Length > 0)
                {
                    if (!observationsRows[0].IsidfsFormTemplateNull())
                        IdfsFormTemplate = observationsRows[0].idfsFormTemplate;
                }
            }

            if ((IdfsFormTemplate == null) || Utils.IsEmpty(IdfsFormTemplate)) return;

            LoadTemplate(formType, IdfsFormTemplate.Value, observationList, presetStubs);
        }

        /// <summary>
        /// Загружает инфраструктуру шаблона
        /// </summary>
        /// <param name="formType">Тип формы</param>
        /// <param name="idFormTemplate">Шаблон, который требуется загрузить</param>
        /// <param name="observationList">Перечень observation</param>
        /// <param name="presetStubs">Боковик</param>
        internal void LoadTemplate(FFType formType, long idFormTemplate, List<long> observationList,IEnumerable<AggregateCaseSection> presetStubs)
        {
            if (observationList == null) return;

            IdfsFormTemplate = idFormTemplate;

            //получим информацию по всему шаблону
            var idfsFormType = (long) formType;
            SetActualTemplate(idfsFormType);

            //загружаем структуру шаблона
            mainDbService.LoadSections(idfsFormType, null, null);
            mainDbService.LoadParameters(idfsFormType, null);
            mainDbService.LoadSectionTemplate(IdfsFormTemplate);
            mainDbService.LoadParameterTemplate(IdfsFormTemplate);

            mainDbService.LoadLines(IdfsFormTemplate);
            mainDbService.LoadLabels(IdfsFormTemplate.Value);

            //если есть предустановленный боковик, то обработаем его
            if (presetStubs != null)
            {
                //версию боковика не указываем, чтобы была взята активная
                mainDbService.IncludeStub(IdfsFormTemplate.Value, mainDbService.GetListSectionsAndVersionsForStub(observationList, formType));
            }

            //для всех заданных observation загрузим пользовательские данные
            foreach (var idfObservation in observationList)
            {
                mainDbService.LoadUserData(idfObservation, IdfsFormTemplate.Value, true);
                //если есть предустановленный боковик, то дополним пользовательские данные его данными
                if (presetStubs == null) continue;
                
                //получаем информацию о версии матрицы боковика
                var matrixVersionRow = mainDbService.LoadMatrixStubInfo(idfObservation);
                //если не удалось найти матрицу (например, она ещё не заведена), то ищем в других Observation
                if (matrixVersionRow == null) continue;
                if (matrixVersionRow.IsidfVersionNull()) continue;

                //данные по боковику уже должны быть загружены, поскольку по ним он визуализировался
                var predefinedStubRows = mainDbService.GetPredefinedStubRows(matrixVersionRow.idfVersion);
                foreach (var predefinedStubRow in predefinedStubRows)
                {
                    mainDbService.MainDataSet.ActivityParameters.RenumActivityParameters(predefinedStubRow, idfObservation);
                    mainDbService.ChangeValue(idfObservation, IdfsFormTemplate.Value, predefinedStubRow.idfsParameter, predefinedStubRow.idfRow, predefinedStubRow.NumRow, predefinedStubRow.idfsParameterValue, predefinedStubRow.strNameValue);
                }
            }
        }

        /// <summary>
        /// Получение структуры шаблона древовидно (шаблон уже должен быть загружен)
        /// </summary>
        /// <param name="idfObservation"></param>
        /// <returns></returns>
        public FlexNode GetFlexNodeFromTemplate(long idfObservation)
        {
            var rootNode = FlexNode.CreateRoot();
            //получаем шаблон, связанный с Observation
            var observationsRow = mainDbService.LoadObservations(idfObservation);
            if ((observationsRow != null) && (!observationsRow.IsidfsFormTemplateNull()))
            {
                //начинаем с корня шаблона и внутрь
                FillFlexNodeForSection(rootNode, null, observationsRow.idfObservation, observationsRow.idfsFormTemplate);
                
                //добавим раздел с динамическими параметрами
                var parametersTable = mainDbService.LoadParameterDeletedFromTemplate(idfObservation, null, null);
                if (parametersTable.Count > 0)
                {
                    //добавим спецсекцию-контейнер для динамических параметров
                    var dynamicGroup = rootNode.Add(EidssMessages.Get("DynamicParametersGroupControlCaption"));
                    int heightTotal = 0;
                    int widthTotal = 0;
                    foreach (var rowParameter in parametersTable)
                    {
                        Size size;
                        //находим значение для этого параметра, добавляем сам параметр
                        dynamicGroup.Add(rowParameter, mainDbService.GetActivityParametersRow(idfObservation, rowParameter.idfsParameter, null), out size);
                        heightTotal += size.Height;
                        if (widthTotal < size.Width) widthTotal = size.Width;
                    }
                    //установим ему правильные размеры с запасом
                    if (heightTotal * widthTotal > 0)
                    {
                        //dynamicGroup.DataItem.Width = widthTotal + 30;
                        dynamicGroup.DataItem.Width = widthTotal;
                        dynamicGroup.DataItem.Height = heightTotal + 30;

                        //подравниваем динамический блок с предыдущим, чтобы не вылезал за границы листа
                        if (rootNode.Count > 1)
                        {
                            var staticItemWidth = rootNode[0].DataItem.Width;
                            if (dynamicGroup.DataItem.Width > staticItemWidth)
                                dynamicGroup.DataItem.Width = staticItemWidth;
                            //аналогично подравниваем и динамические параметры
                            foreach (var rootNodes in rootNode.ChildList)
                            {
                                if (rootNodes.ChildListCount == 0) continue;
                                foreach (var item in rootNodes.ChildList)
                                {
                                    var paramWidth = item.DataItem.Width;
                                    foreach (var child in dynamicGroup.ChildList)
                                    {
                                        if (child.DataItem.Width > paramWidth) child.DataItem.Width = paramWidth;
                                    }
                                    break;
                                }
                                break;
                            }
                        }
                    }
                }
                //для каждой табличной секции верхнего уровня, входящей в шаблон, подцепим таблицу с данными
                AddDataTable(rootNode, idfObservation);
            }
            return rootNode;
        }

        /// <summary>
        /// Перегоняет шаблон с Summary в древовидную форму (шаблон уже должен быть загружен)
        /// </summary>
        /// <returns></returns>
        public FlexNode GetFlexNodeFromTemplateSummary()
        {
            var rootNode = FlexNode.CreateRoot();
            FillFlexNodeForSection(rootNode, null, IdfObservationSummary, IdfsFormTemplateSummary); //начинаем с корня шаблона и внутрь
            //для каждой табличной секции верхнего уровня, входящей в шаблон, подцепим таблицу с данными
            AddDataTable(rootNode, IdfObservationSummary);

            return rootNode;
        }

        /// <summary>
        /// Собирает рекурсивно все нижележащие параметры, которые уже отсортированы по порядку следования
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="parameters"></param>
        private void CollectParametersUnderSection(FlexNode parentNode, List<FlexibleFormsDS.ParameterTemplateRow> parameters)
        {
            var parameterTemplateRow = parentNode.DataItem.LinkedObject as FlexibleFormsDS.ParameterTemplateRow;
            if (parameterTemplateRow != null)
            {
                parameters.Add(parameterTemplateRow);
            }
            //рекурсивно по всем потомкам
            foreach (var childNode in parentNode.ChildList)
            {
                CollectParametersUnderSection(childNode, parameters);
            }
        }

        /// <summary>
        /// Получает таблицу для шаблона в TemplateHelper
        /// </summary>
        /// <param name="idfObservation"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private DataTable GetDataTableForTemplate(long idfObservation, List<FlexibleFormsDS.ParameterTemplateRow> parameters)
        {
            //шаблон должен быть загружен, данные получены
            //столбцами результирующей таблицы являются все параметры для указанного шаблона.
            //строками таблицы являются все найденные idfRow для данного Observation
            //пустые данные заполняются DBNull.Value
            var resultTable = new DataTable();
            var rows = mainDbService.GetActivityParametersRows(idfObservation);
            if ((parameters.Count > 0) && (rows.Length > 0))
            {
                foreach (var parameterRow in parameters)
                {
                    if (!parameterRow.IsRowAlive()) continue;
                    var column = new DataColumn(parameterRow.idfsParameter.ToString(), typeof(string))
                                     {
                                         Caption = parameterRow.NationalName,
                                         AllowDBNull = true,
                                         DefaultValue = DBNull.Value
                                     };
                    resultTable.Columns.Add(column);
                }

                foreach (var activityParametersRow in rows)
                {
                    if (!activityParametersRow.IsRowAlive()) continue;
                    //если не удалось свести с номером строки, то значит какие-то проблемы или изменения с матрицей, и игнорируем эту строку
                    if (activityParametersRow.IsintNumRowNull()) continue;
                    //добавляем столько строк, чтобы хватило для размещения добавляемой строки
                    int cnt = activityParametersRow.intNumRow + 1;
                    if (cnt > resultTable.Rows.Count)
                    {
                        for (int i = resultTable.Rows.Count; i < cnt; i++)
                        {
                            resultTable.Rows.Add(resultTable.NewRow());
                        }
                    }

                    var row = resultTable.Rows[activityParametersRow.intNumRow];

                    foreach (var parameterRow in parameters)
                    {
                        if (!parameterRow.IsRowAlive()) continue;
                        var rowValue = mainDbService.GetActivityParametersRow(idfObservation, parameterRow.idfsParameter, activityParametersRow.idfRow);
                        if (!Utils.IsEmpty(rowValue))
                        {
                            //переводим даты в правильный формат
                            if (rowValue.varValue is DateTime)
                            {
                                var destFormat = (CultureInfo.CurrentCulture).DateTimeFormat.ShortDatePattern;
                                rowValue.strNameValue = ((DateTime)rowValue.varValue).ToString(destFormat, CultureInfo.InvariantCulture);
                            }
                            row[parameterRow.idfsParameter.ToString()] = rowValue.strNameValue.Length > 0 ? rowValue.strNameValue : rowValue.varValue;
                        }
                    }
                }
            }


            return resultTable;
        }

        /// <summary>
        /// Расчёт совокупной ширины объекта, исходя из ширин, входящих в него объектов
        /// </summary>
        /// <param name="parentNode"></param>
        /// <returns></returns>
        private int CalculateWidthTotal(FlexNode parentNode)
        {
            var result = 0;
            if (parentNode.ChildListCount > 0)
            {
                result += parentNode.ChildList.Sum(node => CalculateWidthTotal(node));
                parentNode.DataItem.Width = result;
            }
            else
            {
                result = parentNode.DataItem.Width;
            }
            
            return result;
        }

        /// <summary>
        /// Проходит рекурсивно по всем узлам дерева, отыскивает табличные секции верхнего уровня, подцепляет к ним данные по нижележащим параметрам
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="idfObservation"></param>
        private void AddDataTable(FlexNode parentNode, long idfObservation)
        {
            //если была создана табличная секция и она верхнего уровня (т.е. над ней нет других табличных секций), то
            //именно она будет нести пользовательские данные
            var flexTableItem = parentNode.DataItem as FlexTableItem;
            if ((flexTableItem != null) && (!(parentNode.ParentNode.DataItem is FlexTableItem)))
            {
                //собираем рекурсивно все нижележащие параметры, которые уже отсортированы по порядку следования
                var parameters = new List<FlexibleFormsDS.ParameterTemplateRow>();
                CollectParametersUnderSection(parentNode, parameters);
                flexTableItem.BodyData = GetDataTableForTemplate(idfObservation, parameters);
                //вычисляем актуальную ширину этой секции как совокупность ширин входящих в неё объектов
                flexTableItem.Width = CalculateWidthTotal(parentNode);
            }
            //рекурсивно по всем потомкам
            foreach (var childNode in parentNode.ChildList)
            {
                AddDataTable(childNode, idfObservation);
            }
        }

        /// <summary>
        /// Создаёт узел с тем, что лежит в секции и рекурсивно по всем секциям внутри неё. Если секция не указана, то создаётся то, что лежит в корне шаблона.
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="idfsParentSection"></param>
        /// <param name="idfObservation"></param>
        /// <param name="idfsFormTemplate"></param>
        /// <returns></returns>
        private void  FillFlexNodeForSection(FlexNode parentNode
                                            , long? idfsParentSection
                                            , long idfObservation
                                            , long idfsFormTemplate
                                            )
        {
            //определяем объекты, которые входят в родительскую секцию
            var sectionTemplateRows = mainDbService.GetSectionTemplateChildrenRows(idfsParentSection, idfsFormTemplate);
            var parameterTemplateRows = mainDbService.GetParameterTemplateChildrenRows(idfsParentSection, idfsFormTemplate);
            var labelsRows = mainDbService.GetLabelsTemplateChildrenRows(idfsParentSection, idfsFormTemplate);
            var linesRows = mainDbService.GetLinesTemplateChildrenRows(idfsParentSection, idfsFormTemplate);
            
            //Трансляция секций в узлы дерева
            foreach (var sectionTemplateRow in sectionTemplateRows)
            {
                var sectionNode = parentNode.Add(sectionTemplateRow);
                sectionNode.ProcessAsTable = sectionTemplateRow.blnGrid;
                FillFlexNodeForSection(sectionNode, sectionTemplateRow.idfsSection, idfObservation, idfsFormTemplate);
            }

            #region Трансляция параметров в узлы дерева
            
            foreach (var parameterTemplateRow in parameterTemplateRows)
            {
                //обрабатываем параметры, не входящие в таблицы
                if (parameterTemplateRow.IsidfsSectionNull() || (!parameterTemplateRow.IsidfsSectionNull() && !mainDbService.IsSectionTable(parameterTemplateRow.idfsSection)))
                {
                    //находим значение для этого параметра, добавляем сам параметр
                    parentNode.Add(parameterTemplateRow, mainDbService.GetActivityParametersRow(idfObservation, parameterTemplateRow.idfsParameter, null));
                }
                else
                {
                    var isSummaryTemplate = idfsFormTemplate.Equals(mainDbService.IdfsFormTemplateSummary);
                    if (isSummaryTemplate && !mainDbService.IsParameterNumeric(parameterTemplateRow.idfsParameter) && (parameterTemplateRow.intOrder > 0)) continue;
            
                    //в табличных секциях осуществляем перевод параметра в лейбл без значения
                    parentNode.Add(parameterTemplateRow, true);
                }
            }

            #endregion

            //Сортировка секций и параметров
            parentNode.Sort();

            //Трансляция лейблов в узлы дерева
            foreach (var labelsRow in labelsRows)
            {
                parentNode.Add(labelsRow);
            }
            //Трансляция линий в узлы дерева
            foreach (var linesRow in linesRows)
            {
                parentNode.Add(linesRow);
            }
        }


    }
}
