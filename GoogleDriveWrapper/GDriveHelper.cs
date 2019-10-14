using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Caching;
using System.IO;

namespace GoogleDriveWrapper
{
    public class GDriveHelper
    {
        static ClientSecrets cs = new ClientSecrets();
        static DriveService service = null;
        public static string standardFields = "files(id, name, mimeType, fileExtension, parents, createdTime, description, modifiedTime)";
        private static readonly string[] _scopes =
        {
            DriveService.Scope.Drive,
            DriveService.Scope.DriveAppdata,
            DriveService.Scope.DriveFile,
            DriveService.Scope.DriveMetadata,
            DriveService.Scope.DriveMetadataReadonly,
            DriveService.Scope.DrivePhotosReadonly,
            DriveService.Scope.DriveReadonly,
            DriveService.Scope.DriveScripts
        };

        public static DriveService GetService()
        {
            cs.ClientId = "660084537600-o0m4d4nt4e7qlcli01docs264iffl3tr.apps.googleusercontent.com";
            cs.ClientSecret = "T3lRQ8tFMmHc4NtVPGPAI849";

            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        cs,
                        _scopes,
                        "user",
                        CancellationToken.None,
                        null
                    ).Result;

            service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "OAuth client"
            });
            return service;
        }

        public static GDriveFile GetParentDetail(GDriveFile gDriveFile, bool recursive)
        {
            var dirId = gDriveFile.Parent.FileId;

            var fileRequest = service.Files.Get(dirId);//.List();
            fileRequest.Fields = "*";

            var dirFiles = fileRequest.Execute();
            if (dirFiles != null)
            {
                var file = dirFiles;
                GDriveFile gDriveFile1 = new GDriveFile()
                {
                    FileId = file.Id,
                    FileName = file.Name,
                    MimeType = file.MimeType,
                    LengthInBytes = file.Size,
                    IsFolder = true,
                    File = file
                };

                if (file.Parents != null && file.Parents.Count > 0)
                    gDriveFile1.Parent = new GDriveFile() { FileId = file.Parents[0] };

                gDriveFile.Parent = gDriveFile1;

                if (recursive && gDriveFile1.Parent != null && !string.IsNullOrWhiteSpace(gDriveFile1.Parent.FileId))
                    gDriveFile1 = GetParentDetail(gDriveFile1, recursive);
            }

            return gDriveFile;
        }

        public static GDriveFile GetFolderTree(string directoryPath)
        {
            var splitDirectories = directoryPath.Split(new char[] { '/', '\\' });
            var root = service.Files.Get("root").Execute();

            GDriveFile gDriveFile = new GDriveFile()
            {
                FileId = root.Id,
                FileName = root.Name,
                MimeType = root.MimeType,
                LengthInBytes = root.Size,
                IsFolder = true,
                File = root
            };

            GDriveFile currentFile = gDriveFile;
            for (int i = 0; i < splitDirectories.Length; i++)
            {
                var dir = splitDirectories[i];
                var child = GetChildFolderByName(currentFile, dir);
                currentFile = child;
            }

            return gDriveFile;
        }

        public static GDriveFile GetLastFolderInTree(GDriveFile tree)
        {
            var currentNode = tree;
            do
            {
                currentNode = currentNode.Children.FirstOrDefault();
            } while (currentNode != null && currentNode.Children.Count > 0);
            return currentNode;
        }

        public static GDriveFile GetChildFolderByName(GDriveFile file, string name)
        {
            var fileRequest = service.Files.List();
            fileRequest.Q = $"'{file.FileId}' in parents and trashed = false and mimeType = 'application/vnd.google-apps.folder'";
            fileRequest.Fields = "*";

            var filess = fileRequest.Execute().Files;
            var dir = fileRequest.Execute().Files.Where(m => m.Name == name).FirstOrDefault();

            GDriveFile gDriveFile = new GDriveFile()
            {
                FileId = dir.Id,
                FileName = dir.Name,
                MimeType = dir.MimeType,
                LengthInBytes = dir.Size,
                IsFolder = true,
                File = dir
            };

            file.Children.Add(gDriveFile);
            return gDriveFile;
        }

        public static GDriveFile GetChildFileByName(GDriveFile file, string name)
        {
            var fileRequest = service.Files.List();
            fileRequest.Q = $"'{file.FileId}' in parents and trashed = false and mimeType != 'application/vnd.google-apps.folder'";
            fileRequest.Fields = "*";

            var filess = fileRequest.Execute().Files;
            var dir = fileRequest.Execute().Files.Where(m => m.Name == name).FirstOrDefault();

            GDriveFile gDriveFile = new GDriveFile()
            {
                FileId = dir.Id,
                FileName = dir.Name,
                MimeType = dir.MimeType,
                LengthInBytes = dir.Size,
                IsFolder = true,
                File = dir
            };

            file.Children.Add(gDriveFile);
            return gDriveFile;
        }

        public static GDriveFile GetFileByPath(string filePath)
        {
            var tree = GetFolderTree(filePath);
            var lastFolder = GetLastFolderInTree(tree);
            var file = GDriveHelper.GetChildFileByName(lastFolder, filePath.Split(new char[] { '/', '\\' }).LastOrDefault());
            return file;
        }

        public static GDriveFile GetFolderByPath(string filePath)
        {
            var tree = GetFolderTree(filePath);
            var lastFolder = GetLastFolderInTree(tree);
            return lastFolder;
        }

        public static Google.Apis.Drive.v3.Data.File GetFileById(string id)
        {
            var fileRequest = service.Files.Get(id);//.List();
            fileRequest.Fields = "*";

            var dirFile = fileRequest.Execute();
            return dirFile;
        }

        public static byte[] StreamToByteArray(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

    }
}
