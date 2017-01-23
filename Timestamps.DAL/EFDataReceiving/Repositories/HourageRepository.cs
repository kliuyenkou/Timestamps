using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using Timestamps.DAL.DataInterfaces.Repositories;
using Timestamps.DAL.Entities;

namespace Timestamps.DAL.EFDataReceiving.Repositories
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

        public void RemoveById(int hourageId)
        {
            var record = context.Hourages.Find(hourageId);
            if (record != null) context.Hourages.Remove(record);
        }

        public Hourage Get(int hourageId)
        {
            try {
                var record = context.Hourages.Find(hourageId);
                if (record == null) {
                    throw new ObjectNotFoundException("Record with given id not found");
                }
                return record;
            }
            catch (Exception ex) {
                throw new ObjectNotFoundException("Record not found. See inner exception.", ex);
            }
        }
    }
}