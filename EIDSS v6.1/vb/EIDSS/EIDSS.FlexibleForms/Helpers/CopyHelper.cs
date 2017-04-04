using EIDSS.FlexibleForms.DataBase;

namespace EIDSS.FlexibleForms.Helpers
{
    public static class CopyHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mainDbService"></param>
        /// <param name="idfsObservationNew"></param>
        /// <param name="activityParametersRows"></param>
        public static void CopyActivityParameters(DbServiceUserData mainDbService, long idfsObservationNew, FlexibleFormsDS.ActivityParametersRow[] activityParametersRows)
        {
            foreach (var row in activityParametersRows)
            {
                if (!row.IsRowAlive()) continue;
                var rowResult = mainDbService.ChangeValue(idfsObservationNew, row.idfsFormTemplate, row.idfsParameter, row.idfRow, row.intNumRow, row.varValue, null);
                //оживл€ем параметр
                if (rowResult != null) rowResult.intRowState = 0;
            }
        }

        /// <summary>
        /// ѕроизводит копирование секций в шаблоне
        /// </summary>
        /// <param name="mainDbService"></param>
        /// <param name="idfsFormTemplateTarget"></param>
        /// <param name="idfsLanguage"></param>
        /// <param name="idfsFormTemplateSample"></param>
        public static void CopySectionTemplate(DbService mainDbService, long idfsFormTemplateSample, long idfsFormTemplateTarget, string idfsLanguage)
        {
            var sectionTemplateRows = mainDbService.GetSectionTemplateRows(null, idfsFormTemplateSample);

            foreach (FlexibleFormsDS.SectionTemplateRow row in sectionTemplateRows)
            {
                //если така€ секци€ уже присутствует в целевом шаблоне, то повторно еЄ не добавл€ем
                if (mainDbService.GetSectionTemplateRow(row.idfsSection, idfsFormTemplateTarget, idfsLanguage) != null) continue;
                
                var rowSectionTemplate = mainDbService.MainDataSet.SectionTemplate.NewSectionTemplateRow();
                
                rowSectionTemplate.idfsSection = row.idfsSection;
                if (!row.IsidfsParentSectionNull()) rowSectionTemplate.idfsParentSection = row.idfsParentSection;
                rowSectionTemplate.idfsFormType = row.idfsFormType;
                rowSectionTemplate.idfsFormTemplate = idfsFormTemplateTarget;
                rowSectionTemplate.langid = idfsLanguage.Length > 0 ? idfsLanguage : row.langid;
                rowSectionTemplate.blnFreeze = row.blnFreeze;
                rowSectionTemplate.blnGrid = row.blnGrid;
                rowSectionTemplate.blnFixedRowSet = row.blnFixedRowSet;
                rowSectionTemplate.DefaultName = row.DefaultName;
                rowSectionTemplate.NationalName = row.NationalName;
                rowSectionTemplate.intLeft = row.intLeft;
                rowSectionTemplate.intTop = row.intTop;
                rowSectionTemplate.intWidth = row.intWidth;
                rowSectionTemplate.intHeight = row.intHeight;
                rowSectionTemplate.IsStubLoaded = !row.IsIsStubLoadedNull() && row.IsStubLoaded;
                rowSectionTemplate.intOrder = row.intOrder;
                rowSectionTemplate.intCaptionHeight = !row.IsintCaptionHeightNull() ? row.intCaptionHeight : 23;
                mainDbService.MainDataSet.SectionTemplate.AddSectionTemplateRow(rowSectionTemplate);
            }
        }

