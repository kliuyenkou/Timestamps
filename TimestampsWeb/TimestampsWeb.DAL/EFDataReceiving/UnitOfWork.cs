using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimestampsWeb.TimestampsWeb.DAL.Interfaces;
using TimestampsWeb.Models;

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

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}