using System.Collections.Generic;
using System.Linq;
using BLToolkit.EditableObjects;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Enums;
using eidss.model.Schema;

namespace eidss.model.FlexibleForms.Helpers
{
    public static class FFHelper
    {
        public static string COPIED_PRESENTER_STORAGE_KEY = "BUFFERED_FFPRESENTER";

        /// <summary>
        /// Возвращает те секции, которые относятся к указанной секции
        /// </summary>
        /// <param name="template"></param>
        /// <param name="sectionTemplate"></param>
        public static IEnumerable<SectionTemplate> GetSectionTemplateChildren(this Template template, SectionTemplate sectionTemplate)
        {
            return template.SectionTemplates.Where(c => (c.ParentSection != null) && (c.ParentSection.idfsSection == sectionTemplate.idfsSection));
        }

        /// <summary>
        /// Возвращает те параметры, которые относятся к указанной секции
        /// </summary>
        /// <param name="template"></param>
        /// <param name="sectionTemplate"></param>
        public static IEnumerable<ParameterTemplate> GetParameterTemplateChildren(this Template template, SectionTemplate sectionTemplate)
        {
            return template.ParameterTemplates.Where(c => (c.ParentSection != null) && (c.ParentSection.idfsSection == sectionTemplate.idfsSection));
        }

        /// <summary>
        /// Возвращает те лейблы, которые относятся к указанной секции
        /// </summary>
        /// <param name="template"></param>
        /// <param name="sectionTemplate"></param>
        public static IEnumerable<Label> GetLabelChildren(this Template template, SectionTemplate sectionTemplate)
        {
            return template.Labels.Where(c => (c.idfsSection != null) && (c.idfsSection == sectionTemplate.idfsSection));
        }

        /// <summary>
        /// Возвращает параметры, которые находятся в корне шаблона (не в родительской секции)
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        public static IEnumerable<ParameterTemplate> GetParameterTemplateRoot(this Template template)
        {
            return template.ParameterTemplates.Where(c => c.ParentSection == null);
        }

        /// <summary>
        /// Возвращает лейблы, которые находятся в корне шаблона (не в родительской секции)
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        public static IEnumerable<Label> GetLabelRoot(this Template template)
        {
            return template.Labels.Where(c => c.idfsSection == null);
        }

        /// <summary>
        /// Возвращает секции, которые находятся в корне шаблона (не в родительской секции)
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        public static IEnumerable<SectionTemplate> GetSectionTemplateRoot(this Template template)
        {
            return template.SectionTemplates.Where(c => c.ParentSection == null);
        }


        /// <summary>
        /// Определяет, является ли для данного параметра родительская секция табличной (если она не существует, то не является)
        /// </summary>
        /// <param name="parameterTemplate"></param>
        /// <returns></returns>
        public static bool IsParentSectionTable(this ParameterTemplate parameterTemplate)
        {
            var result = false;

            if (parameterTemplate.ParentSection != null)
            {
                result = parameterTemplate.ParentSection.blnGrid;
            }

            return result;
        }

        /// <summary>
        /// Определяет, является ли для данной секции родительская секция табличной (если она не существует, то не является)
        /// </summary>
        /// <param name="sectionTemplate"></param>
        /// <returns></returns>
        public static bool IsParentSectionTable(this SectionTemplate sectionTemplate)
        {
            var result = false;

            if (sectionTemplate.ParentSection != null)
            {
                result = sectionTemplate.ParentSection.blnGrid;
            }

            return result;
        }

        public static bool IsAggForm(this Template template)
        {
            return template.idfsFormType.Equals((long)FFTypeEnum.HumanAggregateCase)
                   || template.idfsFormType.Equals((long)FFTypeEnum.VetAggregateCase)
                   || template.idfsFormType.Equals((long)FFTypeEnum.VetEpizooticActionDiagnosisInv)
                   || template.idfsFormType.Equals((long)FFTypeEnum.VetEpizooticActionTreatment)
                   || template.idfsFormType.Equals((long)FFTypeEnum.VetEpizooticAction);
        }

