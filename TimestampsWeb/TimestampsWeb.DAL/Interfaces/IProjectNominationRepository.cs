using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimestampsWeb.Models;

namespace TimestampsWeb.TimestampsWeb.DAL.Interfaces
{
    public interface IProjectNominationRepository : IRepository<ProjectNomination>
    {
        IEnumerable<Project> GetProjectsUserTakePart(string userId);
        bool IsUserTakePartInProject(string userId, int projectId);
    }
}
