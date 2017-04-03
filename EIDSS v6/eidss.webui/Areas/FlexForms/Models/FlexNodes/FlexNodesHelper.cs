using BLToolkit.EditableObjects;
using eidss.model.FlexibleForms.Helpers;
using eidss.model.Schema;
using eidss.webui.Areas.FlexForms.Helpers;

namespace eidss.webui.Areas.FlexForms.Models.FlexNodes
{
    /// <summary>
    /// 
    /// </summary>
    public static class FlexNodesHelper
    {
        /// <summary>
        /// Создаёт образ шаблона в древовидной форме
        /// </summary>
        /// <param name="template"></param>
        /// <param name="idfObservation"></param>
        /// <param name="activityParameters"></param>
        /// <returns></returns>
        public static FlexNode CreateFlexNodeForTemplate(this Template template, long? idfObservation, EditableList<ActivityParameter> activityParameters)
        {
            var rootNode = FlexNode.CreateRoot();
            rootNode.FormKey = idfObservation.HasValue
                                   ?  DataHelper.GetFFParameterKey(template.idfsFormTemplate, idfObservation.Value)
                                   :  DataHelper.GetFFParameterSimpleKey(template.idfsFormTemplate);
            //начинаем с корня шаблона и внутрь
            CreateFlexNodeForSection(rootNode, null, template, activityParameters);
            //TODO добавить динамические параметры
            //TODO ??? добавить данные для табличных секций

            return rootNode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="parentSection"></param>
        /// <param name="template"></param>
        /// <param name="activityParameters"></param>
        /// <returns></returns>
        private static void CreateFlexNodeForSection(FlexNode parentNode, SectionTemplate parentSection, Template template, EditableList<ActivityParameter> activityParameters)
        {
            //TODO возможно нужно добавить сюда activityparameters для данных
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
                var node = parentNode.Add(sectionTemplate);
                node.FormKey = parentNode.FormKey;
                CreateFlexNodeForSection(node, sectionTemplate, template, activityParameters);
            }

            //транслируем все параметры, находящиеся на этом уровне
            foreach (var parameterTemplate in parameterList)
            {
                //обрабатываем параметры, не входящие в таблицы
                if (!parameterTemplate.IsParentSectionTable())
                {
                    //находим значение для этого параметра, добавляем сам параметр
                    //TODO добавлять данные
                    var node = parentNode.Add(parameterTemplate, activityParameters);//, DataHelper.GetActivityParametersRow(mainDbService, idfObservation, parameterTemplateRow.idfsParameter, null));
                    node.FormKey = parentNode.FormKey;
                }
                else
                {
                    //TODO как добавлять табличные секции и параметры, которые входят в табличную секцию
                    //bool isSummaryTemplate = idfsFormTemplate.Equals(mainDbService.IdfsFormTemplateSummary);
                    //if (isSummaryTemplate && !HelperFunctions.IsParameterNumeric(mainDbService, parameterTemplateRow.idfsParameter) && (parameterTemplateRow.intOrder > 0)) continue;

                    ////в табличных секциях осуществляем перевод параметра в лейбл без значения
                    //parentNode.Add(parameterTemplateRow, true);
                }
            }

            //транслируем лейблы
            foreach (var label in labelList)
            {
                parentNode.Add(label);
            }
        }
    }
}