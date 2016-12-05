using System.ComponentModel.DataAnnotations;

namespace Timestamps.DAL.Entities
{
    public class ProjectNomination
    {
        public int Id { get; set; }

        [Required]
        public int ProjectId { get; set; }

        [Required]
        public string UserId { get; set; }

        public Project Project { get; set; }

        public ApplicationUser User { get; set; }
    }
}