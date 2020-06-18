using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Collections;

namespace QA.Utilities.DatabaseConnectivity
{
    public class DatabaseConnectivity : IDatabaseConnectivity
    {
        public string GetConnectionString(string dataSource, string authentication, string initialCatalog, string userId, string password)
        {
            return @"Data Source=" + dataSource + ";" +
                    "Authentication=" + authentication + ";" +
                     "Initial Catalog=" + initialCatalog + ";" +
                     "User ID=" + userId + ";" +
                     "Password =" + password + "; ";
        }
        public SqlConnection GetSqlConnection(string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
        public int GetLastAffectedValue(string connectionString, SqlConnection connection, SqlCommand command, string query)
        {
            using (connection = new SqlConnection(connectionString))
            {
                command = new SqlCommand(query, connection);
                command.Connection.Open();
                int lastId = (int)command.ExecuteScalar();
                return lastId;
            }
        }
        public int ManipulateRecord(string connectionString, SqlConnection connection, SqlCommand command, string query)
        {
            Int32 rowsaffected=0;
            using (connection = new SqlConnection(connectionString))
            {
                command.Connection.Open();
                foreach (SqlParameter Parameters in command.Parameters)
                {
                    if (Parameters.Value == null)
                    {
                        Parameters.Value = DBNull.Value;
                    }
                }
                try
                {
                    rowsaffected = command.ExecuteNonQuery();
                    Console.WriteLine(rowsaffected);
                }
                catch (Exception e)
                {
                    throw (e);
                }
                finally
                {
                    command.Connection.Close();
                }
            }
            return rowsaffected;
        }
        public Dictionary<int, List<string>> SelectRecords(string connectionString, SqlConnection connection, SqlCommand command, string query, string searchField)
        {
            List<string> claimantDetails;
            Dictionary<int, List<string>> dicPairs = new Dictionary<int, List<string>>();
            int count = 1;
            using (connection = new SqlConnection(connectionString))
            {
                command = new SqlCommand(query, connection);
                try
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@claimantId", searchField);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        claimantDetails = new List<string>();
                        IDataRecord rowreader = (IDataRecord)reader;
                        for (int i = 0; i < rowreader.FieldCount; i++)
                        {
                            claimantDetails.Add(reader[i].ToString());
                        }
                        dicPairs.Add(count, claimantDetails);
                        // claimantDetails.Clear();
                        count++;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
                finally
                {
                    connection.Close();
                }
                return dicPairs;
            }
        }
        public Dictionary<int, List<string>> GetRecords(string connectionString, string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            List<string> returnRecords;
            Dictionary<int, List<string>> dicPairs = new Dictionary<int, List<string>>();
            int count = 1;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                    try
                    {
                        cmd.CommandType = commandType;
                        cmd.Parameters.AddRange(parameters);
                        cmd.Connection.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            returnRecords = new List<string>();
                            IDataRecord rowreader = (IDataRecord)reader;
                            for (int i = 0; i < rowreader.FieldCount; i++)
                            {
                                returnRecords.Add(reader[i].ToString());
                            }
                            dicPairs.Add(count, returnRecords);
                            // claimantDetails.Clear();
                            count++;
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        throw (ex);
                    }
                    finally
                    {
                        conn.Close();
                    }
                return dicPairs;
            }
        }
        public int ExecuteNonQuery(string connectionString, string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    // There're three command types: StoredProcedure, Text, TableDirect. The TableDirect
                    // type is only for OLE DB.
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

