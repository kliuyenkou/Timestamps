namespace Timestamps.DAL.Interfaces
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
