using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Omu.ValueInjecter;
using Timestamps.BLL.Interfaces;
using Timestamps.DAL.DataContracts;
using Timestamps.DAL.Entities;
using Timestamps.DAL.Management;
using Timestamps.DAL.Management.Interfaces;
using Mapper = AutoMapper.Mapper;
using Project = Timestamps.BLL.Models.Project;
using ProjectEntity = Timestamps.DAL.Entities.Project;

namespace Timestamps.BLL.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectManagement _projectManagement;
        private readonly INotificationManagement _notificationManagement;

        public ProjectService(IProjectManagement projectManagement, INotificationManagement notificationManagement)
        {
            _projectManagement = projectManagement;
            _notificationManagement = notificationManagement;
        }

        public IEnumerable<Project> GetProjectsUserCreate(string userId)
        {
            var dbprojects = _projectManagement.GetProjectsUserCreate(userId);
            var projects = Mapper.Map<IEnumerable<ProjectEntity>, IEnumerable<Project>>(dbprojects);
            return projects;
        }

        public async Task CreateProjectAsync(Project project)
        {
            var projectEntity = new ProjectEntity();
            projectEntity.InjectFrom(project);
            var createProjectRequest = new CreateProjectRequest(projectEntity, project.CreatorId);
            await _projectManagement.CreateProjectAsync(createProjectRequest);
        }

        public IEnumerable<Project> GetAllProjects()
        {
            var dbprojects = _projectManagement.GetAllProjectsWithCreator();
            var projects = Mapper.Map<IEnumerable<ProjectEntity>, IEnumerable<Project>>(dbprojects);
            return projects;
        }

        public Project GetUserProject(string userId, int projectId)
        {
            var projectEntity = _projectManagement.GetUserProjectById(userId, projectId);
            var project = new Project();
            project.InjectFrom(projectEntity);
            return project;
        }

        public async Task UpdateAsync(Project project)
        {
            var projectEntity = new ProjectEntity();
            projectEntity.InjectFrom(project);
            await _projectManagement.UpdateAsync(project.Id, projectEntity);
        }

        public void ArchiveUserProjectAsync(string userId, int projectId)
        {
            var result = _projectManagement.ArchiveProjectAsync(projectId);
            if (result == ArchiveRestoreOperationResult.WarningProjectAlreadyArchived) {
                return;
            }
            var usersOnThisProject = _projectManagement.GetAllUsersOnProject(projectId);

            var notification = _notificationManagement.CreateNotification(DateTime.Now, NotificationType.ProjectArchived, projectId);
            _notificationManagement.NotifyUsers(notification, usersOnThisProject);
        }

        public void RestoreUserProject(string userId, int projectId)
        {
            var result = _projectManagement.RestoreProjectAsync(projectId);
            if (result == ArchiveRestoreOperationResult.WarningProjectIsActive) {
                return;
            }
            var usersOnThisProject = _projectManagement.GetAllUsersOnProject(projectId);

            var notification = _notificationManagement.CreateNotification(DateTime.Now, NotificationType.ProjectRestored, projectId);
            _notificationManagement.NotifyUsers(notification, usersOnThisProject);
        }

        public void AddUserToProject(int projectId, string userId)
        {
            _projectManagement.NominateUserOnTheProjectAsync(userId, projectId);
        }

        public IEnumerable<Project> GetProjectsUserTakePart(string userId)
        {
            var dbprojects = _projectManagement.GetProjectsUserTakePart(userId);
            var projects = Mapper.Map<IEnumerable<DAL.Entities.Project>, IEnumerable<Project>>(dbprojects);
            return projects;
        }

        public bool IsUserTakePartInProject(string userId, int projectId)
        {
            return _projectManagement.IsUserTakePartInProject(userId, projectId);
        }
    }
}