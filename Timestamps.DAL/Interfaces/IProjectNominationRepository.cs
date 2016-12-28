using System.Collections.Generic;
using Timestamps.DAL.Entities;

namespace Timestamps.DAL.Interfaces
{
    public interface IProjectNominationRepository : IRepository<ProjectNomination>
    {
        IEnumerable<Project> GetProjectsUserTakePart(string userId);
        bool IsUserTakePartInProject(string userId, int projectId);
        IEnumerable<ApplicationUser> GetAllUsersOnProject(int projectId);
    }
}