var notification = (function () {

    var timeOfGetStatus = 0;

    function getReplicationStatus() {
        var url = bvUrls.getGetReplicationStatusUrl();
        $.bvGet(url, null, true, function(data) {
            if (data.isFinished) {
                var notification = $("#notification").data("kendoNotification");
                for (var item in data.messages) {
                    notification.show({
                        message: data.messages[item].message,
                        messageDateTime: data.messages[item].messageDateTime
                    }, "replication");
                }
            } else {
                setTimeout(getReplicationStatus, timeOfGetStatus);
            }
        }, function() {
            setTimeout(getReplicationStatus, timeOfGetStatus);
        });
    }

    return {
        replicateData: function(timeout) {
            var url = bvUrls.getRequestReplicationUrl();
            $.bvPost(url, null, null, null);

            timeOfGetStatus = timeout * 1000;
            setTimeout(getReplicationStatus, timeOfGetStatus);
        },
    };
})();