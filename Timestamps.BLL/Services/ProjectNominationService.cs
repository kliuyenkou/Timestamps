using System;
using System.Collections.Generic;
using AutoMapper;
using Omu.ValueInjecter;
using Timestamps.BLL.Interfaces;
using Timestamps.BLL.Models;
using Timestamps.DAL.Entities;
using Timestamps.DAL.Interfaces;
using Project = Timestamps.BLL.Models.Project;
using ProjectNomination = Timestamps.BLL.Models.ProjectNomination;
using ProjectNominationEntity = Timestamps.DAL.Entities.ProjectNomination;

namespace Timestamps.BLL.Services
{
    public class ProjectNominationService : IProjectNominationService
    {
        private readonly IProjectNominationRepository _projectNominationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProjectNominationService(IUnitOfWork unitOfWork)
        {
            _projectNominationRepository = unitOfWork.ProjectNominations;
            _unitOfWork = unitOfWork;
        }

        public void Add(ProjectNomination projectNomination)
        {
            var projectNominationEntity = new ProjectNominationEntity();
            projectNominationEntity.InjectFrom(projectNomination);
            _projectNominationRepository.Add(projectNominationEntity);
            _unitOfWork.SaveChangesWithErrors();
        }

        public IEnumerable<Project> GetProjectsUserTakePart(string userId)
        {
            var dbprojects = _projectNominationRepository.GetProjectsUserTakePart(userId);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ApplicationUser, User>();
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
    }
}