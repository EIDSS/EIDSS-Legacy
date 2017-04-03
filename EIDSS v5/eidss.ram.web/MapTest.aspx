<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MapTest.aspx.cs" Inherits="eidss.ram.web.MapTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

                    <link rel="stylesheet" href="/Content/LeafMap/dist/leaflet.css"" />
	            <!--[if lte IE 8]><link rel="stylesheet" href="/Content/LeafMap/dist/leaflet.ie.css" /><![endif]-->
            	<link rel="stylesheet" href="/Content/LeafMap/css/screen.css" />
	            <script src="/Scripts/LeafMap/leaflet-include.js"></script>

                <!-- <script src="/Scripts/jquery-1.4.1.js"></script> -->

             <link class="include" rel="stylesheet" type="text/css" href="/Scripts/MapPlot/jquery.jqplot.min.css" />  
    <!--[if lt IE 9]><script language="javascript" type="text/javascript" src="/Scripts/MapPlot/excanvas.js"></script><![endif]-->
    <script class="include" type="text/javascript" src="/Scripts/MapPlot/jquery.min.js"></script>

</head>
<body style="height: 459px; width: 748px">
    <form id="form1" runat="server">
    <% =m_map_type %>
    <div id="map" style="height: 447px; width: 709px">
    <div id='legend' style='padding-left:5px;'></div>
    
    </div>
    <p>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Pie" />
        <asp:Button ID="Button2" runat="server" Text="Marker" onclick="Button2_Click" />
        <asp:Button ID="Button3" runat="server" Text="Poly" onclick="Button3_Click" />
        <asp:Button ID="Button4" runat="server" Text="Point" onclick="Button4_Click" />
    </p>

    	<script type="text/javascript">

    	    var PolyColors = ['#ff0000', '#960000', '#969600', '#009600', '#00ff00'];
    	  
    	    var legend_text = vmax + '<br><br>'; // Max value
    	    legend_text += "<img src='/Content/Images/poly_grad_legend_.png'><br>";
    	    //for (var i = 0; i < PolyColors.length; i++) { legend_text += "<div class='map_legend' style='background-color:" + PolyColors[i] + ";'></div><br>"; }
    	    legend_text += vmin + "<br>"; // Min value
    	    $('#legend').get(0).innerHTML = legend_text; 

    	    var marker_url = document.URL;
    	    marker_url = marker_url.substring(0, marker_url.indexOf('/', 7));
    	    marker_url += '/Content/Images/MapMarkers/';
    	    var cloudmadeUrl = 'http://b.tile.openstreetmap.org/{z}/{x}/{y}.png',
        cloudmadeAttribution = 'Map data &copy; 2011 OpenStreetMap contributors, Imagery &copy; 2011 CloudMade',
        cloudmade = new L.TileLayer(cloudmadeUrl, { maxZoom: 18, attribution: cloudmadeAttribution }),
        latlng = new L.LatLng(50.5, 30.51);
    	    var map = new L.Map('map', { center: latlng, zoom: 3, layers: [cloudmade], closePopupOnClick: false });

    	    var TypeIcons = new Object();
    	    var LeafIcon = L.Icon.extend({ iconSize: new L.Point(32, 32), shadowSize: new L.Point(32, 32), iconAnchor: new L.Point(22, 94), popupAnchor: new L.Point(-3, -76) });
    	    for (var i = 1; i < 8; i++) { TypeIcons[i] = new LeafIcon(marker_url + i + ".png"); }

    	    var json_text = '<% =json %>';
    	    var map_type = '<% =m_map_type %>';

    	    if (map_type == 'avr_pie') {

    	        pieColors = { "1": "#b5e61d", "2": "#ed1c24", "4": "#fff200" };
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
    	                if (!PieInfo[Id]) {
    	                    PieInfo[Id] = new Object();
    	                    PieInfo[Id][Type] = Value;
    	                    var popup = new L.Popup({closeButton: false});
    	                    popup.setLatLng(new L.LatLng(Y, X));
    	                    popup.setContent("<div id='" + Id + "' style='margin:0px; width:100px; height:100px;'></div>");
    	                    map.addLayer(popup);
    	                }
    	                else {
    	                    PieInfo[Id][Type] = Value;
    	                }
    	            }
    	            for (var key in PieInfo) {
    	                var Values = new Array();
    	                var lColors = new Array();

    	                for (var cse in PieInfo[key]) {
    	                    Values.push([cse, PieInfo[key][cse]]);
    	                    lColors.push(pieColors[cse]);
    	                }


    	                var plot1 = $.jqplot(key, [Values], {
    	                    gridPadding: { top: 0, bottom: 0, left: 0, right: 0 },
    	                    seriesDefaults: {
    	                        seriesColors: lColors,
    	                        renderer: $.jqplot.PieRenderer, trendline: { show: false }, rendererOptions: { padding: 2, showDataLabels: true, dataLabels: 'value' }
    	                    }
    	                });

    	            }
    	        });
    	    }


    	    if (map_type == 'avr_marker') {
    	        if (json_text) {

    	            var json = JSON.parse(json_text);
    	            var features = json['features'];
    	            for (var i = 0; i < features.length; i++) {
    	                var X = features[i]['properties']['x'];
    	                var Y = features[i]['properties']['y'];
    	                var type = features[i]['properties']['type'];
    	                var marker = new L.Marker(new L.LatLng(Y, X), { icon: TypeIcons[type] });
    	                map.addLayer(marker);
    	            }
    	        }
    	    }



    	    if (map_type == 'avr_poly') {

    	        var json = JSON.parse(json_text);
    	        var features = json['features'];
    	        polyOptions = { fillColor: '#f03', fillOpacity: 0.5 };

    	        var PolyColors = ['#ff0000', '#960000', '#969600', '#009600', '#00ff00'];
    	        var vmax, vmin;
    	        for (var i = 0; i < features.length; i++) {
    	            if (!vmax || vmax < features[i]["properties"]["value"]) { vmax = features[i]["properties"]["value"]; }
    	            if (!vmin || vmin > features[i]["properties"]["value"]) { vmin = features[i]["properties"]["value"]; }
    	        }
    	        var v_step = (vmax - vmin) / 4;


    	        for (var i = 0; i < features.length; i++) {
    	            var color_index = parseInt(features[i]["properties"]["value"] / v_step);
    	            features[i]["properties"]["style"] = { color: PolyColors[color_index], fillColor: PolyColors[color_index], fillOpacity: 0.5 };
    	            var geojsonLayer = new L.GeoJSON();
    	            geojsonLayer.on("featureparse", function (e) { if (e.properties && e.properties.style && e.layer.setStyle) { e.layer.setStyle(e.properties.style); } });
    	            geojsonLayer.addGeoJSON(features[i]);
    	            map.addLayer(geojsonLayer);
    	        }
    	    }

    	    if (map_type == 'avr_point') {
    	        var json = JSON.parse(json_text);
    	        var features = json['features'];
    	        var PointColors = ['#ff0000', '#00ff00'];
    	        var PointSize = [10, 25];

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


    
           
         </script>
         
         

         <script class="include" type="text/javascript" src="/Scripts/MapPlot/jquery.jqplot.min.js"></script>
         <script class="include" type="text/javascript" src="/Scripts/MapPlot/plugins/jqplot.pieRenderer.min.js"></script>
    </form>
</body>
</html>
