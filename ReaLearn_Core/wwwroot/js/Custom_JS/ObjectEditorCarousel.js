// CAROUSEL METHODS ====================================================================================================================================================================================

$("#object-filter").change(function () {

    var i = $('#object-filter option:selected').val();

    $('.property-card-VideoObject').hide();
    $('.property-card-ImageObject').hide();
    $('.property-card-HotSpotObject').hide();
    $('.property-card-TextObject').hide();
    $('.property-card-AudioObject').hide();
    $('.property-card-QuestionObject').hide();
    $('.property-card-' + i).show();

    if (i == "All") {
        $('.property-card-VideoObject').show();
        $('.property-card-ImageObject').show();
        $('.property-card-HotSpotObject').show();
        $('.property-card-TextObject').show();
        $('.property-card-AudioObject').show();
        $('.property-card-QuestionObject').show();
    }
});