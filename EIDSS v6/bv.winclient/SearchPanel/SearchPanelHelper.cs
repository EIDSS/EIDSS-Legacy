using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using bv.common.Core;
using bv.common.Resources;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.model.Model.Validators;
using bv.winclient.Core;
using DevExpress.XtraEditors;
using System.Globalization;
using System.Text.RegularExpressions;

namespace bv.winclient.SearchPanel
{
    public class SearchPanelHelper
    {
        public static List<object> GetSearchCaseByType(EditorType editorType)
        {
            switch (editorType)
            {
                case EditorType.Text:
                    return new List<object> { new { Name = "=", Value = "=" }, new { Name = "<>", Value = "<>" }, new { Name = ">", Value = ">=" }, new { Name = "<", Value = "<=" }, new { Name = "Like", Value = "Like" } }; //{"=", "<>", ">", "<", "Like"};

                case EditorType.Lookup:
                    return new List<object> { new { Name = "=", Value = "=" }, new { Name = "<>", Value = "<>" } };

                case EditorType.Date:
                case EditorType.Datetime:
                case EditorType.Numeric:
                    return new List<object>  { new { Name = "=", Value = "=" }, new { Name = "<>", Value = "<>" }, new { Name = ">", Value = ">=" }, new { Name = "<", Value = "<=" } };
                default:
                    return null;
            }
        }

        public static object GetCurrentItemValue(IObject obj, SearchPanelMetaItem metaItem)
        {
            PropertyInfo property = obj.GetType().GetProperty(metaItem.Name);
            var value = property.GetValue(obj, null);
            return value;
        }


        /// <summary>
        ///   Get list value for combobox
        /// </summary>
        /// <param name = "accessor"></param>
        /// <param name = "metaItem"></param>
        /// <param name = "parameterMetaItem"></param>
        /// <param name = "parameterValue"></param>
        /// <returns></returns>
        public static List<object> GetItemList
            (IObject obj, SearchPanelMetaItem metaItem, SearchPanelMetaItem parameterMetaItem = null,
             object parameterValue = null)
        {
            string propertyName = metaItem.LookupName;
            string parameterName = parameterMetaItem != null ? parameterMetaItem.Name : "";

            using (DbManagerProxy managerProxy = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                PropertyInfo settingProperty = obj.GetType().GetProperty(parameterName);

                if (settingProperty != null)
                {
                    settingProperty.SetValue(obj, parameterValue, null);
                }

                if (string.IsNullOrWhiteSpace(propertyName))
                {
                    return new List<object>();
                }

                ((ILookupUsage) obj).ReloadLookupItem(managerProxy, propertyName);
                PropertyInfo property = obj.GetType().GetProperty(propertyName);

                if (property != null)
                {
                    var list = (IEnumerable) property.GetValue(obj, null);
                    

                    if (list != null)
                    {
                        var itemList = new List<object>();

                        //object firstItem = new
                        //{
                        //    Name = "",
                        //    Value = ""
                        //};
                        //itemList.Add(firstItem);


                        foreach (object item in list)
                        {
                            string name = metaItem.LookupText(item);
                            string value = Convert.ToString(metaItem.LookupValue(item));
                            object obj2 = new
                                              {
                                                  Name = name,
                                                  Value = value
                                              };
                            itemList.Add(obj2);
                        }
                        return itemList;
                    }
                }
                return new List<object>();
            }
        }


        /// <summary>
        ///   Get list value for combobox
        /// </summary>
        /// <param name = "obj">IObject</param>
        /// <param name = "metaItem"></param>
        /// <param name = "parameterMetaItem"></param>
        /// <param name = "parameterValue"></param>
        /// <returns></returns>
        public static BvSelectList GetList
            (IObject obj, SearchPanelMetaItem metaItem, SearchPanelMetaItem parameterMetaItem = null,
             object parameterValue = null)
        {
            /// delete part of name "Lookup"
            var regex = new Regex("(.*)Lookup");
            var match = regex.Match(metaItem.LookupName);
            string itemListName = (match.Groups.Count < 2) 
                ? metaItem.LookupName
                : match.Groups[1].Value;

