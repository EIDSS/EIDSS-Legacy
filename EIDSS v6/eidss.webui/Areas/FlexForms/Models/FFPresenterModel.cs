using System.Collections.Generic;
using BLToolkit.EditableObjects;
using eidss.model.Schema;
using eidss.webui.Areas.FlexForms.Models.FlexNodes;

namespace eidss.webui.Areas.FlexForms.Models
{
    public sealed class FFPresenterModel
    {
        /// <summary>
        /// 
        /// </summary>
        public Template CurrentTemplate { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public long? CurrentObservation { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public FFPresenterModel()
        {
            ParameterList = new List<ParameterTemplate>();
            SectionList = new List<SectionTemplate>();
        }

        /// <summary>
        /// Содержит перечень отрендеренных параметров
        /// </summary>
        public List<ParameterTemplate> ParameterList { get; private set; }

        /// <summary>
        /// Содержит перечень отрендеренных секций
        /// </summary>
        public List<SectionTemplate> SectionList { get; private set; }

        public FlexNode TemplateFlexNode { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="activityParameters"></param>
        public void SetActivityParameters(EditableList<ActivityParameter> activityParameters)
        {
            //TODO нужен ли этот метод? Сохранение при задании нового списка данных?
            ActivityParameters = activityParameters;
        }

        /// <summary>
        /// Пользовательские данные
        /// </summary>
        public EditableList<ActivityParameter> ActivityParameters { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="template"></param>
        /// <param name="idfObservation"></param>
        /// <param name="activityParameters"></param>
        public void SetProperties(Template template, long? idfObservation, EditableList<ActivityParameter> activityParameters)
        {
            CurrentTemplate = template;
            TemplateFlexNode = template.CreateFlexNodeForTemplate(idfObservation, activityParameters);
            CurrentObservation = idfObservation;
            SetActivityParameters(activityParameters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="template"></param>
        /// <param name="activityParameters"></param>
        public void SetProperties(Template template, EditableList<ActivityParameter> activityParameters)
        {
            SetProperties(template, null, activityParameters);
        }
    }
}