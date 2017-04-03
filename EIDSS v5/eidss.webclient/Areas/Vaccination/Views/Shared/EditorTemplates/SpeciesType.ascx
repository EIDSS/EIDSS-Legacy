<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%= Html.Telerik().DropDownList()
    .Name("idfsSpecies")
    .HtmlAttributes(new { style = "width:300px;" })
    .BindTo(new SelectList((IEnumerable)ViewData["SpeciesType"], "Value", "Text"))%>

