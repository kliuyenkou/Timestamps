using System;

namespace TimestampsWeb.Dto
{
    public class HourageDto
    {
        public int Id { get; set; }
        public string WorkDescripton { get; set; }
        public DateTime Date { get; set; }
        public double Hours { get; set; }
        public int ProjectId { get; set; }
        //public ProjectDto Project { get; set; }
        public string UserId { get; set; }
        //public ApplicationUserDto User { get; set; }

    }
}