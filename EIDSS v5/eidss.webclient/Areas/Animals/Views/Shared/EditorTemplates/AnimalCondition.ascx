<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%= Html.Telerik().DropDownList()
    .Name("idfsAnimalCondition")
    .HtmlAttributes(new { style = "width:300px;" })
    .BindTo(new SelectList((IEnumerable)ViewData["AnimalCondition"], "Value", "Text"))%>
