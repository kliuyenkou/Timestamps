using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Timestamps.BLL.Models;

namespace TimestampsWeb.ViewModels
{
    public class HourageViewModel
    {
        public int Id { get; set; }

        [StringLength(128)]
        [DisplayName("Work description")]
        public string WorkDescription { get; set; }

        [Required]
        [DisplayName("Project")]
        public int ProjectId { get; set; }

        [DisplayName("Project")]
        public Project Project { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public double Hours { get; set; }
    }
}