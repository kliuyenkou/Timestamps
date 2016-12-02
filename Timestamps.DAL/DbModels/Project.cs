using System.ComponentModel.DataAnnotations;

namespace Timestamps.DAL.DbModels
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        [StringLength(256)]
        public string Description { get; set; }

        [Required]
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }

    }
}