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

        void Create(string directoryPath);

        void Rename(string sourceDirectoryPath, string newDirectoryName);

        void MoveTo(string sourceDirectoryPath, string destiDirectoryPath);

        void Delete(string directoryPath);

        void CopyTo(string sourceDirectoryPath, string destiDirectoryPath);

        bool Exists(string directoryPath);

        List<ICloudFile> GetFiles(string directoryPath);

        List<ICloudFile> GetAllFiles(string directoryPath);

        List<ICloudFile> GetDirectories(string directoryPath);

        FileStream Download();

    }
}
