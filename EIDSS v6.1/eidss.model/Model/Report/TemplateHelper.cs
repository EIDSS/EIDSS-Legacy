using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Model.FlexibleForms.FlexNodes;
using eidss.model.Schema;

namespace eidss.model.Model.Report
{
    public class TemplateHelper
    {
        public FFPresenterModel Model { get; private set; }

        public TemplateHelper()
        {
            Model = new FFPresenterModel();
        }

        public void LoadAggregateTemplate(AggregateCaseSectionEnum matrixId, long idfObservation)
        {
            var idfVersion = FFPresenterModel.LoadObservationVersion(idfObservation);
            Model.PrepareAggregateCase(matrixId, idfVersion ?? 0);
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
            get { return Model.IdfObservationSummary; }
        }

        /// <summary>
        /// ID фиктивного Form Template, который содержит слитую (merged) структуру по всем Observation, которые входят в сводный отчёт
        /// </summary>
        public long IdfsFormTemplateSummary
        {
            get { return Model.IdfsFormTemplateSummary; }
        }

        /// <summary>
        /// idfVersion шаблона, который используется в данный момент. Применяется только для Aggregate Case.
        /// </summary>
        public long? VersionMatrixStub { get; private set; }

        /*
        /// <summary>
        /// Секции, входящие в активный шаблон
        /// </summary>
        public FlexibleFormsDS.SectionTemplateDataTable SectionTemplate
        {
            get { return MainDbService.MainDataSet.SectionTemplate; }
        }

        /// <summary>
        /// Параметры, входящие в активный шаблон
        /// </summary>
        public FlexibleFormsDS.ParameterTemplateDataTable ParameterTemplate
        {
            get { return MainDbService.MainDataSet.ParameterTemplate; }
        }

        /// <summary>
        /// Данные, входящие в активный шаблон
        /// </summary>
        public FlexibleFormsDS.ActivityParametersDataTable ActivityParameters
        {
            get { return MainDbService.MainDataSet.ActivityParameters; }
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
            MainDbService.LoadSections(idfsFormType, null, null);
            MainDbService.LoadParameters(idfsFormType, null);

            //каждому observation может соответствовать свой шаблон, потому надо загрузить их все
            var observationsRows = MainDbService.LoadObservations(observations);
            if (observationsRows.Length == 0) return;

            #region Загрузка данных по телу таблицы

            //нужно сначало тело, потому что боковик проверяет наличие нужных табличных секций в шаблоне
            foreach (var observationsRow in observationsRows)
            {
                if (observationsRow.IsidfsFormTemplateNull()) continue;
                //загружаем данные по каждому шаблону (если они до сих пор не загружены)
                MainDbService.LoadSectionTemplate(observationsRow.idfsFormTemplate);
                MainDbService.LoadParameterTemplate(observationsRow.idfsFormTemplate);
            }

            #endregion

            //порядок именно такой, потому что боковик заносит признаки загрузки боковика и в тело шаблона

            #region Слияние структуры по шапке таблицы

            //очищаем данные предыдущего слияния
            MainDbService.DeleteSummaryTemplate();

            //копируем секции в саммари-шаблон
            foreach (var observationsRow in observationsRows)
            {
                if (observationsRow.IsidfsFormTemplateNull()) continue;

                //Копия секций в шаблоне
                CopyHelper.CopySectionTemplate(MainDbService, observationsRow.idfsFormTemplate, idfsFormTemplateMerged, bv.model.Model.Core.ModelUserContext.CurrentLanguage);

                //Копия параметров в шаблоне
                CopyHelper.CopyParameterTemplate(MainDbService, observationsRow.idfsFormTemplate, idfsFormTemplateMerged, bv.model.Model.Core.ModelUserContext.CurrentLanguage);
            }

            #endregion

            #region Слияние структуры по боковику

            var listStubInfo = MainDbService.GetListSectionsAndVersionsForStub(observationsRows, formType);
            //получаем информацию о версии матрицы боковика
            //загружаем данные по боковику и сразу вставляем их в шаблон
            MainDbService.IncludeStub(idfsFormTemplateMerged, listStubInfo);

            #endregion
        }
        */