        /// <summary>
        /// ѕроизводит копирование лейблов в шаблоне
        /// </summary>
        /// <param name="mainDbService"></param>
        /// <param name="idfsFormTemplateTarget"></param>
        /// <param name="idfsLanguage"></param>
        /// <param name="idfsFormTemplateSample"></param>
        public static void CopyLabelTemplate(DbService mainDbService, long idfsFormTemplateSample, long idfsFormTemplateTarget, string idfsLanguage)
        {
            var labelsRows = mainDbService.GetLabelTemplateRows(idfsFormTemplateSample);

            foreach (var row in labelsRows)
            {
                //если уже присутствует в целевом шаблоне, то повторно не добавл€ем
                if (mainDbService.GetLabelTemplateRow(row.idfDecorElement, idfsFormTemplateTarget, idfsLanguage) != null) continue;

                var labelsRow = mainDbService.MainDataSet.Labels.NewLabelsRow();
                labelsRow.idfsDecorElementType = row.idfsDecorElementType;
                labelsRow.idfsBaseReference = row.idfsBaseReference;
                labelsRow.langid = idfsLanguage;
                labelsRow.idfsFormTemplate = idfsFormTemplateTarget;
                labelsRow.intLeft = row.intLeft;
                labelsRow.intTop = row.intTop;
                labelsRow.intWidth = row.intWidth;
                labelsRow.intHeight = row.intHeight;
                if (!row.IsColorNull()) labelsRow.Color = row.Color;
                if (!row.IsidfsSectionNull()) labelsRow.idfsSection = row.idfsSection;
                labelsRow.intColor = row.intColor;
                labelsRow.intFontStyle = row.intFontStyle;
                labelsRow.intFontSize = row.intFontSize;
                labelsRow.DefaultText = row.DefaultText;
                labelsRow.NationalText = row.NationalText;
                mainDbService.MainDataSet.Labels.AddLabelsRow(labelsRow);
            }
        }

        /// <summary>
        /// ѕроизводит копирование линий в шаблоне
        /// </summary>
        /// <param name="mainDbService"></param>
        /// <param name="idfsFormTemplateTarget"></param>
        /// <param name="idfsLanguage"></param>
        /// <param name="idfsFormTemplateSample"></param>
        public static void CopyLineTemplate(DbService mainDbService, long idfsFormTemplateSample, long idfsFormTemplateTarget, string idfsLanguage)
        {
            var linesRows = mainDbService.GetLineTemplateRows(idfsFormTemplateSample);

            foreach (var row in linesRows)
            {
                //если така€ секци€ уже присутствует в целевом шаблоне, то повторно еЄ не добавл€ем
                if (mainDbService.GetLineTemplateRow(row.idfDecorElement, idfsFormTemplateTarget, idfsLanguage) != null) continue;

                FlexibleFormsDS.LinesRow linesRow = mainDbService.MainDataSet.Lines.NewLinesRow();
                linesRow.langid = idfsLanguage;
                linesRow.idfsDecorElementType = row.idfsDecorElementType;
                linesRow.idfsFormTemplate = idfsFormTemplateTarget;
                if (!row.IsidfsSectionNull()) linesRow.idfsSection = row.idfsSection;
                linesRow.intLeft = row.intLeft;
                linesRow.intTop = row.intTop;
                linesRow.intWidth = row.intWidth;
                linesRow.intHeight = row.intHeight;
                if (!row.IsColorNull()) linesRow.Color = row.Color;
                linesRow.intColor = row.intColor;
                if (!row.IsblnOrientationNull())
                {
                    linesRow.blnOrientation = row.blnOrientation;
                }
                else
                {
                    linesRow.SetblnOrientationNull();
                }
                if (!row.IsintOrientationNull())
                {
                    linesRow.intOrientation = row.intOrientation;
                }
                else
                {
                    linesRow.SetintOrientationNull();
                }
                mainDbService.MainDataSet.Lines.AddLinesRow(linesRow);
            }
        }

