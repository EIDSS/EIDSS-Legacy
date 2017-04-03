<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<%= Html.Telerik().DropDownList()
    .Name("idfsPersonContactType")
    .HtmlAttributes(new { style = "width:300px;" })
    .BindTo(new SelectList((IEnumerable)ViewData["PersonContactType"], "Value", "Text"))%>