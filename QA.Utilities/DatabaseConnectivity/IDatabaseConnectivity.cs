using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace QA.Utilities.DatabaseConnectivity
{
    public interface IDatabaseConnectivity
    {
        public string GetConnectionString(string dataSource, string authentication, string initialCatalog, string userId, string password);
        public SqlConnection GetSqlConnection(string connectionString);
        public int GetLastAffectedValue(string connectionString, SqlConnection connection, SqlCommand command, string query);
        public Dictionary<int, List<string>> SelectRecords(string connectionString, SqlConnection connection, SqlCommand command, string query, string claimantId);
        public int ManipulateRecord(string connectionString, SqlConnection connection, SqlCommand command, string query);
        public Dictionary<int, List<string>> GetRecords(string connectionString, string commandText, CommandType commandType, params SqlParameter[] parameters);
        public int ExecuteNonQuery(string connectionString, string commandText, CommandType commandType, params SqlParameter[] parameters);
    }
}
