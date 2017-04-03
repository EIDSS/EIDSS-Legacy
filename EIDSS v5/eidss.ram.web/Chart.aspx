<%@ Page Title="Chart" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Chart.aspx.cs" Inherits="eidss.ram.web.Chart" %>

    <%@ Register Assembly="DevExpress.XtraCharts.v11.1, Version=11.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraCharts" TagPrefix="dxCharts" %>

    <%@ Register Assembly="DevExpress.Charts.v11.1.Core, Version=11.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraCharts" TagPrefix="dxCharts" %>

<%@ Register Assembly="DevExpress.XtraCharts.v11.1.Web, Version=11.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxCharts" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v11.1.Export, Version=11.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPivotGrid.Export" TagPrefix="dxExport" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v11.1, Version=11.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dxPivot" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" 
    namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Data.v11.1, Version=11.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" 
    namespace="DevExpress.Data" tagprefix="dx" %>


<%@ Register assembly="eidss.ram.web" namespace="eidss.ram.web.Components" tagprefix="eidss" %>

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
    <asp:Label ID="WarningLabel" runat="server" Font-Size="20"></asp:Label>
    <asp:Panel ID="MainPanel" runat="server" ScrollBars="Auto" Height="520px" > 
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
               <td>
                  <table>
                    <tr>
                        <td>
                            <strong><asp:Literal runat="server" Text="<%$ Resources: ExportTo %>" /></strong>
                        </td>
                        <td>
                            <dx:ASPxComboBox ID="listExportFormat" ClientInstanceName="listExportFormatClient"
                                 runat="server" Style="vertical-align: middle"
                                SelectedIndex="0" ValueType="System.String" Width="90px">
                                <Items>
                                    <dx:ListEditItem Text="Pdf" Value="0" />
                                    <dx:ListEditItem Text="Excel" Value="1" />
                                    <dx:ListEditItem Text="Jpeg" Value="4" />
                                </Items>
                            </dx:ASPxComboBox>
                        </td>
                        <td>
                            <dx:ASPxButton ID="buttonSaveAs" runat="server" ToolTip="<%$ Resources: ExportAndSave %>" Style="vertical-align: middle;"
                                OnClick="buttonSaveAs_Click" Text="<%$ Resources: Save %>" Width="90px" />
                        </td>
                        <td>
                            <dx:ASPxButton ID="buttonOpen" runat="server" ToolTip="<%$ Resources: ExportAndOpen %>" Style="vertical-align: middle" Text="<%$ Resources: Open %>" Width="90px">
                                <ClientSideEvents Click="function(s, e) {
                                 var item =  listExportFormatClient.GetListBoxControl().GetSelectedItem().value;
                                 window.open('./Chart.aspx?open=' + item);
                                }" />
                            </dx:ASPxButton>
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
                            <strong><asp:Literal runat="server" Text="<%$ Resources: ChartCaption %>" /></strong>
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
                    <tr>
                        <td  valign="top" style="width: 200px">
                            <strong><asp:Literal runat="server" Text="<%$ Resources: ChartType %>" /></strong>
                        </td>
                       <td style="width: 600px"> 
                            <dx:ASPxComboBox ID="ChartType" runat="server" OnValueChanged="ChartType_ValueChanged"
                                            AutoPostBack="True" ValueType="System.String" />
                        </td>
                    </tr>
                </table>    
                
            </td>
            </tr>
            <tr>
               <td>
                <table>
                    <tr>
                        <td>
                            
                            <dx:ASPxCheckBox runat="server" Checked="True"  Text="<%$ Resources: ShowColumnGrandTotals %>" AutoPostBack="True"
                                ID="ShowColumnGrandTotals" OnCheckedChanged="ShowColumnGrandTotals_CheckedChanged"
                                Wrap="True"  />
                            
                        </td>
                        <td>
                            <dx:ASPxCheckBox runat="server" Checked="False" Text="<%$ Resources: PivotDiagramAxis %>" AutoPostBack="True"
                                ID="PivotDiagramAxis" OnCheckedChanged="PivotDiagramAxis_CheckedChanged" Wrap="False" />
                        </td>
                    </tr>
                    <tr>

                        <td>
                            <dx:ASPxCheckBox runat="server" Text="<%$ Resources: ShowRowGrandTotals %>" AutoPostBack="True"
                                ID="ShowRowGrandTotals" OnCheckedChanged="ShowRowGrandTotals_CheckedChanged"
                                Wrap="False" />
                        </td>
                        <td>
                            <dx:ASPxCheckBox ID="PointLabels" runat="server" Text="<%$ Resources: ShowPointLabels %>" OnCheckedChanged="PointLabels_CheckedChanged"
                                AutoPostBack="True" Wrap="False" />
                        </td>
                    </tr>
                </table>
            </td>
            </tr>
        </table>
        
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <eidss:WebPivotGrid ID="PivotGrid" ClientInstanceName="PivotGrid" runat="server"  
                            EnableCallBacks="false"  EnableViewState="true" 
                            OnPrefilterCriteriaChanged="PivotGrid_PrefilterCriteriaChanged" >
                            <OptionsView ShowHorizontalScrollBar="True" EnableFilterControlPopupMenuScrolling="True" />
                        </eidss:WebPivotGrid>
                </td>
            </tr>
            <tr>
                <td>
                   &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <dxCharts:WebChartControl ID="WebChart" runat="server"  
                    DataSourceID="PivotGrid" 
                    Height="500px" Width="850px" 
                    SeriesDataMember="Series"
                    >
                    
                        <diagramserializable>
                            <dxCharts:XYDiagram>
                                <axisx visibleinpanesserializable="-1">
                                    <label staggered="True" />
                                    <range sidemarginsenabled="True" />
                                </axisx>
                                <axisy visibleinpanesserializable="-1">
                                    <range sidemarginsenabled="True" />
                                </axisy>
                            </dxCharts:XYDiagram>
                        </diagramserializable>
                        <fillstyle>
                            <optionsserializable>
                                <dxCharts:SolidFillOptions />
                            </optionsserializable>
                        </fillstyle>
                        <legend maxhorizontalpercentage="30"></legend>
                        <seriestemplate argumentdatamember="Arguments" 
                            valuedatamembersserializable="Values">
                            <viewserializable>
                                <dxCharts:SideBySideBarSeriesView>
                                </dxCharts:SideBySideBarSeriesView>
                            </viewserializable>
                            <labelserializable>
                                <dxCharts:SideBySideBarSeriesLabel LineVisible="True">
                                    <fillstyle>
                                        <optionsserializable>
                                            <dxCharts:SolidFillOptions />
                                        </optionsserializable>
                                    </fillstyle>
                                </dxCharts:SideBySideBarSeriesLabel>
                            </labelserializable>
                            <pointoptionsserializable>
                                <dxCharts:PointOptions>
                                </dxCharts:PointOptions>
                            </pointoptionsserializable>
                            <legendpointoptionsserializable>
                                <dxCharts:PointOptions>
                                </dxCharts:PointOptions>
                            </legendpointoptionsserializable>
                        </seriestemplate>
                    
                    </dxCharts:WebChartControl>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
