using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Timestamps.BLL.Interfaces;
using Timestamps.BLL.Models;
using Timestamps.DAL.EFDataReceiving;
using Timestamps.DAL.Interfaces;
using dbModels = Timestamps.DAL.DbModels;

namespace Timestamps.BLL
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IProjectNominationRepository _projectNominationRepository;
        public ProjectService(IProjectRepository projectRepository, IProjectNominationRepository projectNominationRepository)
        {
            _projectRepository = projectRepository;
            _projectNominationRepository = projectNominationRepository;
        }

        public IEnumerable<Project> GetProjectsUserCreate(string userId)
        {
            IEnumerable<dbModels.Project> dbprojects = _projectRepository.GetProjectsUserCreate(userId);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Project, dbModels.Project>();
            });

            var mapper = config.CreateMapper();
            var projects = mapper.Map<IEnumerable<dbModels.Project>, IEnumerable<Project>>(dbprojects);
            return projects;


        }

        public void Add(Project project)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Project GetProject(int projectId)
        {
            throw new NotImplementedException();
        }
    }
}
