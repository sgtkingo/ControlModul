using System;
using System.Data;
using System.Data.OleDb;
using System.IO;

using ControlModul.Handlers.Loger;

namespace ControlModul.DBControl.ExcelConnectorOLE
{
    /// <summary>
    /// Useful class that represented Excel connector 
    /// </summary>
    /// <remarks>
    /// Easy connect to any Excel file and work with it
    /// 
    /// - Allow fast (OLE engine) R/W
    /// - Auto Excel Connection String create
    /// </remarks>
    public class ExcelConnector
    {
        public DataTable Data { get; private set; }

        public string ExcelListName { get; private set; }

        public ExcelConnectionString ConnectionString { get; private set; }

        private OleDbConnection oleDbConnection;
        private OleDbCommand oleDbCommand;
        private OleDbDataAdapter oleDbDataAdapter;

        #region Constructors
        public ExcelConnector(){ 
            this.Data = new DataTable();
            this.ConnectionString = new ExcelConnectionString();
        }

        public ExcelConnector(string excelFileToConnect) : this(){ 
            ConnectFile(excelFileToConnect);
        }
        #endregion

        #region Public methods
        public bool ExtractExcelFile(string ListName){ 
            ExcelListName = ListName;
            Loger.Info($"Starting  extract {ConnectionString.Data_Source}|{ExcelListName}");

            using (oleDbConnection = new OleDbConnection(ConnectionString.ToString())){ 
                oleDbCommand = new OleDbCommand("Select * From [" + ExcelListName + "$]", oleDbConnection);
                //Try open connection
                try { oleDbConnection.Open(); }
                catch (OleDbException e)
                { 
                    Loger.LogAndVisualize(e); 
                    return false; 
                }
                //Using adapter to send dB command
                oleDbDataAdapter = new OleDbDataAdapter(oleDbCommand);
                try { 
                    oleDbDataAdapter.Fill(this.Data);
                }
                catch (InvalidOperationException e)
                {
                    Loger.LogAndVisualize(e); 
                    return false; 
                }
            }
            Loger.Info($"Extraction {ConnectionString.Data_Source}|{ExcelListName} success!");
            return true;
        }

        public void ConnectFile(string filePath){ 
            if( File.Exists(filePath) ){ 
                ConnectionString.Data_Source = filePath;
                Loger.Info($"File {filePath} connected!");
            }
            else 
                Loger.Error($"File {filePath} does NOT exist!", true);
        }
        #endregion
    }
}
