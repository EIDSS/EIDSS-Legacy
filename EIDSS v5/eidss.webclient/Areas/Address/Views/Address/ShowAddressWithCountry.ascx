<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Schema.Address>" %>
<%@ Import Namespace="eidss.webclient.Utils" %>
<script src='<%=Url.Content("~/Scripts/Address/CommonScript.js")%>' type="text/javascript"></script>
<script src='<%=Url.Content("~/Scripts/Address/Lookups.js")%>' type="text/javascript"></script>
<input id='<%=Model.ObjectName%>' name='<%=Model.ObjectName%>' type='hidden' value='<%=Model.Key%>' />
<table>
    <tr>
        <td class="medium">
            <%=Html.LabelFor(m => m.idfsCountry)%>                    
        </td>
        <td>
                <%=Html.BvReadOnlyEditbox(Model, "strReadOnlyCountry")%>                            
        </td>                            
    </tr >   
     <tr>
        <td class="medium">
            <%=Html.LabelFor(m => m.idfsRegion)%>
        </td>
        <td class="xlarge">
            <%=Html.BvCombobox(Model, "Region", false, "onRegionChanged")
                //.ClientEvents(events => events.OnChange("onRegionChanged"))
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
            <%=Html.BvCombobox(Model, "Rayon", false, "onRayonChanged")
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
            <%=Html.BvCombobox(Model, "Settlement", false, "onSettlementChanged")
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
            <%=Html.BvCombobox(Model, "Street", false)
                .DataBinding(b => b.Ajax()
                .Select("SelectStreet", "Address", new RouteValueDictionary { { "area", "Address" }, { "idfGeoLocation", Model.idfGeoLocation } }))
            %>
        </td>
    </tr>
    <tr>
        <td>
            <%=Html.LabelFor(m => m.strPostCode) %>
        </td>
        <td>
            <%=Html.BvCombobox(Model, "PostCode", false)
                .DataBinding(b => b.Ajax()
                .Select("SelectPostCode", "Address", new RouteValueDictionary { { "area", "Address" }, { "idfGeoLocation", Model.idfGeoLocation } }))
            %>
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
