// VR EDIT METHODS ====================================================================================================================================================================================
function ReplaceImage(objectId) {
    var formData = new FormData();
    formData.append('file', $('#replaceFile-' + objectId)[0].files[0]); // myFile is the input type="file" control
    formData.append('objectId', objectId);
    var url = "/SceneEditor/ReplaceImage";
    postAndUpdate(url, formData);
}

function ReplaceImagePreview(id, input) {
    if (input.files && input.files[0]) {
        var ImageDir = new FileReader();
        ImageDir.onload = function (e) {
            var ID = "#img-" + id;
            var el = document.querySelector(ID);
            el.setAttribute('src', e.target.result)
        }

        ImageDir.readAsDataURL(input.files[0]);

        ReplaceImage(id);
    }
}

function UpdateResponses(id) {

    $('.response').each(function (i, obj) {
        if ($(this).attr("data-id") == id) {

            var responseId = this.id;
            var response = $('#' + this.id).val();
            var formData = new FormData();
            formData.append('responseId', responseId);
            formData.append('responseText', response);
            var url = "/SceneEditor/UpdateResponse";
            postNoPostback(url, formData);
        }

    });



}


function ReplaceMedia(objectId, objectType) {
    var formData = new FormData();
    formData.append('file', $('#replaceFile-' + objectId)[0].files[0]);
    formData.append('objectId', objectId);

    if (objectType == "ImageObject") {
        var url = "/SceneEditor/ReplaceImage";
    }
    postNoPostback(url, formData);
}

function ReplaceMediaPreview(id, input, objectType) {
    if (input.files && input.files[0]) {

        var DIR = new FileReader();
        DIR.onload = function (e) {

            if (objectType == "ImageObject") {
                var ID = "#img-" + id;
            }
            else if (objectType == "VideoObject") {
                var ID = "#vid-" + id;
            }

            var el = document.querySelector(ID);
            el.setAttribute('src', e.target.result)
        }
        DIR.readAsDataURL(input.files[0]);
        ReplaceMedia(id, objectType);
    }
}


// ADD OBJECTS

$('#AddTextObjectAJAXbtn').click(function () {
    AddObject("TextObject");
});

$('#AddQuestionObjectAJAX').click(function () {
    AddObject("QuestionObject");
});

$('#VideoObjectFile').change(function () {
    AddObject("VideoObject");
    $('#addVideoModal').modal('hide');
    alert('Please note, as the application has been designed with deployment in mind. Media files do not work unless the course is exported. This is due to the author following good practice and not storing media in the solution. Instead, the assets are stored to the C:/ where the location directory can be changed to an appropriate server.')
});


$('#ImageObjectFile').change(function () {
    AddObject("ImageObject");
    $('#addImageModal').modal('hide');
});

$('#AudioObjectFile').change(function () {
    AddObject("AudioObject");
    $('#addAudioModal').modal('hide');
    alert('Please note, as the application has been designed with deployment in mind. Media files do not work unless the course is exported. This is due to the author following good practice and not storing media in the solution. Instead, the assets are stored to the C:/ where the location directory can be changed to an appropriate server.')

});
// UPDATE VR OBJECT PROPERTIES IN DATBASE
function UpdateVRObject(objectId, type) {

    var colour = $("#colour-" + objectId).val();

    if (type == "TextObject") {
        var ID = "#text-" + objectId;
        var el = document.querySelector(ID);
        colour = el.getAttribute('text').color;
    }
    else if (type == "ImageObject") {
        var ID = "#img-" + objectId;
        var el = document.querySelector(ID);
        colour = el.getAttribute('color');
    }
    else if (type == "VideoObject") {
        var ID = "#vid-" + objectId;
        var el = document.querySelector(ID);
        colour = el.getAttribute('color');
    }
    else if (type == "AudioObject") {
        var ID = "#audio-" + objectId;
        var el = document.querySelector(ID);
        colour = el.getAttribute('color');
    }
    else if (type == "QuestionObject") {
        var ID = "#question-" + objectId;
        var el = document.querySelector(ID);
        colour = "#FFFFFF";
    }

    var xPos = $("#xPos-" + objectId).val();
    var yPos = $("#yPos-" + objectId).val();
    var zPos = $("#zPos-" + objectId).val();

    if (type == "HotSpotObject") {
        var ID = "#hotspot-text-" + objectId;
        var el = document.querySelector(ID);
        var value = $("#hotspot-object-select-update-" + objectId).children("option:selected").val();
    }
    else {
        var xScale = $("#xScale-" + objectId).val();
        var yScale = $("#yScale-" + objectId).val();
        var zScale = $("#zScale-" + objectId).val();

        var xRot = el.getAttribute('rotation').x;
        var yRot = el.getAttribute('rotation').y;
        var zRot = el.getAttribute('rotation').z;
        var value = $("#value-" + objectId).val();
    }

    var url = "/SceneEditor/UpdateVRObject";

    $.post(url, { vrObjectId: objectId, xRot: xRot, yRot: yRot, zRot: zRot, xPos: xPos, yPos: yPos, zPos: zPos, xScale: xScale, yScale: yScale, zScale: zScale, value: value, colour: colour }, function (data) {

    });
}

