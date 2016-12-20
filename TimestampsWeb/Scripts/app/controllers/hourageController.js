var houragesController = function (timesheetService) {

    var loadRecordsList = function () {
        timesheetService.getAllRecrods(loadListItems,
            function () { alert("Fail to load records."); }
            );
    };
    var appendRecordToList = function () {
        var record = {
            WorkDescription: $('#workDescription').val(),
            ProjectId: $('#project').val(),
            Date: $('#date').val(),
            Hours: $('#hours').val()
        };
        timesheetService.addRecord(record,
            addHourageToListItems,
            function () { alert("Fail to save records."); }
            );
    };

    function loadListItems(records) {
        var strLayout =
            "<table class='table'><tr><th>Work description</th><th>Project</th><th>Date</th><th>Hours</th></tr>";
        $.each(records,
            function (index, record) {
                strLayout += "<tr><td>" +
                    record.WorkDescription +
                    "</td><td>" +
                    record.Project.Title +
                    "</td><td>" +
                    record.Date +
                    "</td><td>" +
                    record.Hours +
                    "</td><tr>";
            });
        strLayout += "</table>";
        $('#recordsTable').html(strLayout);
    };

    function addHourageToListItems(record) {
        var str = "<tr><td>" +
            record.WorkDescription +
            "</td><td>" +
            record.Project.Title +
            "</td><td>" +
            record.Date +
            "</td><td>" +
            record.Hours +
            "</td><tr>";
        $('#recordsTable tbody').append(str);
    };

    return {
        loadRecordsList: loadRecordsList,
        appendRecordToList: appendRecordToList
    }
}(TimesheetService);
