<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Schema.AsSessionTableViewItem.AsSessionTableViewItemGridModelList>" %>

<%@ Import Namespace="eidss.model.Schema" %>
<%@ Import Namespace="eidss.webclient.Utils" %>
<script type="text/javascript" language="javascript">
    function addCopy(link, name) {
        var key = $('#<%= ViewData["name"]%> tr.t-state-selected').find("[name='ItemKey']").attr("value");
        var num = $("#NumberOfCopies").data("tTextBox").value();
        if (!key) {
            ShowEidssErrorNotification("No sample selected.", DoNothing);
            return;
        }
        if (!num)
            num = 1;

        $.ajax({
            url: link,
            cache: false,
            dataType: "json",
            data: {
                idfSample: key,
                number: num
            },
            type: "GET",
            success: function (data) {
                gridItemAdded(name);
                updateSamplesTotals();
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(jqXHR.status);
            }
        });
    }

    function onGridDataBound(e) {
        updateSamplesTotals();
        bvGridOnDataBound(e, 'false');
    }
    function updateSamplesTotals() {
        $.ajax({
            url: '<%: Url.Action("GetTotals", "Samples", new RouteValueDictionary { { "root", ViewData["root"] } })%>',
            cache: false,
            dataType: "json",
            type: "GET",
            success: function (data) {
                for (d in data) {
                    $(d).val(data[d]);                    
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(jqXHR.status);
            }
        });        
    }
     
</script>

<%Html.BvGrid<AsSessionTableViewItem.AsSessionTableViewItemGridModel, AsSessionTableViewItem.AsSessionTableViewItemGridModelList>(ViewData["name"].ToString(), Model, "detailsGrid", null, null, (bool)ViewData["IsReadOnly"], true, false, true, false, null, "onGridDataBound")
        .ToolBar(toolBar =>                                                                
            toolBar.Template(() =>
            {
                %>                            
                    <a href='#' class='t-grid-action t-button t-button-icon t-grid-delete'><span><%=Translator.GetMessageString("Delete")%></span></a>       
                                       
                    <div class="tToolBarLeftPanel">                                
                        <% =Html.Telerik().NumericTextBox().Name("NumberOfCopies").EmptyMessage("").DecimalDigits(0).MinValue(1).MaxValue(100).HtmlAttributes(new { @class = "small" }) %>  
                    
                        <a href="javascript:<%=String.Format("addCopy('{0}','{1}')",
                            Url.Action("Copy", "Samples", new RouteValueDictionary { { "area", "ActiveSurveillence" }, { "root", ViewData["root"] }, { "name", ViewData["name"] } })
                            , ViewData["name"])%>" class='t-grid-action t-button t-button-icon t-state-enabled'><span><%=Translator.GetMessageString("Copy")%></span></a> 
                        
                    </div>    
                    
                    <a href="javascript:<%=String.Format("editGridItemInNewWindow('{0}','{1}');", 
                            Url.Action("Details", "Samples", new RouteValueDictionary { { "area", "ActiveSurveillence" }, { "root", ViewData["root"] }, { "name", ViewData["name"] }, { "idfTableViewItem", "*editkey*" } }),
                        ViewData["name"] )%>" class='t-grid-action t-button t-button-icon t-grid-bv-edit'><span><%=Translator.GetMessageString("Edit")%></span></a> 
                    
                    <a href="javascript:<%=String.Format("addNewItemInNewWindow('{0}', '{1}');", Url.Action("Details", "Samples", 
                        new RouteValueDictionary { { "area", "ActiveSurveillence" }, { "root", ViewData["root"] }, { "name", ViewData["name"] }, {"idfTableViewItem", "0"} }),ViewData["name"])%>" 
                        class='t-grid-action t-button t-button-icon t-state-enabled'><span><%=Translator.GetMessageString("strNew")%></span></a>                          
                    
                <%
            })
        )
        .Groupable()
        .Render();                  %> 
