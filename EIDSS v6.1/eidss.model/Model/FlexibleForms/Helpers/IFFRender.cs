using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using eidss.model.Schema;


namespace eidss.model.FlexibleForms.Helpers
{
    public interface IFFRender
    {
        /// <summary>
        /// Создаёт и показывает панель динамических параметров
        /// </summary>
        void ShowDynamicParametersGroupControl();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="visible"></param>
        void SetVisibleDynamicParametersGroupControl(bool visible);

        /// <summary>
        /// Язык, с которым открывается шаблон
        /// </summary>
        string LanguageTemplate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        bool ReadOnly { get; set; }

        /// <summary>
        /// Показывать ли заголовки у табличных секций загруженного шаблона
        /// </summary>
        bool SectionTableCaptionsIsVisible { get; set; }

        /// <summary>
        /// Возвращает контрол параметра из листа параметров
        /// </summary>
        /// <param name="idfsParameter"></param>
        /// <returns></returns>
        Parameter GetParameter(long idfsParameter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idfsSection"></param>
        /// <returns></returns>
        //SectionTable GetSectionTable(long idfsSection);

        /// <summary>
        /// Возвращает табличную секцию, если таковая имеется в шаблоне
        /// </summary>
        /// <param name="index">Порядковый номер табличной секции</param>
        /// <returns>возвращает табличную секцию, если таковая имеется в шаблоне, или null, если её нет</returns>
        //SectionTable GetSectionTableByIndex(int index);

        /// <summary>
        /// Добавляет параметр на хост-контрол
        /// </summary>
        /// <param name="rowParameter"></param>
        /// <param name="mouseLocation"></param>
        /// <param name="idfsFormTemplate"></param>
        /// <param name="isSummaryTemplate"></param>
        /// <returns></returns>
        //Parameter CreateParameterInTemplateHost(FlexibleFormsDS.ParametersRow rowParameter, Point mouseLocation, long idfsFormTemplate, bool isSummaryTemplate);

        /// <summary>
        /// Добавляет параметр на хост-контрол
        /// </summary>
        /// <param name="rowParameter"></param>
        /// <param name="parameterLocation"></param>
        /// <param name="idfsFormTemplate"></param>
        /// <param name="parentControl">Куда поместить созданный параметр</param>
        /// <param name="dynamicParameter">Динамический ли это параметр</param>
        /// <returns></returns>
        //Parameter CreateParameterInTemplateHost(FlexibleFormsDS.ParametersRow rowParameter, Point parameterLocation, long idfsFormTemplate, Control parentControl, bool dynamicParameter);

        /// <summary>
        /// Добавляет параметр на панель динамических параметров
        /// </summary>
        /// <param name="rowParameter"></param>
        /// <param name="idfsFormTemplate"></param>
        //void CreateParameterInParameterDynamicParametersGroupControl(FlexibleFormsDS.ParametersRow rowParameter, long idfsFormTemplate);

        /// <summary>
        /// Производит очистку шаблона
        /// </summary>
        void ClearTemplate();

        /// <summary>
        /// Восстанавливает шаблон на контроле-хосте
        /// </summary>
        /// <param name="idfsFormTemplate"></param>
        /// <param name="idfsFormType"></param>
        /// <param name="langid"></param>
        /// <param name="idfVersion"></param>
        /// <param name="presetStubs"></param>
        /// <param name="isSummary"></param>
        //void RestoreTemplate(long idfsFormTemplate, long idfsFormType, string langid, List<AggregateCaseSection> presetStubs, long? idfVersion, bool isSummary);

        /// <summary>
        /// Восстанавливает шаблон на контроле-хосте
        /// </summary>
        /// <param name="idfsFormTemplate"></param>
        /// <param name="idfsFormType"></param>
        /// <param name="langid"></param>
        void RestoreTemplate(long idfsFormTemplate, long idfsFormType, string langid);

        /// <summary>
        /// Визуализирует секции по нужному шаблону
        /// </summary>
        /// <param name="idfsFormTemplate"></param>
        /// <param name="langid"></param>
        /// <param name="isSummary"></param>
        void RestoreSections(long idfsFormTemplate, string langid, bool isSummary);

        /// <summary>
        /// Определяет добавлена ли уже секция в шаблон
        /// </summary>
        /// <param name="idfsSection"></param>
        /// <returns></returns>
        bool SectionAlreadyAdded(long idfsSection);

        /// <summary>
        /// Определяет добавлена ли уже секция в шаблон
        /// </summary>
        /// <param name="idfsSection"></param>
        /// <returns></returns>
        bool IsSectionTable(long idfsSection);

        /// <summary>
        /// Определяет добавлен ли уже параметр в шаблон
        /// </summary>
        /// <param name="idfsParameter"></param>
        /// <returns></returns>
        bool ParameterAlreadyAdded(long idfsParameter);

        /// <summary>
        /// Отыскивает родительскую секцию либо создаёт её
        /// </summary>
        /// <param name="idfsFormTemplate"></param>
        /// <param name="parentSectionTemplateId"></param>
        /// <param name="mouseLocation"></param>
        /// <returns></returns>
        Section FindParentSection(long idfsFormTemplate, long parentSectionTemplateId, Point mouseLocation);

        /// <summary>
        /// Создаёт секцию, а также все её родительские секции, и размещает их на дизайн-хосте шаблона
        /// </summary>
        /// <param name="rowSection"></param>
        ///<param name="mouseLocation"></param>
        /// <param name="idfsFormTemplate"></param>
        //Section CreateSectionInTemplateHost(FlexibleFormsDS.SectionsRow rowSection, Point mouseLocation, long idfsFormTemplate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowSectionTemplate"></param>
        /// <param name="mouseLocation"></param>
        /// <returns></returns>
        Section CreateSectionInTemplateHost(SectionTemplate rowSectionTemplate, Point mouseLocation);

        /// <summary>
        /// Создаёт секцию, а также все её родительские секции, и размещает их на дизайн-хосте шаблона
        /// </summary>
        /// <param name="rowSectionTemplate"></param>
        ///<param name="mouseLocation"></param>
        ///<param name="isSummaryTemplate"></param>
        Section CreateSectionInTemplateHost(SectionTemplate rowSectionTemplate, Point mouseLocation, bool isSummaryTemplate);
        
        /// <summary>
        /// Построение первого уровня дочерних табличных секций и параметров у табличной секции
        /// (построение более нижних уровней рекурсивное)
        /// </summary>
        /// <param name="sectionTable"></param>
        /// <param name="idfsFormTemplate"></param>
        /// <param name="isSummaryTemplate"></param>
        //void RestoreSectionTableChildren(SectionTable sectionTable, long idfsFormTemplate, bool isSummaryTemplate);

        /// <summary>
        /// Добавляет параметр на хост-контрол
        /// </summary>
        /// <param name="rowParameterTemplate"></param>
        /// <param name="mouseLocation"></param>
        /// <param name="isSummaryTemplate"></param>
        /// <returns></returns>
        Parameter CreateParameterInTemplateHost(ParameterTemplate rowParameterTemplate, Point mouseLocation, bool isSummaryTemplate);

        /// <summary>
        /// Визуализирует параметры по нужному шаблону
        /// </summary>
        /// <param name="idfsFormTemplate"></param>
        /// <param name="langid"></param>
        /// <param name="isSummary"></param>
        void RestoreParameters(long idfsFormTemplate, string langid, bool isSummary);

        /// <summary>
        /// Визуализирует линии по нужному шаблону
        /// </summary>
        /// <param name="idfsFormTemplate"></param>
        /// <param name="langid"></param>
        void RestoreLines(long? idfsFormTemplate, string langid);

        /// <summary>
        /// Создаёт линию на рабочем столе шаблона
        /// </summary>
        /// <param name="linesRow"></param>
        //Line CreateLineInTemplateHost(FlexibleFormsDS.LinesRow linesRow);

        /// <summary>
        /// Визуализирует лейблы по нужному шаблону
        /// </summary>
        /// <param name="idfsFormTemplate"></param>
        /// <param name="langid"></param>
        void RestoreLabels(long idfsFormTemplate, string langid);

        /// <summary>
        /// Создаёт лейбл на рабочем столе шаблона
        /// </summary>
        /// <param name="labelsRow"></param>
        //Label CreateLabelInTemplateHost(FlexibleFormsDS.LabelsRow labelsRow);

        /// <summary>
        /// Осуществляет слияние шаблонов и боковиков, которые относятся к указанным observation
        /// </summary>
        /// <param name="observations"></param>
        /// <param name="formType"></param>
        /// <param name="idfsFormTemplateMerged">ID шаблона, в который нужно поместить совокупный шаблон</param>
        //void MergeTemplates(long idfsFormTemplateMerged, List<long> observations, FFType formType);
    }
     
}
