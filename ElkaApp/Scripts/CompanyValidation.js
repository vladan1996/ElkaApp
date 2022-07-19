$('.company-registration').validate({
    errorClass: 'text-danger',
    errorElement: 'div',
    errorPlacement: function (error, e) {
        e.parents('.form_div').append(error);
    },
    highlight: function (e) {
        $(e).closest('.form_div').removeClass('has-success has-error').addClass('has-error');
        $(e).closest('.help-block').remove();
    },
    success: function (e) {
        e.closest('.form_div').removeClass('has-success has-error');
        e.closest('.help-block').remove();
    },

    rules: {
        FilePath: {
            required: true
        },

        Name: {
            required: true
        },

        Street: {
            required: true
        },

        City: {
            required: true
        },

        Phone: {
            required: true
        },

        Email: {
            required: true,
            email: true
        }

    },
    messages: {
        FilePath: 'Please upload the image',
        Name: 'Please enter company name!',
        Street: 'Please enter street!',
        City: 'Please enter city!',
        Phone: 'Please enter phone!',
        Email: 'Please enter valid email address!'
    }
});


