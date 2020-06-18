using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using QA.Utilities.TestHelpers;
using NUnit.Framework;
using QA.Utilities.DatabaseConnectivity;
using QA.DataDriven;
using QA.Utilities.WebDriverUtils;
using CornSeedTesting.DataReader;
using CornSeedTesting.PageActions;
using CornSeedTesting.CornSeedDBActions;
using RazorEngine.Compilation.ImpromptuInterface.Dynamic;

namespace CornSeedTesting.TestSuite
{
    [TestFixtureSource(typeof(DeterminationNoticeTest), "OneTimeTestData")]
    public class DeterminationNoticeTest
    {
        private string projectUrl, userid, password, expected;
        UserInitialActions UIActions;
        ReviewActions ReActions;
        ClaimantSearchActions CSActions;
        ClaimantDetailsActions CDActions;
        DeterminationDBActions DDBActions;
        UtilitiesActions UtilActions;
        public DeterminationNoticeTest(string projectUrl, string userid, string password, string expected)
        {
            this.projectUrl = projectUrl;
            this.userid = userid;
            this.password = password;
            this.expected = expected;
            UIActions = new UserInitialActions();
            CSActions = new ClaimantSearchActions();
            CDActions = new ClaimantDetailsActions();
            ReActions = new ReviewActions();
            UtilActions = new UtilitiesActions();
            DDBActions = new DeterminationDBActions(new DatabaseConnectivity(), new DatabaseModel());
        }
        public static string GetFileName()
        {
            IConfiguration settings = TestHelper.GetConfig();
            return settings["TestData:DeterminationTest"];
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
        public void TestClass()
        {
            WebDriverUtil.InitializeBrowser(projectUrl);
            UIActions.Login(userid, password);
        }

        [Test, TestCaseSource(typeof(TestDataRead), "TestSourceData", new object[] { "NewClaimantPL.xlsx", "Claimant" }), Order(1)]
        public void TestDeterminationNoticeData(string testdata, string createType, string docId, string docType, string classType, string searchString, string taxType, string taxID, string firstName, string middleName, string lastName, string suffix, string businessName, string addressType, string address1, string address2, string city, string state, string zipCode, string emailAddress, string confirmEmail, string homePhone, string mobile, string mobileProvider, string commPref, string repClaimant, string repReasonType, string repRelation, string repTaxType, string repTaxID, string repFN, string repMN, string repLN, string repSuffix, string lawFirmYN, string lawFirmName, string cropreport13to17, string cropreportplan, string cropinsurance, string landlordinterest, string nonfsaynid, string f13, string f14, string f15, string f16, string f17, string vipteraYN, string sign)
        {
            string cid = null;
            string parentWindowHandle = null;
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
            ReActions.AddNewClaimForm(docType, classType, searchString);
            parentWindowHandle = WebDriverUtil.GetParentWindowHandle();
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
            UIActions.GoToHome();
            UtilActions.ClickUtilities();
            UtilActions.OpenBulkEventManagement();
            UtilActions.ApplyEventForAClaimant("Events", "Assign", "Name / Tax ID Confirmed", cid);
            UIActions.GoToHome();
            CSActions.ClickClaimantSearch();
            List<string> claimantLink = CSActions.SearchClaimants("ClaimantId", cid);
            CDActions.ClickClaimantID();
            CDActions.ClickEditW9Form();
            CDActions.SwitchToIFrame();
            parentWindowHandle = WebDriverUtil.GetParentWindowHandle();
            CDActions.FillW9Form("C Corporation", "Yes", "Yes", "Anusha");
            UIActions.GoToHomeWithWindowHandle(parentWindowHandle);
        }

    }
}
