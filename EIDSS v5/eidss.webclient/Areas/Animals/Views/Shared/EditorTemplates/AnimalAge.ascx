<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%= Html.Telerik().DropDownList()
    .Name("idfsAnimalAge")
    .HtmlAttributes(new { style = "width:300px;" })
    .BindTo(new SelectList((IEnumerable)ViewData["AnimalAge"], "Value", "Text"))%>
