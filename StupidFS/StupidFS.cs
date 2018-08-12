using System;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using DokanNet;
using FileAccess = DokanNet.FileAccess;

namespace StupidFS
{
    class StupidFS : IDokanOperations
    {

        private const string FileContent = "CradftCode Crew 4 ever";
        
        static void Main(string[] args)
        {
            var m = new StupidFS();
            // mounting point, dokan options, num of threads
            m.Mount("g:\\", DokanOptions.DebugMode, 5);
        }

        public NtStatus CreateFile(string fileName, FileAccess access, FileShare share, FileMode mode, FileOptions options,
            FileAttributes attributes, DokanFileInfo info)
        {
            if (fileName.Equals(@"\carftCodeCrew.txt"))
            {
                info.Context = new MemoryStream(System.Text.Encoding.ASCII.GetBytes(FileContent));
            }
            
            return DokanResult.Success;
        }

        public void Cleanup(string fileName, DokanFileInfo info)
        {
        }

        public void CloseFile(string fileName, DokanFileInfo info)
        {
        }

        public NtStatus ReadFile(string fileName, byte[] buffer, out int bytesRead, long offset, DokanFileInfo info)
        {
            bytesRead = 0;

            if (info.Context is MemoryStream stream)
            {
                stream.Position = offset;
                bytesRead = stream.Read(buffer, 0, buffer.Length);
            }

            return DokanResult.Success;
        }

        public NtStatus WriteFile(string fileName, byte[] buffer, out int bytesWritten, long offset, DokanFileInfo info)
        {
            throw new NotImplementedException();
        }

        public NtStatus FlushFileBuffers(string fileName, DokanFileInfo info)
        {
            throw new NotImplementedException();
        }

        public NtStatus GetFileInformation(string fileName, out FileInformation fileInfo, DokanFileInfo info)
        {
            fileInfo = new FileInformation
            {
                FileName = "carftCodeCrew.txt",
                Attributes = 0,
                CreationTime = DateTime.Now,
                LastAccessTime = DateTime.Now,
                LastWriteTime = DateTime.Now,
                Length =  FileContent.Length * 8,
            };

            return DokanResult.Success;
        }

        public NtStatus FindFiles(string fileName, out IList<FileInformation> files, DokanFileInfo info)
        {
           var  fileInfo = new FileInformation
            {
                FileName = "carftCodeCrew.txt",
                Attributes = 0,
                CreationTime = DateTime.Now,
                LastAccessTime = DateTime.Now,
                LastWriteTime = DateTime.Now,
                Length =  FileContent.Length * 8,
            };

            files = new List<FileInformation> {fileInfo};
            
            return DokanResult.Success;
        }

        public NtStatus FindFilesWithPattern(string fileName, string searchPattern, out IList<FileInformation> files, DokanFileInfo info)
        {
           files = null;
           
           return DokanResult.NotImplemented;
        }

        public NtStatus SetFileAttributes(string fileName, FileAttributes attributes, DokanFileInfo info)
        {
            throw new NotImplementedException();
        }

        public NtStatus SetFileTime(string fileName, DateTime? creationTime, DateTime? lastAccessTime, DateTime? lastWriteTime,
            DokanFileInfo info)
        {
            throw new NotImplementedException();
        }

        public NtStatus DeleteFile(string fileName, DokanFileInfo info)
        {
            throw new NotImplementedException();
        }

        public NtStatus DeleteDirectory(string fileName, DokanFileInfo info)
        {
            throw new NotImplementedException();
        }

        public NtStatus MoveFile(string oldName, string newName, bool replace, DokanFileInfo info)
        {
            throw new NotImplementedException();
        }

        public NtStatus SetEndOfFile(string fileName, long length, DokanFileInfo info)
        {
            throw new NotImplementedException();
        }

        public NtStatus SetAllocationSize(string fileName, long length, DokanFileInfo info)
        {
            throw new NotImplementedException();
        }

        public NtStatus LockFile(string fileName, long offset, long length, DokanFileInfo info)
        {
            throw new NotImplementedException();
        }

        public NtStatus UnlockFile(string fileName, long offset, long length, DokanFileInfo info)
        {
            throw new NotImplementedException();
        }

        public NtStatus GetDiskFreeSpace(out long freeBytesAvailable, out long totalNumberOfBytes, out long totalNumberOfFreeBytes,
            DokanFileInfo info)
        {
            freeBytesAvailable = 512 * 1024 * 1024;
            totalNumberOfBytes = 1024 * 1024 * 1024;
            totalNumberOfFreeBytes = 512 * 1024 * 1024;

            return DokanResult.Success;
        }

        public NtStatus GetVolumeInformation(out string volumeLabel, out FileSystemFeatures features, out string fileSystemName,
            out uint maximumComponentLength, DokanFileInfo info)
        {
            volumeLabel = "CraftCode Crew";
            features = FileSystemFeatures.None;
            fileSystemName = "CCCFS";
            maximumComponentLength = 256;

            return DokanResult.Success;
        }

        public NtStatus GetFileSecurity(string fileName, out FileSystemSecurity security, AccessControlSections sections,
            DokanFileInfo info)
        {
            throw new NotImplementedException();
        }

        public NtStatus SetFileSecurity(string fileName, FileSystemSecurity security, AccessControlSections sections,
            DokanFileInfo info)
        {
            throw new NotImplementedException();
        }

        public NtStatus Mounted(DokanFileInfo info)
        {
            return DokanResult.Success;
        }

        public NtStatus Unmounted(DokanFileInfo info)
        {
            throw new NotImplementedException();
        }

        public NtStatus FindStreams(string fileName, out IList<FileInformation> streams, DokanFileInfo info)
        {
            throw new NotImplementedException();
        }
    }
}