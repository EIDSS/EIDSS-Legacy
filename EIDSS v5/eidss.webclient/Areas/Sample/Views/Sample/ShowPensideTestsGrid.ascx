<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Schema.PensideTest.PensideTestGridModelList>" %>

<%@ Import Namespace="eidss.model.Schema" %>
<%@ Import Namespace="eidss.webclient.Utils" %>
        
<%Html.BvGrid<PensideTest.PensideTestGridModel, PensideTest.PensideTestGridModelList>((string)ViewData["PensideTestsName"], Model, "detailsGrid",
@"function(e){
    var path = GetUrlPrefixLanguage() + 'LabSample/PensideTestPicker?key=" + Model.ListKey + "&name=" + (string)ViewData["PensideTestsName"] + @"&id='
    OpenGridEditWindow(e, path, 630, 280, EIDSS.BvMessages['titlePensideTest']);
}",
null,
(bool)ViewData["IsReadOnly"], false, false, !(bool)ViewData["IsReadOnly"], false, (string)ViewData["ExcludeColumns"])
.Render();
%>
     