using NUnit.Framework;
using QA.Utilities.DatabaseConnectivity;
using CornSeedTesting.DataReader;
using CornSeedTesting.CornSeedDBActions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.Extensions.Configuration;
using QA.Utilities.TestHelpers;
using System.Collections.Generic;


namespace CornSeedTesting.TestSuite
{
    [TestFixtureSource(typeof(DeterminationNoticeDBTest), "OneTimeTestData")]
    public class DeterminationNoticeDBTest
    {
        DeterminationDBActions DDBActions;
        private string claimantId;
        public DeterminationNoticeDBTest(string claimantId)
        {
            DDBActions = new DeterminationDBActions(new DatabaseConnectivity(), new DatabaseModel());
            this.claimantId = claimantId;
        }
        public static string GetFileName()
        {
            IConfiguration settings = TestHelper.GetConfig();
            return settings["TestData:DeterminationDBTest"];
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
        [TestCase(TestName = "CheckEvents")]
        public void CheckEvents()
        {
            int taxidrowsAffected = DDBActions.CheckClaimantHasTaxIDConfirmedEvent(claimantId);
            int w9acceptedrowsAffected = DDBActions.CheckClaimantHasW9AcceptedEvent(claimantId);
            Assert.AreEqual(taxidrowsAffected, 1);
            Assert.AreEqual(w9acceptedrowsAffected, 1);
        }

        [TestCase(TestName = "UpdateDate")]
        public void TestUpdateDeadlineDate()
        {
            DDBActions.UpdateDeadlineResponseDate(claimantId);
           //DDBActions.UpdateDocumentUpdateDate(claimantId);
        }
    }
}
