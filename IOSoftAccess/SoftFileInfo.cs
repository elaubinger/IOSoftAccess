using System;
using System.IO;
using System.Threading.Tasks;

namespace IOSoftAccess
{
    public class SoftFileInfo : SoftFileSystemInfo
    {
        private readonly FileInfo file;

        public SoftFileInfo(string fileName)
        {
            FileSystem = new FileInfo(fileName);
            file = FileSystem as FileInfo;
        }

        #region Standard Methods

        #region Synchronous Methods

        public virtual bool TryAppendText(out StreamWriter writer)
        {
            try
            {
                writer = file.AppendText();
                return true;
            }
            catch (Exception)
            {
                writer = default(StreamWriter);
                return false;
            }
        }

        // TODO continue implementing

        #endregion

        #region Asynchronous Methods

        public virtual async Task<(bool success, StreamWriter writer)> TryAppendTextAsync()
            => await Task.Run(() => (TryAppendText(out var writer), writer));

        #endregion

        #endregion

        #region FileInfo Methods

        #region Getters & Setters

        #region Synchronous Methods
        public bool TryGetDirectory(out DirectoryInfo directory)
        {
            try
            {
                directory = file.Directory;
                return true;
            }
            catch (Exception)
            {
                directory = default(DirectoryInfo);
                return false;
            }
        }

        public bool TryGetDirectoryName(out string directoryName)
        {
            try
            {
                directoryName = file.DirectoryName;
                return true;
            }
            catch (Exception)
            {
                directoryName = default(string);
                return false;
            }
        }

        public bool TryGetIsReadOnly(out bool? isReadOnly)
        {
            try
            {
                isReadOnly = file.IsReadOnly;
                return true;
            }
            catch (Exception)
            {
                isReadOnly = default(bool?);
                return false;
            }
        }

        public bool TryGetLastWriteTime(out DateTime? lastWriteTime)
        {
            try
            {
                lastWriteTime = file.LastWriteTime;
                return true;
            }
            catch (Exception)
            {
                lastWriteTime = default(DateTime?);
                return false;
            }
        }

        public bool TryGetLastWriteTimeUtc(out DateTime? lastWriteTimeUtc)
        {
            try
            {
                lastWriteTimeUtc = file.LastWriteTimeUtc;
                return true;
            }
            catch (Exception)
            {
                lastWriteTimeUtc = default(DateTime?);
                return false;
            }
        }

        public bool TryGetLength(out long? length)
        {
            try
            {
                length = file.Length;
                return true;
            }
            catch (Exception)
            {
                length = default(long?);
                return false;
            }
        }
        #endregion

        #region Asynchronous Methods

        // TODO implement

        #endregion

        #endregion

        #endregion
    }
}
