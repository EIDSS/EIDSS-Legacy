<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Schema.LabSample>" %>
<%@ Import Namespace="eidss.webclient.Utils" %>

<table>
    <tr>
        <td>
            <%=Html.BvEditbox(Model, "strFreezer")%>
        </td>
        <%--  
        <td class="selectButton">
            <input type="button" class="coloredButton" onclick="ShowFreezerPicker(<%=Model.idfContainer %>);" value="..." />
        </td>
        --%>
    </tr>
</table>