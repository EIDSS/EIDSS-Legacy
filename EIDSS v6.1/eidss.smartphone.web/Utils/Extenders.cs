using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using Kendo.Mvc.UI;
using Kendo.Mvc.UI.Fluent;
using bv.common.Configuration;
using bv.common.Resources;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using System.Web;
using System.Collections;
using bv.model.Helpers;
using eidss.model.Schema;
using eidss.web.common.Utils;
using bv.common.Enums;
using eidss.model.Core;

//using Kendo.Mvc.UI;

namespace eidss.smartphone.web.Utils
{
    public static partial class Extenders
    {
        #region IEnumerable extenders

        /// <summary>
        /// Method from forum
        /// http://social.msdn.microsoft.com/forums/en-US/adodotnetentityframework/thread/f7cb280d-17c4-4cb3-8b8c-82bf46ea4c56
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="propertyName"></param>
        /// <param name="ascending"></param>
        /// <returns></returns>
        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> query, string propertyName, bool ascending)
        {
            ParameterExpression prm = Expression.Parameter(typeof(T), "it");
            Expression property = Expression.Property(prm, propertyName);
            Type propertyType = property.Type;
            MethodInfo method = typeof(Extenders).GetMethod("OrderByProperty", BindingFlags.Static | BindingFlags.NonPublic)
                .MakeGenericMethod(typeof(T), propertyType);

            return (IEnumerable<T>)method.Invoke(null, new object[] { query, prm, property, ascending });
        }

        private static IEnumerable<T> OrderByProperty<T, P>(this IEnumerable<T> query, ParameterExpression prm, Expression property, bool ascending)
        {
            Func<IEnumerable<T>, Func<T, P>, IEnumerable<T>> orderBy = (q, p) => ascending ? q.OrderBy(p) : q.OrderByDescending(p);
            return orderBy(query, Expression.Lambda<Func<T, P>>(property, prm).Compile());
        }

        #endregion


