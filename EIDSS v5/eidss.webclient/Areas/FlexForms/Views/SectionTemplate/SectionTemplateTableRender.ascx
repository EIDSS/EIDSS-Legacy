<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Model.FlexibleForms.FlexNodes.FlexNode>" %>
<%@ Import Namespace="eidss.model.Model.FlexibleForms.FlexNodes" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="eidss.model.Model.FlexibleForms.Helpers" %>
<%@ Import Namespace="eidss.webclient.Areas.FlexForms.Helpers" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="eidss.model.Enums" %>
<%@ Import Namespace="bv.common.Core" %>
<%@ Import Namespace="eidss.webclient.Utils" %>

<%
    var sectionTemplate = Model.GetSectionTemplate();
    var sectionDataTable = Model.GetDataTableForSectionTable();
    var rowWidth = sectionDataTable.Columns.Cast<DataColumn>().Sum(column => HelperFunctions.GetColumnWidth(column));
    Model.SortRecursive();

    if (!Model.FFModel.IsSummary && !sectionTemplate.IsFixedStubSection) 
    {
%> 
    <div class="sectionName">
        <%=sectionTemplate.NationalName%>
    </div>
    <%
    }   

    var idObservation = Model.FFModel.CurrentObservation.HasValue ? Model.FFModel.CurrentObservation.Value : 0;
    var gridName = String.Format("idfsSection_{0}", sectionTemplate.idfsSection);
    string toolBar;
    if (!sectionTemplate.IsFixedStubSection && !Model.FFModel.ReadOnly)
    {
        var toolBarTemplate = new StringBuilder();
        toolBarTemplate.AppendFormat("<a href='javascript:EditFFGridRow(\"{0}\", \"true\", \"{1}\")' class='t-grid-action t-button t-button-icon'>" +
                                     "<span>{2}</span></a>", gridName, sectionTemplate.NationalName, Translator.GetMessageString("Add"));
        toolBarTemplate.AppendFormat("<a id='{0}' href='javascript:EditFFGridRow(\"{1}\", \"false\", \"{2}\")' class='t-grid-action t-button t-button-icon'>" +
                                     "<span>{3}</span></a>", "btEdit_" + gridName, gridName, sectionTemplate.NationalName, Translator.GetMessageString("Edit"));
        toolBarTemplate.AppendFormat("<a id='{0}' href='javascript:CopyFFGridRow(\"{1}\")' class='t-grid-action t-button t-button-icon'>" +
                                     "<span>{2}</span></a>", "btCopy_" + gridName, gridName, Translator.GetMessageString("Copy"));
        toolBarTemplate.AppendFormat("<a id='{0}' href='javascript:DeleteFFGridRow(\"{1}\")' class='t-grid-action t-button t-button-icon'>" +
                                     "<span>{2}</span></a>", "btDelete_" + gridName, gridName, Translator.GetMessageString("Delete"));
        toolBar = toolBarTemplate.ToString();
    }
    else
    {
        toolBar = "<div></div>";
    }

    %>
    <div>
    <%
    
    Html.Telerik().Grid(sectionDataTable)
    .Name(gridName)
    .Columns((columns =>{
                  columns.Template(row =>
                    {%>                          
                        <table style="width:<%=rowWidth%>px" idfrow="<%=Convert.ToInt64(row["idfRow"]) %>">
                            <tr idfrow="<%=Convert.ToInt64(row["idfRow"]) %>">
                            <%
                            var i = 0;
                            foreach (DataColumn column in sectionDataTable.Columns)
                            {
                                i++;
                                
                                var width = HelperFunctions.GetColumnWidth(column);
                                var idfsParameter = HelperFunctions.GetColumnParameter(column);
                                var columnName = column.ColumnName;
                                
                                if (idfsParameter == 0) continue;
                                var paramKey = HelperFunctions.GetParameterKey(idObservation, idfsParameter,
                                                                               Convert.ToInt64(row["idfRow"]));
                                
                                if (i == sectionDataTable.Columns.Count - 1)
                                {
                                    width -= 20;
                                }

                                //определяем тип параметра
                                var parameter = Model.FFModel.CurrentTemplate.ParameterTemplates.FirstOrDefault(p => p.idfsParameter == idfsParameter);
                            %>
                                <td style="width:<%=width%>px;">
                                <% 
                                   if (!HelperFunctions.IsStubColumn(column) && !Model.FFModel.ReadOnly && !Model.FFModel.IsSummary && sectionTemplate.IsFixedStubSection)
                                   {
                                   %>   
                                        <div class="tdFfContainer">
                                            <%
                                              if (parameter != null)
                                              {
                                                  var minValue = -99000000;
                                                  const int maxValue = 99000000;
                                                  var typeControl = 2; //0-NumericTextBox, 1-IntegerTextBox, 2-String

                                                  switch (parameter.ParameterType)
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
                                                      if (!Utils.IsEmpty(row[columnName])) valueDouble = Convert.ToDouble(row[columnName]);
                                                      %><%= Html.Telerik().NumericTextBox()
                                                            .Name(paramKey)
                                                            .EmptyMessage(String.Empty)
                                                            .DecimalSeparator(CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator)
                                                            .Spinners(false)
                                                            .MinValue(minValue)
                                                            .MaxValue(maxValue)
                                                            .NumberGroupSeparator(String.Empty)
                                                            .HtmlAttributes("style=\"width: 100%!important;\"")
                                                            .Value(valueDouble)
                                                            %><%
                                                  }
                                                  else if (typeControl == 1)
                                                  {
                                                      int? valueInt = null;
                                                      if (!Utils.IsEmpty(row[columnName])) valueInt = Convert.ToInt32(row[columnName]);

                                                      if (parameter.ParameterType.Equals(FFParameterTypes.NumericNatural))
                                                      {
                                                          %><%= Html.Telerik().NumericTextBox<int>()
                                                                .Name(paramKey)
                                                                .EmptyMessage(String.Empty)
                                                                .Spinners(false)
                                                                .MinValue(minValue)
                                                                .MaxValue(maxValue)
                                                                .NumberGroupSeparator(String.Empty)
                                                                .HtmlAttributes("style=\"width: 100%!important;\"")
                                                                .DecimalDigits(0)
                                                                .Value(valueInt)
                                                                %><%
                                                      } 
                                                      else if (parameter.ParameterType.Equals(FFParameterTypes.NumericPositive))
                                                      {
                                                          %><%= Html.Telerik().NumericTextBox<decimal>()
                                                                .Name(paramKey)
                                                                .EmptyMessage(String.Empty)
                                                                .Spinners(false)
                                                                .MinValue(minValue)
                                                                .MaxValue(maxValue)
                                                                .NumberGroupSeparator(String.Empty)
                                                                .HtmlAttributes("style=\"width: 100%!important;\"")
                                                                .DecimalDigits(2)
                                                                .Value(valueInt)
                                                                %><%
                                                      }
                                                  }
                                                  else if (typeControl == 2)
                                                  {
                                                      %>
                                                      <div class='tdContainer'>
                                                          <%= Html.TextBox(paramKey, row[columnName], "style=\"width: 100%!important;\"")%>
                                                      </div>
                                                      <%
                                                  }
                                              }
                                              %>
                                        </div>
                                   <%}
                                   else if (Model.FFModel.ReadOnly) 
                                   {%>   
                                        <span class="readonlyFfCell">
                                            <%=row[column.ColumnName]%>
                                        </span>
                                   <%}
                                   else %><%=row[column.ColumnName]%>
                               </td>
                            <%
                            }
                            %>                               
                            </tr>
                        </table>
                        <%
                        })
                        .HeaderTemplate(() => {%>
                                    <%=WebGridHelper.GetHeader(Model)%>                               
                            <%});
                }))
                .Scrollable()
                .DataKeys(keys => keys.Add(c => c.Row["idfRow"]))
                .Selectable(x=>x.Enabled(!sectionTemplate.IsFixedStubSection))
                .ToolBar(tb=>tb.Template(toolBar))
                .HtmlAttributes(new { @class = "ffGrid" })
                .Footer(false)
                .ClientEvents(events => events
                    .OnRowSelect(sectionTemplate.IsFixedStubSection ? "bvGridNothing" : "onFFGridRowSelected")
                    .OnLoad(sectionTemplate.IsFixedStubSection ? "bvGridNothing" : "function(e) { SelectFirstFFGridRow('" + gridName + "') }"))
                .Render();
    %>    
    </div>
    
