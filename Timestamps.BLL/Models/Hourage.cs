using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timestamps.BLL.Models
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
        public ApplicationUser User { get; set; }
    }
}
