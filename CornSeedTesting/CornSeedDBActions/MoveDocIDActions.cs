//using Microsoft.Extensions.Configuration;
//using QA.Utilities.DatabaseConnectivity;
//using QA.Utilities.TestHelpers;
//using System;
//using System.Collections.Generic;
//using Microsoft.Data.SqlClient;
//using System.Linq;

//namespace CornSeedTesting.CornSeedDBActions
//{
//    public class MoveDocIDActions
//    {
//        private readonly IDatabaseConnectivity db;
//        private static string connectionString;
//        private static SqlConnection connection;
//        IConfiguration settings = TestHelper.GetConfig();
//        DatabaseModel dbModel;

//        public MoveDocIDActions(IDatabaseConnectivity _db, DatabaseModel _dbModel)
//        {
//            this.db = _db;
//            this.dbModel = _dbModel;
//            connectionString = db.GetConnectionString(dbModel.DataSource = settings["DBSettings:DataSource"], dbModel.Authentication = settings["DBSettings:Authentication"], dbModel.InitialCatalog = settings["DBSettings:InitialCatalog"], dbModel.UserId = settings["DBSettings:UserID"], dbModel.Password = settings["DBSettings:Password"]);
//            connection = db.GetSqlConnection(connectionString);
//        }

//        public int CheckDocumentDetailsHistoryTable(string inCDocID)
//        {
//            Dictionary<int, List<string>> records = null;
//            int rowsAffected = 0;
//            string query = "select * from tbldocumentdetails_hist where CDocID = 1444556";
//            Int32 cDocId = Int32.Parse(inCDocID);
//            SqlCommand command = new SqlCommand(query, connection);
//            records = db.SelectRecords(connectionString, connection, command, query, cDocId);
//            if (records.Count >= 1)
//            {
//                rowsAffected = records.ElementAt(0).Key;
//            }
//            else
//                rowsAffected = 0;
//            return rowsAffected;
//        }
//    }
//}
