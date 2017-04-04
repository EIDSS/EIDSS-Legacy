/*
// All maps types
LoadMap() // Global switch and load
LoadCheckboxes() // Toolbar buttons
InitializeMap() // Map + Instruments
ChangeAction(pAction) // Action (Measure, Info, etc)
StopAction(pAction)
ChangeLayer() // Change base layer (OSM, local)
PrintPageMode() // Hide toolbar
AddLabel(label_center, pText) // Value labels

// Pie type
LoadPie()
AddPiePopup(Id, X, Y)

// Marker type
LoadMarker()
DrawMarkerLegend(Types, MarkerUrl)

// Polygon type
LoadPolygon()
DrawLegendBlock(color, value)
GetHTMLColor(r, g, b) // #FFFFFF format
GetValueColor(min, max, start_color, end_color, value)
DrawGradientLegend(min, max, start_color, end_color, steps)
CheckColor(color) // [r, g, b] - check 0-255 range

// Point type
LoadPoint()
GetValueSize(min, max, start_size, end_size, value)
*/

//////////////////////////////////////////////////////////////////////////////////////////////////////////
function LoadMap() {
    if (map_type) {
        InitializeMap();
        LoadCheckboxes();

        if (!map_grad_style_json) { map_grad_style_json = "{}"; }
        if (!map_chart_style_json) { map_chart_style_json = "{}"; }

        if (map_gradLayerName == '') { map_gradLayerName = 'AVR Gradient layer'; }
        $('#legend').append("<div style='clear:both;padding:15px;'>" + map_gradLayerName + "</div>");

        LoadPoint();
        LoadPolygon();
        if (map_blnIsChart == 'True') { LoadPie(); }
        /*if (map_type == 'avr_pie') {LoadPie();}
		if (map_type == 'avr_poly') {LoadPolygon();}
		if (map_type == 'avr_point') {LoadPoint();}
		if (map_type == 'avr_marker') {LoadMarker();}*/
    }
    else { document.getElementById('map').style.display = 'none'; }
}

///////////////////////////////////////////////////////////////////////////////////////////////////////////
function LoadCheckboxes() {
    // Nice checkboxes
    $(document).ready(function () {
        $("#checkbox_layer").get(0).style.display = '';
        $("#checkbox_info").get(0).style.display = '';
        $("#checkbox_meas").get(0).style.display = '';
        $(".checkbox").dgStyle();
        $(".checkbox").dgCheck($("#checkbox_layer").get(0));
        $(".checkbox").dgCheck($("#checkbox_info").get(0));
        $(".checkbox").dgCheck($("#checkbox_meas").get(0));

        $("#map").css("cursor", "default");
    });
}

///////////////////////////////////////////////////////////////////////////////////////////////////////////
function InitializeMap() {
    // Country init
    var init_latlng = new L.LatLng(initial_latlng[0], initial_latlng[1]);
    var osm_url = 'http://b.tile.openstreetmap.org/{z}/{x}/{y}.png', osmAttribution = 'Map data &copy; 2011 OpenStreetMap contributors, Imagery &copy; 2011 CloudMade', osm_layer = new L.TileLayer(osm_url, { maxZoom: 18, attribution: osmAttribution });
    local_layer = new L.TileLayer(localUrl + "/{z}/{x}/{y}.png", { maxZoom: 18 });
    local_layer_label = new L.TileLayer(localUrlLabel + "/{z}/{x}/{y}.png", { maxZoom: 18 });

    map = new L.Map('map', { center: init_latlng, zoom: 5, layers: [osm_layer, local_layer, local_layer_label], closePopupOnClick: false });
    L.control.scale().addTo(map);
    map.on('click', function (e) { mapClick(e); });
}

