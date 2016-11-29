using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimestampsWeb.TimestampsWeb.DAL.Interfaces;
using TimestampsWeb.Models;
using System.Data.Entity;

namespace TimestampsWeb.TimestampsWeb.DAL.EFDataReceiving
{
    public class HourageRepository : Repository<Hourage>, IHourageRepository
    {
        public HourageRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Hourage> GetUserHourageRecordsWithProject(string userId)
        {
            return context.Hourages.Where(h => h.UserId == userId).Include(h => h.Project).Include(h => h.User).ToList();
        }
    }
}