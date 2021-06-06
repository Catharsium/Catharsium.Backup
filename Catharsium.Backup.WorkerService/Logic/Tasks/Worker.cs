using Catharsium.Backup.WorkerService.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Catharsium.Backup.WorkerService.Logic.Tasks
{
    public class Worker : BackgroundService
    {
        private readonly IBackupTaskLauncher backupTask;
        private readonly ILogger<Worker> logger;


        public Worker(IBackupTaskLauncher backupTask, ILogger<Worker> logger)
        {
            this.backupTask = backupTask;
            this.logger = logger;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested) {
                this.logger.LogInformation("Starting Backup...");
                await this.backupTask.Run();
                this.logger.LogInformation("Finished Bakcup.");
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}