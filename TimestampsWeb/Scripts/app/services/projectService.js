var ProjectService = function () {
    var archive = function (projectId, success, error) {
        $.post("/api/archiveproject/" + projectId).done(success).fail(error);
    };
    var restore = function (projectId, success, error) {
        $.ajax({
            url: "/api/archiveproject/" + projectId,
            method: "DELETE"
        }).done(success).fail(error);
    };
    return {
        archiveProject: archive,
        restoreProject: restore
    };
}();