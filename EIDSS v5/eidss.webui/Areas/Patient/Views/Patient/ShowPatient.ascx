<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Schema.Patient>" %>
<%@ Import Namespace="eidss.webui.Utils" %>
<%@ Import Namespace="eidss.webui.Areas.Address" %>

<table width="100%">
    <tr>
        <td colspan="6">
<h3>Demographic Information</h3>
        </td>
    </tr>
    <tr>
        <td>
<%=Html.LabelFor(m => m.strLastName)%>
        </td>
        <td>
<%=Html.BvEditbox(Model, "strLastName")%>
        </td>
        <td>
<%=Html.LabelFor(m => m.strFirstName)%>
        </td>
        <td>
<%=Html.BvEditbox(Model, "strFirstName")%>
        </td>
        <td>
<%=Html.LabelFor(m => m.strSecondName)%>
        </td>
        <td>
<%=Html.BvEditbox(Model, "strSecondName")%>
        </td>
    </tr>
    <tr>
        <td>
<%=Html.LabelFor(m => m.datDateofBirth)%>
        </td>
        <td>
<%=Html.BvDatebox(Model, "datDateofBirth")%>
        </td>
        <td>
        </td>
        <td>
        </td>
        <td>
<%=Html.LabelFor(m => m.Gender)%>
        </td>
        <td>
<%=Html.BvCombobox(Model, "Gender")%>
        </td>
    </tr>
    <tr>
        <td colspan="6">
<h4>Current Residence:</h4>
        </td>
    </tr>
    <tr>
        <td colspan="6">
<%=Html.Address(Model.idfCase.Value, Model.CurrentResidenceAddress)%>
        </td>
    </tr>
    <tr>
        <td>
<%=Html.LabelFor(m => m.strHomePhone)%>
        </td>
        <td>
<%=Html.BvEditbox(Model, "strHomePhone")%>
        </td>
        <td>
<%=Html.LabelFor(m => m.OccupationType)%>
        </td>
        <td>
<%=Html.BvCombobox(Model, "OccupationType")%>
        </td>
        <td>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
<%=Html.LabelFor(m => m.strEmployerName)%>
        </td>
        <td>
<%=Html.BvEditbox(Model, "strEmployerName")%>
        </td>
        <td colspan="4">
[Address of Employer]
        </td>
    </tr>
</table>
