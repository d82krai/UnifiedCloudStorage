using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace UnifiedCloudStorage.Core
{
    public abstract class AbUcsDirectoryInfo
    {

        ////
        //// Summary:
        ////     Initializes a new instance of the System.IO.UcsDirectoryInfo class on the specified
        ////     path.
        ////
        //// Parameters:
        ////   path:
        ////     A string specifying the path on which to create the UcsDirectoryInfo.
        ////
        //// Exceptions:
        ////   T:System.ArgumentNullException:
        ////     path is null.
        ////
        ////   T:System.Security.SecurityException:
        ////     The caller does not have the required permission.
        ////
        ////   T:System.ArgumentException:
        ////     path contains invalid characters such as ", <, >, or |.
        ////
        ////   T:System.IO.PathTooLongException:
        ////     The specified path, file name, or both exceed the system-defined maximum length.
        ////     For example, on Windows-based platforms, paths must be less than 248 characters,
        ////     and file names must be less than 260 characters. The specified path, file name,
        ////     or both are too long.
        //[SecuritySafeCritical]
        //public UcsDirectoryInfo(string path);

        //
        // Summary:
        //     Gets the parent directory of a specified subdirectory.
        //
        // Returns:
        //     The parent directory, or null if the path is null or if the file path denotes
        //     a root (such as "\", "C:", or * "\\server\share").
        //
        // Exceptions:
        //   T:System.Security.SecurityException:
        //     The caller does not have the required permission.
        public AbUcsDirectoryInfo Parent { get; }
        //
        // Summary:
        //     Gets the name of this System.IO.UcsDirectoryInfo instance.
        //
        // Returns:
        //     The directory name.
        public string Name { get; }
        //
        // Summary:
        //     Gets a value indicating whether the directory exists.
        //
        // Returns:
        //     true if the directory exists; otherwise, false.
        public bool Exists { get; }
        //
        // Summary:
        //     Gets the root portion of the directory.
        //
        // Returns:
        //     An object that represents the root of the directory.
        //
        // Exceptions:
        //   T:System.Security.SecurityException:
        //     The caller does not have the required permission.
        public AbUcsDirectoryInfo Root { get; }

        //
        // Summary:
        //     Creates a directory.
        //
        // Exceptions:
        //   T:System.IO.IOException:
        //     The directory cannot be created.
        public abstract void Create();
        //
        // Summary:
        //     Creates a directory using a System.Security.AccessControl.DirectorySecurity object.
        //
        // Parameters:
        //   directorySecurity:
        //     The access control to apply to the directory.
        //
        // Exceptions:
        //   T:System.IO.IOException:
        //     The directory specified by path is read-only or is not empty.
        //
        //   T:System.IO.IOException:
        //     The directory specified by path is read-only or is not empty.
        //
        //   T:System.UnauthorizedAccessException:
        //     The caller does not have the required permission.
        //
        //   T:System.ArgumentException:
        //     path is a zero-length string, contains only white space, or contains one or more
        //     invalid characters as defined by System.IO.Path.InvalidPathChars.
        //
        //   T:System.ArgumentNullException:
        //     path is null.
        //
        //   T:System.IO.PathTooLongException:
        //     The specified path, file name, or both exceed the system-defined maximum length.
        //     For example, on Windows-based platforms, paths must be less than 248 characters,
        //     and file names must be less than 260 characters.
        //
        //   T:System.IO.DirectoryNotFoundException:
        //     The specified path is invalid, such as being on an unmapped drive.
        //
        //   T:System.NotSupportedException:
        //     Creating a directory with only the colon (:) character was attempted.
        public abstract void Create(DirectorySecurity directorySecurity);
        //
        // Summary:
        //     Creates a subdirectory or subdirectories on the specified path. The specified
        //     path can be relative to this instance of the System.IO.UcsDirectoryInfo class.
        //
        // Parameters:
        //   path:
        //     The specified path. This cannot be a different disk volume or Universal Naming
        //     Convention (UNC) name.
        //
        // Returns:
        //     The last directory specified in path.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     path does not specify a valid file path or contains invalid IUcsDirectoryInfo characters.
        //
        //   T:System.ArgumentNullException:
        //     path is null.
        //
        //   T:System.IO.DirectoryNotFoundException:
        //     The specified path is invalid, such as being on an unmapped drive.
        //
        //   T:System.IO.IOException:
        //     The subdirectory cannot be created.-or- A file or directory already has the name
        //     specified by path.
        //
        //   T:System.IO.PathTooLongException:
        //     The specified path, file name, or both exceed the system-defined maximum length.
        //     For example, on Windows-based platforms, paths must be less than 248 characters,
        //     and file names must be less than 260 characters. The specified path, file name,
        //     or both are too long.
        //
        //   T:System.Security.SecurityException:
        //     The caller does not have code access permission to create the directory.-or-The
        //     caller does not have code access permission to read the directory described by
        //     the returned System.IO.UcsDirectoryInfo object. This can occur when the path parameter
        //     describes an existing directory.
        //
        //   T:System.NotSupportedException:
        //     path contains a colon character (:) that is not part of a drive label ("C:\").
        public abstract AbUcsDirectoryInfo CreateSubdirectory(string path);
        //
        // Summary:
        //     Creates a subdirectory or subdirectories on the specified path with the specified
        //     security. The specified path can be relative to this instance of the System.IO.UcsDirectoryInfo
        //     class.
        //
        // Parameters:
        //   path:
        //     The specified path. This cannot be a different disk volume or Universal Naming
        //     Convention (UNC) name.
        //
        //   directorySecurity:
        //     The security to apply.
        //
        // Returns:
        //     The last directory specified in path.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     path does not specify a valid file path or contains invalid IUcsDirectoryInfo characters.
        //
        //   T:System.ArgumentNullException:
        //     path is null.
        //
        //   T:System.IO.DirectoryNotFoundException:
        //     The specified path is invalid, such as being on an unmapped drive.
        //
        //   T:System.IO.IOException:
        //     The subdirectory cannot be created.-or- A file or directory already has the name
        //     specified by path.
        //
        //   T:System.IO.PathTooLongException:
        //     The specified path, file name, or both exceed the system-defined maximum length.
        //     For example, on Windows-based platforms, paths must be less than 248 characters,
        //     and file names must be less than 260 characters. The specified path, file name,
        //     or both are too long.
        //
        //   T:System.Security.SecurityException:
        //     The caller does not have code access permission to create the directory.-or-The
        //     caller does not have code access permission to read the directory described by
        //     the returned System.IO.UcsDirectoryInfo object. This can occur when the path parameter
        //     describes an existing directory.
        //
        //   T:System.NotSupportedException:
        //     path contains a colon character (:) that is not part of a drive label ("C:\").
        [SecuritySafeCritical]
        public abstract AbUcsDirectoryInfo CreateSubdirectory(string path, DirectorySecurity directorySecurity);
        //
        // Summary:
        //     Deletes this instance of a System.IO.UcsDirectoryInfo, specifying whether to delete
        //     subdirectories and files.
        //
        // Parameters:
        //   recursive:
        //     true to delete this directory, its subdirectories, and all files; otherwise,
        //     false.
        //
        // Exceptions:
        //   T:System.UnauthorizedAccessException:
        //     The directory contains a read-only file.
        //
        //   T:System.IO.DirectoryNotFoundException:
        //     The directory described by this System.IO.UcsDirectoryInfo object does not exist
        //     or could not be found.
        //
        //   T:System.IO.IOException:
        //     The directory is read-only.-or- The directory contains one or more files or subdirectories
        //     and recursive is false.-or-The directory is the application's current working
        //     directory. -or-There is an open handle on the directory or on one of its files,
        //     and the operating system is Windows XP or earlier. This open handle can result
        //     from enumerating directories and files. For more information, see How to: Enumerate
        //     Directories and Files.
        //
        //   T:System.Security.SecurityException:
        //     The caller does not have the required permission.
        [SecuritySafeCritical]
        public abstract void Delete(bool recursive);
        //
        // Summary:
        //     Deletes this System.IO.UcsDirectoryInfo if it is empty.
        //
        // Exceptions:
        //   T:System.UnauthorizedAccessException:
        //     The directory contains a read-only file.
        //
        //   T:System.IO.DirectoryNotFoundException:
        //     The directory described by this System.IO.UcsDirectoryInfo object does not exist
        //     or could not be found.
        //
        //   T:System.IO.IOException:
        //     The directory is not empty. -or-The directory is the application's current working
        //     directory.-or-There is an open handle on the directory, and the operating system
        //     is Windows XP or earlier. This open handle can result from enumerating directories.
        //     For more information, see How to: Enumerate Directories and Files.
        //
        //   T:System.Security.SecurityException:
        //     The caller does not have the required permission.
        [SecuritySafeCritical]
        public abstract void Delete();
        //
        // Summary:
        //     Returns an enumerable collection of directory information that matches a specified
        //     search pattern and search subdirectory option.
        //
        // Parameters:
        //   searchPattern:
        //     The search string to match against the names of directories. This parameter can
        //     contain a combination of valid literal path and wildcard (* and ?) characters
        //     (see Remarks), but doesn't support regular expressions. The default pattern is
        //     "*", which returns all files.
        //
        //   searchOption:
        //     One of the enumeration values that specifies whether the search operation should
        //     include only the current directory or all subdirectories. The default value is
        //     System.IO.SearchOption.TopDirectoryOnly.
        //
        // Returns:
        //     An enumerable collection of directories that matches searchPattern and searchOption.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     searchPattern is null.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     searchOption is not a valid System.IO.SearchOption value.
        //
        //   T:System.IO.DirectoryNotFoundException:
        //     The path encapsulated in the System.IO.UcsDirectoryInfo object is invalid (for example,
        //     it is on an unmapped drive).
        //
        //   T:System.Security.SecurityException:
        //     The caller does not have the required permission.
        public abstract IEnumerable<AbUcsDirectoryInfo> EnumerateDirectories(string searchPattern, SearchOption searchOption);
        //
        // Summary:
        //     Returns an enumerable collection of directory information in the current directory.
        //
        // Returns:
        //     An enumerable collection of directories in the current directory.
        //
        // Exceptions:
        //   T:System.IO.DirectoryNotFoundException:
        //     The path encapsulated in the System.IO.UcsDirectoryInfo object is invalid (for example,
        //     it is on an unmapped drive).
        //
        //   T:System.Security.SecurityException:
        //     The caller does not have the required permission.
        public abstract IEnumerable<AbUcsDirectoryInfo> EnumerateDirectories();
        //
        // Summary:
        //     Returns an enumerable collection of directory information that matches a specified
        //     search pattern.
        //
        // Parameters:
        //   searchPattern:
        //     The search string to match against the names of directories. This parameter can
        //     contain a combination of valid literal path and wildcard (* and ?) characters
        //     (see Remarks), but doesn't support regular expressions. The default pattern is
        //     "*", which returns all files.
        //
        // Returns:
        //     An enumerable collection of directories that matches searchPattern.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     searchPattern is null.
        //
        //   T:System.IO.DirectoryNotFoundException:
        //     The path encapsulated in the System.IO.UcsDirectoryInfo object is invalid (for example,
        //     it is on an unmapped drive).
        //
        //   T:System.Security.SecurityException:
        //     The caller does not have the required permission.
        public abstract IEnumerable<AbUcsDirectoryInfo> EnumerateDirectories(string searchPattern);
        //
        // Summary:
        //     Returns an enumerable collection of file information that matches a specified
        //     search pattern and search subdirectory option.
        //
        // Parameters:
        //   searchPattern:
        //     The search string to match against the names of files. This parameter can contain
        //     a combination of valid literal path and wildcard (* and ?) characters (see Remarks),
        //     but doesn't support regular expressions. The default pattern is "*", which returns
        //     all files.
        //
        //   searchOption:
        //     One of the enumeration values that specifies whether the search operation should
        //     include only the current directory or all subdirectories. The default value is
        //     System.IO.SearchOption.TopDirectoryOnly.
        //
        // Returns:
        //     An enumerable collection of files that matches searchPattern and searchOption.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     searchPattern is null.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     searchOption is not a valid System.IO.SearchOption value.
        //
        //   T:System.IO.DirectoryNotFoundException:
        //     The path encapsulated in the System.IO.UcsDirectoryInfo object is invalid (for example,
        //     it is on an unmapped drive).
        //
        //   T:System.Security.SecurityException:
        //     The caller does not have the required permission.
        public abstract IEnumerable<FileInfo> EnumerateFiles(string searchPattern, SearchOption searchOption);
        //
        // Summary:
        //     Returns an enumerable collection of file information that matches a search pattern.
        //
        // Parameters:
        //   searchPattern:
        //     The search string to match against the names of files. This parameter can contain
        //     a combination of valid literal path and wildcard (* and ?) characters (see Remarks),
        //     but doesn't support regular expressions. The default pattern is "*", which returns
        //     all files.
        //
        // Returns:
        //     An enumerable collection of files that matches searchPattern.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     searchPattern is null.
        //
        //   T:System.IO.DirectoryNotFoundException:
        //     The path encapsulated in the System.IO.UcsDirectoryInfo object is invalid, (for
        //     example, it is on an unmapped drive).
        //
        //   T:System.Security.SecurityException:
        //     The caller does not have the required permission.
        public abstract IEnumerable<FileInfo> EnumerateFiles(string searchPattern);
        //
        // Summary:
        //     Returns an enumerable collection of file information in the current directory.
        //
        // Returns:
        //     An enumerable collection of the files in the current directory.
        //
        // Exceptions:
        //   T:System.IO.DirectoryNotFoundException:
        //     The path encapsulated in the System.IO.UcsDirectoryInfo object is invalid (for example,
        //     it is on an unmapped drive).
        //
        //   T:System.Security.SecurityException:
        //     The caller does not have the required permission.
        public abstract IEnumerable<FileInfo> EnumerateFiles();
        //
        // Summary:
        //     Returns an enumerable collection of file system information that matches a specified
        //     search pattern and search subdirectory option.
        //
        // Parameters:
        //   searchPattern:
        //     The search string to match against the names of directories. This parameter can
        //     contain a combination of valid literal path and wildcard (* and ?) characters
        //     (see Remarks), but doesn't support regular expressions. The default pattern is
        //     "*", which returns all files.
        //
        //   searchOption:
        //     One of the enumeration values that specifies whether the search operation should
        //     include only the current directory or all subdirectories. The default value is
        //     System.IO.SearchOption.TopDirectoryOnly.
        //
        // Returns:
        //     An enumerable collection of file system information objects that matches searchPattern
        //     and searchOption.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     searchPattern is null.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     searchOption is not a valid System.IO.SearchOption value.
        //
        //   T:System.IO.DirectoryNotFoundException:
        //     The path encapsulated in the System.IO.UcsDirectoryInfo object is invalid (for example,
        //     it is on an unmapped drive).
        //
        //   T:System.Security.SecurityException:
        //     The caller does not have the required permission.
        public abstract IEnumerable<AbUcsFileSystemInfo> EnumerateFileSystemInfos(string searchPattern, SearchOption searchOption);
        //
        // Summary:
        //     Returns an enumerable collection of file system information that matches a specified
        //     search pattern.
        //
        // Parameters:
        //   searchPattern:
        //     The search string to match against the names of directories. This parameter can
        //     contain a combination of valid literal path and wildcard (* and ?) characters
        //     (see Remarks), but doesn't support regular expressions. The default pattern is
        //     "*", which returns all files.
        //
        // Returns:
        //     An enumerable collection of file system information objects that matches searchPattern.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     searchPattern is null.
        //
        //   T:System.IO.DirectoryNotFoundException:
        //     The path encapsulated in the System.IO.UcsDirectoryInfo object is invalid (for example,
        //     it is on an unmapped drive).
        //
        //   T:System.Security.SecurityException:
        //     The caller does not have the required permission.
        public abstract IEnumerable<AbUcsFileSystemInfo> EnumerateFileSystemInfos(string searchPattern);
        //
        // Summary:
        //     Returns an enumerable collection of file system information in the current directory.
        //
        // Returns:
        //     An enumerable collection of file system information in the current directory.
        //
        // Exceptions:
        //   T:System.IO.DirectoryNotFoundException:
        //     The path encapsulated in the System.IO.UcsDirectoryInfo object is invalid (for example,
        //     it is on an unmapped drive).
        //
        //   T:System.Security.SecurityException:
        //     The caller does not have the required permission.
        public abstract IEnumerable<AbUcsFileSystemInfo> EnumerateFileSystemInfos();
        //
        // Summary:
        //     Gets a System.Security.AccessControl.DirectorySecurity object that encapsulates
        //     the access control list (ACL) entries for the directory described by the current
        //     System.IO.UcsDirectoryInfo object.
        //
        // Returns:
        //     A System.Security.AccessControl.DirectorySecurity object that encapsulates the
        //     access control rules for the directory.
        //
        // Exceptions:
        //   T:System.SystemException:
        //     The directory could not be found or modified.
        //
        //   T:System.UnauthorizedAccessException:
        //     The current process does not have access to open the directory.
        //
        //   T:System.UnauthorizedAccessException:
        //     The directory is read-only.-or- This operation is not supported on the current
        //     platform.-or- The caller does not have the required permission.
        //
        //   T:System.IO.IOException:
        //     An I/O error occurred while opening the directory.
        //
        //   T:System.PlatformNotSupportedException:
        //     The current operating system is not Microsoft Windows 2000 or later.
        public abstract DirectorySecurity GetAccessControl();
        //
        // Summary:
        //     Gets a System.Security.AccessControl.DirectorySecurity object that encapsulates
        //     the specified type of access control list (ACL) entries for the directory described
        //     by the current System.IO.UcsDirectoryInfo object.
        //
        // Parameters:
        //   includeSections:
        //     One of the System.Security.AccessControl.AccessControlSections values that specifies
        //     the type of access control list (ACL) information to receive.
        //
        // Returns:
        //     A System.Security.AccessControl.DirectorySecurity object that encapsulates the
        //     access control rules for the file described by the path parameter.ExceptionsException
        //     typeCondition System.SystemException The directory could not be found or modified.
        //     System.UnauthorizedAccessException The current process does not have access to
        //     open the directory. System.IO.IOException An I/O error occurred while opening
        //     the directory. System.PlatformNotSupportedException The current operating system
        //     is not Microsoft Windows 2000 or later. System.UnauthorizedAccessException The
        //     directory is read-only.-or- This operation is not supported on the current platform.-or-
        //     The caller does not have the required permission.
        public abstract DirectorySecurity GetAccessControl(AccessControlSections includeSections);
        //
        // Summary:
        //     Returns the subdirectories of the current directory.
        //
        // Returns:
        //     An array of System.IO.UcsDirectoryInfo objects.
        //
        // Exceptions:
        //   T:System.IO.DirectoryNotFoundException:
        //     The path encapsulated in the System.IO.UcsDirectoryInfo object is invalid, such
        //     as being on an unmapped drive.
        //
        //   T:System.Security.SecurityException:
        //     The caller does not have the required permission.
        //
        //   T:System.UnauthorizedAccessException:
        //     The caller does not have the required permission.
        public abstract AbUcsDirectoryInfo[] GetDirectories();
        //
        // Summary:
        //     Returns an array of directories in the current System.IO.UcsDirectoryInfo matching
        //     the given search criteria.
        //
        // Parameters:
        //   searchPattern:
        //     The search string to match against the names of directories. This parameter can
        //     contain a combination of valid literal path and wildcard (* and ?) characters
        //     (see Remarks), but doesn't support regular expressions. The default pattern is
        //     "*", which returns all files.
        //
        // Returns:
        //     An array of type IUcsDirectoryInfo matching searchPattern.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     searchPattern contains one or more invalid characters defined by the System.IO.Path.GetInvalidPathChars
        //     method.
        //
        //   T:System.ArgumentNullException:
        //     searchPattern is null.
        //
        //   T:System.IO.DirectoryNotFoundException:
        //     The path encapsulated in the IUcsDirectoryInfo object is invalid (for example, it
        //     is on an unmapped drive).
        //
        //   T:System.UnauthorizedAccessException:
        //     The caller does not have the required permission.
        public abstract AbUcsDirectoryInfo[] GetDirectories(string searchPattern);
        //
        // Summary:
        //     Returns an array of directories in the current System.IO.UcsDirectoryInfo matching
        //     the given search criteria and using a value to determine whether to search subdirectories.
        //
        // Parameters:
        //   searchPattern:
        //     The search string to match against the names of directories. This parameter can
        //     contain a combination of valid literal path and wildcard (* and ?) characters
        //     (see Remarks), but doesn't support regular expressions. The default pattern is
        //     "*", which returns all files.
        //
        //   searchOption:
        //     One of the enumeration values that specifies whether the search operation should
        //     include only the current directory or all subdirectories.
        //
        // Returns:
        //     An array of type IUcsDirectoryInfo matching searchPattern.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     searchPattern contains one or more invalid characters defined by the System.IO.Path.GetInvalidPathChars
        //     method.
        //
        //   T:System.ArgumentNullException:
        //     searchPattern is null.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     searchOption is not a valid System.IO.SearchOption value.
        //
        //   T:System.IO.DirectoryNotFoundException:
        //     The path encapsulated in the IUcsDirectoryInfo object is invalid (for example, it
        //     is on an unmapped drive).
        //
        //   T:System.UnauthorizedAccessException:
        //     The caller does not have the required permission.
        public abstract AbUcsDirectoryInfo[] GetDirectories(string searchPattern, SearchOption searchOption);
        //
        // Summary:
        //     Returns a file list from the current directory.
        //
        // Returns:
        //     An array of type System.IO.FileInfo.
        //
        // Exceptions:
        //   T:System.IO.DirectoryNotFoundException:
        //     The path is invalid, such as being on an unmapped drive.
        public abstract FileInfo[] GetFiles();
        //
        // Summary:
        //     Returns a file list from the current directory matching the given search pattern
        //     and using a value to determine whether to search subdirectories.
        //
        // Parameters:
        //   searchPattern:
        //     The search string to match against the names of files. This parameter can contain
        //     a combination of valid literal path and wildcard (* and ?) characters (see Remarks),
        //     but doesn't support regular expressions. The default pattern is "*", which returns
        //     all files.
        //
        //   searchOption:
        //     One of the enumeration values that specifies whether the search operation should
        //     include only the current directory or all subdirectories.
        //
        // Returns:
        //     An array of type System.IO.FileInfo.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     searchPattern contains one or more invalid characters defined by the System.IO.Path.GetInvalidPathChars
        //     method.
        //
        //   T:System.ArgumentNullException:
        //     searchPattern is null.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     searchOption is not a valid System.IO.SearchOption value.
        //
        //   T:System.IO.DirectoryNotFoundException:
        //     The path is invalid (for example, it is on an unmapped drive).
        //
        //   T:System.Security.SecurityException:
        //     The caller does not have the required permission.
        public abstract FileInfo[] GetFiles(string searchPattern, SearchOption searchOption);
        //
        // Summary:
        //     Returns a file list from the current directory matching the given search pattern.
        //
        // Parameters:
        //   searchPattern:
        //     The search string to match against the names of files. This parameter can contain
        //     a combination of valid literal path and wildcard (* and ?) characters (see Remarks),
        //     but doesn't support regular expressions. The default pattern is "*", which returns
        //     all files.
        //
        // Returns:
        //     An array of type System.IO.FileInfo.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     searchPattern contains one or more invalid characters defined by the System.IO.Path.GetInvalidPathChars
        //     method.
        //
        //   T:System.ArgumentNullException:
        //     searchPattern is null.
        //
        //   T:System.IO.DirectoryNotFoundException:
        //     The path is invalid (for example, it is on an unmapped drive).
        //
        //   T:System.Security.SecurityException:
        //     The caller does not have the required permission.
        public abstract FileInfo[] GetFiles(string searchPattern);
        //
        // Summary:
        //     Returns an array of strongly typed System.IO.UcsFileSystemInfo entries representing
        //     all the files and subdirectories in a directory.
        //
        // Returns:
        //     An array of strongly typed System.IO.UcsFileSystemInfo entries.
        //
        // Exceptions:
        //   T:System.IO.DirectoryNotFoundException:
        //     The path is invalid (for example, it is on an unmapped drive).
        public abstract AbUcsFileSystemInfo[] GetFileSystemInfos();
        //
        // Summary:
        //     Retrieves an array of System.IO.UcsFileSystemInfo objects that represent the files
        //     and subdirectories matching the specified search criteria.
        //
        // Parameters:
        //   searchPattern:
        //     The search string to match against the names of directories and filesa. This
        //     parameter can contain a combination of valid literal path and wildcard (* and
        //     ?) characters (see Remarks), but doesn't support regular expressions. The default
        //     pattern is "*", which returns all files.
        //
        //   searchOption:
        //     One of the enumeration values that specifies whether the search operation should
        //     include only the current directory or all subdirectories. The default value is
        //     System.IO.SearchOption.TopDirectoryOnly.
        //
        // Returns:
        //     An array of file system entries that match the search criteria.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     searchPattern contains one or more invalid characters defined by the System.IO.Path.GetInvalidPathChars
        //     method.
        //
        //   T:System.ArgumentNullException:
        //     searchPattern is null.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     searchOption is not a valid System.IO.SearchOption value.
        //
        //   T:System.IO.DirectoryNotFoundException:
        //     The specified path is invalid (for example, it is on an unmapped drive).
        //
        //   T:System.Security.SecurityException:
        //     The caller does not have the required permission.
        public abstract AbUcsFileSystemInfo[] GetFileSystemInfos(string searchPattern, SearchOption searchOption);
        //
        // Summary:
        //     Retrieves an array of strongly typed System.IO.UcsFileSystemInfo objects representing
        //     the files and subdirectories that match the specified search criteria.
        //
        // Parameters:
        //   searchPattern:
        //     The search string to match against the names of directories and files. This parameter
        //     can contain a combination of valid literal path and wildcard (* and ?) characters
        //     (see Remarks), but doesn't support regular expressions. The default pattern is
        //     "*", which returns all files.
        //
        // Returns:
        //     An array of strongly typed UcsFileSystemInfo objects matching the search criteria.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     searchPattern contains one or more invalid characters defined by the System.IO.Path.GetInvalidPathChars
        //     method.
        //
        //   T:System.ArgumentNullException:
        //     searchPattern is null.
        //
        //   T:System.IO.DirectoryNotFoundException:
        //     The specified path is invalid (for example, it is on an unmapped drive).
        //
        //   T:System.Security.SecurityException:
        //     The caller does not have the required permission.
        public abstract AbUcsFileSystemInfo[] GetFileSystemInfos(string searchPattern);
        //
        // Summary:
        //     Moves a System.IO.UcsDirectoryInfo instance and its contents to a new path.
        //
        // Parameters:
        //   destDirName:
        //     The name and path to which to move this directory. The destination cannot be
        //     another disk volume or a directory with the identical name. It can be an existing
        //     directory to which you want to add this directory as a subdirectory.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     destDirName is null.
        //
        //   T:System.ArgumentException:
        //     destDirName is an empty string (''").
        //
        //   T:System.IO.IOException:
        //     An attempt was made to move a directory to a different volume. -or- destDirName
        //     already exists.-or-You are not authorized to access this path.-or- The directory
        //     being moved and the destination directory have the same name.
        //
        //   T:System.Security.SecurityException:
        //     The caller does not have the required permission.
        //
        //   T:System.IO.DirectoryNotFoundException:
        //     The destination directory cannot be found.
        [SecuritySafeCritical]
        public abstract void MoveTo(string destDirName);
        //
        // Summary:
        //     Applies access control list (ACL) entries described by a System.Security.AccessControl.DirectorySecurity
        //     object to the directory described by the current System.IO.UcsDirectoryInfo object.
        //
        // Parameters:
        //   directorySecurity:
        //     An object that describes an ACL entry to apply to the directory described by
        //     the path parameter.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     The directorySecurity parameter is null.
        //
        //   T:System.SystemException:
        //     The file could not be found or modified.
        //
        //   T:System.UnauthorizedAccessException:
        //     The current process does not have access to open the file.
        //
        //   T:System.PlatformNotSupportedException:
        //     The current operating system is not Microsoft Windows 2000 or later.
        public abstract void SetAccessControl(DirectorySecurity directorySecurity);
        //
        // Summary:
        //     Returns the original path that was passed by the user.
        //
        // Returns:
        //     Returns the original path that was passed by the user.
        public abstract string ToString();

    }
}
