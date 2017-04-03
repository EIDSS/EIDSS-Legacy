<%@ Page Title="Map" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Map.aspx.cs" Inherits="eidss.ram.web.Map" %>


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
    <dx:ASPxCallback ID="cbControl" ClientInstanceName="cbControl" runat="server" OnCallback="cbControl_Callback">
        <ClientSideEvents CallbackComplete="function(s, e) { 
                if(s.cpNeedChangeFilterCaptionText){
                    FilterCaption.SetText(s.cpFilterCaptionText);
                }
                s.cpNeedChangeFilterCaptionText = false;
            }" />
    </dx:ASPxCallback>
    <asp:HiddenField ID="MapHiddenField" runat="server" />
    <asp:HiddenField ID="PivotGridPageIndex" runat="server" />

   <asp:Panel ID="MainPanel" runat="server" ScrollBars="Auto" Height="520px" >
       <table cellpadding="0" cellspacing="0" width="100%">
          <tr>
            <td>
                <table>
                    <tr>
                        <td>
                            <strong><asp:Literal runat="server" Text="<%$ Resources: ExportToJpeg %>" /></strong>
                        </td>
                        <td>
                            <dx:ASPxButton ID="buttonSaveAs" runat="server" ToolTip="<%$ Resources: ExportAndSave %>" Style="vertical-align: middle;"
                                OnClick="buttonSaveAs_Click" Text="<%$ Resources: Save %>" Width="90px" >
                                <ClientSideEvents Click="function(s, e) {
                                var bounds =  map.getBounds();
                                var base_layer = 0;
                                if (document.getElementById('map_base_layer').checked) {base_layer = 1;}
                                document.getElementById('MainContent_MapHiddenField').value = bounds.getSouthWest().lng + ';' + bounds.getSouthWest().lat + ';' + bounds.getNorthEast().lng + ';' + bounds.getNorthEast().lat + ';' + base_layer;
                                }" />
                            </dx:ASPxButton>
                        </td>
                        <td>
                            <dx:ASPxButton ID="buttonOpen" runat="server" 
                                ToolTip="<%$ Resources: ExportAndOpen %>" Style="vertical-align: middle" AutoPostBack="False"
                                 Text="<%$ Resources: Open %>" Width="90px" >
                                <ClientSideEvents Click="function(s, e) {
                                var bounds =  map.getBounds();
                                var base_layer = 0;
                                if (document.getElementById('map_base_layer').checked) {base_layer = 1;}
                                var gisData = bounds.getSouthWest().lng + ';' + bounds.getSouthWest().lat + ';' + bounds.getNorthEast().lng + ';' + bounds.getNorthEast().lat + ';' + base_layer;
                                document.getElementById('MainContent_MapHiddenField').value = gisData;
                                var pageIndex = document.getElementById('MainContent_PivotGridPageIndex').value;
                                var FilterUnit = document.getElementById('MainContent_AdministrativeUnit_I').value;                                
                                window.open('./Map.aspx?gisData=' + gisData + '&' + 'FilterUnit=' + FilterUnit+ '&' + 'PivotGridPageIndex=' + pageIndex);
                            }" />
                        </dx:ASPxButton>
                        </td>
                        <td align="right" class="style1">
                            <dx:ASPxButton ID="shp_export" runat="server" AutoPostBack="False" 
                                Style="vertical-align: middle" Text="SHP" 
                                ToolTip="<%$ Resources: ExportAndOpen %>" Width="90px" 
                                onclick="shp_export_Click">                              
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
                            <strong><asp:Literal runat="server" Text="<%$ Resources: MapCaption %>" /></strong>
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
                            <strong><asp:Literal runat="server" Text="<%$ Resources: AdministrativeUnit %>" /></strong>
                        </td>
                       <td style="width: 600px"> 
                          <dx:ASPxComboBox ID="AdministrativeUnit" runat="server" Width="600px" 
                                 AutoPostBack="False" ValueType="System.String" />
                        </td>
                    </tr>
                     <tr>
                        <td  valign="top" style="width: 200px">
                            <strong><asp:Literal runat="server" Text="<%$ Resources: DataField %>" /></strong>
                        </td>
                       <td style="width: 600px"> 
                          <dx:ASPxComboBox ID="DataField" runat="server" Width="600px" 
                                AutoPostBack="False" ValueType="System.String" />
                        </td>
                    </tr>
                     <tr>
                        <td  valign="top" style="width: 200px">
                            &nbsp;
                        </td>
                       <td style="width: 600px"> 
                         <dx:ASPxButton ID="buttonApply" runat="server" ToolTip="Apply Changes" Style="vertical-align: middle;"
                                OnClick="buttonApply_Click" Text="Apply" Width="90px" />
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
        </table>

        <table cellpadding="0" cellspacing="0" width="100%">
          <tr>
            <td>
                <eidss:WebPivotGrid ID="PivotGrid" ClientInstanceName="PivotGrid" runat="server" 
                        EnableCallBacks="true" EnableViewState="true" 
                        OnPrefilterCriteriaChanged="PivotGrid_PrefilterCriteriaChanged" >
                        <OptionsView ShowHorizontalScrollBar="True" EnableFilterControlPopupMenuScrolling="True"  />
                        <ClientSideEvents AfterCallback="function(s, e) { cbControl.PerformCallback(); }" />
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
                
                <link rel="stylesheet" href="/Content/LeafMap/dist/leaflet.css"" />
	            <!--[if lte IE 8]><link rel="stylesheet" href="/Content/LeafMap/dist/leaflet.ie.css" /><![endif]-->
            	<link rel="stylesheet" href="/Content/LeafMap/css/screen.css" />
	            <script src="/Scripts/LeafMap/leaflet-include.js"></script>
                <style type="text/css"> .map_legend {display:block; border: 1px solid black; width: 50px; height:25px;}</style> 
                <style type="text/css">
                    .checkbox_layer {height: 35px;width: 19px;clear:left;float:left;margin: 0 0 3px;padding: 0 0 0 36px; background: url("/Content/Toolbar/checkbox_layer.png") no-repeat;cursor: pointer;text-align:left;}
                    .checkbox_info {height: 35px;width: 19px;clear:left;float:left;margin: 0 0 3px;padding: 0 0 0 36px; background: url("/Content/Toolbar/checkbox_info.png") no-repeat;cursor: pointer;text-align:left;}
                    .checkbox_meas {height: 35px;width: 19px;clear:left;float:left;margin: 0 0 3px;padding: 0 0 0 36px; background: url("/Content/Toolbar/checkbox_meas.png") no-repeat;cursor: pointer;text-align:left;}
                    .checkbox input,.radio input {display: none;}
                    .checkbox input.show,.radio input.show {display: inline;}
                    .selected {background-position: 0 -70px;}
                    .block {width: 50%;float: left;}
                    label {padding-left:10px;float:left;text-align:left;}
                </style>
                <script class="include" type="text/javascript" src="/Scripts/MapPlot/jquery.min.js"></script>
                <script src="/Scripts/jquery.custom_radio_checkbox.js" type="text/javascript"></script>
                <!--[if lt IE 9]><script language="javascript" type="text/javascript" src="/Scripts/MapPlot/excanvas.min.js"></script><![endif]-->
                <script language="javascript" type="text/javascript" src="/Scripts/MapPlot/jquery.jqplot.min.js"></script>  
                <link rel="stylesheet" type="text/css" href="/Scripts/MapPlot/jquery.jqplot.min.css" />  
                <script class="include" language="javascript" type="text/javascript" src="/Scripts/MapPlot/plugins/jqplot.barRenderer.min.js"></script>
                <script class="include" language="javascript" type="text/javascript" src="/Scripts/MapPlot/plugins/jqplot.categoryAxisRenderer.min.js"></script>
                <script class="include" language="javascript" type="text/javascript" src="/Scripts/MapPlot/plugins/jqplot.pointLabels.min.js"></script>

                <table cellspacing='0' cellpadding='2'>
