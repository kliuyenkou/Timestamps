var ProjectController = function(service) {
    var archiveProject = function(projectId, success, fail) {
        service.archiveProject(projectId, success, fail);
    };
    var restoreProject = function(projectId, success, fail) {
        service.restoreProject(projectId, success, fail);
    };
    return {
        restoreProject: restoreProject,
        archiveProject: archiveProject
    }
}(ProjectService)