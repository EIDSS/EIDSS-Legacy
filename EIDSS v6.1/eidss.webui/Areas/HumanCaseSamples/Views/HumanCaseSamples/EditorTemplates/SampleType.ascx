<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%= Html.Telerik().DropDownList()
        .Name("idfsSpecimenType")
    .BindTo(new SelectList((IEnumerable) ViewData["SampleType"], "Value", "Text"))%>