        /// <summary>
        /// Получение содержимого шаблона, расположенного по вертикали
        /// </summary>
        public List<object> GetReportView()
        {
            if (!IdfsFormTemplate.HasValue) return new List<object>();
            var result = new List<object>();

            //вычисляем значение поля TopAbsolute у всех секций, параметров, лейблов и линий
            CalculateTopAbsolute(Model.CurrentTemplate, Model.CurrentTemplate.SectionTemplatesLookup, result);
            CalculateTopAbsolute(Model.CurrentTemplate, Model.CurrentTemplate.ParameterTemplatesLookup, result);
            CalculateTopAbsolute(Model.CurrentTemplate, Model.CurrentTemplate.LabelsLookup, result);
            
            //сортируем по возрастанию поля TopAbsolute
            result.Sort(CompareParameterHostDataRows);

            return result;
            
        }

        /// <summary>
        /// Вычисляет параметр 
        /// </summary>
        private static void CalculateTopAbsolute(Template template, IEnumerable<object> rows, List<object> resultList)
        {
            foreach (var row in rows)
            {
                int intTop;
                var intAdditionalTop = 0;
                long idfsSection;

                if (row is ParameterTemplate)
                {
                    var pt = (ParameterTemplate) row;
                    intTop = pt.intTop;
                    if (pt.ParentSection != null)
                    {
                        idfsSection = pt.ParentSection.idfsSection;
                        if (idfsSection > 0) intAdditionalTop = GetTopParentSection(template, idfsSection);
                        pt.TopAbsolute = intTop + intAdditionalTop;
                    }
                } 
                else if (row is SectionTemplate)
                {
                    var st = (SectionTemplate) row;
                    intTop = st.intTop ?? 0;
                    if (st.ParentSection != null)
                    {
                        idfsSection = st.ParentSection.idfsSection;
                        if (idfsSection > 0) intAdditionalTop = GetTopParentSection(template, idfsSection);
                        st.TopAbsolute = intTop + intAdditionalTop;
                    }
                }
                else if (row is Label)
                {
                    var l = (Label) row;
                    intTop = l.intTop;
                    if (l.idfsSection.HasValue)
                    {
                        idfsSection = l.idfsSection.Value;
                        if (idfsSection > 0) intAdditionalTop = GetTopParentSection(template, idfsSection);
                        l.TopAbsolute = intTop + intAdditionalTop;
                    }
                }
                resultList.Add(row);
            }
        }

        private static int GetIntTop(object row)
        {
            var intTop = 0;
            if (row is ParameterTemplate)
            {
                var pt = (ParameterTemplate)row;
                intTop = pt.intTop;
            }
            else if (row is SectionTemplate)
            {
                var st = (SectionTemplate)row;
                intTop = st.intTop ?? 0;
            }
            else if (row is Label)
            {
                var l = (Label)row;
                intTop = l.intTop;
            }
            return intTop;
        }

        private static int CompareParameterHostDataRows(object row1, object row2)
        {
            var t1 = GetIntTop(row1); 
            var t2 = GetIntTop(row2);
            return (Convert.ToInt32(t1) - Convert.ToInt32(t2));
        }

        private const string TopAbsoluteColumnName = "TopAbsolute";

        private static int GetTopParentSection(Template template, long idfsSection)
        {
            var result = 0;
            var section = template.SectionTemplatesLookup.FirstOrDefault(c => c.idfsSection == idfsSection);
            if (section != null)
            {
                result = section.intTop ?? 0;
                if (section.idfsParentSection.HasValue)
                {
                    result += GetTopParentSection(template, section.idfsParentSection.Value);
                }
            }
            return result;
        }

