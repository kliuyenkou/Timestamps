using System.Collections.Generic;
using System.Threading.Tasks;
using Timestamps.DAL.DataContracts;
using Timestamps.DAL.Entities;

namespace Timestamps.DAL.Management.Interfaces
{
    public interface IProjectManagement
    {
        Task CreateProjectAsync(CreateProjectRequest createProjectRequest);
        IEnumerable<Project> GetProjectsUserCreate(string userId);
        Project GetProjectById(int projectId);
        IEnumerable<Project> GetAllProjectsWithCreator();
        Project GetUserProjectById(string userId, int projectId);
        Task UpdateAsync(int projectId, Project project);
        ArchiveRestoreOperationResult ArchiveProjectAsync(int projectId);
        IEnumerable<ApplicationUser> GetAllUsersOnProject(int projectId);
        ArchiveRestoreOperationResult RestoreProjectAsync(int projectId);
        Task NominateUserOnTheProjectAsync(string userId, int projectId);
        IEnumerable<Project> GetProjectsUserTakePart(string userId);
        bool IsUserTakePartInProject(string userId, int projectId);
    }
}