using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TimestampsWeb.Models
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