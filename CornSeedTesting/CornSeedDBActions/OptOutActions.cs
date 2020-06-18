using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using QA.Utilities.TestHelpers;
using QA.Utilities.DatabaseConnectivity;
using Microsoft.Data.SqlClient;


namespace CornSeedTesting.CornSeedDBActions
{
    public class OptOutActions
    {
        private readonly IDatabaseConnectivity db;
        public string connectionString;
        public SqlConnection connection;
        public SqlCommand command;
        IConfiguration settings = TestHelper.GetConfig();
        private readonly DatabaseModel dbModel;
        public OptOutActions(IDatabaseConnectivity _db)
        {
            this.db = _db;
            connectionString = db.GetConnectionString(dbModel.DataSource = settings["DBSettings:DataSource"], dbModel.Authentication = settings["DBSettings:Authentication"], dbModel.InitialCatalog = settings["DBSettings:InitialCatalog"], dbModel.UserId = settings["DBSettings:UserID"], dbModel.Password = settings["DBSettings:Password"]);
            connection = db.GetSqlConnection(connectionString);
        }
        public void InsertIntoOptOutTableForProd(string optoutId, string xmlHistId, string recordNo, string admin, string attaddr1, string attaddr2, string attcity, string attFirst, string attLast, string attMiddle, string attPhone1, string attPhone2, string attPhone3, string attState, string attSuffix, string attZip, string business, string caAcres13, string caAcres13NP, string caAcres14, string caAcres14NP, string caAcres15, string caAcres15NP, string caAcres16, string caAcres16NP, string caAcres17, string caAcres17NP, string caAcresTotal, string child, string city, string cmem13, string CMem13NP, string CMem14, string CMem14NP, string CMem15, string CMem15NP, string CMem16, string CMem16NP, string CMem17, string CMem17NP, string CMemShare, string CMemShareNP, string CPhone1, string CPhone2, string CPhone3, string Day, string Deceased, string EIN, string Executor, string FarmAddress1, string FarmAddress2, string FarmCity, string FarmPhone1, string FarmPhone2, string FarmPhone3, string FarmState, string FarmZip, string FirmName, string First, string GovRecNo, string GovRecYes, string Last, string LegallyInCap, string Middle, string Minor, string Month, string OptOutInc, string OptOutNo, string OptOutYes, string Parent, string PerYear, string RelOther, string RelOtherDesc, string RepEIN, string RepFirst, string RepLast, string RepMiddle, string RepOther, string RepOtherDesc, string RepSSN, string RepSuffix, string RepTaxpayerID, string Sibling, string Signature, string SignHandWritten, string SignNotProvided, string Spouse, string SSN, string StateProvince, string StreetAddress1, string StreetAddress2, string Suffix, string TaxPayerID, string Total, string Year, string ZipCode)
        {
            string query = "";
            query = "INSERT INTO [dbo].[tblFillableOptOutData_Prod] ([OptOutID] " +
            " ,[XMLHistID] " +
            " ,[RecordNo]  " +
            " ,[Administrator]   " +
            " ,[AttAddress1]     " +
            " ,[AttAddress2]     " +
            " ,[AttCity]         " +
            " ,[AttFirst]        " +
            " ,[AttLast]         " +
            " ,[AttMiddle]       " +
            " ,[AttPhone1]       " +
            " ,[AttPhone2]       " +
            " ,[AttPhone3]       " +
            " ,[AttState]        " +
            " ,[AttSuffix]       " +
            " ,[AttZip]          " +
            " ,[BusinessName]    " +
            " ,[CAcres13]        " +
            " ,[CAcres13NP]      " +
            " ,[CAcres14]        " +
            " ,[CAcres14NP]      " +
            " ,[CAcres15]        " +
            " ,[CAcres15NP]      " +
            " ,[CAcres16]        " +
            " ,[CAcres16NP]      " +
            " ,[CAcres17]        " +
            " ,[CAcres17NP]      " +
            " ,[CAcresTotal]     " +
            " ,[Child]           " +
            " ,[City]            " +
            " ,[CMem13]          " +
            " ,[CMem15NP]        " +
            " ,[CMem14]          " +
            " ,[CMem14NP]        " +
            " ,[CMem15]          " +
            " ,[CMem16]          " +
            " ,[CMem16NP]        " +
            " ,[CMem17]          " +
            " ,[CMem17NP]        " +
            " ,[CMem13NP]        " +
            " ,[CMemShare]       " +
            " ,[CMemShareNP]     " +
            " ,[CPhone1]         " +
            " ,[CPhone2]         " +
            " ,[CPhone3]         " +
            " ,[Day]             " +
            " ,[Deceased]        " +
            " ,[EIN]             " +
            " ,[Executor]        " +
            " ,[FarmAddress1]    " +
            " ,[FarmAddress2]    " +
            " ,[FarmCity]        " +
            " ,[FarmPhone1]      " +
            " ,[FarmPhone2]      " +
            " ,[FarmPhone3]      " +
            " ,[FarmState]       " +
            " ,[FarmZip]         " +
            " ,[FirmName]        " +
            " ,[First]           " +
            " ,[GovRecNo]        " +
            " ,[GovRecYes]       " +
            " ,[Last]            " +
            " ,[LegallyInCap]    " +
            " ,[Middle]          " +
            " ,[Minor]           " +
            " ,[Month]           " +
            " ,[OptOutInc]       " +
            " ,[OptOutNo]        " +
            " ,[OptOutYes]       " +
            " ,[Parent]          " +
            " ,[PerYear]         " +
            " ,[RelOther]        " +
            " ,[RelOtherDesc]    " +
            " ,[RepEIN]          " +
            " ,[RepFirst]        " +
            " ,[RepLast]         " +
            " ,[RepMiddle]       " +
            " ,[RepOther]        " +
            " ,[RepOtherDesc]    " +
            " ,[RepSSN]          " +
            " ,[RepSuffix]       " +
            " ,[RepTaxpayerID]   " +
            " ,[Sibling]         " +
            " ,[Signature]       " +
            " ,[SignHandWritten] " +
            " ,[SignNotProvided] " +
            " ,[Spouse]          " +
            " ,[SSN]             " +
            " ,[StateProvince]   " +
            " ,[StreetAddress1]  " +
            " ,[StreetAddress2]  " +
            " ,[Suffix]          " +
            " ,[TaxPayerID]      " +
            " ,[Total]           " +
            " ,[Year]            " +
            " ,[ZipCode])        " +
           " VALUES  " +
             "(@OptOutID  " +
             ",@XMLHistID " +
             ",@RecordNo " +
             ",@Administrator   " +
             ",@AttAddress1   " +
             ",@AttAddress2   " +
             ",@AttCity   " +
             ",@AttFirst   " +
             ",@AttLast   " +
             ",@AttMiddle   " +
             ",@AttPhone1   " +
             ",@AttPhone2   " +
             ",@AttPhone3   " +
             ",@AttState   " +
             ",@AttSuffix   " +
             ",@AttZip   " +
             ",@BusinessName   " +
             ",@CAcres13   " +
             ",@CAcres13NP   " +
             ",@CAcres14   " +
             ",@CAcres14NP   " +
             ",@CAcres15   " +
             ",@CAcres15NP   " +
             ",@CAcres16   " +
             ",@CAcres16NP   " +
             ",@CAcres17   " +
             ",@CAcres17NP   " +
             ",@CAcresTotal   " +
             ",@Child   " +
             ",@City   " +
             ",@CMem13   " +
             ",@CMem15NP   " +
             ",@CMem14   " +
             ",@CMem14NP   " +
             ",@CMem15   " +
             ",@CMem16   " +
             ",@CMem16NP   " +
             ",@CMem17   " +
             ",@CMem17NP   " +
             ",@CMem13NP   " +
             ",@CMemShare   " +
             ",@CMemShareNP   " +
             ",@CPhone1   " +
             ",@CPhone2   " +
             ",@CPhone3   " +
             ",@Day   " +
             ",@Deceased   " +
             ",@EIN   " +
             ",@Executor   " +
             ",@FarmAddress1   " +
             ",@FarmAddress2   " +
             ",@FarmCity   " +
             ",@FarmPhone1   " +
             ",@FarmPhone2   " +
             ",@FarmPhone3   " +
             ",@FarmState   " +
             ",@FarmZip   " +
             ",@FirmName   " +
             ",@First   " +
             ",@GovRecNo   " +
             ",@GovRecYes   " +
             ",@Last   " +
             ",@LegallyInCap   " +
             ",@Middle   " +
             ",@Minor   " +
             ",@Month   " +
             ",@OptOutInc   " +
             ",@OptOutNo   " +
             ",@OptOutYes   " +
             ",@Parent   " +
             ",@PerYear   " +
             ",@RelOther   " +
             ",@RelOtherDesc   " +
             ",@RepEIN   " +
             ",@RepFirst   " +
             ",@RepLast   " +
             ",@RepMiddle   " +
             ",@RepOther   " +
             ",@RepOtherDesc   " +
             ",@RepSSN   " +
             ",@RepSuffix   " +
             ",@RepTaxpayerID   " +
             ",@Sibling   " +
             ",@Signature   " +
             ",@SignHandWritten   " +
             ",@SignNotProvided   " +
             ",@Spouse   " +
             ",@SSN   " +
             ",@StateProvince   " +
             ",@StreetAddress1   " +
             ",@StreetAddress2   " +
             ",@Suffix   " +
             ",@TaxPayerID   " +
             ",@Total   " +
             ",@Year   " +
             ",@ZipCode)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@OptOutID", Int32.Parse(optoutId));
            command.Parameters.AddWithValue("@XMLHistID", Int32.Parse(xmlHistId));
            command.Parameters.AddWithValue("@RecordNo", Int32.Parse(recordNo));
            command.Parameters.AddWithValue("@Administrator", admin);
            command.Parameters.AddWithValue("@AttAddress1", attaddr1);
            command.Parameters.AddWithValue("@AttAddress2", attaddr2);
            command.Parameters.AddWithValue("@AttCity", attcity);
            command.Parameters.AddWithValue("@AttFirst", attFirst);
            command.Parameters.AddWithValue("@AttLast", attLast);
            command.Parameters.AddWithValue("@AttMiddle", attMiddle);
            command.Parameters.AddWithValue("@AttPhone1", attPhone1);
            command.Parameters.AddWithValue("@AttPhone2", attPhone2);
            command.Parameters.AddWithValue("@AttPhone3", attPhone3);
            command.Parameters.AddWithValue("@AttState", attState);
            command.Parameters.AddWithValue("@AttSuffix", attSuffix);
            command.Parameters.AddWithValue("@AttZip", attZip);
            command.Parameters.AddWithValue("@BusinessName", business);
            command.Parameters.AddWithValue("@CAcres13", caAcres13);
            command.Parameters.AddWithValue("@CAcres13NP", caAcres13NP);
            command.Parameters.AddWithValue("@CAcres14", caAcres14);
            command.Parameters.AddWithValue("@CAcres14NP", caAcres14NP);
            command.Parameters.AddWithValue("@CAcres15 ", caAcres15);
            command.Parameters.AddWithValue("@CAcres15NP", caAcres15NP);
            command.Parameters.AddWithValue("@CAcres16", caAcres16);
            command.Parameters.AddWithValue("@CAcres16NP", caAcres16NP);
            command.Parameters.AddWithValue("@CAcres17", caAcres17);
            command.Parameters.AddWithValue("@CAcres17NP", caAcres17NP);
            command.Parameters.AddWithValue("@CAcresTotal", caAcresTotal);
            command.Parameters.AddWithValue("@Child", child);
            command.Parameters.AddWithValue("@City", city);
            command.Parameters.AddWithValue("@CMem13", cmem13);
            command.Parameters.AddWithValue("@CMem13NP", CMem13NP);
            command.Parameters.AddWithValue("@CMem14", CMem14);
            command.Parameters.AddWithValue("@CMem14NP", CMem14NP);
            command.Parameters.AddWithValue("@CMem15", CMem15);
            command.Parameters.AddWithValue("@CMem15NP", CMem15NP);
            command.Parameters.AddWithValue("@CMem16", CMem16);
            command.Parameters.AddWithValue("@CMem16NP", CMem16NP);
            command.Parameters.AddWithValue("@CMem17", CMem17);
            command.Parameters.AddWithValue("@CMem17NP", CMem17NP);
            command.Parameters.AddWithValue("@CMemShare ", CMemShare);
            command.Parameters.AddWithValue("@CMemShareNP", CMemShareNP);
            command.Parameters.AddWithValue("@CPhone1 ", CPhone1);
            command.Parameters.AddWithValue("@CPhone2 ", CPhone2);
            command.Parameters.AddWithValue("@CPhone3 ", CPhone3);
            command.Parameters.AddWithValue("@Day", Day);
            command.Parameters.AddWithValue("@Deceased", Deceased);
            command.Parameters.AddWithValue("@EIN", EIN);
            command.Parameters.AddWithValue("@Executor", Executor);
            command.Parameters.AddWithValue("@FarmAddress1", FarmAddress1);
            command.Parameters.AddWithValue("@FarmAddress2", FarmAddress2);
            command.Parameters.AddWithValue("@FarmCity", FarmCity);
            command.Parameters.AddWithValue("@FarmPhone1", FarmPhone1);
            command.Parameters.AddWithValue("@FarmPhone2", FarmPhone2);
            command.Parameters.AddWithValue("@FarmPhone3", FarmPhone3);
            command.Parameters.AddWithValue("@FarmState ", FarmState);
            command.Parameters.AddWithValue("@FarmZip", FarmZip);
            command.Parameters.AddWithValue("@FirmName", FirmName);
            command.Parameters.AddWithValue("@First", First);
            command.Parameters.AddWithValue("@GovRecNo", GovRecNo);
            command.Parameters.AddWithValue("@GovRecYes", GovRecNo);
            command.Parameters.AddWithValue("@Last", Last);
            command.Parameters.AddWithValue("@LegallyInCap", LegallyInCap);
            command.Parameters.AddWithValue("@Middle", Middle);
            command.Parameters.AddWithValue("@Minor", Minor);
            command.Parameters.AddWithValue("@Month", Month);
            command.Parameters.AddWithValue("@OptOutInc", OptOutInc);
            command.Parameters.AddWithValue("@OptOutNo", OptOutNo);
            command.Parameters.AddWithValue("@OptOutYes", OptOutYes);
            command.Parameters.AddWithValue("@Parent", Parent);
            command.Parameters.AddWithValue("@PerYear", PerYear);
            command.Parameters.AddWithValue("@RelOther", RelOther);
            command.Parameters.AddWithValue("@RelOtherDesc", RelOtherDesc);
            command.Parameters.AddWithValue("@RepEIN", RepEIN);
            command.Parameters.AddWithValue("@RepFirst", RepFirst);
            command.Parameters.AddWithValue("@RepLast", RepLast);
            command.Parameters.AddWithValue("@RepMiddle", RepMiddle);
            command.Parameters.AddWithValue("@RepOther", RepOther);
            command.Parameters.AddWithValue("@RepOtherDesc", RepOtherDesc);
            command.Parameters.AddWithValue("@RepSSN", RepSSN);
            command.Parameters.AddWithValue("@RepSuffix", RepSuffix);
            command.Parameters.AddWithValue("@RepTaxpayerID ", RepTaxpayerID);
            command.Parameters.AddWithValue("@Sibling", Sibling);
            command.Parameters.AddWithValue("@Signature", Signature);
            command.Parameters.AddWithValue("@SignHandWritten", SignHandWritten);
            command.Parameters.AddWithValue("@SignNotProvided", SignNotProvided);
            command.Parameters.AddWithValue("@Spouse", Spouse);
            command.Parameters.AddWithValue("@SSN", SSN);
            command.Parameters.AddWithValue("@StateProvince", StateProvince);
            command.Parameters.AddWithValue("@StreetAddress1 ", StreetAddress1);
            command.Parameters.AddWithValue("@StreetAddress2 ", StreetAddress2);
            command.Parameters.AddWithValue("@Suffix", Suffix);
            command.Parameters.AddWithValue("@TaxPayerID", TaxPayerID);
            command.Parameters.AddWithValue("@Total", Total);
            command.Parameters.AddWithValue("@Year", Year);
            command.Parameters.AddWithValue("@ZipCode", ZipCode);
            db.ManipulateRecord(connectionString, connection, command, query);
        }
        public void InsertIntoOptOutTableForEG(string claimType, string optoutId, string xmlHistId, string recordNo, string Administrator, string AttAddress1, string AttAddress2, string AttCity, string AttFirst, string AttLast, string AttMiddle, string AttPhone1, string AttPhone2, string AttPhone3, string AttState, string AttSuffix, string AttZip, string BusinessName, string Child, string City, string CPhone1, string CPhone2, string CPhone3, string Day, string Deceased, string EIN, string Executor, string FirmName, string First, string Last, string LegallyInCap, string Middle, string Minor, string Month, string MY2013, string MY2013NP, string MY2014, string MY2014NP, string MY2015, string MY2015NP, string MY2016, string MY2016NP, string MY2017, string MY2017NP, string MYAfter2013, string MYAfter2013NP, string MYAfter2014, string MYAfter2014NP, string MYAfter2015, string MYAfter2015NP, string MYAfter2016, string MYAfter2016NP, string MYAfter2017, string MYAfter2017NP, string MYAfterNP, string MYAfterPerYear, string MYAfterTotal, string MYNP, string MYPerYear, string MYSTon2013, string MYSTon2013NP, string MYSTon2014, string MYSTon2014NP, string MYSTon2015, string MYSTon2015NP, string MYSTon2016, string MYSTon2016NP, string MYSTon2017, string MYSTon2017NP, string MYSTonCapacity, string MYSTonCapacityNP, string MYSTonNP, string MYSTonPerYear, string MYSTonTotal, string MYTotal, string OptOutInc, string OptOutNo, string OptOutYes, string Parent, string RelOther, string RelOtherDesc, string RepEIN, string RepFirst, string RepLast, string RepMiddle, string RepOther, string RepOtherDesc, string RepSSN, string RepSuffix, string RepTaxpayerID, string Sibling, string Signature, string SignHandWritten, string SignNotProvided, string Spouse, string SSN, string StateProvince, string StreetAddress1, string StreetAddress2, string Suffix, string TaxPayerID, string Year, string ZipCode)
        {
            string query = "INSERT INTO [dbo].[tblFillableOptOutData_" + claimType + "] " +
                  "  ([OptOutID]			 " +
                  "  ,[XMLHistID]		 " +
                  "  ,[RecordNo]			 " +
                  "  ,[Administrator]	 " +
                  "  ,[AttAddress1]		 " +
                  "  ,[AttAddress2]		 " +
                  "  ,[AttCity]			 " +
                  "  ,[AttFirst]			 " +
                  "  ,[AttLast]			 " +
                  "  ,[AttMiddle]		 " +
                  "  ,[AttPhone1]		 " +
                  "  ,[AttPhone2]		 " +
                  "  ,[AttPhone3]		 " +
                  "  ,[AttState]			 " +
                  "  ,[AttSuffix]		 " +
                  "  ,[AttZip]			 " +
                  "  ,[BusinessName]		 " +
                  "  ,[Child]			 " +
                  "  ,[City]				 " +
                  "  ,[CPhone1]			 " +
                  "  ,[CPhone2]			 " +
                  "  ,[CPhone3]			 " +
                  "  ,[Day]				 " +
                  "  ,[Deceased]			 " +
                  "  ,[EIN]				 " +
                  "  ,[Executor]			 " +
                  "  ,[FirmName]			 " +
                  "  ,[First]			 " +
                  "  ,[Last]				 " +
                  "  ,[LegallyInCap]		 " +
                  "  ,[Middle]			 " +
                  "  ,[Minor]			 " +
                  "  ,[Month]			 " +
                  "  ,[MY2013]			 " +
                  "  ,[MY2013NP]			 " +
                  "  ,[MY2014]			 " +
                  "  ,[MY2014NP]			 " +
                  "  ,[MY2015]			 " +
                  "  ,[MY2015NP]			 " +
                  "  ,[MY2016]			 " +
                  "  ,[MY2016NP]			 " +
                  "  ,[MY2017]			 " +
                  "  ,[MY2017NP]			 " +
                  "  ,[MYAfter2013]		 " +
                  "  ,[MYAfter2013NP]	 " +
                  "  ,[MYAfter2014]		 " +
                  "  ,[MYAfter2014NP]	 " +
                  "  ,[MYAfter2015]		 " +
                  "  ,[MYAfter2015NP]	 " +
                  "  ,[MYAfter2016]		 " +
                  "  ,[MYAfter2016NP]	 " +
                  "  ,[MYAfter2017]		 " +
                  "  ,[MYAfter2017NP]	 " +
                  "  ,[MYAfterNP]		 " +
                  "  ,[MYAfterPerYear]	 " +
                  "  ,[MYAfterTotal]		 " +
                  "  ,[MYNP]				 " +
                  "  ,[MYPerYear]		 " +
                  "  ,[MYSTon2013]		 " +
                  "  ,[MYSTon2013NP]		 " +
                  "  ,[MYSTon2014]		 " +
                  "  ,[MYSTon2014NP]		 " +
                  "  ,[MYSTon2015]		 " +
                  "  ,[MYSTon2015NP]		 " +
                  "  ,[MYSTon2016]		 " +
                  "  ,[MYSTon2016NP]		 " +
                  "  ,[MYSTon2017]		 " +
                  "  ,[MYSTon2017NP]		 " +
                  "  ,[MYSTonCapacity]	 " +
                  "  ,[MYSTonCapacityNP]	 " +
                  "  ,[MYSTonNP]			 " +
                  "  ,[MYSTonPerYear]	 " +
                  "  ,[MYSTonTotal]		 " +
                  "  ,[MYTotal]			 " +
                  "  ,[OptOutInc]		 " +
                  "  ,[OptOutNo]			 " +
                  "  ,[OptOutYes]		 " +
                  "  ,[Parent]			 " +
                  "  ,[RelOther]			 " +
                  "  ,[RelOtherDesc]		 " +
                  "  ,[RepEIN]			 " +
                  "  ,[RepFirst]			 " +
                  "  ,[RepLast]			 " +
                  "  ,[RepMiddle]		 " +
                  "  ,[RepOther]			 " +
                  "  ,[RepOtherDesc]		 " +
                  "  ,[RepSSN]			 " +
                  "  ,[RepSuffix]		 " +
                  "  ,[RepTaxpayerID]	 " +
                  "  ,[Sibling]			 " +
                  "  ,[Signature]		 " +
                  "  ,[SignHandWritten]	 " +
                  "  ,[SignNotProvided]	 " +
                  "  ,[Spouse]			 " +
                  "  ,[SSN]				 " +
                  "  ,[StateProvince]	 " +
                  "  ,[StreetAddress1]	 " +
                  "  ,[StreetAddress2]	 " +
                  "  ,[Suffix]			 " +
                  "  ,[TaxPayerID]		 " +
                  "  ,[Year]				 " +
                  "  ,[ZipCode])          " +
             " VALUES " +
                   " (@OptOutID " +
                   ",@XMLHistID " +
                   ",@RecordNo" +
                   ",@Administrator " +
                   ",@AttAddress1 " +
                   ",@AttAddress2 " +
                   ",@AttCity " +
                   ",@AttFirst " +
                   ",@AttLast " +
                   ",@AttMiddle " +
                   ",@AttPhone1 " +
                   ",@AttPhone2 " +
                   ",@AttPhone3 " +
                   ",@AttState " +
                   ",@AttSuffix " +
                   ",@AttZip " +
                   ",@BusinessName " +
                   ",@Child " +
                   ",@City " +
                   ",@CPhone1 " +
                   ",@CPhone2 " +
                   ",@CPhone3 " +
                   ",@Day " +
                   ",@Deceased " +
                   ",@EIN " +
                   ",@Executor " +
                   ",@FirmName " +
                   ",@First " +
                   ",@Last " +
                   ",@LegallyInCap " +
                   ",@Middle " +
                   ",@Minor " +
                   ",@Month " +
                   ",@MY2013 " +
                   ",@MY2013NP " +
                   ",@MY2014 " +
                   ",@MY2014NP " +
                   ",@MY2015 " +
                   ",@MY2015NP " +
                   ",@MY2016 " +
                   ",@MY2016NP " +
                   ",@MY2017 " +
                   ",@MY2017NP " +
                   ",@MYAfter2013 " +
                   ",@MYAfter2013NP " +
                   ",@MYAfter2014 " +
                   ",@MYAfter2014NP " +
                   ",@MYAfter2015 " +
                   ",@MYAfter2015NP " +
                   ",@MYAfter2016 " +
                   ",@MYAfter2016NP " +
                   ",@MYAfter2017 " +
                   ",@MYAfter2017NP " +
                   ",@MYAfterNP " +
                   ",@MYAfterPerYear " +
                   ",@MYAfterTotal " +
                   ",@MYNP " +
                   ",@MYPerYear " +
                   ",@MYSTon2013 " +
                   ",@MYSTon2013NP " +
                   ",@MYSTon2014 " +
                   ",@MYSTon2014NP " +
                   ",@MYSTon2015 " +
                   ",@MYSTon2015NP " +
                   ",@MYSTon2016 " +
                   ",@MYSTon2016NP " +
                   ",@MYSTon2017 " +
                   ",@MYSTon2017NP " +
                   ",@MYSTonCapacity " +
                   ",@MYSTonCapacityNP " +
                   ",@MYSTonNP " +
                   ",@MYSTonPerYear " +
                   ",@MYSTonTotal " +
                   ",@MYTotal " +
                   ",@OptOutInc " +
                   ",@OptOutNo " +
                   ",@OptOutYes " +
                   ",@Parent " +
                   ",@RelOther " +
                   ",@RelOtherDesc " +
                   ",@RepEIN " +
                   ",@RepFirst " +
                   ",@RepLast " +
                   ",@RepMiddle " +
                   ",@RepOther " +
                   ",@RepOtherDesc " +
                   ",@RepSSN " +
                   ",@RepSuffix " +
                   ",@RepTaxpayerID " +
                   ",@Sibling " +
                   ",@Signature " +
                   ",@SignHandWritten " +
                   ",@SignNotProvided " +
                   ",@Spouse " +
                   ",@SSN " +
                   ",@StateProvince " +
                   ",@StreetAddress1 " +
                   ",@StreetAddress2 " +
                   ",@Suffix " +
                   ",@TaxPayerID " +
                   ",@Year " +
                   ",@ZipCode)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@OptOutID", Int32.Parse(optoutId));
            command.Parameters.AddWithValue("@XMLHistID", Int32.Parse(xmlHistId));
            command.Parameters.AddWithValue("@RecordNo", Int32.Parse(recordNo));
            command.Parameters.AddWithValue("@Administrator", Administrator);
            command.Parameters.AddWithValue("@AttAddress1", AttAddress1);
            command.Parameters.AddWithValue("@AttAddress2", AttAddress2);
            command.Parameters.AddWithValue("@AttCity", AttCity);
            command.Parameters.AddWithValue("@AttFirst", AttFirst);
            command.Parameters.AddWithValue("@AttLast", AttLast);
            command.Parameters.AddWithValue("@AttMiddle", AttMiddle);
            command.Parameters.AddWithValue("@AttPhone1", AttPhone1);
            command.Parameters.AddWithValue("@AttPhone2", AttPhone2);
            command.Parameters.AddWithValue("@AttPhone3", AttPhone3);
            command.Parameters.AddWithValue("@AttState", AttState);
            command.Parameters.AddWithValue("@AttSuffix", AttSuffix);
            command.Parameters.AddWithValue("@AttZip", AttZip);
            command.Parameters.AddWithValue("@BusinessName", BusinessName);
            command.Parameters.AddWithValue("@Child", Child);
            command.Parameters.AddWithValue("@City", City);
            command.Parameters.AddWithValue("@CPhone1", CPhone1);
            command.Parameters.AddWithValue("@CPhone2", CPhone2);
            command.Parameters.AddWithValue("@CPhone3", CPhone3);
            command.Parameters.AddWithValue("@Day", Day);
            command.Parameters.AddWithValue("@Deceased", Deceased);
            command.Parameters.AddWithValue("@EIN", EIN);
            command.Parameters.AddWithValue("@Executor", Executor);
            command.Parameters.AddWithValue("@FirmName", FirmName);
            command.Parameters.AddWithValue("@First", First);
            command.Parameters.AddWithValue("@Last", Last);
            command.Parameters.AddWithValue("@LegallyInCap", LegallyInCap);
            command.Parameters.AddWithValue("@Middle", Middle);
            command.Parameters.AddWithValue("@Minor", Minor);
            command.Parameters.AddWithValue("@Month", Month);
            command.Parameters.AddWithValue("@MY2013", MY2013);
            command.Parameters.AddWithValue("@MY2013NP", MY2013NP);
            command.Parameters.AddWithValue("@MY2014", MY2014);
            command.Parameters.AddWithValue("@MY2014NP", MY2014NP);
            command.Parameters.AddWithValue("@MY2015", MY2015);
            command.Parameters.AddWithValue("@MY2015NP", MY2015NP);
            command.Parameters.AddWithValue("@MY2016", MY2016);
            command.Parameters.AddWithValue("@MY2016NP", MY2016NP);
            command.Parameters.AddWithValue("@MY2017", MY2017);
            command.Parameters.AddWithValue("@MY2017NP", MY2017NP);
            command.Parameters.AddWithValue("@MYAfter2013", MYAfter2013);
            command.Parameters.AddWithValue("@MYAfter2013NP", MYAfter2013NP);
            command.Parameters.AddWithValue("@MYAfter2014", MYAfter2014);
            command.Parameters.AddWithValue("@MYAfter2014NP", MYAfter2014NP);
            command.Parameters.AddWithValue("@MYAfter2015", MYAfter2015);
            command.Parameters.AddWithValue("@MYAfter2015NP", MYAfter2015NP);
            command.Parameters.AddWithValue("@MYAfter2016", MYAfter2016);
            command.Parameters.AddWithValue("@MYAfter2016NP", MYAfter2016NP);
            command.Parameters.AddWithValue("@MYAfter2017", MYAfter2017);
            command.Parameters.AddWithValue("@MYAfter2017NP", MYAfter2017NP);
            command.Parameters.AddWithValue("@MYAfterNP", MYAfterNP);
            command.Parameters.AddWithValue("@MYAfterPerYear", MYAfterPerYear);
            command.Parameters.AddWithValue("@MYAfterTotal", MYAfterTotal);
            command.Parameters.AddWithValue("@MYNP", MYNP);
            command.Parameters.AddWithValue("@MYPerYear", MYPerYear);
            command.Parameters.AddWithValue("@MYSTon2013", MYSTon2013);
            command.Parameters.AddWithValue("@MYSTon2013NP", MYSTon2013NP);
            command.Parameters.AddWithValue("@MYSTon2014", MYSTon2014);
            command.Parameters.AddWithValue("@MYSTon2014NP", MYSTon2014NP);
            command.Parameters.AddWithValue("@MYSTon2015", MYSTon2015);
            command.Parameters.AddWithValue("@MYSTon2015NP", MYSTon2015NP);
            command.Parameters.AddWithValue("@MYSTon2016", MYSTon2016);
            command.Parameters.AddWithValue("@MYSTon2016NP", MYSTon2016NP);
            command.Parameters.AddWithValue("@MYSTon2017", MYSTon2017);
            command.Parameters.AddWithValue("@MYSTon2017NP", MYSTon2017NP);
            command.Parameters.AddWithValue("@MYSTonCapacity", MYSTonCapacity);
            command.Parameters.AddWithValue("@MYSTonCapacityNP", MYSTonCapacityNP);
            command.Parameters.AddWithValue("@MYSTonNP", MYSTonNP);
            command.Parameters.AddWithValue("@MYSTonPerYear", MYSTonPerYear);
            command.Parameters.AddWithValue("@MYSTonTotal", MYSTonTotal);
            command.Parameters.AddWithValue("@MYTotal", MYTotal);
            command.Parameters.AddWithValue("@OptOutInc", OptOutInc);
            command.Parameters.AddWithValue("@OptOutNo", OptOutNo);
            command.Parameters.AddWithValue("@OptOutYes", OptOutYes);
            command.Parameters.AddWithValue("@Parent", Parent);
            command.Parameters.AddWithValue("@RelOther", RelOther);
            command.Parameters.AddWithValue("@RelOtherDesc", RelOtherDesc);
            command.Parameters.AddWithValue("@RepEIN", RepEIN);
            command.Parameters.AddWithValue("@RepFirst", RepFirst);
            command.Parameters.AddWithValue("@RepLast", RepLast);
            command.Parameters.AddWithValue("@RepMiddle", RepMiddle);
            command.Parameters.AddWithValue("@RepOther", RepOther);
            command.Parameters.AddWithValue("@RepOtherDesc", RepOtherDesc);
            command.Parameters.AddWithValue("@RepSSN", RepSSN);
            command.Parameters.AddWithValue("@RepSuffix", RepSuffix);
            command.Parameters.AddWithValue("@RepTaxpayerID", RepTaxpayerID);
            command.Parameters.AddWithValue("@Sibling", Sibling);
            command.Parameters.AddWithValue("@Signature", Signature);
            command.Parameters.AddWithValue("@SignHandWritten", SignHandWritten);
            command.Parameters.AddWithValue("@SignNotProvided", SignNotProvided);
            command.Parameters.AddWithValue("@Spouse", Spouse);
            command.Parameters.AddWithValue("@SSN", SSN);
            command.Parameters.AddWithValue("@StateProvince", StateProvince);
            command.Parameters.AddWithValue("@StreetAddress1", StreetAddress1);
            command.Parameters.AddWithValue("@StreetAddress2", StreetAddress2);
            command.Parameters.AddWithValue("@Suffix", Suffix);
            command.Parameters.AddWithValue("@TaxPayerID", TaxPayerID);
            command.Parameters.AddWithValue("@Year", Year);
            command.Parameters.AddWithValue("@ZipCode", ZipCode);
            db.ManipulateRecord(connectionString, connection, command, query);
        }
    }
}
