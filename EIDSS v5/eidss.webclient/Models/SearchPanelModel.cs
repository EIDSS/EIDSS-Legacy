using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bv.model.Model.Core;
using System.Web.Mvc;
using System.Collections;
using eidss.webclient.Utils;

namespace eidss.webclient.Models
{
    public class SearchPanelModelItem
    {
        public SearchPanelMetaItem Item { get; set; }
        public object Value { get; set; }
        public object ValueFrom { get; set; }
        public object ValueTo { get; set; }
        public string ControlName { get { return _controlName; } }
        public string ControlNameFrom { get { return _controlNameFrom; } }
        public string ControlNameTo { get { return _controlNameTo; } }


        private string _controlName, _controlNameFrom, _controlNameTo;
        private byte _objNameIndex;
        public SearchPanelModelItem(SearchPanelMetaItem item, object valueFrom, object valueTo = null, byte objNameIndex = 0)
        {
            Item = item;
            _objNameIndex = objNameIndex;
            if (item.IsRange)
            {
                _controlNameFrom = GetControlName(GetBaseName(), "From");
                _controlNameTo = GetControlName(GetBaseName(), "To");
                ValueFrom = valueFrom;
                ValueTo = valueTo;
            }
            else
            {
                _controlName = GetControlName(GetBaseName());
                Value = ValueFrom;
            }
        }


        private string GetBaseName()
        {
            if (Item.Location == SearchPanelLocation.Combobox)
                return "CBox";
            switch (Item.EditorType)
            {
                case EditorType.Flag: return "Flag";
                case EditorType.Date: return "Date";
                case EditorType.Datetime: return "DateTime";
                case EditorType.Lookup: return "Lookup";
                case EditorType.Numeric: return "Int";
                case EditorType.Text: return "String";
                default: return string.Empty;
            }
        }


        private string GetControlName(string baseName, string intervalPart = "")
        {
            if (Item.Location == bv.model.Model.Core.SearchPanelLocation.Combobox)
            {
                if (!baseName.StartsWith("CBox"))
                    baseName = "CBox.Value";

                return String.Format("{0}.{1}", baseName, _objNameIndex);
            }
            else
            {
                if (intervalPart.Length > 0)
                    intervalPart += ".";
                return String.Format("{0}.{1}{2}", baseName, intervalPart, Item.Name.Replace(" ", ""));
            }
        }

    }


    public class SearchPanelModel
    {
        public List<SearchPanelMetaItem> SearchPanelItems { get; set; }
        public IObject ResultObjectInstance { get; set; }
        public FilterParams CurrentFilter;
        public Guid Id { get { return _id; } }
        public bool IsDefaultFilter { get; set; }
        private Guid _id;
        public SearchPanelModel(List<SearchPanelMetaItem> panel, IObject instance, FilterParams filter)
        {
            SearchPanelItems = panel;
            ResultObjectInstance = instance;
            CurrentFilter = filter;
            _id = Guid.NewGuid();
        }


        public bool FieldIsHiddenPersonalData(string name)
        {
            return ResultObjectInstance.IsHiddenPersonalData(name);
        }

        public List<SearchPanelMetaItem> SearchPanelItemsBasic { get { return SearchPanelItems.Where(m => m.Location == SearchPanelLocation.Main).ToList(); } }
        public List<SearchPanelMetaItem> SearchPanelItemsAdditional { get { return SearchPanelItems.Where(m => m.Location == SearchPanelLocation.Additional).ToList(); } }
        public List<SearchPanelMetaItem> SearchPanelItemsCombo { get { return SearchPanelItems.Where(m => m.Location == SearchPanelLocation.Combobox).ToList(); } }


        public MvcHtmlString GetScriptForCombo()
        {
           System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type='text/javascript' language='javascript'>\r\n");
            sb.Append("$(document).ready(function () {\r\n");
            if (IsDefaultFilter)
            {
                foreach (var item in SearchPanelItemsBasic.Where(x => x.EditorType == EditorType.Lookup && !String.IsNullOrEmpty(x.Dependent)))
                {
                    if (CurrentFilter.Contains(item.Name))
                    {
                        sb.AppendFormat("$('#Lookup_{0}-input').val('{1}');\r\n", item.Name, SearchPanelDataExtractor.GetLookupSelectionText(item, ResultObjectInstance, CurrentFilter.Value(item.Name).ToString()));
                        sb.AppendFormat("$('#Lookup_{0}-value').val('{1}');\r\n", item.Name, CurrentFilter.Value(item.Name));
                    }
                }
            }
            sb.Append("$('#LoadingHelper').change(function() {ReloadSlaves(); }) \r\n});\r\n");
            sb.Append("</script>");            

            return new MvcHtmlString(sb.ToString());
        }
    }

