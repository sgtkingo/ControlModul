using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ControlModul.Handlers.Loger;

using FluentFTP;

namespace ControlModul.FileControl
{
    public enum FtpFileSystemObjectType 
    {
        File=0,
        Directory=1,
        Link=2
    }

    public static class FTPManager
    {
        public static FtpClient CreateClient(Uri host)
        {
            try
            {
                if (host.Scheme != Uri.UriSchemeFtp)
                {
                    throw new UriFormatException();
                }
                    FtpClient client = new FtpClient(host);
                // connect to the server and automatically detect working FTP settings
                client.AutoConnect();

                return client;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static FtpClient CreateClient(string host)
        {
            try
            {
                FtpClient client = new FtpClient(host);
                // connect to the server and automatically detect working FTP settings
                client.AutoConnect();

                return client;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static FtpClient CreateClient(Uri host, string username, string password)
        {
            try
            {
                if (host.Scheme != Uri.UriSchemeFtp)
                {
                    throw new UriFormatException();
                }

                FtpClient client = new FtpClient(host, username, password);
                // connect to the server and automatically detect working FTP settings
                client.AutoConnect();

                return client;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static FtpClient CreateClient(string host, string username, string password) 
        {
            try
            {
                FtpClient client = new FtpClient(host, username, password);
                // connect to the server and automatically detect working FTP settings
                client.AutoConnect();

                return client;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DisconnectClient(FtpClient client) 
        {
            try
            {
                client.Disconnect();
            }
            catch (Exception ex)
            {
                throw ex;                  
            }
        }

        public async static Task<FtpListItem[]> ListDirectoryAsync(FtpClient client, string path = "/") 
        {
            try
            {
                // get a list of files and directories in the "/htdocs" folder
                return await client.GetListingAsync(path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static FtpListItem[] ListDirectory(FtpClient client, string path = "/")
        {
            try
            {
                // get a list of files and directories in the "/htdocs" folder
                return client.GetListing(path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static long GetFileSize(FtpClient client, FtpListItem file) 
        {
            // if this is a file
            if ((int)file.Type == (int)FtpFileSystemObjectType.File)
            {
                // get the file size
                return client.GetFileSize(file.FullName);
            }
            else return -1;
        }

        public static FtpHash GetFileHash(FtpClient client, FtpListItem file)
        {
            // if this is a file
            if ((int)file.Type == (int)FtpFileSystemObjectType.File)
            {
                // get the file size
                return client.GetChecksum(file.FullName);
            }
            else return null;
        }

        public static DateTime GetFileModifiedTime(FtpClient client, FtpListItem file)
        {
            // if this is a file
            if ((int)file.Type == (int)FtpFileSystemObjectType.File)
            {
                // get the file size
                return client.GetModifiedTime(file.FullName);
            }
            else return DateTime.MinValue;
        }

        public async static void UploadFileAsync(FtpClient client, string from, string to = "/") 
        {
            try
            {
                await client.UploadFileAsync(from, to);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async static void MoveFileAsync(FtpClient client, string from, string to = "/")
        {
            try
            {
                await client.MoveFileAsync(from, to);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static bool CompareFile(FtpClient client, string localPath, string remotePath)
        {
            try
            {
                return (client.CompareFile(localPath, remotePath) == FtpCompareResult.Equal);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async static void DownloadFileAsync(FtpClient client, string from, string to)
        {
            try
            {
                await client.DownloadFileAsync(to, from);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async static void DeleteFileAsync(FtpClient client, string from)
        {
            try
            {
                await client.DeleteFileAsync(from);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async static void UploadDirectoryAsync(FtpClient client, string from, string to, FtpFolderSyncMode ftpFolderSyncMode )
        {
            try
            {
                await client.UploadDirectoryAsync(from, to, ftpFolderSyncMode);
            }
            catch (Exception ex)
            { 
                throw ex;
            }
            
        }

        public async static void DownloadDirectoryAsync(FtpClient client, string from, string to, FtpFolderSyncMode ftpFolderSyncMode)
        {
            try
            {
                await client.DownloadDirectoryAsync(to, from, ftpFolderSyncMode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
