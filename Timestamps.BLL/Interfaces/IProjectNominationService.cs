using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
