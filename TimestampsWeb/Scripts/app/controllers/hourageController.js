var houragesController = function(timesheetService) {
    var loadRecordsList = function() {
        var d = $.Deferred();

        timesheetService.getAllRecords(
            function(records) {
                loadListItems(records);
                d.resolve(records);
            },
            function() {
                d.reject();
            });

        return d.promise();
    };
    var appendRecordToList = function(onClickDelete) {
        var date = toDate($("#date").val());
        var dateString = "";
        if (date instanceof Date && isFinite(date)) {
            dateString = date.toISOString();
        }
        var record = {
            WorkDescription: $("#workDescription").val(),
            ProjectId: $("#project").val(),
            Date: dateString,
            Hours: $("#hours").val()
        };
        timesheetService.addRecord(record,
            function(rec) {
                addRecordToListItems(rec, onClickDelete);
            },
            function() { bootbox.alert("Failed to save record."); }
        );
    };

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
            submitHandler: function(form) {
                submitCallback();
                form.reset();
            },
            errorElement: "span",
            errorClass: "error",
            errorLabelContainer: errorContainer,
            wrapper: "li"
        });
    }

    function loadListItems(records) {
        var table = $("#Timesheet");
        var tbody = document.createElement("tbody");
        table.append(tbody);
        $.each(records,
            function(index, record) {
                var tRow = renderRecord(record);
                tbody.appendChild(tRow);
            });
    };

    function addRecordToListItems(record, deleteRecord) {
        var tRow = renderRecord(record);
        $(tRow).find("a").click(deleteRecord);
        $("#Timesheet tbody").append(tRow);
    };

    function renderRecord(record) {
        if (record == null) {
            bootbox.alert("Failed to save record.");
            return;
        }
        var tRow = document.createElement("tr");
        var tdWorkDescription = document.createElement("td");
        tdWorkDescription.innerHTML = record.WorkDescription;
        tRow.appendChild(tdWorkDescription);
        var tdProject = document.createElement("td");
        tdProject.innerHTML = record.Project.Title;
        tRow.appendChild(tdProject);
        var tdDate = document.createElement("td");
        tdDate.innerHTML = new Date(record.Date).toLocaleDateString();
        tRow.appendChild(tdDate);
        var tdHours = document.createElement("td");
        tdHours.innerHTML = record.Hours;
        tRow.appendChild(tdHours);
        var tdDelete = document.createElement("td");
        var a = document.createElement("a");
        var icon = document.createElement("i");
        icon.className += "glyphicon glyphicon-remove";
        a.appendChild(icon);
        a.href = "#";
        a.className += "js-delete-record";
        a.setAttribute("data-record-id", record.Id);
        tdDelete.appendChild(a);
        tRow.appendChild(tdDelete);
        return tRow;
    };

    return {
        loadRecordsList: loadRecordsList,
        appendRecordToList: appendRecordToList,
        validateRecordForm: validateRecordForm
    };
}(TimesheetService);