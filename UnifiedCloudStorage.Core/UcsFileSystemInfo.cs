using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace UnifiedCloudStorage.Core
{
    public abstract class UcsFileSystemInfo
    {

        ////
        //// Summary:
        ////     Represents the fully qualified path of the directory or file.
        ////
        //// Exceptions:
        ////   T:System.IO.PathTooLongException:
        ////     The fully qualified path is 260 or more characters.
        //protected string FullPath;
        ////
        //// Summary:
        ////     The path originally specified by the user, whether relative or absolute.
        //protected string OriginalPath;

        ////
        //// Summary:
        ////     Initializes a new instance of the System.IO.UcsFileSystemInfo class.
        //protected UcsFileSystemInfo();


        ////
        //// Summary:
        ////     Initializes a new instance of the System.IO.UcsFileSystemInfo class with serialized
        ////     data.
        ////
        //// Parameters:
        ////   info:
        ////     The System.Runtime.Serialization.SerializationInfo that holds the serialized
        ////     object data about the exception being thrown.
        ////
        ////   context:
        ////     The System.Runtime.Serialization.StreamingContext that contains contextual information
        ////     about the source or destination.
        ////
        //// Exceptions:
        ////   T:System.ArgumentNullException:
        ////     The specified System.Runtime.Serialization.SerializationInfo is null.
        //protected UcsFileSystemInfo(SerializationInfo info, StreamingContext context);

        //
        // Summary:
        //     Gets or sets the time when the current file or directory was last written to.
        //
        // Returns:
        //     The time the current file was last written.
        //
        // Exceptions:
        //   T:System.IO.IOException:
        //     System.IO.UcsFileSystemInfo.Refresh cannot initialize the data.
        //
        //   T:System.PlatformNotSupportedException:
        //     The current operating system is not Windows NT or later.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     The caller attempts to set an invalid write time.
        public DateTime LastWriteTime { get; set; }
        //
        // Summary:
        //     Gets or sets the time, in coordinated universal time (UTC), that the current
        //     file or directory was last accessed.
        //
        // Returns:
        //     The UTC time that the current file or directory was last accessed.
        //
        // Exceptions:
        //   T:System.IO.IOException:
        //     System.IO.UcsFileSystemInfo.Refresh cannot initialize the data.
        //
        //   T:System.PlatformNotSupportedException:
        //     The current operating system is not Windows NT or later.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     The caller attempts to set an invalid access time.
        [ComVisible(false)]
        public DateTime LastAccessTimeUtc { get; set; }
        //
        // Summary:
        //     Gets or sets the time the current file or directory was last accessed.
        //
        // Returns:
        //     The time that the current file or directory was last accessed.
        //
        // Exceptions:
        //   T:System.IO.IOException:
        //     System.IO.UcsFileSystemInfo.Refresh cannot initialize the data.
        //
        //   T:System.PlatformNotSupportedException:
        //     The current operating system is not Windows NT or later.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     The caller attempts to set an invalid access time
        public DateTime LastAccessTime { get; set; }
        //
        // Summary:
        //     Gets or sets the creation time, in coordinated universal time (UTC), of the current
        //     file or directory.
        //
        // Returns:
        //     The creation date and time in UTC format of the current System.IO.UcsFileSystemInfo
        //     object.
        //
        // Exceptions:
        //   T:System.IO.IOException:
        //     System.IO.UcsFileSystemInfo.Refresh cannot initialize the data.
        //
        //   T:System.IO.DirectoryNotFoundException:
        //     The specified path is invalid; for example, it is on an unmapped drive.
        //
        //   T:System.PlatformNotSupportedException:
        //     The current operating system is not Windows NT or later.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     The caller attempts to set an invalid access time.
        [ComVisible(false)]
        public DateTime CreationTimeUtc { get; set; }
        //
        // Summary:
        //     Gets or sets the creation time of the current file or directory.
        //
        // Returns:
        //     The creation date and time of the current System.IO.UcsFileSystemInfo object.
        //
        // Exceptions:
        //   T:System.IO.IOException:
        //     System.IO.UcsFileSystemInfo.Refresh cannot initialize the data.
        //
        //   T:System.IO.DirectoryNotFoundException:
        //     The specified path is invalid; for example, it is on an unmapped drive.
        //
        //   T:System.PlatformNotSupportedException:
        //     The current operating system is not Windows NT or later.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     The caller attempts to set an invalid creation time.
        public DateTime CreationTime { get; set; }
        //
        // Summary:
        //     Gets a value indicating whether the file or directory exists.
        //
        // Returns:
        //     true if the file or directory exists; otherwise, false.
        public abstract bool Exists { get; }
        //
        // Summary:
        //     Gets the string representing the extension part of the file.
        //
        // Returns:
        //     A string containing the System.IO.UcsFileSystemInfo extension.
        public string Extension { get; }
        //
        // Summary:
        //     Gets or sets the time, in coordinated universal time (UTC), when the current
        //     file or directory was last written to.
        //
        // Returns:
        //     The UTC time when the current file was last written to.
        //
        // Exceptions:
        //   T:System.IO.IOException:
        //     System.IO.UcsFileSystemInfo.Refresh cannot initialize the data.
        //
        //   T:System.PlatformNotSupportedException:
        //     The current operating system is not Windows NT or later.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     The caller attempts to set an invalid write time.
        [ComVisible(false)]
        public DateTime LastWriteTimeUtc { get; set; }
        //
        // Summary:
        //     Gets the full path of the directory or file.
        //
        // Returns:
        //     A string containing the full path.
        //
        // Exceptions:
        //   T:System.IO.PathTooLongException:
        //     The fully qualified path and file name is 260 or more characters.
        //
        //   T:System.Security.SecurityException:
        //     The caller does not have the required permission.
        public virtual string FullName { get; }
        //
        // Summary:
        //     For files, gets the name of the file. For directories, gets the name of the last
        //     directory in the hierarchy if a hierarchy exists. Otherwise, the Name property
        //     gets the name of the directory.
        //
        // Returns:
        //     A string that is the name of the parent directory, the name of the last directory
        //     in the hierarchy, or the name of a file, including the file name extension.
        public abstract string Name { get; }
        //
        // Summary:
        //     Gets or sets the attributes for the current file or directory.
        //
        // Returns:
        //     System.IO.FileAttributes of the current System.IO.UcsFileSystemInfo.
        //
        // Exceptions:
        //   T:System.IO.FileNotFoundException:
        //     The specified file does not exist.
        //
        //   T:System.IO.DirectoryNotFoundException:
        //     The specified path is invalid; for example, it is on an unmapped drive.
        //
        //   T:System.Security.SecurityException:
        //     The caller does not have the required permission.
        //
        //   T:System.ArgumentException:
        //     The caller attempts to set an invalid file attribute. -or-The user attempts to
        //     set an attribute value but does not have write permission.
        //
        //   T:System.IO.IOException:
        //     System.IO.UcsFileSystemInfo.Refresh cannot initialize the data.
        public FileAttributes Attributes { get; set; }

        //
        // Summary:
        //     Deletes a file or directory.
        //
        // Exceptions:
        //   T:System.IO.DirectoryNotFoundException:
        //     The specified path is invalid; for example, it is on an unmapped drive.
        //
        //   T:System.IO.IOException:
        //     There is an open handle on the file or directory, and the operating system is
        //     Windows XP or earlier. This open handle can result from enumerating directories
        //     and files. For more information, see How to: Enumerate Directories and Files.
        public abstract void Delete();
        //
        // Summary:
        //     Sets the System.Runtime.Serialization.SerializationInfo object with the file
        //     name and additional exception information.
        //
        // Parameters:
        //   info:
        //     The System.Runtime.Serialization.SerializationInfo that holds the serialized
        //     object data about the exception being thrown.
        //
        //   context:
        //     The System.Runtime.Serialization.StreamingContext that contains contextual information
        //     about the source or destination.
        [ComVisible(false)]
        [SecurityCritical]
        public abstract void GetObjectData(SerializationInfo info, StreamingContext context);
        //
        // Summary:
        //     Refreshes the state of the object.
        //
        // Exceptions:
        //   T:System.IO.IOException:
        //     A device such as a disk drive is not ready.
        [SecuritySafeCritical]
        public abstract void Refresh();

    }
}
