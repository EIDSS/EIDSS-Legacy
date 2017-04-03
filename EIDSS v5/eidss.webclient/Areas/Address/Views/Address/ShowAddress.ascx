<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Schema.Address>" %>
<%@ Import Namespace="eidss.webclient.Utils" %>
<%@ Import Namespace="bv.model.Model.Core" %>
<input id='<%=Model.ObjectName%>' name='<%=Model.ObjectName%>' type='hidden' value='<%=Model.Key%>' />
<table>
    <%if((bool)ViewBag.IsCountryFieldVisible)
    {%>
        <tr>
            <td class="small">
                <%=Html.LabelFor(m => m.idfsCountry)%>
            </td>
            <td class="medium">
                <%=Html.BvCombobox(Model, "Country", true, "onCountryChanged", readOnly: ((IObject)Model).IsHiddenPersonalData("Street"))%>
            </td>
            <%if ((bool)ViewBag.IsForeignAddressFieldVisible)
            {%>
                <td class="small">
                    <%=Html.BvLabel(Model, "strForeignAddress")%>
                </td>
                <td>
                    <%=Html.BvEditbox(Model, "strForeignAddress", true)%>
                </td>
                <td colspan="3">
                </td>
            <%}
            else
            {%>    
                <td colspan="5">
                </td>
            <%}%>    
        </tr>
    <%}%>    
    <tr>
        <td class="small">
            <%=Html.LabelFor(m => m.idfsRegion)%>
        </td>
        <td class="medium">
            <%=Html.BvCombobox(Model, "Region", false, "onRegionChanged", readOnly: ((IObject)Model).IsHiddenPersonalData("Street") )
                .DataBinding(b => b.Ajax()
                .Select("SelectRegion", "Address", new RouteValueDictionary { { "area", "Address" }, { "idfGeoLocation", Model.idfGeoLocation } }))
            %>
        </td>
        <td class="small">
            <%=Html.LabelFor(m => m.idfsRayon)%>
        </td>
        <td class="medium">
            <%=Html.BvCombobox(Model, "Rayon", false, "onRayonChanged", readOnly: ((IObject)Model).IsHiddenPersonalData("Street"))
                .DataBinding(b => b.Ajax()
                .Select("SelectRayon", "Address", new RouteValueDictionary { { "area", "Address" }, { "idfGeoLocation", Model.idfGeoLocation } }))
            %>
        </td>
        <td class="small">
            <%=Html.LabelFor(m => m.idfsSettlement)%>
        </td>
        <td class="medium">
            <% if (((bv.model.Model.Core.IObject)Model).IsHiddenPersonalData("Settlement"))
                { %>
                <%=Html.BvHiddenPersonalData("Settlement")%>
            <% }
                else {%>
                <%=Html.BvCombobox(Model, "Settlement", false, "onSettlementChanged", readOnly: ((IObject)Model).IsHiddenPersonalData("Street"))
                    .DataBinding(b => b.Ajax()
                    .Select("SelectSettlement", "Address", new RouteValueDictionary { { "area", "Address" }, { "idfGeoLocation", Model.idfGeoLocation } }))%>
             <%}
                %>
        </td>
        <td></td>
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
             <%}
                %>
        </td>
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
             <%}
                %>
        </td>
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
        <td></td>
    </tr>
    <%if ((bool)ViewBag.IsCoordinatesFieldsVisible)
    {%>
        <tr>
            <td>
                <%=Html.LabelFor(m => m.dblLongitude)%><br/>(&#177;&#35;.&#35;&#35;&#35;&#35;&#35;&#176;)
            </td>
            <td>
                <%=Html.BvNumeric(Model, "dblLongitude", 5, -180, 180)%>
            </td>
            <td>
                <%=Html.LabelFor(m => m.dblLatitude)%><br/>(&#177;&#35;.&#35;&#35;&#35;&#35;&#35;&#176;)
            </td>
            <td>
                <%=Html.BvNumeric(Model, "dblLatitude", 5, -90, 90)%>
            </td>
            <td>
            <%if (!Model.IsHiddenPersonalData("dblLongitude"))
              {%>
                <button class="magnifierButton" onclick="ShowMap('<%=Model.ObjectIdent%>');" type="button">
                    <img src="<%=Url.Content(VirtualPathUtility.ToAbsolute("~/Content/Images/Map.jpg"))%>" alt="Map" />
                </button>
                <%--<input type="button" class="coloredButton" value="Map" onclick="ShowMap('<%=Model.ObjectIdent%>');"/>--%>
            <%} %>
            </td>
            <td colspan="2">
            </td>
        </tr>
    <%}%>    
</table>