        /// <summary>
        /// ѕроизводит копирование параметров в шаблоне
        /// </summary>
        /// <param name="mainDbService"></param>
        /// <param name="idfsFormTemplateSample"></param>
        /// <param name="idfsFormTemplateTarget"></param>
        /// <param name="idfsLanguage"></param>
        public static void CopyParameterTemplate(DbService mainDbService, long idfsFormTemplateSample, long idfsFormTemplateTarget, string idfsLanguage)
        {
            var parameterTemplateRows = mainDbService.GetParameterTemplateRows(null, idfsFormTemplateSample);

            foreach (var row in parameterTemplateRows)
            {
                //если такой параметр уже присутствует в целевом шаблоне, то повторно его не добавл€ем
                if (mainDbService.GetParameterTemplateRow(row.idfsParameter, idfsFormTemplateTarget, idfsLanguage) != null) continue;
                
                FlexibleFormsDS.ParameterTemplateRow rowParameterTemplate = mainDbService.MainDataSet.ParameterTemplate.NewParameterTemplateRow();

                rowParameterTemplate.idfsParameter = row.idfsParameter;
                if (!row.IsidfsSectionNull())
                    rowParameterTemplate.idfsSection = row.idfsSection;
                rowParameterTemplate.idfsFormType = row.idfsFormType;
                rowParameterTemplate.idfsFormTemplate = idfsFormTemplateTarget;
                rowParameterTemplate.langid = idfsLanguage.Length > 0 ? idfsLanguage : row.langid;
                rowParameterTemplate.idfsEditor = row.idfsEditor;
                rowParameterTemplate.intScheme = row.intScheme;
                rowParameterTemplate.intLabelSize = row.intLabelSize;
                rowParameterTemplate.DefaultName = row.DefaultName;
                rowParameterTemplate.NationalName = row.NationalName;
                rowParameterTemplate.intLeft = row.intLeft;
                rowParameterTemplate.intTop = row.intTop;
                rowParameterTemplate.intWidth = row.intWidth;
                rowParameterTemplate.intHeight = row.intHeight;
                rowParameterTemplate.intHACode = row.intHACode;
                rowParameterTemplate.idfsParameterType = row.idfsParameterType;
                rowParameterTemplate.blnFreeze = row.blnFreeze;
                rowParameterTemplate.idfsEditMode = row.idfsEditMode;
                rowParameterTemplate.intOrder = row.intOrder;
                mainDbService.MainDataSet.ParameterTemplate.AddParameterTemplateRow(rowParameterTemplate);
            }
        }

        /// <summary>
        /// ѕроизводит копирование метрических объектов в шаблоне
        /// </summary>
        /// <param name="mainDbService"></param>
        /// <param name="idfsFormTemplate"> </param>
        /// <param name="idfsLanguageTo"> </param>
        public static void RestoreLanguageLayout(DbService mainDbService, long idfsFormTemplate, string idfsLanguageTo)
        {
            //копируем из английского сло€ в национальный
            //строки в национальном слое должны быть
            string idfsLanguageFrom = bv.common.Core.Localizer.lngEn;
            var parameterTemplateRows = mainDbService.GetParameterTemplateRows(null, idfsFormTemplate, idfsLanguageFrom);

            foreach (var row in parameterTemplateRows)
            {
                //если такой параметр уже присутствует в целевом шаблоне, то повторно его не добавл€ем
                var targetRow = (mainDbService.GetParameterTemplateRow(row.idfsParameter, idfsFormTemplate, idfsLanguageTo));
                if (targetRow == null) continue;
                targetRow.intScheme = row.intScheme;
                targetRow.intLabelSize = row.intLabelSize;
                targetRow.intLeft = row.intLeft;
                targetRow.intTop = row.intTop;
                targetRow.intWidth = row.intWidth;
                targetRow.intHeight = row.intHeight;
            }

            var sectionTemplateRows = mainDbService.GetSectionTemplateRows(null, idfsFormTemplate, idfsLanguageFrom);

            foreach (var row in sectionTemplateRows)
            {
                var targetRow = mainDbService.GetSectionTemplateRow(row.idfsSection, idfsFormTemplate, idfsLanguageTo);
                if (targetRow == null) continue;
                targetRow.intLeft = row.intLeft;
                targetRow.intTop = row.intTop;
                targetRow.intWidth = row.intWidth;
                targetRow.intHeight = row.intHeight;
            }

            var labelsRows = mainDbService.GetLabelTemplateRows(idfsFormTemplate, idfsLanguageFrom);

            foreach (var row in labelsRows)
            {
                //если уже присутствует в целевом шаблоне, то повторно не добавл€ем
                var targetRow = (mainDbService.GetLabelTemplateRow(row.idfDecorElement, idfsFormTemplate, idfsLanguageTo));
                if (targetRow == null) continue;
                targetRow.intLeft = row.intLeft;
                targetRow.intTop = row.intTop;
                targetRow.intWidth = row.intWidth;
                targetRow.intHeight = row.intHeight;
                if (!row.IsColorNull()) targetRow.Color = row.Color;
                targetRow.intColor = row.intColor;
                targetRow.intFontStyle = row.intFontStyle;
                targetRow.intFontSize = row.intFontSize;
            }

            //линий у нас нигде нет
        }

