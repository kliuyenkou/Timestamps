using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Omu.ValueInjecter;
using Timestamps.BLL.Interfaces;
using Timestamps.DAL.Interfaces;
using Mapper = AutoMapper.Mapper;
using Project = Timestamps.BLL.Models.Project;
using ProjectEntity = Timestamps.DAL.Entities.Project;
using ProjectNominationEntity = Timestamps.DAL.Entities.ProjectNomination;

namespace Timestamps.BLL.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectNominationRepository _projectNominationRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProjectService(IUnitOfWork unitOfWork)
        {
            _projectRepository = unitOfWork.Projects;
            _projectNominationRepository = unitOfWork.ProjectNominations;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Project> GetProjectsUserCreate(string userId)
        {
            var dbprojects = _projectRepository.GetProjectsUserCreate(userId);
            var projects = Mapper.Map<IEnumerable<ProjectEntity>, IEnumerable<Project>>(dbprojects);
            return projects;
        }

        public async Task CreateProjectAsync(Project project)
        {
            var projectEntity = new ProjectEntity();
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
            var projectEntity = new ProjectEntity();
            projectEntity.InjectFrom(project);
            _projectRepository.Add(projectEntity);
            _unitOfWork.SaveChangesWithErrors();
        }

        public Project GetProjectById(int projectId)
        {
            var projectEntity = _projectRepository.GetProjectById(projectId);
            var project = new Project();
            project.InjectFrom(projectEntity);
            return project;
        }

        public IEnumerable<Project> GetAllProjects()
        {

            var dbprojects = _projectRepository.GetAllProjectsWithCreator();
            var projects = Mapper.Map<IEnumerable<ProjectEntity>, IEnumerable<Project>>(dbprojects);
            return projects;
        }

        public Project GetUserProjectById(string userId, int projectId)
        {
            var projectEntity = _projectRepository.GetUserProjectById(userId, projectId);
            var project = new Project();
            project.InjectFrom(projectEntity);
            return project;
        }

        public async Task UpdateAsync(Project project)
        {
            var projectEntity = _projectRepository.GetProjectById(project.Id);
            projectEntity.Title = project.Title;
            projectEntity.Description = project.Description;
            projectEntity.IsArchived = project.IsArchived;
            await _unitOfWork.SaveChangesAsync();
        }

        public void ArchiveUserProjectById(string userId, int projectId)
        {
            var projectEntity = _projectRepository.GetUserProjectById(userId, projectId);
            if (projectEntity.IsArchived) {
                throw new Exception("Project has already archived.");
            }
            projectEntity.IsArchived = true;
            _unitOfWork.SaveChanges();
        }
    }
}