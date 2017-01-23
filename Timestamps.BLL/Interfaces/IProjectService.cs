using System.Collections.Generic;
using System.Threading.Tasks;
using Timestamps.BLL.DataContracts;

namespace Timestamps.BLL.Interfaces
{
    public interface IProjectService
    {
        IEnumerable<Project> GetProjectsUserCreate(string userId);
        Task CreateProjectAsync(Project project);
        IEnumerable<Project> GetAllProjects();
        Project GetUserProject(string userId, int projectId);
        Task UpdateAsync(Project project);
        void ArchiveUserProject(string userId, int projectId);
        void RestoreUserProject(string userId, int projectId);
        void AddUserToProject(int projectId, string userId);
        IEnumerable<Project> GetProjectsUserTakePart(string userId);
        bool IsUserTakePartInProject(string userId, int projectId);
    }
}