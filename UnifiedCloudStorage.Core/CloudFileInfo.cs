using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnifiedCloudStorage.Core
{
    public class CloudFileInfo
    {
        public CloudFileInfo()
        {
            this.Children = new List<CloudFileInfo>();
        }
        public string FileId { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public long? LengthInBytes { get; set; }
        public string Path { get; set; }
        public string DirectoryName { get; set; }
        public bool IsFolder { get; set; }
        public CloudFileInfo Parent { get; set; }
        public List<CloudFileInfo> Children { get; set; }
    }
}
