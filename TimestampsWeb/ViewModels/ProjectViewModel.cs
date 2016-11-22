using System.ComponentModel.DataAnnotations;
namespace TimestampsWeb.ViewModels
{
    public class ProjectViewModel
    {
        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        [StringLength(256)]
        public string Description { get; set; }

    }
}