using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimestampsWeb.TimestampsWeb.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IProjectRepository Projects { get; }
        IProjectNominationRepository ProjectNominations { get; }
        IHourageRepository Hourages { get; }
        void Dispose();
        void SaveChanges();
        int SaveChangesWithErrors();
    }
}
