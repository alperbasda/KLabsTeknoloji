var referencePage = 1;
var elem;
function loadMore() {


    $("#load-more").html("Yükleniyor...");
    $.get('../../Referans/ReferansJson?page=' + referencePage,
        function(data) {

            elem = '';

            if (data.length < 8) {
                endOfReferences();
            }

            $.each(data,
                function(index, item) {
                    debugger;
                    elem +=
                        '<div style="display:none" class="col-lg-3 col-md-6 hidden-item">' +
                        '<div class="ht-box-icon style-01">' +
                        '<div class="icon-box-wrap">' +
                        '<div class="icon">' +
                        '<img src="' +
                        item.LogoPath +
                        '" alt="' +
                        item.Name +
                        '"></div>' +
                        '<div class="content">' +
                        '<h5 class="heading">' +
                        item.Name +
                        ' </h5>' +
                        '<div class="text"> ' +
                        item.Description +
                        ' </div>' +
                        '<div class="feature-btn"><a target="_blank" href="' +
                        item.Description +
                        '">' +
                        '<span class="button-text">Siteye Git</span>' +
                        '<i class="far fa-long-arrow-right"></i>' +
                        '</a></div></div></div></div></div>';

                });

        })
        .done(function () {
            debugger;
            
            $('#load-references').append($(elem));
            $('.hidden-item').show('slow');
            $('.hidden-item').removeClass('hidden-item');

            $("#load-more").html("Devamını Gör");
            $("#load-more").css('color', 'white');
        })
        .fail(function () {
            toastr.error('İşlem Sırasında Hata Oluştu Lütfen Tekrar Deneyin.');
        })
        .always(function () {
            referencePage++;
        });



}

function endOfReferences() {

    var pos = $('#load-more').position();

    $('#load-more').css('position', 'relative');
    $('#load-more').position(pos);

    $('#load-more').animate({
        left: '-1200',
        opacity: '0',
        display: 'none'
    },
        1000).promise().done(function () {
            setTimeout(5000,
                function () {
                    $('#load-more').remove();
                });
        });

}