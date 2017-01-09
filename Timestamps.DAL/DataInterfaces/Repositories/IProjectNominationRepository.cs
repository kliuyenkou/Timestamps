using System.Collections.Generic;
using Timestamps.DAL.Entities;
using Timestamps.DAL.Interfaces;

namespace Timestamps.DAL.DataInterfaces.Repositories
{
    public interface IProjectNominationRepository : IRepository<ProjectNomination>
    {
        IEnumerable<Project> GetProjectsUserTakePart(string userId);
        bool IsUserTakePartInProject(string userId, int projectId);
        IEnumerable<ApplicationUser> GetAllUsersOnProject(int projectId);
    }
}