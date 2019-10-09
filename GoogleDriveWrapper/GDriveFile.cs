using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnifiedCloudStorage.Core;

namespace GoogleDriveWrapper
{
    public class GDriveFile : ICloudFile
    {
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Path { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string DirectoryName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public long Length { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task CopyTo(string sourceFilePath, string destiFilePath)
        {
            throw new NotImplementedException();
        }

        public Task Create(string filePath, FileStream fileStream)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string filePath)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(string filePath)
        {
            throw new NotImplementedException();
        }

        public Task MoveTo(string sourceFilePath, string destiFilePath)
        {
            throw new NotImplementedException();
        }

        public Task<FileStream> Read(string filePath)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> ReadAllBytes(string filePath)
        {
            throw new NotImplementedException();
        }

        public Task<string> ReadAllText(string filePath)
        {
            throw new NotImplementedException();
        }

        public Task Rename(string filePath, string newFileName)
        {
            throw new NotImplementedException();
        }

        public Task Replace(string filePath, FileStream fileStream)
        {
            throw new NotImplementedException();
        }

        public Task Replace(string sourceFilePath, string destiFilePath)
        {
            throw new NotImplementedException();
        }

        public Task WriteAllBytes(string filePath, byte[] byteArr)
        {
            throw new NotImplementedException();
        }

        public Task WriteAllText(string filePath, string content)
        {
            throw new NotImplementedException();
        }
    }
}
