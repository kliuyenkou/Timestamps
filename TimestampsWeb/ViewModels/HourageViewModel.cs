using System;
using System.ComponentModel.DataAnnotations;
using TimestampsWeb.Models;

namespace TimestampsWeb.ViewModels
{
    public class HourageViewModel
    {
        [StringLength(128)]
        public string WorkDescripton { get; set; }
        [Required]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        [Required]
        public DateTime Date { get; set; }
        public double Hours { get; set; }

    }
}