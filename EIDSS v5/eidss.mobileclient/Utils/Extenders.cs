using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using bv.common.Configuration;
using bv.model.Model.Core;
using System.Web;
using System.Collections;
using bv.model.Helpers;

namespace eidss.mobileclient.Utils
{
    public static class Extenders
    {
        /// <summary>  
        /// Determines whether this request was made from a mobile safari device  
        /// </summary>  
        /// <param name="request">The request.</param>  
        /// <returns>  
        /// <c>true</c> if request is from mobile safari; otherwise, <c>false</c>.  
        /// </returns>  
        private static bool IsMobileSafari(HttpRequestBase request)
        {
            if (request == null)
            {
                return false;
            }

            var userAgent = request.UserAgent;
            if (string.IsNullOrEmpty(userAgent))
            {
                return false;
            }

            var ipodIndex = userAgent.IndexOf("iPod");
            var ipadIndex = userAgent.IndexOf("iPad");
            var iphoneIndex = userAgent.IndexOf("iPhone");

            return iphoneIndex + ipodIndex + ipadIndex > -1;
        }

        public static MvcHtmlString BvHiddenPersonalData(this HtmlHelper htmlHelper, IObject obj, string bindToProp)
        {
            Dictionary<string, object> htmlAttributes = GetHtmlAttributes(obj, bindToProp);
            string displayText = "**********";
            MvcHtmlString textBox = htmlHelper.TextBox(bindToProp, displayText, htmlAttributes);
            return textBox;
        }
      

        public static MvcHtmlString BvEditBox(this HtmlHelper htmlHelper, IObject obj, string bindToProp)
        {
            if (obj.IsHiddenPersonalData(bindToProp))
            {
                return htmlHelper.BvHiddenPersonalData(obj, bindToProp);
            }

            Dictionary<string, object> htmlAttributes = GetHtmlAttributes(obj, bindToProp);
            MvcHtmlString textBox = htmlHelper.TextBox(obj.ObjectIdent + bindToProp, obj.GetValue(bindToProp), htmlAttributes);
            return textBox;
        }

        public static MvcHtmlString BvNumeric(this HtmlHelper htmlHelper, IObject obj, string bindToProp, bool refreshOnLostFocus = false)
        {
            if (obj.IsHiddenPersonalData(bindToProp))
            {
                return htmlHelper.BvHiddenPersonalData(obj, bindToProp);
            }

            string stileClass = GetStyleClass(obj, bindToProp);
            string classAttribute = string.IsNullOrEmpty(stileClass) ? "" : string.Format("class='{0}'", stileClass);
            IObjectPermissions permission = obj.GetPermissions();
            bool isReadOnly = permission == null ? false : permission.IsReadOnlyForEdit;
            string disabled = obj.IsReadOnly(bindToProp) || isReadOnly ? "disabled='disabled'" : "";
            string textBoxName = obj.ObjectIdent + bindToProp;
            string onBlur = refreshOnLostFocus ? string.Format("onblur='{0}'", string.Format("ModelFieldChangedNumeric(\"{0}\");", textBoxName)) : "";
            string result = String.Format("<input type='number' id='{0}' name='{0}' value='{1}' {2} {3} {4} />", textBoxName, obj.GetValue(bindToProp), classAttribute, disabled, onBlur);
            return new MvcHtmlString(result);
        }

        public static MvcHtmlString BvSimpleNumeric(this HtmlHelper htmlHelper, string name, int? value, bool isMandatory = false, bool isReadOnly = false)
        {
            string stileClass = isMandatory ? "requiredField" : "";
            string classAttribute = string.IsNullOrEmpty(stileClass) ? "" : string.Format("class='{0}'", stileClass);
            string disabled = isReadOnly ? "disabled='disabled'" : "";
            string result = String.Format("<input type='number' id='{0}' name='{0}' value='{1}' {2} {3} />", name, value, classAttribute, disabled);
            return new MvcHtmlString(result);
        }

