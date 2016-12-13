using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timestamps.BLL.Models;

namespace Timestamps.BLL.Interfaces
{
    public interface IHourageService
    {
        IEnumerable<Hourage> GetUserHourageRecordsWithProject(string userId);
        void Add(Hourage hourage);
        Hourage GetHourageById(int hourageId);
        void Delete(int hourageId);
        void Dispose();

    }
}
