using CornSeedTesting.PageActions;
using NUnit.Framework;
using CornSeedTesting.DataReader;
using QA.Utilities.Validations;
using QA.Utilities.WebDriverUtils;
using QA.Utilities.DatabaseConnectivity;
using QA.DataDriven;
using System.Collections.Generic;
using CornSeedTesting.PageObjects;
using CornSeedTesting.Models;
using Microsoft.Extensions.Configuration;
using QA.Utilities.TestHelpers;

namespace CornSeedTesting.TestSuite
{
    [TestFixtureSource(typeof(SanityTestCases), "OneTimeTestData")]
    public class SanityTestCases
    {
        private string projectUrl, userid, password, expected;
        private readonly IDatabaseConnectivity db;
        UserInitialActions UIActions;
        ReviewActions ReActions;
        ClaimantSearchActions CSActions;
        ClaimantDetailsActions CDActions;
        UtilitiesActions UtilActions;
        ReportActions RActions;
        Validation validation;

        public SanityTestCases(string projectUrl, string userid, string password, string expected)
        {
            this.projectUrl = projectUrl;
            this.userid = userid;
            this.password = password;
            this.expected = expected;
            UIActions = new UserInitialActions();
            CSActions = new ClaimantSearchActions();
            CDActions = new ClaimantDetailsActions();
            RActions = new ReportActions();
            ReActions = new ReviewActions();
            UtilActions = new UtilitiesActions();
            validation = new Validation();
        }
        public static string GetFileName()
        {
            IConfiguration settings = TestHelper.GetConfig();
            return settings["TestData:SanityTest"];
        }
        public static IEnumerable<TestFixtureData> OneTimeTestData
        {
            get
            {
                List<TestFixtureData> TestCaseDataList = TestDataRead.TestFixtureSourceData(TestHelper.TestData() + @"\" + GetFileName(), "Sheet1");
                if (TestCaseDataList != null)
                    foreach (TestFixtureData TestCaseData in TestCaseDataList)
                        yield return TestCaseData;
            }
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            WebDriverUtil.InitializeBrowser(projectUrl);
            UIActions.Login(userid, password);
        }
        [Test, TestCaseSource(typeof(TestDataRead), "TestSourceData", new object[] { "NewClaimantPL.xlsx", "Claimant" }), Order(1)]
        public void TestCreateNewClaimantsForPL(string testdata, string createType, string docId, string docType, string classType, string claimantId, string taxType, string taxID, string firstName, string middleName, string lastName, string suffix, string businessName, string addressType, string address1, string address2, string city, string state, string zipCode, string emailAddress, string confirmEmail, string homePhone, string mobile, string mobileProvider, string commPref, string repClaimant, string repReasonType, string repRelation, string repTaxType, string repTaxID, string repFN, string repMN, string repLN, string repSuffix, string lawFirmYN, string lawFirmName, string cropreport13to17, string cropreportplan, string cropinsurance, string landlordinterest, string nonfsaynid, string f13, string f14, string f15, string f16, string f17, string vipteraYN, string sign)
        {
            string cid = null;
            ReActions.GoToDocCat();
            switch (createType)
            {
                case "GetNext":
                    ReActions.ClickOnGetNext();
                    break;
                case "DocID":
                    ReActions.ClickOnDocLink(docId);
                    break;
            }
            ReActions.AddNewClaimForm(docType, classType, claimantId);
            string parentWindowHandle = WebDriverUtil.GetParentWindowHandle();
            ReActions.SwitchToIFrame();
            ReActions.SetClaimantInfo(taxType, taxID, firstName, middleName, lastName, suffix, businessName, addressType, address1, address2, city, state, zipCode, emailAddress, confirmEmail, homePhone, mobile, mobileProvider, commPref);
            ReActions.SetRepClaimant(repClaimant);
            ReActions.ClickPage1Next();
            cid = ReActions.SaveGenClaimantId();
            ReActions.ClickPage2Next();
            ReActions.CheckRepClaimant(repClaimant, repReasonType, repRelation, repTaxType, repTaxID, repFN, repMN, repLN, repSuffix);
            ReActions.SetLawFirm(lawFirmYN, lawFirmName);
            ReActions.ClickPage3Next();
            ReActions.SetCornReportingInfo(cropreport13to17, cropreportplan, cropinsurance, landlordinterest);
            ReActions.ClickPage4Next();
            if (nonfsaynid.Equals("Y"))
            {
                List<TestCaseData> nonFSAData = ExcelColumnReader.GetAncillaryData(@"\NewClaimantPL.xlsx", "NonFSA", testdata);
                if (nonFSAData != null)
                {
                    foreach (TestCaseData currNonFSA in nonFSAData)
                    {
                        if (classType.Equals("Producer"))
                        {
                            ReActions.SetNonFSAAcresForProducer(currNonFSA.Arguments.GetValue(1).ToString(), currNonFSA.Arguments.GetValue(2).ToString(), currNonFSA.Arguments.GetValue(3).ToString(), currNonFSA.Arguments.GetValue(4).ToString(), currNonFSA.Arguments.GetValue(5).ToString(), currNonFSA.Arguments.GetValue(6).ToString(), currNonFSA.Arguments.GetValue(11).ToString(), currNonFSA.Arguments.GetValue(10).ToString(), currNonFSA.Arguments.GetValue(12).ToString(), currNonFSA.Arguments.GetValue(13).ToString());
                        }
                        else
                        {
                            ReActions.SetNonFSAAcresForLandlord(currNonFSA.Arguments.GetValue(1).ToString(), currNonFSA.Arguments.GetValue(2).ToString(), currNonFSA.Arguments.GetValue(3).ToString(), currNonFSA.Arguments.GetValue(4).ToString(), currNonFSA.Arguments.GetValue(5).ToString(), currNonFSA.Arguments.GetValue(7).ToString(), currNonFSA.Arguments.GetValue(8).ToString(), currNonFSA.Arguments.GetValue(9).ToString(), currNonFSA.Arguments.GetValue(11).ToString(), currNonFSA.Arguments.GetValue(10).ToString(), currNonFSA.Arguments.GetValue(12).ToString(), currNonFSA.Arguments.GetValue(13).ToString());
                        }
                    }
                }
                ReActions.ClickPage5Next();
            }
            else
            {
                ReActions.ClickPage5NextWhenNoNonFSA();
            }
            ReActions.SetFedOnFarmAndViptera(f13, f14, f15, f16, f17, vipteraYN);
            ReActions.ClickPage6Next();
            ReActions.EnterSignAndSubmitClaim(sign);
            ReActions.CheckInIntakeDocument(parentWindowHandle);
        }
        [Test, TestCaseSource(typeof(TestDataRead), "TestSourceData", new object[] { "NewClaimantEG.xlsx", "Claimant" }), Order(2)]
        public void TestCreateNewClaimantsForEG(string testdata, string createType, string docId, string docType, string classType, string claimantId, string taxType, string taxID, string firstName, string middleName, string lastName, string suffix, string businessName, string addressType, string address1, string address2, string city, string state, string zipCode, string emailAddress, string confirmEmail, string homePhone, string mobile, string mobileProvider, string commPref, string lawFirmYN, string lawFirmName, string facilityynid, string sign)
        {
            string cid = null;
            ReActions.GoToDocCat();
            switch (createType)
            {
                case "GetNext":
                    ReActions.ClickOnGetNext();
                    break;
                case "DocID":
                    ReActions.ClickOnDocLink(docId);
                    break;
            }
            ReActions.AddNewClaimForm(docType, classType, claimantId);
            string parentWindowHandle = WebDriverUtil.GetParentWindowHandle();
            ReActions.SwitchToIFrame();
            ReActions.SetClaimantInfo(taxType, taxID, firstName, middleName, lastName, suffix, businessName, addressType, address1, address2, city, state, zipCode, emailAddress, confirmEmail, homePhone, mobile, mobileProvider, commPref);
            ReActions.ClickPage1Next();
            cid = ReActions.SaveGenClaimantId();
            ReActions.ClickPage2Next();
            ReActions.SetLawFirm(lawFirmYN, lawFirmName);
            ReActions.ClickPage3Next();
            if (facilityynid == "Y")
            {
                List<TestCaseData> facilitydata = ExcelColumnReader.GetAncillaryData(@"\NewClaimantEG.xlsx", "Facility", testdata);
                if (facilitydata != null)
                {
                    foreach (TestCaseData currFacilityData in facilitydata)
                    {
                        if (classType.Equals("Ethanol"))
                        {
                            ReActions.SetFacilityInfoForEthanol(currFacilityData.Arguments.GetValue(1).ToString(), currFacilityData.Arguments.GetValue(2).ToString(), currFacilityData.Arguments.GetValue(3).ToString(), currFacilityData.Arguments.GetValue(4).ToString(), currFacilityData.Arguments.GetValue(5).ToString(), currFacilityData.Arguments.GetValue(6).ToString(), currFacilityData.Arguments.GetValue(7).ToString(), currFacilityData.Arguments.GetValue(9).ToString(), currFacilityData.Arguments.GetValue(10).ToString(), currFacilityData.Arguments.GetValue(11).ToString(), currFacilityData.Arguments.GetValue(12).ToString(), currFacilityData.Arguments.GetValue(13).ToString(), currFacilityData.Arguments.GetValue(19).ToString());
                        }
                        else
                        {
                            ReActions.SetFacilityInfoForGrain(currFacilityData.Arguments.GetValue(1).ToString(), currFacilityData.Arguments.GetValue(2).ToString(), currFacilityData.Arguments.GetValue(3).ToString(), currFacilityData.Arguments.GetValue(4).ToString(), currFacilityData.Arguments.GetValue(5).ToString(), currFacilityData.Arguments.GetValue(6).ToString(), currFacilityData.Arguments.GetValue(8).ToString(), currFacilityData.Arguments.GetValue(14).ToString(), currFacilityData.Arguments.GetValue(15).ToString(), currFacilityData.Arguments.GetValue(16).ToString(), currFacilityData.Arguments.GetValue(17).ToString(), currFacilityData.Arguments.GetValue(18).ToString(), currFacilityData.Arguments.GetValue(19).ToString());
                        }
                    }
                }
            }
            ReActions.ClickPage4Next();
            ReActions.EnterSignAndSubmitClaim(sign);
            ReActions.CheckInIntakeDocument(parentWindowHandle);
        }

        [Test, TestCaseSource(typeof(TestDataRead), "TestSourceData", new object[] { "ClaimantDetail.xlsx", "ClaimantBanner" }), Order(3)]
        public void TestClaimantBanner(string testCase, string claimantId)
        {
            CSActions.ClickClaimantSearch();
            List<string> columnValues = CSActions.SearchClaimants(testCase, claimantId);
            CDActions.ClickClaimantID();


        }

        [Test, TestCaseSource(typeof(TestDataRead), "TestSourceData", new object[] { "ClaimantSearchData.xlsx", "ClaimantSearch" }), Order(4)]
        public void TestSearchClaimants(string testCase, string searchInput, string expected)
        {
            CSActions.ClickClaimantSearch();
            List<string> columnValues = CSActions.SearchClaimants(testCase, searchInput);
            validation.ValidateColumnData(expected, columnValues);
        }

        [Test, TestCaseSource(typeof(TestDataRead), "TestSourceData", new object[] { "ClaimantDetail.xlsx", "Documents" }), Order(5)]
        public void TestUploadDocument(string testCase, string claimantId, string docType, string fileType, string uploadMessage)
        {
            CSActions.ClickClaimantSearch();
            CSActions.SearchClaimants(testCase, claimantId);
            CDActions.ClickClaimantID();
            CDActions.ClickDocument();
            CDActions.ClaimantUploadDocument(docType, fileType);
            validation.ValidateTextIsPresent(uploadMessage, ClaimantDetailsPage.UploadMessage);
        }

        [Test, Order(5)]
        public void TestCheckReportUnderGeneral()
        {
            string parentWindowHandle = WebDriverUtil.GetParentWindowHandle();
            RActions.ClickReporting();
            RActions.ClickOnReportByName();
            validation.ValidateScreenByUrl("https://cornseed-nonprod-as.azurewebsites.net/TestWebReview/Secure/Reporting/ReportPage.aspx");
            validation.ValidateTitleOfAPage("Syngenta Cornseed Reporting");
            validation.ValidateTextIsPresent("Ethanol Production Facility Claim Data", ReportTreePage.EthanolReport);
            WebDriverUtil.CloseCurrent();
            WebDriverUtil.SwitchToParentWindow(parentWindowHandle);
        }

        //[Test, Order(6)]
        //public void UploadBlobTest()
        //{
        //    BlobActions.UploadToBlob();
        //}

        [Test, TestCaseSource(typeof(TestDataRead), "TestSourceData", new object[] { "UtilityEventData.xlsx", "EventData" }), Order(7)]
        public void TestApplyEventForClaimant(string process, string action, string eventOrHold, string claimantid)
        {
            UtilActions.ClickUtilities();
            UtilActions.OpenBulkEventManagement();
            UtilActions.ApplyEventForAClaimant(process, action, eventOrHold, claimantid);
        }


        [Test, TestCaseSource(typeof(TestDataRead), "TestSourceData", new object[] { "ClaimantDetail.xlsx", "W-9Edit" }), Order(8)]
        public void TestSubmitW9AcceptedDocument(string testCase, string claimantId, string taxClassification, string taxWithholding, string taxSigned, string taxSignature)
        {
            CSActions.ClickClaimantSearch();
            CSActions.SearchClaimants(testCase, claimantId);
            CDActions.ClickClaimantID();
            CDActions.ClickEditW9Form();
            string parentWindowHandle = WebDriverUtil.GetParentWindowHandle();
            CDActions.SwitchToIFrame();
            CDActions.FillW9Form(taxClassification, taxWithholding, taxSigned, taxSignature);
        }

        [Test, TestCaseSource(typeof(TestDataRead), "TestSourceData", new object[] { "ClaimantDetail.xlsx", "DMIReview" }), Order(9)]
        public void TestSubmitDMIReviewData(string testCase, string searchInput, string repReasonType, string repDocProvide, string repDocSufficient, string repDocType, string eventDesc)
        {
            List<string> eventDescFromGrid = new List<string>();
            CSActions.ClickClaimantSearch();
            CSActions.SearchClaimants(testCase, searchInput);
            CDActions.ClickClaimantID();
            CDActions.ClickDMIReview();
            CDActions.PerformDMIReview(repReasonType, repDocProvide, repDocSufficient, repDocType);
            List<Events> eventData = CDActions.ReadEventGrid();
            foreach (Events anEvent in eventData)
            {
                eventDescFromGrid.Add(anEvent.EventDesc);
            }
            validation.ValidateColumnData(eventDesc, eventDescFromGrid);
        }

        [TearDown]
        public void AfterTest()
        {
            UIActions.GoToHome();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            //UIActions.Logout();
            WebDriverUtil.CloseAll();
        }
    }
}