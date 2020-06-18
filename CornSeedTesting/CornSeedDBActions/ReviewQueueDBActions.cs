using System;
using System.Collections.Generic;
using System.Text;
using QA.Utilities.DatabaseConnectivity;
using Microsoft.Data.SqlClient;
using CornSeedTesting.Models;
using Microsoft.Extensions.Configuration;
using QA.Utilities.TestHelpers;

namespace CornSeedTesting.CornSeedDBActions
{
    public class ReviewQueueDBActions
    {
        private readonly IDatabaseConnectivity db;
        public string connectionString;
        public SqlConnection connection;
        List<Acres> acresDB = new List<Acres>();
        string query = "";
        IConfiguration settings = TestHelper.GetConfig();
        private readonly DatabaseModel dbModel;
        public ReviewQueueDBActions(IDatabaseConnectivity _db)
        {
            this.db = _db;
            connectionString = db.GetConnectionString(dbModel.DataSource = settings["DBSettings:DataSource"], dbModel.Authentication = settings["DBSettings:Authentication"], dbModel.InitialCatalog = settings["DBSettings:InitialCatalog"], dbModel.UserId = settings["DBSettings:UserID"], dbModel.Password = settings["DBSettings:Password"]);
            connection = db.GetSqlConnection(connectionString);
        }

