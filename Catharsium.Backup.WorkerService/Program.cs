using Catharsium.Backup.WorkerService._Configuration;
using Catharsium.Backup.WorkerService.Logic.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;

namespace Catharsium.Backup.WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", false, false);
                    var configuration = builder.Build();

                    services.AddLogging(configure => configure.AddConsole());
                    services.AddBackupWorkerService(configuration);
                    services.AddHostedService<Worker>();
                });
    }
}