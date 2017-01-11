using System.Collections.Generic;
using System.Threading.Tasks;
using Timestamps.DAL.DataContracts;
using Timestamps.DAL.Entities;
using Timestamps.DAL.Interfaces;
using Timestamps.DAL.Management.Interfaces;

namespace Timestamps.DAL.Management
{
    public class ProjectManagement : IProjectManagement
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProjectManagement(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task CreateProjectAsync(CreateProjectRequest createProjectRequest)
        {
            var projectEntity = createProjectRequest.ProjectEntity;

            var projectNomination = new ProjectNomination
            {
                ProjectId = projectEntity.Id,
                Project = projectEntity,
                UserId = createProjectRequest.UserId
            };

            _unitOfWork.Projects.Add(projectEntity);
            _unitOfWork.ProjectNominations.Add(projectNomination);
            await _unitOfWork.SaveChangesAsync();
        }

        public IEnumerable<Project> GetProjectsUserCreate(string userId)
        {
            return _unitOfWork.Projects.GetProjectsUserCreate(userId);
        }

        public Project GetProjectById(int projectId)
        {
            return _unitOfWork.Projects.GetProjectById(projectId);
        }

        public IEnumerable<Project> GetAllProjectsWithCreator()
        {
            return _unitOfWork.Projects.GetAllProjectsWithCreator();
        }

        public Project GetUserProjectById(string userId, int projectId)
        {
            return _unitOfWork.Projects.GetUserProjectById(userId, projectId);
        }

        public async Task UpdateAsync(int projectId, Project newProject)
        {
            var project = _unitOfWork.Projects.GetProjectById(projectId);
            project.Title = newProject.Title;
            project.Description = newProject.Description;
            await _unitOfWork.SaveChangesAsync();
        }

        public ArchiveRestoreOperationResult ArchiveProjectAsync(int projectId)
        {
            var project = _unitOfWork.Projects.GetProjectById(projectId);
            if (project.IsArchived) {
                return ArchiveRestoreOperationResult.WarningProjectAlreadyArchived;
            }

            project.IsArchived = true;
            _unitOfWork.SaveChanges();
            return ArchiveRestoreOperationResult.ProjectArchivedSuccessfully;
        }

        public IEnumerable<ApplicationUser> GetAllUsersOnProject(int projectId)
        {
            return _unitOfWork.ProjectNominations.GetAllUsersOnProject(projectId);
        }

        public ArchiveRestoreOperationResult RestoreProjectAsync(int projectId)
        {
            var project = _unitOfWork.Projects.GetProjectById(projectId);
            if (!project.IsArchived) {
                return ArchiveRestoreOperationResult.WarningProjectIsActive;
            }

            project.IsArchived = false;
            _unitOfWork.SaveChanges();
            return ArchiveRestoreOperationResult.ProjectRestoredSuccessfully;
        }

        public async Task NominateUserOnTheProjectAsync(string userId, int projectId)
        {
            var projectNomination = new ProjectNomination()
            {
                ProjectId = projectId,
                UserId = userId
            };
            _unitOfWork.ProjectNominations.Add(projectNomination);
            await _unitOfWork.SaveChangesAsync();
        }

        public IEnumerable<Project> GetProjectsUserTakePart(string userId)
        {
            return _unitOfWork.ProjectNominations.GetProjectsUserTakePart(userId);
        }

        public bool IsUserTakePartInProject(string userId, int projectId)
        {
            return _unitOfWork.ProjectNominations.IsRecordExist(userId, projectId);
        }
    }
}
