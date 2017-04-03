<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Model.FlexibleForms.FlexNodes.FlexNode>" %>
<%@ Import Namespace="eidss.model.Enums"  %>
<%@ Import Namespace="eidss.model.Model.FlexibleForms.FlexNodes" %>
<%@ Import Namespace="eidss.model.Schema" %>
<%@ Import Namespace="eidss.model.Model.FlexibleForms.Helpers" %>
<%@ Import Namespace="bv.common.Core" %>
<%@ Import Namespace="System.Globalization" %>

<table>
    <tr>        
        <%
            var parameterTemplate = Model.GetParameterTemplate();
            var parameterCaption = Model.UseFullPath ? Model.GetFullPathForNode(true) : parameterTemplate.NationalName;
        %>
        <td class="ffLabelTd">
            <%=parameterCaption%>
        </td>
        <td>        
        <%
            #region рендеринг управляющего контрола

            var enable = !Model.FFModel.ReadOnly;

            var cl = "control";
            if (parameterTemplate.IsMandatory()) cl += " requiredField";
            var htmlAttributes = new Dictionary<string, object> { { "class", cl } };
            if (!enable)
            {
                htmlAttributes.Add("readonly", "readonly");
                htmlAttributes.Add("disabled", "disabled");
            }
            var activityParameter = Model.GetParameterValue();
            var idObservation = Model.FFModel.CurrentObservation.HasValue ? Model.FFModel.CurrentObservation.Value : 0;
            if (activityParameter == null)
            {
                //создаём новый АП, чтобы сформировать ключ
                activityParameter = Model.ActivityParameters.SetActivityParameterValue(Model.FFModel.CurrentTemplate, idObservation, parameterTemplate.idfsParameter, DBNull.Value);
                activityParameter.varValue = null;
            }
            var idRow = activityParameter.idfRow.HasValue ? activityParameter.idfRow.Value : 0;
            if (Model.idfRow.HasValue && (Model.idfRow > 0) && (idRow < 0))
            {
                activityParameter.idfRow = idRow = Model.idfRow.Value;
            }
            var controlName = HelperFunctions.GetParameterKey(idObservation, parameterTemplate.idfsParameter, idRow);
            
            switch (parameterTemplate.Editor)
            {
                case FFParameterEditors.TextBox:
                   
                        var minValue = -99000000;
                        const int maxValue = 99000000;
                        var typeControl = 2; //0-NumericTextBox, 1-IntegerTextBox, 2-String

                        switch (parameterTemplate.ParameterType)
                        {
                            case FFParameterTypes.NumericPositive:
                                minValue = 0;
                                typeControl = 0;
                                break;
                            case FFParameterTypes.NumericNatural:
                                minValue = 0;
                                typeControl = 1;
                                break;
                            case FFParameterTypes.NumericInteger:
                                typeControl = 1;
                                break;
                        }

                        if (typeControl == 0)
                        {
                            double? valueDouble = null;
                            if (!Utils.IsEmpty(activityParameter.varValue)) valueDouble = Convert.ToDouble(activityParameter.varValue);
                            %><%= Html.Telerik().NumericTextBox()
                                .Name(controlName)
                                .EmptyMessage(String.Empty)
                                .DecimalSeparator(CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator)
                                .Spinners(false)
                                .MinValue(minValue)
                                .MaxValue(maxValue)
                                .NumberGroupSeparator(String.Empty)
                                .HtmlAttributes(htmlAttributes)
                                .Value(valueDouble)
                                .Enable(enable)
                                %><%
                        }
                        else if (typeControl == 1)
                        {
                            int? valueInt = null;
                            if (!Utils.IsEmpty(activityParameter.varValue)) valueInt = Convert.ToInt32(activityParameter.varValue);
                            %><%= Html.Telerik().IntegerTextBox()
                                .Name(controlName)
                                .EmptyMessage(String.Empty)
                                .Spinners(false)
                                .MinValue(minValue)
                                .MaxValue(maxValue)
                                .NumberGroupSeparator(String.Empty)
                                .HtmlAttributes(htmlAttributes)
                                .Value(valueInt)
                                .Enable(enable)
                                %><%
                        }
                        else if (typeControl == 2)
                        {
                            %>
                            <div class='tdContainer'>
                                <%= Html.TextBox(controlName, ActivityParameter.ToString(activityParameter), htmlAttributes) %>
                            </div>
                            <%
                        }
                    break;
                case FFParameterEditors.ComboBox:
                    var index = -1;
                    var idValue = ActivityParameter.ToLong(activityParameter);
                    var selected = parameterTemplate.SelectList.FirstOrDefault(c => c.idfsValue == idValue);
                    if (selected != null)
                    {
                        for (var i = 0; i < parameterTemplate.SelectList.Count; i++)
                        {
                            if (parameterTemplate.SelectList[i].strValueCaption == selected.strValueCaption)
                            {
                                index = i;
                                break;
                            }
                        }
                    }

                    var sl = new SelectList(parameterTemplate.SelectList, "idfsValue", "strValueCaption", selected);
                    
                    var ddl = Html.Telerik().ComboBox()
                        .Name(controlName)
                        .SelectedIndex(index)
                        .HtmlAttributes(new {@class = cl})
                        .Enable(enable)
                        .ClientEvents(c => c.OnChange("FFModelFieldChangedCombobox"))
                        .BindTo(sl);
                    ddl.Render();
                    
                    break;
                case FFParameterEditors.CheckBox:
                    %><%=Html.CheckBox(controlName, ActivityParameter.ToBool(activityParameter), htmlAttributes)%><%
                    break;
                case FFParameterEditors.Date:
                    var dt = Html.Telerik().DatePicker()
                        .Name(controlName)
                        .Enable(enable)
                        .Min(new DateTime(999, 1, 1));
                    if (!Utils.IsEmpty(activityParameter.varValue) && !activityParameter.varValue.Equals(DateTime.MinValue))
                        dt.Value(ActivityParameter.ToDate(activityParameter));
                    dt.Render();
                    break;
                case FFParameterEditors.DateTime:
                    var dtd = Html.Telerik().DateTimePicker()
                        .Name(controlName)
                        .Enable(enable);
                    if (!Utils.IsEmpty(activityParameter.varValue) && !activityParameter.varValue.Equals(DateTime.MinValue))
                    {
                        dtd.Value(ActivityParameter.ToDateTime(activityParameter));
                    }
                    dtd.Render();
                    break;
                case FFParameterEditors.Memo:
                    %><%= enable ? Html.TextArea(controlName, ActivityParameter.ToString(activityParameter), htmlAttributes) : activityParameter.varValue%><%
                    break;
                case FFParameterEditors.UpDown:
                    Html.Telerik().IntegerTextBox()
                        .Name(controlName)
                        .Value(ActivityParameter.ToInt(activityParameter))
                        .MinValue(0)
                        .MaxValue(99000000)
                        .Enable(enable)
                        .Render();
                    break;
                default:
                    //это крайне маловероятно, но всё же
                    %>
                    <div class='tdContainer'>
                        <%= Html.TextBox(controlName, ActivityParameter.ToString(activityParameter), htmlAttributes) %>
                    </div>
                    <%
                    break;
            }

            #endregion
            
             %>

        </td>
    </tr>    
</table>

