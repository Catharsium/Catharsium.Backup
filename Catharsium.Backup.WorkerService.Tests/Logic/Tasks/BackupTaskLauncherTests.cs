using Catharsium.Backup.WorkerService._Configuration;
using Catharsium.Backup.WorkerService.Interfaces;
using Catharsium.Backup.WorkerService.Logic.Tasks;
using Catharsium.Util.IO.Interfaces;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Catharsium.Backup.WorkerService.Tests.Logic.Tasks
{
    [TestClass]
    public class BackupTaskLauncherTests : TestFixture<BackupTaskLauncher>
    {
        [TestMethod]
        public async Task Run_Versioned_FileTask_SynchronizesFile()
        {
            var settings = new BackupServiceSettings {
                Tasks = new[] {
                    new TaskSettings {
                        Strategy = Strategy.Versioned,
                        Source = Directory.GetFiles(AppContext.BaseDirectory).First(),
                        Target = "My target"
                    }
                }
            };
            this.SetDependency(settings);
            var file = Substitute.For<IFile>();
            this.GetDependency<IFileFactory>().CreateFile(settings.Tasks[0].Source).Returns(file);

            await this.Target.Run();
            await this.GetDependency<IBackupService>().Received().Synchronize(file, settings.Tasks[0].Target);
        }


        [TestMethod]
        public async Task Run_Versioned_DirectoryTask_SynchronizesEachFile()
        {
            var settings = new BackupServiceSettings {
                Tasks = new[] {
                    new TaskSettings {
                        Strategy = Strategy.Versioned,
                        Source = AppContext.BaseDirectory,
                        Target = "My target"
                    }
                }
            };
            this.SetDependency(settings);
            var files = new[] {
                Substitute.For<IFile>(),
                Substitute.For<IFile>()
            };
            var directory = Substitute.For<IDirectory>();
            directory.GetFiles().Returns(files);
            this.GetDependency<IFileFactory>().CreateDirectory(settings.Tasks[0].Source).Returns(directory);

            await this.Target.Run();
            foreach (var file in files) {
                await this.GetDependency<IBackupService>().Received().Synchronize(file, settings.Tasks[0].Target);
            }
        }
    }
}