        /// <summary>
        /// ѕроизводит копирование детерминантов из одного шаблона в другой
        /// </summary>
        /// <param name="mainDbService"></param>
        /// <param name="idfsFormTemplateTarget"></param>
        /// <param name="idfsFormTemplateSample"></param>
        public static void CopyDeterminants(DbService mainDbService, long idfsFormTemplateSample, long idfsFormTemplateTarget)
        {
            //детерминанты добавл€ютс€ к уже существующим на целевом шаблоне

            var determinantValuesRows = (FlexibleFormsDS.TemplateDeterminantValuesRow[])mainDbService.MainDataSet.TemplateDeterminantValues.Select(DataHelper.Filter("idfsFormTemplate", idfsFormTemplateSample));

            foreach (var rowDeterminant in determinantValuesRows)
            {
                var row = mainDbService.MainDataSet.TemplateDeterminantValues.NewTemplateDeterminantValuesRow();
                row.idfsFormTemplate = idfsFormTemplateTarget;
                row.idfsFormType = rowDeterminant.idfsFormType;
                row.DeterminantValue = rowDeterminant.DeterminantValue;
                row.DeterminantDefaultName = rowDeterminant.DeterminantDefaultName;
                row.DeterminantNationalName = rowDeterminant.DeterminantNationalName;
                if (!rowDeterminant.IsidfsBaseReferenceNull()) row.idfsBaseReference = rowDeterminant.idfsBaseReference;
                if (!rowDeterminant.IsidfsGISBaseReferenceNull()) row.idfsGISBaseReference = rowDeterminant.idfsGISBaseReference;
                row.DeterminantType = rowDeterminant.DeterminantType;
                row.DeterminantTypeDefaultName = rowDeterminant.DeterminantTypeDefaultName;
                row.DeterminantTypeNationalName = rowDeterminant.DeterminantTypeNationalName;

                mainDbService.MainDataSet.TemplateDeterminantValues.AddTemplateDeterminantValuesRow(row);
            }
        }

