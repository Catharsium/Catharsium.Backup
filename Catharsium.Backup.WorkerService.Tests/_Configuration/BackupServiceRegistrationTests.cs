using Catharsium.Backup.WorkerService._Configuration;
using Catharsium.Backup.WorkerService.Interfaces;
using Catharsium.Backup.WorkerService.Logic.BackupRepository;
using Catharsium.Backup.WorkerService.Logic.BackupServices;
using Catharsium.Backup.WorkerService.Logic.Tasks;
using Catharsium.Util.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Backup.WorkerService.Tests._Configuration
{
    [TestClass]
    public class BackupServiceRegistrationTests
    {
        [TestMethod]
        public void AddBackupWorkerService_RegistersDependencies()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();
            var configuration = Substitute.For<IConfiguration>();

            serviceCollection.AddBackupWorkerService(configuration);
            serviceCollection.ReceivedRegistration<IBackupFileRepositoryFactory, BackupFileRepositoryFactory>();

            serviceCollection.ReceivedRegistration<IBackupFileFactory, BackupFileFactory>();
            serviceCollection.ReceivedRegistration<IBackupTaskLauncher, BackupTaskLauncher>();

            serviceCollection.ReceivedRegistration<IBackupService, VersionedBackupService>();
        }
    }
}