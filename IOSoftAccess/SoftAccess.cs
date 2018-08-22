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
            throw new NotImplementedException();
        }

        public override bool TryGetName(out string name)
        {
            throw new NotImplementedException();
        }

        public override bool TryGetAttributes(out FileAttributes attributes)
        {
            throw new NotImplementedException();
        }

        public override bool TryGetCreationTime(out DateTime creationTime)
        {
            throw new NotImplementedException();
        }

        public override bool TryGetCreationTimeUtc(out DateTime creationTimeUtc)
        {
            throw new NotImplementedException();
        }

        public override bool TryGetLastAccessTime(out DateTime lastAccessTime)
        {
            throw new NotImplementedException();
        }

        public override bool TryGetLastAccessTimeUtc(out DateTime lastAccessTimeUtc)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> TryDeleteAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<(bool success, string extension)> TryGetExtensionAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<(bool success, string fullName)> TryGetFullNameAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<(bool success, string name)> TryGetNameAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<(bool success, FileAttributes attributes)> TryGetAttributesAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<(bool success, DateTime creationTime)> TryGetCreationTimeAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<(bool success, DateTime creationTimeUtc)> TryGetCreationTimeUtcAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<(bool success, DateTime lastAccessTime)> TryGetLastAccessTimeAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<(bool success, DateTime lastAccessTimeUtc)> TryGetLastAccessTimeUtcAsync()
        {
            throw new NotImplementedException();
        }
    }
}
