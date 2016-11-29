using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Text;

namespace TimestampsWeb.Models
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

    public static class ExtensionsApplicationDbContext
    {
        /// Wrapper for SaveChanges adding the Validation Messages to the generated exception
        public static int SaveChangesWithErrors(this DbContext context)
        {
            try {
                return context.SaveChanges();
            }
            catch (DbEntityValidationException ex) {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors) {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors) {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                );
            }
        }
    }
}