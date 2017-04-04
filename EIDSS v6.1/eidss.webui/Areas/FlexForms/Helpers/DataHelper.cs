using System;
using System.Linq;
using System.Web.Mvc;
using BLToolkit.EditableObjects;
using bv.model.BLToolkit;
using eidss.model.Enums;
using eidss.model.Schema;

namespace eidss.webui.Areas.FlexForms.Helpers
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="activityParameters"></param>
        /// <param name="form"></param>
        /// <param name="template"></param>
        /// <param name="idfObservation"></param>
        public static void ExtractFromCollection(this EditableList<ActivityParameter> activityParameters
                    , FormCollection form
                    , Template template
                    , long idfObservation)
        {

            //отберём те контролы с формы, которые относятся к нужному ключу
            string ffKey = GetFFParameterKey(template.idfsFormTemplate, idfObservation);
            const string idparam = "idfsParameter_";
            int keyPartLength = idparam.Length;
            foreach (string key in form.Keys)
            {
                if (key.Contains(ffKey) && key.Contains(idparam))
                {
                    int index = key.IndexOf(idparam);
                    var idfsParameter = Convert.ToInt64(key.Substring(index + keyPartLength, key.Length - index - keyPartLength));
                    activityParameters.SetActivityParameterValue(template, idfObservation, idfsParameter, form[key]);
                }
            }
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameterTemplate"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static object ConvertToRealDataType(ParameterTemplate parameterTemplate, object value)
        {
            if (value == null) return value;

            switch (parameterTemplate.ParameterType)
            {
                case FFParameterTypes.Boolean:
                    return Convert.ToBoolean(value);
                case FFParameterTypes.Numeric:
                    return Convert.ToDouble(value);
                case FFParameterTypes.NumericNatural:
                    return Convert.ToInt32(value);
                case FFParameterTypes.NumericPositive:
                    return Convert.ToInt32(value);
                case FFParameterTypes.NumericInteger:
                    return Convert.ToInt32(value);
                case FFParameterTypes.String:
                    if (parameterTemplate.Editor.Equals(FFParameterEditors.ComboBox))
                    {
                        return Convert.ToInt64(value);
                    }
                    return value.ToString();
                case FFParameterTypes.Date:
                    return Convert.ToDateTime(value);
                case FFParameterTypes.DateTime:
                    return Convert.ToDateTime(value);
                default:
                    return value.ToString();
            }
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
        public static void SetActivityParameterValue(this EditableList<ActivityParameter> activityParameters, Template template, long idfObservation, long idfsParameter, object value)
        {
            //TODO разобраться с idfRow и табличными данными
            var ap = activityParameters.FirstOrDefault(c =>
                                                             (c.idfsParameter == idfsParameter)
                                                             &&
                                                             (c.idfsFormTemplate == template.idfsFormTemplate)
                );
            //определяем реальный тип по типу параметра
            var parameterTemplate = template.ParameterTemplates.FirstOrDefault(c => c.idfsParameter == idfsParameter);
            var val = parameterTemplate != null ? ConvertToRealDataType(parameterTemplate, value) : ConvertToRealDataType(value);
            
            if (ap != null)
            {
                ap.varValue = val;
            }
            else
            {
                using (var manager = DbManagerFactory.Factory.Create())
                {
                    ap = ActivityParameter.Accessor.Instance(null)
                        .Create(manager
                                , idfsParameter
                                , idfObservation
                                , template.idfsFormTemplate);
                    ap.varValue = val;

                    activityParameters.Add(ap);
                }
            }
        }
    }
}