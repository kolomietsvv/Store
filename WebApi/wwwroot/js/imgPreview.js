﻿$(document).ready(function () {
    setImgPreview();
});

function setImgPreview() {
    $(document).on('change', '.btn-file :file', function() {
        var input = $(this), label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
        input.trigger('fileselect', [label]);
    });
    $('.btn-file :file').on('fileselect', function(event, label) {
        var input = $(this).parents('.input-group').find(':text'), log = label;
        if (input.length) {
            input.val(log);
        }
        else {
            if (log)
                ;
        }
    });
    function readURL(input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();
            reader.onload = function(e) {
                input.parentNode.querySelector("img[class='img-upload']").src = e.target.result;
            };
            reader.readAsDataURL(input.files[0]);
        }
    }
    $(".imgInp").change(function() {
        readURL(this);
    });
}
