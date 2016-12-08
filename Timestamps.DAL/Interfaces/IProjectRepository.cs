using System.Collections.Generic;
using System.Threading.Tasks;
using Timestamps.DAL.Entities;

namespace Timestamps.DAL.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        IEnumerable<Project> GetProjectsUserCreate(string userId);
        Project GetProjectById(int projectId);
    }
}
