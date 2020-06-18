using System;
using System.Collections.Generic;
using System.Text;
using QA.Utilities.WebDriverUtils;
using CornSeedTesting.PageObjects;


namespace CornSeedTesting.PageActions
{
    public class ReviewQueueActions
    {
        WebElementUtil elementUtils;
        public ReviewQueueActions()
        {
            elementUtils = new WebElementUtil();
        }

        public void SearchReviewClaimant(string claimantId, string reviewQueueType)
        {
            elementUtils.SendKeys(ReviewQueuePage.ClaimantId, claimantId);
            elementUtils.SelectDropDownByText(ReviewQueuePage.ReviewQueueType, reviewQueueType);
            elementUtils.ClickElement(ReviewQueuePage.Submit);
        }

        public void StartReview()
        {
            elementUtils.ClickElement(ReviewQueuePage.StartReview);
        }
        public void CheckOutClaimant(string claimantId)
        {
            int count = 0;
            List<string> reviewCIDs = new List<string>();
            reviewCIDs = elementUtils.ReadTableColumnData(reviewCIDs, ReviewQueuePage.PendingGridTable, ReviewQueuePage.PendingFirstPart, ReviewQueuePage.GetTableXPathColumnForPendingGrid(4));
            foreach (string cid in reviewCIDs)
            {
                if (claimantId.Equals(cid))
                {
                    elementUtils.ClickElement(ReviewQueuePage.GetXPathForReviewButton(count));
                    break;
                }
                count++;
            }
        }

    }
}
