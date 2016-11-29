using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace TimestampsWeb.Models
{
    public class Hourage
    {
        public int Id { get; set; }

        [Required]
        public int ProjectId { get; set; }

        [Required]
        public string UserId { get; set; }

        [StringLength(128)]
        public string WorkDescription { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public double Hours { get; set; }

        public Project Project { get; set; }
        public ApplicationUser User { get; set; }
    }
}