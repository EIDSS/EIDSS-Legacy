<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.webui.Areas.FlexForms.Models.FlexNodes.FlexNode>" %>
<%@ Import Namespace="eidss.model.Enums"  %>
<%@ Import Namespace="eidss.model.Schema" %>

<table border="0" class="ffparameter">
    <tr>        
        <%var parameterTemplate = Model.GetParameterTemplate();%>
        <td width="70%"><%=parameterTemplate.NationalName%></td>
        <td>        
        <%
            #region рендеринг управляющего контрола

            var controlName = String.Format("{0}idfsParameter_{1}", Model.FormKey, parameterTemplate.idfsParameter);
            var htmlAttributes = new Dictionary<string, object> { { "class", "control" } };

            var activityParameter = Model.GetParameterValue();
            
            //tmpItem.HtmlAttributes.AppendInValue("class", " ", "t-highlighted");
            switch (parameterTemplate.Editor)
            {
                case FFParameterEditors.TextBox:
                    %><%=Html.TextBox(controlName, ActivityParameter.ToString(activityParameter), htmlAttributes)%><%
                    //ControlParameter = new TextEdit();)
                    break;
                case FFParameterEditors.ComboBox:
                    //TODO определить как выставить ранее выбранное значение
                    Html.Telerik().DropDownList()
                        .Name(controlName)
                        .BindTo(new SelectList(parameterTemplate.SelectList, "idfsValue", "strValueCaption"))
                        //.HtmlAttributes(htmlAttributes)
                        .HtmlAttributes(new { @class = "control" })
                        .Render();
                    //ControlParameter = new LookUpEdit();
                    //LookUpEdit le = ControlParameter as LookUpEdit;
                    //le.Properties.NullText = String.Empty;
                    //le.Properties.ValueMember = "idfsValue";
                    //le.Properties.DisplayMember = "strValueCaption";
                    //LookUpColumnInfo column = new LookUpColumnInfo("strValueCaption", 120);
                    ////column.SortOrder = ColumnSortOrder.Ascending;
                    //le.Properties.Columns.Add(column);
                    //le.Properties.ShowHeader = le.Properties.ShowFooter = false;
                    //deleteEditorButton = new EditorButton(ButtonPredefines.Delete);
                    //le.Properties.Buttons.Add(deleteEditorButton);
                    //le.ButtonClick += OnButtonControlClick;)))
                    break;
                case FFParameterEditors.CheckBox:
                    %><%=Html.CheckBox(controlName, ActivityParameter.ToBool(activityParameter))%><%
                    //ControlParameter = new CheckEdit();
                    //ControlParameter.Text = String.Empty;
                    //CheckEdit checkEdit = (CheckEdit)ControlParameter;
                    //checkEdit.Properties.AutoWidth = true;
                    //checkEdit.Properties.NullStyle = StyleIndeterminate.Unchecked;)
                    break;
                case FFParameterEditors.Date:
                    Html.Telerik().DatePicker()
                        .Name(controlName)
                        .Min(new DateTime(999, 1, 1))
                        .Value(ActivityParameter.ToDate(activityParameter))
                        .Render();
                    //ControlParameter = new DateEdit();
                    //deleteEditorButton = new EditorButton(ButtonPredefines.Delete);
                    //DateEdit de = (DateEdit)ControlParameter;
                    //de.Properties.NullText = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                    //de.Properties.MinValue = new DateTime(1900, 1, 1);
                    //de.Properties.MaxValue = new DateTime(2050, 1, 1);
                    //de.Properties.Buttons.Add(deleteEditorButton);
                    //de.ButtonClick += OnButtonControlClick;
                    break;
                case FFParameterEditors.DateTime:
                    Html.Telerik().DateTimePicker()
                        .Name(controlName)
                        .Value(ActivityParameter.ToDateTime(activityParameter))
                        .Render();
                    //ControlParameter = new TimeEdit();
                    //TimeEdit te = (TimeEdit)ControlParameter;
                    //te.Properties.EditMask = "g";
                    //deleteEditorButton = new EditorButton(ButtonPredefines.Delete);
                    //te.Properties.Buttons.Add(deleteEditorButton);
                    //te.Properties.NullText = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                    //te.ButtonClick += OnButtonControlClick;
                    break;
                case FFParameterEditors.Memo:
                    Html.Telerik().Editor()
                        .Name(controlName)
                        .Tools(tools => tools.Clear())
                        .Encode(false)
                        .Value(ActivityParameter.ToString(activityParameter))
                        .Render();
                    //ControlParameter = new MemoEdit();
                    break;
                case FFParameterEditors.UpDown:
                    Html.Telerik().IntegerTextBox()
                        .Name(controlName)
                        .Value(ActivityParameter.ToInt(activityParameter))
                        .MinValue(0)
                        .MaxValue(99000000)
                        .Render();
                    //ControlParameter = new SpinEdit();
                    //SpinEdit se = (SpinEdit)ControlParameter;
                    //se.Properties.MaxValue = 99000000;
                    //se.Properties.MinValue = 0;
                    //deleteEditorButton = new EditorButton(ButtonPredefines.Delete);
                    //se.Properties.Buttons.Add(deleteEditorButton);
                    //se.ButtonClick += OnButtonControlClick;
                    break;
                default:
                    //это крайне маловероятно, но всё же
                    %><%=Html.TextBox(controlName, ActivityParameter.ToString(activityParameter), htmlAttributes)%><%
                    //ControlParameter = new TextEdit();
                    break;
            }

            #endregion
            
             %>

        </td>
    </tr>    
</table>

