using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimestampsWeb.TimestampsWeb.DAL.Interfaces;
using TimestampsWeb.Models;
using System.Data.Entity.Validation;
using System.Text;

namespace TimestampsWeb.TimestampsWeb.DAL.EFDataReceiving
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Projects = new ProjectRepository(_context);
            ProjectNominations = new ProjectNominationRepository(_context);
            Hourages = new HourageRepository(_context);
        }

        public IProjectRepository Projects { get; private set; }
        public IProjectNominationRepository ProjectNominations { get; private set; }
        public IHourageRepository Hourages { get; private set; }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        /// Wrapper for SaveChanges adding the Validation Messages to the generated exception
        public int SaveChangesWithErrors()
        {
            try {
                return _context.SaveChanges();
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

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}