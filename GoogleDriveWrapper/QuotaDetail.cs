using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnifiedCloudStorage.Core;

namespace GoogleDriveWrapper
{
    public class GDrive : ICloud
    {
        public long GetQuotaTotal()
        {
            throw new NotImplementedException();
        }

        public long GetQuotaUsed()
        {
            throw new NotImplementedException();
        }
    }
}
