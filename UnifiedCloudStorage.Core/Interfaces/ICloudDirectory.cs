using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnifiedCloudStorage.Core
{
    public interface ICloudDirectory
    {

        //-	Name
        //-	Path
        //-	Parent
        //-	Create
        //-	Rename
        //-	MoveTo
        //-	Delete
        //-	CopyTo
        //-	Exists
        //-	GetFiles: Get files under directory
        //-	GetAllFiles: Get All Files under directory, recursively
        //-	GetDirectories: Get Directories under current directory

        string Name { get; set; }

        string Path { get; set; }

        ICloudDirectory Parent { get; set; }

        Task Create(string directoryPath);

        Task Rename(string sourceDirectoryPath, string newDirectoryName);

        Task MoveTo(string sourceDirectoryPath, string destiDirectoryPath);

        Task Delete(string directoryPath);

        Task CopyTo(string sourceDirectoryPath, string destiDirectoryPath);

        Task<bool> Exists(string directoryPath);

        Task<List<string>> GetFiles(string directoryPath);

        Task<List<string>> GetAllFiles(string directoryPath);

        Task<List<string>> GetDirectories(string directoryPath);

        Task<FileStream> Download();

    }
}