// DELETE VR OBJECT
function DeleteVRObject(id, type) {
    var ID = getObjectInScene(id, type);
    var el = document.querySelector(ID);

    document.getElementById('property-card-' + id).style.display = "none";
    el.setAttribute('visible', 'false');

    var formData = new FormData();
    formData.append('objectId', id);

    var url = "/SceneEditor/DeleteVRObject";

    postAndUpdate(url, formData);
}



// COLOUR CHANGE ====================================================================================================================
function ChangeColour(id, type) {
    var value = $("#colour-" + id).val();
    if (type == "TextObject") {
        var ID = "#text-" + id;
        var el = document.querySelector(ID);
        el.setAttribute('text', 'color', value);
    }
    else if (type == "ImageObject") {
        var ID = "#img-" + id;
        var el = document.querySelector(ID);
        el.setAttribute('color', value);
    }
    else if (type == "VideoObject") {
        var ID = "#vid-" + id;
        var el = document.querySelector(ID);
        el.setAttribute('color', value);
    }
    else if (type == "HotSpotObject") {
        var ID = "#hotspot-text-" + id;
        var el = document.querySelector(ID);
        el.setAttribute('text', 'color', value);
    }
}


// CHANGE FONT SIZE ====================================================================================================================
function ChangeFontSize(id, type) {
    var ID = "#text-" + id;

    var value = $("#xScale-" + id).val();
    var el = document.querySelector(ID);

    el.object3D.scale.x = value;
    el.object3D.scale.y = value;
}

function ChangeHotSpotSize(id, type) {
    var ID = "#hotspot-text-" + id;

    var value = $("#xScale-" + id).val();
    var el = document.querySelector(ID);

    el.object3D.scale.x = value;
    el.object3D.scale.y = value;
}


function ChangePosition(id, type, axis) {
    var ID = getObjectInScene(id, type);
    var el = document.querySelector(ID);

    var value = $("#" + axis + "Pos-" + id).val();
    if (axis == 'x') { el.object3D.position.x = value; }
    else if (axis == 'y') { el.object3D.position.y = value; }
    else if (axis == 'z') { el.object3D.position.z = value; }
}

// CHANGE SCALE
function ChangeScale(id, type, axis) {
    var ID = getObjectInScene(id, type);
    var el = document.querySelector(ID);
    if (axis == 'x') {
        var value = $("#xScale-" + id).val();
        el.object3D.scale.x = value;
    } else if (axis == 'y') {
        var value = $("#yScale-" + id).val();
        el.object3D.scale.y = value;
    }

}

// CHANGE POSITION ====================================================================================================================

function ChangeRotation(rotationValues, el) {
    var x = el.getAttribute('rotation').x + THREE.Math.radToDeg(rotationValues.x);
    var y = el.getAttribute('rotation').y + THREE.Math.radToDeg(rotationValues.y);
    el.object3D.rotation.set(
        THREE.Math.degToRad(x),
        THREE.Math.degToRad(y),
        THREE.Math.degToRad(0)
    );
}

// CHANGE VALUE  ====================================================================================================================
function ChangeValue(id, type) {
    if (type == "TextObject") {
        var ID = "#text-" + id;
        var value = $("#value-" + id).val();
        var el = document.querySelector(ID);
        el.setAttribute('text', 'value', value);


    }
    if (type == "QuestionObject") {
        var ID = "#question-text-" + id;
        var value = $("#value-" + id).val();
        var el = document.querySelector(ID);
        el.setAttribute('text', 'value', value);

    }
}

function getObjectInScene(id, type) {
    if (type == "TextObject") {
        var ID = "#text-" + id;
    }
    else if (type == "ImageObject") {
        var ID = "#img-" + id;
    }
    else if (type == "VideoObject") {
        var ID = "#vid-" + id;
    }
    else if (type == "HotSpotObject") {
        var ID = "#hotspot-" + id;
    }
    else if (type == "AudioObject") {
        var ID = "#audio-" + id;
    } else if (type == "QuestionObject") {
        var ID = "#question-" + id;
    }
    return ID;
}



