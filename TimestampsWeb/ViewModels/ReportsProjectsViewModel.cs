using System;
using Timestamps.BLL.Models;

namespace TimestampsWeb.ViewModels
{
    public class ReportsProjectsViewModel
    {
        public ProjectType ProjectType { get; set; }
        public Project Project { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}