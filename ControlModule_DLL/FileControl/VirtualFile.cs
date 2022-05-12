using System;
using System.IO;

namespace ControlModul.FileControl
{
    /// <summary>
    /// Class that represented text file
    /// </summary>
    /// <remarks>
    /// Create digital virtual twin of any text file or create your own.
    /// 
    /// - Possibility to create empty virual file and append some new on it by <see cref="AppendFile(string, bool)"/>
    /// - Possibility to work with file data to file by <see cref="FillFile(string)">, <see cref="AddData(string, bool)">, <see cref="GetData">, <see cref="EraseData">
    /// - Autosave file by <see cref="SaveFile">
    /// - Possibility to add labels on the top of file by <see cref="SetLabels(string)">
    /// </remarks>
    /// <example>
    /// <code>
    /// static void Main(string[] args)
    /// {
    ///     //Code here
    ///     string filePath = @"../../../sources/test.txt";
    ///
    ///     VirtualFile virtualFile = new VirtualFile(filePath);
    ///     virtualFile.AddData("Baf");
    ///     virtualFile.AddData("Baf", true);
    ///     virtualFile.SaveFile();
    /// }
    /// </code>
    /// </example>
    public class VirtualFile
    {
        #region File variables
        public string FILENAME{ get; private set; }
        public string FILEPATH{ get; private set; }
        public string FILETYPE{ get; private set; }

        public string FILEDATA { get; private set; }
        #endregion

        #region Help variables
        private const char splitCharName=(char)92;
        private const char splitCharType='.';
        #endregion

        #region Private methods
        /// <summary>
        /// Parse file name and type from path
        /// </summary>
        /// <remarks>
        /// Used by <see cref="AppendFile(string, bool)">
        /// </remarks>
        /// <param name="path"><see cref="ParseFileNameAndPath"/> File path variable, should NOT be null or empty!</param>
        /// <returns>This function doesnt return value...</returns>
        private void ParseFileNameAndPath(string path){
            if (string.IsNullOrEmpty(path))
                return;

            FILEPATH = path;
            FILENAME = Path.GetFileName(path);
            FILETYPE = FILENAME.Substring(FILENAME.LastIndexOf(splitCharType));
        }
        #endregion

        #region Constructors
        public VirtualFile(){
            this.Clear();
        }

        public VirtualFile(string filePath, bool tryToLoad = true)
        {
            this.AppendFile(filePath, tryToLoad);
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Append file to this virtual file
        /// </summary>
        /// <remarks>
        /// Used by <see cref="AppendFile(string, bool)">
        /// </remarks>
        /// <param name="path"><see cref="ParseFileNameAndPath(string)"/> File path variable, should NOT be null or empty!</param>
        /// <param name="tryToLoad"> Indicate if object should try to load real file.</param>
        /// <returns>This function doesnt return value...</returns>
        public void AppendFile(string path, bool tryToLoad = true)
        {
            this.Clear();
            ParseFileNameAndPath(path);
            if (tryToLoad)
            {
                this.LoadFile();
            }
        }
        /// <summary>
        /// Fill new text data to <see cref="FILEDATA"/>
        /// </summary>
        /// <param name="data">Text data to fill.</param>
        /// <returns>This function doesnt return value...</returns>
        public void FillFile(string data){
            this.FILEDATA = data;
        }
        /// <summary>
        /// Save to real file by using <see cref="FILEPATH"/>
        /// </summary>
        /// <returns>This function doesnt return value...</returns>
        public void SaveFile()
        {
            FileManager.SaveFile(this);
        }
        /// <summary>
        /// Load real file by using <see cref="FILEPATH"/>
        /// </summary>
        /// <returns>This function doesnt return value...</returns>
        public void LoadFile()
        {
            string data = FileManager.LoadFile(FILEPATH);
            FillFile(data);
        }
        /// <summary>
        /// Append labels on top of virtual file.
        /// </summary>
        /// <param name="labels">Labels to append.</param>
        /// <returns>This function doesnt return value...</returns>
        public void SetLabels(string labels)
        {
            this.FILEDATA = labels +"\n"+ this.FILEDATA;
        }

        /// <summary>
        /// Append text data to the virtual file.
        /// </summary>
        /// <param name="data">Text data to append.</param>
        /// <param name="newLine">Indicate if method should add data to new line.</param>
        /// <returns>This function doesnt return value...</returns>
        public void AddData(string data, bool newLine = false)
        {
            if (newLine)
                FILEDATA += Environment.NewLine;

            FILEDATA += data;
        }
        /// <summary>
        /// ¨Get text data from the virtual file.
        /// </summary>
        /// <returns>Text data as <see cref="string"/></returns>
        public string GetData()
        {
            return FILEDATA;
        }
        /// <summary>
        /// Erase all data from the virtual file.
        /// </summary>
        /// <returns>This function doesnt return value...</returns>
        public void EraseData()
        {
            FILEDATA = string.Empty;
        }
        /// <summary>
        /// Clear virtual file...
        /// </summary>
        /// <returns>This function doesnt return value...</returns>
        public void Clear(){ 
            FILEDATA="";
            FILENAME="";
            FILEPATH="";
            FILETYPE="";                
        }
        /// <summary>
        /// Clear virtual file...
        /// </summary>
        /// <returns>File name in format <fileName>.<fileType> as <see cref="string"/></returns>
        public string GetFullFileName(){
            return Path.GetFileName(FILEPATH);
        }
        #endregion
    }
}
