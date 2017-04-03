        if (json_text) {

  var json = JSON.parse(json_text);
            var features = json['features'];
            for (var i = 0; i < features.length; i++) {
                var X = features[i]['properties']['x'];
                var Y = features[i]['properties']['y'];
                var Value = features[i]['properties']['value'];
                var marker = new L.Marker(new L.LatLng(Y, X), { icon: TypeIcons[Value] });
                map.addLayer(marker);
                }