using Catharsium.Util.IO.Interfaces;

namespace Catharsium.Backup.WorkerService.Interfaces
{
    public interface IBackupFileRepositoryFactory
    {
        IBackupRepository CreateFor(IDirectory folder);
    }
}