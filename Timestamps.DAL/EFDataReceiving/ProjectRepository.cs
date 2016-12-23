using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
            return context.Projects.Where(p => p.CreatorId == userId);
        }

        public Project GetProjectById(int projectId)
        {
            return context.Projects.Find(projectId);
        }

        public IEnumerable<Project> GetAllProjectsWithCreator()
        {
            return context.Projects.Include(project => project.Creator).ToList();
        }

        public Project GetUserProjectById(string userId, int projectId)
        {
            return context.Projects.Single(p => p.CreatorId == userId && p.Id == projectId);
        }
    }
}