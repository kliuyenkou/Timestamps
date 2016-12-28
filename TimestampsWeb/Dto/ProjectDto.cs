namespace TimestampsWeb.Dto
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatorId { get; set; }
        public string CreatorEmail { get; set; }
        public string CreatorName { get; set; }
        public bool IsArchived { get; set; }
    }
}