        public List<Acres> GetAcresFromDB(string source, string claimantId)
        {       
            Dictionary<int, List<string>> claimantAcres = new Dictionary<int, List<string>>();
            SqlCommand command;
            switch (source)
            {
                case "Claim Form":
                    query = "select nfsa.FarmNbr, nfsa.TractNbr, nfsa.CLUFieldNbr," +
                        "my.SettlementYear, nfsa.CornAcreage, "+
                        "case when cd.ClaimTypeID = 1 then nfsa.ProducerSharePct " +
                        "when cd.ClaimTypeID = 4 then nfsa.LandLordShare end sharepercentage, " +
                        "nfsa.AdjPLSharePct " +
                        "from tblCRNonFSAData nfsa " +
                        "join tblclaimant c on c.ClaimantID = nfsa.ClaimantID " +
                        "join tblClaimDetail cd on cd.ClaimantID = c.ClaimantID " +
                        "join ctblMarketingYear my on my.MarketingYearID = nfsa.MarketingYearID " +
                        "where c.SettlementID = @claimantid order by nfsa.FarmNbr";
                    command = new SqlCommand(query, connection);
                    claimantAcres = db.SelectRecords(connectionString, connection, command, query, claimantId);
                    foreach (KeyValuePair<int, List<string>> claimantAcre in claimantAcres)
                    {
                        acresDB.Add(new Acres()
                        {
                            Source = "Claim Form",
                            Relevance = "Claim Form",
                            FarmNumber = claimantAcre.Value[0],
                            TractNumber = claimantAcre.Value[1],
                            FieldNumber = claimantAcre.Value[2],
                            MarketingYear = claimantAcre.Value[3],
                            PlantingPrimCode = "",
                            CornAcreage = claimantAcre.Value[4],
                            SharePercentage = claimantAcre.Value[5],
                            TotalSharePercentage = "",
                            AdjSharePercentage = claimantAcre.Value[6],
                            LinkedClaimantId = " "
                        });                       
                    }
                    break;

                case "FSA":
                    query = "select fo.FarmNumber, fo.TractNumber, fo.FieldNumber," +
                        "my.SettlementYear, fo.plantingprimstatuscode, fo.CropFieldRepQuantity, " +
                        "fo.CropSharePercentage, fo.AdjTotalCropSharePercentage, fo.AdjCropSharePercentage " +
                        "from tblCRFSAOverlap fo " +
                        "join tblclaimant c on c.ClaimantID = fo.ClaimantID " +
                        "join tblClaimDetail cd on cd.ClaimantID = c.ClaimantID " +
                        "join ctblMarketingYear my on my.MarketingYearID = fo.MarketingYearID " +
                        "where c.SettlementID = @claimantid order by fo.FarmNumber";
                    command = new SqlCommand(query, connection);
                    claimantAcres = db.SelectRecords(connectionString, connection, command, query, claimantId);
                    foreach(KeyValuePair<int, List<string>> claimantAcre in claimantAcres)
                    {
                        acresDB.Add(new Acres()
                        {
                            Source = "FSA",
                            Relevance = "Claim Form",
                            FarmNumber = claimantAcre.Value[0],
                            TractNumber = claimantAcre.Value[1],
                            FieldNumber = claimantAcre.Value[2],
                            MarketingYear = claimantAcre.Value[3],
                            PlantingPrimCode = claimantAcre.Value[4],
                            CornAcreage = claimantAcre.Value[5],
                            SharePercentage = claimantAcre.Value[6],
                            TotalSharePercentage = claimantAcre.Value[7],
                            AdjSharePercentage = claimantAcre.Value[8],
                            LinkedClaimantId = " "
                        });
                    }                   
                    break;

                case "RMA":
                    query = "select * from tblclaimant c " +
                        "join tblcrrmaoverlap fo on fo.claimantid = c.claimantid " +
                        "where c.settlementid = @claimantid";
                    //  claimantAcres= db.GetClaimantDetails(query, claimantId);
                    acresDB.Add(new Acres()
                    {
                        Source = "RMA",
                        Relevance = "Claim Form",
                        FarmNumber = claimantAcres[0].ToString(),
                        TractNumber = claimantAcres[1].ToString(),
                        FieldNumber = claimantAcres[2].ToString(),
                        MarketingYear = claimantAcres[3].ToString(),
                        PlantingPrimCode = claimantAcres[0].ToString(),
                        CornAcreage = claimantAcres[4].ToString(),
                        SharePercentage = claimantAcres[5].ToString(),
                        TotalSharePercentage = claimantAcres[0].ToString(),
                        AdjSharePercentage = claimantAcres[6].ToString(),
                        LinkedClaimantId = claimantAcres[0].ToString()
                    });
                    break;

                case "Lease":
                    query = "select lnk.FarmNbr, lnk.TractNbr, lnk.CLUFieldNbr, " +
                        "my.SettlementYear, " +
                        "case when lnk.SourceTypeID = 1 then lnk.PlantingPrimStatusCode " +
                        "else null end, " +
                        "lnk.CornAcreage, " +
                        "case when cd.ClaimTypeID = 1 then lnk.ProducerSharePct " +
                        "when cd.ClaimTypeID = 4 then lnk.LandLordShare end sharepercentage, " +
                        "lnk.AdjPLSharePct, c.SettlementID " +
                        "from tblclaimant c " +
                        "join tblCRLnkClaimantAcreageData lnk on lnk.claimantid = c.claimantid " +
                        "join tblclaimdetail cd on cd.ClaimantID = lnk.linkedclaimantid "+
                        "join ctblMarketingYear my on my.MarketingYearID = lnk.MarketingYearID " +
                        "where c.settlementid = @claimantid order by lnk.FarmNbr";
                    command = new SqlCommand(query, connection);
                    claimantAcres = db.SelectRecords(connectionString, connection, command, query, claimantId);
                    foreach (KeyValuePair<int, List<string>> claimantAcre in claimantAcres)
                    {
                        acresDB.Add(new Acres()
                        {
                            Source = "Lease",
                            Relevance = "Claim Form",
                            FarmNumber = claimantAcre.Value[0],
                            TractNumber = claimantAcre.Value[1],
                            FieldNumber = claimantAcre.Value[2],
                            MarketingYear = claimantAcre.Value[3],
                            PlantingPrimCode = claimantAcre.Value[4],
                            CornAcreage = claimantAcre.Value[5],
                            SharePercentage = claimantAcre.Value[6],
                            TotalSharePercentage = "",
                            AdjSharePercentage = claimantAcre.Value[7],
                            LinkedClaimantId = claimantAcre.Value[8]
                        });
                    }
                    break;
            }
            return acresDB;
        }

    }
}