        public static string VersionCode()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            string versionCode = string.Format("{0}-{1}-{2}-{3}", version.Major, version.Minor, version.Build, version.Revision);
            return versionCode;
        }

        #region Controller extenders

        public static string RenderPartialView(this Controller controller, string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
            {
                viewName = controller.ControllerContext.RouteData.GetRequiredString("action");
            }

            controller.ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
                var viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }

        #endregion


        private static string BindToProp(Expression expr)
        {
            return expr is MemberExpression
                       ? ((MemberExpression) expr).Member.Name
                       : expr is UnaryExpression
                             ? BindToProp((expr as UnaryExpression).Operand)
                             : "";
        }

        private static string BindToProp<O>(Expression<Func<O, object>> expr)
            where O : IObject
        {
            return BindToProp(expr.Body);
        }

        #region BV UI elements

        public static ComboBoxBuilder BvComboboxWithList<O>
            (this HtmlHelper htmlHelper,
             O obj, Expression<Func<O, object>> expr, BvSelectList items, string keyName = null, string valueName = null)
            where O : IObject
        {
            return BvCombobox(htmlHelper, obj, expr, true, null, null, null, false, items, keyName, valueName);
        }

        public static ComboBoxBuilder BvCombobox<O>(this HtmlHelper htmlHelper, 
            O obj, Expression<Func<O, object>> expr, bool bBind = true, string clientOnChange = null, 
            string styleClass = null, string strRight = null, bool readOnly = false, BvSelectList items = null,
            string keyName = null, string valueName = null, EditorControlWidth width = EditorControlWidth.Normal,
            string textName = null, CachedLookup cacheKey = CachedLookup.None)
            where O : IObject
        {
            var bindToProp = BindToProp(expr);
            var cls = String.Empty; // default style - width:100%
            var stl = String.Empty;
            if (!string.IsNullOrEmpty(styleClass))
            {
                cls = styleClass;
            }
            if (obj.IsRequired(bindToProp))
            {
                cls += " requiredField";
            }
            if (obj.IsInvisible(bindToProp))
            {
                cls += " invisible";
                stl = "display: none;";
            }
            var bIsAutoTestingVersion = Config.GetBoolSetting("AutoTestingVersion");
            var htmlAttributes = bIsAutoTestingVersion
                ? (object) new { @class = cls, style = stl, bvid = obj.ObjectName + "." + bindToProp }
                : new { @class = cls, style = stl };
            //if (obj.IsHiddenPersonalData(bindToProp))
            //{                
            //    return new MvcHtmlString(
            //        String.Format("<div class='tdContainer'>{0}</div>", 
            //        htmlHelper.TextBox(bindToProp, "***********", 
            //        new Dictionary<string,object> { {"class", cls +"readonlyField"} })));

            //}

            var selectlist = items ?? obj.GetList(bindToProp);
            var index = selectlist == null ? -1 : selectlist.items.IndexOf(selectlist.selectedValue);
            if (index < 0 && selectlist != null && selectlist.items != null && selectlist.selectedValue != null)
            {
                var str = selectlist.selectedValue.ToString();
                if (!string.IsNullOrEmpty(str))
                {
                    for (var i = 0; i < selectlist.items.Count; i++)
                    {
                        if (selectlist.items[i].ToString() == str)
                        {
                            index = i;
                            break;
                        }
                    }
                }
            }

            var bEnable = !(obj.IsReadOnly(bindToProp) || readOnly);
            var permission = obj.GetPermissions();
            if (permission != null)
            {
                bEnable = bEnable && !permission.IsReadOnlyForEdit;
            }
            if (strRight != null)
            {
                bEnable = bEnable && ModelUserContext.Instance.CanDo(strRight);
            }
            
            var ret = htmlHelper.Kendo().ComboBox()
                .Name(obj.ObjectIdent + bindToProp)
                .SelectedIndex(index)
                .Enable(bEnable)
                .Filter("startswith")
                .HtmlAttributes(htmlAttributes);
            if (bBind && selectlist != null)
            {
                ret =
                    ret.BindTo(new SelectList(selectlist.items
                                            , selectlist.dataValueField
                                            , valueName ?? selectlist.dataTextField
                                            , selectlist.selectedValue));
            }
            if (bBind)
            {
                ret.Events(events => 
                {
                    events
                        .Change("bvComboBox.onTextChanged")
                        .Select(clientOnChange ?? "bvComboBox.onChanged")
                        .Open("function(e) { bvComboBox.onOpen(e, " + (int)width + "); }");
                    if (bIsAutoTestingVersion)
                        events.DataBound("bvComboBox.onDataBound");
                });
            }
            else
            {
                ret = ret
                    .DataSource(source =>
                        source.Read(read =>
                            {
                                if (cacheKey == CachedLookup.None)
                                    read.Action("SelectGeneric", "System", new { id = (long) obj.Key, lookup = bindToProp, keyname = keyName, textname = textName });
                                else
                                    read.Action(cacheKey.ToString(), "SystemCached");
                            })
                            .ServerFiltering(false))
                    .DataValueField("id")
                    .DataTextField("name")
                    .Events(events =>
                    {
                        events
                            .Change(clientOnChange ?? "bvComboBox.onChanged")
                            .Open("function(e) { bvComboBox.onOpen(e, " + (int)width + "); }");
                        if (bIsAutoTestingVersion)
                            events.DataBound("bvComboBox.onDataBound");
                    });
            }
            return ret;
        }

        public static Kendo.Mvc.UI.Fluent.ComboBoxBuilder BvDummyCombobox(this HtmlHelper htmlHelper)
        {
            string style = "width:0px;";
            var htmlAttributes = new { style };
            var ret = htmlHelper.Kendo().ComboBox()
                .Name("dummy_combo")
                .Enable(false)
                .HtmlAttributes(htmlAttributes);
            return ret;
        }


        public static DropDownListBuilder BvComboboxWithCheckboxes<O>(this HtmlHelper htmlHelper,
            O obj, Expression<Func<O, object>> expr, string keyName, string textName, string selected,
            /*bool bBind = true, string clientOnChange = null, */
            string styleClass = null, string strRight = null, bool readOnly = false, BvSelectList items = null,
            string controller = null, string action = null, EditorControlWidth width = EditorControlWidth.Normal
            )
            where O : IObject
        {
            var bindToProp = BindToProp(expr);
            var cls = String.Empty; // default style - width:100%
            if (!string.IsNullOrEmpty(styleClass))
            {
                cls = styleClass;
            }
            if (obj.IsRequired(bindToProp))
            {
                cls += " requiredField";
            }
            if (obj.IsInvisible(bindToProp))
            {
                cls += " invisible";
            }
            var bIsAutoTestingVersion = Config.GetBoolSetting("AutoTestingVersion");
            var htmlAttributes = bIsAutoTestingVersion
                ? (object)new { @class = cls, bvid = obj.ObjectName + "." + bindToProp }
                : new { @class = cls };

            var selectlist = items ?? obj.GetList(bindToProp);

            var bEnable = !(obj.IsReadOnly(bindToProp) || readOnly);
            var permission = obj.GetPermissions();
            if (permission != null)
            {
                bEnable = bEnable && !permission.IsReadOnlyForEdit;
            }
            if (strRight != null)
            {
                bEnable = bEnable && ModelUserContext.Instance.CanDo(strRight);
            }


            var ret = htmlHelper.Kendo().DropDownList()
                .Name(obj.ObjectIdent + bindToProp)
                .DataTextField("Text")
                .DataValueField("Value")
                .Template("<input type=\"checkbox\"checkedname=\"${ data.Text }\" value=\"${ data.Value }\" class=\"check-item\" id=\"chb${ data.Value }\"/><span>${ data.Text }</span>")
                .Events(e => e.Select("bvCheckedComboBox.onCheckedComboBoxChanged")
                              .DataBound("function(e) { bvCheckedComboBox.bindCheckedComboBoxClickEvent('" + obj.ObjectIdent + bindToProp + "', '" + selected + "');}")
                              .Open("function(e) { bvComboBox.onOpen(e, " + (int)width + "); }"))
                .Enable(bEnable)
                .HtmlAttributes(htmlAttributes);

            if (controller != null && action != null)
            {
                ret = ret.DataSource(source => source.Read(read => read.Action(action, controller, new { id = (long)obj.Key, keyname = keyName, valuename = textName })));
            }
            else
            {
                ret = ret.BindTo(new SelectList(selectlist.items, keyName, textName, null));
            }

            return ret;
        }



        /*
        public static Kendo.Mvc.UI.Fluent.DropDownListBuilder BvDropdownList(this HtmlHelper htmlHelper, IObject obj, string bindToProp, bool bBind = true, string clientOnChange = null, string styleClass = null)
        {
            string cls = "fillAll"; // default style - width:100%
            if (!string.IsNullOrEmpty(styleClass))
            {
                cls = styleClass;
            }
            if (obj.IsRequired(bindToProp))
            {
                cls += " requiredField";
            }
            var bIsAutoTestingVersion = Config.GetBoolSetting("AutoTestingVersion");
            var htmlAttributes = bIsAutoTestingVersion
                ? (object)new { @class = cls, bvid = obj.ObjectName + "." + bindToProp }
                : new { @class = cls };
            BvSelectList selectlist = obj.GetList(bindToProp);

            bool bEnable = !obj.IsReadOnly(bindToProp);
            IObjectPermissions permission = obj.GetPermissions();
            if (permission != null)
                bEnable = bEnable && !permission.IsReadOnlyForEdit;

            var ret = htmlHelper.Kendo().DropDownList()
                .Name(obj.ObjectIdent + bindToProp)
                .SelectedIndex(selectlist.items.IndexOf(selectlist.selectedValue) < 0 ? 0 : selectlist.items.IndexOf(selectlist.selectedValue))
                .Enable(bEnable)
                .Events(events => events.Change(clientOnChange ?? "bvComboBox.applyChanges"))
                .HtmlAttributes(htmlAttributes);
            if (bBind)
                ret = ret.BindTo(new SelectList(selectlist.items, selectlist.dataValueField, selectlist.dataTextField, selectlist.selectedValue));
            return ret;
        }
        */

        public static Kendo.Mvc.UI.Fluent.DatePickerBuilder BvDatebox<O>(this HtmlHelper htmlHelper, O obj, Expression<Func<O, object>> expr, string clientOnChange = null, bool limitMonth = false)
            where O : IObject
        {
            var bindToProp = BindToProp(expr);
            string cls = "";

            if (obj.IsInvisible(bindToProp) && obj.IsRequired(bindToProp))
            {
                cls = "requiredField invisible";
            }
            else if (obj.IsRequired(bindToProp))
            {
                cls = "requiredField";
            }
            else if (obj.IsInvisible(bindToProp))
            {
                cls = "invisible";
            }

            var bIsAutoTestingVersion = Config.GetBoolSetting("AutoTestingVersion");
            var htmlAttributes = bIsAutoTestingVersion
                ? (object)new { @class = cls, bvid = obj.ObjectName + "." + bindToProp }
                : new { @class = cls };

            bool bEnable = !obj.IsReadOnly(bindToProp);
            IObjectPermissions permission = obj.GetPermissions();
            if (permission != null)
                bEnable = bEnable && !permission.IsReadOnlyForEdit;


            var val = obj.GetValue(bindToProp) as DateTime?;
            limitMonth &= (val != null);
            DateTime MaxMonth = DateTime.MaxValue;
            DateTime MinMonth = DateTime.MinValue;
            if(limitMonth){
                MinMonth = val.Value.AddDays(-val.Value.Day+1);
                MaxMonth = MinMonth.AddMonths(1).AddMinutes(-1);
                if(MaxMonth > DateTime.Today.AddDays(1).AddMinutes(-1))
                    MaxMonth = DateTime.Today.AddDays(1).AddMinutes(-1);
            }

            //string format = Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortDatePattern;

            var ret = htmlHelper.Kendo().DatePicker()
                .Name(obj.ObjectIdent + bindToProp)
                .Value(val)
                .Events(events => events.Change(clientOnChange ?? "formRefresher.onDateChanged"))
                //.Format(format)
                .HtmlAttributes(htmlAttributes)
                .Enable(bEnable)
                .Max(MaxMonth)
                .Min(MinMonth);

            return ret;
        }

        /*
        public static Kendo.Mvc.UI.Fluent.DateTimePickerBuilder BvDatetimebox<O>(this HtmlHelper htmlHelper, O obj, Expression<Func<O, object>> expr, string clientOnChange = null)
            where O : IObject
        {
            var bindToProp = BindToProp(expr);
            string cls = "";
            if (obj.IsRequired(bindToProp))
            {
                cls = "requiredField";
            }
            var bIsAutoTestingVersion = Config.GetBoolSetting("AutoTestingVersion");
            var htmlAttributes = bIsAutoTestingVersion
                ? (object)new { @class = cls, bvid = obj.ObjectName + "." + bindToProp }
                : new { @class = cls };

            bool bEnable = !obj.IsReadOnly(bindToProp);
            IObjectPermissions permission = obj.GetPermissions();
            if (permission != null)
                bEnable = bEnable && !permission.IsReadOnlyForEdit;

            var ret = htmlHelper.Kendo().DateTimePicker()
                .Name(obj.ObjectIdent + bindToProp)
                .Value(obj.GetValue(bindToProp) as DateTime?)
                .Events(events => events.Change(clientOnChange ?? "formRefresher.onDateTimeChanged"))
                .HtmlAttributes(htmlAttributes)
                .Enable(bEnable)
                .Max(DateTime.Now.AddHours(1));
            return ret;
        }
        */
        public static Kendo.Mvc.UI.Fluent.DateTimePickerBuilder BvDummyDatetimebox(this HtmlHelper htmlHelper)
        {
            string style = "width:0px;";
            var htmlAttributes = new { style };
            var ret = htmlHelper.Kendo().DateTimePicker()
                .Name("dummy_datetime")
                .Enable(false)
                .HtmlAttributes(htmlAttributes);
            return ret;
        }

        public static MvcHtmlString BvHidden<O>(this HtmlHelper htmlHelper, O obj, string bindToProp)
            where O : IObject
        {
            return htmlHelper.Hidden(obj.ObjectIdent + bindToProp, obj.GetValue(bindToProp));
        }
        public static MvcHtmlString BvHidden<O>(this HtmlHelper htmlHelper, O obj, Expression<Func<O, object>> expr)
            where O : IObject
        {
            var bindToProp = BindToProp(expr);
            return htmlHelper.Hidden(obj.ObjectIdent + bindToProp, obj.GetValue(bindToProp));
        }
        public static MvcHtmlString BvLabel<O>(this HtmlHelper htmlHelper, O obj, Expression<Func<O, object>> expr)
            where O : IObject
        {
            var labelFor = BindToProp(expr);
            var label = new TagBuilder("label");
            label.Attributes["for"] = TagBuilder.CreateSanitizedId(labelFor);
            var labelText = obj.GetType().GetProperty(labelFor).GetCustomAttributes(typeof(LocalizedDisplayNameAttribute), true).SingleOrDefault(c => true, c => (c as LocalizedDisplayNameAttribute).DisplayName);
            string text = labelText ?? Translator.GetString(labelFor);
            label.InnerHtml = HttpUtility.HtmlEncode(text);
            if (obj.IsInvisible(labelFor))
            {
                label.AddCssClass("invisible");
            }
            return MvcHtmlString.Create(label.ToString());
        }

        public static MvcHtmlString BvHiddenPersonalData<O>(this HtmlHelper htmlHelper, O obj, Expression<Func<O, object>> expr, string format = "**********", bool isInvisible = false)
            where O : IObject
        {
            var bindToProp = BindToProp(expr);
            return BvHiddenPersonalData(htmlHelper, obj, bindToProp, format, isInvisible);
        }
        public static MvcHtmlString BvHiddenPersonalData<O>(this HtmlHelper htmlHelper, O obj, string bindToProp, string format = "**********", bool isInvisible = false)
            where O : IObject
        {
            var htmlAttributes = new Dictionary<string, object>();
            htmlAttributes.Add("class", "readonlyField");
            if (isInvisible)
            {
                htmlAttributes["class"] = "readonlyField invisible";
            }
            return new MvcHtmlString(String.Format("<div class='tdContainer'>{0}</div>", htmlHelper.TextBox(bindToProp, format, htmlAttributes)));
        }

        public static MvcHtmlString BvEditbox<O>(this HtmlHelper htmlHelper, O obj, Expression<Func<O, object>> expr, bool refreshOnLostFocus = false, string width = null, string strRight = null,
            string clientScript = null)
            where O : IObject
        {
            var bindToProp = BindToProp(expr);
            return BvEditbox(htmlHelper, obj, bindToProp, refreshOnLostFocus, width, strRight, clientScript);
        }
        public static MvcHtmlString BvEditbox<O>(this HtmlHelper htmlHelper, O obj, string bindToProp, bool refreshOnLostFocus = false, string width = null, string strRight = null,
            string clientScript = null)
            where O : IObject
        {
            if (obj.IsHiddenPersonalData(bindToProp))
            {
                return htmlHelper.BvHiddenPersonalData(obj, bindToProp, isInvisible: obj.IsInvisible(bindToProp));
            }

            var htmlAttributes = new Dictionary<string, object>();
            var bIsAutoTestingVersion = Config.GetBoolSetting("AutoTestingVersion");
            if (bIsAutoTestingVersion)
                htmlAttributes.Add("bvid", obj.ObjectName + "." + bindToProp);

            bool bEnable = !obj.IsReadOnly(bindToProp);
            IObjectPermissions permission = obj.GetPermissions();
            if (permission != null)
            {
                bEnable = bEnable && !permission.IsReadOnlyForEdit;
            }
            if (strRight != null)
            {
                bEnable = bEnable && ModelUserContext.Instance.CanDo(strRight);
            }

            if (!bEnable)
            {
                htmlAttributes.Add("readonly", "readonly");
            }
            if (!string.IsNullOrEmpty(width))
            {
                htmlAttributes.Add("style", String.Format("width:{0}", width));
            }
            var classes = new StringBuilder();
            if (!bEnable)
            {
                classes.Append("readonlyField ");
            }
            if (obj.IsRequired(bindToProp))
            {
                classes.Append("requiredField ");
            }
            if (obj.IsInvisible(bindToProp))
            {
                classes.Append("invisible ");
            }
            if (classes.Length > 0)
            {
                htmlAttributes.Add("class", classes.ToString().Trim());
            }
            int? maxSize = ((IObjectMeta)obj.GetAccessor()).MaxSize(bindToProp);
            if (maxSize.HasValue)
            {
                htmlAttributes.Add("maxlength", maxSize);
            }
            if (refreshOnLostFocus)
            {
                string textBoxName = obj.ObjectIdent + bindToProp;
                htmlAttributes.Add("onblur", string.Format("{0}('{1}');", clientScript ?? "formRefresher.onTextBoxChanged", textBoxName));
            }
            MvcHtmlString textBox = htmlHelper.TextBox(obj.ObjectIdent + bindToProp, obj.GetValue(bindToProp), htmlAttributes);
            string result = String.Format("<span class='tdContainer'>{0}</span>", textBox); // fix for IE (100% 'input' width)
            return new MvcHtmlString(result);
        }
        public static MvcHtmlString BvReadOnlyEditbox<O>(this HtmlHelper htmlHelper, O obj, Expression<Func<O, object>> expr)
            where O : IObject
        {
            var bindToProp = BindToProp(expr);
            var htmlAttributes = new Dictionary<string, object>();
            var bIsAutoTestingVersion = Config.GetBoolSetting("AutoTestingVersion");
            if (bIsAutoTestingVersion)
                htmlAttributes.Add("bvid", obj.ObjectName + "." + bindToProp);
            htmlAttributes.Add("readonly", "readonly");
            htmlAttributes.Add("class", "readonlyField");
            MvcHtmlString textBox = htmlHelper.TextBox(obj.ObjectIdent + bindToProp, obj.GetValue(bindToProp), htmlAttributes);
            string result = String.Format("<div class='tdContainer'>{0}</div>", textBox); // fix for IE (100% 'input' width)
            return new MvcHtmlString(result);
        }

        public static MvcHtmlString BvTextArea<O>(this HtmlHelper htmlHelper, O obj, Expression<Func<O, object>> expr, bool refreshOnLostFocus = false)
            where O : IObject
        {
            var bindToProp = BindToProp(expr);
            if (obj.IsHiddenPersonalData(bindToProp))
            {
                return htmlHelper.BvHiddenPersonalData(obj, expr);
            }

            var htmlAttributes = new Dictionary<string, object>();
            var bIsAutoTestingVersion = Config.GetBoolSetting("AutoTestingVersion");
            if (bIsAutoTestingVersion)
                htmlAttributes.Add("bvid", obj.ObjectName + "." + bindToProp);

            bool bEnable = !obj.IsReadOnly(bindToProp);
            IObjectPermissions permission = obj.GetPermissions();
            if (permission != null)
                bEnable = bEnable && !permission.IsReadOnlyForEdit;

            if (!bEnable)
            {
                htmlAttributes.Add("readonly", "readonly");
            }
            if (obj.IsInvisible(bindToProp) && !bEnable)
            {
                htmlAttributes.Add("class", "invisible readonlyField");
            }
            else if (obj.IsInvisible(bindToProp))
            {
                htmlAttributes.Add("class", "invisible");
            }
            else if (!bEnable)
            {
                htmlAttributes.Add("class", "readonlyField");
            }
            string textBoxName = obj.ObjectIdent + bindToProp;
            int? maxSize = ((IObjectMeta)obj.GetAccessor()).MaxSize(bindToProp);
            if (maxSize.HasValue)
            {
                htmlAttributes.Add("maxlength", maxSize);
                htmlAttributes.Add("onkeyup", string.Format("LimitTextArea('{0}');", textBoxName));
            }
            if (refreshOnLostFocus)
            {
                htmlAttributes.Add("onblur", string.Format("formRefresher.onTextBoxChanged('{0}');", textBoxName));
            }
            var valobj = obj.GetValue(bindToProp);
            var val = valobj == null ? "" : valobj.ToString();
            MvcHtmlString textBox = htmlHelper.TextArea(obj.ObjectIdent + bindToProp, val, htmlAttributes);
            string result = String.Format("<div class='tdContainer'>{0}</div>", textBox); // fix for IE (100% 'input' width)
            return new MvcHtmlString(result);
        }

        public static MvcHtmlString BvNumeric<O>(this HtmlHelper htmlHelper, O obj, Expression<Func<O, object>> expr, int decimalDigits = 2, double minValue = 0, double maxValue = (double)Int32.MaxValue, bool refreshOnLostFocus = false, string clientOnChange = null)
            where O : IObject
        {
            var bindToProp = BindToProp(expr);
            if (obj.IsHiddenPersonalData(bindToProp))
            {
                return htmlHelper.BvHiddenPersonalData(obj, expr, decimalDigits == 0 ? "****" : "***.**");
            }
            string cls = "";
            var htmlAttributes = new Dictionary<string, object>();
            var bIsAutoTestingVersion = Config.GetBoolSetting("AutoTestingVersion");
            if (bIsAutoTestingVersion)
                htmlAttributes.Add("bvid", obj.ObjectName + "." + bindToProp);
            if (obj.IsRequired(bindToProp))
            {
                cls += "requiredField ";
            }
            if (obj.IsInvisible(bindToProp))
            {
                cls += "invisible ";
            }
            htmlAttributes.Add("class", cls);
            double? value = obj.GetValue(bindToProp) as double?;
            if (obj.GetValue(bindToProp) != null && decimalDigits == 0 && value == null)
                value = Convert.ToDouble((int)obj.GetValue(bindToProp));

            bool bEnable = !obj.IsReadOnly(bindToProp);
            IObjectPermissions permission = obj.GetPermissions();
            if (permission != null)
                bEnable = bEnable && !permission.IsReadOnlyForEdit;

            string format = decimalDigits <= 0 ? "#" : "#.";
            for (int i = 0; i < decimalDigits; i++) format = format + "#";
            var ret = htmlHelper.Kendo()
                .NumericTextBox().Name(obj.ObjectIdent + bindToProp)
                .Format(format)
                .Value(value)
                .Enable(bEnable)
                .Decimals(decimalDigits)
                .Min(minValue)
                .Max(maxValue)
                .Placeholder("")
                .HtmlAttributes(htmlAttributes);

            if (refreshOnLostFocus)
            {
                ret = ret
                    .Events(events => events.Change(clientOnChange ?? "formRefresher.onNumericChanged"));
            }
            return new MvcHtmlString(ret.ToHtmlString());
        }
        
        public static MvcHtmlString BvRadioButtonGroup<O>(this HtmlHelper htmlHelper, O obj, Expression<Func<O, object>> expr, bool verticalLayout = true)
            where O : IObject
        {
            var bindToProp = BindToProp(expr);
            BvSelectList selectlist = obj.GetList(bindToProp);
            if (selectlist == null)
                return new MvcHtmlString("");

            bool bEnable = !obj.IsReadOnly(bindToProp);
            IObjectPermissions permission = obj.GetPermissions();
            if (permission != null)
                bEnable = bEnable && !permission.IsReadOnlyForEdit;

            StringBuilder result = new StringBuilder();
            //the result is a list with radiobuttons
            result.Append(verticalLayout ? "<ul class='verticalRadioList'>" : "<ul class='horizontalRadioList'>");

            var bIsAutoTestingVersion = Config.GetBoolSetting("AutoTestingVersion");

            var currentValue = string.Empty;
            if (selectlist.selectedValue != null)
                currentValue = selectlist.selectedValue.ToString();
            foreach (var item in selectlist.items)
            {
                // Generate an id to be given to the radio button field 
                string value = item.GetType().GetProperty(selectlist.dataValueField).GetValue(item, null).ToString();
                if (value == "0")
                {
                    continue;
                }

                string text = item.GetType().GetProperty(selectlist.dataTextField ?? "name").GetValue(item, null).ToString();
                var id = string.Format("{0}{1}_{2}", obj.ObjectIdent, bindToProp, value);

                //// Create and populate a radio button using the existing html helpers 
                var label = htmlHelper.Label(id, HttpUtility.HtmlDecode(text));
                string radio = "";
                if (bIsAutoTestingVersion)
                    radio = String.Format("<input type='radio' id='{0}' name='{1}{2}' value='{3}' {4} {5} bvid='{6}.{2}'/>",
                            id,
                            obj.ObjectIdent,
                            bindToProp,
                            value,
                            text.Equals(currentValue) ? "checked='checked'" : "",
                            !bEnable ? "disabled='disabled'" : "",
                            obj.ObjectName
                            );
                else
                    radio = String.Format("<input type='radio' id='{0}' name='{1}{2}' value='{3}' {4} {5}/>",
                            id,
                            obj.ObjectIdent,
                            bindToProp,
                            value,
                            text.Equals(currentValue) ? "checked='checked'" : "",
                            !bEnable ? "disabled='disabled'" : ""
                            );

                result.AppendFormat("<li>{0}{1}</li>\r\n", radio, label);
            }
            result.Append("</ul>");
            return new MvcHtmlString(result.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="text"></param>
        /// <param name="imageUrl"></param>
        /// <returns></returns>
        public static MvcHtmlString BvButton(this HtmlHelper htmlHelper, string text, string imageUrl)
        {
            //TODO переделать на телериковские компоненты

            var sb = new StringBuilder();
            sb.AppendFormat("<img src=\"{0}\"/>", new[] { imageUrl });
            sb.AppendFormat("<input align=\"right\" type=\"button\" value=\"{0}\"/>", new[] { text });

            return new MvcHtmlString(sb.ToString());
        }
        /*
        public static MvcHtmlString BvCheckBox<O>(this HtmlHelper htmlHelper, O obj, Expression<Func<O, object>> expr)
            where O : IObject
        {
            var bindToProp = BindToProp(expr);
            var result = new StringBuilder();

            bool value = obj.GetValue(bindToProp) == null ? false : (bool)obj.GetValue(bindToProp);
            var id = string.Format("{0}{1}", obj.ObjectIdent, bindToProp);

            bool bEnable = !obj.IsReadOnly(bindToProp);
            IObjectPermissions permission = obj.GetPermissions();
            if (permission != null)
                bEnable = bEnable && !permission.IsReadOnlyForEdit;

            //// Create and populate a checkbox using the existing html helpers 
            var label = htmlHelper.Label(bindToProp);
            var bIsAutoTestingVersion = Config.GetBoolSetting("AutoTestingVersion");
            string radio = "";
            if (bIsAutoTestingVersion)
                radio = String.Format("<input type='checkbox' id='{0}' name='{1}' value='{2}' {3} {4} onclick='this.value=this.checked;' bvid='{5}.{6}'/>",
                                      id,
                                      id,
                                      value,
                                      value ? "checked='checked'" : "",
                                      !bEnable ? "disabled='disabled'" : "",
                                      obj.ObjectName,
                                      bindToProp
                                      );
            else
                radio = String.Format("<input type='checkbox' id='{0}' name='{1}' value='{2}' {3} {4} onclick='this.value=this.checked;'/>",
                                      id,
                                      id,
                                      value,
                                      value ? "checked='checked'" : "",
                                      !bEnable ? "disabled='disabled'" : ""
                                      );
            result.AppendFormat("<li>{0}{1}</li>\r\n", radio, label);
            return new MvcHtmlString(result.ToString());
        }
        */
        public static MvcHtmlString BvCheckBox<O>(this HtmlHelper htmlHelper, O obj, Expression<Func<O, object>> expr, bool bSendToServer, string strEventOnClick = null, string strRight = null)
            where O : IObject
        {
            var bindToProp = BindToProp(expr);
            var result = new StringBuilder();

            bool value = obj.GetValue(bindToProp) == null ? false : ParsingHelper.ParseBoolean(obj.GetValue(bindToProp).ToString());
            string checkBoxName = obj.ObjectIdent + bindToProp;

            bool bEnable = !obj.IsReadOnly(bindToProp);
            IObjectPermissions permission = obj.GetPermissions();
            if (permission != null)
            {
                bEnable = bEnable && !permission.IsReadOnlyForEdit;
            }
            if (strRight != null)
            {
                bEnable = bEnable && ModelUserContext.Instance.CanDo(strRight);
            }

            var bIsAutoTestingVersion = Config.GetBoolSetting("AutoTestingVersion");
            string radio = "";

            //// Create and populate a checkbox using the existing html helpers 
            var label = htmlHelper.Label(bindToProp);
            if (bIsAutoTestingVersion)
                radio = String.Format("<input type='checkbox' id='{0}' name='{1}' value='{2}' {3} {4} {5} bvid='{6}.{7}'/>",
                                      checkBoxName,
                                      checkBoxName,
                                      value,
                                      value ? "checked='checked'" : "",
                                      bSendToServer ? "onclick='formRefresher.onCheckBoxChanged(\"" + checkBoxName + "\")'" :
                                        strEventOnClick == null ? "" : "onclick='" + strEventOnClick + "(\"" + checkBoxName + "\")'",
                                      !bEnable ? "disabled='disabled'" : "",
                                      obj.ObjectName,
                                      bindToProp
                                      );
            else
                radio = String.Format("<input type='checkbox' id='{0}' name='{1}' value='{2}' {3} {4} {5}/>",
                                      checkBoxName,
                                      checkBoxName,
                                      value,
                                      value ? "checked='checked'" : "",
                                      bSendToServer ? "onclick='formRefresher.onCheckBoxChanged(\"" + checkBoxName + "\")'" :
                                        strEventOnClick == null ? "" : "onclick='" + strEventOnClick + "(\"" + checkBoxName + "\")'",
                                      !bEnable ? "disabled='disabled'" : ""
                                      );
            result.AppendFormat("{0}{1}", radio, label);
            return new MvcHtmlString(result.ToString());
        }
        #endregion

        #region Address extenders

        public static MvcHtmlString Address(this HtmlHelper htmlHelper, long root, eidss.model.Schema.Address address, bool isCountryFieldVisible = false,
            bool isForeignAddressFieldVisible = false, bool needFillRegionOnCountryChanged = false, bool isCoordinatesFieldsVisible = false)
        {
            var args = new RouteValueDictionary { { "root", root }, { "address", address }, { "isCountryFieldVisible", isCountryFieldVisible }, 
                { "isForeignAddressFieldVisible", isForeignAddressFieldVisible }, { "needFillRegionOnCountryChanged", needFillRegionOnCountryChanged },
                {"isCoordinatesFieldsVisible", isCoordinatesFieldsVisible}};
            return htmlHelper.Action("Address", "Address", args);
        }

        public static MvcHtmlString ReadOnlyAddress(this HtmlHelper htmlHelper, long root, eidss.model.Schema.Address address)
        {
            var args = new RouteValueDictionary { { "root", root }, { "address", address } };
            return htmlHelper.Action("ReadOnlyAddress", "Address", args);
        }

       /* public static MvcHtmlString InlineAddressPicker(this HtmlHelper htmlHelper, long root, eidss.model.Schema.Address address)
        {
            var args = new RouteValueDictionary { { "root", root }, { "address", address } };
            return htmlHelper.Action("InlineAddressPicker", "Address", args);
        }*/

        public static MvcHtmlString AddressInTwoColumns(this HtmlHelper htmlHelper, long root, eidss.model.Schema.Address address, bool isCountryFieldVisible = false,
            bool isForeignAddressFieldVisible = false, bool needFillRegionOnCountryChanged = false, bool isCoordinatesFieldsVisible = false)
        {
            var args = new RouteValueDictionary { { "root", root }, { "address", address }, { "isCountryFieldVisible", isCountryFieldVisible }, 
                { "isForeignAddressFieldVisible", isForeignAddressFieldVisible }, { "needFillRegionOnCountryChanged", needFillRegionOnCountryChanged },
                {"isCoordinatesFieldsVisible", isCoordinatesFieldsVisible}};
            return htmlHelper.Action("AddressInTwoColumns", "Address", args);
        }

        public static MvcHtmlString AddressWithCountry(this HtmlHelper htmlHelper, long root, eidss.model.Schema.Address address)
        {
            var args = new RouteValueDictionary { { "root", root }, { "address", address } };
            return htmlHelper.Action("AddressWithCountry", "Address", args);
        }

        #endregion

        #region ActionPanel extenders

        public static void RenderActionPanel(this HtmlHelper htmlHelper, IObjectAccessor accessor, IObject obj, ActionsPanelType panelType)
        {
            if (accessor != null)
                htmlHelper.RenderAction("Index", "ActionPanel", 
                    new RouteValueDictionary { { "accessor", accessor }, { "obj", obj }, { "panelType", panelType } });
        }
        #endregion
    }
}
