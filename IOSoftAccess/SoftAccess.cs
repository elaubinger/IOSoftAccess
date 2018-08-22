using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace IOSoftAccess
{
    public abstract class SoftFileSystemInfo
    {
        public virtual bool Exists { get; }
        
        public abstract bool TryDelete();

        public abstract bool TryGetExtension(out string extension);
        public abstract bool TryGetFullName(out string fullName);
        public abstract bool TryGetName(out string name);
        public abstract bool TryGetAttributes(out FileAttributes attributes);
        public abstract bool TryGetCreationTime(out DateTime creationTime);
        public abstract bool TryGetCreationTimeUtc(out DateTime creationTimeUtc);
        public abstract bool TryGetLastAccessTime(out DateTime lastAccessTime);
        public abstract bool TryGetLastAccessTimeUtc(out DateTime lastAccessTimeUtc);

        public abstract Task<bool> TryDeleteAsync();

        public abstract Task<(bool success, string extension)> TryGetExtensionAsync();
        public abstract Task<(bool success, string fullName)> TryGetFullNameAsync();
        public abstract Task<(bool success, string name)> TryGetNameAsync();
        public abstract Task<(bool success, FileAttributes attributes)> TryGetAttributesAsync();
        public abstract Task<(bool success, DateTime creationTime)> TryGetCreationTimeAsync();
        public abstract Task<(bool success, DateTime creationTimeUtc)> TryGetCreationTimeUtcAsync();
        public abstract Task<(bool success, DateTime lastAccessTime)> TryGetLastAccessTimeAsync();
        public abstract Task<(bool success, DateTime lastAccessTimeUtc)> TryGetLastAccessTimeUtcAsync();
    }

    public class SoftFileInfo : SoftFileSystemInfo
    {
        private readonly FileInfo file;
        public override bool Exists => file.Exists;

        public SoftFileInfo(string fileName)
        {
            file = new FileInfo(fileName);
        }

        public override bool TryDelete()
        {
            try
            {
                file.Delete();
                return true;
            }
            catch(Exception) { return false; }
        }

        public override bool TryGetExtension(out string extension)
        {
            try
            {
                extension = file.Extension;
                return true;
            }
            catch(Exception)
            {
                extension = default(string);
                return false;
            }
        }

        public override bool TryGetFullName(out string fullName)
        {
            try
            {
                fullName = file.FullName;
                return true;
            }
            catch (Exception)
            {
                fullName = default(string);
                return false;
            }
        }

        public override bool TryGetName(out string name)
        {
            try
            {
                name = file.Name;
                return true;
            }
            catch (Exception)
            {
                name = default(string);
                return false;
            }
        }

        public override bool TryGetAttributes(out FileAttributes attributes)
        {
            try
            {
                attributes = file.Attributes;
                return true;
            }
            catch (Exception)
            {
                attributes = default(FileAttributes);
                return false;
            }
        }

        public override bool TryGetCreationTime(out DateTime creationTime)
        {
            try
            {
                creationTime = file.CreationTime;
                return true;
            }
            catch (Exception)
            {
                creationTime = default(DateTime);
                return false;
            }
        }

        public override bool TryGetCreationTimeUtc(out DateTime creationTimeUtc)
        {
            try
            {
                creationTimeUtc = file.CreationTimeUtc;
                return true;
            }
            catch (Exception)
            {
                creationTimeUtc = default(DateTime);
                return false;
            }
        }

        public override bool TryGetLastAccessTime(out DateTime lastAccessTime)
        {
            try
            {
                lastAccessTime = file.LastAccessTime;
                return true;
            }
            catch (Exception)
            {
                lastAccessTime = default(DateTime);
                return false;
            }
        }

        public override bool TryGetLastAccessTimeUtc(out DateTime lastAccessTimeUtc)
        {
            try
            {
                lastAccessTimeUtc = file.LastAccessTimeUtc;
                return true;
            }
            catch (Exception)
            {
                lastAccessTimeUtc = default(DateTime);
                return false;
            }
        }

        public override async Task<bool> TryDeleteAsync() 
            => await Task.Run(() => TryDelete());

        public override async Task<(bool success, string extension)> TryGetExtensionAsync()
            => await Task.Run(() => (TryGetExtension(out var extension), extension));

        public override async Task<(bool success, string fullName)> TryGetFullNameAsync()
            => await Task.Run(() => (TryGetFullName(out var fullName), fullName));

        public override async Task<(bool success, string name)> TryGetNameAsync()
            => await Task.Run(() => (TryGetName(out var name), name));

        public override async Task<(bool success, FileAttributes attributes)> TryGetAttributesAsync()
            => await Task.Run(() => (TryGetAttributes(out var attributes), attributes));

        public override async Task<(bool success, DateTime creationTime)> TryGetCreationTimeAsync()
            => await Task.Run(() => (TryGetCreationTime(out var creationTime), creationTime));

        public override async Task<(bool success, DateTime creationTimeUtc)> TryGetCreationTimeUtcAsync()
            => await Task.Run(() => (TryGetCreationTimeUtc(out var creationTimeUtc), creationTimeUtc));

        public override async Task<(bool success, DateTime lastAccessTime)> TryGetLastAccessTimeAsync()
            => await Task.Run(() => (TryGetLastAccessTime(out var lastAccessTime), lastAccessTime));

        public override async Task<(bool success, DateTime lastAccessTimeUtc)> TryGetLastAccessTimeUtcAsync()
            => await Task.Run(() => (TryGetLastAccessTimeUtc(out var lastAccessTimeUtc), lastAccessTimeUtc));
    }
}
