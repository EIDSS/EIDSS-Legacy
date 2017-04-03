<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%= Html.Telerik().DropDownList()
    .Name("idfSpecies")
    .HtmlAttributes(new { style = "width:300px;" })
    .BindTo(new SelectList((IEnumerable)ViewData["FarmTree"], "Value", "Text"))%>
