<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Schema.Address>" %>
<%@ Import Namespace="eidss.webclient.Utils" %>

<input id='<%=Model.ObjectName%>' name='<%=Model.ObjectName%>' type='hidden' value='<%=Model.Key%>' />
<table>
    <tr>
        <td>
            <%=Html.BvEditbox(Model, "strReadOnlyFullName")%>          
        </td>
        <td class="selectButton">
            <input type="button" class="coloredButton" onclick="ShowAddressPicker(<%=Model.idfGeoLocation %>);" value=".." />
        </td>
    </tr>
</table>