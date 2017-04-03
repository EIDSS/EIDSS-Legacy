<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Schema.Address>" %>
<%@ Import Namespace="eidss.webclient.Utils" %>
<%@ Import Namespace="bv.model.Model.Core" %>

<input id='<%=Model.ObjectName%>' name='<%=Model.ObjectName%>' type='hidden' value='<%=Model.Key%>' />
<table class="autoWidth">  
 <%if((bool)ViewBag.IsCountryFieldVisible)
    {%>
        <tr>
            <td class="medium">
                <%=Html.LabelFor(m => m.idfsCountry)%>
            </td>
            <td class="xlarge">
                <%=Html.BvCombobox(Model, "Country", true, "onCountryChanged", readOnly: ((IObject)Model).IsHiddenPersonalData("Street"))%>
            </td>           
        </tr>
       <%-- <tr>
                <td class="medium">
                    <%=Html.BvLabel(Model, "strForeignAddress")%>
                </td>
                <td  class="xlarge">
                    <%=Html.BvEditbox(Model, "strForeignAddress", true)%>
                </td>
        </tr>--%>

    <%}%>     
    <tr>
        <td class="medium">
            <%=Html.LabelFor(m => m.idfsRegion)%>
        </td>
        <td class="xlarge">
            <%=Html.BvCombobox(Model, "Region", false, "onRegionChanged", readOnly: ((IObject)Model).IsHiddenPersonalData("Street"))
                .ClientEvents(events => events.OnChange("onRegionChanged"))
                .DataBinding(b => b.Ajax()
                .Select("SelectRegion", "Address", new RouteValueDictionary { { "area", "Address" }, { "idfGeoLocation", Model.idfGeoLocation } }))
            %>
        </td>
    </tr>
    <tr>
        <td>
            <%=Html.LabelFor(m => m.idfsRayon)%>
        </td>
        <td>
            <%=Html.BvCombobox(Model, "Rayon", false, "onRayonChanged", readOnly: ((IObject)Model).IsHiddenPersonalData("Street"))
                .DataBinding(b => b.Ajax()
                .Select("SelectRayon", "Address", new RouteValueDictionary { { "area", "Address" }, { "idfGeoLocation", Model.idfGeoLocation } }))
            %>
        </td>
    </tr>
    <tr>
        <td>
            <%=Html.LabelFor(m => m.idfsSettlement)%>
        </td>
        <td>
        <% if (((bv.model.Model.Core.IObject)Model).IsHiddenPersonalData("Settlement"))
                { %>
                <%=Html.BvHiddenPersonalData("Settlement")%>
            <% }
                else {%>
            <%=Html.BvCombobox(Model, "Settlement", false, "onSettlementChanged", readOnly: ((IObject)Model).IsHiddenPersonalData("Street"))
                .DataBinding(b => b.Ajax()
                .Select("SelectSettlement", "Address", new RouteValueDictionary { { "area", "Address" }, { "idfGeoLocation", Model.idfGeoLocation } }))
            %>
           <%} %>
        </td>
    </tr>
    <tr>
        <td>
            <%=Html.LabelFor(m => m.strStreetName) %>
        </td>
        <td>
            <% if (((bv.model.Model.Core.IObject)Model).IsHiddenPersonalData("Street"))
            { %>
                <%=Html.BvHiddenPersonalData("Street")%>
            <% }
            else {%>
                <%=Html.BvCombobox(Model, "Street", false)
                    .DataBinding(b => b.Ajax()
                    .Select("SelectStreet", "Address", new RouteValueDictionary { { "area", "Address" }, { "idfGeoLocation", Model.idfGeoLocation } }))
            %>
            <%} %>
        </td>
    </tr>
    <tr>
        <td>
            <%=Html.LabelFor(m => m.strPostCode) %>
        </td>
        <td>
            <% if (((bv.model.Model.Core.IObject)Model).IsHiddenPersonalData("PostCode"))
                { %>
                <%=Html.BvHiddenPersonalData("PostCode")%>
            <% }
                else {%>
            <%=Html.BvCombobox(Model, "PostCode", false)
                .DataBinding(b => b.Ajax()
                .Select("SelectPostCode", "Address", new RouteValueDictionary { { "area", "Address" }, { "idfGeoLocation", Model.idfGeoLocation } }))
            %>
             <%} %>
        </td>
    </tr>
    <tr>
        <td>
            <%=Html.LabelFor(m => m.strBuilding)%>/<%=Html.LabelFor(m => m.strHouse)%>/<%=Html.LabelFor(m => m.strApartment)%>
        </td>
        <td class="noIndent">
            <table>
                <tr>
                    <td>
                        <%=Html.BvEditbox(Model, "strBuilding", true)%>
                    </td>                    
                    <td>
                        <%=Html.BvEditbox(Model, "strHouse", true)%>
                    </td>
                    <td>
                        <%=Html.BvEditbox(Model, "strApartment", true)%>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>

