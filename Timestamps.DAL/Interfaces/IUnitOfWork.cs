using System.Threading.Tasks;

namespace Timestamps.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IProjectRepository Projects { get; }
        IProjectNominationRepository ProjectNominations { get; }
        IHourageRepository Hourages { get; }
        IApplicationUserRepository ApplicationUsers { get; }
        void Dispose();
        void SaveChanges();
        Task SaveChangesAsync();
        int SaveChangesWithErrors();
    }
}
