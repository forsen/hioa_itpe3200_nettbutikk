$(document).ready(function () {
    $('#stop').submit(function (event) {
        event.preventDefault();
        var form = $('#__AjaxAntiForgeryForm');
        var token = $('input[name="__RequestVerificationToken"]', form).val();
        $.ajax({
            url: $(this).data('url'),
            type: 'POST',
            data: {
                __RequestVerificationToken: token,
                un: $('#un').val(),
                pw: $('#pw').val()
            },
            success: function (status) {
                if(status)
                {
                    $('#LoginModal').hide();
                    location.reload(); 
                }
                else
                {
                    $('.loginFields').addClass("has-error");
                    $('#forgotPwBtn').show();
                    $('#closeModalBtn').show();
                    $('#modalMessage').text("Feil brukernavn og/eller passord");
                }
            }
        }); 
        return false;
    });
});
