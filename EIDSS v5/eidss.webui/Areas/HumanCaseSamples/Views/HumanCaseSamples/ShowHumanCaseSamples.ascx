<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Schema.HumanCaseSample.HumanCaseSampleGridModelList>" %>
<%@ Import Namespace="eidss.model.Schema" %>

<table>
    <tr>
        <td>
<%=Html.Telerik().Grid<HumanCaseSample.HumanCaseSampleGridModel>()
        .Name("SamplesGrid")
        .ToolBar(commands => commands.Insert())
        .DataKeys(keys => keys.Add(c => c.idfMaterial))
        .DataBinding(dataBinding =>
        {
            dataBinding.Ajax()
                .Select("_SamplesBinding", "HumanCaseSamples", new RouteValueDictionary { { "area", "HumanCaseSamples" }, { "idfCase", Model.idfKey } })
                .Insert("_InsertSample", "HumanCaseSamples", new RouteValueDictionary { { "area", "HumanCaseSamples" }, { "idfCase", Model.idfKey } })
                .Update("_UpdateSample", "HumanCaseSamples", new RouteValueDictionary { { "area", "HumanCaseSamples" }, { "idfCase", Model.idfKey } })
                .Delete("_DeleteSample", "HumanCaseSamples", new RouteValueDictionary { { "area", "HumanCaseSamples" }, { "idfCase", Model.idfKey } });
        })
        .Columns(columns =>
        {
            columns.Bound(o => o.SampleTypeName).Width(250).Title("Type");
            columns.Bound(o => o.datFieldCollectionDate).Width(100).Title("Date");
            columns.Bound(o => o.strSpecimenName).Width(100).Title("Name");
            columns.Command(c =>
            {
                c.Edit();
                c.Delete();
            }).Title("Commands").Width(200);
        }).ClientEvents(events => events.OnEdit("onEditSamplesGrid"))
        .Sortable()
%>
        </td>
    </tr>
</table>

<script type="text/javascript">
    function onEditSamplesGrid(e) 
    {
        $(e.form).find('#idfsSpecimenType').data('tDropDownList').select(function (dataItem) 
        {
            if (e.dataItem == null) return false;
            return dataItem.Value == e.dataItem['idfsSpecimenType'];
        });
    }
</script>
