using Catharsium.Backup.WorkerService.Interfaces;
using Catharsium.Backup.WorkerService.Logic.BackupRepository;
using Catharsium.Backup.WorkerService.Logic.BackupServices;
using Catharsium.Backup.WorkerService.Logic.Tasks;
using Catharsium.Util._Configuration;
using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.IO._Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Backup.WorkerService._Configuration
{
    public static class BackupServiceRegistration
    {
        public static IServiceCollection AddBackupWorkerService(this IServiceCollection services, IConfiguration config)
        {
            var configuration = config.Load<BackupServiceSettings>();
            services.AddSingleton<BackupServiceSettings, BackupServiceSettings>(_ => configuration);

            services.AddCatharsiumUtilities(config);
            services.AddIoUtilities(config);

            services.AddSingleton<IBackupFileRepositoryFactory, BackupFileRepositoryFactory>();

            services.AddSingleton<IBackupFileFactory, BackupFileFactory>();
            services.AddSingleton<IBackupTaskLauncher, BackupTaskLauncher>();

            services.AddSingleton<IBackupService, VersionedBackupService>();

            return services;
        }
    }
}