        /// <summary>
        ///  опирование шаблона
        /// </summary>
        /// <param name="mainDbService"></param>
        /// <param name="template"></param>
        /// <param name="idfsFormType"></param>
        /// <param name="needTransferUNI">Ќужно ли переносить UNI с предка</param>
        public static FlexibleFormsDS.TemplatesRow CopyTemplate(DbService mainDbService, FlexibleFormsDS.TemplatesRow template, long idfsFormType, bool needTransferUNI)
        {
            #region  опи€ шаблона

            FlexibleFormsDS.TemplatesRow rowTemplate = mainDbService.MainDataSet.Templates.NewTemplatesRow();
            rowTemplate.idfsFormType = idfsFormType;
            rowTemplate.blnUNI = needTransferUNI && template.blnUNI;
            rowTemplate.DefaultName = template.DefaultName + " (New)";
            rowTemplate.NationalName = template.NationalName + " (New)"; //TODO сделать национальный перевод
            rowTemplate.NationalLongName = template.NationalLongName;
            rowTemplate.langid = template.langid;
            if (!template.IsstrNoteNull()) rowTemplate.strNote = template.strNote;

            mainDbService.MainDataSet.Templates.AddTemplatesRow(rowTemplate);

            #endregion

            // опи€ секций в шаблоне
            CopySectionTemplate(mainDbService, template.idfsFormTemplate, rowTemplate.idfsFormTemplate, bv.model.Model.Core.ModelUserContext.CurrentLanguage);

            // опи€ параметров в шаблоне
            CopyParameterTemplate(mainDbService, template.idfsFormTemplate, rowTemplate.idfsFormTemplate, bv.model.Model.Core.ModelUserContext.CurrentLanguage);

            // опи€ лейблов в шаблоне
            CopyLabelTemplate(mainDbService, template.idfsFormTemplate, rowTemplate.idfsFormTemplate, bv.model.Model.Core.ModelUserContext.CurrentLanguage);

            // опи€ линий в шаблоне
            CopyLineTemplate(mainDbService, template.idfsFormTemplate, rowTemplate.idfsFormTemplate, bv.model.Model.Core.ModelUserContext.CurrentLanguage);

            #region  опи€ правил в шаблоне

            var rulesRows = mainDbService.GetRules(template.idfsFormTemplate);
            foreach (var row in rulesRows)
            {
                if (!row.IsRowAlive()) continue;
                var rowRules = mainDbService.MainDataSet.Rules.NewRulesRow();
                rowRules.langid = row.langid;
                rowRules.idfsFormTemplate = rowTemplate.idfsFormTemplate;
                rowRules.DefaultName = row.DefaultName;
                rowRules.NationalName = row.NationalName;
                rowRules.idfsRuleFunction = row.idfsRuleFunction;
                if (!row.IsMessageTextNull()) rowRules.MessageText = row.MessageText;
                if (!row.IsMessageNationalTextNull()) rowRules.MessageNationalText = row.MessageNationalText;
                if (!row.IsidfsCheckPointDescrNull()) rowRules.idfsCheckPointDescr = row.idfsCheckPointDescr;
                rowRules.idfsCheckPoint = row.idfsCheckPoint;
                if (!row.IsidfsRuleMessageNull()) rowRules.idfsRuleMessage = row.idfsRuleMessage;
                rowRules.blnNot = row.blnNot;
                rowRules.intNumberOfParameters = row.intNumberOfParameters;
                if (!row.IsFunctionTextNull()) rowRules.FunctionText = row.FunctionText;

                mainDbService.MainDataSet.Rules.AddRulesRow(rowRules);

                string filterForRules = DataHelper.Filter("idfsRule", row.idfsRule);

                #region  опи€ параметров функций дл€ правил внутри шаблона

                var ruleParameterForFunctionRows = (FlexibleFormsDS.RuleParameterForFunctionRow[])mainDbService.MainDataSet.RuleParameterForFunction.Select(filterForRules);

                foreach (var rowParam in ruleParameterForFunctionRows)
                {
                    if (!rowParam.IsRowAlive()) continue;
                    var rowRuleParameterForFunctionRow = mainDbService.MainDataSet.RuleParameterForFunction.NewRuleParameterForFunctionRow();
                    rowRuleParameterForFunctionRow.idfsFormTemplate = rowTemplate.idfsFormTemplate;
                    rowRuleParameterForFunctionRow.idfsRule = rowRules.idfsRule;
                    rowRuleParameterForFunctionRow.intOrder = rowParam.intOrder;
                    rowRuleParameterForFunctionRow.idfsParameter = rowParam.idfsParameter;
                    rowRuleParameterForFunctionRow.idfsParameterType = rowParam.idfsParameterType;
                    mainDbService.MainDataSet.RuleParameterForFunction.AddRuleParameterForFunctionRow(rowRuleParameterForFunctionRow);
                }

                #endregion

                #region  опи€ установленных значений дл€ правил внутри шаблона

                var ruleConstantRows =
                    (FlexibleFormsDS.RuleConstantRow[])
                    mainDbService.MainDataSet.RuleConstant.Select(filterForRules);

                foreach (var rowConstants in ruleConstantRows)
                {
                    if (!rowConstants.IsRowAlive()) continue;
                    var rowConstant = mainDbService.MainDataSet.RuleConstant.NewRuleConstantRow();
                    rowConstant.idfsRule = rowRules.idfsRule;
                    rowConstant.varConstant = rowConstants.varConstant;
                    mainDbService.MainDataSet.RuleConstant.AddRuleConstantRow(rowConstant);
                }

                #endregion

                #region  опи€ действий дл€ правил внутри шаблона

                var ruleParameterForActionRows =
                    (FlexibleFormsDS.RuleParameterForActionRow[])
                    mainDbService.MainDataSet.RuleParameterForAction.Select(filterForRules);

                foreach (var rowParam in ruleParameterForActionRows)
                {
                    if (!rowParam.IsRowAlive()) continue;
                    var rowParameterForAction = mainDbService.MainDataSet.RuleParameterForAction.NewRuleParameterForActionRow();
                    rowParameterForAction.idfsFormTemplate = rowTemplate.idfsFormTemplate;
                    rowParameterForAction.idfsRule = rowRules.idfsRule;
                    rowParameterForAction.idfsParameter = rowParam.idfsParameter;
                    rowParameterForAction.idfsRuleAction = rowParam.idfsRuleAction;
                    mainDbService.MainDataSet.RuleParameterForAction.AddRuleParameterForActionRow(rowParameterForAction);
                }

                #endregion
            }

            #endregion

            return rowTemplate;
        }

    }
}
