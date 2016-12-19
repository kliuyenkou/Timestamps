using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Timestamps.DAL.Entities;

namespace Timestamps.DAL.EFDataReceiving
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", false)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectNomination> ProjectNominations { get; set; }
        public DbSet<Hourage> Hourages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectNomination>().HasRequired(pn => pn.Project).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Hourage>().HasRequired(h => h.Project).WithMany().WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}