<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Schema.AsMonitoringSession.AsMonitoringSessionGridModelList>" %>

<%@ Import Namespace="eidss.model.Schema" %>
<%@ Import Namespace="eidss.webclient.Utils" %>

<script language="javascript" type="text/javascript">

    function onASSessionPickerSelect() {        
        var id = GetSelectedItemId();      
        $.ajax({
            url: '<%= Url.Action("SelectSession", "Session", new RouteValueDictionary { { "area", "ActiveSurveillence" }})%>',
            data: {
                root: <%=ViewData["root"] %>,
                idfSession : id
            },
            cache: false,
            dataType: "json",
            type: "GET",
            success: function (data) {
                if (data == "ok") {
                    var sessionlist = $('div[id$="Sessions"]');
                    gridItemAdded(sessionlist[0].id);
                    CloseMessageWindow();
                }
                else {                    
                    ShowEidssErrorNotification(data, function () { });
                }
            },
            error : function(data) {
                ShowEidssErrorNotification(EIDSS.BvMessages['ErrWebTemporarilyUnavailableFunction'], DoNothing);
            }
        });        
    }
   
</script>
<table></table>
<%Html.BvGrid<AsMonitoringSession.AsMonitoringSessionGridModel, AsMonitoringSession.AsMonitoringSessionGridModelList>(ViewData["name"].ToString(),
      Model, "detailsGrid", null, null, (bool)ViewData["IsReadOnly"], true, false, onDataBound: "onSessionsGridDataBound")
      .ToolBar(toolBar =>                                                                
            toolBar.Template(() =>
            {
                %>                                                
                    <a id='btViewDetails' class="t-grid-action t-button t-button-icon t-grid-bv-edit"
                            href="javascript:<%=String.Format("editGridItemInNewWindow('{0}','{1}');", 
                                                    Url.Action("DetailsNonPostable", "ASSession", new RouteValueDictionary { { "area", null }, {"idfCampaign", ViewData["root"]}, { "idfSession", "*editkey*" } }),
                                                    ViewData["name"] )%>">
                            <span><%=Translator.GetMessageString("btViewDetails")%></span></a> 
                    
                    <a id='btRemove' class="t-grid-action t-button t-button-icon t-grid-bv-edit"
                            href="javascript:<%=String.Format("TryRemoveSession('{0}', '{1}');", 
                                                    Url.Action("RemoveSession", "AsCampaign", new RouteValueDictionary { { "area", null }, { "idfCampaign", ViewData["root"] }, {"idfSession", "*editkey*"} }),
                                                    ViewData["name"])%>" >
                            <span><%=Translator.GetMessageString("btRemoveASSession")%></span></a>                           

                    <a id='btSelect' class="t-grid-action t-button t-button-icon t-grid-bv-edit"                        
                        href="javascript:ShowASSessionPicker('<%=Url.Action("ASSessionPicker", "ASSession",  new RouteValueDictionary { { "area", null }}) %>');" >
                            <span><%=Translator.GetMessageString("btSelectASSession")%></span></a>                           
                    
                    <a id='btNew' class="t-grid-action t-button t-button-icon t-state-enabled"                        
                        href="javascript:<%=String.Format("CreateNewSession('{0}', '{1}');", 
                                                    Url.Action("DetailsNonPostable", "ASSession", new RouteValueDictionary { { "area", null }, {"idfCampaign", ViewData["root"]}, { "idfSession", "0" } }),
                                                    ViewData["name"])%>" >
                            <span><%=Translator.GetMessageString("btCreateASSession")%></span></a>
                                                                               
                <%
            })
        )
      .Render();%> 
        
