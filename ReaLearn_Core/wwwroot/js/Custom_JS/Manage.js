
$('.EditCourseBtn').click(function () {
    $('#EditCourseModal').on('show.bs.modal', function (e) {
        var courseIdFromRow = $(e.relatedTarget).data('id');
        var courseNameFromRow = $(e.relatedTarget).data('name');
        var courseDescriptionFromRow = $(e.relatedTarget).data('description');

        $('#EditCourseIdInput').val(courseIdFromRow);
        $("#EditTitleInput").val(courseNameFromRow);
        $("#EditDescriptionInput").val(courseDescriptionFromRow);

    });
});

$('#UpdateCourseBtn').unbind().on('click', function () {
    var ID = $('#EditCourseIdInput').val();
    var Name = $("#EditTitleInput").val();
    var Description = $("#EditDescriptionInput").val();
    $('#course-row-name-' + ID).val(Name);
    if (Name != "" && Description != "") {

        var url = "/Course/UpdateCourse";

        $.post(url, { Id: ID, Name: Name, Description: Description }, function (data) {
            
        });
    } else {
        alert("Name and description cannot be empty");
    }
});

$('.AssignCourseModalBtn').unbind().on('click', function () {

    $('#AssignCourseModal').on('show.bs.modal', function (e) {
        $('.isAssignedCheckboxClass').prop('checked', false);

        var courseIdFromRow = $(e.relatedTarget).data('id');
        var courseNameFromRow = $(e.relatedTarget).data('name');

        var details = "Assign " + courseNameFromRow + " (id:" + courseIdFromRow + ") ";

        $('#AssignCourseDetails').text(details);
        $('.courseRowName').text(courseNameFromRow);

        var url = "/Course/GetAssignedUsers";

        $.get(url, { courseId: courseIdFromRow }, function (data) {
            $(data).each(function () {
                $('#isAssigned-' + this).prop('checked', true);
            });
        });


        $('#UpdateCoursesAssignedToUsers').unbind().on('click', function () {
            $('#AssignCourseToUserTable > tbody  > tr').each(function () {
                var userId = $(this).attr('data-id');
                var isAssigned = $('#isAssigned-' + userId).is(":checked");

                var _url = "/Course/AssignCourseToUser"
                $.post(_url, { courseId: courseIdFromRow, userId: userId, isAssigned: isAssigned }, function (data) {


                });

            });
        });

    });

});




$(document).ready(function () {
    $('#courses-table').DataTable();

});