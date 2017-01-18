using System;

namespace Timestamps.BLL.DataContracts
{
    public class Hourage
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string UserId { get; set; }
        public string WorkDescription { get; set; }
        public DateTime Date { get; set; }
        public double Hours { get; set; }
        public Project Project { get; set; }
        public User User { get; set; }
    }
}