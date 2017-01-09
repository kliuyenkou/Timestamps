using System.Collections.Generic;
using System.Threading.Tasks;
using Timestamps.DAL.DataContracts;
using Timestamps.DAL.Entities;
using Timestamps.DAL.Interfaces;
using Timestamps.DAL.Management.Interfaces;

namespace Timestamps.DAL.Management
{
    public class ProjectManagement : IProjectManagement
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProjectManagement(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task CreateProject(CreateProjectRequest createProjectRequest)
        {
            var projectEntity = createProjectRequest.ProjectEntity;

            var projectNomination = new ProjectNomination
            {
                ProjectId = projectEntity.Id,
                Project = projectEntity,
                UserId = createProjectRequest.UserId
            };

            _unitOfWork.Projects.Add(projectEntity);
            _unitOfWork.ProjectNominations.Add(projectNomination);
            await _unitOfWork.SaveChangesAsync();
        }

        public IEnumerable<Project> GetProjectsUserCreate(string userId)
        {
            return _unitOfWork.Projects.GetProjectsUserCreate(userId);
        }
    }
}
