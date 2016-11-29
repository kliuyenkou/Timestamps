using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TimestampsWeb.Models;
using TimestampsWeb.TimestampsWeb.DAL.Interfaces;

namespace TimestampsWeb.TimestampsWeb.DAL.EFDataReceiving
{
    public class ProjectNominationRepository : Repository<ProjectNomination>, IProjectNominationRepository
    {
        public ProjectNominationRepository(ApplicationDbContext context) : base(context)
        {

        }
        public IEnumerable<Project> GetProjectsUserTakePart(string userId)
        {
            return context.ProjectNominations.Where(pn => pn.UserId == userId).Include(pn => pn.Project).Select(pn => pn.Project).ToList();
        }
    }
}