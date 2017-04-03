<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/FlexForms/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="bv.common.Configuration" %>
<%@ Import Namespace="bv.model.BLToolkit" %>
<%@ Import Namespace="eidss.model.Schema" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<%
        Template template;

        DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString", ""));
        using (var manager = DbManagerFactory.Factory.Create())
        {
            var acc = Template.Accessor.Instance(null);
            const long idfsFormTemplate = 249540000000;
            template = acc.SelectByKey(manager, idfsFormTemplate, null);
        }

        Html.Telerik().NumericTextBox()
            .Name("testTextBox")
            .MaxValue(100)
            .MinValue(0)
            .Value(50)
            .Render();
        
        %>

    <h2><%= template.NationalName %></h2>    

    <%
        var args = new RouteValueDictionary { { "template", template }, { "activityParameters", null } };
        Html.RenderAction("ShowFlexibleForm", "FFPresenter", args);
        %>

</asp:Content>
