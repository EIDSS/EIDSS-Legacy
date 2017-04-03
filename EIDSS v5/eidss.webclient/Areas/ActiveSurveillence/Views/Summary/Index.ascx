<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Schema.AsSessionSummary.AsSessionSummaryGridModelList>" %>

<%@ Import Namespace="eidss.model.Schema" %>
<%@ Import Namespace="eidss.webclient.Utils" %>
<script language="javascript" type="text/javascript">
    function updateTotals() {
        $.ajax({            
            url: '<%: Url.Action("GetTotals", "Summary", new RouteValueDictionary { { "root", ViewData["root"] } })%>',
            cache: false,
            dataType: "json",
            type: "GET",
            success: function (data) {
                for (d in data) {
                    $(d).val(data[d]);
                    //alert(data[d]);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(jqXHR.status);
            }
        });        
    }

</script>
<%Html.BvGrid<AsSessionSummary.AsSessionSummaryGridModel, AsSessionSummary.AsSessionSummaryGridModelList>(ViewData["name"].ToString(), Model, "detailsGrid", null, null, (bool)ViewData["IsReadOnly"], true, false)
        .ToolBar(toolBar =>                                                                
            toolBar.Template(() =>
            {
                %>
                    <a href='#' class='t-grid-action t-button t-button-icon t-grid-delete'><span><%=Translator.GetMessageString("Delete")%></span></a> 
                    
                    <a href="javascript:<%=String.Format("editGridItemInNewWindow('{0}','{1}');", 
                        Url.Action("Details", "Summary", new RouteValueDictionary { { "area", "ActiveSurveillence" }, { "root", ViewData["root"] }, { "name", ViewData["name"] }, { "idfSummary", "*editkey*" } }),
                        ViewData["name"] )%>" class='t-grid-action t-button t-button-icon t-grid-bv-edit'><span><%=Translator.GetMessageString("Edit")%></span></a> 
                    
                    <a href="javascript:<%=String.Format("addNewItemInNewWindow('{0}', '{1}');", Url.Action("Details", "Summary", 
                        new RouteValueDictionary { { "area", "ActiveSurveillence" }, { "root", ViewData["root"] }, { "name", ViewData["name"] }, {"idfSummary", 0 }}),ViewData["name"])%>" 
                        class='t-grid-action t-button t-button-icon t-state-enabled'><span><%=Translator.GetMessageString("strNew")%></span></a>  
                <%
            })
        )                
        .Render();%> 


