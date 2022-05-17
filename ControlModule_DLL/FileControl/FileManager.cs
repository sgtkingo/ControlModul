using System;
using System.IO;

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
            if (!File.Exists(virtualFile.FILEPATH))
            {
                Loger.Error($"File {virtualFile.FILEPATH} DOESNT exist!");
                return false;
            }
            try{
                var data = LoadFile(virtualFile.FILEPATH);
                virtualFile.FillFile(data);
            }catch (Exception e){
                Loger.LogAndVisualize(e);
                return false;
            }

            Loger.Info("File "+virtualFile.FILENAME+" loaded...");
            return true;
        }

        public static bool SaveFile(VirtualFile virtualFile){
            if(virtualFile == null)return false;

            try{
                SaveFile(virtualFile.FILEPATH, virtualFile.FILEDATA);
            }catch (Exception e){
                Loger.LogAndVisualize(e);
                return false;
            }

            Loger.Info("File "+virtualFile.FILENAME+" saved!");
            return true;
        }

        public static bool SaveFile(string path, string data){
            try
            {
                File.WriteAllText(path, data);
            }
            catch (Exception e)
            {
                Loger.LogAndVisualize(e);
                return false;
            }
            return true;
        }

        public static string LoadFile(string path){
            string data = string.Empty;
            try
            {
                data = File.ReadAllText(path);
            }
            catch (Exception e)
            {
                Loger.LogAndVisualize(e);
            }
            return data;
        }
    }
}
