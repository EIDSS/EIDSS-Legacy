var upFile = (function () {
    return {
        showDialog: function () {
            $("#errorMessageSpan").hide();
            bvPopup.showDefault(bvUrls.getUploadFileUrl(), EIDSS.BvMessages['uploadFile'], '', 700, 290, false);
        },

   
        onFileUpload: function (fileUpload) {
            $("#errorMessageSpan").hide();
            document.UploadForm.submit();
            bvPopup.closeDefaultPopup();
            //var contentData = bvPopup.getDefaultWindowData();
            //$.ajax({
            //    url: bvUrls.getSetGeoLocationUrl(),
            //    dataType: "json",
            //    type: "GET",
            //    data: {
            //        formData: contentData
            //    },
            //    success: function (data) {
            //        var hasError = formRefresher.hasError(data);
            //        formRefresher.updateControls(data);
            //        if (!hasError) {
            //            bvPopup.closeDefaultPopup();
            //        }
            //    },
            //    error: function () {
            //        bvPopup.closeDefaultPopup();
            //    }
            //});
        },


    };
})();
