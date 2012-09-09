/// <reference path="knockout-2.1.0.debug.js" />
/// <reference path="jquery-1.7.2-vsdoc.js" />

$(function () {

    var ajaxPlatformInfo = function () {
        $.ajax({
            url: "/PlatformInfo.ashx",
            success: function (data) {
                $("#totailGuests").text(data);
            },
            complete: function (data) {
                ajaxPlatformInfo();
            }
        });
    };
    ajaxPlatformInfo();

});
