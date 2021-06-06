using Catharsium.Backup.WorkerService._Configuration;
using Catharsium.Util.IO.Interfaces;
using System.Threading.Tasks;

namespace Catharsium.Backup.WorkerService.Interfaces
{
    public interface IBackupService
    {
        Strategy SupportedStrategy { get; }

        Task Synchronize(IFile file, string targetFolder);
    }
}