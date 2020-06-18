using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using QA.Utilities.TestHelpers;
using QA.Utilities.DatabaseConnectivity;
using System.Collections;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CornSeedTesting.CornSeedDBActions
{
    public class FSARMAActions
    {
        private readonly IDatabaseConnectivity db;
        private static string connectionString;
        private static SqlConnection connection;
        IConfiguration settings = TestHelper.GetConfig();
        DatabaseModel dbModel;
        public FSARMAActions(IDatabaseConnectivity _db, DatabaseModel _dbModel)
        {
            this.db = _db;
            this.dbModel = _dbModel;
            connectionString = db.GetConnectionString(dbModel.DataSource = settings["DBSettings:DataSource"], dbModel.Authentication = settings["DBSettings:Authentication"], dbModel.InitialCatalog = settings["DBSettings:InitialCatalog"], dbModel.UserId = settings["DBSettings:UserID"], dbModel.Password = settings["DBSettings:Password"]);
            connection = db.GetSqlConnection(connectionString);
        }
 
        public int GetTransferDataID(string transferTypeId)
        {
            int transferdataid = 0;            
            string query = "insert into dbo.tblTransferData " +
                        "(TransferTypeID, CreatedBy, CreateDate, UpdatedBy, UpdateDate)" +
                        "output INSERTED.Transferdataid " +
                        "VALUES(" + transferTypeId + ", 1, dbo.GETESTDATE(), 1, dbo.GETESTDATE()) ";
            SqlCommand command = new SqlCommand(query, connection);
            transferdataid = db.GetLastAffectedValue(connectionString, connection, command, query);
            Console.WriteLine(transferdataid);
            return transferdataid;
        }

        public void InsertIntoResponseTable(string source, string cid, string transfertypeId, Dictionary<string, List<string>> dicPairs, Hashtable ht, string comment, string fname, string mname, string lname, string businessname, string formatname, string bgfirstname, string bgmiddlename, string bglastname, string bgbusinessname, string address1, string address2, string city, string state, string zip, string nametype, string entitytypecode, string year, string stateid, string locationstateabbrev, string countycode, string locationcountyname, string commoditycode, string typecode, string practicecode, string landtypecode, string farmnumber, string tractnumber, string fieldid, string fieldnumber, string cropcode, string croptypecode, string cropintendedusecode, string irricode, string plantprimcode, string plantseccode, string plantmulticode, string croplandindicator, string cropfieldrep, string cropdeterim, string lastdatechanged, string customernumber, string businesspartycode, string landid, string rluid, string cluid, string cropsharepercentage, string settlementid)
        {
            string query;
            string taxQuery = "";
            int transferDataId;
            SqlCommand command;
            Dictionary<int, List<string>> taxDetails = new Dictionary<int, List<string>>();
            if (transfertypeId.Equals("2") || transfertypeId.Equals("4"))
            {
                taxQuery = "select pii.taxpayerid, pii.taxpayertypeid from tblclaimant c join tblpiidata pii on pii.foreignkeyid = c.claimantid and pii.foreignkeyrefid = 1 where c.settlementid = @claimantid";
            }
            else if (transfertypeId.Equals("13") || transfertypeId.Equals("15"))
            {
                taxQuery = "select sws.taxpayerid, sws.taxpayertypeid from tblclaimant c join tblsws02form sws on sws.claimantid = c.claimantid and sws.swstypeid = 2 where c.settlementid = @claimantid and InvalidTaxID = 0";
            }
            else if (transfertypeId.Equals("17") || transfertypeId.Equals("19"))
            {
                taxQuery = "select swsd.taxpayerid, swsd.taxpayertypeid from tblclaimant c join tblsws02formdetails swsd on swsd.claimantid = c.claimantid and swsd.swstypeid = 2 where c.settlementid = @claimantid and InvalidTaxID = 0";
            }
            else if (transfertypeId.Equals("23") || transfertypeId.Equals("25"))
            {
                taxQuery = "select swsd.taxpayerid, swsd.taxpayertypeid from tblclaimant c join tblsws02formdetails swsd on swsd.claimantid = c.claimantid and swsd.swstypeid in (4,5) where c.settlementid = @claimantid and InvalidTaxID = 0";
            }
            SqlParameter parametercid = new SqlParameter("@claimantid", SqlDbType.NVarChar);
            parametercid.Value = settlementid;
            taxDetails = db.GetRecords(connectionString, taxQuery, CommandType.Text, parametercid);
            List<string> taxInfo = taxDetails[1];
            List<string> cidTType;
            switch (source)
            {
                case "FSA":
                    if (dicPairs.ContainsKey(cid))
                    {
                        cidTType = dicPairs[cid];
                        if (cidTType.Contains(transfertypeId))
                        {
                            transferDataId = (int)ht[transfertypeId];
                            query = "Insert Into dbo.tblFSAResponseDetail (TransferDataID, TaxID, taxtype, comment, FirstName, LastName, FormattedName," +
                                      " Address1, Address2, City, State, ZipCode, NameType," +
                                      "ProgramYear, StateID, CountyCode, FarmNumber, TractNumber, FieldID, FieldNumber," +
                                      " CropCode, CropTypeCode, CropIntendedUseCode, IrrigationPracticeCode," +
                                      " PlantingPrimStatusCode, PlantingSecStatusCode, PlantingMultiCropCode, " +
                                      "CroplandIndicator, CropFieldRepQuantity, CropFieldDetermQuantity, LastDateChanged, CustomerNumber, BusinessPartyTypeCode, CropSharePercentage, SettlementID, ProcessedDate)" +
                                      "VALUES(@TransferDataID, @taxId, @taxType, @comment, @fname, @lname, @formatname, " +
                                      "@address1, @address2, @city, @state, @zip, @nametype, " +
                                      "@programyear, @stateid, @countycode, @farmnumber, @tractnumber, @fieldid, @fieldnumber," +
                                      "@cropcode, @croptypecode, @cropintendedusecode, @irricode, @plantprimcode, @plantsecode, @plantmulticode," +
                                      "@croplandindicator, @croprep, @cropdeterim, @lastdate, @customernumber, @businesspartycode, @sharepercentage, @settlementid, @processeddate)";
                            command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@TransferDataID", transferDataId);
                            command.Parameters.AddWithValue("@taxId", taxInfo[0]);
                            command.Parameters.AddWithValue("@taxType", taxInfo[1]);
                            command.Parameters.AddWithValue("@comment", comment);
                            command.Parameters.AddWithValue("@fname", fname);
                            command.Parameters.AddWithValue("@lname", lname);
                            command.Parameters.AddWithValue("@formatname", formatname);
                            command.Parameters.AddWithValue("@address1", address1);
                            command.Parameters.AddWithValue("@address2", address2);
                            command.Parameters.AddWithValue("@city", city);
                            command.Parameters.AddWithValue("@state", state);
                            command.Parameters.AddWithValue("@zip", zip);
                            command.Parameters.AddWithValue("@nametype", nametype);
                            command.Parameters.AddWithValue("@programyear", year);
                            command.Parameters.AddWithValue("@stateid", stateid);
                            command.Parameters.AddWithValue("@countycode", countycode);
                            command.Parameters.AddWithValue("@farmnumber", farmnumber);
                            command.Parameters.AddWithValue("@tractnumber", tractnumber);
                            command.Parameters.AddWithValue("@fieldid", fieldid);
                            command.Parameters.AddWithValue("@fieldnumber", fieldnumber);
                            command.Parameters.AddWithValue("@cropcode", cropcode);
                            command.Parameters.AddWithValue("@croptypecode", croptypecode);
                            command.Parameters.AddWithValue("@cropintendedusecode", cropintendedusecode);
                            command.Parameters.AddWithValue("@irricode", irricode);
                            command.Parameters.AddWithValue("@plantprimcode", plantprimcode);
                            command.Parameters.AddWithValue("@plantsecode", plantseccode);
                            command.Parameters.AddWithValue("@plantmulticode", plantmulticode);
                            command.Parameters.AddWithValue("@croplandindicator", croplandindicator);
                            command.Parameters.AddWithValue("@croprep", cropfieldrep);
                            command.Parameters.AddWithValue("@cropdeterim", cropdeterim);
                            command.Parameters.AddWithValue("@lastdate", DateTime.Now);
                            command.Parameters.AddWithValue("@customernumber", customernumber);
                            command.Parameters.AddWithValue("@businesspartycode", businesspartycode);
                            command.Parameters.AddWithValue("@sharepercentage", cropsharepercentage);
                            command.Parameters.AddWithValue("@settlementid", settlementid);
                            command.Parameters.AddWithValue("@processeddate", DBNull.Value);
                            db.ManipulateRecord(connectionString, connection, command, query);
                        }
                    }
                    break;
                case "RMA":
                    if (dicPairs.ContainsKey(cid))
                    {
                        cidTType = dicPairs[cid];
                        if (cidTType.Contains(transfertypeId))
                        {
                            transferDataId = (int)ht[transfertypeId];
                            query = "Insert Into dbo.tblRMAResponseDetail (TransferDataID, CommodityYear, TaxID, TaxType, " +
                                        "BGFirstName, BGMiddleName, BGLastName, BGBusinessName," +
                                      "FirstName, MiddleName, LastName, BusinessName, FormattedName," +
                                      "Address1, Address2, City, State, ZipCode, EntityTypeCode, " +
                                      "LocationStateCode, LocationStateAbbrev, LocationCountyCode, LocationCountyName, " +
                                      "CommodityCode, TypeCode, PracticeCode, InsuredSharePercent, LandTypeCode, " +
                                      "FarmNumber, TractNumber, fieldnumber, LandID, RLUID, CLUID," +
                                      "ReportedAcreage, SettlementID, ProcessedDate)" +
                                      "VALUES(@TransferDataID, @commodityyear, @taxID, @taxType, " +
                                      "@bgfirstname, @bgmiddlename, @bglastname, @bgbusinessname, " +
                                      "@firstname, @middlename, @lastname, @businessname, @formatname, " +
                                      "@address1, @address2, @city, @state, @zipcode, @entitytypecode, " +
                                      "@locationstatecode, @locationstateabbrev, @locationcountycode, @locationcountyname, " +
                                      "@commoditycode, @typecode, @practicecode, @insuredsharedpercent, @landtypecode, " +
                                      "@farmnumber, @tractnumber, @fieldnumber, @landid, @rluid, @cluid, " +
                                      "@reportedacreage, @settlementid, @processeddate)";
                            command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@TransferDataID", transferDataId);
                            command.Parameters.AddWithValue("@commodityyear", year);
                            command.Parameters.AddWithValue("@taxID", taxInfo[0]);
                            command.Parameters.AddWithValue("@taxType", taxInfo[1]);
                            command.Parameters.AddWithValue("@bgfirstname", bgfirstname);
                            command.Parameters.AddWithValue("@bgmiddlename", bgmiddlename);
                            command.Parameters.AddWithValue("@bglastname", bglastname);
                            command.Parameters.AddWithValue("@bgbusinessname", bgbusinessname);
                            command.Parameters.AddWithValue("@firstname", fname);
                            command.Parameters.AddWithValue("@middlename", mname);
                            command.Parameters.AddWithValue("@lastname", lname);
                            command.Parameters.AddWithValue("@businessname", businessname);
                            command.Parameters.AddWithValue("@formatname", formatname);
                            command.Parameters.AddWithValue("@address1", address1);
                            command.Parameters.AddWithValue("@address2", address2);
                            command.Parameters.AddWithValue("@city", city);
                            command.Parameters.AddWithValue("@state", state);
                            command.Parameters.AddWithValue("@zipcode", zip);
                            command.Parameters.AddWithValue("@entitytypecode", entitytypecode);
                            command.Parameters.AddWithValue("@locationstatecode", stateid);
                            command.Parameters.AddWithValue("@locationstateabbrev", locationstateabbrev);
                            command.Parameters.AddWithValue("@locationcountycode", countycode);
                            command.Parameters.AddWithValue("@locationcountyname", locationcountyname);
                            command.Parameters.AddWithValue("@commoditycode", commoditycode);
                            command.Parameters.AddWithValue("@typecode", typecode);
                            command.Parameters.AddWithValue("@practicecode", practicecode);
                            command.Parameters.AddWithValue("@insuredsharedpercent", cropsharepercentage);
                            command.Parameters.AddWithValue("@landtypecode", landtypecode);
                            command.Parameters.AddWithValue("@farmnumber", farmnumber);
                            command.Parameters.AddWithValue("@tractnumber", tractnumber);
                            command.Parameters.AddWithValue("@fieldnumber", fieldnumber);
                            command.Parameters.AddWithValue("@landid", landid);
                            command.Parameters.AddWithValue("@rluid", rluid);
                            command.Parameters.AddWithValue("@cluid", cluid);
                            command.Parameters.AddWithValue("@reportedacreage", cropfieldrep);
                            command.Parameters.AddWithValue("@settlementid", settlementid);
                            command.Parameters.AddWithValue("@processeddate", DBNull.Value);
                            db.ManipulateRecord(connectionString, connection, command, query);
                        }
                    }
                    break;
            }
        }
    }
}

