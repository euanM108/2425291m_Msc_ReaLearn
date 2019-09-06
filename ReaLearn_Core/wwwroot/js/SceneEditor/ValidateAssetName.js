//VALIDATION
$('.model-opener').click(function () {

    $('#AddTextObjectAJAXbtn').prop("disabled", true);
    $('#ImageObjectFile').prop("disabled", true);
    $('#VideoObjectFile').prop("disabled", true)
    $('#AudioObjectFile').prop("disabled", true);
    $('#AddHotSpotObjectAJAXbtn').prop("disabled", true)
});

$('#AddTextAssetNameAJAX, #AddTextObjectAJAX').on("keyup", textObjectValidate);

function textObjectValidate() {
    if ($('#AddTextAssetNameAJAX').val().length > 0 && $('#AddTextObjectAJAX').val().length > 0) {
        $('#AddTextObjectAJAXbtn').prop("disabled", false);
    } else {
        $('#AddTextObjectAJAXbtn').prop("disabled", true);
    }
}

// IMAGE OBJECT VALIDATION
$('#AddImageAssetNameAJAX').on("change", imageObjectValidate);

function imageObjectValidate() {
    if ($('#AddImageAssetNameAJAX').val().length > 0) {
        $('#ImageObjectFile').prop("disabled", false);
        $('.InputErrorMessage').hide();
    } else {
        $('#ImageObjectFile').prop("disabled", true);
        $('.InputErrorMessage').show();
    }
}
// Video OBJECT VALIDATION
$('#AddVideoAssetNameAJAX').on("change", videoObjectValidate);

function videoObjectValidate() {
    if ($('#AddVideoAssetNameAJAX').val().length > 0) {
        $('#VideoObjectFile').prop("disabled", false);
        $('.InputErrorMessage').hide();
    } else {
        $('#VideoObjectFile').prop("disabled", true);
        $('.InputErrorMessage').show();
    }
}

$('#AddAudioAssetNameAJAX').on("change", audioObjectValidate);

function audioObjectValidate() {
    if ($('#AddAudioAssetNameAJAX').val().length > 0) {
        $('#AudioObjectFile').prop("disabled", false);
        $('.InputErrorMessage').hide();
    } else {
        $('#AudioObjectFile').prop("disabled", true);
        $('.InputErrorMessage').show();
    }
}

// HOTSPOT VALIDATION
$('#hotspot-action-select, #hotspot-onlook, #hotspot-onclick').on("change", hotspotObjectValidate);
$('#AddHotspotAssetNameAJAX, #hotspot-object-select, #hotspot-scene-select, #hotspot-object-select').on("keyup", hotspotObjectValidate);

function hotspotObjectValidate() {
    if ($('#AddHotspotAssetNameAJAX').val().length > 0 && $('#hotspot-action-select').children("option:selected").val() != 'null' && ($("#hotspot-onclick").is(":checked") || $("#hotspot-onlook").is(":checked"))) {
        $('#AddHotSpotObjectAJAXbtn').prop("disabled", false);
    } else {
        $('#AddHotSpotObjectAJAXbtn').prop("disabled", true);
    }
}