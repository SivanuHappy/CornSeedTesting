using NUnit.Framework;
using System.Collections.Generic;
using System.Collections;
using QA.DataDriven;
using QA.Utilities.DatabaseConnectivity;
using CornSeedTesting.DataReader;
using CornSeedTesting.CornSeedDBActions;

namespace CornSeedTesting.TestSuite
{
    [TestFixture]
    public class FSARMAResponseTest
    {
        public static Hashtable ht; 
        public static Dictionary<string, List<string>> dicPairs;
        FSARMAActions FRActions = new FSARMAActions(new DatabaseConnectivity(), new DatabaseModel());

        [OneTimeSetUp]
        public void SetTransferDataForResponse()
        {
            ht = new Hashtable();
            dicPairs = new Dictionary<string, List<string>>();
            dicPairs = ExcelColumnReader.GetAncillaryData(@"\FSARMAResponseData.xlsx", "TransferType");
            foreach(KeyValuePair<string, List<string>> dicPair in dicPairs)
            {
                foreach(string value in dicPair.Value)
                {
                    if (ht.ContainsKey(value))
                    {
                        
                    }
                    else
                    {
                        ht.Add(value, FRActions.GetTransferDataID(value));
                    }
                }           
            }           
        }

        [Test, TestCaseSource(typeof(TestDataRead), "TestSourceData", new object[] { "FSARMAResponseData.xlsx", "FSAResponse" }), Order(1)]
        public void InsertIntoResponseTable(string source, string cid, string transfertypeId, string settlementid, string comment, string fname, string mname, string lname, string businessname, string formatname, string bgfirstname, string bgmiddlename, string bglastname, string bgbusinessname, string address1, string address2, string city, string state, string zip, string nametype, string entitytypecode, string year, string stateid, string locationstateabbrev, string countycode, string locationcountyname, string commoditycode, string typecode, string practicecode, string landtypecode, string farmnumber, string tractnumber, string fieldid, string fieldnumber, string landid, string rluid, string cluid, string cropcode, string croptypecode, string cropintendedusecode, string irricode, string plantprimcode, string plantseccode, string plantmulticode, string croplandindicator, string cropfieldrep, string cropdeterim, string lastdatechanged, string customernumber, string businesspartycode, string cropsharepercentage)
        {
            FRActions.InsertIntoResponseTable(source, cid, transfertypeId, dicPairs, ht, comment, fname, mname, lname, businessname, formatname, bgfirstname, bgmiddlename, bglastname, bgbusinessname, address1, address2, city, state, zip, nametype, entitytypecode, year, stateid, locationstateabbrev, countycode, locationcountyname, commoditycode, typecode, practicecode, landtypecode, farmnumber, tractnumber, fieldid, fieldnumber, cropcode, croptypecode, cropintendedusecode, irricode, plantprimcode, plantseccode, plantmulticode, croplandindicator, cropfieldrep, cropdeterim, lastdatechanged, customernumber, businesspartycode, landid, rluid, cluid, cropsharepercentage, settlementid);
        }
    }
}
