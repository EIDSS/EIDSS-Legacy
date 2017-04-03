<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<%= Html.Telerik().DropDownList()
    .Name("idfsVaccinationRoute")
    .HtmlAttributes(new { style = "width:300px;" })
        .BindTo(new SelectList((IEnumerable)ViewData["VaccinationRoute"], "Value", "Text"))%>