<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Schema.Address>" %>
<%@ Import Namespace="eidss.webclient.Utils" %>

<input id='<%=Model.ObjectName%>' name='<%=Model.ObjectName%>' type='hidden' value='<%=Model.Key%>' />
<table>    
    <tr>
        <td class="small">
            <%=Html.LabelFor(m => m.idfsRegion)%>
        </td>
        <td class="medium">        
            <%=Html.BvEditbox(Model, "strReadOnlyRegion")%>                
        </td>
        <td class="small">
            <%=Html.LabelFor(m => m.idfsRayon)%>
        </td>
        <td class="medium">
            <%=Html.BvEditbox(Model, "strReadOnlyRayon")%> 
        </td>
        <td class="small">
            <%=Html.LabelFor(m => m.idfsSettlement)%>
        </td>
        <td class="medium">
            <%=Html.BvEditbox(Model, "strReadOnlySettlement")%>        
        </td>
        <td></td>
    </tr>
    <tr>
        <td>
            <%=Html.LabelFor(m => m.strStreetName) %>
        </td>
        <td>
            <%=Html.BvEditbox(Model, "strReadOnlyStreet")%>              
        </td>
        <td>
            <%=Html.LabelFor(m => m.strPostCode) %>
        </td>
        <td>
            <%=Html.BvEditbox(Model, "strReadOnlyPostCode")%>              
        </td>
        <td>
            <%=Html.LabelFor(m => m.strBuilding)%>/<%=Html.LabelFor(m => m.strHouse)%>/<%=Html.LabelFor(m => m.strApartment)%>
        </td>
        <td class="noIndent">
            <table>
                <tr>
                    <td>
                        <%=Html.BvEditbox(Model, "strReadOnlyBuilding")%>      
                    </td>
                    <td>
                        <%=Html.BvEditbox(Model, "strReadOnlyHouse")%>   
                    </td>
                    <td>
                        <%=Html.BvEditbox(Model, "strReadOnlyApartment")%>   
                    </td>                    
                </tr>
            </table>
        </td>
        <td></td>
    </tr>
</table>