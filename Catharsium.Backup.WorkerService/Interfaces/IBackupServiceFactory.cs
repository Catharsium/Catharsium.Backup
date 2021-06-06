using Catharsium.Backup.WorkerService._Configuration;

namespace Catharsium.Backup.WorkerService.Interfaces
{
    public interface IBackupServiceFactory
    {
        IBackupService CreateFor(TaskSettings taskSettings);
    }
}