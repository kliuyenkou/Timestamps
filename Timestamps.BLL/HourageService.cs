using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timestamps.BLL.Interfaces;
using Timestamps.BLL.Models;

namespace Timestamps.BLL
{
    public class HourageService : IHourageService
    {
        public IEnumerable<Hourage> GetUserHourageRecordsWithProject(string userId)
        {
            throw new NotImplementedException();
        }

        public void Add(Hourage hourage)
        {
            throw new NotImplementedException();
        }

        public void Delete(int hourageId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
