using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimestampsWeb.Dto
{
    public class ProjectWithTotalHoursDto
    {
        public int ProjectId { get; set; }
        public string ProjectTitle { get; set; }
        public double Hours { get; set; }
    }
}