        public static MvcHtmlString BvDropDownList(this HtmlHelper htmlHelper, IObject obj, string bindToProp, string clientOnChange = null)
        {
            Dictionary<string, object> htmlAttributes = GetHtmlAttributes(obj, bindToProp);
            htmlAttributes.Add("onChange", !string.IsNullOrEmpty(clientOnChange) ? clientOnChange
                                   : string.Format("new function () {{ ModelFieldChangedCombobox('{0}'); }}", obj.ObjectIdent + bindToProp));
            BvSelectList selectList = obj.GetList(bindToProp);
            MvcHtmlString dropDownList;
            if (selectList != null)
            {
                IEnumerable<SelectListItem> items = GetItemsForBvDropDownList(selectList);
                dropDownList = htmlHelper.DropDownList(obj.ObjectIdent + bindToProp, items, htmlAttributes);
            }
            else
            {
                dropDownList = htmlHelper.DropDownList(obj.ObjectIdent + bindToProp);
            }
            return dropDownList;
        }
        
        private static IEnumerable<SelectListItem> GetItemsForBvDropDownList(BvSelectList selectList)
        {
            List<SelectListItem> items = new SelectList(selectList.items, selectList.dataValueField, selectList.dataTextField, selectList.selectedValue).ToList();
            if (selectList.selectedValue != null)
            {
                SelectListItem item = items.Where(x => x.Value == ((IObject)selectList.selectedValue).Key.ToString()).SingleOrDefault();
                item.Selected = true;
            }
            return items;
        }

        public static MvcHtmlString BvSimpleDropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> items, bool isMandatory = false, 
            string clientOnChange = null, bool isReadOnly = false)
        {
            var htmlAttributes = new Dictionary<string, object>();
            if(isMandatory)
            {
                htmlAttributes.Add("class", "requiredField");
            }
            if(isReadOnly)
            {
                htmlAttributes.Add("class", "readonlyField");
                htmlAttributes.Add("readonly", "readonly");
                htmlAttributes.Add("disabled", "disabled");
            }

            htmlAttributes.Add("onChange", !string.IsNullOrEmpty(clientOnChange) ? clientOnChange
                                   : string.Format("new function () {{ }}"));
            
            MvcHtmlString dropDownList = htmlHelper.DropDownList(name, items, htmlAttributes);
            return dropDownList;
        }

        public static MvcHtmlString BvDateBox(this HtmlHelper htmlHelper, IObject obj, string bindToProp, string onBlurHandler = "")
        {
            bool isMobileSafari = IsMobileSafari(htmlHelper.ViewContext.HttpContext.Request);
            MvcHtmlString dateBox;
            if(isMobileSafari)
            {
                dateBox = MobileSafariDateBox(obj, bindToProp, onBlurHandler);
                return dateBox;
            }
            dateBox = CustomDateBox(htmlHelper, obj, bindToProp, onBlurHandler);
            return dateBox;
        }

        public static MvcHtmlString BvSimpleDateBox(this HtmlHelper htmlHelper, string name, DateTime? value, bool isMandatory = false, bool isReadOnly = false)
        {
            bool isMobileSafari = IsMobileSafari(htmlHelper.ViewContext.HttpContext.Request);
            MvcHtmlString dateBox;
            if (isMobileSafari)
            {
                dateBox = MobileSafariDateBox(name, value, isMandatory, isReadOnly);
                return dateBox;
            }
            dateBox = CustomDateBox(htmlHelper, name, value, isMandatory, isReadOnly);
            return dateBox;
        }

        public static MvcHtmlString BvDateTimeBox(this HtmlHelper htmlHelper, IObject obj, string bindToProp)
        {
            bool isMobileSafari = IsMobileSafari(htmlHelper.ViewContext.HttpContext.Request);
            MvcHtmlString dateTimeBox;
            if (isMobileSafari)
            {
                dateTimeBox = MobileSafariDateTimeBox(htmlHelper, obj, bindToProp);
                return dateTimeBox;
            }
            dateTimeBox = CustomDateTimeBox(htmlHelper, obj, bindToProp);
            return dateTimeBox;
        }

        private static MvcHtmlString MobileSafariDateBox(IObject obj, string bindToProp, string onBlurHandler = "")
        {
            string controlName = obj.ObjectIdent + bindToProp;
            MvcHtmlString result = GetMobileSafariDateBoxHtml(obj, bindToProp, controlName, onBlurHandler);
            return result;
        }

        private static MvcHtmlString MobileSafariDateBox(string name, DateTime? value, bool isMandatory = false, bool isReadOnly = false)
        {
            string classAttribute = isMandatory ? "class='requiredField'" : "";
            string disabled = isReadOnly ? "disabled='disabled'" : "";
            string date = value.HasValue ? value.Value.ToString("yyyy-MM-dd") : null;
            string result = String.Format("<input type='date' id='{0}' name='{0}' value='{1}' {2} {3} />", name, date, classAttribute, disabled);
            return new MvcHtmlString(result);
        }

