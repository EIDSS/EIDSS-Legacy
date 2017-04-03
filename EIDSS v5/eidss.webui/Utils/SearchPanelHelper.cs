using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Collections;
using System.Linq;
using bv.model.Model.Core;
using eidss.model.Resources;

namespace eidss.webui.Utils
{
    public static class SearchPanelHelper
    {
        public static MvcHtmlString CloseTableCell()
        {
            return new MvcHtmlString("</td></tr><tr><td>");
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

            using (bv.model.BLToolkit.DbManagerProxy dbmanager = bv.model.BLToolkit.DbManagerFactory.Factory.Create())
            {
                //create instance
                var obj = accessor.CreateNew(dbmanager, null);
                
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

            using (bv.model.BLToolkit.DbManagerProxy dbmanager = bv.model.BLToolkit.DbManagerFactory.Factory.Create())
            {
                var obj = accessor.CreateNew(dbmanager, null);
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

        private static object GetTypedValue(string type, string value)
        {
            switch (type.ToLower())
            {
                case "date" :
                case "datetime" :
                    DateTime dt;
                    if (DateTime.TryParse(value, out dt))
                        return dt;
                    break;
                case "int" :
                    int i;
                    if (int.TryParse(value, out i))
                        return i;
                    break;
                case "string" :
                    return value;
                case "lookup" :
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
                    continue;
                result.Add(key, "=", request.QueryString[key]);
            }
            return result;
        }

        public static FilterParams SearchPanelParseValues(System.Web.HttpRequestBase request)
        {
            FilterParams result = new FilterParams();
            string[] helpers;
            string[] ignoredKeys = new string[request.Form.AllKeys.Length];
            int counter = 0;
            foreach (string key in request.Form.AllKeys)
            {
                if (String.IsNullOrWhiteSpace(request.Form[key]) || ignoredKeys.Contains(key) || key.ToLower().EndsWith("input"))
                    continue;

                helpers = key.Split('.');                

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
                            request.Form[String.Format(CBOX_PARAMETER_PATTERN, "Item", helpers[2])],
                            request.Form[String.Format(CBOX_PARAMETER_PATTERN, "Operand", helpers[2])],
                            request.Form[String.Format(CBOX_PARAMETER_PATTERN, "Value", helpers[2])]
                            );
                        ignoredKeys[counter++] = String.Format(CBOX_PARAMETER_PATTERN, "Item", helpers[2]);
                        ignoredKeys[counter++] = String.Format(CBOX_PARAMETER_PATTERN, "Operand", helpers[2]);
                        ignoredKeys[counter++] = String.Format(CBOX_PARAMETER_PATTERN, "Value", helpers[2]);
                    }
                    else //interval values
                    {
                        result.Add(
                             helpers[2],
                             (helpers[1].ToLower() == "from") ? ">=" : "<=",
                              GetTypedValue(helpers[0], request[key])
                             );
                        ignoredKeys[counter++] = key;
                    }
                }
                else
                {
                    if (helpers[0].ToLower() == "string")
                        result.Add(helpers[1],
                            "LIKE",
                            String.Format("%{0}%", request[key]));
                    else
                        result.Add(helpers[1],
                            "=",
                           GetTypedValue(helpers[0], request[key]));
                    ignoredKeys[counter++] = key;
                }
            }
            return result;
        }
    }
}