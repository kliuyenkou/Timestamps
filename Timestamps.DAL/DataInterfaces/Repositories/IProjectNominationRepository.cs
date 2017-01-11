using System.Collections.Generic;
using Timestamps.DAL.Entities;

namespace Timestamps.DAL.DataInterfaces.Repositories
{
    public interface IProjectNominationRepository : IRepository<ProjectNomination>
    {
        IEnumerable<Project> GetProjectsUserTakePart(string userId);
        bool IsRecordExist(string userId, int projectId);
        IEnumerable<ApplicationUser> GetAllUsersOnProject(int projectId);
    }
}