using Timestamps.DAL.Entities;

namespace Timestamps.DAL.DataContracts
{
    public class CreateProjectRequest
    {
        public CreateProjectRequest(Project projectEntity, string creatorId)
        {
            this.ProjectEntity = projectEntity;
            this.UserId = creatorId;
        }

        public Project ProjectEntity { get; private set; }
        public string UserId { get; private set; }
    }
}
