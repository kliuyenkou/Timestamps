var houragesController = function (timesheetService) {

    var loadRecordsList = function () {
        timesheetService.getAllRecords(loadListItems,
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
        var table = $('#Timesheet');
        var tbody = document.createElement('tbody');
        table.append(tbody);
        $.each(records,
            function (index, record) {
                var tRow = document.createElement('tr');
                var tdWorkDescription = document.createElement('td');
                tdWorkDescription.innerHTML = record.WorkDescription;
                tRow.appendChild(tdWorkDescription);
                var tdProject = document.createElement('td');
                tdProject.innerHTML = record.Project.Title;
                tRow.appendChild(tdProject);
                var tdDate = document.createElement('td');
                tdDate.innerHTML = record.Date;
                tRow.appendChild(tdDate);
                var tdHours = document.createElement('td');
                tdHours.innerHTML = record.Hours;
                tRow.appendChild(tdHours);
                var tdDelete = document.createElement('td');
                var a = document.createElement('a');
                var linkText = document.createTextNode('Delete');
                a.appendChild(linkText);
                a.href = "#";
                a.class = "js-delete-record";
                a.setAttribute("data-record-id", record.Id);
                tdDelete.appendChild(a);
                tRow.appendChild(tdDelete);
                tbody.appendChild(tRow);

            });
    };


    function addHourageToListItems(record) {
        var tRow = document.createElement('tr');
        var tdWorkDescription = document.createElement('td');
        tdWorkDescription.innerHTML = record.WorkDescription;
        tRow.appendChild(tdWorkDescription);
        var tdProject = document.createElement('td');
        tdProject.innerHTML = record.ProjectId;
        tRow.appendChild(tdProject);
        var tdDate = document.createElement('td');
        tdDate.innerHTML = record.Date;
        tRow.appendChild(tdDate);
        var tdHours = document.createElement('td');
        tdHours.innerHTML = record.Hours;
        tRow.appendChild(tdHours);
        var tdDelete = document.createElement('td');
        var a = document.createElement('a');
        var linkText = document.createTextNode('Delete');
        a.appendChild(linkText);
        a.className = "js-delete-record";
        a.href = "#";
        tdDelete.appendChild(a);
        tRow.appendChild(tdDelete);
        $('#Timesheet tbody').append(tRow);
    };

    return {
        loadRecordsList: loadRecordsList,
        appendRecordToList: appendRecordToList
    }
}(TimesheetService);
