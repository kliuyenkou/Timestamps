using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timestamps.BLL.Models;

namespace Timestamps.BLL.Interfaces
{
    public interface IProjectService
    {
        Project GetProject(int projectId);
        IEnumerable<Project> GetProjectsUserCreate(string userId);
        void Add(Project project);
        void Dispose();

    }
}
