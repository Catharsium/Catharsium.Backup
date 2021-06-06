using Catharsium.Backup.WorkerService._Configuration;
using Catharsium.Backup.WorkerService.Interfaces;
using Catharsium.Util.IO.Extensions;
using Catharsium.Util.IO.Interfaces;
using System.Threading.Tasks;

namespace Catharsium.Backup.WorkerService.Logic.Tasks
{
    public class BackupTaskLauncher : IBackupTaskLauncher
    {
        private readonly IBackupService backupFileService;
        private readonly IFileFactory fileFactory;
        private readonly BackupServiceSettings settings;


        public BackupTaskLauncher(IBackupService backupFileService, IFileFactory fileFactory, BackupServiceSettings settings)
        {
            this.backupFileService = backupFileService;
            this.fileFactory = fileFactory;
            this.settings = settings;
        }


        public async Task Run()
        {
            foreach (var task in this.settings.Tasks) {
                if (task.Source.IsFile()) {
                    var file = this.fileFactory.CreateFile(task.Source);
                    await this.backupFileService.Synchronize(file, task.Target);
                }

                if (task.Source.IsDirectory()) {
                    var directory = this.fileFactory.CreateDirectory(task.Source);
                    foreach (var file in directory.GetFiles()) {
                        await this.backupFileService.Synchronize(file, task.Target);
                    }
                }
            }
        }
    }
}