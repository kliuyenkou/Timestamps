using System.Collections.Generic;
using System.Threading.Tasks;
using Timestamps.BLL.Models;

namespace Timestamps.BLL.Interfaces
{
    public interface IProjectService
    {
        Project GetProjectById(int projectId);
        IEnumerable<Project> GetProjectsUserCreate(string userId);
        Task CreateProjectAsync(Project project);
        void Add(Project project);
        IEnumerable<Project> GetAllProjects();
    }
}