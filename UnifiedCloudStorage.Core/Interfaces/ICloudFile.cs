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

        //CloudFileInfo CloudFileInfo { get; set; }

        void Create(string filePath, FileStream fileStream);

        void Rename(string filePath, string newFileName);

        void MoveTo(string sourceFilePath, string destiFilePath);

        void Delete(string filePath);

        void CopyTo(string sourceFilePath, string destiFilePath);

        bool Exists(string filePath);

        void Replace(string filePath, FileStream fileStream);

        void Replace(string sourceFilePath, string destiFilePath);

        Stream Read(string filePath);

        string ReadAllText(string filePath);

        void WriteAllText(string filePath, string content);

        byte[] ReadAllBytes(string filePath);

        void WriteAllBytes(string filePath, byte[] byteArr);

        void FetchDetail();

        string GetFullPath();
    }

    
}
