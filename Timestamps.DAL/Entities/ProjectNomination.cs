using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timestamps.DAL.Entities
{
    public class ProjectNomination
    {
        [Key]
        [Column(Order = 1)]
        public int ProjectId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string UserId { get; set; }

        public Project Project { get; set; }

        public ApplicationUser User { get; set; }
    }
}