        /// <summary>
        /// Рассчитывает сводные данные, заполняя табличные секции предустановленными боковиками, по текущей стране
        /// </summary>
        /// <param name="observations">Коллекция ID сущностей (observation)</param>
        /// <param name="formType">ID типа формы</param>
        public void LoadSummary(List<long> observations, FFTypeEnum formType)
        {
            Model.FormType = (long) formType;
            Model.PrepareSummary(observations);
            /*
            if (observations == null) return;

            IdfsFormTemplate = IdfsFormTemplateSummary;
            //обнуляем эти свойства, потому что в саммари участвует несколько Observation и у каждого может быть своя версия боковика и шаблона
            VersionMatrixStub = null;
            var idfsFormType = (long)formType;
            //получим информацию по всему шаблону
            SetActualTemplate(0, idfsFormType, 0);

            //загружаем структуру
            MergeTemplates(MainDbService.IdfsFormTemplateSummary, observations, formType);
            var observationsRows = MainDbService.LoadObservations(observations);

            //загружаем данные
            //загрузим пользовательские данные
            foreach (var observationsRow in observationsRows)
            {
                if (observationsRow.IsidfsFormTemplateNull()) continue;
                MainDbService.LoadUserData(observationsRow.idfObservation, observationsRow.idfsFormTemplate, true);
            }

            //надо рассчитать сумму данных и заложить её в фиктивный ObservationSummary, а затем показывать его
            //суммировать можно только те параметры, у которых тип Numeric. Остальные игнорировать (Михаил, 11.01.2010).
            //суммируется только тело таблицы, боковик не учитывается
            //в дальнейшем суммированные данные не сохраняются

            //расчёт summary
            var lst = new List<long>();
            lst.AddRange(observations);
            MainDbService.CalculateSummary(lst);
            List<FlexibleFormsDS.PredefinedStubRow> predefinedStubRows;

            MainDbService.IncludeStubDataInUserData(IdfsFormTemplate, IdfObservationSummary, null, null, out predefinedStubRows);

            //загружаем структуру шаблона
            MainDbService.LoadSections(idfsFormType, null, null);
            MainDbService.LoadParameters(idfsFormType, null);
            MainDbService.LoadSectionTemplate(IdfsFormTemplate);
            MainDbService.LoadParameterTemplate(IdfsFormTemplate);
            */
        }

        /*
        /// <summary>
        /// Загружает инфраструктуру шаблона
        /// </summary>
        /// <param name="idFormTemplate"></param>
        /// <param name="observation"></param>
        /// <param name="formType"></param>
        public void LoadAggregateTemplate(long idFormTemplate, long observation, FFTypeEnum formType)
        {
            LoadTemplate(formType, idFormTemplate, new List<long> { observation });
        }
        */

        /// <summary>
        /// Загружает инфраструктуру шаблона
        /// </summary>
        /// <param name="observations"></param>
        /// <param name="formType"></param>
        /// <param name="secondDeterminant">Диагноз или Тип теста</param>
        public void LoadTemplate(List<long> observations, long? secondDeterminant, FFTypeEnum formType)
        {
            LoadTemplate(formType, EidssSiteContext.Instance.CountryID, secondDeterminant, observations);
        }

        public void LoadTemplate(List<long> observations, long idfsFormTemplate)
        {
            Model.SetProperties(FFPresenterModel.LoadActualTemplate(idfsFormTemplate), observations, 0);
        }

        /// <summary>
        /// Загружает инфраструктуру шаблона
        /// </summary>
        /// <param name="formType">Тип формы</param>
        /// <param name="countryDeterminant">Детерминант-страна</param>
        /// <param name="secondDeterminant">Детерминант диагноз или тест</param>
        /// <param name="observationList">Перечень observation</param>
        private void LoadTemplate(FFTypeEnum formType, long countryDeterminant, long? secondDeterminant, List<long> observationList)
        {
            IdfsFormTemplate = null;

            Model.SetProperties(countryDeterminant, secondDeterminant, formType, observationList, 0);
            //если нет ни одной строки, то никакого шаблона не удалось найти (ни обычного, ни UNI)
            IdfsFormTemplate = Model.CurrentTemplate != null ? (long?) Model.CurrentTemplate.idfsFormTemplate : null;
        }

