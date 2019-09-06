$('.EditUserBtn').click(function () {

    $('#EditUserModal').on('show.bs.modal', function (e) {
        var getUserNameFromRow = $(e.relatedTarget).data('username');
        var getEmailFromRow = $(e.relatedTarget).data('email');
        var getFNameFromRow = $(e.relatedTarget).data('fname');
        var getLNameFromRow = $(e.relatedTarget).data('lname');

        $('#EditUserEmailInput').val(getEmailFromRow);
        $("#EditUserNameInput").val(getUserNameFromRow);
        $("#EditUserFirstNameInput").val(getFNameFromRow);
        $("#EditUserLastNameInput").val(getLNameFromRow);

    });
});

$('#UpdateUserBtn').on('click', function () {
    var url = "/Customer/UpdateUser";
    var Email = $("#EditUserEmailInput").val();
    var UserName = $("#EditUserNameInput").val();
    var FName = $("#EditUserFirstNameInput").val();
    var LName = $("#EditUserLastNameInput").val();

    $.post(url, { Email: Email, UserName: UserName, FirstName: FName, LastName: LName }, function (data) {

    });
});

$('.DeleteUserBtn').on('click', function () {
    $('#DeleteUserModal').on('show.bs.modal', function (e) {
        var getIdFromRow = $(e.relatedTarget).data('id');
        var getNameFromRow = $(e.relatedTarget).data('name');
        var details = "Are you sure you want to delete " + getNameFromRow + "?";


        $('#DeleteUserDetails').text(details);

        $('#deleteUserAjaxBtn').on('click', function () {
            $('#DeleteUserModal').modal('hide')
            var name = $('#delete-user-text').val();
            if (name == getNameFromRow) {

                var url = "/Customer/DeleteUser";

                $.post(url, { Id: getIdFromRow }, function (data) {
                    location.reload();
                });
            }
            else {
                alert("User's name does not match.");
            }


        });


    });

});


$(document).ready(function () {
    $('#users-table').DataTable();
});