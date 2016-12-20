var TimesheetService = function () {
    var getAllRecords = function (success, error) {
        $.ajax({
            url: '/api/Timesheet',
            type: 'GET',
            dataType: 'json'
        }).done(success).fail(error);
    };
    var addRecord = function (data, success, error) {
        $.post({
            url: '/api/Timesheet',
            data: data,
            dataType: 'json'
        }).done(success).fail(error);
    }
    return {
        getAllRecrods: getAllRecords,
        addRecord: addRecord
    }
}();