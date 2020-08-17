
$(document).ready(function() {
    initLayoutButtons();
});

function initLayoutButtons() {

    //User Waiting Events
    $('.kt-header__topbar-wrapper').on('click', function () {

        if ($(this).attr("aria-expanded") != "true") {

            $.ajax({
                url: "../../Layout/LayOutWaitingData",
                type: 'Get',
                beforeSend: function() {
                    //$('#loading').show();
                },
                success: function (data) {
                    //$('#loading').hide();
                    if (data.IsCompleted) {
                        if (data.Data.WaitingQuestion == 0) {
                            $('#question-badge').addClass("kt-badge--success");
                        } else {
                            $('#question-badge').addClass("kt-badge--warning");
                        }
                        if (data.Data.WaitingApplication == 0) {
                            $('#application-badge').addClass("kt-badge--success");
                        } else {
                            $('#application-badge').addClass("kt-badge--warning");
                        }
                        if (data.Data.WaitingDecision == 0) {
                            $('#decision-badge').addClass("kt-badge--success");
                        } else {
                            $('#decision-badge').addClass("kt-badge--warning");
                        }
                        if (data.Data.WaitingSuperVision == 0) {
                            $('#supervision-badge').addClass("kt-badge--success");
                        } else {
                            $('#supervision-badge').addClass("kt-badge--warning");
                        }
                        if (data.Data.WaitingComplain == 0) {
                            $('#complain-badge').addClass("kt-badge--success");
                        } else {
                            $('#complain-badge').addClass("kt-badge--warning");
                        }
                        if (data.Data.WaitingResultExam == 0) {
                            $('#examresult-badge').addClass("kt-badge--success");
                            
                        } else {
                            $('#examresult-badge').addClass("kt-badge--warning");
                        }
                        $('#question-badge').html(data.Data.WaitingQuestion);
                        $('#application-badge').html(data.Data.WaitingApplication);
                        $('#decision-badge').html(data.Data.WaitingDecision);
                        $('#examresult-badge').html(data.Data.WaitingResultExam);
                        $('#supervision-badge').html(data.Data.WaitingSuperVision);
                        $('#complain-badge').html(data.Data.WaitingComplain);
                        
                    } else {
                        toastr.error(data.Message);
                    }
                }
            });

        }

    });
}