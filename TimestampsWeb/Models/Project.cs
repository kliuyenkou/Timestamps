using System.ComponentModel.DataAnnotations;

namespace TimestampsWeb.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        [StringLength(127)]
        public string Title { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        public ApplicationUser Creator { get; set; }

    }
}