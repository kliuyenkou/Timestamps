using System;
using System.Collections.Generic;
using AutoMapper;
using Timestamps.BLL.Interfaces;
using Timestamps.BLL.Models;
using Timestamps.DAL.Interfaces;

namespace Timestamps.BLL.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IProjectNominationRepository _projectNominationRepository;
        public ProjectService(IUnitOfWork unitOfWork)
        {
            _projectRepository = unitOfWork.Projects;
            _projectNominationRepository = unitOfWork.ProjectNominations;
        }

        public IEnumerable<Project> GetProjectsUserCreate(string userId)
        {
            IEnumerable<DAL.Entities.Project> dbprojects = _projectRepository.GetProjectsUserCreate(userId);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DAL.Entities.ApplicationUser, User>();
                cfg.CreateMap<DAL.Entities.Project, Project>();
            });

            var mapper = config.CreateMapper();
            var projects = mapper.Map<IEnumerable<DAL.Entities.Project>, IEnumerable<Project>>(dbprojects);
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
