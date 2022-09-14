using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using ControlModul.Handlers.Loger;

namespace ControlModul.FileControl
{
    /// <summary>
    /// Static class that represented simple file manager
    /// </summary>
    /// <remarks>
    /// Load and save files by different methods
    /// 
    /// - Possiblity to use VirtualFile files"/>
    /// </remarks>
    public static class FileManager
    {
        public static bool LoadFile(VirtualFile virtualFile){ 
            if(virtualFile == null)return false;

            virtualFile.EraseData();
            try
            {
                var data = LoadFile(virtualFile.FILEPATH);
                virtualFile.FillFile(data);
            }
            catch (Exception e)
            {
                Loger.LogAndVisualize(e);
                return false;
            }
            return true;
        }

        public static bool SaveFile(VirtualFile virtualFile){
            if(virtualFile == null)return false;

            try
            {
                SaveFile(virtualFile.FILEPATH, virtualFile.FILEDATA);
            }
            catch (Exception e)
            {
                Loger.LogAndVisualize(e);
                return false;
            }
            return true;
        }

        public static bool SaveFile(string path, string data){
            try
            {
                File.WriteAllText(path, data);
                Loger.Info("File " + path + " saved!");
            }
            catch (Exception e)
            {
                Loger.Log(e);
                throw e;
            }
            return true;
        }

        public static string LoadFile(string path){
            string data = string.Empty;
            try
            {
                data = File.ReadAllText(path);
                Loger.Info("File " + path + " loaded...");
            }
            catch (Exception e)
            {
                Loger.Log(e);
                throw e;
            }
            return data;
        }

        public static void FileTransfer(string file, string to, bool overwrite = true)
        {
            try
            {
                var target = Path.Combine(to, Path.GetFileName(file));
                File.Copy(file, target, overwrite);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static IEnumerable<string> GetDictonaryIndex(string path, string filter = "*.*")
        {
            try
            {
                return Directory.EnumerateFiles(path, filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static IEnumerable<string> GetDictonariesIntersect(string path1, string path2, string filter1="*.*", string filter2="*.*") 
        {
            try
            {
                var comparer = new IFileComparer();

                var localIndex = GetDictonaryIndex(path1, filter1);
                var targetIndex = GetDictonaryIndex(path2, filter2);

                return localIndex.Except(targetIndex, comparer);
            }
            catch (Exception ex)
            {
                Loger.Log(ex);
                return null;
            }
        }

        internal class IFileComparer : IEqualityComparer<string>
        {
            public bool Equals(string path1, string path2)
            {
                return Path.GetFileName(path1).Equals(Path.GetFileName(path2));
            }

            public int GetHashCode(string path)
            {
                return Path.GetFileName(path).GetHashCode();
            }
        }
    }
}
