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
    [TestFixtureSource(typeof(TestDataRead), "ManualReviewDataEG")]
    public class ManualReviewTestEG
    {
        private string projectUrl, userid, password, reviewType, claimantId, reviewQueueType, claimType;
        UserInitialActions UIActions;
        ReviewActions ReActions;
        ReviewQueueDBActions RqDBActions;
        ReviewQueueActions RqActions;
        ReviewDetailsEGActions RqEGActions;
        Validation Validation;
        List<Acres> acresDB = null;
        Acres acreObj;
        public ManualReviewTestEG(string projectUrl, string userid, string password, string reviewType, string claimantId, string reviewQueueType, string claimType)
        {
            this.projectUrl = projectUrl;
            this.userid = userid;
            this.password = password;
            this.reviewType = reviewType;
            this.claimantId = claimantId;
            this.claimType = claimType;
            this.reviewQueueType = reviewQueueType;
            UIActions = new UserInitialActions();
            ReActions = new ReviewActions();
            RqActions = new ReviewQueueActions();
            RqEGActions = new ReviewDetailsEGActions();
            RqDBActions = new ReviewQueueDBActions(new DatabaseConnectivity());
            Validation = new Validation();
            acreObj = new Acres();
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
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

        [Test]
        public void TestFacilityReview(string claimType, string q2Comment, string q2Answer)
        {
            RqEGActions.FacilityReview(claimType, q2Comment, q2Answer);
        }
    }
}
