<%@ Page Title="Analysis, Visualization and Reporting Module (Report Viewer)" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="eidss.ram.web._Default" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" 
    namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="eidss.ram.web" namespace="eidss.ram.web.Components" tagprefix="eidss" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        <asp:Literal runat="server" Text="<%$ Resources: Common, ModuleTitle%>" />   
    </h2>
    <asp:Panel ID="MainPanel" runat="server" ScrollBars="Vertical" Height="600">
        <table runat="server" ID="StandardReportTable" cellpadding="0" cellspacing="0" width="100%">
            <tr runat="server" ID="StandardReportTR" >
                <td  runat="server" ID="StandardReportTD">
                    &nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
