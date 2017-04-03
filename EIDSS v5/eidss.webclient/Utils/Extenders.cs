using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using BLToolkit.EditableObjects;
using bv.common.Configuration;
using bv.model.Model.Core;
using Telerik.Web.Mvc.UI;
using System.Web;
using System.Collections;
using bv.model.Helpers;
using eidss.model.Core;

namespace eidss.webclient.Utils
{
    public static partial class Extenders
    {
        private static readonly int m_HeartbeatSeconds = Config.GetIntSetting("HeartbeatSeconds", 300);

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

        public static MvcHtmlString IdentificationAndHeartbeat(this HtmlHelper htmlHelper, string keyName, long keyValue)
        {
            return new MvcHtmlString(
                @"<input id='" + keyName + @"' name='" + keyName + @"' type='hidden' value='" + keyValue + @"' />
                <script type='text/javascript'>
                //setInterval(
                //    function heartbeat() {
                //        $.post(heartbeatUrl, { id: " + keyValue + @" } );
                //        }, " + (m_HeartbeatSeconds * 1000) + @");
                function checkChanges(ifChanged, ifNotChanged)
                {
                    CheckChangesById(ifChanged, ifNotChanged, " + keyValue + @");
                }
                </script>");
        }

        #region BV UI elements
        public static Telerik.Web.Mvc.UI.Fluent.ComboBoxBuilder BvCombobox(this HtmlHelper htmlHelper, IObject obj, string bindToProp, bool bBind = true, string clientOnChange = null, string styleClass = null, string strRight = null, bool readOnly = false)
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
            if (obj.IsInvisible(bindToProp))
            {
                cls += " invisible";
            }
            var bIsAutoTestingVersion = Config.GetBoolSetting("AutoTestingVersion");
            var htmlAttributes = bIsAutoTestingVersion
                ? (object) new { @class = cls, bvid = obj.ObjectName + "." + bindToProp }
                : new { @class = cls };
            //if (obj.IsHiddenPersonalData(bindToProp))
            //{                
            //    return new MvcHtmlString(
            //        String.Format("<div class='tdContainer'>{0}</div>", 
            //        htmlHelper.TextBox(bindToProp, "***********", 
            //        new Dictionary<string,object> { {"class", cls +"readonlyField"} })));

            //}

            BvSelectList selectlist = obj.GetList(bindToProp);
            int index = selectlist == null ? -1 : selectlist.items.IndexOf(selectlist.selectedValue);
            if (index < 0 && selectlist != null && selectlist.items != null && selectlist.selectedValue != null)
            {
                string str = selectlist.selectedValue.ToString();
                if (!string.IsNullOrEmpty(str))
                {
                    for (int i = 0; i < selectlist.items.Count; i++)
                    {
                        if (selectlist.items[i].ToString() == str)
                        {
                            index = i;
                            break;
                        }
                    }
                }
            }

            bool bEnable = !(obj.IsReadOnly(bindToProp) || readOnly);
            IObjectPermissions permission = obj.GetPermissions();
            if (permission != null)
            {
                bEnable = bEnable && !permission.IsReadOnlyForEdit;
            }
            if (strRight != null)
            {
                bEnable = bEnable && ModelUserContext.Instance.CanDo(strRight);
            }

            var ret = htmlHelper.Telerik().ComboBox()
                .Name(obj.ObjectIdent + bindToProp)
                .SelectedIndex(index)
                .Enable(bEnable)
                .ClientEvents(events => events
                    .OnChange(clientOnChange ?? "ModelFieldChangedCombobox")
                    .OnLoad("ModelFieldLoadCombobox")
                    )
                .HtmlAttributes(htmlAttributes);
            if (bBind && selectlist != null)
                ret = ret.BindTo(new SelectList(selectlist.items, selectlist.dataValueField, selectlist.dataTextField, selectlist.selectedValue));
            return ret;
        }

        public static Telerik.Web.Mvc.UI.Fluent.ComboBoxBuilder BvDummyCombobox(this HtmlHelper htmlHelper)
        {
            string style = "width:0px;";
            var htmlAttributes = new { style };
            var ret = htmlHelper.Telerik().ComboBox()
                .Name("dummy_combo")
                .Enable(false)
                .HtmlAttributes(htmlAttributes);
            return ret;
        }