        private static MvcHtmlString MobileSafariDateTimeBox(this HtmlHelper htmlHelper, IObject obj, string bindToProp)
        {
            string controlId = obj.ObjectIdent + bindToProp;
            string onBlurDateHandler = string.Format("OnDateboxChanged(\"{0}\")", controlId);
            MvcHtmlString dateBoxHtml = GetMobileSafariDateBoxHtml(obj, bindToProp, controlId + "_Date", onBlurDateHandler);
            MvcHtmlString timeBoxHtml = GetMobileSafariTimeBoxHtml(obj, bindToProp, controlId + "_Time");
            var result = new StringBuilder();
            result.Append("<table><tr><td>");
            result.Append(dateBoxHtml);
            result.Append("</td><td>");
            result.Append(timeBoxHtml);
            result.Append("</td></tr></table>");
            return new MvcHtmlString(result.ToString());
        }

        private static MvcHtmlString GetMobileSafariDateBoxHtml(IObject obj, string bindToProp, string controlName, string onBlurHandler = "")
        {
            string stileClass = GetStyleClass(obj, bindToProp);
            string classAttribute = string.IsNullOrEmpty(stileClass) ? "" : string.Format("class='{0}'", stileClass);
            string dateValue = obj.GetValue(bindToProp) == null ? "" : ((DateTime?)obj.GetValue(bindToProp)).Value.Date.ToString("yyyy-MM-dd");
            IObjectPermissions permission = obj.GetPermissions();
            bool isReadOnly = permission == null ? false : permission.IsReadOnlyForEdit;
            string disabled = obj.IsReadOnly(bindToProp) || isReadOnly ? "disabled='disabled'" : "";
            string onBlur = string.IsNullOrEmpty(onBlurHandler) ? "" : string.Format("onblur='{0}'", onBlurHandler);
            string dateBoxHtml = String.Format("<input type='date' id='{0}' name='{0}' value='{1}' {2} {3} {4} />", controlName, dateValue, classAttribute, disabled, onBlur);
            return new MvcHtmlString(dateBoxHtml);
        }

        private static MvcHtmlString GetMobileSafariTimeBoxHtml(IObject obj, string bindToProp, string controlName)
        {
            string stileClass = GetStyleClass(obj, bindToProp);
            string classAttribute = string.IsNullOrEmpty(stileClass) ? "" : string.Format("class='{0}'", stileClass);
            string timeValue = obj.GetValue(bindToProp) == null ? "" : ((DateTime?)obj.GetValue(bindToProp)).Value.ToString("HH:mm:ss");
            IObjectPermissions permission = obj.GetPermissions();
            bool isReadOnly = permission == null ? false : permission.IsReadOnlyForEdit;
            string disabled = obj.IsReadOnly(bindToProp) || isReadOnly || string.IsNullOrEmpty(timeValue) ? "disabled='disabled' readonly='readonly'" : "";
            string timeBoxHtml = String.Format("<input type='time' id='{0}' name='{0}' value='{1}' {2} {3} />", controlName, timeValue, classAttribute, disabled);
            return new MvcHtmlString(timeBoxHtml);
        }


        private static MvcHtmlString CustomDateBox(this HtmlHelper htmlHelper, IObject obj, string bindToProp, string onBlurHandler = "")
        {
            Dictionary<string, object> htmlAttributes = GetHtmlAttributes(obj, bindToProp);
            htmlAttributes.Add("onChange", !string.IsNullOrEmpty(onBlurHandler) ? onBlurHandler : string.Format("new function () {{ bvNothing(); }}"));
            var dateValue = (DateTime?)obj.GetValue(bindToProp);
            MvcHtmlString dateBoxHtml = GetCustomDateBoxHtml(htmlHelper, obj.ObjectIdent + bindToProp, dateValue, htmlAttributes);
            return dateBoxHtml;
        }

        private static MvcHtmlString CustomDateBox(this HtmlHelper htmlHelper, string name, DateTime? value, bool isMandatory = false, bool isReadOnly = false)
        {
            var htmlAttributes = new Dictionary<string, object>();
            if(isMandatory)
            {
                htmlAttributes.Add("class", "requiredField");
            }
            if(isReadOnly)
            {
                htmlAttributes.Add("readonly", "readonly");
                htmlAttributes.Add("disabled", "disabled");
            }

            MvcHtmlString dateBoxHtml = GetCustomDateBoxHtml(htmlHelper, name, value, htmlAttributes);
            return dateBoxHtml;
        }

