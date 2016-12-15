using System;
using System.Collections.Generic;
using Timestamps.DAL.Entities;
using Timestamps.DAL.Interfaces;

namespace Timestamps.DAL.EFDataReceiving
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Project> GetProjectsUserCreate(string userId)
        {
            throw new NotImplementedException();
        }

        public Project GetProjectById(int projectId)
        {
            return context.Projects.Find(projectId);
        }
    }
}