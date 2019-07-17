using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using UnifiedCloudStorage.Core;

namespace GoogleDriveWrapper
{
    public class UcsDirectoryInfo : AbUcsDirectoryInfo
    {
        public override void Create()
        {
            throw new NotImplementedException();
        }

        public override void Create(DirectorySecurity directorySecurity)
        {
            throw new NotImplementedException();
        }

        public override AbUcsDirectoryInfo CreateSubdirectory(string path)
        {
            throw new NotImplementedException();
        }

        public override AbUcsDirectoryInfo CreateSubdirectory(string path, DirectorySecurity directorySecurity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(bool recursive)
        {
            throw new NotImplementedException();
        }

        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<AbUcsDirectoryInfo> EnumerateDirectories(string searchPattern, SearchOption searchOption)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<AbUcsDirectoryInfo> EnumerateDirectories()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<AbUcsDirectoryInfo> EnumerateDirectories(string searchPattern)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<FileInfo> EnumerateFiles(string searchPattern, SearchOption searchOption)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<FileInfo> EnumerateFiles(string searchPattern)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<FileInfo> EnumerateFiles()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<AbUcsFileSystemInfo> EnumerateFileSystemInfos(string searchPattern, SearchOption searchOption)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<AbUcsFileSystemInfo> EnumerateFileSystemInfos(string searchPattern)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<AbUcsFileSystemInfo> EnumerateFileSystemInfos()
        {
            throw new NotImplementedException();
        }

        public override DirectorySecurity GetAccessControl()
        {
            throw new NotImplementedException();
        }

        public override DirectorySecurity GetAccessControl(AccessControlSections includeSections)
        {
            throw new NotImplementedException();
        }

        public override AbUcsDirectoryInfo[] GetDirectories()
        {
            throw new NotImplementedException();
        }

        public override AbUcsDirectoryInfo[] GetDirectories(string searchPattern)
        {
            throw new NotImplementedException();
        }

        public override AbUcsDirectoryInfo[] GetDirectories(string searchPattern, SearchOption searchOption)
        {
            throw new NotImplementedException();
        }

        public override FileInfo[] GetFiles()
        {
            throw new NotImplementedException();
        }

        public override FileInfo[] GetFiles(string searchPattern, SearchOption searchOption)
        {
            throw new NotImplementedException();
        }

        public override FileInfo[] GetFiles(string searchPattern)
        {
            throw new NotImplementedException();
        }

        public override AbUcsFileSystemInfo[] GetFileSystemInfos()
        {
            throw new NotImplementedException();
        }

        public override AbUcsFileSystemInfo[] GetFileSystemInfos(string searchPattern, SearchOption searchOption)
        {
            throw new NotImplementedException();
        }

        public override AbUcsFileSystemInfo[] GetFileSystemInfos(string searchPattern)
        {
            throw new NotImplementedException();
        }

        public override void MoveTo(string destDirName)
        {
            throw new NotImplementedException();
        }

        public override void SetAccessControl(DirectorySecurity directorySecurity)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
