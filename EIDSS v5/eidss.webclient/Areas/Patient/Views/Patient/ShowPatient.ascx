<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<eidss.model.Schema.Patient>" %>
<%@ Import Namespace="eidss.webclient.Utils" %>
<%@ Import Namespace="eidss.webclient.Areas.Address" %>
<%@ Import Namespace="eidss.webclient.Utils" %>

     
<input id='<%=Model.ObjectName%>' name='<%=Model.ObjectName%>' type='hidden' value='<%=Model.Key%>' />
<table>    
    <tr>
        <td class="small">
            <%=Translator.GetString("Patient.Name")%>:&nbsp;&nbsp;<%=Translator.GetString("Patient.strLastName")%>
        </td>
        <td class="medium">
            <%=Html.BvEditbox(Model, "strLastName", true)%>
        </td>
        <td class="small">
            <%=Translator.GetString("Patient.strFirstName")%>
        </td>
        <td class="medium">
            <%=Html.BvEditbox(Model, "strFirstName", true)%>
        </td>
        <td class="small">
            <%=Translator.GetString("Patient.strSecondName")%>
        </td>
        <td>
            <%=Html.BvEditbox(Model, "strSecondName", true)%>
        </td>
        <td class="fillAll"></td>
    </tr>
    <tr>
        <td>
            <%=Html.LabelFor(m => m.datDateofBirth)%>
        </td>
        <td>
            <% if (((bv.model.Model.Core.IObject)Model).IsHiddenPersonalData("datDateofBirth"))
                { %>
                <%=Html.BvHiddenPersonalData("datDateofBirth", "**.**.****")%>
            <% }
                else {%>
                <%=Html.BvDatebox(Model, "datDateofBirth")%>
             <%}
                %>            
        </td>
        <%if((bool)ViewBag.IsAgeVisible)
           {
           %>
        <td>
            <%=Translator.GetMessageString("Age")%>
        </td>
        <td class="noIndent">
            <table>
                <tr>
                    <td class="xsmall" style="padding-top:0px">
                        <%=Html.BvNumeric(Model, "intPatientAgeFromCase", 0, 0, 1000, refreshOnLostFocus: true)%>
                    </td>
                    <td style="padding-top:4px">
                    <% if (((bv.model.Model.Core.IObject)Model).IsHiddenPersonalData("HumanAgeType"))
                       { %>
                        <%=Html.BvHiddenPersonalData("HumanAgeType") %>
                    <% }
                       else {%>
                        <%=Html.BvCombobox(Model, "HumanAgeType")%>
                    <%}
                        %>
                    </td>
                </tr>
            </table>
        </td>
        <%}
          else
        {%>
        <td colspan="2"></td>
        <%}
        %>
        <td>
            <%=Html.LabelFor(m => m.idfsHumanGender)%>
        </td>
        <td>
            <% if (((bv.model.Model.Core.IObject)Model).IsHiddenPersonalData("Gender"))
                { %>
                <%=Html.BvHiddenPersonalData("Gender")%>
            <% }
                else {%>
                <%=Html.BvCombobox(Model, "Gender")%>
             <%}
                %>
        </td>
        <td></td>
    </tr>
    <tr>
        <td colspan="7">      
            <%=Translator.GetMessageString("titleCurrentResidence")%>:    
        </td>        
    </tr>
    <tr>
        <td colspan="7" class="noIndent">
            <%=Html.Address(Model.idfCase.HasValue ? Model.idfCase.Value : Model.idfHuman, Model.CurrentResidenceAddress, false, false, false, (bool)ViewBag.IsCoordinatesFieldsVisible)%>
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
            <%=Html.LabelFor(m => m.idfsNationality)%>
        </td>
        <td>
            <%=Html.BvCombobox(Model, "Nationality")%>
        </td>
        <td colspan="3">
        </td>        
    </tr>
    <tr>
        <td colspan="3">
            <%=Html.LabelFor(m => m.strEmployerName)%>
        </td>
        <td colspan="3">
            <%=Html.BvEditbox(Model, "strEmployerName", true)%>
        </td>
        <td>
        </td>    
    </tr> 
    <tr>
        <td colspan="7">
            <%=Html.LabelFor(m => m.idfEmployerAddress)%>:
        </td>
    </tr>
    <tr>
        <td colspan="7" class="noIndent">
            <%=Html.Address(Model.idfCase.HasValue ? Model.idfCase.Value : Model.idfHuman, Model.EmployerAddress, true, false, true)%>
        </td>
    </tr>               
</table>
