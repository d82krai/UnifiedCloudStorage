using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using UnifiedCloudStorage.Core;

namespace GoogleDriveWrapper
{
    public class UcsFileInfo : AbUcsFileInfo
    {
        public override StreamWriter AppendText()
        {
            throw new NotImplementedException();
        }

        public override AbUcsFileInfo CopyTo(string destFileName)
        {
            throw new NotImplementedException();
        }

        public override AbUcsFileInfo CopyTo(string destFileName, bool overwrite)
        {
            throw new NotImplementedException();
        }

        public override FileStream Create()
        {
            throw new NotImplementedException();
        }

        public override StreamWriter CreateText()
        {
            throw new NotImplementedException();
        }

        public override void Decrypt()
        {
            throw new NotImplementedException();
        }

        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override void Encrypt()
        {
            throw new NotImplementedException();
        }

        public override FileSecurity GetAccessControl()
        {
            throw new NotImplementedException();
        }

        public override FileSecurity GetAccessControl(AccessControlSections includeSections)
        {
            throw new NotImplementedException();
        }

        public override void MoveTo(string destFileName)
        {
            throw new NotImplementedException();
        }

        public override FileStream Open(FileMode mode)
        {
            throw new NotImplementedException();
        }

        public override FileStream Open(FileMode mode, FileAccess access, FileShare share)
        {
            throw new NotImplementedException();
        }

        public override FileStream Open(FileMode mode, FileAccess access)
        {
            throw new NotImplementedException();
        }

        public override FileStream OpenRead()
        {
            throw new NotImplementedException();
        }

        public override StreamReader OpenText()
        {
            throw new NotImplementedException();
        }

        public override FileStream OpenWrite()
        {
            throw new NotImplementedException();
        }

        public override AbUcsFileInfo Replace(string destinationFileName, string destinationBackupFileName)
        {
            throw new NotImplementedException();
        }

        public override AbUcsFileInfo Replace(string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors)
        {
            throw new NotImplementedException();
        }

        public override void SetAccessControl(FileSecurity fileSecurity)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