            //string itemListName = metaItem.LookupName.Replace("Lookup", "");
            var list = obj.GetList(itemListName);
            return list;
        }
        /// <summary>
        ///  Geting caption by metaitem's LabelId 
        /// </summary>
        /// <param name="metaItem"></param>
        /// <returns></returns>
        public static string GetCaption(SearchPanelMetaItem metaItem)
        {
            string id = metaItem.LabelId;
            return GetCaption(id);
        }
        /// <summary>
        /// Geting caption by LabelId 
        /// </summary>
        /// <param name="labelId"></param>
        /// <returns></returns>
        public static string GetCaption(string labelId)
        {
            var cultureName =  Localizer.GetLanguageID(Thread.CurrentThread.CurrentCulture);

            string id = labelId;
            return WinClientContext.FieldCaptions != null
                       ? WinClientContext.FieldCaptions.GetString(id, id, cultureName)
                       : id;
        }
        public static string GetText(SearchPanelMetaItem metaItem)
        {
            string id = metaItem.LabelId;
            return GetText(id);
        }
        public static string GetText(string labelId)
        {
            string id = labelId;
            return BvMessages.Get(id, id);
        }

        /// <summary>
        /// Get FilterParams by linked content
        /// </summary>
        /// <param name="linkedContent"></param>
        /// <returns></returns>
        public static FilterParams GetFilterParams(IObject obj, LinkedContent linkedContent)
        {
            var filterParams = new FilterParams();

            var notComboboxLinkedContext = linkedContent.m_LinkedItems.Where(s => s.MetaItem.Location != SearchPanelLocation.Combobox && s.MetaItem.Location != SearchPanelLocation.Toolbox);
            var comboboxLinkedContext = linkedContent.m_LinkedItems.Where(s => s.MetaItem.Location == SearchPanelLocation.Combobox || s.MetaItem.Location == SearchPanelLocation.Toolbox);
           
                foreach (
                    var control in
                        notComboboxLinkedContext.Where(f => f.MetaItem.EditorType == EditorType.Text))
                {
                    if (!String.IsNullOrEmpty(control.Controls.First().Text))
                    {
                        filterParams.Add(control.MetaItem.Name, Utils.IsEmpty(control.MetaItem.DefaultOper) ? "Like" : control.MetaItem.DefaultOper, control.Controls.First().Text);
                    }
                    else if (control.MetaItem.Mandatory(obj))
                    {
                        throw new ValidationModelException("strSearchPanelMandatoryFields_msgId", control.MetaItem.Name, control.MetaItem.Name, null, typeof(RequiredValidator), false, obj);
                    }
                }
                foreach (
                    var control in
                        notComboboxLinkedContext.Where(f => f.MetaItem.EditorType == EditorType.Numeric).Where(
                f => f.MetaItem.IsRange == false)/*.Where(d => !string.IsNullOrWhiteSpace(d.Controls.First().Text))*/)
                {
                    if (!control.Controls.First().Visible)
                    {
                        object val = obj.GetValue(control.MetaItem.Name);
                        if (val != null)
                        {
                            filterParams.Add(control.MetaItem.Name, Utils.IsEmpty(control.MetaItem.DefaultOper) ? "=" : control.MetaItem.DefaultOper, val, EditorType.Numeric);
                        }
                    }
                    if (!Utils.IsEmpty(control.Controls.First().EditValue))
                    {
                        filterParams.Add(control.MetaItem.Name, Utils.IsEmpty(control.MetaItem.DefaultOper) ? "=" : control.MetaItem.DefaultOper, control.Controls.First().Text, EditorType.Numeric);
                    }
                }

                foreach (
                       var control in
                           notComboboxLinkedContext.Where(f => f.MetaItem.EditorType == EditorType.Numeric).Where(f => f.MetaItem.IsRange))
                {
                    List<BaseEdit> contr = control.Controls.ToList();
                    if (!Utils.IsEmpty(contr[0].EditValue))
                    {
                        filterParams.Add(control.MetaItem.Name, ">=", contr[0].Text, EditorType.Numeric);
                    }
                    if (!Utils.IsEmpty(contr[1].EditValue))
                    {
                        filterParams.Add(control.MetaItem.Name, "<=", contr[1].Text, EditorType.Numeric);
                    }
                }

                foreach (
                    var control in
                        notComboboxLinkedContext.Where(f => f.MetaItem.EditorType == EditorType.Date).Where(
                            f => f.MetaItem.IsRange == false).Where(d => !string.IsNullOrWhiteSpace(d.Controls.First().Text)))
                {
                    if (!Utils.IsEmpty(control.Controls.First().EditValue))
                    {
                        DateTime start;
                        if (DateTime.TryParseExact(control.Controls.First().Text, CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern, CultureInfo.InvariantCulture, DateTimeStyles.None, out start))
                        {
                            filterParams.Add(control.MetaItem.Name,
                                string.IsNullOrEmpty(control.MetaItem.DefaultOper) ? "=" : control.MetaItem.DefaultOper, 
                                start, EditorType.Date);
                        }
                    }
                }
                foreach (
                    var control in
                        notComboboxLinkedContext.Where(f => f.MetaItem.EditorType == EditorType.Date).Where(f => f.MetaItem.IsRange))
                {
                    List<BaseEdit> contr = control.Controls.ToList();

                    bool bStart = false;
                    DateTime start;
                    if (DateTime.TryParseExact(contr[0].Text, CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern, CultureInfo.InvariantCulture, DateTimeStyles.None, out start))
                    {
                        filterParams.Add(control.MetaItem.Name, ">=", start, EditorType.Date);
                        bStart = true;
                    }
                    bool bEnd = false;
                    DateTime end;
                    if (DateTime.TryParseExact(contr[1].Text, CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern, CultureInfo.InvariantCulture, DateTimeStyles.None, out end))
                    {
                        filterParams.Add(control.MetaItem.Name, "<", end.AddDays (1), EditorType.Date);
                        bEnd = true;
                    }

                    if (control.MetaItem.Mandatory(obj) && (!bStart || !bEnd))
                    {
                        throw new ValidationModelException("strSearchPanelMandatoryFields_msgId", control.MetaItem.Name, control.MetaItem.Name, null, typeof(RequiredValidator), false, obj);
                    }

                    //if (!string.IsNullOrWhiteSpace(contr[0].Text))
                    //{
                    //    filterParams.Add(control.MetaItem.Name, ">=", contr[0].Text, EditorType.Datetime);
                    //}
                    //if (!string.IsNullOrWhiteSpace(contr[1].Text))
                    //{
                    //    filterParams.Add(control.MetaItem.Name, "<=", contr[1].Text, EditorType.Datetime);
                    //}
                }
                foreach (
                   var control in
                        notComboboxLinkedContext.Where(f => f.MetaItem.EditorType == EditorType.Lookup && !f.MetaItem.IsMultiple))
                {
                    var cntrl = (control.Controls.First() as LookUpEdit);
                    var lookUpEditValue = cntrl.EditValue as IObject;
                    //if (!Utils.IsEmpty(lookUpEditValue))
                    if (lookUpEditValue != null)
                    {
                        if ((long)lookUpEditValue.Key != 0)
                        {
                            filterParams.Add(control.MetaItem.Name, "=", lookUpEditValue.Key);
                        }
                    }
                    else if(!Utils.IsEmpty(cntrl.EditValue))//This is the case of Case_Status lookup, we use custom values for it
                    {
                        filterParams.Add(control.MetaItem.Name, "=", cntrl.EditValue);                       
                    }
                }
                foreach (
                   var control in
                        notComboboxLinkedContext.Where(f => f.MetaItem.EditorType == EditorType.Lookup && f.MetaItem.IsMultiple))
                {
                    var cntrl = (control.Controls.First() as PopupContainerEdit);
                    var container = cntrl.Properties.PopupControl;
                    var list = container.Controls[0] as CheckedListBoxControl;
                    foreach(var i in list.CheckedItems)
                    {
                        var o = i as IObject;
                        if (o == null)
                            continue;
                        if (0L.Equals(o.Key))
                            continue;
                        if(control.MetaItem.IsBitMask)
                            filterParams.Add(control.MetaItem.Name, "&", o.Key, true);
                        else
                           filterParams.Add(control.MetaItem.Name, "=", o.Key, true);
                    }
                }


            foreach (
                var control in
                    comboboxLinkedContext.Where(f => f.MetaItem.IsMultiple))
                {
                    var cntrl = (control.Controls.ToArray()[2] as PopupContainerEdit);
                    var container = cntrl.Properties.PopupControl;
                    var list = container.Controls[0] as CheckedListBoxControl;
                    foreach (var i in list.CheckedItems)
                    {
                        var o = i as IObject;
                        if (o == null)
                            continue;
                        if (0L.Equals(o.Key))
                            continue;
                        if (control.MetaItem.IsBitMask)
                            filterParams.Add(control.MetaItem.Name, "&", o.Key, true);
                        else
                            filterParams.Add(control.MetaItem.Name, "=", o.Key, true);
                    }
                }

            foreach (
                var control in
                    comboboxLinkedContext.Where(f => !f.MetaItem.IsMultiple))
            {
                var controlWithValue = control.Controls.ToArray()[2] as BaseEdit;
                var condition = control.MetaItem.IsRange ? ">=" : control.Controls.ToArray()[1].EditValue.ToString();
                object value = null;

                if (controlWithValue.Controls.Count == 4) // panel with range controls
                {
                    var cnt1 = controlWithValue.Controls[1];
                    var cnt2 = controlWithValue.Controls[3];
                    if (cnt1 is DateEdit)
                    {
                        value = (cnt1 as DateEdit).EditValue;
                        if (!Utils.IsEmpty(value))
                            filterParams.Add(control.MetaItem.Name, ">=", value); 
                    }
                    if (cnt2 is DateEdit)
                    {
                        value = (cnt2 as DateEdit).EditValue;
                        if (!Utils.IsEmpty(value))
                            filterParams.Add(control.MetaItem.Name, "<=", value);
                    }
                }

                if (!Utils.IsEmpty(controlWithValue.EditValue) && !String.IsNullOrWhiteSpace(condition))
                {

                    if (controlWithValue is LookUpEdit)
                    {
                        //value = (controlWithValue as LookUpEdit).EditValue;
                        var lookUpEditValue = (controlWithValue as LookUpEdit).EditValue as IObject;
                        if (lookUpEditValue != null)
                        {
                            value = lookUpEditValue.Key;
                        }
                    }
                    else if (controlWithValue is DateEdit)
                    {
                        value = (controlWithValue as DateEdit).EditValue;
                    }
                    else
                    {
                        if (control.Controls.ToArray()[1].Text != "Like")
                        {
                            value = controlWithValue.Text; 
                        }
                        else
                        {
                            value = controlWithValue.Text; 
                        }
                    }

                    filterParams.Add(control.MetaItem.Name, condition, value); //  as ListControl));
                   
                }
            }
            foreach (
                   var control in
                       notComboboxLinkedContext.Where(f => f.MetaItem.EditorType == EditorType.Flag))
            {
                //for null values if needed
                var flag = (control.Controls.First() as CheckEdit);
                filterParams.Add(control.MetaItem.Name, "=", flag.Checked?1:0);

            }
            return filterParams;
        }

