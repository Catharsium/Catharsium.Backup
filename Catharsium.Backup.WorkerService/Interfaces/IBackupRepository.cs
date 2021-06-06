using Catharsium.Backup.WorkerService.Entities;
using Catharsium.Util.IO.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catharsium.Backup.WorkerService.Interfaces
{
    public interface IBackupRepository
    {
        IEnumerable<BackupFile> GetAll();
        IEnumerable<BackupFile> GetFor(IFile sourceFile);
        Task<BackupFile> AddFor(IFile sourceFile, string name);
        Task<BackupFile> UpdateFor(IFile sourceFile, string name);
    }
}