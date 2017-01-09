using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Timestamps.DAL.DataInterfaces.Repositories;
using Timestamps.DAL.Entities;
using Timestamps.DAL.Interfaces;

namespace Timestamps.DAL.EFDataReceiving.Repositories
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
                    .Where(p => !p.Project.IsArchived)
                    .Select(pn => pn.Project)
                    .ToList();
        }

        public bool IsUserTakePartInProject(string userId, int projectId)
        {
            return context.ProjectNominations.Any(pn => (pn.ProjectId == projectId) && (pn.UserId == userId));
        }

        public IEnumerable<ApplicationUser> GetAllUsersOnProject(int projectId)
        {
            return context.ProjectNominations.Where(pn => pn.ProjectId == projectId).Select(pn => pn.User).ToList();
        }
    }
}