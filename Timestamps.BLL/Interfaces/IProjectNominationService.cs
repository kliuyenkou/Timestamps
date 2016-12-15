using System.Collections.Generic;
using Timestamps.BLL.Models;

namespace Timestamps.BLL.Interfaces
{
    public interface IProjectNominationService
    {
        void Add(ProjectNomination projectNomination);
        IEnumerable<Project> GetProjectsUserTakePart(string userId);
        bool IsUserTakePartInProject(string userId, int projectId);
        void Dispose();
    }
}