///////////////////////////////////////////////////////////////////////////////////////////////////////////
function mapClick(e) {

    if (Action == "Info") {
        Action = '';
        $(".checkbox").dgCheck($("#checkbox_info").get(0));
        $.ajax({
            url: avrinfo_url + "?lon=" + e.latlng.lng + "&lat=" + e.latlng.lat, //
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
}

///////////////////////////////////////////////////////////////////////////////////////////////////////////
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
    else if (pAction == 'ChangeLayer') { ChangeLayer(); }
    else { Action = ''; SelectVet(); }
}

////////////////////////////////////////////////////
function StopAction(pAction) {
    if (pAction != 'Measure') { return; }
    if (MeasureLine) { map.removeLayer(MeasureLine); }
    MeasurePoints = new Array();
    $("#map_info_line").html('');

}

////////////////////////////////////////////////////
function ChangeLayer() {
    /*// Show/Hide on map local cache layer
	var LayerList = [local_layer, local_layer_label];
	var pCheck = $('#map_base_layer').get(0).checked;
	for (k in LayerList)
	{
		if (pCheck) {map.addLayer(LayerList[k]);}
		else {map.removeLayer(LayerList[k]);}
	}*/
    // var pCheck = $('#map_base_layer').get(0).checked; Style conflict / not work in popup
    if (!BaseLayer) {
        map.addLayer(local_layer);
        map.addLayer(local_layer_label);
        BaseLayer = 1;
    }
    else {
        map.removeLayer(local_layer);
        map.removeLayer(local_layer_label);
        BaseLayer = 0;
    }
}

////////////////////////////////////////////////////
function PrintPageMode() {
    window.print();

    /*var tool_dipslay = document.getElementById('map_toolbar').style.display;
    if (tool_dipslay == '') { document.getElementById('map_toolbar').style.display = 'none'; window.print(); }
    else { document.getElementById('map_toolbar').style.display = ''; }*/
}

////////////////////////////////////////////////////
function AddLabel(label_center, pText)
{ L.circleMarker(label_center, { color: "#000", radius: 1, opacity: 0, fillOpacity: 0 }).bindLabel(pText.toString(), { noHide: true, direction: 'right' }).addTo(map).showLabel(); }

///////////////////////////////////////////////////////////////////////////////////////////////////////////
function LoadPie() {
    var c_pie = 0;
    var barColors = ['#ffff66', '#ff6666', '#9999ff', '#66ff66', '#ff66ff', '#ff9633', '#ad5a00', '#8aceff', '#880015', '#999999', '#b4e61e', '#FF0000'];

    if (map_chart_style_json) {
        var map_chart_style = JSON.parse(map_chart_style_json);
        if (map_chart_style['BarCharts'] && map_chart_style['BarCharts'].length) {
            var i = 0;
            while (i < map_chart_style['BarCharts'].length && i < 12) {
                barColors[i] = map_chart_style['BarCharts'][i]["color"];
                i++;
            }
        }
    }

    $(document).ready(function () {
        var ticks = ['1'];
        var lseriesDefaults = { rendererOptions: { barWidth: 10 }, renderer: $.jqplot.BarRenderer, pointLabels: { show: true, edgeTolerance: -25 }, shadow: false };
        var laxesDefaults = { showTicks: false, showTickMarks: false };
        var lgrid = { drawGridLines: false, gridLineColor: '#FFFFFF', background: '#FFFFFF', shadow: false, borderWidth: 0 };
        var laxes = { xaxis: { renderer: $.jqplot.CategoryAxisRenderer, ticks: ticks } };

        var json = JSON.parse(json_text);
        var features = json['features'];
        if (!features[0]) { return; }

        var BarColumns = [];
        var BarColumnsName = [];
        var avr = JSON.parse(avr_json);
        var avr_col = avr['features'];
        for (var i = 0; i < avr_col.length; i++) // Get data to draw !!! features.length
        {
            if (avr_col[i]['properties']['blnIsChart'] == '1') {
                BarColumns.push(avr_col[i]['properties']['ColumnDescription']);
                BarColumnsName.push(avr_col[i]['properties']['ColumnDescription']);
            }
        }
        // for (var key in features[0]["properties"]) {if (key != 'id' && key != 'x' && key != 'y') {BarColumns.push(key);}}

        var vmin, vmax;
        var lColors = [];
        for (var i = 0; i < BarColumns.length; i++) { if (i < barColors.length) { lColors.push(barColors[i]); } }

        var Values = [];
        for (var i = 0; i < features.length; i++) {
            Values[i] = [];

            for (var col_index in BarColumns) {
                var bar_column = BarColumns[col_index];
                var value = features[i]['properties'][bar_column];

                if (c_pie) { Values[i].push([0, value]); }
                else { Values[i].push([value]); }

                if (vmin == null || value < vmin) { vmin = value; }
                if (vmax == null || value > vmax) { vmax = value; }
            }
            // Values[i].push([0]); Values[i].push([0]); // fix 
        }
        if (vmin > 0) { vmin = 0; }


        for (var i = 0; i < features.length; i++) // Get data to draw !!! features.length
        {
            var Id = features[i]['properties']['id'];
            var X = features[i]['properties']['x'];
            var Y = features[i]['properties']['y'];

            if (Id) {
                var is0 = 0;
                for (var j = 0; j < Values[i].length; j++) { is0 += Values[i][j]; }
                if (is0 != 0) //(features[i]['properties'][bar_column] == null)
                {
                    AddPiePopup(Id, X, Y);
                    if (c_pie) { $.jqplot(Id, [Values[i]], { seriesColors: lColors, seriesDefaults: { renderer: $.jqplot.PieRenderer, rendererOptions: { padding: 0, showDataLabels: true } }, legend: { show: false } }); }
                    else { $.jqplot(Id, Values[i], { seriesColors: lColors, seriesDefaults: lseriesDefaults, axesDefaults: laxesDefaults, grid: lgrid, axes: laxes }); }
                }
            }
        }
        DrawPieLegend(BarColumns, barColors, BarColumnsName);
    });
}

////////////////////////////////////////////////////
function DrawPieLegend(BarColumns, barColors, BarColumnsName) {
    var i = 0;
    if (map_chartLayerName == '') { map_chartLayerName = 'AVR Chart layer'; }
    $('#legend_grad').append("<div style='clear:both;padding:15px;'>" + map_chartLayerName + "</div>");
    for (j in BarColumns) {
        if (i > barColors.length || i > BarColumns.length) { return; }
        var color = barColors[i];
        $('#legend_grad').append("<div style='font-size:10px; clear:both; padding:5px;'><table><tr><td width='1%'><div class='map_legend' style='float:left; background-color:" + color + "'></td><td></div><div style='float:left;'>&nbsp;-&nbsp;" + BarColumnsName[i] + "</div></td></tr></table></div>");
        i++;
    }
}

////////////////////////////////////////////////////
function AddPiePopup(Id, X, Y) {
    var popup = new L.Popup({ closeButton: false });
    popup.setLatLng(new L.LatLng(Y, X));
    popup.setContent("<div id='" + Id + "' style='margin:-10px; width:250px; height:100px;'></div>");
    map.addLayer(popup);
}

///////////////////////////////////////////////////////////////////////////////////////////////////////////
function LoadMarker() {
    var Types = { "human": 0, "vet": 0, "vector": 0, "avian": 0, "livestock": 0 };

    var TypeIcons = {};
    var MarkerUrl = {};
    var LeafIcon = L.Icon.extend({ iconSize: new L.Point(25, 25), shadowSize: new L.Point(1, 1), iconAnchor: new L.Point(22, 94), popupAnchor: new L.Point(-3, -76) });

    var marker_url = base_url + '/Content/Images/MapMarkers/';
    if (MarkerSrc == 'DB') { var marker_url = base_url + '/Content/Images/MapMarkers/'; }
    else { MarkerIds = { "human": 1, "vet": 2, "vector": 3, "avian": 4, "livestock": 5 }; } // Reset if default

    for (k in MarkerIds) { MarkerUrl[k] = marker_url + MarkerIds[k] + ".png"; }
    for (k in MarkerUrl) { TypeIcons[k] = new LeafIcon({ iconUrl: MarkerUrl[k] }); }

    if (json_text) {
        var json = JSON.parse(json_text);
        var features = json['features'];
        for (var i = 0; i < features.length; i++) {
            var X = features[i]['properties']['x'];
            var Y = features[i]['properties']['y'];
            for (j in Types) { if (features[i]['properties'][j]) { var marker = new L.Marker(new L.LatLng(Y, X), { icon: TypeIcons[j] }); map.addLayer(marker); Types[j] = 1; } }
        }
        DrawMarkerLegend(Types, MarkerUrl);
    }
}

////////////////////////////////////////////////////
function DrawMarkerLegend(Types, MarkerUrl)
{ for (j in Types) { if (Types[j]) { $('#legend').append("<div style='clear:both; padding:5px;'><img src='" + MarkerUrl[j] + "'> - " + j + "</div>"); } } }

///////////////////////////////////////////////////////////////////////////////////////////////////////////
function LoadPolygon() {
    var json = JSON.parse(json_text);
    var features = json['features'];
    var default_color = '#559955';

    if (features.length && features[0]["geometry"]["type"] == "Point") { return; }

    var ValueColumn;
    var avr = JSON.parse(avr_json);
    var avr_col = avr['features'];
    for (var i = 0; i < avr_col.length; i++) // Get data to draw !!! features.length
    {
        if (avr_col[i]['properties']['blnIsGradient'] == '1') { ValueColumn = avr_col[i]['properties']['ColumnDescription']; }
    }


    var ValueList = [];
    var vmax, vmin, vavr = null;
    if (ValueColumn) {
        for (var i = 0; i < features.length; i++) {
            var Value = features[i]["properties"][ValueColumn];
            if (vmax == null || vmax < Value) { vmax = Value; }
            if (vmin == null || vmin > Value) { vmin = Value; }
            if (("#" + ValueList.join("#,#") + "#").search("#" + Value + "#") == -1) { ValueList.push(Value); }
        }
    }

    if (ValueList.length > 2) { vavr = 1; }

    var map_grad_style = JSON.parse(map_grad_style_json);
    if (map_grad_style["type"] == "gradient") {
        vmin = map_grad_style["min_value"];
        vmax = map_grad_style["max_value"];
        min_grad_color = map_grad_style["min_color"];
        max_grad_color = map_grad_style["max_color"];
    }

    if (map_grad_style["type"] == "graduated") // Predefined legend
    {
        for (var i = 0; i < map_grad_style["legend"].length; i++) {
            DrawLegendBlock(map_grad_style["legend"][i]["color"], map_grad_style["legend"][i]["title"]);
        }
    }
    else // Dynamic generated legend
    {
        // Draw legend
        if (!ValueColumn) { }
        else if (vmin == vmax) // only 1 value
        {
            DrawLegendBlock(GetHTMLColor(min_grad_color[0], min_grad_color[1], min_grad_color[2]), vmin);
        }
        else if (!vavr) // only 2 values - min & max
        {
            DrawLegendBlock(GetHTMLColor(min_grad_color[0], min_grad_color[1], min_grad_color[2]), vmin);
            DrawLegendBlock(GetHTMLColor(max_grad_color[0], max_grad_color[1], max_grad_color[2]), vmax);
        }
        else // 3 and more values, draw gradient
        {
            DrawGradientLegend(vmin, vmax, min_grad_color, max_grad_color, grad_step_count);
            /*ValueList.sort();
            for (var i = 0; i < ValueList.length; i++) {
                var color = GetValueColor(vmin, vmax, min_grad_color, max_grad_color, ValueList[i]);
                DrawLegendBlock(color, ValueList[i]);
            }*/
        }
    }


    // Paint regions
    for (var i = 0; i < features.length; i++) {
        if (features[i]["geometry"] != null) {
            var avr_color = features[i]["properties"]["color"];
            var Value = features[i]["properties"][ValueColumn];

            var value_color;
            if (avr_color) { value_color = avr_color; }
            else { value_color = GetValueColor(vmin, vmax, min_grad_color, max_grad_color, Value); }
            if (!ValueColumn && !value_color) { value_color = default_color; }

            features[i]["properties"]["style"] = { color: value_color, fillColor: value_color, fillOpacity: 0.5 };
            function onEachFeature(e, layer) { if (e.properties && e.properties.style && layer.setStyle) { layer.setStyle(e.properties.style); } }
            var geojsonLayer = new L.GeoJSON(features[i], { onEachFeature: onEachFeature });
            // if (Value) {AddLabel(geojsonLayer.getBounds().getCenter(), Value.toFixed(4));}
            map.addLayer(geojsonLayer);
            geojsonLayer.on('click', function (e) { mapClick(e); });
        }
    }
}

//////////////////////////////////////////////////////////////////////
function DrawLegendBlock(color, value) {
    if (left2right > 0)
    { $('#legend').append("<div style='clear:both; padding:5px;'><table><tr><td align='right'>" + value + "&nbsp;-&nbsp;</td><td width='1%'><div class='map_legend' style='float:right; background-color:" + color + "'></div></td></tr></table></div>"); }
    else
    { $('#legend').append("<div style='clear:both; padding:5px;'><table><tr><td width='1%'><div class='map_legend' style='float:left; background-color:" + color + "'></div></td><td><div style='float:left;'>&nbsp;-&nbsp;" + value + "</div></td></tr></table></div>"); }

}

//////////////////////////////////////////////////////////////////////
function DrawSymbolBlock(symbol, value) {
    if (left2right > 0)
    { $('#legend').append("<div style='clear:both; padding:5px;'><table><tr><td align='right'>" + value + "&nbsp;-&nbsp;</td><td width='1%'><img src='" + symbol + "'></div></td></tr></table></div>"); }
    else
    { $('#legend').append("<div style='clear:both; padding:5px;'><table><tr><td width='1%'><img src='" + symbol + "'></div></td><td><div style='float:left;'>&nbsp;-&nbsp;" + value + "</div></td></tr></table></div>"); }
}

//////////////////////////////////////////////////////////////////////
function GetHTMLColor(r, g, b) {
    r = CheckColor(r); g = CheckColor(g); b = CheckColor(b);
    var r_color = r < 16 ? '0' + r.toString(16) : r.toString(16);
    var g_color = g < 16 ? '0' + g.toString(16) : g.toString(16);
    var b_color = b < 16 ? '0' + b.toString(16) : b.toString(16);
    return '#' + r_color + g_color + b_color;
}

//////////////////////////////////////////////////////////////////////
function GetValueColor(min, max, start_color, end_color, value) {
    var r, g, b, dr, dg, db;
    r = start_color[0];
    g = start_color[1];
    b = start_color[2];

    var width = max - min;
    if (width) {
        dr = (end_color[0] - r) / width;
        dg = (end_color[1] - g) / width;
        db = (end_color[2] - b) / width;

        r = r + dr * (value - min);
        g = g + dg * (value - min);
        b = b + db * (value - min);
    }
    return GetHTMLColor(r, g, b);
}

//////////////////////////////////////////////////////////////////////
function DrawGradientLegend(min, max, start_color, end_color, steps) {
    var width = max + Math.abs(min);
    var step = width / steps;

    var min_height = parseInt(120 / ((max - min) / step), 10);

    $('#legend').append("<div style='text-align:left; font-size:16px;'>" + min + "</div>");
    for (var i = min; i <= max; i += step) {
        var color = GetValueColor(min, max, start_color, end_color, i);
        $('#legend').append("<div style='width:55px;height:" + min_height + "px;background-color:" + color + ";'></div>");
    }
    $('#legend').append("<div style='text-align:left; font-size:16px;'>" + max + "</div>");
}

//////////////////////////////////////////////////////////////////////
function CheckColor(color) {
    if (color < 0) { color = 0; }
    if (color > 255) { color = 255; }
    return parseInt(color);
}

///////////////////////////////////////////////////////////////////////////////////////////////////////////
function LoadPoint() {
    var json = JSON.parse(json_text);
    var features = json['features'];

    if (features.length && features[0]["geometry"]["type"] != "Point") { return; }

    var ValueColumn = map_ColumnName;
    var vmax, vmin, vavr = null;
    for (var i = 0; i < features.length; i++) {
        var Value = features[i]["properties"][ValueColumn];
        if (vmax == null || vmax < Value) { vmax = Value; }
        if (vmin == null || vmin > Value) { vmin = Value; }
        if (!vavr && vmin < Value && Value < vmax) { vavr = 1; }
    }

    var map_grad_style = JSON.parse(map_grad_style_json);
    if (map_grad_style["type"] == "gradient") {
        min_grad_color = map_grad_style["min_color"];
        max_grad_color = map_grad_style["max_color"];
    }

    if (map_grad_style["type"] == "graduated") // Predefined legend
    {
        for (var i = 0; i < map_grad_style["legend"].length; i++) {
            var l_color = map_grad_style["legend"][i]["color"];
            var l_symbol = map_grad_style["legend"][i]["symbol"];
            var avr_symbol_url = "/en-KA-Eidss/Map/AvrSymbol/"

            if (l_symbol > 0) {
                DrawSymbolBlock(avr_symbol_url + l_symbol, map_grad_style["legend"][i]["title"]);
            }
            else {
                DrawLegendBlock(map_grad_style["legend"][i]["color"], map_grad_style["legend"][i]["title"]);
            }

        }
    }
    else // Dynamic generated legend
    {
        // Draw legend
        if (vmin == vmax) // only 1 value
        {
            DrawLegendBlock(GetHTMLColor(min_grad_color[0], min_grad_color[1], min_grad_color[2]), vmin);
        }
        else {
            DrawLegendBlock(GetHTMLColor(min_grad_color[0], min_grad_color[1], min_grad_color[2]), vmin);
            DrawLegendBlock(GetHTMLColor(max_grad_color[0], max_grad_color[1], max_grad_color[2]), vmax);
        }
    }

    /* Gradient legend disabled + else if (!vavr) {..} else {DrawGradientLegend(vmin, vmax, min_grad_color, max_grad_color, grad_step_count);} */

    // Paint points
    for (var i = 0; i < features.length; i++) {
        if (features[i]["geometry"] != null) {
            var avr_color = features[i]["properties"]["color"];
            var avr_symbol = features[i]["properties"]["symbol"];
            var Value = features[i]["properties"][ValueColumn];
            var value_color;
            if (avr_color) { value_color = avr_color; }
            else { value_color = GetValueColor(vmin, vmax, min_grad_color, max_grad_color, Value); }
            var value_size = GetValueSize(vmin, vmax, 5, 15, Value);

            var X = features[i]['properties']['x'];
            var Y = features[i]['properties']['y'];

            if (avr_symbol > 0) {
                var symbol_url = "/en-KA-Eidss/Map/AvrSymbol/" + avr_symbol;
                var myIcon = L.icon({ iconUrl: symbol_url, iconSize: [30, 30] });
                L.marker([Y, X], { icon: myIcon }).addTo(map);
            }
            else {
                var circleLocation = new L.LatLng(Y, X);
                var circleOptions = { color: value_color, fillColor: value_color, fillOpacity: 0.5, radius: 1 }; // HARDCORE value_size
                var circle = new L.CircleMarker(circleLocation, circleOptions);
                map.addLayer(circle);

            }
            // AddLabel(circleLocation, Value); WORKS BUT DISABLED
        }
    }
}

//////////////////////////////////////////////////////////////////////
function GetValueSize(min, max, start_size, end_size, value) {
    var width = max + Math.abs(min);
    dsize = (end_size - start_size) / width;
    var size = start_size + dsize * value;
    if (size > end_size) { size = end_size; }
    return size;
}

/*
////////////////////////////////////////////////////////////////////////////////////////////////////// OLD TO DEL

function LoadPie()
{
	// Input params
	c_pie = 0;
	c_type = 'type';
	c_value = 'value';
	type_colors = {"1": "#b5e61d", "2": "#ed1c24", "4": "#fff200", "8": "#FFFF00", "16": "#694132"};

	$(document).ready(function () {

		var PieInfo = new Object();
		var json = JSON.parse(json_text);
		var features = json['features'];

		for (var i = 0; i < features.length; i++) // Get data to draw
		{
			var Id = features[i]['properties']['id'];
			var X = features[i]['properties']['x'];
			var Y = features[i]['properties']['y'];
			var Type = features[i]['properties'][c_type];
			var Value = features[i]['properties'][c_value];

			if (!PieInfo[Id]) {PieInfo[Id] = {}; AddPiePopup(Id, X, Y);}
			PieInfo[Id][Type] = Value;
		}

		var ticks = ['1'];
		var lseriesDefaults = {rendererOptions: {barWidth: 30}, renderer: $.jqplot.BarRenderer, pointLabels: {show: true, edgeTolerance: -25}, shadow: false};
		var laxesDefaults = {showTicks: false, showTickMarks: false};
		var lgrid = {drawGridLines: false, gridLineColor: '#FFFFFF', background: '#FFFFFF', shadow: false, borderWidth: 0};
	 	var laxes = {xaxis: { renderer: $.jqplot.CategoryAxisRenderer, ticks: ticks}};


		for (var key in PieInfo) // Set data in pie control
		{
			var Values = new Array();
			var lColors = new Array();
			for (var cse in PieInfo[key])
			{
				if (c_pie) {Values.push([0, PieInfo[key][cse]]);}
				else {Values.push([PieInfo[key][cse]]);}
				lColors.push(type_colors[cse]);
			}
			if (c_pie) {$.jqplot (key, [Values], {seriesColors: lColors, seriesDefaults: {renderer: $.jqplot.PieRenderer, rendererOptions: {padding: 0,showDataLabels: true}}, legend: {show:false}});}
			else {$.jqplot(key, Values, {seriesColors: lColors, seriesDefaults: lseriesDefaults, axesDefaults: laxesDefaults, grid: lgrid, axes: laxes});}
		}
	});
}
*/