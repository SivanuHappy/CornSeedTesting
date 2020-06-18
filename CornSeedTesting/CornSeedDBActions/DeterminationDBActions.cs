using System;
using QA.Utilities.DatabaseConnectivity;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using QA.Utilities.TestHelpers;
using System.Data;

namespace CornSeedTesting.CornSeedDBActions
{

    public class DeterminationDBActions
    {
        private readonly IDatabaseConnectivity db;
        private static string connectionString;
        IConfiguration settings = TestHelper.GetConfig();
        DatabaseModel dbModel;

        public DeterminationDBActions(IDatabaseConnectivity _db, DatabaseModel _dbModel)
        {
            this.db = _db;
            this.dbModel = _dbModel;
            connectionString = db.GetConnectionString(dbModel.DataSource = settings["DBSettings:DataSource"], dbModel.Authentication = settings["DBSettings:Authentication"], dbModel.InitialCatalog = settings["DBSettings:InitialCatalog"], dbModel.UserId = settings["DBSettings:UserID"], dbModel.Password = settings["DBSettings:Password"]);
        }

        public int CheckClaimantHasTaxIDConfirmedEvent(string claimantId)
        {
            Dictionary<int, List<string>> records = null;
            int rowsAffected = 0;
            string query = "select e.eventid from tblclaimant c join tblevents e on e.foreignkeyid = c.claimantid where c.settlementid = @claimantid and eventtypeid = 35";
            SqlParameter queryParameter = new SqlParameter("@claimantid", SqlDbType.NVarChar);
            queryParameter.Value = claimantId;
            records = db.GetRecords(connectionString, query, CommandType.Text, queryParameter);
            if (records.Count >= 1)
            {
                rowsAffected = records.ElementAt(0).Key;
            }
            else
                rowsAffected = 0;
            return rowsAffected;
        }

        public int CheckClaimantHasW9AcceptedEvent(string claimantId)
        {
            Dictionary<int, List<string> > records = null;
            int rowsAffected = 0;
            string query = "select * from tblclaimant c join tblevents e on e.foreignkeyid = c.claimantid where c.settlementid = @claimantid and eventtypeid = 68";
            SqlParameter queryParameter = new SqlParameter("@claimantid", SqlDbType.NVarChar);
            queryParameter.Value = claimantId;
            records = db.GetRecords(connectionString, query, CommandType.Text, queryParameter);
            if (records.Count >= 1)
            {
                rowsAffected = records.ElementAt(0).Key;
            }
            else
                rowsAffected = 0;
            return rowsAffected;
        }

        public void UpdateDeadlineResponseDate(string claimantId)
        {
            Int32 rowsaffected = 0;
            DateTime currentDate = DateTime.Now;
            TimeSpan ts = new TimeSpan(15, 0,0, 0);
            string updateDate = currentDate.Subtract(ts).ToString("yyyy-MM-dd");
            string query = "update tblrptnotices set DeadlineResponseDate = @date where noticeid in " +
                "(select noticeid from tblrptnotices where settlementid = @claimantId and lettertypeid in (7, 14, 15) and active = 1)";
            SqlParameter queryParameter1 = new SqlParameter("@claimantId", claimantId);
            SqlParameter queryParameter2 = new SqlParameter("@date", updateDate);
            rowsaffected = db.ExecuteNonQuery(connectionString, query, CommandType.Text, queryParameter1, queryParameter2);
        }

        //public void UpdateDocumentUpdateDate(string claimantId)
        //{
        //    Int32 rowsaffected = 0;
        //    DateTime currentDate = DateTime.Now;
        //    TimeSpan ts = new TimeSpan(16, 0, 0, 0);
        //    string updateDate = currentDate.Subtract(ts).ToString("yyyy-MM-dd");
        //    string query = "update tbldocuments set updatedate = @date " +
        //        "where PDocID in (select pdocid from tblDocuments d " +
        //        "join tblclaimant c on c.ClaimantID = d.ForeignKeyID  and foreignkeyrefid = 1 " + 
        //        "where SettlementID = @claimantId and documenttypeid not in (44, 50))";
        //    SqlParameter queryParameter1 = new SqlParameter("@claimantId", claimantId);
        //    SqlParameter queryParameter2 = new SqlParameter("@date", updateDate);
        //    rowsaffected = db.ExecuteNonQuery(connectionString, query, CommandType.Text, queryParameter1, queryParameter2);
        //}

    }
}
