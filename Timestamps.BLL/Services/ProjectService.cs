using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Omu.ValueInjecter;
using Timestamps.BLL.Interfaces;
using Timestamps.BLL.Models;
using Timestamps.DAL.Entities;
using Timestamps.DAL.Interfaces;
using Project = Timestamps.BLL.Models.Project;
using ProjectEntity = Timestamps.DAL.Entities.Project;
using ProjectNomination = Timestamps.BLL.Models.ProjectNomination;
using ProjectNominationEntity = Timestamps.DAL.Entities.ProjectNomination;

namespace Timestamps.BLL.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProjectRepository _projectRepository;
        private readonly IProjectNominationRepository _projectNominationRepository;
        public ProjectService(IUnitOfWork unitOfWork)
        {
            _projectRepository = unitOfWork.Projects;
            _projectNominationRepository = unitOfWork.ProjectNominations;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Project> GetProjectsUserCreate(string userId)
        {
            IEnumerable<ProjectEntity> dbprojects = _projectRepository.GetProjectsUserCreate(userId);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ApplicationUser, User>();
                cfg.CreateMap<ProjectEntity, Project>();
            });

            var mapper = config.CreateMapper();
            var projects = mapper.Map<IEnumerable<ProjectEntity>, IEnumerable<Project>>(dbprojects);
            return projects;
        }

        public async Task CreateProjectAsync(Project project)
        {
            ProjectEntity projectEntity = new ProjectEntity();
            projectEntity.InjectFrom(project);
            _projectRepository.Add(projectEntity);

            var projectNomination = new ProjectNominationEntity
            {
                ProjectId = project.Id,
                Project = projectEntity,
                UserId = project.CreatorId
            };

            _projectNominationRepository.Add(projectNomination);
            await _unitOfWork.SaveChangesAsync();

        }

        public void Add(Project project)
        {
            ProjectEntity projectEntity = new ProjectEntity();
            projectEntity.InjectFrom(project);
            _projectRepository.Add(projectEntity);
            _unitOfWork.SaveChangesWithErrors();

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Project GetProjectById(int projectId)
        {
            var projectEntity = _projectRepository.GetProjectById(projectId);
            Project project = new Project();
            project.InjectFrom(projectEntity);
            return project;
        }
    }
}
