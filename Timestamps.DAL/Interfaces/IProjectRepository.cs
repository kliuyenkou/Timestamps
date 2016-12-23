using System.Collections.Generic;
using Timestamps.DAL.Entities;

namespace Timestamps.DAL.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        IEnumerable<Project> GetProjectsUserCreate(string userId);
        Project GetProjectById(int projectId);
        IEnumerable<Project> GetAllProjectsWithCreator();
        Project GetUserProjectById(string userId, int projectId);
    }
}