using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ControlModul.FileControl;
using ControlModul.Handlers.Reporter;
using ControlModul.Protocols.FTP;

using FluentFTP;

namespace ControlModul.Handlers.Loger
{
    /// <summary>
    /// Manage logs created by Loger
    /// </summary>
    public static class LogerManager
    {
        private static FtpClient _ftpClient;
        private static Uri _ftpUri = null;

        public static bool HasValidExternalBackupSet 
        { 
            get
            {
                return _ftpClient != null;
            }
        }

        private static int _daysDeleteLimit = 365;
        public static int DaysDeleteLimit
        {
            get
            {
                return _daysDeleteLimit;
            }
            set
            {
                if (value < 0)
                {
                    value *= -1;
                }
                _daysDeleteLimit = value;
            }
        }

        public static string LogDirectory
        {
            get
            {
                return Loger.LogDir;
            }
            set
            {
                try
                {
                    Loger.SetLogDir(value, true);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        private static string _targetDirectory;
        public static string TargetDirectory
        {
            get
            {
                return _targetDirectory;
            }
            set
            {
                try
                {
                    _targetDirectory = value;
                    if (string.IsNullOrEmpty(_targetDirectory))
                    {
                        _targetDirectory = Path.Combine(LogDirectory, "backup");
                    }
                    if (!Directory.Exists(_targetDirectory))
                    {
                        Directory.CreateDirectory(_targetDirectory);
                    }
                }
                catch (Exception ex)
                {
                    _targetDirectory = null;
                    throw ex;
                }
            }
        }


        public static List<Report> Reports { get; private set; } = new List<Report>();

        public static void Init(string logDir = null, string targetDir = null)
        {
            try
            {
                LogDirectory = logDir;
                TargetDirectory = targetDir;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SetExternalBackup(Uri ftpUri, string username = null, string password = "")
        {
            try
            {
                if (ftpUri.Scheme != Uri.UriSchemeFtp)
                {
                    throw new UriFormatException();
                }
                else _ftpUri = ftpUri;

                if (string.IsNullOrEmpty(username))
                {
                    _ftpClient = FTPManager.CreateClient(ftpUri);
                }
                else
                {
                    _ftpClient = FTPManager.CreateClient(ftpUri, username, password);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UnsetExternalBackup()
        {
            if( _ftpClient !=null)
            {
                FTPManager.DiscardClient(_ftpClient);
                _ftpClient = null;
            }
        }

        public static List<Report> Load()
        {
            try
            {
                Reports.Clear();
                //TODO: Looks to LogDirectory and load all logs to Reports list

                var index = FileManager.GetDictonaryIndex(LogDirectory, "*.log");
                foreach (var file in index)
                {
                    var containment = File.ReadAllText(file);
                    var reportdate = File.GetCreationTime(file);

                    Reports.Add(new Report(file, containment, reportdate));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Reports;
        }

        public static void Delete(Report report)
        {
            try
            {
                if (Reports.Contains(report))
                {
                    File.Delete(report.Source as string);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Backup(Report report)
        {
            try
            {
                if (Reports.Contains(report))
                {
                    FileManager.FileTransfer(report.Source as string, TargetDirectory);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async static void ExBackup(Report report)
        {
            try
            {
                if (Reports.Contains(report))
                {
                    await FTPManager.UploadFileAsync(_ftpClient, report.Source as string, _ftpUri.LocalPath);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Maintanance()
        {
            try
            {
                //TODO: Looks to LogDirectory and delete all logs older than DaysDeleteLimit
                var localIndex = FileManager.GetDictonaryIndex(LogDirectory, "*.log");
                foreach (var file in localIndex)
                {
                    var writetime = File.GetLastWriteTime(file);
                    if (DateTime.Now.Subtract(writetime).TotalDays > DaysDeleteLimit)
                    {
                        File.Delete(file);
                    }
                }
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);
            }
        }

        public static void DoBackup()
        {
            try
            {
                var intersectIndex = FileManager.GetDictonariesIntersect(LogDirectory, TargetDirectory, "*.log", "*.log");
                foreach (var file in intersectIndex)
                {
                    FileManager.FileTransfer(file, TargetDirectory);
                }
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);
            }
        }

        public async static void DoExternalBackUp() 
        {
            try
            {
                await FTPManager.UploadDirectoryAsync(_ftpClient, LogDirectory, _ftpUri.LocalPath, FtpFolderSyncMode.Update);
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);
            }
        }
    }
}