    public static class SearchPanelDataExtractor
    {
        public static string GetLookupSelectionText(SearchPanelMetaItem item, IObject source, string value)
        {
            var lookup = GetLookup(source, item);
            if (lookup.Count(x => x.Value == value) > 0)
            {
                return lookup.Where(x => x.Value == value).First().Text;
            }
            else
            {
                return string.Empty;
            }

        }

        public static List<SelectListItem> GetLookup(IObject source, SearchPanelMetaItem item, string masterField = null, object masterValue = null, object initValue = null)
        {
            List<SelectListItem> result = new List<SelectListItem>();

            object value = null;
            if (masterField != null)
            {
                var settingProperty = source.GetType().GetProperty(masterField);

                if (settingProperty != null)
                    settingProperty.SetValue(source, masterValue, null);

                value = source.GetType().GetProperty(item.LookupName).GetValue(source, null);
            }
            else
            {
                value = source.GetType().GetProperty(item.LookupName).GetValue(source, null);
            }
            var list = (IEnumerable)value;

            dynamic textFunction = item.LookupText, valueFuncton = item.LookupValue;
            foreach (var t in (IEnumerable)list)
            {
                result.Add(new SelectListItem { Text = textFunction(t), Value = Convert.ToString(valueFuncton(t)), Selected = valueFuncton(t).ToString().Equals(initValue) });
            }
            return result;
        }

        public static ViewDataDictionary GetDataForItem(string modelGuid, SearchPanelMetaItem item, IObject source, FilterParams filter, bool isdependant = false, bool isHiddenPersonalData = false)
        {
            string fieldName = item.Name;
            var vd = new ViewDataDictionary();
            foreach (var i in GetValuePair(filter, fieldName))
            {
                if (!vd.ContainsKey(i.Key))
                    vd.Add(i);
            }
            vd.Add("IsHiddenPersonalData", isHiddenPersonalData);
            if (item.EditorType == EditorType.Lookup)
            {
                vd.Add("LookupList", GetLookup(source, item));
                vd.Add("IsDependant", isdependant);
                vd.Add("Source", source);
                vd.Add("ModelGuid", modelGuid);
            }
            if (item.IsMandatory)
            {
                if (item.IsRange)
                {
                    vd.Add("DefaultValueFrom", SearchPanelHelper.GetDefaultValue(
                        item,
                        source,
                        SearchPanelHelper.ValuePrefix.From));
                    vd.Add("DefaultValueTo", SearchPanelHelper.GetDefaultValue(
                        item,
                        source,
                        SearchPanelHelper.ValuePrefix.To));
                }
                else
                    vd.Add("DefaultValue", SearchPanelHelper.GetDefaultValue(
                            item,
                            source,
                            SearchPanelHelper.ValuePrefix.No));
            }
            return vd;
        }


        private static List<KeyValuePair<string, object>> GetValuePair(FilterParams filter, string fieldName)
        {

            var list = new List<KeyValuePair<string, object>>();
            if (filter.Contains(fieldName))
            {
                for (int i = 0; i < filter.ValueCount(fieldName); i++)
                {
                    string viewDataField = "Value";

                    object value = filter.Value(fieldName, i);
                    var operation = filter.Operation(fieldName, i);
                    if (operation == null && value == null)
                    {
                        value = "true";
                    }
                    else
                    {
                        if ((operation == ">" || operation == ">=") && filter.ValueCount(fieldName) == 2)
                            viewDataField += "From";
                        else
                            if ((operation == "<" || operation == "<=") && filter.ValueCount(fieldName) == 2)
                                viewDataField += "To";
                            else
                                if (operation.Equals("like", StringComparison.InvariantCultureIgnoreCase))
                                    if (value.ToString().StartsWith("%") && value.ToString().EndsWith("%"))
                                        value = value.ToString().Substring(1, value.ToString().Length - 2);
                    }
                    list.Add(new KeyValuePair<string, object>(viewDataField, value));
                }
            }

            return list;
        }
    }
}