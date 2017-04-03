<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Schema.AsDisease.AsDiseaseGridModelList>" %>

<%@ Import Namespace="eidss.model.Schema" %>
<%@ Import Namespace="eidss.webclient.Utils" %>
<script language="javascript" type="text/javascript">
    function moveItem(link, name) {
        link = getFullUrlByGridName(link, name);
        $.ajax({
            url: link,
            cache: false,
            dataType: "json",
            type: "GET",
            success: function (data) {
                gridItemAdded(name);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(jqXHR.status);
            }
        });
    }
</script>
<%Html.BvGrid<AsDisease.AsDiseaseGridModel, AsDisease.AsDiseaseGridModelList>(ViewData["name"].ToString(), Model, "detailsGrid", null, null, (bool)ViewData["IsReadOnly"], true, false)
        .ToolBar(toolBar =>                                                                
            toolBar.Template(() =>
            {
                %>
                    <a href='#' class='t-grid-action t-button t-button-icon t-grid-delete'><span><%=Translator.GetMessageString("Delete")%></span></a>
                    
                    <a href="javascript:<%=String.Format("moveItem('{0}', '{1}');", 
                        Url.Action("MoveItem", "Disease", new RouteValueDictionary { { "area", "ActiveSurveillence" }, { "key", ViewData["root"] }, { "name", ViewData["name"] },  {"idfAsDisease", "*editkey*"}, {"moveDirection", "1"}  }),
                        ViewData["name"])%>" class='t-grid-action t-button t-button-icon'><span><%=Translator.GetMessageString("Down")%></span></a> 
                        
                    <a href="javascript:<%=String.Format("moveItem('{0}', '{1}');", 
                        Url.Action("MoveItem", "Disease", new RouteValueDictionary { { "area", "ActiveSurveillence" }, { "key", ViewData["root"] }, { "name", ViewData["name"] },  {"idfAsDisease", "*editkey*"}, {"moveDirection", "-1"}  }),
                        ViewData["name"])%>" class='t-grid-action t-button t-button-icon'><span><%=Translator.GetMessageString("Up")%></span></a> 
                        
                    <a href="javascript:<%=String.Format("addNewItem('{0}', '{1}', 'Add Disease', 300);", Url.Action("Details", "Disease", 
                        new RouteValueDictionary { { "area", "ActiveSurveillence" }, { "key", ViewData["root"] }, { "name", ViewData["name"] }, {"idfAsDisease", "0"} }),ViewData["name"])%>" 
                        class='t-grid-action t-button t-button-icon t-state-enabled'><span><%=Translator.GetMessageString("strNew")%></span></a> 
                <%
            })
        )                  
    .Sortable(sorting=>sorting.OrderBy(ordering=>ordering.Add("intOrder")))
        .Render();       %> 

