var chartForm = (function() {
    return {
        chartExport: function () {
            var img = document.getElementById('chart');
            var text = img.src.replace('image/jpg', 'image/octet-stream');

            var pom = document.createElement('a');
            pom.setAttribute('href', text);
            pom.setAttribute('download', "image.jpg");
            pom.click();
        },

        chartPrint: function () {
            window.print();
            /*var toPrint = $('#imgPlace');
            var width = toPrint.width();
            var height = toPrint.height()+10;
            var popupWin = window.open('', '_blank', 'width=' + width + ',height=' + height + ',location=no,left=200px');
            popupWin.document.open();
            popupWin.document.write('<html><title>::Preview::   ' + window.document.title + '</title></head><body onload="window.print()">')
            popupWin.document.write(toPrint[0].innerHTML);
            popupWin.document.write('</html>');
            popupWin.document.close();*/
        },

        onChartTypeChanged: function (s, e) {
            $("body").css("cursor", "progress");
            var width = $('#imgPlace').width() - 10;
            if (width === undefined || width == null || width < 600) width = 600;
            var height = $('#imgPlace').height() - 3;
            if (height === undefined || height == null || height < 600) height = 600;
            $.ajax({
                url: avrUrls.getChartTypeChangedUrl(),
                dataType: 'json',
                type: 'POST',
                data: {
                    layoutId: document.forms[0].LayoutId.value,
                    value: s.GetValue(),
                    width: width,
                    height: height
                },
                success: function (data) {
                    $("body").css("cursor", "default");
                    if (data.result == 'success') {
                        $('#chart')[0].src = "data:image/jpg;base64," + data.text;
                        $('#chart')[0].className = '';
                    } else {
                        alert(data.text);
                    }
                }

            });
        }

    }
})();
