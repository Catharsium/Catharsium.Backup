using Catharsium.Util.IO.Interfaces;
using System;

namespace Catharsium.Backup.WorkerService.Entities
{
    public class BackupFile
    {
        public IFile File { get; private set; }

        public string SourceFileName { get; set; }

        public string SourceFileExtension { get; set; }

        public DateTime Timestamp { get; set; }

        public string Name { get; set; }


        public void SetFile(IFile file)
        {
            this.File = file;
        }
    }
}