        /*
        /// <summary>
        /// Загружает инфраструктуру шаблона
        /// </summary>
        /// <param name="formType">Тип формы</param>
        /// <param name="idFormTemplate">Шаблон, который требуется загрузить</param>
        /// <param name="observationList">Перечень observation</param>
        internal void LoadTemplate(FFType formType, long idFormTemplate, List<long> observationList)
        {
            if (observationList == null) return;

            IdfsFormTemplate = idFormTemplate;

            //получим информацию по всему шаблону
            var idfsFormType = (long)formType;
            SetActualTemplate(idFormTemplate, idfsFormType, observationList.Count == 1 ? observationList[0] : 0);

            //загружаем структуру шаблона
            MainDbService.LoadSections(idfsFormType, null, null);
            MainDbService.LoadParameters(idfsFormType, null);
            MainDbService.LoadSectionTemplate(IdfsFormTemplate);
            MainDbService.LoadParameterTemplate(IdfsFormTemplate);

            //MainDbService.LoadLines(IdfsFormTemplate);
            MainDbService.LoadLabels(IdfsFormTemplate.Value);

            //информация по секции вернётся только тогда, когда работаем с аг. секциями
            List<long> presetStubs = null;
            long? idfsSection;
            long? idfsMatrixType;
            MainDbService.GetSectionForAggregateCase(IdfsFormTemplate, idfsFormType, out idfsSection, out idfsMatrixType);
            if (idfsSection.HasValue) presetStubs = new List<long>(1) { idfsSection.Value };

            //для всех заданных observation загрузим пользовательские данные
            foreach (var idfObservation in observationList)
            {
                MainDbService.LoadUserData(idfObservation, IdfsFormTemplate.Value, true);
                //если есть предустановленный боковик, то дополним пользовательские данные его данными
                if (presetStubs == null) continue;

                //получаем информацию о версии матрицы боковика
                var matrixVersionRow = MainDbService.LoadMatrixStubInfo(idfObservation);
                //если не удалось найти матрицу (например, она ещё не заведена), то ищем в других Observation
                if (matrixVersionRow == null) continue;
                if (matrixVersionRow.IsidfVersionNull()) continue;
                if ((matrixVersionRow.idfVersion > 0) && idfsMatrixType.HasValue)
                {
                    //обработаем загруженный боковик
                    presetStubs.IncludeStub(MainDbService, IdfsFormTemplate.Value, matrixVersionRow.idfVersion, idfsMatrixType.Value);
                }

                var predefinedStubRows = MainDbService.GetPredefinedStubRows(matrixVersionRow.idfVersion);
                foreach (var predefinedStubRow in predefinedStubRows)
                {
                    MainDbService.MainDataSet.ActivityParameters.RenumActivityParameters(predefinedStubRow, idfObservation);
                    MainDbService.ChangeValue(idfObservation, IdfsFormTemplate.Value, predefinedStubRow.idfsParameter, predefinedStubRow.idfRow, predefinedStubRow.NumRow, predefinedStubRow.idfsParameterValue, predefinedStubRow.strNameValue);
                }
            }
        }
        */

