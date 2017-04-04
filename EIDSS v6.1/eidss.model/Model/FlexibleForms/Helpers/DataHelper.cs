using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using BLToolkit.EditableObjects;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Enums;
using eidss.model.FlexibleForms.Helpers;
using eidss.model.Schema;

namespace eidss.model.Model.FlexibleForms.Helpers
{
    public static class DataHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public static string FFParameterSimpleKey
        {
            get { return "ff_idfsFormTemplate_{0}_"; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string FFParameterKey
        {
            get { return "ff_idfsFormTemplate_{0}_idfObservation_{1}_"; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idfsFormTemplate"></param>
        /// <param name="idfObservation"></param>
        /// <returns></returns>
        public static string GetFFParameterKey(long idfsFormTemplate, long idfObservation)
        {
            return String.Format(FFParameterKey, idfsFormTemplate, idfObservation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idfsFormTemplate"></param>
        /// <returns></returns>
        public static string GetFFParameterSimpleKey(long idfsFormTemplate)
        {
            return String.Format(FFParameterSimpleKey, idfsFormTemplate);
        }

        private static bool IsCorrectDataType(this FFParameterTypes parameterType, object value)
        {
            //если пустое значение, считаем, что правильно
            if (value == null || (String.IsNullOrWhiteSpace(value.ToString()))) return true;

            var val = value.ToString();
            switch (parameterType)
            {
                case FFParameterTypes.Boolean:
                    bool b;
                    var coll = val.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    return coll.Length <= 0 || Boolean.TryParse(coll[0], out b);
                case FFParameterTypes.Numeric:
                case FFParameterTypes.NumericPositive:
                    double d;
                    return Double.TryParse(val, out d);
                case FFParameterTypes.NumericNatural:
                case FFParameterTypes.NumericInteger:
                    int i;
                    var res = Int32.TryParse(val, out i);
                    if (res && (parameterType == FFParameterTypes.NumericNatural)) res = i >= 0; //нули тоже можно 
                    return res;
                case FFParameterTypes.String:
                    return true;
                case FFParameterTypes.Date:
                case FFParameterTypes.DateTime:
                    DateTime dt;
                    return DateTime.TryParse(val, out dt);
            }
            return false;
        }

        public static bool IsCorrectDataType(this ParameterTemplate parameterTemplate, object value)
        {
            return IsCorrectDataType(parameterTemplate.ParameterType, value);
        }

        public static bool IsCorrectDataType(this ParametersDeletedFromTemplate parameterTemplate, object value)
        {
            return IsCorrectDataType(ParameterTypeHelper.ConvertToParameterType(parameterTemplate.idfsParameterType), value);
        }
        
        public static object ConvertToRealDataType(this FFParameterTypes parameterType, FFParameterEditors parameterEditor, object value)
        {
            //инициализационное значение присваивается новому параметру, чтобы его можно было редактировать
            var isInitValue = value == DBNull.Value;
            if (!isInitValue && (value == null || String.IsNullOrWhiteSpace(value.ToString()))) return value;

            object realvalue;

            switch (parameterType)
            {
                case FFParameterTypes.Boolean:
                    if (isInitValue) return false;
                    //в вебе из чекбокса приходит "true,false" или "false"
                    var str = value.ToString().Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);
                    if (str.Length > 0)
                    {
                        switch (str[0])
                        {
                            case "1":
                                str[0] = "true";
                                break;
                            case "0":
                                str[0] = "false";
                                break;
                        }
                        realvalue = (str.Length > 0) && Convert.ToBoolean(str[0]);
                    }
                    else
                    {
                        realvalue = false;
                    }

                    break;
                case FFParameterTypes.Numeric:
                case FFParameterTypes.NumericPositive:
                    if (isInitValue) return 0;
                    double d;
                    realvalue = Double.TryParse(value.ToString(), out d) ? d : 0;
                    break;
                case FFParameterTypes.NumericNatural:
                case FFParameterTypes.NumericInteger:
                    if (isInitValue) return 0;
                    int i;
                    realvalue = Int32.TryParse(value.ToString(), out i) ? i : 0;
                    break;
                case FFParameterTypes.String:
                    if (parameterEditor.Equals(FFParameterEditors.ComboBox))
                    {
                        if (isInitValue) return 0;
                        long l;
                        return Int64.TryParse(value.ToString(), out l) ? l : 0;
                    }
                    if (isInitValue) return String.Empty;
                    realvalue = value.ToString();
                    break;
                case FFParameterTypes.Date:
                case FFParameterTypes.DateTime:
                    if (isInitValue) return DateTime.MinValue;
                    DateTime dt;
                    realvalue = DateTime.TryParse(value.ToString(), out dt) ? dt : 
                        (DateTime.TryParseExact(value.ToString(), "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out dt) ? dt : DateTime.MinValue);
                    break;
                default:
                    return isInitValue ? String.Empty : value.ToString();
            }

            return realvalue;
        }
        
        private static object ConvertToRealDataType(object value)
        {
            if (value == null) return null;
            var valStr = value.ToString();
            if (valStr.Length > 0)
            {
                Int64 resultInt64;
                Int32 resultInt32;
                Double resultDouble;
                DateTime resultDateTime;

                if (Int64.TryParse(valStr, out resultInt64)) return resultInt64;
                if (Int32.TryParse(valStr, out resultInt32)) return resultInt32;
                if (Double.TryParse(valStr, out resultDouble)) return resultDouble;
                if (DateTime.TryParse(valStr, out resultDateTime)) return resultDateTime;
            }
            return value;
        }

        public static string ConvertToRealDataTypeAsString(object value)
        {
            var val = ConvertToRealDataType(value);
            if (val.GetType().Name == "Double")
            {
                var ni = new NumberFormatInfo {NumberDecimalSeparator = "."};
                return ((Double)val).ToString(ni);
            }
            if (val.GetType().Name == "DateTime")
            {
                return ((DateTime)val).ToString("yyyy-MM-dd");
            }
            return val.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="activityParameters"></param>
        /// <param name="template"></param>
        /// <param name="idfObservation"></param>
        /// <param name="idfsParameter"></param>
        /// <param name="value"></param>
        public static ActivityParameter SetActivityParameterValue(this EditableList<ActivityParameter> activityParameters, Template template, long idfObservation, long idfsParameter, object value)
        {
            return activityParameters.SetActivityParameterValue(template, idfObservation, idfsParameter, FFPresenterModel.UnassignedValue, FFPresenterModel.UnassignedValue, value, String.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="activityParameters"></param>
        /// <param name="template"></param>
        /// <param name="idfObservation"></param>
        /// <param name="idfsParameter"></param>
        /// <param name="value"></param>
        /// <param name="strNameValue"> </param>
        public static ActivityParameter SetActivityParameterValue(this EditableList<ActivityParameter> activityParameters, Template template, long idfObservation, long idfsParameter, object value, string strNameValue)
        {
            return activityParameters.SetActivityParameterValue(template, idfObservation, idfsParameter, FFPresenterModel.UnassignedValue, FFPresenterModel.UnassignedValue, value, strNameValue);
        }

        public static ActivityParameter GetActivityParameter(
            this EditableList<ActivityParameter> activityParameters
            , bool parameterInSectionTable
            , long idfObservation
            , long idfsParameter
            , long idfRow = 0
            )
        {
            return parameterInSectionTable
                                       ? activityParameters.FirstOrDefault(c =>
                                                                           (c.idfsParameter == idfsParameter)
                                                                           &&
                                                                           (c.idfObservation == idfObservation)
                                                                           &&
                                                                           (c.idfRow == idfRow)
                                             )
                                       : activityParameters.FirstOrDefault(c =>
                                                                           (c.idfsParameter == idfsParameter)
                                                                           &&
                                                                           (c.idfObservation == idfObservation)
                                             );
        }

        public static bool IsParameterInSectionTable(ParameterTemplate parameterTemplate, Template template)
        {
            //TODO предусмотреть ситуацию, когда имеет место динамический или ressurected параметр
            var result = false;
            if (parameterTemplate != null)
            {
                if (parameterTemplate.idfsSection.HasValue)
                {
                    var section = template.SectionTemplatesLookup.FirstOrDefault(c => c.idfsSection == parameterTemplate.idfsSection);
                    if (section != null) result = section.blnGrid;
                }
            }
            else
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="activityParameters"></param>
        /// <param name="template"></param>
        /// <param name="idfObservation"></param>
        /// <param name="idfsParameter"></param>
        /// <param name="numRow"></param>
        /// <param name="value"></param>
        /// <param name="idfRow"></param>
        /// <param name="strNameValue"></param>
        /// <param name="deletedParameters"></param>
        public static ActivityParameter SetActivityParameterValue(this EditableList<ActivityParameter> activityParameters, Template template, long idfObservation, long idfsParameter, long idfRow, int numRow, object value, string strNameValue, List<ParametersDeletedFromTemplate> deletedParameters = null)
        {
            if (template == null) return null;
           
            //определяем реальный тип по типу параметра
            var parameterTemplate = template.ParameterTemplatesLookup.FirstOrDefault(c => c.idfsParameter == idfsParameter);
            var deletedParameter = deletedParameters != null ? deletedParameters.FirstOrDefault(c => c.idfsParameter == idfsParameter) : null;
            //динамических параметров в табличных секциях не бывает
            var isParameterInSectionTable = deletedParameter == null && IsParameterInSectionTable(parameterTemplate, template);
            var ap = GetActivityParameter(activityParameters, isParameterInSectionTable, idfObservation, idfsParameter, idfRow);
            
            object val;
            if (parameterTemplate != null)
            {
                val = ConvertToRealDataType(parameterTemplate.ParameterType, parameterTemplate.Editor, value);
            }
            else if (deletedParameter != null)
            {
                val = ConvertToRealDataType(ParameterTypeHelper.ConvertToParameterType(deletedParameter.idfsParameterType), ParameterControlTypeHelper.ConvertToParameterControlType(deletedParameter.idfsEditor), value);
            }
            else
            {
                val = ConvertToRealDataType(value);
            }
            
            var isInitValue = value == DBNull.Value;
            long idval;
            //проверяем, не пустое ли это значение в выпадающем списке (верхняя пустышка)
            if ((val != null) && Int64.TryParse(val.ToString(), out idval) && (idval == -1000) && (strNameValue.Length == 0)) val = null;
            //для checkbox значение = false означает null
            bool valbool;
            if ((val != null) && Boolean.TryParse(val.ToString(), out valbool) && !valbool) val = null;

            if (!isInitValue && Utils.IsEmpty(val))
            {
                if ((ap != null) && (ap.varValue != null))
                {
                    //если до изменения было какое-то значение, а теперь его стёрли, то удаляем значение
                    var str = ap.varValue.ToString();
                    //0 -- нужно хранить. Кроме того, 0 -- это ничего не выбрано в вып. списке
                    if (
                        (str.Length > 0)
                        &&
                        (str != "0"))
                    {
                        ap.varValue = null;
                        ap.HasRealChanges = true;
                        //TODO убрать, когда ActivityParameter.HasChanges начнёт меняться от varValue
                        ap.IncreaseFakeField();
                    }
                }
            }
            else
            {
                if (ap != null)
                {
                    if (ap.varValue != null)
                    {
                        if (!ap.varValue.Equals(val))
                        {
                            ap.varValue = val;
                            ap.HasRealChanges = true;
                            //TODO убрать, когда ActivityParameter.HasChanges начнёт меняться от varValue
                            ap.IncreaseFakeField();

                        }
                    }
                    else
                    {
                        ap.varValue = val;
                        ap.HasRealChanges = true;
                        //TODO убрать, когда ActivityParameter.HasChanges начнёт меняться от varValue
                        ap.IncreaseFakeField();
                    }
                }
                else
                {
                    using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        ap = ActivityParameter.Accessor.Instance(null)
                            .Create(manager, template
                                    , idfsParameter
                                    , idfObservation
                                    , template.idfsFormTemplate);

                        if (idfRow != FFPresenterModel.UnassignedValue) ap.idfRow = idfRow;
                        if (numRow != FFPresenterModel.UnassignedValue) ap.intNumRow = numRow;
                        ap.varValue = val;
                        //TODO может быть убрать это присвоение
                        ap.strNameValue = strNameValue;
                        activityParameters.Add(ap);
                        if (isInitValue)
                        {
                            ap.AcceptChanges();
                            //activityParameters.AcceptChanges();
                        }
                        else ap.HasRealChanges = true;
                    }
                }
                //если не удалось присвоить, то пробуем взять из параметра
                if (val != null)
                {
                    var selectList = parameterTemplate != null
                                         ? parameterTemplate.SelectListLookup
                                         : deletedParameter != null ? deletedParameter.SelectListLookup : null;

                    if (selectList != null)
                    {
                        long id;
                        if (Int64.TryParse(val.ToString(), out id))
                        {
                            var sl = selectList.FirstOrDefault(s => s.idfsValue == id);
                            if (sl != null) ap.strNameValue = sl.strValueCaption;
                        }
                    }
                }
            }
            //уточняем, если это динамический параметр
            if ((deletedParameter != null) && (ap != null)) ap.IsDynamicParameter = true;
            return ap;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mainActivityParameters"></param>
        /// <param name="idfObservation"></param>
        public static void LoadActivityParameters(this EditableList<ActivityParameter> mainActivityParameters, long idfObservation)
        {
            mainActivityParameters.LoadActivityParameters(idfObservation, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mainActivityParameters"></param>
        /// <param name="idfObservation"></param>
        /// <param name="needMerge"></param>
        public static void LoadActivityParameters(this EditableList<ActivityParameter> mainActivityParameters, long idfObservation, bool needMerge)
        {
            mainActivityParameters.LoadActivityParameters(new List<long> {idfObservation}, needMerge);
        }

        /// <summary>
        /// Осуществляет загрузку данных по обсервациям и слияние с основным хранилищем пользовательских данных
        /// </summary>
        /// <param name="mainActivityParameters"></param>
        /// <param name="observations"></param>
        /// <param name="needMerge"></param>
        public static EditableList<ActivityParameter> LoadActivityParameters(this EditableList<ActivityParameter> mainActivityParameters, List<long> observations, bool needMerge)
        {
            var activityParameters = new EditableList<ActivityParameter>();
            var observationList = observations.GetObservations();
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var acc = ActivityParameter.Accessor.Instance(null);
                activityParameters.AddRange(acc.SelectDetailList(manager, observationList));
            }
            if (needMerge) mainActivityParameters.Merge(activityParameters);
            activityParameters.AcceptChanges();
            mainActivityParameters.AcceptChanges();
            return activityParameters;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetObservations(this List<long> observations)
        {
            var sb = new StringBuilder();
            foreach (var observation in observations)
            {
                sb.AppendFormat("{0};", observation);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Производит слияние двух наборов данных
        /// </summary>
        /// <param name="activityParameters"></param>
        /// <param name="anotherActivityParameters"></param>
        public static void Merge(this EditableList<ActivityParameter> activityParameters, EditableList<ActivityParameter> anotherActivityParameters)
        {
            foreach (var ap in anotherActivityParameters)
            {
                var idObservation = ap.idfObservation;
                var idRow = ap.idfRow;
                var idParameter = ap.idfsParameter;
                if (activityParameters.Where(c => 
                    (c.idfObservation == idObservation)
                    && (c.idfRow == idRow)
                    && (c.idfsParameter == idParameter)
                    ).SingleOrDefault() == null)
                {
                    activityParameters.Add(ap);
                }
            }
        }
    }
}