<tr>
<td title='<asp:Literal runat="server" Text="<%$ Resources: mapChangeLayer %>" />'><div><div id='checkbox_layer' style='display:none;' class="checkbox_layer checkbox" onClick='ChangeAction("ChangeLayer");'><input type="checkbox" checked id="map_base_layer"></div></div></td> 
<td title='<asp:Literal runat="server" Text="<%$ Resources: mapInfo %>" />'><div><div id='checkbox_info' style='display:none;' class="checkbox_info checkbox" onClick='ChangeAction("Info");'><input type="checkbox" checked id="map_chk_info"></div></div></td> 
<td title='<asp:Literal runat="server" Text="<%$ Resources: mapMeasure %>" />'?><div><div id='checkbox_meas' style='display:none;' class="checkbox_meas checkbox" onClick='ChangeAction("Measure");'><input type="checkbox" checked id="map_chk_meas"></div></div></td> 
</tr>
</table>
                <br>

                <table>
    <tr>
    <td><div id="map" style="height: 447px; width: 709px"></div><div id='map_info_line'></div></td>
    <td valign='top'><div id='legend' style='padding-left:5px;'></div></td>
    </tr>
    </table>
      
	            <script type="text/javascript">
	    var json_text = '<% =json %>';
	    var map_type = '<% =m_map_type %>';

	    if (map_type) {
	        $(document).ready(function () {
	            $("#checkbox_layer").get(0).style.display = '';
	            $("#checkbox_info").get(0).style.display = '';
	            $("#checkbox_meas").get(0).style.display = '';
	            $(".checkbox").dgStyle();
	            $(".checkbox").dgCheck($("#checkbox_layer").get(0));
	            $(".checkbox").dgCheck($("#checkbox_info").get(0));
	            $(".checkbox").dgCheck($("#checkbox_meas").get(0));
	        });

	        var base_url = document.URL;
	        base_url = base_url.substring(0, base_url.indexOf('/', 7));
	        base_url = '';
	        var marker_url = base_url + '/Content/Images/MapMarkers/';

	        var localUrl = '<% =m_map_url %>';
	        var localUrlLabel = '<% =m_map_url_label %>';

	        latlng = new L.LatLng(-7, 37);
	        var osm_url = 'http://b.tile.openstreetmap.org/{z}/{x}/{y}.png', osmAttribution = 'Map data &copy; 2011 OpenStreetMap contributors, Imagery &copy; 2011 CloudMade', osm_layer = new L.TileLayer(osm_url, { maxZoom: 18, attribution: osmAttribution });
	        local_layer = new L.TileLayer(localUrl + "/{z}/{x}/{y}.png", { maxZoom: 18 });
	        local_layer_label = new L.TileLayer(localUrlLabel + "/{z}/{x}/{y}.png", { maxZoom: 18 });
	        var map = new L.Map('map', { center: latlng, zoom: 5, layers: [osm_layer, local_layer, local_layer_label], closePopupOnClick: false });


	        map.on('click', function (e) {
	            if (Action == "Info") {
	                Action = '';
	                $(".checkbox").dgCheck($("#checkbox_info").get(0));
	                $.ajax({
	                    url: "/en-US/Map/InfoMap?lon=" + e.latlng.lng + "&lat=" + e.latlng.lat,
	                    cache: false,
	                    success: function (html) {
	                        if (html.search("InfoMapResult") > -1) {
	                            $("#map_info_line").html(html.replace("InfoMapResult", ""));
	                        }
	                    }
	                }
                );
	            }
	            else if (Action == "Measure") {
	                if (MeasureLine) { map.removeLayer(MeasureLine); }
	                MeasurePoints.push(e.latlng);
	                MeasureLine = new L.Polyline(MeasurePoints, { color: 'red' });
	                map.addLayer(MeasureLine);

	                var MeasureValue = 0;
	                for (var i = 0; i < MeasurePoints.length - 1; i++) { MeasureValue += MeasurePoints[i].distanceTo(MeasurePoints[i + 1]); }
	                $("#map_info_line").html((MeasureValue / 1000).toFixed(2) + " km");
	            }
	        });

	        var Action;
	        var MeasureLine;
	        var MeasurePoints = new Array();
	        function ChangeAction(pAction) {
	            if (pAction == 'Measure') {
	                if (Action != pAction) {
	                    if (Action == 'Info') { $(".checkbox").dgCheck($("#checkbox_info").get(0)); }
	                    Action = 'Measure';
	                }
	                else {
	                    StopAction('Measure');
	                    Action = '';
	                }
	            }
	            else if (pAction == 'Info') {
	                if (Action != pAction) {
	                    if (Action == 'Measure') { StopAction('Measure'); $(".checkbox").dgCheck($("#checkbox_meas").get(0)); }
	                    Action = 'Info';
	                }
	                else { Action = ''; $("#map_info_line").html(''); }
	            }
	            else if (pAction == 'ChangeLayer') { Action = ''; ChangeLayer(); }
	            else { Action = ''; SelectVet(); }
	        }

	        function StopAction(pAction) {
	            if (pAction == 'Measure') {
	                if (MeasureLine) { map.removeLayer(MeasureLine); }
	                MeasurePoints = new Array();
	                $("#map_info_line").html('');

	            }

	        }
	    }
	    else
	    {document.getElementById('map').style.display = 'none'; }


	    if (map_type == 'avr_pie') {
	        pieColors = { "1": "#b5e61d", "2": "#ed1c24", "4": "#fff200", "8": "#FFFF00", "16": "#694132" };

	        var HasAvian = 0;
	        $(document).ready(function () {

	            var PieInfo = new Object();
	            var json = JSON.parse(json_text);
	            var features = json['features'];
	            for (var i = 0; i < features.length; i++) {
	                var Id = features[i]['properties']['id'];
	                var X = features[i]['properties']['x'];
	                var Y = features[i]['properties']['y'];
	                var Type = features[i]['properties']['type'];
	                var Value = features[i]['properties']['value'];
	                if (Value == 8 || Value == 16) { HasAvian = 1; }
	                if (!PieInfo[Id]) {
	                    PieInfo[Id] = new Object();
	                    PieInfo[Id][Type] = Value;
	                    var popup = new L.Popup({ closeButton: false });
	                    popup.setLatLng(new L.LatLng(Y, X));
	                    popup.setContent("<div id='" + Id + "' style='margin:-10px; width:100px; height:100px;'></div>");
	                    map.addLayer(popup);
	                }
	                else {
	                    PieInfo[Id][Type] = Value;
	                }
	            }


	            for (var key in PieInfo) {
	                var ticks = ['1'];
	                var Values = new Array();
	                var lColors = new Array();

	                for (var cse in PieInfo[key]) {
	                    Values.push([PieInfo[key][cse]]);
	                    lColors.push(pieColors[cse]);
	                }
	                var plot1 = $.jqplot(key, Values, {
	                    seriesColors: lColors,
	                    seriesDefaults: { rendererOptions: { barWidth: 30 }, renderer: $.jqplot.BarRenderer, pointLabels: { show: true, edgeTolerance: -25 }, shadow: false },
	                    axesDefaults: { showTicks: false, showTickMarks: false },
	                    grid: { drawGridLines: false, gridLineColor: '#FFFFFF', background: '#FFFFFF', shadow: false, borderWidth: 0 },
	                    axes: { xaxis: { renderer: $.jqplot.CategoryAxisRenderer, ticks: ticks} }
	                });
	            }
	        });
	    }



	    if (map_type == 'avr_marker') {
	        var TypeIcons = new Object();
	        var LeafIcon = L.Icon.extend({ iconSize: new L.Point(25, 25), shadowSize: new L.Point(1, 1), iconAnchor: new L.Point(22, 94), popupAnchor: new L.Point(-3, -76) });
	        for (var i = 1; i < 6; i++) { TypeIcons[i] = new LeafIcon(marker_url + i + ".png"); }
	        for (var i = 11; i < 16; i++) { TypeIcons[i] = new LeafIcon(marker_url + i + ".png"); }

	        if (json_text) {
	            var legend_text = "<p><img src='" + marker_url + 1 + ".png'> - Human</p>";
	            legend_text += "<p><img src='" + marker_url + 2 + ".png'> - Vet</p>";
	            legend_text += "<p><img src='" + marker_url + 3 + ".png'> - Vector</p>";
	            legend_text += "<p><img src='" + marker_url + 4 + ".png'> - Avian</p>";
	            legend_text += "<p><img src='" + marker_url + 5 + ".png'> - LiveStock</p>";
	            $('#legend').get(0).innerHTML = legend_text;

	            var json = JSON.parse(json_text);
	            var features = json['features'];

	            for (var i = 0; i < features.length; i++) {
	                var X = features[i]['properties']['x'];
	                var Y = features[i]['properties']['y'];

	                if (features[i]['properties']['human']) { var marker = new L.Marker(new L.LatLng(Y, X), { icon: TypeIcons[11] }); map.addLayer(marker); }
	                if (features[i]['properties']['vet']) { var marker = new L.Marker(new L.LatLng(Y, X), { icon: TypeIcons[12] }); map.addLayer(marker); }
	                if (features[i]['properties']['vector']) { var marker = new L.Marker(new L.LatLng(Y, X), { icon: TypeIcons[13] }); map.addLayer(marker); }
	                if (features[i]['properties']['avian']) { var marker = new L.Marker(new L.LatLng(Y, X), { icon: TypeIcons[14] }); map.addLayer(marker); }
	                if (features[i]['properties']['livestock']) { var marker = new L.Marker(new L.LatLng(Y, X), { icon: TypeIcons[15] }); map.addLayer(marker); }
	                map.addLayer(marker);
	            }
	        }
	    }


	    if (map_type == 'avr_poly') {

	        var json = JSON.parse(json_text);
	        var features = json['features'];
	        polyOptions = { fillColor: '#f03', fillOpacity: 0.5 };
	        
	        var vmax, vmin, vavr = 0;
	        for (var i = 0; i < features.length; i++) {
                var Value = features[i]["properties"]["value"];
                if (vmax == null || vmax < Value) { vmax = Value; vavr++; }
	            if (vmin == null || vmin > Value) { vmin = Value; }
	        }
	        var v_step = (vmax - vmin) / 4;


	        var legend_text;
	        var PolyColors = ['#00ff00', '#00c800', '#009600', '#006400', '#004b00'];
	        // Inverted '#ff0000', '#960000', '#969600', '#009600', '#00ff00'
	        if (vmax == vmin)
            {
                legend_text = "<div class='map_legend' style='background-color:#00ff00'></div>" + vmin;
            }
            else if (vavr < 3)
            {
                legend_text = vmax + "<br><div class='map_legend' style='background-color:#004b00'></div><br>";
                legend_text += "<div class='map_legend' style='background-color:#00ff00'></div><br>" + vmin;
            }
            else {
                
                legend_text = vmax + '<br><br>'; // Max value
                legend_text += "<img src='" + base_url  + "/Content/Images/poly_grad_legend_.png'><br>";
                //for (var i = 0; i < PolyColors.length; i++) { legend_text += "<div class='map_legend' style='background-color:" + PolyColors[i] + ";'></div><br>"; }
                legend_text += vmin + "<br>"; // Min value                 
            }
            $('#legend').get(0).innerHTML = legend_text;


            for (var i = 0; i < features.length; i++)
            {
                var color_index = 0;
                if (v_step > 0) { color_index = parseInt((features[i]["properties"]["value"] - vmin) / v_step); }
                if (color_index > 4) { color_index = 4; }


                if (features[i]["geometry"] != null)
                {
                    features[i]["properties"]["style"] = { color: PolyColors[color_index], fillColor: PolyColors[color_index], fillOpacity: 0.5 };
                    var geojsonLayer = new L.GeoJSON();
                    geojsonLayer.on("featureparse", function (e) { if (e.properties && e.properties.style && e.layer.setStyle) { e.layer.setStyle(e.properties.style); } });
                    geojsonLayer.addGeoJSON(features[i]);
                    map.addLayer(geojsonLayer);
                }
	        }
	       
	    }

	    if (map_type == 'avr_point') {
	        var json = JSON.parse(json_text);
	        var features = json['features'];
	        var PointColors = ['#ff0000', '#00ff00'];
	        var PointSize = [10, 25];

	        var legend_text = 'Max value<br><br>';
	        for (var i = 0; i < PointColors.length; i++) { legend_text += "<div class='map_legend' style='background-color:" + PointColors[i] + ";'></div><br>"; }
	        legend_text += "Min value<br>";
	        $('#legend').get(0).innerHTML = legend_text; 


	        for (var i = 0; i < features.length; i++) {
	            if (!vmax || vmax < features[i]["properties"]["value"]) { vmax = features[i]["properties"]["value"]; }
	            if (!vmin || vmin > features[i]["properties"]["value"]) { vmin = features[i]["properties"]["value"]; }
	        }
	        var v_step = (vmax - vmin) / 2;


	        for (var i = 0; i < features.length; i++) {
	            var p_index = 0;
	            if (parseInt(features[i]["properties"]["value"]) > v_step) { p_index = 1; }
	            var X = features[i]['properties']['x'];
	            var Y = features[i]['properties']['y'];
	            var circleLocation = new L.LatLng(Y, X),
                circleOptions = { color: PointColors[p_index], fillColor: PointColors[p_index], fillOpacity: 0.5, radius: PointSize[p_index] };
	            var circle = new L.CircleMarker(circleLocation, circleOptions);
	            map.addLayer(circle);
	        }
	    }

	    function ChangeLayer() {
	        var pCheck = $('#map_base_layer').get(0).checked;
	        if (pCheck) {
	            map.addLayer(local_layer);
	            map.addLayer(local_layer_label);
	        }
	        else {
	            map.removeLayer(local_layer);
	            map.removeLayer(local_layer_label);
	        }
	    }    
           
         </script> 
        </td>
          </tr>
        </table>
   </asp:Panel>     
</asp:Content>