        public static Telerik.Web.Mvc.UI.Fluent.DropDownListBuilder BvDropdownList(this HtmlHelper htmlHelper, IObject obj, string bindToProp, bool bBind = true, string clientOnChange = null, string styleClass = null)
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

            var ret = htmlHelper.Telerik().DropDownList()
                .Name(obj.ObjectIdent + bindToProp)
                .SelectedIndex(selectlist.items.IndexOf(selectlist.selectedValue) < 0 ? 0 : selectlist.items.IndexOf(selectlist.selectedValue))
                .Enable(bEnable)
                .ClientEvents(events => events.OnChange(clientOnChange ?? "ModelFieldChangedDropdownList"))
                .HtmlAttributes(htmlAttributes);
            if (bBind)
                ret = ret.BindTo(new SelectList(selectlist.items, selectlist.dataValueField, selectlist.dataTextField, selectlist.selectedValue));
            return ret;
        }

        public static Telerik.Web.Mvc.UI.Fluent.DatePickerBuilder BvDatebox(this HtmlHelper htmlHelper, IObject obj, string bindToProp, string clientOnChange = null, bool limitMaxDate = false)
        {
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


            var ret = htmlHelper.Telerik().DatePicker()
                .Name(obj.ObjectIdent + bindToProp)
                .Value(obj.GetValue(bindToProp) as DateTime?)
                .ClientEvents(events => events.OnChange(clientOnChange ?? "ModelFieldChangedDate"))
                .HtmlAttributes(htmlAttributes)
                .Enable(bEnable)
                .Max(limitMaxDate ? DateTime.Today.AddDays(1).AddMinutes(-1) : DateTime.MaxValue);

            return ret;
        }

        public static Telerik.Web.Mvc.UI.Fluent.DateTimePickerBuilder BvDatetimebox(this HtmlHelper htmlHelper, IObject obj, string bindToProp, string clientOnChange = null)
        {
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

            var ret = htmlHelper.Telerik().DateTimePicker()
                .Name(obj.ObjectIdent + bindToProp)
                .Value(obj.GetValue(bindToProp) as DateTime?)
                .ClientEvents(events => events.OnChange(clientOnChange ?? "ModelFieldChangedDatetime"))
                .HtmlAttributes(htmlAttributes)
                .Enable(bEnable)
                .Max(DateTime.Now.AddHours(1));
            return ret;
        }
        public static Telerik.Web.Mvc.UI.Fluent.DateTimePickerBuilder BvDummyDatetimebox(this HtmlHelper htmlHelper)
        {
            string style = "width:0px;";
            var htmlAttributes = new { style };
            var ret = htmlHelper.Telerik().DateTimePicker()
                .Name("dummy_datetime")
                .Enable(false)
                .HtmlAttributes(htmlAttributes);
            return ret;
        }

        public static MvcHtmlString BvHidden(this HtmlHelper htmlHelper, IObject obj, string bindToProp)
        {
            return htmlHelper.Hidden(obj.ObjectIdent + bindToProp, obj.GetValue(bindToProp));
        }
        public static MvcHtmlString BvLabel(this HtmlHelper htmlHelper, IObject obj, string labelFor)
        {
            var label = new TagBuilder("label");
            label.Attributes["for"] = TagBuilder.CreateSanitizedId(labelFor);
            string text = Translator.GetString(labelFor);
            label.InnerHtml = HttpUtility.HtmlEncode(text);
            if (obj.IsInvisible(labelFor))
            {
                label.AddCssClass("invisible");
            }
            return MvcHtmlString.Create(label.ToString());
        }

        public static MvcHtmlString BvHiddenPersonalData(this HtmlHelper htmlHelper, string bindToProp, string format = "**********", bool isInvisible = false)
        {
            var htmlAttributes = new Dictionary<string, object>();
            htmlAttributes.Add("class", "readonlyField");
            if (isInvisible)
            {
                htmlAttributes["class"] = "readonlyField invisible";
            }
            return new MvcHtmlString(String.Format("<div class='tdContainer'>{0}</div>", htmlHelper.TextBox(bindToProp, format, htmlAttributes)));
        }

