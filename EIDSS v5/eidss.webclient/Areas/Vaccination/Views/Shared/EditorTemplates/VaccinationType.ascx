﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%= Html.Telerik().DropDownList()
        .Name("idfsVaccinationType")
    .HtmlAttributes(new { style = "width:300px;" })
        .BindTo(new SelectList((IEnumerable)ViewData["VaccinationType"], "Value", "Text"))%>
