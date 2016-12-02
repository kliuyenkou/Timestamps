using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Timestamps.DAL.DbModels;

namespace Timestamps.DAL
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectNomination> ProjectNominations { get; set; }
        public DbSet<Hourage> Hourages { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectNomination>().HasRequired(pn => pn.Project).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Hourage>().HasRequired(h => h.Project).WithMany().WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }

    }

    
}