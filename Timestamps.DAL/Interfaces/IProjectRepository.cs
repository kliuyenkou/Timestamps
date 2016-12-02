using System.Collections.Generic;
using Timestamps.DAL.DbModels;

namespace Timestamps.DAL.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        IEnumerable<Project> GetProjectsUserCreate(string userId);
    }
}
