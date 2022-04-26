using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ControlModul.DBControl.SQL
{
    /// <summary>
    /// Class that represented SQL DB manager and connection manager
    /// </summary>
    /// <remarks>
    /// Easy connect to any SQL DB, databases and SQL servers autofinder, basic data-transfer methods  
    /// 
    /// - Possibility to fast test connection by  <see cref="FastTestConnectionString(string)"/> metod
    /// - Possibility to autofind DB servers and databases by <see cref="GetLocalServerIntances()"/> and <see cref="GetServerDatabases(string)"/> metods
    /// - Build autonomous SQL connection by  <see cref="BuildConnection(string)"/>
    /// - Get structured server info
    /// </remarks>
    public class DatabaseManager
    {
        //TODO dodelat metody pro práci s SQL Serverem
        public SQLConnector SQLConnector { get; private set; }

        #region Static methods
        public static bool FastTestConnectionString(string connectionString)
        {
            try
            {
                var connnector = SQLConnector.BuildConnector(connectionString);
                if (connnector.TestConnection() == TestState.OK)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetLocalServerIntances()
        {
            DataTable foundedInstances = null;
            try
            {
                SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
                foundedInstances = instance.GetDataSources();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return foundedInstances;
        }

        public static DataTable GetServerDatabases(string serverName)
        {
            DataTable foundedDatabases = null;
            try
            {
                string localServerConnectionString = ConnectionStringBuilder.BuildConnectionString_Trusted(serverName, string.Empty);
                using (var connection = new SqlConnection(localServerConnectionString))
                {
                    connection.Open();
                    foundedDatabases = connection.GetSchema("Databases");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return foundedDatabases;
        }
        #endregion

        #region Constructors
        public DatabaseManager() { }

        public DatabaseManager(string connectionString){
            if( string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException();
            }
            BuildConnection(connectionString);
        }
        #endregion

        #region Public methods
        public SQLConnector BuildConnection(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException();
            }
            if (SQLConnector != null)
            {
                SQLConnector.Disconnect();
            }
            SQLConnector = SQLConnector.BuildConnector(connectionString);

            return SQLConnector;
        }
        public void Connect()
        {
            try
            {
                SQLConnector.Connect();
            }
            catch (Exception e)
            {
                throw e;
            }         
        }
        public async Task ConnectAsync()
        {
            try
            {
                await SQLConnector.ConnectAsync();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public void Disconnect()
        {
            try
            {
                SQLConnector.Disconnect();
            }
            catch (Exception e)
            {

                throw e;
            } 
        }
        public async Task DisconnectAsync(){
            try
            {
                await SQLConnector.DisconnectAsync();
            }
            catch (Exception e)
            {
                throw e;
            }          
        }

        public TestState Test()
        {
            if (SQLConnector == null) return TestState.FAIL;
            return SQLConnector.TestConnection();
        }

        public async Task TestAsync()
        {
            if (SQLConnector == null) return;
            await SQLConnector.TestConnectionAsync();
        }

        public string GetServerInfo(){
            if (SQLConnector == null) return "Internal error occours...!";
            return $"{SQLConnector.GetServerFriendlyName()}, status=[{SQLConnector.ConnectionMessage}], errors=[{SQLConnector.ErrorMessage}]";
        }

        public string GetServerStatus()
        {
            if (SQLConnector == null) return "Internal error occours...!";
            return $"{SQLConnector.ConnectionMessage}, errors=[{SQLConnector.ErrorMessage}]";
        }

        public virtual Exception SendData(DataSet dataSet)
        {
            return new NotImplementedException();
        }

        public virtual DataSet GetData(DataSet dataSet)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
