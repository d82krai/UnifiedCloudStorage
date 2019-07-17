using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using UnifiedCloudStorage.Core;

namespace GoogleDriveWrapper
{
    public class UcsFileSystemInfo : AbUcsFileSystemInfo
    {
        public override bool Exists => throw new NotImplementedException();

        public override string Name => throw new NotImplementedException();

        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        public override void Refresh()
        {
            throw new NotImplementedException();
        }
    }
}
