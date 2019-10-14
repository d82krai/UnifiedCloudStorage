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
using UnifiedCloudStorage.Core;

namespace GoogleDriveWrapper
{
    public class GDriveDirectory : ICloudDirectory
    {
        DriveService service = null;

        public GDriveDirectory()
        {
            service = GDriveHelper.GetService();
        }

        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Path { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICloudDirectory Parent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void CopyTo(string sourceDirectoryPath, string destiDirectoryPath)
        {
            throw new NotImplementedException();
        }

        public void Create(string directoryPath)
        {
            Google.Apis.Drive.v3.Data.File fileMetadata = new Google.Apis.Drive.v3.Data.File();
            fileMetadata.Name = "Invoices";
            fileMetadata.MimeType = "application/vnd.google-apps.folder";
            service.Files.Create(fileMetadata);
        }

        public void Delete(string directoryPath)
        {
            throw new NotImplementedException();
        }

        public FileStream Download()
        {
            throw new NotImplementedException();
        }

        public bool Exists(string directoryPath)
        {
            try
            {
                var tree = GDriveHelper.GetFolderTree(directoryPath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<ICloudFile> GetAllFiles(string directoryPath)
        {
            GDriveFile parentGDriveFile = new GDriveFile();
            var tree = GDriveHelper.GetFolderTree(directoryPath);
            List<ICloudFile> ret = new List<ICloudFile>();

            var currentNode = tree;
            do
            {
                currentNode = currentNode.Children.FirstOrDefault();
            } while (currentNode != null && currentNode.Children.Count > 0);

            var fileRequest = service.Files.List();
            fileRequest.Q = $"'{currentNode.FileId}' in parents and trashed = false and mimeType != 'application/vnd.google-apps.folder'";
            fileRequest.Fields = GDriveHelper.standardFields;

            var list = new List<Google.Apis.Drive.v3.Data.File>();
            IList<Google.Apis.Drive.v3.Data.File> dirFiles = fileRequest.Execute().Files;
            foreach (var file in dirFiles)
            {
                GDriveFile gDriveFile = new GDriveFile()
                {
                    FileId = file.Id,
                    FileName = file.Name,
                    MimeType = file.MimeType,
                    LengthInBytes = file.Size,
                    IsFolder = false,
                    Parent = parentGDriveFile,
                    File = file
                };

                gDriveFile.Parent = currentNode;

                var fullPath = gDriveFile.GetFullPath();

                //parentGDriveFile.Children.Add(gDriveFile);
                ret.Add(gDriveFile);
            }
            return ret;
        }

        public List<ICloudFile> GetDirectories(string directoryPath)
        {
            var splitDirectories = directoryPath.Split(new char[] { '/', '\\' });
            var directory = splitDirectories[splitDirectories.Length - 1];
            var request = service.Files.List();
            request.Q = $"name = '{directory}' and trashed = false and mimeType = 'application/vnd.google-apps.folder'";
            request.Fields = GDriveHelper.standardFields;

            IList<Google.Apis.Drive.v3.Data.File> directories = request.Execute().Files;

            List<GDriveFile> retFiles = new List<GDriveFile>();
            foreach (var dir in directories)
            {
                var dirId = dir.Id;

                GDriveFile parentGDriveFile = new GDriveFile()
                {
                    FileId = dir.Id,
                    FileName = dir.Name,
                    MimeType = dir.MimeType,
                    LengthInBytes = dir.Size,
                    IsFolder = true
                };

                var fileRequest = service.Files.List();
                fileRequest.Q = $"'{dirId}' in parents and trashed = false and mimeType = 'application/vnd.google-apps.folder'";
                fileRequest.Fields = GDriveHelper.standardFields;

                var list = new List<Google.Apis.Drive.v3.Data.File>();
                IList<Google.Apis.Drive.v3.Data.File> dirFiles = fileRequest.Execute().Files;
                foreach (var file in dirFiles)
                {
                    GDriveFile gDriveFile = new GDriveFile()
                    {
                        FileId = file.Id,
                        FileName = file.Name,
                        MimeType = file.MimeType,
                        LengthInBytes = file.Size,
                        IsFolder = false,
                        Parent = parentGDriveFile,
                        File = file
                    };
                    parentGDriveFile.Children.Add(gDriveFile);
                }
            }


            throw new NotImplementedException();
        }

        public List<ICloudFile> GetFiles(string directoryPath)
        {
            throw new NotImplementedException();
        }

        public void MoveTo(string sourceDirectoryPath, string destiDirectoryPath)
        {
            throw new NotImplementedException();
        }

        public void Rename(string sourceDirectoryPath, string newDirectoryName)
        {
            throw new NotImplementedException();
        }
    }
}
