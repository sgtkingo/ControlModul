using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Data;
using System.Data.Common;

namespace ControlModul.Entity
{
    /// <summary>
    /// Simple static extendor class for Entity framework
    /// </summary>
    /// <remarks>
    /// - Add <see cref="GetTable(DbContext, string, string)"> extension mutable method
    /// - Add <see cref="AsTable(DbContext, string)"> extension mutable method
    /// </remarks>
    public static class DbContextExtensions
    {
        /*
         * need
            Only EntityFramework
         */
        public static DataTable GetTable<T>(this DbContext context, string schemaName = "dbo",
                                                    string tableName = null) where T : class
        {
            //Name rules for tables
            if( string.IsNullOrEmpty(tableName))
            {
                tableName = typeof(T).Name;
                if (tableName.EndsWith("e"))
                {
                    tableName += "s";
                }
                else tableName += "es";
            }
            string textQuery = $"SELECT * FROM [{schemaName}].[{tableName}]";
            return AsTable(context, textQuery);
        }
        public static DataTable AsTable(this DbContext context, string sqlQuery,
                                          params DbParameter[] parameters)
        {
            DataTable dataTable = new DataTable();

            DbConnection connection = context.Database.Connection;
            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(connection);

            try
            {
                using (var cmd = dbFactory.CreateCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sqlQuery;
                    if (parameters != null)
                    {
                        foreach (var item in parameters)
                        {
                            cmd.Parameters.Add(item);
                        }
                    }
                    using (DbDataAdapter adapter = dbFactory.CreateDataAdapter())
                    {
                        adapter.SelectCommand = cmd;
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataTable;
        }
    }
}
