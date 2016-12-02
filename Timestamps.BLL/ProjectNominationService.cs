using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Omu.ValueInjecter;
using Timestamps.BLL.Interfaces;
using Timestamps.BLL.Models;
using Timestamps.DAL.EFDataReceiving;
using Timestamps.DAL.Interfaces;

namespace Timestamps.BLL
{
    public class ProjectNominationService : IProjectNominationService
    {
        private readonly IProjectNominationRepository _projectNominationRepository;
        public ProjectNominationService(IProjectNominationRepository projectNominationRepository)
        {
            _projectNominationRepository = projectNominationRepository;
        }
        public void Add(ProjectNomination projectNomination)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetProjectsUserTakePart(string userId)
        {
            IEnumerable<DAL.DbModels.Project> dbprojects = _projectNominationRepository.GetProjectsUserTakePart(userId);
            IEnumerable<Project> projects = new Collection<Project>();
            projects.InjectFrom(dbprojects);
            return projects;
        }

        public bool IsUserTakePartInProject(string userId, int projectId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
