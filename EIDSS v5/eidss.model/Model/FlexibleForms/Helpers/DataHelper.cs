﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.EditableObjects;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Enums;
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

        

        ///// <summary>
        ///// Парсит форму и переносит данные в модель
        ///// </summary>
        ///// <param name="model"></param>
        ///// <param name="form"></param>
        //public static void PutDataIntoModel(this FFPresenterModel model, FormCollection form)
        //{
        //    //обрабатываем только те параметры, которые относятся к данному шаблону
        //    //TODO решить как обрабатывать динамические параметры, которые не относятся к шаблону, но присутствуют в данных
        //    int keyPartLength = "idfsParameter_".Length;
        //    foreach (var element in form.AllKeys)
        //    {
        //        if (!element.Contains("idfsParameter")) continue;
        //        var idfsParameter = Convert.ToInt64(element.Substring(keyPartLength, element.Length - keyPartLength));
        //        if (model.CurrentTemplate.ParameterTemplates.Select(c => c.idfsParameter == idfsParameter).Count() == 0) continue;
        //        //TODO нужно конвертить строковое значение в конкретный тип данных
        //        model.SetActivityParameterValue(idfsParameter, form[element]);
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="model"></param>
        //public static void SaveActivityParameters(this FFPresenterModel model)
        //{

        //}

        public static bool IsCorrectDataType(this ParameterTemplate parameterTemplate, object value)
        {
            //если пустое значение, считаем, что правильно
            if (value == null || (String.IsNullOrWhiteSpace(value.ToString()))) return true;

            var val = value.ToString();
            switch (parameterTemplate.ParameterType)
            {
                case FFParameterTypes.Boolean:
                    bool b;
                    var coll = val.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);
                    return coll.Length <= 0 || Boolean.TryParse(coll[0], out b);
                case FFParameterTypes.Numeric:
                case FFParameterTypes.NumericPositive:
                    double d;
                    return Double.TryParse(val, out d);
                case FFParameterTypes.NumericNatural:
                case FFParameterTypes.NumericInteger:
                    int i;
                    var res = Int32.TryParse(val, out i);
                    if (res && (parameterTemplate.ParameterType == FFParameterTypes.NumericNatural)) res = i >= 0; //нули тоже можно 
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameterTemplate"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object ConvertToRealDataType(this ParameterTemplate parameterTemplate, object value)
        {
            //инициализационное значение присваивается новому параметру, чтобы его можно было редактировать
            var isInitValue = value == DBNull.Value;
            if (!isInitValue && (value == null || String.IsNullOrWhiteSpace(value.ToString()))) return value;

            object realvalue;

            switch (parameterTemplate.ParameterType)
            {
                case FFParameterTypes.Boolean:
                    if (isInitValue) return false;
                    //в вебе из чекбокса приходит "true,false" или "false"
                    var str = value.ToString().Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);
                    realvalue = (str.Length > 0) && Convert.ToBoolean(str[0]);
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
                    if (parameterTemplate.Editor.Equals(FFParameterEditors.ComboBox))
                    {
                        return isInitValue ? 0 : Convert.ToInt64(value);
                    }
                    if (isInitValue) return String.Empty;
                    realvalue = value.ToString();
                    break;
                case FFParameterTypes.Date:
                case FFParameterTypes.DateTime:
                    if (isInitValue) return DateTime.MinValue;
                    DateTime dt;
                    realvalue = DateTime.TryParse(value.ToString(), out dt) ? dt : DateTime.MinValue;
                    break;
                default:
                    return isInitValue ? String.Empty : value.ToString();
            }

            return realvalue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static object ConvertToRealDataType(object value)
        {
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
            , long idfObservation, long idfsParameter, long idfRow
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
            var result = true;
            if ((parameterTemplate != null) && parameterTemplate.idfsSection.HasValue)
            {
                var section = template.SectionTemplates.FirstOrDefault(c => c.idfsSection == parameterTemplate.idfsSection);
                if (section != null) result = section.blnGrid;
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
        public static ActivityParameter SetActivityParameterValue(this EditableList<ActivityParameter> activityParameters, Template template, long idfObservation, long idfsParameter, long idfRow, int numRow, object value, string strNameValue)
        {
            if (template == null) return null;
           
            //определяем реальный тип по типу параметра
            var parameterTemplate = template.ParameterTemplates.FirstOrDefault(c => c.idfsParameter == idfsParameter);
            
            var ap = GetActivityParameter(activityParameters, IsParameterInSectionTable(parameterTemplate, template), idfObservation, idfsParameter, idfRow);
            
            var val = parameterTemplate != null ? ConvertToRealDataType(parameterTemplate, value) : ConvertToRealDataType(value);
            var isInitValue = value == DBNull.Value;
            long idval;
            //проверяем, не пустое ли это значение в выпадающем списке (верхняя пустышка)
            if ((val != null) && Int64.TryParse(val.ToString(), out idval) && (idval == -1000) && (strNameValue.Length == 0)) val = null;

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
                if ((parameterTemplate != null) && (parameterTemplate.SelectList != null) && (val != null))
                {
                    long id;
                    if (Int64.TryParse(val.ToString(), out id))
                    {
                        var sl = parameterTemplate.SelectList.FirstOrDefault(s => s.idfsValue == id);
                        if (sl != null) ap.strNameValue = sl.strValueCaption;
                    }

                }
            }
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
