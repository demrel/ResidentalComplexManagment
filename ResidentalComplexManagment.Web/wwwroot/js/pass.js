$('.show-password-toggle').each(function () {
    var eye = $(this);
    eye.on('click', function () {
        eye.toggleClass("fa-eye fa-eye-slash");
        eye.siblings("input").each(function () {
            if (eye.hasClass('fa-eye-slash')) {
                $(this).attr('type', 'password');
            }
            else if (eye.hasClass('fa-eye')) {
                $(this).attr('type', 'text');
            }
        });
    });
});