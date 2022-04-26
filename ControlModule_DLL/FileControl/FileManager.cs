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
            string data = string.Empty;

            if (!File.Exists(virtualFile.FILEPATH))
            {
                Loger.Error($"File {virtualFile.FILEPATH} DOESNT exist!");
                return false;
            }
            try{ 
                using (FileStream fs = new FileStream(virtualFile.FILEPATH,FileMode.Open))
                {
                fs.Seek(0,SeekOrigin.Begin);
                    StreamReader sr=new StreamReader(fs);

                    while(!sr.EndOfStream){ 
                        data += sr.ReadLine();
                        data += "\n";
                    }
                    sr.Close();
                }               
            }catch (Exception e){
                Loger.LogAndVisualize(e);
                return false;
            }
            virtualFile.FillFile(data);
            Loger.Info("File "+virtualFile.FILENAME+" loaded...");
            return true;
        }

        public static bool SaveFile(VirtualFile virtualFile){
            if(virtualFile == null)return false;

            string filePath=(virtualFile.FILEPATH);
            try{ 
                using (FileStream fs = new FileStream(filePath,FileMode.Create))
                {
                fs.Seek(0,SeekOrigin.Begin);
                    StreamWriter sw=new StreamWriter(fs);
                    sw.Write(virtualFile.GetData());
                    sw.Close();
                }               
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
