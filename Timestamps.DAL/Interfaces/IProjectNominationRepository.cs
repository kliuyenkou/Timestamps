using System.Collections.Generic;
using Timestamps.DAL.DbModels;

namespace Timestamps.DAL.Interfaces
{
    public interface IProjectNominationRepository : IRepository<ProjectNomination>
    {
        IEnumerable<Project> GetProjectsUserTakePart(string userId);
        bool IsUserTakePartInProject(string userId, int projectId);
    }
}
