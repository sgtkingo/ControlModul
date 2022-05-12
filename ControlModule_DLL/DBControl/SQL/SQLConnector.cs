using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

using ControlModul.DBControl.SQL.Exceptions;

namespace ControlModul.DBControl.SQL
{
    /// <summary>
    /// Enum represented state of DB connection test result
    /// </summary>
    public enum TestState
    {
        OK,
        FAIL,
        NOT_TESTED
    }
    /// <summary>
    /// Class that represented connector to SQL DB
    /// </summary>
    /// <remarks>
    /// Easy connect to any SQL DB 
    /// 
    /// - Possibility to fast connect by  <see cref="Connect()"/> metod
    /// - Possibility to secure testing connection by  <see cref="TestConnection()"/> metod
    /// - Async twin metods>
    /// - Error and info messages>
    /// </remarks>
    public class SQLConnector
    {
        #region Constants
        private const string messageOpen = "Connection is opened...";
        private const string messageClose = "Connection is closed...";
        private const string messageConnecting = "Connecting in progress...";
        private const string messageExecuting = "Executing in progress...";
        private const string messageFetching = "Fetching in progress...";
        private const string messageBroken = "Connection is broken!";
        private const string messageDisconnected = "Disconnected...";

        private const string messageOK = "Connection OK...";
        private const string messageFAIL = "Connection FAILED!";
        private const string messageNOT_TESTED = "Not tested yet...";
        #endregion

        #region Creditals
        public string ServerAddress { get; private set; }
        public string DatabaseName { get; private set; }
        public bool IntegratedSecurity { get; private set; } 
        public string Username { get; private set; }
        private string Password { get; set; }
        #endregion

        #region Test variables
        public TestState LastTestResult { get; private set; }
        public DateTime? LastTestTime { get; private set; }
        public string LastTestMessage {
            get {
                switch (LastTestResult)
                {
                    case TestState.OK:
                        return $"{messageOK} [{LastTestTime}]";
                    case TestState.FAIL:
                        return $"{messageFAIL} [{LastTestTime}]";
                    case TestState.NOT_TESTED:
                        return $"{messageNOT_TESTED} [{LastTestTime}]";
                    default:
                        break;
                }
                return "Unknown test state...";
            }
        }

        public string ErrorMessage { get; private set; }
        public string InfoMessage { get; private set; }
        #endregion

        #region Connection variables
        public ConnectionState ConnectionStatus 
        { 
            get {
                return Connection.State;
            }
        }
        public string ConnectionMessage 
        { 
            get 
            {
                switch (ConnectionStatus)
                {
                    case ConnectionState.Closed:
                        return messageClose;
                    case ConnectionState.Open:
                        return messageOpen;
                    case ConnectionState.Connecting:
                        return messageConnecting;
                    case ConnectionState.Executing:
                        return messageExecuting;
                    case ConnectionState.Fetching:
                        return messageFetching;
                    case ConnectionState.Broken:
                        return messageBroken;
                    default:
                        break;
                }
                return messageDisconnected;
            } 
        }

        public string ConnectionString { get; private set; }
        public SqlConnection Connection { get; private set; }
        #endregion

        #region Constructors
        private SQLConnector(string connectionString)
        {
            if( string.IsNullOrEmpty(connectionString) )
            {
                ErrorMessage = "Connection String is Null Or Empty!";
                throw new ConnectionStringIsEmptyException();
            }
            ConnectionString = connectionString;

            Connection = new SqlConnection(connectionString);
            Connection.FireInfoMessageEventOnUserErrors = true;
            Connection.InfoMessage += InfoMessageEventHandler;

            LastTestResult = TestState.NOT_TESTED;
            LastTestTime = null;

            ParseConnectionString(connectionString);
        }

        public static SQLConnector BuildConnector(string connectionString){
            return new SQLConnector(connectionString);
        }
        #endregion

        #region Connection And Testing methods
        public void Connect(){
            try
            {
                Connection.Open();
            }
            catch (SqlException e)
            {
                ErrorMessage = e.Message;
                throw e;
            }
        }

        public async Task ConnectAsync()
        {
            await Task.Run(() => this.Connect());
        }

        public void Disconnect()
        {
            try
            {
                Connection.Close();
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                throw e;
            }
        }
        public async Task DisconnectAsync()
        {
            await Task.Run(() => this.Disconnect());
        }

        public TestState TestConnection(){

            try
            {
                using (Connection)
                {
                    Connection.Open();
                    //Timestamp
                    DoTestTimestamp();
                }
            }
            catch (Exception e)
            {
                DoTestTimestamp();
                ErrorMessage = e.Message;
            }
            return LastTestResult;
        }
        public async Task TestConnectionAsync()
        {
            await Task.Run(() => this.TestConnection());
        }

        private void DoTestTimestamp(){
            if (ConnectionStatus == ConnectionState.Open || ConnectionStatus == ConnectionState.Fetching || ConnectionStatus == ConnectionState.Executing)
            {
                LastTestResult = TestState.OK;
            }
            else LastTestResult = TestState.FAIL;

            LastTestTime = DateTime.Now;
        }
        #endregion

        #region Other Methods
        private void ParseConnectionString(string connectionString){
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder(connectionString);
            this.ServerAddress = scsb.DataSource;
            this.DatabaseName = scsb.InitialCatalog;
            this.Username = scsb.UserID;
            this.Password = scsb.Password;
            this.IntegratedSecurity = scsb.IntegratedSecurity;
        }

        public string GetServerFriendlyName(){
            return $"{ServerAddress} -> {DatabaseName} ({Username})";
        }

        private void InfoMessageEventHandler(object sender, SqlInfoMessageEventArgs e)
        {
            string state = ConnectionStatus.ToString();
            string msg = e.Message;

            this.InfoMessage = $"Last databese info message: state={state}, message={msg}, errors={e.Errors.Count} [{DateTime.Now}]";
            this.ErrorMessage = $"Last databese errors:{e.Errors} [{DateTime.Now}]";

            Debug.WriteLine($"Databese info message: state={state}, message={msg}, errors={e.Errors.Count} [{DateTime.Now}]");
        }
        #endregion
    }
}
