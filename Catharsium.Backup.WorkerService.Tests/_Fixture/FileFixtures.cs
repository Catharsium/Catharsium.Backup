using Catharsium.Util.IO.Interfaces;
using NSubstitute;

namespace Catharsium.Backup.WorkerService.Tests._Fixture
{
    public static class FileFixtures
    {
        public static string BackupFileName => "My file.2019-02-09.ext";

        public static IFile BackupFile {
            get {
                var result = Substitute.For<IFile>();
                result.Name.Returns(BackupFileName);
                return result;
            }
        }



        public static string OtherOriginalFileName => "My other file.ext";

        public static IFile OtherOriginalFile {
            get {
                var result = Substitute.For<IFile>();
                result.Name.Returns(OtherOriginalFileName);
                return result;
            }
        }
    }
}