        public static ParametersDeletedFromTemplate CreateDeletedParameter(Parameter parameter, long idfObservation, long idfsFormTemplate)
        {
            var p = ParametersDeletedFromTemplate.CreateInstance();
            p.idfsParameter = parameter.idfsParameter;
            p.DefaultName = parameter.DefaultName;
            p.NationalName = parameter.NationalName;
            p.idfObservation = idfObservation;
            p.idfsEditor = parameter.idfsEditor;
            p.idfsFormTemplate = idfsFormTemplate;
            p.idfsParameterType = parameter.idfsParameterType;
            p.SelectList.AddRange(parameter.SelectList);
            return p;
        }

        public static List<ParametersDeletedFromTemplate> GetDeletedParameters(EditableList<ActivityParameter> activityParameters, long idfObservation, Template currentTemplate)
        {
            List<ParametersDeletedFromTemplate> deletedFromTemplates;
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var accessor = ParametersDeletedFromTemplate.Accessor.Instance(null);
                deletedFromTemplates = accessor.SelectList(manager, idfObservation).ToList();
                
                //определим, надо ли производить поиск среди пользовательских данных. Не надо для агг. случаев и саммари.
                //если есть хоть одна табличная секция, то это агг.случай или саммари
                if (!currentTemplate.IsAggForm())
                {
                    //также определим те данные, которые "лишние" для нового шаблона, но ещё не были сохранены в БД
                    var aps = activityParameters.Where(c => !Utils.IsEmpty(c.varValue)).ToList();
                    for (var i = aps.Count - 1; i >= 0; i--)
                    {
                        var idp = aps[i].idfsParameter;
                        //если и в новом шаблоне присутствует этот параметр, то он не считается удаленным/динамическим
                        //нужно присвоить ему ИД шаблона, чтобы он отобразился не в динамических параметрах, а на своём месте
                        var notDeletedNow = false;
                        if (currentTemplate.ParameterTemplates.Any(c => c.idfsParameter == idp))
                        {
                            var ap = activityParameters.FirstOrDefault(c => c.idfsParameter == idp);
                            if (ap != null)
                            {
                                //параметр теперь не динамический
                                ap.idfsFormTemplate = currentTemplate.idfsFormTemplate;
                                ap.IsDynamicParameter = false;
                                aps.RemoveAt(i);
                                notDeletedNow = true;
                            }
                        }

                        //также исключаем параметр, если он уже есть в удалённых
                        //может быть сценарий, когда его удалили и снова добавили
                        if (deletedFromTemplates.Any(c => c.idfsParameter == idp) && !notDeletedNow) aps.RemoveAt(i);
                        if (notDeletedNow)
                        {
                            var p = deletedFromTemplates.FirstOrDefault(c => c.idfsParameter == idp);
                            if (p != null) deletedFromTemplates.Remove(p);
                        }
                    }
                    if (aps.Count > 0)
                    {
                        //список параметров, относящихся к данному типу формы
                        var idfFormType = currentTemplate.idfsFormType;
                        var accParameter = Parameter.Accessor.Instance(null);
                        var allParameters = accParameter.SelectDetailList(manager, null, idfFormType);

                        foreach (var ap in aps)
                        {
                            var parameter = allParameters.FirstOrDefault(c => c.idfsParameter == ap.idfsParameter);
                            if (parameter == null) continue; //но вообще это ошибка
                            if (!ap.idfsFormTemplate.HasValue) continue;//но вообще это ошибка
                            //создаем фейковые удаленные строки
                            deletedFromTemplates.Add(CreateDeletedParameter(parameter, idfObservation, ap.idfsFormTemplate.Value));
                        }
                    }
                }
            }

            return deletedFromTemplates;
        }
    }
}
