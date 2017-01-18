namespace Timestamps.BLL.DataContracts
{
    public class ProjectNomination
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string UserId { get; set; }
        public Project Project { get; set; }
        public User User { get; set; }
    }
}