        private static MvcHtmlString CustomDateTimeBox(this HtmlHelper htmlHelper, IObject obj, string bindToProp)
        {
            Dictionary<string, object> htmlAttributes = GetHtmlAttributes(obj, bindToProp);
            var dateValue = (DateTime?)obj.GetValue(bindToProp);
            MvcHtmlString dateTimeBoxHtml = GetCustomDateTimeBoxHtml(htmlHelper, obj.ObjectIdent + bindToProp, dateValue, htmlAttributes);
            return dateTimeBoxHtml;
        }

        private static MvcHtmlString GetCustomDateTimeBoxHtml(this HtmlHelper htmlHelper, string name, DateTime? dateValue, Dictionary<string, object> htmlAttributes)
        {
            MvcHtmlString dateBoxHtml = GetCustomDateBoxHtml(htmlHelper, name, dateValue, htmlAttributes);
            MvcHtmlString timeBoxHtml = GetCustomTimeBoxHtml(htmlHelper, name, dateValue, htmlAttributes);
            var result = new StringBuilder();
            result.Append("<table><tr><td>");
            result.Append(dateBoxHtml);
            result.Append("</td><tr><td>");
            result.Append(Translator.GetMessageString("titleMobileTimeFormat"));
            result.Append("</td><tr><td>");
            result.Append(timeBoxHtml);
            result.Append("</td></tr></table>");
            return new MvcHtmlString(result.ToString());
        }

        private static MvcHtmlString GetCustomDateBoxHtml(this HtmlHelper htmlHelper, string name, DateTime? dateValue, Dictionary<string, object> htmlAttributes)
        {
            MvcHtmlString daysDropDownList = GetDaysDropDownList(htmlHelper, name, dateValue, htmlAttributes);
            MvcHtmlString monthesDropDownList = GetMonthesDropDownList(htmlHelper, name, dateValue, htmlAttributes);
            MvcHtmlString yearsDropDownList = GetYearsDropDownList(htmlHelper, name, dateValue, htmlAttributes);
            var result = new StringBuilder();
            result.Append("<table><tr><td>");
            result.Append(monthesDropDownList);
            result.Append("</td><td>");
            result.Append(daysDropDownList);
            result.Append("</td><td>");
            result.Append(yearsDropDownList);
            result.Append("</td></tr></table>");
            return new MvcHtmlString(result.ToString());
        }

        private static MvcHtmlString GetCustomTimeBoxHtml(this HtmlHelper htmlHelper, string name, DateTime? dateValue, Dictionary<string, object> htmlAttributes)
        {
            MvcHtmlString hoursDropDownList = GetHoursDropDownList(htmlHelper, name, dateValue, htmlAttributes);
            MvcHtmlString minutesDropDownList = GetMinutesDropDownList(htmlHelper, name, dateValue, htmlAttributes);
            var result = new StringBuilder();
            result.Append("<table><tr><td>");
            result.Append(hoursDropDownList);
            result.Append("</td><td>:</td><td>");
            result.Append(minutesDropDownList);
            result.Append("</td></tr></table>");
            return new MvcHtmlString(result.ToString());
        }

        private static Dictionary<string, object> GetHtmlAttributes(IObject obj, string bindToProp)
        {
            var htmlAttributes = new Dictionary<string, object>();

            IObjectPermissions permission = obj.GetPermissions();
            bool isReadOnly = permission == null ? false : permission.IsReadOnlyForEdit;
            
            if (obj.IsReadOnly(bindToProp) || obj.IsHiddenPersonalData(bindToProp) || isReadOnly)
            {
                htmlAttributes.Add("readonly", "readonly");
                htmlAttributes.Add("disabled", "disabled");
            }

            string stileClass = GetStyleClass(obj, bindToProp);
            if (!string.IsNullOrEmpty(stileClass))
            {
                htmlAttributes.Add("class", stileClass);
            }

            return htmlAttributes;
        }

