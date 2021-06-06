using Catharsium.Backup.WorkerService.Entities;
using Catharsium.Util.IO.Interfaces;

namespace Catharsium.Backup.WorkerService.Interfaces
{
    public interface IBackupFileFactory
    {
        BackupFile GetExisting(IFile backupFile);

        BackupFile CreateNew(IFile sourceFile);
    }
}