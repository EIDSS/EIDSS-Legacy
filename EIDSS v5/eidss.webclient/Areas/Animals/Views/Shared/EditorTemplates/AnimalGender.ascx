<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%= Html.Telerik().DropDownList()
    .Name("idfsAnimalGender")
    .HtmlAttributes(new { style = "width:300px;" })
    .BindTo(new SelectList((IEnumerable)ViewData["AnimalGender"], "Value", "Text"))%>
