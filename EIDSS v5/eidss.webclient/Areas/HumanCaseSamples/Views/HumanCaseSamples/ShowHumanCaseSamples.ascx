<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Schema.HumanCaseSample.HumanCaseSampleGridModelList>" %>

<%@ Import Namespace="eidss.model.Schema" %>
<%@ Import Namespace="eidss.webclient.Utils" %>

<!--script type="text/javascript">
    function onEditSamplesGrid(e) {
        $(e.form).find('#idfsSpecimenType').data('tDropDownList').select(function (dataItem) {
            if (e.dataItem == null) return false;
            return dataItem.Value == e.dataItem['idfsSpecimenType'];
        });
    }
</script-->

<%Html.BvGrid<HumanCaseSample.HumanCaseSampleGridModel, HumanCaseSample.HumanCaseSampleGridModelList>((string)ViewData["SampleName"], Model, "detailsGrid",
    @"function(e){        
        var url = GetUrlPrefixLanguage() + 'LabSample/HumanCaseSamplePicker?key=" + Model.ListKey + "&name=" + (string)ViewData["SampleName"] + @"&id=';
        OpenGridEditWindow(e, url, 600, 420, EIDSS.BvMessages['titleSampleDetails']);
    }", null, 
    (bool)ViewData["IsReadOnly"], false)
        .Render();
    %>
