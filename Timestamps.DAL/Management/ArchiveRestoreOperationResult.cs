namespace Timestamps.DAL.Management
{
    public enum ArchiveRestoreOperationResult
    {
        ProjectArchivedSuccessfully = 1,
        WarningProjectAlreadyArchived = 2,
        ProjectRestoredSuccessfully = 3,
        WarningProjectIsActive = 4
    }
}