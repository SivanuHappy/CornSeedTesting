using NUnit.Framework;
using System;
using System.Collections.Generic;
using CornSeedTesting.PageActions;
using CornSeedTesting.DataReader;
using QA.Utilities.WebDriverUtils;
using QA.Utilities.Validations;
using CornSeedTesting.CornSeedDBActions;
using QA.Utilities.DatabaseConnectivity;
using System.Linq;
using CornSeedTesting.Models;

namespace CornSeedTesting.TestSuite

{
    [TestFixtureSource(typeof(TestDataRead), "ManualReviewData")]
    public class ManualReviewTestPL
    {
        private string projectUrl, userid, password, reviewType, claimantId, reviewQueueType;       
        UserInitialActions UIActions;      
        ReviewActions ReActions;
        ReviewQueueDBActions RqDBActions;
        ReviewQueueActions RqActions;
        ReviewDetailsPLActions RqPLActions;
        Validation Validation;
        List<Acres> acresDB = null;
        Acres acreObj;
        public ManualReviewTestPL(string projectUrl, string userid, string password, string reviewType, string claimantId, string reviewQueueType)
        {
            this.projectUrl = projectUrl;
            this.userid = userid;
            this.password = password;
            this.reviewType = reviewType;
            this.claimantId = claimantId;
            this.reviewQueueType = reviewQueueType;
            UIActions = new UserInitialActions();
            ReActions = new ReviewActions();
            RqActions = new ReviewQueueActions();
            RqPLActions = new ReviewDetailsPLActions();
            RqDBActions = new ReviewQueueDBActions(new DatabaseConnectivity());
            Validation = new Validation();
            acreObj = new Acres();
        }

        [OneTimeSetUp]
        public void TestClass()
        {
            WebDriverUtil.InitializeBrowser(projectUrl);
            UIActions.Login(userid, password);
            ReActions.GoToReview();
            switch (reviewType)
            {
                case "AwaitingQueue":
                    RqActions.SearchReviewClaimant(claimantId, reviewQueueType);
                    RqActions.StartReview();
                    break;
                case "PendingQueue":
                    RqActions.CheckOutClaimant(claimantId);
                    break;
            }
        }

        [Test, Order(1)]
        public void TestAcresGridData()
        {
            List<Acres> acres = RqPLActions.GetAcresData(claimantId);
            List<string> sources = RqPLActions.GetDistinctItem(acres);
            foreach(string source in sources)
            {
                acresDB = RqDBActions.GetAcresFromDB(source, claimantId);

            }
            acresDB.Sort(delegate (Acres x, Acres y)
            {
                if (x.MarketingYear == null && y.MarketingYear == null) return 0;
                else if (x.MarketingYear == null) return -1;
                else if (y.MarketingYear == null) return 1;
                else return x.MarketingYear.CompareTo(y.MarketingYear);
            });
            foreach (Acres acre in acres)
            {
                Console.WriteLine(acre.ToString());
            }
            foreach (Acres acre in acresDB)
            {
                Console.WriteLine(acre.ToString());
            }
            acreObj.FarmAcresAreSame(acres, acresDB);
            acreObj.SharePercentageAreSame(acres, acresDB);
        }
        
        [Test]
        public void TestReviewAcreageDetails()
        {
            List<Acres> acres = RqPLActions.ReviewAcres();
            foreach (Acres acre in acres)
            {
                Console.WriteLine(acre.ToString());
            }
        }

        [Test]
        public void TestAdjAcres()
        {

        }

        [Test]
        public void TestNoticeOfDetermination()
        {

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            WebDriverUtil.CloseAll();
        }
    }
}

