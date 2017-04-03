using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using System.Linq;
using bv.model.Model.Core;
using eidss.model.Resources;
using System.ComponentModel;

namespace eidss.web.common.Utils
{
    public static class SearchPanelHelper
    {
        public enum ValuePrefix
        {
            From,
            To,
            No
        }

        public static byte COMBOBOXES_ON_ADDITIONAL_PANEL_COUNT = 4;


        public static object GetDefaultValue(SearchPanelMetaItem item, IObject initSource, ValuePrefix prefix = ValuePrefix.No)
        {
            object result = null;
            if (item.DefaultValue != null)
            {

                if (item.IsRange && prefix == ValuePrefix.To && (item.EditorType == EditorType.Date || item.EditorType == EditorType.Datetime))
                    result = DateTime.Now;
                else
                    result = item.DefaultValue.Invoke(initSource);
            }
            else
            {
                if (item.EditorType == EditorType.Flag)
                {
                    result = false;
                }
                else
                {
                    result = initSource.GetValue(item.Name);
                }
            }
            return result;
        }

        public static FilterParams GetDefaultFilter(IEnumerable<SearchPanelMetaItem> searchPanel, IObject initSource, FilterParams addFilter = null)
        {
            var filter = new FilterParams();
            foreach (var item in searchPanel)
            {
                if (item.Location != SearchPanelLocation.Main)
                    continue;

                if (item.DefaultValue != null)
                {

                    if (item.IsRange)
                    {
                        if (item.EditorType == EditorType.Date || item.EditorType == EditorType.Datetime)
                        {
                            //DateTime range = Convert.ToDateTime(item.DefaultValue.Invoke());
                            //DateTime today = DateTime.Today;
                            //string rangeSign = today > range ? ">= " : "<=";
                            //string todaySign = today > range ? "<= " : ">=";
                            //filter.Add(item.Name, rangeSign, range);
                            //filter.Add(item.Name, todaySign, today);
                            var defVal = item.DefaultValue.Invoke(initSource);
                            if (defVal != null)
                            {
                                filter.Add(item.Name, ">=", defVal);
                                filter.Add(item.Name, "<=", DateTime.Now);
                            }
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
                            operation = item.EditorType == EditorType.Text ? "like" : "=";

                        filter.Add(item.Name, operation, item.DefaultValue.Invoke(initSource));
                    }
                }
                else
                {
                    if (item.EditorType == EditorType.Flag)
                    {
                        filter.Add(item.Name, "=", false);
                    }
                    else
                    {
                        var property = initSource.GetValue(item.Name);
                        if (property != null && !String.IsNullOrWhiteSpace(property.ToString()))
                        {
                            string operation = item.DefaultOper;

                            if (String.IsNullOrWhiteSpace(operation))
                                operation = item.EditorType == EditorType.Text ? "like" : "=";

                            filter.Add(item.Name, operation, property);
                        }
                    }

                }
            }

            filter = filter.Merge(addFilter);

            return filter;
        }

        public static MvcHtmlString CloseOpenRowCell()
        {
            return new MvcHtmlString("</tr><tr>");
        }
        public static MvcHtmlString CloseTableCell()
        {
            return new MvcHtmlString("</td>");
        }
        public static MvcHtmlString OpenTableCell()
        {
            return new MvcHtmlString("<td>");
        }

        public static IEnumerable<SelectListItem> GetComboSource(IEnumerable<bv.model.Model.Core.SearchPanelMetaItem> items)
        {
            List<SelectListItem> result = new List<SelectListItem>();
            //result.Add(new SelectListItem { Text = "", Value = "" });
            result.AddRange(from a in items
                            where (a.Location == bv.model.Model.Core.SearchPanelLocation.Combobox)
                            select new SelectListItem { Text = Translator.GetString(a.Name), Value = a.Name });

            return result;
        }

        private const string CACH_OBJECT_KEY = "CurrentObjectCachedCopy";
        private const string CBOX_PARAMETER_PATTERN = "CBox.{0}.{1}";


        private static object GetDependantProperty(bv.model.Model.Core.IObjectCreator accessor, string propertyName, string parameterName, object parameterValue)
        {
            if (accessor == null || String.IsNullOrWhiteSpace(propertyName))
                return null;

            using (bv.model.BLToolkit.DbManagerProxy dbmanager = bv.model.BLToolkit.DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                //create instance
                var obj = accessor.CreateNew(dbmanager, null, null);

                //set value of main property
                var settingProperty = obj.GetType().GetProperty(parameterName);

                if (settingProperty != null)
                    settingProperty.SetValue(obj, parameterValue, null);

                var property = obj.GetType().GetProperty(propertyName);

                if (property == null)
                    return null;

                return property.GetValue(obj, null);
            }
        }

        private static object GetPropertyValue(bv.model.Model.Core.IObjectCreator accessor, string propertyName)
        {
            if (accessor == null || String.IsNullOrWhiteSpace(propertyName))
                return null;

            using (bv.model.BLToolkit.DbManagerProxy dbmanager = bv.model.BLToolkit.DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var obj = accessor.CreateNew(dbmanager, null, null);
                var property = obj.GetType().GetProperty(propertyName);

                if (property == null)
                    return null;

                return property.GetValue(obj, null);
            }

        }


        public static IEnumerable<SelectListItem> GetLookup(bv.model.Model.Core.IObjectCreator accessor, bv.model.Model.Core.SearchPanelMetaItem item, string parameterName = null, object parameterValue = null)
        {
            List<SelectListItem> result = new List<SelectListItem>(); //if value can't be defined return empty list

            if (item.EditorType != bv.model.Model.Core.EditorType.Lookup)
                return result;

            var value = (parameterName != null && parameterValue != null)
                ? GetDependantProperty(accessor, item.LookupName, parameterName, parameterValue)
                : GetPropertyValue(accessor, item.LookupName);

            if (value == null)
                return result;

            var list = (IEnumerable)value;

            dynamic textFunction = item.LookupText, valueFuncton = item.LookupValue;
            foreach (var t in (IEnumerable)list)
            {
                result.Add(new SelectListItem { Text = textFunction(t), Value = Convert.ToString(valueFuncton(t)) });
            }
            return result;
        }

        private static object GetTypedValue(string type, string value, bool setDateToEndOfDay = false)
        {
            switch (type.ToLower())
            {
                case "date":
                case "datetime":
                    DateTime dt;
                    if (DateTime.TryParse(value, out dt))
                    {
                        if (setDateToEndOfDay)
                            return dt.AddDays(1).AddMilliseconds(-1);
                        else
                            return dt;
                    }
                    break;
                case "int":
                    int i;
                    if (int.TryParse(value, out i))
                        return i;
                    break;
                case "string":
                    return value;
                case "lookup":
                    long t;
                    if (long.TryParse(value, out t))
                        return t;
                    break;

            }
            return DBNull.Value;
        }

        public static FilterParams DuplicatesFilter(System.Web.HttpRequestBase request)
        {
            FilterParams result = new FilterParams();

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

        public static FilterParams SearchPanelParseValues(string formData, List<SearchPanelMetaItem> searchPanelMeta)
        {
            NameValueCollection formCollection = HttpUtility.ParseQueryString(formData);
            FilterParams filter = SearchPanelParseValues(formCollection, searchPanelMeta);
            return filter;
        }

        public static FilterParams SearchPanelParseValues(NameValueCollection collection, List<SearchPanelMetaItem> searchPanelMeta)
        {
            var result = new FilterParams();
            string[] helpers;
            string[] ignoredKeys = new string[collection.AllKeys.Length];
            int counter = 0;

            foreach (string key in collection.AllKeys)
            {
                if (String.IsNullOrWhiteSpace(collection[key]) || ignoredKeys.Contains(key) || key.ToLower().EndsWith("input") || key.ToLower().EndsWith("-text"))
                    continue;

                helpers = key.Split('_');

                if (helpers.Length <= 1)
                    continue;

                if (helpers[1].ToLower() == "operand")
                    continue;

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
                        result.Add(
                             helpers[2],
                             (helpers[1].ToLower() == "from") ? ">=" : "<",
                              GetTypedValue(helpers[0], collection[key], (helpers[1].ToLower() == "to"))
                             );
                        ignoredKeys[counter++] = key;
                    }
                }
                else
                {
                    //get operand for item
                    var name = helpers[1].Replace("-", "");
                    var meta = searchPanelMeta.Single(x => x.Name == name && (x.Location == SearchPanelLocation.Main || x.Location == SearchPanelLocation.Additional));
                    string operand = meta.DefaultOper ?? "=";
                    if (helpers[0].ToLower() == "string")
                        result.Add(name,
                            "LIKE",
                            String.Format("{0}", collection[key]));
                    else
                    {
                        if (helpers[0].ToLower() == "flag")
                        {
                            //if (Convert.ToBoolean(collection[key].Split(',')[0]))
                            result.Add(name, operand, Convert.ToBoolean(collection[key].Split(',')[0]));
                        }
                        else if (helpers[0].ToLower() == "lookupmultiple")
                        {
                            string[] values = collection[key].Split(',');
                            foreach (var val in values)
                            {
                                result.Add(name, meta.IsBitMask ? "&" : operand, val, true);
                            }
                        }
                        else
                        {
                            if (helpers[0].ToLower() == "lookup" && collection[key] == "0")
                                continue;

                            result.Add(name,
                                       operand, //how to get default operand?
                                       GetTypedValue(helpers[0], collection[key], operand.Contains("<")));
                        }
                        ignoredKeys[counter++] = key;
                    }
                }
            }

            var flagItems = searchPanelMeta.Where(x => x.EditorType == EditorType.Flag);
            if (flagItems.Count() > 0)
            {
                foreach (var item in flagItems)
                {
                    if (!result.Contains(item.Name))
                        result.Add(item.Name, "=", false);
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
            if (orderByComponents.Length < 2)
            {
                return new string[0];
            }
            return orderByComponents;
        }
    }
}