using Microsoft.Extensions.Options;

namespace Catharsium.Backup.WorkerService.Tests._Fixture
{
    public class MockConfiguration<T> : IOptions<T> where T : class, new()
    {
        public T Value { get; }


        public MockConfiguration(T configuration)
        {
            this.Value = configuration;
        }
    }
}