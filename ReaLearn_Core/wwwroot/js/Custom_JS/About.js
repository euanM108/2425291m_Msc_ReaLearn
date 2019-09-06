$('#submit-btn').click(function () {
    this.attr('disabled', 'disabled');
    $('#submit-btn').attr("src", "~/images/svg/check.svg");
});