        public static void DisplayMultipleText(PopupContainerEdit cont)
        {
            var list = cont.Properties.PopupControl.Controls[0] as CheckedListBoxControl;
            string dispVal = "";
            foreach (var i in list.CheckedItems)
            {
                if (Utils.IsEmpty(i.ToString()))
                    continue;
                if (dispVal.Length > 0) dispVal += ", ";
                dispVal += i.ToString();
            }
            cont.EditValue = dispVal;
        }
    }

    public static class FilterParamsExtension
    {
        public static void Add(this FilterParams filterParams, string param, string oper, object inputVal, EditorType editorType = EditorType.Text)
        {
            switch (editorType)
            {
                case EditorType.Numeric:
                    {
                        decimal preValue = 0;
                        decimal.TryParse(inputVal.ToString(), out preValue);
                        inputVal = preValue;
                    }
                    break;
                case EditorType.Date:
                case EditorType.Datetime:
                    {
                        DateTime preValue = new DateTime();
                        if (DateTime.TryParse(inputVal.ToString(), out preValue))
                        {
                            //DateTime.TryParse(inputVal.ToString(), out preValue);
                            inputVal = preValue;
                        }
                        else
                        {
                            inputVal = null;
                        }
                    }
                    break;
                case EditorType.Flag:
                    {
                        bool preValue = false;
                        bool.TryParse(inputVal.ToString(), out preValue);
                        inputVal = preValue;
                    }
                    break;
                default:
                    {
                        inputVal = inputVal.ToString();
                    }
                    break;
            }
           
            filterParams.Add(param, oper, inputVal);
        }

    }
}
