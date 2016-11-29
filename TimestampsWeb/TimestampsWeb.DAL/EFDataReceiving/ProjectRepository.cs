using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimestampsWeb.TimestampsWeb.DAL.Interfaces;
using TimestampsWeb.Models;
using System.Data.Entity;

namespace TimestampsWeb.TimestampsWeb.DAL.EFDataReceiving
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}