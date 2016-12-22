using System;
using System.ComponentModel.DataAnnotations;

namespace TimestampsWeb.ViewModels
{
    public class ProjectWithCreatorViewModel
    {
        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        [StringLength(256)]
        public string Description { get; set; }
        public string CreatorName { get; set; }
        public DateTime CreationDate { get; set; }

    }
}