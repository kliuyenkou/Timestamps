using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timestamps.BLL.Models
{
    public class ProjectNomination
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string UserId { get; set; }
        public Project Project { get; set; }
        public User User { get; set; }
    }
}
