using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using UnifiedCloudStorage.Core;

namespace GoogleDriveWrapper
{
    public class GDriveFile : ICloudFile
    {
        DriveService service = null;

        public GDriveFile()
        {
            service = GDriveHelper.GetService();
            this.Children = new List<GDriveFile>();
        }

        //public CloudFileInfo CloudFileInfo { get; set; }

        public string FileId { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public long? LengthInBytes { get; set; }
        public string Path { get; set; }
        public string DirectoryName { get; set; }
        public bool IsFolder { get; set; }
        public Google.Apis.Drive.v3.Data.File File { get; set; }
        public GDriveFile Parent { get; set; }
        public List<GDriveFile> Children { get; set; }

        //TODO: Implement destiFilePath
        public void CopyTo(string sourceFilePath, string destiFilePath)
        {
            var file = GDriveHelper.GetFileByPath(sourceFilePath);
            service.Files.Copy(file.File, "");
        }

        public void Create(string filePath, FileStream fileStream)
        {
            var FileMetaData = new Google.Apis.Drive.v3.Data.File();
            FileMetaData.Name = System.IO.Path.GetFileName(filePath);
            FileMetaData.MimeType = MimeMapping.GetMimeMapping(filePath);

            Google.Apis.Drive.v3.FilesResource.CreateMediaUpload request;

            request = service.Files.Create(FileMetaData, fileStream, FileMetaData.MimeType);
            request.Fields = "id";
            request.Upload();
        }

        public void Delete(string filePath)
        {
            var file = GDriveHelper.GetFileByPath(filePath);
            service.Files.Delete(file.FileId);
        }

        public bool Exists(string filePath)
        {
            return GDriveHelper.GetFileByPath(filePath) != null;
        }

        public void MoveTo(string sourceFilePath, string destiFilePath)
        {
            var file = GDriveHelper.GetFileByPath(sourceFilePath);
            var updateRequest = service.Files.Update(new Google.Apis.Drive.v3.Data.File(), file.FileId);
            GDriveDirectory gDriveDirectory = new GDriveDirectory();
            if (!gDriveDirectory.Exists(destiFilePath))
                throw new DirectoryNotFoundException(destiFilePath + " does not exists");

            var tree = GDriveHelper.GetFolderTree(destiFilePath);
            var lastFolder = GDriveHelper.GetLastFolderInTree(tree);
            updateRequest.AddParents = lastFolder.FileId;
            updateRequest.RemoveParents = file.File.Parents[0];
            updateRequest.Execute();
        }

        public Stream Read(string filePath)
        {
            var file = GDriveHelper.GetFileByPath(filePath);
            var request = service.Files.Get(file.FileId);
            MemoryStream memoryStream = new MemoryStream();
            request.Download(memoryStream);
            return memoryStream;
        }

        public byte[] ReadAllBytes(string filePath)
        {
            var ms = Read(filePath);
            return GDriveHelper.StreamToByteArray(ms);
        }

        public string ReadAllText(string filePath)
        {
            var ms = Read(filePath);
            StreamReader reader = new StreamReader(ms);
            return reader.ReadToEnd();
        }

        public void Rename(string filePath, string newFileName)
        {
            var file = GDriveHelper.GetFileByPath(filePath);
            Google.Apis.Drive.v3.Data.File gfile = new Google.Apis.Drive.v3.Data.File() { Name = newFileName };
            var updateRequest = service.Files.Update(gfile, file.FileId);
            updateRequest.Fields = "name";
            updateRequest.Execute();
        }

        public void Replace(string filePath, FileStream fileStream)
        {
            throw new NotImplementedException();
        }

        public void Replace(string sourceFilePath, string destiFilePath)
        {
            throw new NotImplementedException();
        }

        public void WriteAllBytes(string filePath, byte[] byteArr)
        {
            throw new NotImplementedException();
        }

        public void WriteAllText(string filePath, string content)
        {
            throw new NotImplementedException();
        }

        public void FetchDetail()
        {
            throw new NotImplementedException();
        }

        public string GetFullPath()
        {
            List<string> lstPath = new List<string>();
            if (this.Parent != null && !string.IsNullOrWhiteSpace(this.Parent.FileId))
            {
                var a = GDriveHelper.GetParentDetail(this, true);
                var currentNode = a;
                do
                {
                    lstPath.Add(currentNode.FileName);
                    if (currentNode.Parent != null)
                        currentNode = currentNode.Parent;
                } while (currentNode.Parent != null && currentNode.IsFolder);
            }
            lstPath.Reverse();

            return string.Join("/", lstPath);
        }

    }
}
