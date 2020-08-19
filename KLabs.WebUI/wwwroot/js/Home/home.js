var solutionPage = 0;
var referencePage = 0;
var brandLogoSlider;
var brandLogoSliderInterval;
var slideItems = [];


$(document).ready(function () {
    loadMore();
    fillSwiperData();
});

function loadMore() {

    if (solutionCount > solutionPage * 3) {
        $("#load-more").html("Yükleniyor...");
        $.get('../../Solution/HomePageSolutionsPartial?page=' + solutionPage, function (data) {
            $('#load-solutions').append($(data));
            $('#hidden-item').show('slow');
            $('#hidden-item').removeAttr('id');


        })
            .done(function () {
                $("#load-more").html("Devamını Gör");
                $("#load-more").css('color', 'white');
            })
            .fail(function () {
                toastr.error('İşlem Sırasında Hata Oluştu Lütfen Tekrar Deneyin.');
            })
            .always(function () {
                $('#loading').css('display', 'none');
            });
        if (Math.abs(solutionCount - solutionPage * 3) <= 3)
            endOfSolutions();

        solutionPage++;
        return;
    }
    endOfSolutions();
}

function endOfSolutions() {


    var pos = $('#load-more').position();

    $('#load-more').css('position', 'relative');
    $('#load-more').position(pos);

    $('#load-more').animate({
        left: '-1200',
        opacity: '0',
        display: 'none'
    },
        1000).promise().done(function () {
            $('#load-more').remove();
        });

}

function loadSwiper() {
    
    brandLogoSlider = new Swiper('.brand-logo-slider__container', {
        slidesPerView: 6,
        loop: true,
        speed: 1000,
        spaceBetween: 30,

        autoplay: {
            delay: 3000,
        },

        breakpoints: {
            1499: {
                slidesPerView: 6
            },

            991: {
                slidesPerView: 4
            },

            767: {
                slidesPerView: 3

            },

            575: {
                slidesPerView: 2
            }
        }
    });

    brandLogoSlider.appendSlide(slideItems);

}

function fillSwiperData() {
    $.get('../../Reference/ReferenceJson?page=' + referencePage,
        function (data) {
            if (data.length > 0) {
                $.each(data,
                    function (index, item) {
                        slideItems.push('<div class="swiper-slide brand-logo brand-logo--slider">' +
                            '<a target="_blank" href = "' +
                            item.Description +
                            '"><div class="brand-logo__image">' +
                            '<img src="' +
                            item.LogoPath +
                            '" class="img-fluid" alt="' +
                            item.Name +
                            '">' +
                            '</div>' +
                            '<div class="brand-logo__image-hover">' +
                            '<img src="' +
                            item.LogoPath +
                            '" class="img-fluid" alt="' +
                            item.Name +
                            '">' +
                            '</div>' +
                            '</a>' +
                            '</div>');
                    });
                referencePage++;
                
                
                loadSwiper();
            } else {
                
                loadSwiper();
            }

            if (data.length == 6) {
                setTimeout(function () { fillSwiperData(); }, 3000);
            }


        });
}
