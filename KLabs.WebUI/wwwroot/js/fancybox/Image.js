var myDropzone;
$('#imagezone').dropzone({
    autoProcessQueue: false,
    uploadMultiple: true,
    parallelUploads: 1,
    url: $('#' +
        'imagezone' +
        '').attr('action'), // Set the url for your upload script location
    paramName: "image", // The name that will be used to transfer the file
    maxFiles: 1,
    maxFilesize: 10, // MB
    previewsContainer: '#dropzonePreview',
    addRemoveLinks: true,
    acceptedFiles: "image/*",
    init: function (e) {

        myDropzone = this;

        this.element.querySelector("button[type=submit]").addEventListener("click", function (e) {
            // Make sure that the form isn't actually being sent.

            e.preventDefault();
            e.stopPropagation();

            var $form = $('#imagezone');


            if (!$form.valid()) {

                return;
            }


            $('#loading').show();

            if (myDropzone.files.length > 0) {
                myDropzone.processQueue();
            } else {
                $form.submit();
            }
        });

        this.on("success",
            function (file, responseText) {
                
                $('#loading').hide();
                if (responseText.Success) {
                    toastr.info(responseText.Message);
                    $('#basicmodal').modal('hide');
                    return;
                }
                toastr.error(responseText.Message);
            });

    }
});
function deleteImage(item) {
    var redirect = $(item).data('href');
    var message = $(item).data('message');
    var remove = $(item).data('remove-index');
    swal.fire({
        "title": "Silme İşlemi",
        "text": message,
        "type": "success",
        "showCloseButton": true,
        "showCancelButton": true,
        "focusConfirm": false,
        "confirmButtonText":
            '<i class="fa fa-thumbs-up"></i> Sil !',
        "confirmButtonAriaLabel": 'Sil',
        "cancelButtonText":
            '<i class="fa fa-thumbs-down"></i> İptal',
        "cancelButtonAriaLabel": 'İptal Et'

    }).then((result) => {
        if (result.value) {
            $.ajax({
                dataType: 'Json',
                type: 'get',
                url: redirect,
                beforeSend: function () {
                    $('#loading').show();
                },
                success: function (data) {
                    $('#loading').hide();
                    if (data.Success) {

                        $('#' + remove).remove();
                        toastr.info(data.Message);
                        return;
                    }
                    toastr.error(data.Message);
                }
            });
        }
    });
}
