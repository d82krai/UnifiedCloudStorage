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
        ClientSecrets cs = new ClientSecrets();
        DriveService service = null;

        public GDriveDirectory()
        {
            cs.ClientId = "660084537600-o0m4d4nt4e7qlcli01docs264iffl3tr.apps.googleusercontent.com";
            cs.ClientSecret = "T3lRQ8tFMmHc4NtVPGPAI849";

            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        cs,
                        new[] { DriveService.Scope.Drive },
                        "user",
                        CancellationToken.None,
                        null
                    ).Result;

            service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "OAuth client"
            });
        }

        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Path { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICloudDirectory Parent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task CopyTo(string sourceDirectoryPath, string destiDirectoryPath)
        {
            throw new NotImplementedException();
        }

        public async Task Create(string directoryPath)
        {
            await Task.Run(() =>
                    {
                        Google.Apis.Drive.v3.Data.File fileMetadata = new Google.Apis.Drive.v3.Data.File();
                        fileMetadata.Name = "Invoices";
                        fileMetadata.MimeType = "application/vnd.google-apps.folder";
                        service.Files.Create(fileMetadata);
                    }
                );
        }

        public Task Delete(string directoryPath)
        {
            throw new NotImplementedException();
        }

        public Task<FileStream> Download()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(string directoryPath)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetAllFiles(string directoryPath)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetDirectories(string directoryPath)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetFiles(string directoryPath)
        {
            throw new NotImplementedException();
        }

        public Task MoveTo(string sourceDirectoryPath, string destiDirectoryPath)
        {
            throw new NotImplementedException();
        }

        public Task Rename(string sourceDirectoryPath, string newDirectoryName)
        {
            throw new NotImplementedException();
        }
    }
}
