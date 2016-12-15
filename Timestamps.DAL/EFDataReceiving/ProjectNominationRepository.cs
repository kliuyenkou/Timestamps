using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Timestamps.DAL.Entities;
using Timestamps.DAL.Interfaces;

namespace Timestamps.DAL.EFDataReceiving
{
    public class ProjectNominationRepository : Repository<ProjectNomination>, IProjectNominationRepository
    {
        public ProjectNominationRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Project> GetProjectsUserTakePart(string userId)
        {
            return
                context.ProjectNominations.Where(pn => pn.UserId == userId)
                    .Include(pn => pn.Project)
                    .Select(pn => pn.Project)
                    .ToList();
        }

        public bool IsUserTakePartInProject(string userId, int projectId)
        {
            return context.ProjectNominations.Any(pn => (pn.ProjectId == projectId) && (pn.UserId == userId));
        }
    }
}