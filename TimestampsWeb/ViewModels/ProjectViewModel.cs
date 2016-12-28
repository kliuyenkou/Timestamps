using System.ComponentModel.DataAnnotations;

namespace TimestampsWeb.ViewModels
{
    public class ProjectViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        [StringLength(256)]
        public string Description { get; set; }

        public string Action { get; set; }

        public bool IsArchived { get; set; }
    }
}