        /// <summary>
        /// Получение структуры шаблона древовидно (шаблон уже должен быть загружен)
        /// </summary>
        /// <returns></returns>
        public FlexNodeReport GetFlexNodeFromTemplate(bool needRecalculateNode)
        {
            var flexNodeFF = needRecalculateNode ? Model.CreateFlexNodeForTemplate() : Model.TemplateFlexNode;
            var flexNodeReport = FlexNodesHelper.ConvertNode(flexNodeFF, Model.ActivityParameters);
            //получаем шаблон, связанный с Observation

            if (Model.CurrentObservation.HasValue)
            {
                /*
                //начинаем с корня шаблона и внутрь
                FillFlexNodeForSection(rootNode, null, observationsRow.idfObservation, observationsRow.idfsFormTemplate);

                //добавим раздел с динамическими параметрами
                var parametersTable = MainDbService.LoadParameterDeletedFromTemplate(idfObservation, null, null);
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
                        dynamicGroup.Add(rowParameter, MainDbService.GetActivityParametersRow(idfObservation, rowParameter.idfsParameter, null), out size);
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
                */
                //для каждой табличной секции верхнего уровня, входящей в шаблон, подцепим таблицу с данными
                AddDataTable(flexNodeReport, Model.CurrentObservation.Value);
            }
            return flexNodeReport;
        }

        /*
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
        */

        /// <summary>
        /// Собирает рекурсивно все нижележащие параметры, которые уже отсортированы по порядку следования
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="parameters"></param>
        private void CollectParametersUnderSection(FlexNodeReport parentNode, List<Tuple<long, string>> parameters)
        {
            if (parentNode.DataItem != null)
            {
                var parameterTemplateRow = parentNode.DataItem.LinkedObject as ParameterTemplate;
                if (parameterTemplateRow != null)
                {
                    parameters.Add(new Tuple<long, string>(parameterTemplateRow.idfsParameter, parameterTemplateRow.NationalName));
                }
                else
                {
                    var ps = parentNode.DataItem.LinkedObject as PredefinedStub;
                    if (ps != null && ps.idfsParameter.HasValue)
                    {
                        parameters.Add(new Tuple<long, string>(ps.idfsParameter.Value, ps.strNameValue));
                    }
                }
            }
            //рекурсивно по всем потомкам
            foreach (var childNode in parentNode.ChildList)
            {
                CollectParametersUnderSection((FlexNodeReport)childNode, parameters);
            }
        }

