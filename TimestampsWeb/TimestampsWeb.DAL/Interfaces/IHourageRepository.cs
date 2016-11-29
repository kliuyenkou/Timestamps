using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimestampsWeb.Models;

namespace TimestampsWeb.TimestampsWeb.DAL.Interfaces
{
    public interface IHourageRepository : IRepository<Hourage>
    {
        IEnumerable<Hourage> GetUserHourageRecordsWithProject(string userId);
    }
    
}
