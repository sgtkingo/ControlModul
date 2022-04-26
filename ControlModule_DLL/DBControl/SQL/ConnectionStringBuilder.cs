using System.Data.SqlClient;
using System;

namespace ControlModul.DBControl.SQL
{
    /// <summary>
    /// Static simple class that can build custom SQL database Connection String
    /// </summary>
    /// <remarks>
    /// Easy build custom SQL database Connection String with different static methods
    /// </remarks>
    public static class ConnectionStringBuilder
    {
        static SqlConnectionStringBuilder _scsb;
        public static string BuildConnectionString_Std(string server, string database, string user_id, string password){
            _scsb = new SqlConnectionStringBuilder();
            _scsb.DataSource = server;
            _scsb.InitialCatalog = database;
            _scsb.UserID = user_id;
            _scsb.Password = password;
            _scsb.IntegratedSecurity = false;

            return _scsb.ConnectionString;
        }

        public static string BuildConnectionString_Std_WithInstance(string server, string instance, string database, string user_id, string password)
        {
            _scsb = new SqlConnectionStringBuilder();
            _scsb.DataSource = server+@"\"+instance;
            _scsb.InitialCatalog = database;
            _scsb.UserID = user_id;
            _scsb.Password = password;
            _scsb.IntegratedSecurity = false;

            return _scsb.ConnectionString;
        }

        public static string BuildConnectionString_Trusted(string server, string database, string userName = "")
        {
            _scsb = new SqlConnectionStringBuilder();
            _scsb.DataSource = server;
            _scsb.InitialCatalog = database;
            _scsb.UserID = userName;
            _scsb.IntegratedSecurity = true;

            return _scsb.ConnectionString;
        }
    }
}