        /// <summary>
        /// Получает таблицу для шаблона в TemplateHelper
        /// </summary>
        private DataTable GetDataTableForTemplate(long idfObservation, List<Tuple<long, string>> parameters)
        {
            //шаблон должен быть загружен, данные получены
            //столбцами результирующей таблицы являются все параметры для указанного шаблона.
            //строками таблицы являются все найденные idfRow для данного Observation
            //пустые данные заполняются DBNull.Value
            var resultTable = new DataTable();
            if (parameters.Count > 0 && Model.ActivityParameters.Count > 0)
            {
                foreach (var parameterRow in parameters)
                {
                    var column = new DataColumn(parameterRow.Item1.ToString(), typeof(string))
                    {
                        Caption = parameterRow.Item2,
                        AllowDBNull = true,
                        DefaultValue = DBNull.Value
                    };
                    resultTable.Columns.Add(column);
                }

                foreach (var activityParametersRow in Model.ActivityParameters)
                {
                    //если не удалось свести с номером строки, то значит какие-то проблемы или изменения с матрицей, и игнорируем эту строку
                    if (!activityParametersRow.intNumRow.HasValue) continue;
                    //добавляем столько строк, чтобы хватило для размещения добавляемой строки
                    var cnt = activityParametersRow.intNumRow.Value + 1;
                    if (cnt > resultTable.Rows.Count)
                    {
                        for (var i = resultTable.Rows.Count; i < cnt; i++)
                        {
                            resultTable.Rows.Add(resultTable.NewRow());
                        }
                    }

                    var row = resultTable.Rows[activityParametersRow.intNumRow.Value];

                    foreach (var parameterRow in parameters)
                    {
                        var rowValue = Model.ActivityParameters.FirstOrDefault(
                            c => c.idfObservation.HasValue && c.idfsParameter.HasValue && c.idfRow.HasValue
                                 &&
                                 c.idfObservation.Value == idfObservation
                                 && c.idfsParameter.Value == parameterRow.Item1
                                 && c.idfRow.Value == activityParametersRow.idfRow
                            );
                        if (rowValue == null) continue;

                        //переводим даты в правильный формат
                        if (rowValue.varValue is DateTime)
                        {
                            var destFormat = (CultureInfo.CurrentCulture).DateTimeFormat.ShortDatePattern;
                            rowValue.strNameValue = ((DateTime) rowValue.varValue).ToString(destFormat,
                                CultureInfo.InvariantCulture);
                        }
                        row[parameterRow.Item1.ToString()] = rowValue.strNameValue.Length > 0
                            ? rowValue.strNameValue
                            : rowValue.varValue;
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
        private int CalculateWidthTotal(FlexNodeReport parentNode)
        {
            var result = 0;
            if (parentNode.ChildListCount > 0)
            {
                result += parentNode.ChildList.Sum(node => CalculateWidthTotal((FlexNodeReport) node));
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
        private void AddDataTable(FlexNodeReport parentNode, long idfObservation)
        {
            //если была создана табличная секция и она верхнего уровня (т.е. над ней нет других табличных секций), то
            //именно она будет нести пользовательские данные
            if (parentNode == null) return;
            var flexTableItem = parentNode.DataItem as FlexTableItem;
            if (flexTableItem != null && !(parentNode.ParentNode.DataItem is FlexTableItem))
            {
                //собираем рекурсивно все нижележащие параметры, которые уже отсортированы по порядку следования
                var parameters = new List<Tuple<long, string>>();
                CollectParametersUnderSection(parentNode, parameters);
                flexTableItem.BodyData = GetDataTableForTemplate(idfObservation, parameters);
                //вычисляем актуальную ширину этой секции как совокупность ширин входящих в неё объектов
                flexTableItem.Width = CalculateWidthTotal(parentNode);
            }
            //рекурсивно по всем потомкам
            foreach (var childNode in parentNode.ChildList)
            {
                AddDataTable((FlexNodeReport)childNode, idfObservation);
            }
        }

        /*
        /// <summary>
        /// Создаёт узел с тем, что лежит в секции и рекурсивно по всем секциям внутри неё. Если секция не указана, то создаётся то, что лежит в корне шаблона.
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="idfsParentSection"></param>
        /// <param name="idfObservation"></param>
        /// <param name="idfsFormTemplate"></param>
        /// <returns></returns>
        private void FillFlexNodeForSection(FlexNode parentNode
                                            , long? idfsParentSection
                                            , long idfObservation
                                            , long idfsFormTemplate
                                            )
        {
            //определяем объекты, которые входят в родительскую секцию
            var sectionTemplateRows = MainDbService.GetSectionTemplateChildrenRows(idfsParentSection, idfsFormTemplate);
            var parameterTemplateRows = MainDbService.GetParameterTemplateChildrenRows(idfsParentSection, idfsFormTemplate);
            var labelsRows = MainDbService.GetLabelsTemplateChildrenRows(idfsParentSection, idfsFormTemplate);
            var linesRows = MainDbService.GetLinesTemplateChildrenRows(idfsParentSection, idfsFormTemplate);

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
                if (parameterTemplateRow.IsidfsSectionNull() || (!parameterTemplateRow.IsidfsSectionNull() && !MainDbService.IsSectionTable(parameterTemplateRow.idfsSection)))
                {
                    //находим значение для этого параметра, добавляем сам параметр
                    parentNode.Add(parameterTemplateRow, MainDbService.GetActivityParametersRow(idfObservation, parameterTemplateRow.idfsParameter, null));
                }
                else
                {
                    bool isSummaryTemplate = idfsFormTemplate.Equals(MainDbService.IdfsFormTemplateSummary);
                    if (isSummaryTemplate && !MainDbService.IsParameterNumeric(parameterTemplateRow.idfsParameter) && (parameterTemplateRow.intOrder > 0)) continue;

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
        */

    }
}
