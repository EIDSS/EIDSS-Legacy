<%@ Page Title="AVR" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Report.aspx.cs" Inherits="eidss.ram.web.Report" %>

<%@ Register Assembly="DevExpress.XtraCharts.v11.1, Version=11.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraCharts" TagPrefix="dxCharts" %>

<%@ Register Assembly="DevExpress.XtraCharts.v11.1.Web, Version=11.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxCharts" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v11.1.Export, Version=11.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPivotGrid.Export" TagPrefix="dxExport" %>


<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v11.1, Version=11.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dxPivot" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" 
    namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" 
    Namespace="DevExpress.Web.ASPxCallback" TagPrefix="dx" %>
    
<%@ Register Assembly="eidss.ram.web" namespace="eidss.ram.web.Components" tagprefix="eidss" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript">
        function OnCaptionTextBoxKeyUp(s, e) {
            var layoutName = CaptionTextBox.GetValue();
            var queryPath = document.getElementById("QueryPath").value;
            document.getElementById("LayoutHeader").innerText = queryPath + "->" + layoutName;            
        }
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">    
    <dx:ASPxCallback ID="cbControl" ClientInstanceName="cbControl" runat="server" OnCallback="cbControl_Callback">
        <ClientSideEvents CallbackComplete="function(s, e) { 
                if(s.cpNeedChangeFilterCaptionText){
                    FilterCaption.SetText(s.cpFilterCaptionText);
                }
                s.cpNeedChangeFilterCaptionText = false;
            }" />
    </dx:ASPxCallback>
 <asp:Panel ID="MainPanel" runat="server" ScrollBars="Auto" Height="520px">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <table>
                    <tr>
                        <td>
                            <strong><asp:Literal runat="server" Text="<%$ Resources: ExportTo %>" /></strong>
                        </td>
                        <td>
                            <dx:ASPxComboBox ID="listExportFormat"  ClientInstanceName="listExportFormatClient" 
                                runat="server" Style="vertical-align: middle"
                                SelectedIndex="0" ValueType="System.String" Width="90px">
                                <Items>
                                    <dx:ListEditItem Text="Pdf" Value="0" />
                                    <dx:ListEditItem Text="Excel" Value="1" />
                                    <dx:ListEditItem Text="Rtf" Value="2" />
                                    <dx:ListEditItem Text="Jpeg" Value="4" />

                                </Items>
                            </dx:ASPxComboBox>
                        </td>
                        <td>
                            <dx:ASPxButton ID="buttonSaveAs" runat="server" ToolTip="<%$ Resources: ExportAndSave %>" Style="vertical-align: middle;"
                                OnClick="buttonSaveAs_Click" Text="<%$ Resources: Save %>" Width="90px" />
                        </td>
                        <td>
                            <dx:ASPxButton ID="buttonOpen" runat="server" ToolTip="<%$ Resources: ExportAndOpen %>" Style="vertical-align: middle" Text="<%$ Resources: Open %>" Width="90px" >
                                 <ClientSideEvents Click="function(s, e) {
                                 var item =  listExportFormatClient.GetListBoxControl().GetSelectedItem().value;
                                 window.open('./Report.aspx?open=' + item);
                                 }" />
                            </dx:ASPxButton>
                        </td>
                        <td>
                          <dx:ASPxCheckBox runat="server" Checked="False"  Text="<%$ Resources: UseArchive %>" AutoPostBack="True"
                                ID="UseArchive" OnCheckedChanged="UseArchive_CheckedChanged"
                                Wrap="True" TextAlign="Right"  />
                          </td>
                    </tr>
                </table>

            </td>
        </tr>
        <tr>
            <td>
               &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                 <table border="0" cellpadding="3" cellspacing="0">
                    <tr>
                        <td  valign="top" style="width: 200px">
                            <strong><asp:Literal runat="server" Text="<%$ Resources: ReportCaption %>" /></strong>
                        </td>
                        <td style="width: 600px"> 
                            <dx:ASPxTextBox ID="CaptionTextBox" ClientInstanceName="CaptionTextBox" runat="server" Width="600px" >
                                <ClientSideEvents KeyUp="OnCaptionTextBoxKeyUp"></ClientSideEvents>
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td  valign="top" style="width: 200px">
                            <strong><asp:Literal runat="server" Text="<%$ Resources: FilterCaption %>" /></strong>
                        </td>
                       <td style="width: 600px"> 
                            <dx:ASPxTextBox ID="FilterCaption" ClientInstanceName="FilterCaption" runat="server" Width="600px">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    
                </table>
            </td>
        </tr>
        <tr>
            <td>
               &nbsp;<asp:Label runat="server" ID="PivotGridWarning"></asp:Label>
            </td>
        </tr>
    </table>
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                 
                    <eidss:WebPivotGrid ID="PivotGrid" ClientInstanceName="PivotGrid" runat="server" 
                      
                        EnableCallBacks="true" EnableViewState="true" 
                        OnPrefilterCriteriaChanged="PivotGrid_PrefilterCriteriaChanged" >
                        <OptionsView  EnableFilterControlPopupMenuScrolling="True"  />
                        <ClientSideEvents AfterCallback="function(s, e) { cbControl.PerformCallback(); }" />
                  
                    </eidss:WebPivotGrid>
                 
                </td>
            </tr>
        </table>
    </asp:Panel>  
</asp:Content>
