function toDate(dateStr) {
    var parts = dateStr.split(".");
    return new Date(parts[2], parts[1] - 1, parts[0]);
}

function validateRecordForm(submitCallback, errorContainer) {
    $("#recordForm").validate({
        rules: {
            workDescription: {
                required: true,
                maxlength: 128

            },
            projectId: {
                required: true
            },
            workdate: {
                required: true
            },
            hours: {
                required: true,
                number: true
            }
        },
        messages: {
            workDescription: {
                required: "Work description is required."
            },
            projectId: {
                required: "Project is required."
            },
            workdate: {
                required: "Date is required."
            },
            hours: {
                required: "Hours is required.",
                number: "Please, enter hours as a valid number."
            }
        },
        submitHandler: function (form) {
            submitCallback();
            form.reset();
        },
        errorElement: "span",
        errorClass: "error",
        errorLabelContainer: errorContainer,
        wrapper: "li"
    });
}