$(document).ready(function () {
    $(".hotspot-action-select-class").change(function () {
        var selectedAction = $(this).children("option:selected").val();
        $('#object-select-container').hide();
        $('#scene-select-container').hide();
        $('#video-select-container').hide();

        if (selectedAction == "link") {
            $('#scene-select-container').show();
        } else if (selectedAction == "play" || selectedAction == "stop") {
            $('#video-select-container').show();
        } else {
            $('#object-select-container').show();
        }
    });
});

$('#AddHotSpotObjectAJAXbtn').click(function () {

    AddObject("HotSpotObject");
});