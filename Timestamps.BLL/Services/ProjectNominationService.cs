using System;
using System.Collections.Generic;
using AutoMapper;
using Timestamps.BLL.Interfaces;
using Timestamps.BLL.Models;
using Timestamps.DAL.Interfaces;

namespace Timestamps.BLL.Services
{
    public class ProjectNominationService : IProjectNominationService
    {
        private readonly IProjectNominationRepository _projectNominationRepository;
        public ProjectNominationService(IUnitOfWork unitOfWork)
        {
            _projectNominationRepository = unitOfWork.ProjectNominations;
        }
        public void Add(ProjectNomination projectNomination)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetProjectsUserTakePart(string userId)
        {
            IEnumerable<DAL.Entities.Project> dbprojects = _projectNominationRepository.GetProjectsUserTakePart(userId);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DAL.Entities.ApplicationUser, ApplicationUser>();
                cfg.CreateMap<DAL.Entities.Project, Project>();
            });

            var mapper = config.CreateMapper();
            var projects = mapper.Map<IEnumerable<DAL.Entities.Project>, IEnumerable<Project>>(dbprojects);
            return projects;

        }

        public bool IsUserTakePartInProject(string userId, int projectId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
