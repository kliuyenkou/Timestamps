namespace Timestamps.DAL.Management
{
    public enum ArchiveRestoreOperationResult
    {
        ProjectNotFound = 0,
        ProjectArchivedSuccessfully = 1,
        WarningProjectAlreadyArchived = 2,
        ProjectRestoredSuccessfully = 3,
        WarningProjectIsActive = 4
    }
}