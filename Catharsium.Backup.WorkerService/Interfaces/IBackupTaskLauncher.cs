using System.Threading.Tasks;

namespace Catharsium.Backup.WorkerService.Interfaces
{
    public interface IBackupTaskLauncher
    {
        Task Run();
    }
}