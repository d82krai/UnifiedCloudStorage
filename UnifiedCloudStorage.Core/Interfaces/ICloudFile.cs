using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnifiedCloudStorage.Core
{
    public interface ICloudFile
    {
        //-	Name
        //-	Path
        //-	DirectoryName
        //-	Length
        //-	Create
        //-	Rename
        //-	MoveTo
        //-	Delete
        //-	CopyTo
        //-	Exists
        //-	Replace
        //-	FileStream Read()
        //-	string ReadAllText()
        //-	void WriteAllText()
        //-	byte[] ReadAllBytes()
        //-	void WriteAllBytes()

        string Name { get; set; }
        string Path { get; set; }
        string DirectoryName { get; set; }
        long Length { get; set; }

        Task Create(string filePath, FileStream fileStream);

        Task Rename(string filePath, string newFileName);

        Task MoveTo(string sourceFilePath, string destiFilePath);

        Task Delete(string filePath);

        Task CopyTo(string sourceFilePath, string destiFilePath);

        Task<bool> Exists(string filePath);

        Task Replace(string filePath, FileStream fileStream);

        Task Replace(string sourceFilePath, string destiFilePath);

        Task<FileStream> Read(string filePath);

        Task<string> ReadAllText(string filePath);

        Task WriteAllText(string filePath, string content);

        Task<byte[]> ReadAllBytes(string filePath);

        Task WriteAllBytes(string filePath, byte[] byteArr);
    }
}
