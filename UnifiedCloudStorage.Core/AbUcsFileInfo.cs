using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace UnifiedCloudStorage.Core
{
    public abstract class AbUcsFileInfo
    {

        ////
        //// Summary:
        ////     Initializes a new instance of the System.IO.UcsFileInfo class, which acts as a wrapper
        ////     for a file path.
        ////
        //// Parameters:
        ////   fileName:
        ////     The fully qualified name of the new file, or the relative file name. Do not end
        ////     the path with the directory separator character.
        ////
        //// Exceptions:
        ////   T:System.ArgumentNullException:
        ////     fileName is null.
        ////
        ////   T:System.Security.SecurityException:
        ////     The caller does not have the required permission.
        ////
        ////   T:System.ArgumentException:
        ////     The file name is empty, contains only white spaces, or contains invalid characters.
        ////
        ////   T:System.UnauthorizedAccessException:
        ////     Access to fileName is denied.
        ////
        ////   T:System.IO.PathTooLongException:
        ////     The specified path, file name, or both exceed the system-defined maximum length.
        ////     For example, on Windows-based platforms, paths must be less than 248 characters,
        ////     and file names must be less than 260 characters.
        ////
        ////   T:System.NotSupportedException:
        ////     fileName contains a colon (:) in the middle of the string.
        //[SecuritySafeCritical]
        //public UcsFileInfo(string fileName);

        //
        // Summary:
        //     Gets an instance of the parent directory.
        //
        // Returns:
        //     A System.IO.UcsDirectoryInfo object representing the parent directory of this file.
        //
        // Exceptions:
        //   T:System.IO.DirectoryNotFoundException:
        //     The specified path is invalid, such as being on an unmapped drive.
        //
        //   T:System.Security.SecurityException:
        //     The caller does not have the required permission.
        public AbUcsDirectoryInfo Directory { get; }
        //
        // Summary:
        //     Gets a string representing the directory's full path.
        //
        // Returns:
        //     A string representing the directory's full path.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     null was passed in for the directory name.
        //
        //   T:System.IO.PathTooLongException:
        //     The fully qualified path is 260 or more characters.
        //
        //   T:System.Security.SecurityException:
        //     The caller does not have the required permission.
        public string DirectoryName { get; }
        //
        // Summary:
        //     Gets the size, in bytes, of the current file.
        //
        // Returns:
        //     The size of the current file in bytes.
        //
        // Exceptions:
        //   T:System.IO.IOException:
        //     System.IO.UcsFileSystemInfo.Refresh cannot update the state of the file or directory.
        //
        //   T:System.IO.FileNotFoundException:
        //     The file does not exist.-or- The Length property is called for a directory.
        public long Length { get; }
        //
        // Summary:
        //     Gets the name of the file.
        //
        // Returns:
        //     The name of the file.
        public string Name { get; }
        //
        // Summary:
        //     Gets or sets a value that determines if the current file is read only.
        //
        // Returns:
        //     true if the current file is read only; otherwise, false.
        //
        // Exceptions:
        //   T:System.IO.FileNotFoundException:
        //     The file described by the current System.IO.UcsFileInfo object could not be found.
        //
        //   T:System.IO.IOException:
        //     An I/O error occurred while opening the file.
        //
        //   T:System.UnauthorizedAccessException:
        //     This operation is not supported on the current platform.-or- The caller does
        //     not have the required permission.
        //
        //   T:System.ArgumentException:
        //     The user does not have write permission, but attempted to set this property to
        //     false.
        public bool IsReadOnly { get; set; }
        //
        // Summary:
        //     Gets a value indicating whether a file exists.
        //
        // Returns:
        //     true if the file exists; false if the file does not exist or if the file is a
        //     directory.
        public bool Exists { get; }

        //
        // Summary:
        //     Creates a System.IO.StreamWriter that appends text to the file represented by
        //     this instance of the System.IO.UcsFileInfo.
        //
        // Returns:
        //     A new StreamWriter.
        public abstract StreamWriter AppendText();
        //
        // Summary:
        //     Copies an existing file to a new file, disallowing the overwriting of an existing
        //     file.
        //
        // Parameters:
        //   destFileName:
        //     The name of the new file to copy to.
        //
        // Returns:
        //     A new file with a fully qualified path.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     destFileName is empty, contains only white spaces, or contains invalid characters.
        //
        //   T:System.IO.IOException:
        //     An error occurs, or the destination file already exists.
        //
        //   T:System.Security.SecurityException:
        //     The caller does not have the required permission.
        //
        //   T:System.ArgumentNullException:
        //     destFileName is null.
        //
        //   T:System.UnauthorizedAccessException:
        //     A directory path is passed in, or the file is being moved to a different drive.
        //
        //   T:System.IO.DirectoryNotFoundException:
        //     The directory specified in destFileName does not exist.
        //
        //   T:System.IO.PathTooLongException:
        //     The specified path, file name, or both exceed the system-defined maximum length.
        //     For example, on Windows-based platforms, paths must be less than 248 characters,
        //     and file names must be less than 260 characters.
        //
        //   T:System.NotSupportedException:
        //     destFileName contains a colon (:) within the string but does not specify the
        //     volume.
        public abstract AbUcsFileInfo CopyTo(string destFileName);
        //
        // Summary:
        //     Copies an existing file to a new file, allowing the overwriting of an existing
        //     file.
        //
        // Parameters:
        //   destFileName:
        //     The name of the new file to copy to.
        //
        //   overwrite:
        //     true to allow an existing file to be overwritten; otherwise, false.
        //
        // Returns:
        //     A new file, or an overwrite of an existing file if overwrite is true. If the
        //     file exists and overwrite is false, an System.IO.IOException is thrown.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     destFileName is empty, contains only white spaces, or contains invalid characters.
        //
        //   T:System.IO.IOException:
        //     An error occurs, or the destination file already exists and overwrite is false.
        //
        //   T:System.Security.SecurityException:
        //     The caller does not have the required permission.
        //
        //   T:System.ArgumentNullException:
        //     destFileName is null.
        //
        //   T:System.IO.DirectoryNotFoundException:
        //     The directory specified in destFileName does not exist.
        //
        //   T:System.UnauthorizedAccessException:
        //     A directory path is passed in, or the file is being moved to a different drive.
        //
        //   T:System.IO.PathTooLongException:
        //     The specified path, file name, or both exceed the system-defined maximum length.
        //     For example, on Windows-based platforms, paths must be less than 248 characters,
        //     and file names must be less than 260 characters.
        //
        //   T:System.NotSupportedException:
        //     destFileName contains a colon (:) in the middle of the string.
        public abstract AbUcsFileInfo CopyTo(string destFileName, bool overwrite);
        //
        // Summary:
        //     Creates a file.
        //
        // Returns:
        //     A new file.
        public abstract FileStream Create();
        //
        // Summary:
        //     Creates a System.IO.StreamWriter that writes a new text file.
        //
        // Returns:
        //     A new StreamWriter.
        //
        // Exceptions:
        //   T:System.UnauthorizedAccessException:
        //     The file name is a directory.
        //
        //   T:System.IO.IOException:
        //     The disk is read-only.
        //
        //   T:System.Security.SecurityException:
        //     The caller does not have the required permission.
        public abstract StreamWriter CreateText();
        //
        // Summary:
        //     Decrypts a file that was encrypted by the current account using the System.IO.UcsFileInfo.Encrypt
        //     method.
        //
        // Exceptions:
        //   T:System.IO.DriveNotFoundException:
        //     An invalid drive was specified.
        //
        //   T:System.IO.FileNotFoundException:
        //     The file described by the current System.IO.UcsFileInfo object could not be found.
        //
        //   T:System.IO.IOException:
        //     An I/O error occurred while opening the file.
        //
        //   T:System.NotSupportedException:
        //     The file system is not NTFS.
        //
        //   T:System.PlatformNotSupportedException:
        //     The current operating system is not Microsoft Windows NT or later.
        //
        //   T:System.UnauthorizedAccessException:
        //     The file described by the current System.IO.UcsFileInfo object is read-only.-or-
        //     This operation is not supported on the current platform.-or- The caller does
        //     not have the required permission.
        [ComVisible(false)]
        public abstract void Decrypt();
        //
        // Summary:
        //     Permanently deletes a file.
        //
        // Exceptions:
        //   T:System.IO.IOException:
        //     The target file is open or memory-mapped on a computer running Microsoft Windows
        //     NT.-or-There is an open handle on the file, and the operating system is Windows
        //     XP or earlier. This open handle can result from enumerating directories and files.
        //     For more information, see How to: Enumerate Directories and Files.
        //
        //   T:System.Security.SecurityException:
        //     The caller does not have the required permission.
        //
        //   T:System.UnauthorizedAccessException:
        //     The path is a directory.
        [SecuritySafeCritical]
        public abstract void Delete();
        //
        // Summary:
        //     Encrypts a file so that only the account used to encrypt the file can decrypt
        //     it.
        //
        // Exceptions:
        //   T:System.IO.DriveNotFoundException:
        //     An invalid drive was specified.
        //
        //   T:System.IO.FileNotFoundException:
        //     The file described by the current System.IO.UcsFileInfo object could not be found.
        //
        //   T:System.IO.IOException:
        //     An I/O error occurred while opening the file.
        //
        //   T:System.NotSupportedException:
        //     The file system is not NTFS.
        //
        //   T:System.PlatformNotSupportedException:
        //     The current operating system is not Microsoft Windows NT or later.
        //
        //   T:System.UnauthorizedAccessException:
        //     The file described by the current System.IO.UcsFileInfo object is read-only.-or-
        //     This operation is not supported on the current platform.-or- The caller does
        //     not have the required permission.
        [ComVisible(false)]
        public abstract void Encrypt();
        //
        // Summary:
        //     Gets a System.Security.AccessControl.FileSecurity object that encapsulates the
        //     access control list (ACL) entries for the file described by the current System.IO.UcsFileInfo
        //     object.
        //
        // Returns:
        //     A System.Security.AccessControl.FileSecurity object that encapsulates the access
        //     control rules for the current file.
        //
        // Exceptions:
        //   T:System.IO.IOException:
        //     An I/O error occurred while opening the file.
        //
        //   T:System.PlatformNotSupportedException:
        //     The current operating system is not Microsoft Windows 2000 or later.
        //
        //   T:System.Security.AccessControl.PrivilegeNotHeldException:
        //     The current system account does not have administrative privileges.
        //
        //   T:System.SystemException:
        //     The file could not be found.
        //
        //   T:System.UnauthorizedAccessException:
        //     This operation is not supported on the current platform.-or- The caller does
        //     not have the required permission.
        public abstract FileSecurity GetAccessControl();
        //
        // Summary:
        //     Gets a System.Security.AccessControl.FileSecurity object that encapsulates the
        //     specified type of access control list (ACL) entries for the file described by
        //     the current System.IO.UcsFileInfo object.
        //
        // Parameters:
        //   includeSections:
        //     One of the System.Security.AccessControl.AccessControlSections values that specifies
        //     which group of access control entries to retrieve.
        //
        // Returns:
        //     A System.Security.AccessControl.FileSecurity object that encapsulates the access
        //     control rules for the current file.
        //
        // Exceptions:
        //   T:System.IO.IOException:
        //     An I/O error occurred while opening the file.
        //
        //   T:System.PlatformNotSupportedException:
        //     The current operating system is not Microsoft Windows 2000 or later.
        //
        //   T:System.Security.AccessControl.PrivilegeNotHeldException:
        //     The current system account does not have administrative privileges.
        //
        //   T:System.SystemException:
        //     The file could not be found.
        //
        //   T:System.UnauthorizedAccessException:
        //     This operation is not supported on the current platform.-or- The caller does
        //     not have the required permission.
        public abstract FileSecurity GetAccessControl(AccessControlSections includeSections);
        //
        // Summary:
        //     Moves a specified file to a new location, providing the option to specify a new
        //     file name.
        //
        // Parameters:
        //   destFileName:
        //     The path to move the file to, which can specify a different file name.
        //
        // Exceptions:
        //   T:System.IO.IOException:
        //     An I/O error occurs, such as the destination file already exists or the destination
        //     device is not ready.
        //
        //   T:System.ArgumentNullException:
        //     destFileName is null.
        //
        //   T:System.ArgumentException:
        //     destFileName is empty, contains only white spaces, or contains invalid characters.
        //
        //   T:System.Security.SecurityException:
        //     The caller does not have the required permission.
        //
        //   T:System.UnauthorizedAccessException:
        //     destFileName is read-only or is a directory.
        //
        //   T:System.IO.FileNotFoundException:
        //     The file is not found.
        //
        //   T:System.IO.DirectoryNotFoundException:
        //     The specified path is invalid, such as being on an unmapped drive.
        //
        //   T:System.IO.PathTooLongException:
        //     The specified path, file name, or both exceed the system-defined maximum length.
        //     For example, on Windows-based platforms, paths must be less than 248 characters,
        //     and file names must be less than 260 characters.
        //
        //   T:System.NotSupportedException:
        //     destFileName contains a colon (:) in the middle of the string.
        [SecuritySafeCritical]
        public abstract void MoveTo(string destFileName);
        //
        // Summary:
        //     Opens a file in the specified mode.
        //
        // Parameters:
        //   mode:
        //     A System.IO.FileMode constant specifying the mode (for example, Open or Append)
        //     in which to open the file.
        //
        // Returns:
        //     A file opened in the specified mode, with read/write access and unshared.
        //
        // Exceptions:
        //   T:System.IO.FileNotFoundException:
        //     The file is not found.
        //
        //   T:System.UnauthorizedAccessException:
        //     The file is read-only or is a directory.
        //
        //   T:System.IO.DirectoryNotFoundException:
        //     The specified path is invalid, such as being on an unmapped drive.
        //
        //   T:System.IO.IOException:
        //     The file is already open.
        public abstract FileStream Open(FileMode mode);
        //
        // Summary:
        //     Opens a file in the specified mode with read, write, or read/write access and
        //     the specified sharing option.
        //
        // Parameters:
        //   mode:
        //     A System.IO.FileMode constant specifying the mode (for example, Open or Append)
        //     in which to open the file.
        //
        //   access:
        //     A System.IO.FileAccess constant specifying whether to open the file with Read,
        //     Write, or ReadWrite file access.
        //
        //   share:
        //     A System.IO.FileShare constant specifying the type of access other FileStream
        //     objects have to this file.
        //
        // Returns:
        //     A System.IO.FileStream object opened with the specified mode, access, and sharing
        //     options.
        //
        // Exceptions:
        //   T:System.Security.SecurityException:
        //     The caller does not have the required permission.
        //
        //   T:System.IO.FileNotFoundException:
        //     The file is not found.
        //
        //   T:System.UnauthorizedAccessException:
        //     path is read-only or is a directory.
        //
        //   T:System.IO.DirectoryNotFoundException:
        //     The specified path is invalid, such as being on an unmapped drive.
        //
        //   T:System.IO.IOException:
        //     The file is already open.
        public abstract FileStream Open(FileMode mode, FileAccess access, FileShare share);
        //
        // Summary:
        //     Opens a file in the specified mode with read, write, or read/write access.
        //
        // Parameters:
        //   mode:
        //     A System.IO.FileMode constant specifying the mode (for example, Open or Append)
        //     in which to open the file.
        //
        //   access:
        //     A System.IO.FileAccess constant specifying whether to open the file with Read,
        //     Write, or ReadWrite file access.
        //
        // Returns:
        //     A System.IO.FileStream object opened in the specified mode and access, and unshared.
        //
        // Exceptions:
        //   T:System.Security.SecurityException:
        //     The caller does not have the required permission.
        //
        //   T:System.IO.FileNotFoundException:
        //     The file is not found.
        //
        //   T:System.UnauthorizedAccessException:
        //     path is read-only or is a directory.
        //
        //   T:System.IO.DirectoryNotFoundException:
        //     The specified path is invalid, such as being on an unmapped drive.
        //
        //   T:System.IO.IOException:
        //     The file is already open.
        public abstract FileStream Open(FileMode mode, FileAccess access);
        //
        // Summary:
        //     Creates a read-only System.IO.FileStream.
        //
        // Returns:
        //     A new read-only System.IO.FileStream object.
        //
        // Exceptions:
        //   T:System.UnauthorizedAccessException:
        //     path is read-only or is a directory.
        //
        //   T:System.IO.DirectoryNotFoundException:
        //     The specified path is invalid, such as being on an unmapped drive.
        //
        //   T:System.IO.IOException:
        //     The file is already open.
        public abstract FileStream OpenRead();
        //
        // Summary:
        //     Creates a System.IO.StreamReader with UTF8 encoding that reads from an existing
        //     text file.
        //
        // Returns:
        //     A new StreamReader with UTF8 encoding.
        //
        // Exceptions:
        //   T:System.Security.SecurityException:
        //     The caller does not have the required permission.
        //
        //   T:System.IO.FileNotFoundException:
        //     The file is not found.
        //
        //   T:System.UnauthorizedAccessException:
        //     path is read-only or is a directory.
        //
        //   T:System.IO.DirectoryNotFoundException:
        //     The specified path is invalid, such as being on an unmapped drive.
        [SecuritySafeCritical]
        public abstract StreamReader OpenText();
        //
        // Summary:
        //     Creates a write-only System.IO.FileStream.
        //
        // Returns:
        //     A write-only unshared System.IO.FileStream object for a new or existing file.
        //
        // Exceptions:
        //   T:System.UnauthorizedAccessException:
        //     The path specified when creating an instance of the System.IO.UcsFileInfo object
        //     is read-only or is a directory.
        //
        //   T:System.IO.DirectoryNotFoundException:
        //     The path specified when creating an instance of the System.IO.UcsFileInfo object
        //     is invalid, such as being on an unmapped drive.
        public abstract FileStream OpenWrite();
        //
        // Summary:
        //     Replaces the contents of a specified file with the file described by the current
        //     System.IO.UcsFileInfo object, deleting the original file, and creating a backup
        //     of the replaced file.
        //
        // Parameters:
        //   destinationFileName:
        //     The name of a file to replace with the current file.
        //
        //   destinationBackupFileName:
        //     The name of a file with which to create a backup of the file described by the
        //     destFileName parameter.
        //
        // Returns:
        //     A System.IO.UcsFileInfo object that encapsulates information about the file described
        //     by the destFileName parameter.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     The path described by the destFileName parameter was not of a legal form.-or-The
        //     path described by the destBackupFileName parameter was not of a legal form.
        //
        //   T:System.ArgumentNullException:
        //     The destFileName parameter is null.
        //
        //   T:System.IO.FileNotFoundException:
        //     The file described by the current System.IO.UcsFileInfo object could not be found.-or-The
        //     file described by the destinationFileName parameter could not be found.
        //
        //   T:System.PlatformNotSupportedException:
        //     The current operating system is not Microsoft Windows NT or later.
        [ComVisible(false)]
        public abstract AbUcsFileInfo Replace(string destinationFileName, string destinationBackupFileName);
        //
        // Summary:
        //     Replaces the contents of a specified file with the file described by the current
        //     System.IO.UcsFileInfo object, deleting the original file, and creating a backup
        //     of the replaced file. Also specifies whether to ignore merge errors.
        //
        // Parameters:
        //   destinationFileName:
        //     The name of a file to replace with the current file.
        //
        //   destinationBackupFileName:
        //     The name of a file with which to create a backup of the file described by the
        //     destFileName parameter.
        //
        //   ignoreMetadataErrors:
        //     true to ignore merge errors (such as attributes and ACLs) from the replaced file
        //     to the replacement file; otherwise false.
        //
        // Returns:
        //     A System.IO.UcsFileInfo object that encapsulates information about the file described
        //     by the destFileName parameter.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     The path described by the destFileName parameter was not of a legal form.-or-The
        //     path described by the destBackupFileName parameter was not of a legal form.
        //
        //   T:System.ArgumentNullException:
        //     The destFileName parameter is null.
        //
        //   T:System.IO.FileNotFoundException:
        //     The file described by the current System.IO.UcsFileInfo object could not be found.-or-The
        //     file described by the destinationFileName parameter could not be found.
        //
        //   T:System.PlatformNotSupportedException:
        //     The current operating system is not Microsoft Windows NT or later.
        [ComVisible(false)]
        public abstract AbUcsFileInfo Replace(string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors);
        //
        // Summary:
        //     Applies access control list (ACL) entries described by a System.Security.AccessControl.FileSecurity
        //     object to the file described by the current System.IO.UcsFileInfo object.
        //
        // Parameters:
        //   fileSecurity:
        //     A System.Security.AccessControl.FileSecurity object that describes an access
        //     control list (ACL) entry to apply to the current file.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     The fileSecurity parameter is null.
        //
        //   T:System.SystemException:
        //     The file could not be found or modified.
        //
        //   T:System.UnauthorizedAccessException:
        //     The current process does not have access to open the file.
        //
        //   T:System.PlatformNotSupportedException:
        //     The current operating system is not Microsoft Windows 2000 or later.
        public abstract void SetAccessControl(FileSecurity fileSecurity);
        //
        // Summary:
        //     Returns the path as a string.
        //
        // Returns:
        //     A string representing the path.
        public abstract string ToString();

    }
}
