<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Schema.VetCaseSample.VetCaseSampleGridModelList>" %>

<%@ Import Namespace="eidss.model.Schema" %>
<%@ Import Namespace="eidss.webclient.Utils" %>

<%Html.BvGrid<VetCaseSample.VetCaseSampleGridModel, VetCaseSample.VetCaseSampleGridModelList>((string)ViewData["SampleName"], Model, "detailsGrid",
    @"function(e){        
        var url = GetUrlPrefixLanguage() + 'LabSample/VetCaseSamplePicker?key=" + Model.ListKey + "&name=" + (string)ViewData["SampleName"] + @"&id=';
        OpenGridEditWindow(e, url, 630, 420, EIDSS.BvMessages['titleSampleDetails']);
    }", null,
    (bool)ViewData["IsReadOnly"], false, false, !(bool)ViewData["IsReadOnly"], false, (string)ViewData["ExcludeColumns"])
        .Render();
    %>
