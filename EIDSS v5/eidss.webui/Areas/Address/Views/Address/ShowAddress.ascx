<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Schema.Address>" %>
<%@ Import Namespace="eidss.webui.Utils" %>

<table>
    <!-- tr>
        <td>
<Html.LabelFor(m => m.Country)>
        </td>
        <td>
<Html.BvCombobox(Model, "Country", 200)
    .ClientEvents(e => e.OnChange("onCountryChanged" + Model.idfGeoLocation))>
        </td>
    </tr -->
    <tr>
        <td>
<%=Html.LabelFor(m => m.Region)%>
        </td>
        <td>
<%=Html.BvCombobox(Model, "Region", null, false, "onRegionChanged")
        .ClientEvents(events => events.OnChange("onRegionChanged"))
    .DataBinding(b => b.Ajax()
        .Select("SelectRegion", "Address", new RouteValueDictionary { { "area", "Address" }, { "idfGeoLocation", Model.idfGeoLocation } }))%>
        </td>
        <td>
<%=Html.LabelFor(m => m.Rayon)%>
        </td>
        <td>
<%=Html.BvCombobox(Model, "Rayon", null, false, "onRayonChanged")
    .DataBinding(b => b.Ajax()
        .Select("SelectRayon", "Address", new RouteValueDictionary { { "area", "Address" }, { "idfGeoLocation", Model.idfGeoLocation } }))%>
        </td>
        <td>
<%=Html.LabelFor(m => m.Settlement)%>
        </td>
        <td>
<%=Html.BvCombobox(Model, "Settlement", null, false, "onSettlementChanged")
    .DataBinding(b => b.Ajax()
        .Select("SelectSettlement", "Address", new RouteValueDictionary { { "area", "Address" }, { "idfGeoLocation", Model.idfGeoLocation } }))
    %>
        </td>
    </tr>
    <tr>
        <td>
<%=Html.LabelFor(m => m.strStreetName) %>
        </td>
        <td>
<%=Html.BvCombobox(Model, "Street", null, false)
    .DataBinding(b => b.Ajax()
        .Select("SelectStreet", "Address", new RouteValueDictionary { { "area", "Address" }, { "idfGeoLocation", Model.idfGeoLocation } }))
    %>
        </td>
        <td>
<%=Html.LabelFor(m => m.strPostCode) %>
        </td>
        <td>
<%=Html.BvCombobox(Model, "PostCode", null, false)
    .DataBinding(b => b.Ajax()
        .Select("SelectPostCode", "Address", new RouteValueDictionary { { "area", "Address" }, { "idfGeoLocation", Model.idfGeoLocation } }))
    %>
        </td>
        <td>
<%=Html.LabelFor(m => m.strBuilding) %>
        </td>
        <td>
<%=Html.BvEditbox(Model, "strBuilding")%>
<%=Html.BvEditbox(Model, "strApartment")%>
<%=Html.BvEditbox(Model, "strHouse")%>
        </td>
    </tr>
</table>