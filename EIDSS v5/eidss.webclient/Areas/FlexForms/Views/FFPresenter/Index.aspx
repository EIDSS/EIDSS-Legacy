<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/FlexForms/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="eidss.model.Schema" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<%
        //ЭТО ТЕСТ
        var template = FFPresenterModel.LoadActualTemplate(249540000000);

        Html.Telerik().NumericTextBox()
            .Name("testTextBox")
            .MaxValue(100)
            .MinValue(0)
            .Value(50)
            .EmptyMessage("")
            .Render();
        
        %>

    <h2><%= template.NationalName %></h2>    

    <%
        var model = new FFPresenterModel();
        model.SetProperties(template);
        var args = new RouteValueDictionary { { "model", model } };
        Html.RenderAction("ShowFlexibleForm", "FFPresenter", args);
        %>

</asp:Content>
