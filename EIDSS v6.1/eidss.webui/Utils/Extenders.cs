using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using bv.common.Configuration;
using bv.model.Model.Core;
using Telerik.Web.Mvc.UI;

namespace eidss.webui.Utils
{
    public static class Extenders
    {
        private static readonly int m_HeartbeatSeconds = Config.GetIntSetting("HeartbeatSeconds", 300);

        public static MvcHtmlString IdentificationAndHeartbeat(this HtmlHelper htmlHelper, string keyName, long keyValue)
        {
            return new MvcHtmlString(
@"<input id='" + keyName + @"' name='" + keyName + @"' type='hidden' value='" + keyValue + @"' />
<script type='text/javascript'>
setInterval(
    function heartbeat() {
        $.post('/System/Heartbeat', { id: " + keyValue + @" } );
        }, " + (m_HeartbeatSeconds * 1000) + @");
</script>");
        }


        //public static object Wrap(this HtmlHelper htmlHelper, object content)
        //{
        //    return content;
        //}

        public static Telerik.Web.Mvc.UI.Fluent.ComboBoxBuilder BvCombobox(this HtmlHelper htmlHelper, IObject obj, string bindToProp, int? width = null, bool bBind = true, string clientOnChange = null)
        {
            string style = "";
            if (obj.IsRequired(bindToProp))
            {
                style += "border: 1px solid Red;";
            }
            if (width != null)
            {
                style += "width:" + width + "px;";
            }
            var htmlAttributes = new { style };
            BvSelectList selectlist = obj.GetList(bindToProp);
            var ret = htmlHelper.Telerik().ComboBox()
                .Name(obj.ObjectIdent + bindToProp)
                .SelectedIndex(selectlist.items.IndexOf(selectlist.selectedValue))
                .Enable(!obj.IsReadOnly(bindToProp))
                .ClientEvents(events => events
                    .OnChange(clientOnChange ?? "ModelFieldChangedCombobox")
                    .OnLoad("ModelFieldLoadCombobox")
                    )
                .HtmlAttributes(htmlAttributes);
            if (bBind)
                ret = ret.BindTo(new SelectList(selectlist.items, selectlist.dataValueField, selectlist.dataTextField, selectlist.selectedValue));
            return ret;
        }

        public static Telerik.Web.Mvc.UI.Fluent.DropDownListBuilder BvDropdownList(this HtmlHelper htmlHelper, IObject obj, string bindToProp, int? width = null, bool bBind = true, string clientOnChange = null)
        {
            string style = "";
            if (obj.IsRequired(bindToProp))
            {
                style += "border: 1px solid Red;";
            }
            if (width != null)
            {
                style += "width:" + width + "px;";
            }
            var htmlAttributes = new { style };
            BvSelectList selectlist = obj.GetList(bindToProp);
            var ret = htmlHelper.Telerik().DropDownList()
                .Name(obj.ObjectIdent + bindToProp)
                .SelectedIndex(selectlist.items.IndexOf(selectlist.selectedValue) < 0 ? 0 : selectlist.items.IndexOf(selectlist.selectedValue))
               // .Enable(!obj.IsReadOnly(bindToProp))
                .ClientEvents(events => events.OnChange(clientOnChange ?? "ModelFieldChangedDropdownList"))
                .HtmlAttributes(htmlAttributes);
            if (bBind)
                ret = ret.BindTo(new SelectList(selectlist.items, selectlist.dataValueField, selectlist.dataTextField, selectlist.selectedValue));
            return ret;
        }

        public static Telerik.Web.Mvc.UI.Fluent.DatePickerBuilder BvDatebox(this HtmlHelper htmlHelper, IObject obj, string bindToProp, string clientOnChange = null)
        {
            var ret = htmlHelper.Telerik().DatePicker()
                .Name(obj.ObjectIdent + bindToProp)
                .Value(obj.GetValue(bindToProp) as DateTime?)
                .ClientEvents(events => events.OnChange(clientOnChange ?? "ModelFieldChangedDate"))
                .Enable(!obj.IsReadOnly(bindToProp));
            return ret;
        }

        public static Telerik.Web.Mvc.UI.Fluent.DateTimePickerBuilder BvDatetimebox(this HtmlHelper htmlHelper, IObject obj, string bindToProp, string clientOnChange = null)
        {
            var ret = htmlHelper.Telerik().DateTimePicker()
                .Name(obj.ObjectIdent + bindToProp)
                .Value(obj.GetValue(bindToProp) as DateTime?)
                .ClientEvents(events => events.OnChange(clientOnChange ?? "ModelFieldChangedDatetime"))
                .Enable(!obj.IsReadOnly(bindToProp));
            return ret;
        }

        public static MvcHtmlString BvEditbox(this HtmlHelper htmlHelper, IObject obj, string bindToProp)
        {
            var htmlAttributes = new Dictionary<string, object>();
            if (obj.IsReadOnly(bindToProp))
            {
                htmlAttributes.Add("readonly", "readonly");
                htmlAttributes.Add("class", "readonly-text");
            }
            if (obj.IsRequired(bindToProp))
            {
                htmlAttributes.Add("class", "required-text");
            }
            return htmlHelper.TextBox(obj.ObjectIdent + bindToProp, obj.GetValue(bindToProp), htmlAttributes);
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

    }
}