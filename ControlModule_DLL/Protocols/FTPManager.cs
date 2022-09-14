using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using ControlModul.Handlers.Loger;

using FluentFTP;

namespace ControlModul.Protocols.FTP
{
    public enum FtpFileSystemObjectType 
    {
        File=0,
        Directory=1,
        Link=2
    }

    public static class FTPManager
    {
        public static bool SkipCertificateValidation { get; set; } = false;

        public static X509Certificate TrustedRawCertData { get; set; }

        public static void ValidatingCertificate(FtpClient control, FtpSslValidationEventArgs e)
        {
            if( SkipCertificateValidation ) 
            {
                e.Accept = true;
                return;
            }

            if (e.PolicyErrors == SslPolicyErrors.None)
            {
                if( TrustedRawCertData != null && e.Certificate.GetRawCertDataString().Equals(TrustedRawCertData.GetRawCertDataString())) 
                {
                    e.Accept = true;
                }
                else if( TrustedRawCertData == null ) 
                {
                    e.Accept = true;
                }
            }
            else
            {
                throw new Exception($"{e.PolicyErrors}{Environment.NewLine}{e.Certificate}");
            }
        }

        public static FtpClient CreateClient(Uri host, bool useDataEncryption = true, FtpEncryptionMode encryptionMode = FtpEncryptionMode.Auto)
        {
            try
            {
                if (host.Scheme != Uri.UriSchemeFtp)
                {
                    throw new UriFormatException();
                }

                FtpClient client = new FtpClient(host);
                client.DataConnectionEncryption = useDataEncryption;
                client.EncryptionMode = encryptionMode;
                client.ValidateCertificate += ValidatingCertificate;

                // connect to the server and automatically detect working FTP settings
                client.AutoConnect();

                return client;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static FtpClient CreateClient(string host, bool useDataEncryption = true, FtpEncryptionMode encryptionMode = FtpEncryptionMode.Auto)
        {
            try
            {
                FtpClient client = new FtpClient(host);
                client.DataConnectionEncryption = useDataEncryption;
                client.EncryptionMode = encryptionMode;
                client.ValidateCertificate += ValidatingCertificate;
                // connect to the server and automatically detect working FTP settings
                client.AutoConnect();

                return client;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static FtpClient CreateClient(Uri host, NetworkCredential credentials, bool useDataEncryption = true, FtpEncryptionMode encryptionMode = FtpEncryptionMode.Auto)
        {
            try
            {
                if (host.Scheme != Uri.UriSchemeFtp)
                {
                    throw new UriFormatException();
                }

                FtpClient client = new FtpClient(host, credentials);
                client.DataConnectionEncryption = useDataEncryption;
                client.EncryptionMode = encryptionMode;
                client.ValidateCertificate += ValidatingCertificate;
                // connect to the server and automatically detect working FTP settings
                client.AutoConnect();

                return client;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static FtpClient CreateClient(Uri host, string username, string password = "", bool useDataEncryption = true, FtpEncryptionMode encryptionMode = FtpEncryptionMode.Auto)
        {
            try
            {
                if (host.Scheme != Uri.UriSchemeFtp)
                {
                    throw new UriFormatException();
                }

                FtpClient client = new FtpClient(host, username, password);
                client.DataConnectionEncryption = useDataEncryption;
                client.EncryptionMode = encryptionMode;
                client.ValidateCertificate += ValidatingCertificate;

                // connect to the server and automatically detect working FTP settings
                client.AutoConnect();

                return client;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static FtpClient CreateClient(Uri host, int port, string username, string password = "", bool useDataEncryption = true, FtpEncryptionMode encryptionMode = FtpEncryptionMode.Auto)
        {
            try
            {
                if (host.Scheme != Uri.UriSchemeFtp)
                {
                    throw new UriFormatException();
                }

                FtpClient client = new FtpClient(host, port, username, password);
                client.DataConnectionEncryption = useDataEncryption;
                client.EncryptionMode = encryptionMode;
                client.ValidateCertificate += ValidatingCertificate;
                // connect to the server and automatically detect working FTP settings
                client.AutoConnect();

                return client;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static FtpClient CreateClient(string host, string username, string password = "", bool useDataEncryption = true, FtpEncryptionMode encryptionMode = FtpEncryptionMode.Auto) 
        {
            try
            {
                FtpClient client = new FtpClient(host, username, password);
                client.DataConnectionEncryption = useDataEncryption;
                client.EncryptionMode = encryptionMode;
                client.ValidateCertificate += ValidatingCertificate;
                // connect to the server and automatically detect working FTP settings
                client.AutoConnect();

                return client;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static FtpClient CreateClient(string host, int port, string username, string password = "", bool useDataEncryption = true, FtpEncryptionMode encryptionMode = FtpEncryptionMode.Auto)
        {
            try
            {
                FtpClient client = new FtpClient(host, port, username, password);
                client.DataConnectionEncryption = useDataEncryption;
                client.EncryptionMode = encryptionMode;
                client.ValidateCertificate += ValidatingCertificate;
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
                client.DisconnectAsync();
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);                  
            }
        }

        public static void DiscardClient(FtpClient client)
        {
            try
            {
                client.Dispose();
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);
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

        public static FtpStatus UploadFile(FtpClient client, string file, string to = "/")
        {
            try
            {
                to = Path.Combine(to, Path.GetFileName(file));
                return client.UploadFile(file, to);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async static Task<FtpStatus> UploadFileAsync(FtpClient client, string file, string to = "/") 
        {
            try
            {
                to = Path.Combine(to, Path.GetFileName(file));
                return await client.UploadFileAsync(file, to);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool MoveFile(FtpClient client, string from, string to = "/")
        {
            try
            {
                to = Path.Combine(to, Path.GetFileName(from));
                return client.MoveFile(from, to);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async static Task<bool> MoveFileAsync(FtpClient client, string from, string to = "/")
        {
            try
            {
                to = Path.Combine(to, Path.GetFileName(from));
                return await client.MoveFileAsync(from, to);
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

        public static FtpStatus DownloadFile(FtpClient client, string file, string to)
        {
            try
            {
                to = Path.Combine(to, Path.GetFileName(file));
                return client.DownloadFile(to, file);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async static Task<FtpStatus> DownloadFileAsync(FtpClient client, string file, string to)
        {
            try
            {
                to = Path.Combine(to, Path.GetFileName(file));
                return await client.DownloadFileAsync(to, file);
            }
            catch (Exception ex)
            {
                throw ex;
            }    
        }
        public static void DeleteFile(FtpClient client, string file)
        {
            try
            {
                client.DeleteFile(file);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async static void DeleteFileAsync(FtpClient client, string file)
        {
            try
            {
                await client.DeleteFileAsync(file);
            }
            catch (Exception ex)
            {
                throw ex;
            }     
        }

        public async static Task<List<FtpResult>> UploadDirectoryAsync(FtpClient client, string localDirectory, string remoteDirectory = "/", FtpFolderSyncMode ftpFolderSyncMode = FtpFolderSyncMode.Update )
        {
            try
            {
                return await client.UploadDirectoryAsync(localDirectory, remoteDirectory, ftpFolderSyncMode);
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);
                return null;
            }
            
        }

        public async static Task<List<FtpResult>> DownloadDirectoryAsync(FtpClient client, string remoteDirectory, string localDirectory, FtpFolderSyncMode ftpFolderSyncMode = FtpFolderSyncMode.Update )
        {
            try
            {
                return await client.DownloadDirectoryAsync(localDirectory, remoteDirectory, ftpFolderSyncMode);
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);
                return null;
            }
        }
    }
}