        public static MvcHtmlString BvEditbox(this HtmlHelper htmlHelper, IObject obj, string bindToProp, bool refreshOnLostFocus = false, string width = null, string strRight = null)
        {
            if (obj.IsHiddenPersonalData(bindToProp))
            {
                return htmlHelper.BvHiddenPersonalData(bindToProp, isInvisible: obj.IsInvisible(bindToProp));
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
            if (!bEnable && obj.IsRequired(bindToProp))
            {
                htmlAttributes.Add("class", "readonlyField requiredField");
            }
            else if (!bEnable)
            {
                htmlAttributes.Add("class", "readonlyField");
            }
            else if (obj.IsRequired(bindToProp))
            {
                htmlAttributes.Add("class", "requiredField");
            }
            else if (obj.IsInvisible(bindToProp))
            {
                htmlAttributes.Add("class", "invisible");
            }
            int? maxSize = ((IObjectMeta)obj.GetAccessor()).MaxSize(bindToProp);
            if (maxSize.HasValue)
            {
                htmlAttributes.Add("maxlength", maxSize);
            }
            if (refreshOnLostFocus)
            {
                string textBoxName = obj.ObjectIdent + bindToProp;
                htmlAttributes.Add("onblur", string.Format("ModelFieldChangedEditbox('{0}');", textBoxName));
            }
            MvcHtmlString textBox = htmlHelper.TextBox(obj.ObjectIdent + bindToProp, obj.GetValue(bindToProp), htmlAttributes);
            string result = String.Format("<div class='tdContainer'>{0}</div>", textBox); // fix for IE (100% 'input' width)
            return new MvcHtmlString(result);
        }
        public static MvcHtmlString BvReadOnlyEditbox(this HtmlHelper htmlHelper, IObject obj, string bindToProp)
        {
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

        public static MvcHtmlString BvTextArea(this HtmlHelper htmlHelper, IObject obj, string bindToProp, bool refreshOnLostFocus = false)
        {
            if (obj.IsHiddenPersonalData(bindToProp))
            {
                return htmlHelper.BvHiddenPersonalData(bindToProp);
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
                htmlAttributes.Add("onblur", string.Format("ModelFieldChangedEditbox('{0}');", textBoxName));
            }
            MvcHtmlString textBox = htmlHelper.TextArea(obj.ObjectIdent + bindToProp, obj.GetValue(bindToProp).ToString(), htmlAttributes);
            string result = String.Format("<div class='tdContainer'>{0}</div>", textBox); // fix for IE (100% 'input' width)
            return new MvcHtmlString(result);
        }

        public static MvcHtmlString BvNumeric(this HtmlHelper htmlHelper, IObject obj, string bindToProp, int decimalDigits = 2, double minValue = 0, double maxValue = double.MaxValue, bool refreshOnLostFocus = false, string clientOnChange = null)
        {
            if (obj.IsHiddenPersonalData(bindToProp))
            {
                return htmlHelper.BvHiddenPersonalData(bindToProp, decimalDigits == 0 ? "****" : "***.**");
            }
            string cls = "fillAll"; // default style - width:100%
            var htmlAttributes = new Dictionary<string, object>();
            var bIsAutoTestingVersion = Config.GetBoolSetting("AutoTestingVersion");
            if (bIsAutoTestingVersion)
                htmlAttributes.Add("bvid", obj.ObjectName + "." + bindToProp);
            if (obj.IsRequired(bindToProp))
            {
                cls += "requiredField";
            }
            htmlAttributes.Add("class", cls);
            double? value = obj.GetValue(bindToProp) as double?;
            if (obj.GetValue(bindToProp) != null && decimalDigits == 0 && value == null)
                value = Convert.ToDouble((int)obj.GetValue(bindToProp));

            bool bEnable = !obj.IsReadOnly(bindToProp);
            IObjectPermissions permission = obj.GetPermissions();
            if (permission != null)
                bEnable = bEnable && !permission.IsReadOnlyForEdit;

            var ret = htmlHelper.Telerik()
                .NumericTextBox().Name(obj.ObjectIdent + bindToProp)
                .Value(value)
                .Enable(bEnable)
                .DecimalDigits(decimalDigits)
                .MinValue(minValue)
                .MaxValue(maxValue)
                .EmptyMessage("")
                .HtmlAttributes(htmlAttributes);

            if (refreshOnLostFocus)
            {
                ret = ret
                    .ClientEvents(events => events.OnChange(clientOnChange ?? "ModelFieldChangedNumeric"));
            }

            string result = String.Format("<div class='tdContainer'>{0}</div>", ret.ToHtmlString()); // fix for IE (100% 'input' width)
            return new MvcHtmlString(result);
        }


        public static MvcHtmlString BvRadioButtonGroup(this HtmlHelper htmlHelper, IObject obj, string bindToProp, bool verticalLayout = true)
        {
            BvSelectList selectlist = obj.GetList(bindToProp);
            if (selectlist == null)
                return new MvcHtmlString("");

            bool bEnable = !obj.IsReadOnly(bindToProp);
            IObjectPermissions permission = obj.GetPermissions();
            if (permission != null)
                bEnable = bEnable && !permission.IsReadOnlyForEdit;

            StringBuilder result = new StringBuilder();
            //the result is a list with radiobuttons
            if (verticalLayout)
            {
                result.Append("<ul class='radioList'>");
            }

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

                if (verticalLayout)
                {
                    result.AppendFormat("<li>{0}{1}</li>\r\n", radio, label);
                }
                else
                {
                    result.AppendFormat("{0}{1}&nbsp;&nbsp;&nbsp;", radio, label);
                }
            }
            if (verticalLayout)
            {
                result.Append("</ul>");
            }
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

        public static MvcHtmlString BvCheckBox(this HtmlHelper htmlHelper, IObject obj, string bindToProp)
        {
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

        public static MvcHtmlString BvCheckBox(this HtmlHelper htmlHelper, IObject obj, string bindToProp, bool bSendToServer, string strEventOnClick = null, string strRight = null)
        {
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
                                      bSendToServer ? "onclick='ModelFieldChangedCheckbox(\"" + checkBoxName + "\")'" :
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
                                      bSendToServer ? "onclick='ModelFieldChangedCheckbox(\"" + checkBoxName + "\")'" :
                                        strEventOnClick == null ? "" : "onclick='" + strEventOnClick + "(\"" + checkBoxName + "\")'",
                                      !bEnable ? "disabled='disabled'" : ""
                                      );
            result.AppendFormat("{0}{1}", radio, label);
            return new MvcHtmlString(result.ToString());
        }
        #endregion

        #region BV Grids

        public static Telerik.Web.Mvc.UI.Fluent.GridBuilder<M> BvGrid<M, L>(this HtmlHelper htmlHelper, string name, L list,
            string styleClass, string clientOnEdit = null, string clientOnSelect = null,
            bool readOnly = false, bool bCustomToolbar = false, bool bFilterable = false, bool bEditable = true, bool bToolBarBtnsDisable = false,
            string strExcludeColumns = null, string onDataBound = null, string onDelete = null, IObject sample = null)
            where M : class, IGridModelItem
            where L : class, IGridModelList
        {
            string[] strExclude = strExcludeColumns == null ? null : strExcludeColumns.Split(',');
            var ret = htmlHelper.Telerik().Grid<M>()
                .Name(name)
                .DataKeys(keys => keys.Add(c => c.ItemKey))
                .Selectable()
                .Sortable()
                .Scrollable(s => s.Enabled(true))
                .HtmlAttributes(new { @class = styleClass })
                .Resizable(r => r.Columns(true))
                .Footer(false)
                .DataBinding(dataBinding => dataBinding.Ajax()
                    .Select("_GridBinding", "System", new RouteValueDictionary { { "area", String.Empty }, { "key", list.ListKey }, { "name", name }, { "type", typeof(L).FullName } })
                    //.Insert("_GridInsert", "System", new RouteValueDictionary { { "area", String.Empty }, { "key", list.ListKey }, { "name", name }, { "type", typeof(L).FullName } })
                    //.Update("_GridUpdate", "System", new RouteValueDictionary { { "area", String.Empty }, { "key", list.ListKey }, { "name", name }, { "type", typeof(L).FullName } })
                    .Delete("_GridDelete", "System", new RouteValueDictionary { { "area", String.Empty }, { "key", list.ListKey }, { "name", name }, { "type", typeof(L).FullName } })
                    )
                .Columns(columns =>
                    {
                        //list.Keys.ForEach(c => columns.Bound(c).Hidden());   
                        foreach (var c in list.Columns)
                        {
                            if (strExclude != null && strExclude.Contains(c))
                                continue;
                                                                                      
                            if (sample == null)
                            {
                                if (c.StartsWith("dat"))
                                {
                                    if (!SystemDateFields.Contains(c))
                                    {
                                        columns
                                            .Bound(c)
                                            .Title(Translator.GetString(list.Labels.ContainsKey(c) ? list.Labels[c] : c))
                                            .HeaderHtmlAttributes(new { title = Translator.GetString(list.Labels.ContainsKey(c) ? list.Labels[c] : c) })
                                            .ClientTemplate(String.Format("<#=toServerTime( {0})#>", c));
                                    }
                                    else
                                    {
                                        columns
                                           .Bound(c)
                                           .Title(Translator.GetString(list.Labels.ContainsKey(c) ? list.Labels[c] : c))
                                           .HeaderHtmlAttributes(new { title = Translator.GetString(list.Labels.ContainsKey(c) ? list.Labels[c] : c) })
                                           .Format("{0:d}");
                                    }
                                        
                                }
                                else
                                {
                                    columns.Bound(c).Title(Translator.GetString(list.Labels.ContainsKey(c) ? list.Labels[c] : c))
                                        .HeaderHtmlAttributes(new { title = Translator.GetString(list.Labels.ContainsKey(c) ? list.Labels[c] : c) });
                                }
                            }
                            else
                            {
                                if (sample.IsHiddenPersonalData(c) && !GeoLocationsToBeHidden.Contains(c)/*!c.Contains("GeoLocationName")*/)
                                {
                                    columns.Bound(c).ClientTemplate("*******").Title(Translator.GetString(list.Labels.ContainsKey(c) ? list.Labels[c] : c))
                                        .HeaderHtmlAttributes(new { title = Translator.GetString(list.Labels.ContainsKey(c) ? list.Labels[c] : c) });
                                }
                                else
                                {
                                    if (c.StartsWith("dat"))
                                    {
                                        if (!SystemDateFields.Contains(c))
                                        {
                                            columns
                                                .Bound(c)
                                                .Title(Translator.GetString(list.Labels.ContainsKey(c) ? list.Labels[c] : c))
                                                .HeaderHtmlAttributes(new { title = Translator.GetString(list.Labels.ContainsKey(c) ? list.Labels[c] : c) })
                                                .ClientTemplate(String.Format("<#=toServerTime( {0})#>", c));
                                        }
                                        else
                                        {
                                            columns
                                               .Bound(c)
                                               .Title(Translator.GetString(list.Labels.ContainsKey(c) ? list.Labels[c] : c))
                                               .HeaderHtmlAttributes(new { title = Translator.GetString(list.Labels.ContainsKey(c) ? list.Labels[c] : c) })
                                               .Format("{0:d}");
                                        }
                                    }
                                    else
                                    {
                                        columns.Bound(c).Title(Translator.GetString(list.Labels.ContainsKey(c) ? list.Labels[c] : c))
                                            .HeaderHtmlAttributes(new { title = Translator.GetString(list.Labels.ContainsKey(c) ? list.Labels[c] : c) });
                                    }
                                }
                                
                            }
                            
                        }

                        //list.Columns
                        //    .Where(c => (strExclude == null)
                        //        ? true 
                        //        : !strExclude.Contains(c))
                        //    .ToList()
                        //    .ForEach(c => columns.Bound(c).Title(Translator.GetString(list.Labels.ContainsKey(c) ? list.Labels[c] : c)));

                        columns.Command(c => c.Delete().ButtonType(GridButtonType.Image).HtmlAttributes(new { style = "display:none" })).Width(0);

                        // !Important! Hidden field must be the last one and has display:none attribute
                        //columns.Bound("ItemKey").Hidden(true).ReadOnly(true).HtmlAttributes(new { style = "display:none" });
                        columns.Bound("ItemKey")
                            .Hidden(true)
                            .ClientTemplate("<input type='hidden' name='ItemKey' value='<#=ItemKey#>' />")
                            .HtmlAttributes(new { @class = "gridId" })
                            .Width(0);

                        list.Hiddens.ForEach(c => columns
                            .Bound(c)
                            .Hidden(true)
                            .ClientTemplate("<input type='hidden' name='" + c + "' value='<#=" + c + "#>' />")
                            .HtmlAttributes(new { @class = "gridHidden" })
                            .Width(0));
                    })
                .ClientEvents(events => events
                    .OnRowDataBound("bvGridOnRowDataBound")
                    .OnEdit(clientOnEdit ?? "bvGridNothing")
                    .OnDelete("function(e) { " + (onDelete ?? "bvGridOnDelete") + "(e, " + list.ListKey + ", '" + name + "', " + (bToolBarBtnsDisable ? "'true'" : "'false'") + ") }")
                    .OnRowSelect(clientOnSelect ?? "bvGridNothing")
                    .OnLoad("function(e) { bvGridOnLoad(e, " + (readOnly ? "'true'" : "'false'") + ", " + (bToolBarBtnsDisable ? "'true'" : "'false'") + ") }")
                    .OnDataBound(onDataBound ?? "function(e) { bvGridOnDataBound(e, " + (bToolBarBtnsDisable ? "'true'" : "'false'") + ") }")
                    );
            if (bEditable && !bCustomToolbar)
            {
                //Translator.GetMessageString
                var toolBarTemplate = new StringBuilder();
                toolBarTemplate.AppendFormat("<a href='#' class='t-grid-action t-button t-button-icon t-grid-delete'>" +
                                             "<span>{0}</span></a>", Translator.GetMessageString("Delete"));
                toolBarTemplate.AppendFormat("<a href='#' class='t-grid-action t-button t-button-icon t-grid-edit'>" +
                                             "<span>{0}</span></a>", Translator.GetMessageString("Edit"));
                toolBarTemplate.AppendFormat("<a href='#' class='t-grid-action t-button t-button-icon t-grid-add'>" +
                                             "<span>{0}</span></a>", Translator.GetMessageString("strNew"));
                ret = ret.ToolBar(toolBar => toolBar.Template(toolBarTemplate.ToString()));
            }
            if (bFilterable)
            {
                //ret = ret.Filterable();
            }
            if (bEditable)
            {
                //ret = ret.Editable(e => e.Mode(GridEditMode.InLine));
            }

            return ret;
        }

        private static List<string> GeoLocationsToBeHidden = new List<string> { "GeoLocationName", "AddressName" };
        private static List<string> SystemDateFields = new List<string> { "datEnteredDate" };

        public static Telerik.Web.Mvc.UI.Fluent.GridBuilder<M> BvFullGrid<M, L>(this HtmlHelper htmlHelper,
            string sessionId,
            L list,
            byte? pageSize = null,
            string cssclass = "lfGrid",
            string gridName = "Grid",            
           IObject sample = null)
            where M : class, IGridModelItem
            where L : class, IGridModelList
        {
            //recount geolocations if needed
            if (sample != null && list.Columns.Count(s=>GeoLocationsToBeHidden.Contains(s)) > 0)
            {
                ModelStorage.Put(sessionId, list.ListKey, list.ListKey, "SampleObject", sample);
            }
            
            ModelStorage.Put(sessionId, list.ListKey, list.ListKey, gridName, list as IEnumerable);
            pageSize = pageSize ?? Configurations.GridDisplayRowsSettings.DEFAULT_VALUE;
            var ret = htmlHelper.Telerik().Grid<M>()
                .Name(gridName)
                .DataKeys(keys => keys.Add(c => c.ItemKey))
                .Selectable()
                .Sortable()
                .Scrollable(s => s.Enabled(true))
                .HtmlAttributes(new { @class = cssclass })
                .Resizable(r => r.Columns(true))
                .Pageable(p => p.PageSize((int)pageSize))
                .DataBinding(dataBinding => dataBinding.Ajax()
                    .Select("_FullGridBinding", "System", new RouteValueDictionary { { "area", String.Empty }, { "key", list.ListKey }, { "name", gridName }, { "type", typeof(L).FullName } })
                    .Delete("_FullGridDelete", "System", new RouteValueDictionary { { "area", String.Empty }, { "key", list.ListKey }, { "name", gridName }, { "type", typeof(L).FullName } })
                    )
                .Columns(columns =>
                {
                    if (sample == null)
                    {
                        foreach (var columnName in list.Columns)
                        {
                            if (columnName.StartsWith("dat") && !SystemDateFields.Contains(columnName))
                            {
                                columns
                                    .Bound(columnName)
                                    .Format("{0:d}")
                                    .Title(Translator.GetString(list.Labels.ContainsKey(columnName) ? list.Labels[columnName] : columnName))
                                    .HeaderHtmlAttributes(new { title = Translator.GetString(list.Labels.ContainsKey(columnName) ? list.Labels[columnName] : columnName) });
                            }
                            else if(list.Actions.ContainsKey(columnName))
                            {
                                columns
                                    .Bound(columnName)
                                    .ClientTemplate(string.Format("<a href='javascript:{0}(\"<#=ItemKey#>\");'><#= {1} #></a>", list.Actions[columnName].Name, columnName))
                                    .Title(Translator.GetString(list.Labels.ContainsKey(columnName) ? list.Labels[columnName] : columnName))
                                    .HeaderHtmlAttributes(new { title = Translator.GetString(list.Labels.ContainsKey(columnName) ? list.Labels[columnName] : columnName) });
                            }
                            else
                            {
                                columns.Bound(columnName).Title(Translator.GetString(list.Labels.ContainsKey(columnName) ? list.Labels[columnName] : columnName))
                                    .HeaderHtmlAttributes(new { title = Translator.GetString(list.Labels.ContainsKey(columnName) ? list.Labels[columnName] : columnName) });
                            }   
                        }    
                    }
                    else
                    {
                        foreach (var columnName in list.Columns)
                        {
                            if (sample.IsHiddenPersonalData(columnName) && !GeoLocationsToBeHidden.Contains(columnName))
                            {
                                columns.Bound(columnName).ClientTemplate("*******").Title(Translator.GetString(list.Labels.ContainsKey(columnName) ? list.Labels[columnName] : columnName))
                                    .HeaderHtmlAttributes(new { title = Translator.GetString(list.Labels.ContainsKey(columnName) ? list.Labels[columnName] : columnName) }); 
                            }
                            else
                            {
                                if (columnName.StartsWith("dat") && !SystemDateFields.Contains(columnName))
                                {
                                    columns.Bound(columnName).Format("{0:d}").Title(Translator.GetString(list.Labels.ContainsKey(columnName) ? list.Labels[columnName] : columnName))
                                        .HeaderHtmlAttributes(new { title = Translator.GetString(list.Labels.ContainsKey(columnName) ? list.Labels[columnName] : columnName) });
                                }
                                else if (list.Actions.ContainsKey(columnName))
                                {
                                    columns
                                        .Bound(columnName)
                                        .ClientTemplate(string.Format("<a href='javascript:{0}(\"<#=ItemKey#>\");'><#= {1} #></a>", list.Actions[columnName].Name, columnName))
                                        .Title(Translator.GetString(list.Labels.ContainsKey(columnName) ? list.Labels[columnName] : columnName))
                                        .HeaderHtmlAttributes(new { title = Translator.GetString(list.Labels.ContainsKey(columnName) ? list.Labels[columnName] : columnName) });
                                }
                                else
                                {
                                    columns.Bound(columnName).Title(Translator.GetString(list.Labels.ContainsKey(columnName) ? list.Labels[columnName] : columnName))
                                        .HeaderHtmlAttributes(new { title = Translator.GetString(list.Labels.ContainsKey(columnName) ? list.Labels[columnName] : columnName) });
                                }
                            }
                        }
                    }
                    columns.Command(c => c.Delete().ButtonType(GridButtonType.Image).HtmlAttributes(new { style = "display:none" })).Width(0);
                    columns.Bound("ItemKey").Hidden(true).HtmlAttributes(new { @class = "gridId" }).Width(0);
                    //columns.Bound("ItemKey").Hidden(true).ClientTemplate("<input type='hidden' name='id' value='<#= ItemKey#>'").HtmlAttributes(new { @class = "gridId" }).Width(0);
                })
                .ClientEvents(events => events
                    .OnDataBound(string.Format("function(e) {{ ClearSelection(e, '{0}') }}", gridName)));
            return ret;
        }

        public static Telerik.Web.Mvc.UI.Fluent.GridBuilder<M> BvSelectGrid<M, L>(this HtmlHelper htmlHelper,
            string sessionId,
            L list,
            //IEnumerable<object> items,
            byte? pageSize = null,
            string cssclass = "popupSearchGrid",
            bool multiSelectRows = false)
            where M : class, IGridModelItem
            where L : class, IGridModelList
        {
            string name = "Grid";
            ModelStorage.Put(sessionId, list.ListKey, list.ListKey, name, list as IEnumerable);
            pageSize = pageSize ?? Configurations.GridDisplayRowsSettings.DEFAULT_VALUE;
            var ret = htmlHelper.Telerik().Grid<M>()
                .Name(name)
                .DataKeys(keys => keys.Add(c => c.ItemKey))
                .Selectable()
                .Sortable()
                .Scrollable()
                .HtmlAttributes(new { @class = cssclass })
                .Resizable(r => r.Columns(true))
                .Pageable(p => p.PageSize((int)pageSize))
                .DataBinding(dataBinding => dataBinding.Ajax()
                    .Select("_SelectGridBinding", "System", new RouteValueDictionary { { "area", String.Empty }, { "key", list.ListKey }, { "name", name } })
                    )
                .Columns(columns =>
                {
                    if (multiSelectRows)
                    {
                        columns.Bound("ItemKey")
                            .ClientTemplate(string.Format("<input class='gridChB' type='checkbox' value='<#=ItemKey#>' onclick='onSearchPickerCheckBoxChange(this, \"{0}\");' />", name))
                            .Title("").Width(36).HtmlAttributes(new { @class = "gridChBTd" });
                    }
                    foreach (var columnName in list.Columns)
                    {
                        if (columnName.StartsWith("dat") && !SystemDateFields.Contains(columnName))
                        {
                            columns
                                .Bound(columnName)
                                .Width(120)
                                .Format("{0:d}")
                                .Title(Translator.GetString(list.Labels.ContainsKey(columnName) ? list.Labels[columnName] : columnName))
                                .HeaderHtmlAttributes(new { title = Translator.GetString(list.Labels.ContainsKey(columnName) ? list.Labels[columnName] : columnName) });
                        }
                        else
                        {
                            columns
                                .Bound(columnName)
                                .Width(120)
                                .Title(Translator.GetString(list.Labels.ContainsKey(columnName) ? list.Labels[columnName] : columnName))
                                .HeaderHtmlAttributes(new { title = Translator.GetString(list.Labels.ContainsKey(columnName) ? list.Labels[columnName] : columnName) });
                        }
                    }                      
                    //list.Columns.ForEach(c => columns.Bound(c).Title(Translator.GetString(list.Labels.ContainsKey(c) ? list.Labels[c] : c)));
                    columns.Bound("ItemKey").Hidden(true).HtmlAttributes(new { @class = "gridId" }).Width(0);
                })
                .ClientEvents(events => events
                    .OnDataBound(string.Format("function(e) {{ ClearSelection(e, '{0}') }}", name))
                    .OnRowSelect(multiSelectRows ? "onSearchPickerRowSelect" : "bvGridNothing"));
            return ret;
        }

        #endregion
    }
}
