 $(document).ready(function () {
            var PieInfo = new Object();
            var json = JSON.parse(json_text);
            var features = json['features'];
	        for (var i = 0; i < features.length; i++) {
	            var Id = features[i]['properties']['id'];
	            var X = features[i]['properties']['x'];
	            var Y = features[i]['properties']['y'];
	            var Type = features[i]['properties']['type']; Type = i; //TODEL
	            var Value = features[i]['properties']['value'];
	            if (!PieInfo[Id]) {
	                PieInfo[Id] = new Object();
	                PieInfo[Id][Type] = Value;
	                var popup = new L.Popup();
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
	            for (var cse in PieInfo[key]) { Values.push([cse, PieInfo[key][cse]]); }
	            var plot1 = $.jqplot(key, [Values], {
	                gridPadding: { top: 0, bottom: 0, left: 0, right: 0 },
	                seriesDefaults: { renderer: $.jqplot.PieRenderer, trendline: { show: false }, rendererOptions: { padding: 2, showDataLabels: true, dataLabels: 'value' }
	                }
	            });
	        }
	    });
        }