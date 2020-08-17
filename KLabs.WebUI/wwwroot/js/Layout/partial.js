$(document).ready(function () {
    
    $('.partial-item').each(function (index, item) {
        var url = getBaseUrl() + $(item).data('url');
        if (url && url.length > 0) {
            $(item).load(url,
                function (response) {
                    $(item).replaceWith(response);

                });
        }
    });
    setTooltips();
});

function setTooltips() {
    $('[data-original-title]').tooltip();
    $('.bs-tooltip-bottom').remove();
}


function getBaseUrl() {
    var getUrl = window.location;
    return getUrl.protocol + "//" + getUrl.host ;
}

function JsItemGridRefresh(item, gridIds) {
    var redirect = $(item).data('href');
    var message = $(item).data('message');
    swal.fire({
        "title": "Silmeİşlemi",
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
                url: redirect,
                dataType: "json",
                success: function (data) {
                    if (data.Success) {
                        $.each(gridIds.split(','),
                            function(index, item) {
                                $("#" + item).dxDataGrid("instance").refresh();
                            });
                        

                    } else {
                        swal.fire({
                            "title": "Hata",
                            "text": data.Message,
                            "type": "error",
                            "showCloseButton": true,
                            "confirmButtonText":
                                'Kapat',
                            "confirmButtonAriaLabel": 'Kapat'
                        });
                    }
                }
            });

        }
    });
}




function deleteItem(item) {
    var redirect = $(item).data('href');
    var message = $(item).data('message');
    swal.fire({
        "title": "İşlem Doğrulama",
        "text": message,
        "type": "success",
        "showCloseButton": true,
        "showCancelButton": true,
        "focusConfirm": false,
        "confirmButtonText":
            '<i class="fa fa-thumbs-up"></i> Onayla !',
        "confirmButtonAriaLabel": 'Onayla',
        "cancelButtonText":
            '<i class="fa fa-thumbs-down"></i> İptal',
        "cancelButtonAriaLabel": 'İptal Et'

    }).then((result) => {
        if (result.value) {
            window.location.href = redirect;
        }
    });
}

function FillBasicModal(item) {
    $('#loading').css('display', 'block');

    $.get($(item).data('fill-url'), function (data) {
        $('#basicmodalcontent').children('div').remove();
        $('#basicmodalcontent').append(data);
    })
        .done(function () {
            $("#basicmodal").modal("show");
        })
        .fail(function () {
            swal.fire({
                "title": "Hata",
                "text": "İşlem Sırasında Hata Oluştu Lütfen Tekrar Deneyin.",
                "type": "error",
                "showCloseButton": true,
                "confirmButtonText":
                    'Kapat',
                "confirmButtonAriaLabel": 'Kapat'
            });
        })
        .always(function () {
            $('#loading').css('display', 'none');
        });


}


function dataURItoBlob(dataURI) {
    'use strict'
    var byteString,
        mimestring

    if (dataURI.split(',')[0].indexOf('base64') !== -1) {
        byteString = atob(dataURI.split(',')[1])
    } else {
        byteString = decodeURI(dataURI.split(',')[1])
    }

    mimestring = dataURI.split(',')[0].split(':')[1].split(';')[0]

    var content = new Array();
    for (var i = 0; i < byteString.length; i++) {
        content[i] = byteString.charCodeAt(i)
    }

    return new Blob([new Uint8Array(content)], { type: mimestring });
}


function getQueryString(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, '\\$&');
    var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, ' '));
}

function getFormData($form) {
    var unindexed_array = $form.serializeArray();
    var indexed_array = {};

    $.map(unindexed_array, function (n, i) {
        indexed_array[n['name']] = n['value'];
    });

    return indexed_array;
}