        private static string GetStyleClass(IObject obj, string bindToProp)
        {
            if (obj.IsHiddenPersonalData(bindToProp) && obj.IsInvisible(bindToProp))
            {
                return "readonlyField invisible";
            }
            if (obj.IsHiddenPersonalData(bindToProp))
            {
                return "readonlyField";
            } 

            IObjectPermissions permission = obj.GetPermissions();
            bool isReadOnly = permission == null ? false : permission.IsReadOnlyForEdit;

            if ((obj.IsReadOnly(bindToProp) || isReadOnly) && obj.IsRequired(bindToProp))
            {
                return "readonlyField requiredField";
            }
            if (obj.IsReadOnly(bindToProp) || isReadOnly)
            {
                return "readonlyField";
            }
            if (obj.IsRequired(bindToProp))
            {
                return "requiredField";
            }
            return string.Empty;
        }

        private static MvcHtmlString GetDaysDropDownList(this HtmlHelper htmlHelper, string namePrefix, DateTime? dateValue, 
            Dictionary<string, object> htmlAttributes)
        {
            string selectedDay = dateValue == null ? "0" : dateValue.Value.Date.Day.ToString();
            var days = new SelectList(GetItemsForCalendar(1, 31), "Value", "Text", selectedDay);
            MvcHtmlString daysDropDownList = htmlHelper.DropDownList(namePrefix + "_Day", days, htmlAttributes);
            return daysDropDownList;
        }

        private static MvcHtmlString GetMonthesDropDownList(this HtmlHelper htmlHelper, string namePrefix, DateTime? dateValue, 
            Dictionary<string, object> htmlAttributes)
        {
            string selectedMonth = dateValue == null ? "0" : dateValue.Value.Date.Month.ToString();
            var monthes = new SelectList(GetItemsForCalendar(1, 12), "Value", "Text", selectedMonth);
            MvcHtmlString monthesDropDownList = htmlHelper.DropDownList(namePrefix + "_Month", monthes, htmlAttributes);
            return monthesDropDownList;
        }

        private static MvcHtmlString GetYearsDropDownList(this HtmlHelper htmlHelper, string namePrefix, DateTime? dateValue, 
            Dictionary<string, object> htmlAttributes)
        {
            string selectedYear = dateValue == null ? "0" : dateValue.Value.Date.Year.ToString();
            var years = new SelectList(GetYearsForCalendar(), "Value", "Text", selectedYear);
            MvcHtmlString yearsDropDownList = htmlHelper.DropDownList(namePrefix + "_Year", years, htmlAttributes);
            return yearsDropDownList;
        }

        private static MvcHtmlString GetHoursDropDownList(this HtmlHelper htmlHelper, string namePrefix, DateTime? dateValue,
            Dictionary<string, object> htmlAttributes)
        {
            string selectedHour = dateValue == null ? null : dateValue.Value.Hour.ToString();
            var hours = new SelectList(GetItemsForTime(0, 23), "Value", "Text", selectedHour);
            MvcHtmlString hoursDropDownList = htmlHelper.DropDownList(namePrefix + "_Hour", hours, htmlAttributes);
            return hoursDropDownList;
        }

        private static MvcHtmlString GetMinutesDropDownList(this HtmlHelper htmlHelper, string namePrefix, DateTime? dateValue,
            Dictionary<string, object> htmlAttributes)
        {
            string selectedMinute = dateValue == null ? null : dateValue.Value.Minute.ToString();
            var minutes = new SelectList(GetItemsForTime(0, 59), "Value", "Text", selectedMinute);
            MvcHtmlString hoursDropDownList = htmlHelper.DropDownList(namePrefix + "_Minute", minutes, htmlAttributes);
            return hoursDropDownList;
        }

        private static List<SelectListItem> GetItemsForCalendar(int startIndex, int stopIndex)
        {
            var items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "", Value = "0", Selected = true });
            for (int i = startIndex; i <= stopIndex; i++)
            {
                items.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }
            return items;
        }

        private static List<SelectListItem> GetYearsForCalendar()
        {
            var items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "", Value = "0", Selected = true });
            for (int i = DateTime.Now.Year; i >= 1900; i--)
            {
                items.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }
            return items;
        }

        private static List<SelectListItem> GetItemsForTime(int startIndex, int stopIndex)
        {
            var items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "", Value = null, Selected = true });
            for (int i = startIndex; i <= stopIndex; i++)
            {
                string valueText = i < 10 ? string.Format("0{0}", i) : i.ToString();
                items.Add(new SelectListItem { Text = valueText, Value = i.ToString() });
            }
            return items;
        }
    }
}
