using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using System.Linq;
using bv.model.Model.Core;
using bv.model.BLToolkit;

namespace eidss.mobileclient.Utils
{
    public static class SearchPanelHelper
    {
        public static FilterParams GetDefaultFilter(IEnumerable<SearchPanelMetaItem> searchPanel, IObject initSource)
        {
            var filter = new FilterParams();
            foreach (var item in searchPanel)
            {
                if (item.DefaultValue != null)
                {
                    if (item.IsRange)
                    {
                        if (item.EditorType == EditorType.Date || item.EditorType == EditorType.Datetime)
                        {
                            filter.Add(item.Name, ">=", item.DefaultValue.Invoke(initSource));
                            filter.Add(item.Name, "<=", DateTime.Now.Date.AddDays(1).AddSeconds(-1));
                        }
                        else
                        {
                            filter.Add(item.Name, "<=", item.DefaultValue.Invoke(initSource));
                            filter.Add(item.Name, ">=", item.DefaultValue.Invoke(initSource));
                        }
                    }
                    else
                    {
                        string operation = item.DefaultOper;
                        if (String.IsNullOrWhiteSpace(operation))
                        {
                            operation = item.EditorType == EditorType.Text ? "like" : "=";
                        }
                        filter.Add(item.Name, operation, item.DefaultValue.Invoke(initSource));
                    }
                }
            }
            return filter;
        }

        public static MvcHtmlString CloseTableCell()
        {
            return new MvcHtmlString("</td></tr><tr><td>");
        }
        public static IEnumerable<SelectListItem> GetComboSource(IEnumerable<SearchPanelMetaItem> items)
        {
            var result = new List<SelectListItem>();
            //result.Add(new SelectListItem { Text = "", Value = "" });
            result.AddRange(from a in items
                            where (a.Location == SearchPanelLocation.Combobox)
                            select new SelectListItem { Text = Translator.GetString(a.Name), Value = a.Name });

            return result;
        }

        private const string CACH_OBJECT_KEY = "CurrentObjectCachedCopy";
        private const string CBOX_PARAMETER_PATTERN = "CBox.{0}.{1}";

        
        private static object GetDependantProperty(IObjectCreator accessor, string propertyName, string parameterName, object parameterValue)
        {
            if (accessor == null || String.IsNullOrWhiteSpace(propertyName))
            {
                return null;
            }

            using (DbManagerProxy dbmanager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                //create instance
                var obj = accessor.CreateNew(dbmanager, null, null);
                
                //set value of main property
                var settingProperty = obj.GetType().GetProperty(parameterName);

                if (settingProperty != null)
                {
                    settingProperty.SetValue(obj, parameterValue, null);
                }

                var property = obj.GetType().GetProperty(propertyName);

                if (property == null)
                {
                    return null;
                }

                return property.GetValue(obj, null);
            }
        }

        private static object GetPropertyValue(IObjectCreator accessor, string propertyName)
        {
            if (accessor == null || String.IsNullOrWhiteSpace(propertyName))
            {
                return null;
            }

            using (DbManagerProxy dbmanager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var obj = accessor.CreateNew(dbmanager, null, null);
                var property = obj.GetType().GetProperty(propertyName);

                if (property == null)
                {
                    return null;
                }

                return property.GetValue(obj, null);
            }

        }


        public static IEnumerable<SelectListItem> GetLookup(IObjectCreator accessor, SearchPanelMetaItem item, IObject initSource, string parameterName = null, object parameterValue = null)
        {
            var result = new List<SelectListItem>(); //if value can't be defined return empty list
            
            if (item.EditorType != EditorType.Lookup)
            {
                return result;
            }

            var value = (parameterName != null && parameterValue != null)
                ? GetDependantProperty(accessor, item.LookupName, parameterName, parameterValue)
                : GetPropertyValue(accessor, item.LookupName);

            if (value == null)
            {
                return result;
            }

            var list = (IEnumerable)value;

            dynamic textFunction = item.LookupText, valueFuncton = item.LookupValue;

            string defaultValue = item.DefaultValue == null ? null : item.DefaultValue.Invoke(initSource).ToString();

            foreach (var t in list)
            {
                string itemValue = Convert.ToString(valueFuncton(t));
                bool selected = !string.IsNullOrEmpty(defaultValue) && itemValue == defaultValue ? true : false;
                var listItem = new SelectListItem {Text = textFunction(t), Value = itemValue, Selected = selected};
                result.Add(listItem);
                
            }
            return result;
        }

