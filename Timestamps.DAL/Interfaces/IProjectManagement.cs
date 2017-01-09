using System.Collections.Generic;
using System.Threading.Tasks;
using Timestamps.DAL.DataContracts;
using Timestamps.DAL.Entities;

namespace Timestamps.DAL.Interfaces
{
    public interface IProjectManagement
    {
        Task CreateProject(CreateProjectRequest createProjectRequest);
        IEnumerable<Project> GetProjectsUserCreate(string userId);
    }
}
