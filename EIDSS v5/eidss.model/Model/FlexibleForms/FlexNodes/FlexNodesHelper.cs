using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BLToolkit.EditableObjects;
using bv.model.Model.Core;
using eidss.model.FlexibleForms.Helpers;
using eidss.model.Model.FlexibleForms.Helpers;
using eidss.model.Schema;
using System.Linq;

namespace eidss.model.Model.FlexibleForms.FlexNodes
{
    /// <summary>
    /// 
    /// </summary>
    public static class FlexNodesHelper
    {
        /// <summary>
        /// Для указанной табличной секции 
        /// </summary>
        /// <param name="sectionNode"></param>
        /// <param name="activityParameters"></param>
        /// <returns></returns>
        public static int GetNumForNewRow(this FlexNode sectionNode, EditableList<ActivityParameter> activityParameters)
        {
            var idParameters = sectionNode.GetIDParametersForSection();
            var numRow = 0;
            var findedRows = 0;
            foreach (var ap in activityParameters)
            {
                if (ap.IsMarkedToDelete) continue;
                if (!ap.idfsParameter.HasValue || !ap.intNumRow.HasValue) continue;
                if (!idParameters.Contains(ap.idfsParameter.Value)) continue;
                if (ap.intNumRow > numRow) numRow = ap.intNumRow.Value;
                findedRows++;
            }
            if (findedRows > 0) numRow++;
            return numRow;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="template"></param>
        /// <param name="idfObservation"></param>
        /// <param name="activityParameters"></param>
        /// <param name="predefinedStubRows"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static FlexNode CreateFlexNodeForTemplate(this Template template, long? idfObservation, EditableList<ActivityParameter> activityParameters, List<PredefinedStub> predefinedStubRows, FFPresenterModel model)
        {
            var rootNode = FlexNode.CreateRoot();
            rootNode.FormKey = idfObservation.HasValue
                                   ? DataHelper.GetFFParameterKey(template.idfsFormTemplate, idfObservation.Value)
                                   : DataHelper.GetFFParameterSimpleKey(template.idfsFormTemplate);
            //начинаем с корня шаблона и внутрь
            CreateFlexNodeForSection(rootNode, null, template, activityParameters, predefinedStubRows, model);
            //TODO добавить динамические параметры
            
            //рекурсивная сортировка узлов
            //TODO нужен ли дополнительный Order в корне или можно использовать DataItem.Order
            rootNode.SortRecursive();

            return rootNode;
        }

        /// <summary>
        /// Создаёт образ шаблона в древовидной форме
        /// </summary>
        /// <param name="template"></param>
        /// <param name="idfObservation"></param>
        /// <param name="activityParameters"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static FlexNode CreateFlexNodeForTemplate(this Template template, long? idfObservation, EditableList<ActivityParameter> activityParameters, FFPresenterModel model)
        {
            return template.CreateFlexNodeForTemplate(idfObservation, activityParameters, null, model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="parentSection"></param>
        /// <param name="template"></param>
        /// <param name="activityParameters"></param>
        /// <param name="predefinedStubRows"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        private static void CreateFlexNodeForSection(FlexNode parentNode, SectionTemplate parentSection, Template template, EditableList<ActivityParameter> activityParameters, List<PredefinedStub> predefinedStubRows, FFPresenterModel model)
        {
            //для табличной секции верхнего уровня следует добавить пользовательские данные

            var sectionList = parentSection != null
                                  ? template.GetSectionTemplateChildren(parentSection)
                                  : template.GetSectionTemplateRoot();

            var parameterList = parentSection != null
                                    ? template.GetParameterTemplateChildren(parentSection)
                                    : template.GetParameterTemplateRoot();

            var labelList = parentSection != null
                                    ? template.GetLabelChildren(parentSection)
                                    : template.GetLabelRoot();

            //рекурсивно транслируем в узлы каждую секцию с её содержимым
            foreach (var sectionTemplate in sectionList)
            {
                FlexNode node;
                if (sectionTemplate.blnGrid && (parentSection == null) && (predefinedStubRows != null))
                {
                    node = parentNode.Add(sectionTemplate, activityParameters, model);

                    #region Добавление параметров-столбцов боковика

                    //параметры боковика не имеют секции над собой, всегда крайние слева
                    //вынимаем уникальные параметры из данных боковика (spGetPredefinedStub)
                    var usedParams = new List<long>();
                    //for (var index = predefinedStubRows.Count - 1; index >= 0; index--)
                    var nodes = new List<FlexNode>();
                    foreach (var predefinedStubRow in predefinedStubRows)
                    {
                        if (!predefinedStubRow.idfsParameter.HasValue) continue;
                        if (usedParams.Contains(predefinedStubRow.idfsParameter.Value)) continue;
                        usedParams.Add(predefinedStubRow.idfsParameter.Value);
                        predefinedStubRow.intOrder = usedParams.Count - 1;
                        var nodePred = node.Add(predefinedStubRow, null, predefinedStubRow.intOrder, model);
                        nodePred.Order = predefinedStubRow.intOrder;
                        nodes.Add(nodePred);
                    }
                    //у каждого нода боковика должен быть отрицательный индекс в порядке возрастания
                    for (var index = 0; index < nodes.Count; index++)
                    {
                        nodes[index].Order = index - nodes.Count;
                    }

                    #endregion
                }
                else
                {
                    node = parentNode.Add(sectionTemplate, activityParameters, model);
                }
                if (sectionTemplate.intOrder.HasValue) node.Order = sectionTemplate.intOrder.Value;
                node.FormKey = parentNode.FormKey;

                CreateFlexNodeForSection(node, sectionTemplate, template, activityParameters, predefinedStubRows, model);
            }

            //транслируем все параметры, находящиеся на этом уровне
            foreach (var parameterTemplate in parameterList)
            {
                var node = parentNode.Add(parameterTemplate, activityParameters, model);
                node.FormKey = parentNode.FormKey;
                node.Order = parameterTemplate.intOrder;
            }

            //транслируем лейблы
            foreach (var label in labelList)
            {
                parentNode.Add(label, model);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static string GetColumnName(long id)
        {
            return String.Format("col{0}", id);
        }

        /// <summary>
        /// Название столбца, где располагаются вспомогательные radiobutton для динамических табличных секций
        /// </summary>
        public static string GetRadioButtonColumnName
        {
            get { return "radioButtonColumn"; }
        }

        /// <summary>
        /// Возвращает перечень idfsParameter, которые входят в эту секцию
        /// </summary>
        /// <param name="sectionNode"></param>
        /// <returns></returns>
        public static List<long> GetIDParametersForSection(this FlexNode sectionNode)
        {
            //параметры станут столбцами
            var parameterTemplates = sectionNode.GetParameterTemplateForDataTable();
            var predefinedStubs = sectionNode.GetPredefinedStubsForDataTable();
            var idParameters = parameterTemplates.Select(parameter => parameter.idfsParameter).ToList();
            foreach (var ps in predefinedStubs)
            {
                if (ps.idfsParameter.HasValue) idParameters.Add(ps.idfsParameter.Value);
            }
            return idParameters;
        }

        /// <summary>
        /// Формирует таблицу данных исходя из табличной секции верхнего уровня
        /// </summary>
        /// <param name="sectionNode"></param>
        /// <returns></returns>
        public static DataTable GetDataTableForSectionTable(this FlexNode sectionNode)
        {
            var section = sectionNode.GetSectionTemplate();
            if (section == null) return null;
            if (!section.blnGrid) return null;

            const string paramKey = "idfsParameter";
            const string typeKey = "columnType";
            const string widthKey = "width";
            const string sectionKey = "idfsSection";
            const string parameterTemplateKey = "parameterTemplate";

            var resultTable = new DataTable();
            
            //параметры станут столбцами
            var parameterTemplates = sectionNode.GetParameterTemplateForDataTable();
            //TODO проверить, не сломалось ли в других местах
            //parameterTemplates.Sort(new ParameterTemplateComparer());
            var predefinedStubs = sectionNode.GetPredefinedStubsForDataTable();
            predefinedStubs.Sort(new PredefinedStubComparer());
            
            var columnInfo = new List<IObject>();
            columnInfo.AddRange(predefinedStubs);
            columnInfo.AddRange(parameterTemplates);

            var idParameters = sectionNode.GetIDParametersForSection();
            
            //формируем остальные столбцы
            foreach (var columnInfoItem in columnInfo)
            {
                //могут быть только числовые или текстовые параметры
                //боковик не участвует в установке типа
                
                var columnName = String.Empty;
                var nationalName = String.Empty;
                var type = typeof (String);
                long idfsParameter = 0;
                var columnType = 0; //0-ParameterTemplate, 1- PredefinedStub
                var width = 0;
                long idfsSection = 0;
                var parameterTemplate = columnInfoItem as ParameterTemplate;
                
                if (parameterTemplate != null)
                {
                    //для Summary надо отбирать только числовые параметры
                    if (parameterTemplate.IsParameterNumericPositive())
                    {
                        type = typeof(Double);
                    }
                    else if (parameterTemplate.IsParameterNumeric())
                    {
                        type = typeof(Int32);
                    }
                    else if (sectionNode.FFModel.IsSummary) continue;
                
                    columnName = GetColumnName(parameterTemplate.idfsParameter);//parameterTemplate.DefaultName;
                    nationalName = parameterTemplate.NationalName;
                    idfsParameter = parameterTemplate.idfsParameter;
                    columnType = 0;
                    width = parameterTemplate.intWidth;
                    if (parameterTemplate.idfsSection.HasValue) idfsSection = parameterTemplate.idfsSection.Value;
                }
                else
                {
                    var predefinedStub = columnInfoItem as PredefinedStub;
                    if ((predefinedStub != null) && (predefinedStub.idfsParameter.HasValue))
                    {
                        columnName = GetColumnName(predefinedStub.idfsParameter.Value);//predefinedStub.strDefaultParameterName; 
                        nationalName = predefinedStub.strDefaultParameterName;
                        idfsParameter = predefinedStub.idfsParameter.Value;
                        columnType = 1;
                        width = 80; //??
                    }
                }

                if (idfsParameter > 0)
                {
                    var column = new DataColumn(columnName, type) {Caption = nationalName};
                    column.ExtendedProperties.Add(paramKey, idfsParameter);
                    column.ExtendedProperties.Add(typeKey, columnType);
                    column.ExtendedProperties.Add(widthKey, width);
                    column.ExtendedProperties.Add(sectionKey, idfsSection);
                    if (parameterTemplate != null)
                        column.ExtendedProperties.Add(parameterTemplateKey, parameterTemplate);
                    resultTable.Columns.Add(column);
                }
            }

            //добавляем специальный столбец с ID строк
            resultTable.Columns.Add(new DataColumn("idfRow", typeof(Int64)) {Caption = "idfRow"});

            //подставляем пользовательские данные
            if ((sectionNode.ActivityParameters != null) && (sectionNode.ActivityParameters.Count > 0))
            {
                //заполняем сначала все строки
                var activityParametersAll = sectionNode.ActivityParameters;
                activityParametersAll.Sort(new ActivityParametersComparer());
                var rowList = new List<DataRow>();
                foreach (var activityParameter in activityParametersAll)
                {
                    if (activityParameter.IsMarkedToDelete) continue;
                    if (!activityParameter.idfsParameter.HasValue) continue;
                    //проверяем, находится ли параметр в этой таблице (может быть как тело таблицы, так и боковик)
                    if (!idParameters.Contains(activityParameter.idfsParameter.Value)) continue;
                    var row = resultTable.NewRow();
                    var idfRow = activityParameter.idfRow;
                    var finded = false;
                    foreach (var dataRow in rowList)
                    {
                        if (!idfRow.HasValue) continue;
                        if (Convert.ToInt64(dataRow["idfRow"]) == idfRow.Value)
                        {
                            finded = true;
                            break;
                        }
                    }
                    if (finded) continue;
                    //if (resultTable.Select(String.Format("idfRow={0}", idfRow)).Length > 0) continue;
                    row["idfRow"] = idfRow;
                    rowList.Add(row);
                    //resultTable.Rows.Add(row);
                }

                //теперь распихиваем остальные данные по строкам и столбцам
                foreach (var row in /*resultTable.Rows*/ rowList)
                {
                    var idfRow = Convert.ToInt64(row["idfRow"]);
                    var activityParameters = sectionNode.ActivityParameters.Where(ap => ap.idfRow.HasValue && (ap.idfRow.Value == idfRow)).ToList();
                    if (activityParameters.Count == 0) continue;
                    //построчно переносим все значения
                    foreach (DataColumn column in resultTable.Columns)
                    {
                        if ((!column.ExtendedProperties.ContainsKey(typeKey)) 
                            ||(!column.ExtendedProperties.ContainsKey(paramKey))) continue;

                        //var otkey = column.ExtendedProperties[typeKey];
                        var opkey = column.ExtendedProperties[paramKey];
                        //if ((otkey == null) || (opkey == null)) continue;
                        if (opkey == null) continue;
                        var idfsParameter = Convert.ToInt64(opkey);
                        var ap = activityParameters.FirstOrDefault(a => a.idfsParameter == idfsParameter);
                        if ((ap != null) && !ap.IsMarkedToDelete)
                        {
                            object value;
                            if (ap.strNameValue.Length > 0)
                            {
                                value = ap.strNameValue;
                            }
                            else
                            {
                                value = ap.varValue ?? String.Empty;
                                int i;
                                if (Int32.TryParse(value.ToString(), out i))
                                {
                                    value = i;
                                    if (i == 0) value = String.Empty;
                                }
                            }

                            var strValue = value.ToString();
                            if (strValue.Length > 0)
                            {
                                //уточняем формат выводимых дат
                                if (column.ExtendedProperties.Contains(parameterTemplateKey))
                                {
                                    var pt = column.ExtendedProperties[parameterTemplateKey] as ParameterTemplate;
                                    if ((pt != null) && pt.IsParameterDate())
                                    {
                                        var sp = strValue.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                                        if (sp.Length > 0) strValue = sp[0];
                                    }
                                }

                                row[GetColumnName(idfsParameter)] = strValue;
                            }
                        }
                    }
                }

                //сортируем, упорядочивая по номерам строк. Это актуально для динамических таблиц.
                if (!section.IsFixedStubSection)
                {
                    rowList.Sort(new ActivityParametersRowsComparer());
                }
                foreach (var dataRow in rowList)
                {
                    resultTable.Rows.Add(dataRow);
                }
            }

            return resultTable;
        }

        /// <summary>
        /// Отыскивает узел, который является секцией с указанным ID
        /// </summary>
        /// <param name="node"></param>
        /// <param name="idfsSection"></param>
        /// <returns></returns>
        public static FlexNode FindChildNodeSection(this FlexNode node, long idfsSection)
        {
            FlexNode result = null;
            var section = node.GetSectionTemplate();
            if (section != null)
            {
                if (section.idfsSection == idfsSection) result = node;
                if ((result == null) && (node.ChildListCount > 0))
                {
                    foreach (var nodeChild in node.ChildList)
                    {
                        result = nodeChild.FindChildNodeSection(idfsSection);
                        if (result != null) break;
                    }
                }
            }
            else
            {
                foreach (var nodeChild in node.ChildList)
                {
                    result = nodeChild.FindChildNodeSection(idfsSection);
                    if (result != null) break;
                }
            }
            return result;
        }

        /// <summary>
        /// Возвращает полный путь к ноду
        /// </summary>
        /// <param name="node"></param>
        /// <param name="withoutTopNode">true-в путь собирается всё, кроме верхнего узла</param>
        /// <returns></returns>
        public static string GetFullPathForNode(this FlexNode node, bool withoutTopNode)
        {
            return CollectPath(node, new StringBuilder(), withoutTopNode);
        }

        /// <summary>
        /// Рекурсивная функция для сбора пути до узла
        /// </summary>
        /// <param name="node"></param>
        /// <param name="sbPath"></param>
        /// <param name="withoutTopNode">true-в путь собирается всё, кроме верхнего узла</param>
        /// <returns></returns>
        private static string CollectPath(FlexNode node, StringBuilder sbPath, bool withoutTopNode)
        {
            if (node.Level == 1)
            {
                if (!withoutTopNode) sbPath.Insert(0, node.Text, 1);
                var result = sbPath.ToString();
                return result.Substring(DelimiterPath.Length, result.Length - DelimiterPath.Length);
            }
            sbPath.Insert(0, node.Text, 1);
            return CollectPath(node.ParentNode, sbPath.Insert(0, DelimiterPath, 1), withoutTopNode);
        }

        /// <summary>
        /// Разделитель, использующийся при генерации строки, содержащей полный путь к узлу в дереве
        /// </summary>
        private const string DelimiterPath = "->";
    }
}