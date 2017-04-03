using System.Collections.Generic;
using System.Linq;
using eidss.model.Schema;

namespace eidss.model.FlexibleForms.Helpers
{
    public static class FFHelper
    {
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
    }
}
