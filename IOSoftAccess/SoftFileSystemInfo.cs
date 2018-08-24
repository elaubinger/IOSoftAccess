using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace IOSoftAccess
{
    public abstract class SoftFileSystemInfo
    {
        protected FileSystemInfo FileSystem;

        public virtual bool Exists => FileSystem.Exists;

        #region FileSystemInfo Methods

        #region Standard Methods

        #region Synchronous Methods

        public virtual bool TryDelete()
        {
            try
            {
                FileSystem.Delete();
                return true;
            }
            catch (Exception) { return false; }
        }

        #endregion

        #region Asynchronous Methods

        public virtual async Task<bool> TryDeleteAsync()
            => await Task.Run(() => TryDelete());

        #endregion

        #endregion

        #region Getters & Setters

        #region Synchronous Methods

        public virtual bool TryGetExtension(out string extension)
        {
            try
            {
                extension = FileSystem.Extension;
                return true;
            }
            catch (Exception)
            {
                extension = default(string);
                return false;
            }
        }

        public virtual bool TryGetFullName(out string fullName)
        {
            try
            {
                fullName = FileSystem.FullName;
                return true;
            }
            catch (Exception)
            {
                fullName = default(string);
                return false;
            }
        }

        public virtual bool TryGetName(out string name)
        {
            try
            {
                name = FileSystem.Name;
                return true;
            }
            catch (Exception)
            {
                name = default(string);
                return false;
            }
        }

        public virtual bool TryGetAttributes(out FileAttributes? attributes)
        {
            try
            {
                attributes = FileSystem.Attributes;
                return true;
            }
            catch (Exception)
            {
                attributes = default(FileAttributes?);
                return false;
            }
        }

        public virtual bool TryGetCreationTime(out DateTime? creationTime)
        {
            try
            {
                creationTime = FileSystem.CreationTime;
                return true;
            }
            catch (Exception)
            {
                creationTime = default(DateTime?);
                return false;
            }
        }

        public virtual bool TryGetCreationTimeUtc(out DateTime? creationTimeUtc)
        {
            try
            {
                creationTimeUtc = FileSystem.CreationTimeUtc;
                return true;
            }
            catch (Exception)
            {
                creationTimeUtc = default(DateTime?);
                return false;
            }
        }

        public virtual bool TryGetLastAccessTime(out DateTime? lastAccessTime)
        {
            try
            {
                lastAccessTime = FileSystem.LastAccessTime;
                return true;
            }
            catch (Exception)
            {
                lastAccessTime = default(DateTime?);
                return false;
            }
        }

        public virtual bool TryGetLastAccessTimeUtc(out DateTime? lastAccessTimeUtc)
        {
            try
            {
                lastAccessTimeUtc = FileSystem.LastAccessTimeUtc;
                return true;
            }
            catch (Exception)
            {
                lastAccessTimeUtc = default(DateTime?);
                return false;
            }
        }
        #endregion

        #region Asynchronous Methods
        public virtual async Task<(bool success, string extension)> TryGetExtensionAsync()
            => await Task.Run(() => (TryGetExtension(out var extension), extension));

        public virtual async Task<(bool success, string fullName)> TryGetFullNameAsync()
            => await Task.Run(() => (TryGetFullName(out var fullName), fullName));

        public virtual async Task<(bool success, string name)> TryGetNameAsync()
            => await Task.Run(() => (TryGetName(out var name), name));

        public virtual async Task<(bool success, FileAttributes? attributes)> TryGetAttributesAsync()
            => await Task.Run(() => (TryGetAttributes(out var attributes), attributes));

        public virtual async Task<(bool success, DateTime? creationTime)> TryGetCreationTimeAsync()
            => await Task.Run(() => (TryGetCreationTime(out var creationTime), creationTime));

        public virtual async Task<(bool success, DateTime? creationTimeUtc)> TryGetCreationTimeUtcAsync()
            => await Task.Run(() => (TryGetCreationTimeUtc(out var creationTimeUtc), creationTimeUtc));

        public virtual async Task<(bool success, DateTime? lastAccessTime)> TryGetLastAccessTimeAsync()
            => await Task.Run(() => (TryGetLastAccessTime(out var lastAccessTime), lastAccessTime));

        public virtual async Task<(bool success, DateTime? lastAccessTimeUtc)> TryGetLastAccessTimeUtcAsync()
            => await Task.Run(() => (TryGetLastAccessTimeUtc(out var lastAccessTimeUtc), lastAccessTimeUtc));
        #endregion

        #endregion

        #endregion
    }
    

}