        private static object GetTypedValue(string type, string value)
        {
            switch (type.ToLower())
            {
                case "date" :
                case "datetime" :
                    DateTime dt;
                    if (DateTime.TryParse(value, out dt))
                    {
                        return dt;
                    }
                    break;
                case "int" :
                    Int32 i;
                    if (Int32.TryParse(value, out i))
                    {
                        return i;
                    }
                    break;
                case "string" :
                    return value;
                case "lookup" :
                    Int64 t;
                    if (Int64.TryParse(value, out t))
                    {
                        return t;
                    }
                    break;
            }
            return DBNull.Value;
        }

        public static FilterParams DuplicatesFilter(HttpRequestBase request)
        {
            var result = new FilterParams();

            foreach (var key in request.QueryString.AllKeys)
            {
                if (String.IsNullOrWhiteSpace(request.QueryString[key]))
                {
                    continue;
                }
                if (key == "idfsTentativeDiagnosis" && !String.IsNullOrWhiteSpace(request.QueryString["idfsFinalDiagnosis"]))
                {
                    continue;
                }
                result.Add(key, "=", request.QueryString[key]);
            }
            return result;
        }

        public static FilterParams SearchPanelParseValues(string formData)
        {
            NameValueCollection formCollection = HttpUtility.ParseQueryString(formData);
            FilterParams filter = SearchPanelParseValues(formCollection);
            return filter;
        }

        public static FilterParams SearchPanelParseValues(NameValueCollection collection)
        {
            var result = new FilterParams();
            string[] helpers;
            string[] ignoredKeys = new string[collection.AllKeys.Length];
            int counter = 0;
            foreach (string key in collection.AllKeys)
            {
                if (String.IsNullOrWhiteSpace(collection[key]) || ignoredKeys.Contains(key) || key.ToLower().EndsWith("input") || key.ToLower().EndsWith("-text"))
                {
                    continue;
                }

                helpers = key.Split('.');

                if (helpers.Length <= 1)
                {
                    continue;
                }

                if (helpers[0].ToLower() == "lookup" && collection[key] == "0")
                {
                    continue;
                }

                if (helpers[1].ToLower() == "operand")
                {
                    continue;
                }

                //helpers is an array of strings helping to define param 

                if (helpers.Length >= 3) //it means the item is interval or from combobox
                {
                    if (helpers[0].Equals("CBox", StringComparison.InvariantCultureIgnoreCase))//value from combobox
                    {
                        // find all parts, include all to ignored keys
                        result.Add(
                            collection[String.Format(CBOX_PARAMETER_PATTERN, "Item", helpers[2])],
                            collection[String.Format(CBOX_PARAMETER_PATTERN, "Operand", helpers[2])],
                            collection[String.Format(CBOX_PARAMETER_PATTERN, "Value", helpers[2])]
                            );
                        ignoredKeys[counter++] = String.Format(CBOX_PARAMETER_PATTERN, "Item", helpers[2]);
                        ignoredKeys[counter++] = String.Format(CBOX_PARAMETER_PATTERN, "Operand", helpers[2]);
                        ignoredKeys[counter++] = String.Format(CBOX_PARAMETER_PATTERN, "Value", helpers[2]);
                    }
                    else //interval values
                    {
                        if (helpers[2].Contains("_Day"))
                        {
                            DateTime? date = DateTimeHelper.GetDateForFilterByKey(collection, key.Replace("_Day", ""));
                            if (date.HasValue)
                            {
                                result.Add(helpers[2].Replace("_Day", ""), (helpers[1].ToLower() == "from") ? ">=" : "<=", date);
                            }
                        }
                        else if (!helpers[2].Contains("_Month") && !helpers[2].Contains("_Year"))
                        {
                            result.Add(
                                helpers[2],
                                (helpers[1].ToLower() == "from") ? ">=" : "<=",
                                GetTypedValue(helpers[0], collection[key])
                                );
                        }
                        ignoredKeys[counter++] = key;
                    }
                }
                else
                {
                    if (helpers[0].ToLower() == "string")
                    {
                        result.Add(helpers[1], "LIKE", String.Format("%{0}%", collection[key]));
                    }
                    else
                    {
                        if (helpers[0].ToLower() == "flag")
                        {
                            if (Convert.ToBoolean(collection[key].Split(',')[0]))
                            {
                                result.Add(helpers[1], null, null);
                            }
                        }
                        else
                        {
                            result.Add(helpers[1], "=", GetTypedValue(helpers[0], collection[key]));
                        }
                        ignoredKeys[counter++] = key;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderBy">example: coluntName-asc</param>
        /// <returns>result[0] = "coluntName", result[1] = "asc"</returns>
        public static string[] GetSortOrderFromAjaxString(string orderBy)
        {
            if (String.IsNullOrEmpty(orderBy))
            {
                return new string[0];
            }

            string[] orderByComponents = orderBy.Split('-');
            if(orderByComponents.Length < 2)
            {
                return new string[0];
            }
            return orderByComponents;
        }
    }
}
