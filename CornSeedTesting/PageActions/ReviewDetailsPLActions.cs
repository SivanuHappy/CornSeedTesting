using System;
using System.Collections.Generic;
using CornSeedTesting.Models;
using QA.Utilities.WebDriverUtils;
using CornSeedTesting.PageObjects;
using OpenQA.Selenium;
using System.Linq;

namespace CornSeedTesting.PageActions
{
    public class ReviewDetailsPLActions
    {
        WebElementUtil elementUtils;
        public ReviewDetailsPLActions()
        {
            elementUtils = new WebElementUtil();
        }
        //public void SearchReviewClaimant(string claimantId, string reviewQueueType)
        //{
        //    elementUtils.SendKeys(ReviewQueuePage.ClaimantId, claimantId);
        //    elementUtils.SelectDropDownByText(ReviewQueuePage.ReviewQueueType, reviewQueueType);
        //    elementUtils.ClickElement(ReviewQueuePage.Submit);
        //}
        //public void StartReview()
        //{
        //    elementUtils.ClickElement(ReviewQueuePage.StartReview);
        //}
        //public void CheckOutClaimant(string claimantId)
        //{
        //    int count = 0;
        //    List<string> reviewCIDs = new List<string>();
        //    reviewCIDs = elementUtils.ReadTableColumnData(reviewCIDs, ReviewQueuePage.PendingGridTable, ReviewQueuePage.PendingFirstPart, ReviewQueuePage.GetTableXPathColumnForPendingGrid(4));
        //    foreach (string cid in reviewCIDs)
        //    {
        //        if (claimantId.Equals(cid))
        //        {
        //            elementUtils.ClickElement(ReviewQueuePage.GetXPathForReviewButton(count));
        //            break;
        //        }
        //        count++;
        //    }
        //}
        public void ReviewQ1(string fsaResponse, string rmaResponse)
        {
            elementUtils.SelectRadioButtonByText(ReviewDetailsPLPage.FSAResponseQ1, fsaResponse);
            elementUtils.SelectRadioButtonByText(ReviewDetailsPLPage.RMAResponseQ1, rmaResponse);
        }
        public void SaveProducerReview()
        {
            elementUtils.ClickElement(ReviewDetailsPLPage.SaveButton);
        }
        public List<Acres> GetAcresData(string claimantId)
        {
            int count = 1;
            List<string> sources = new List<string>();
            List<string> acresFromGrid = new List<string>();
            List<Acres> acres = new List<Acres>();
            int size = elementUtils.CountTableRows(ReviewDetailsPLPage.AcresGridRow);
            for (int i = 1; i <= size; i++)
            {
                By xPathSource = ReviewDetailsPLPage.GetAcreSource(i);
                sources.Add(elementUtils.GetTextFromElement(xPathSource));
            }
            foreach (string source in sources)
            {
                if (source.Equals("Claim Form") || source.Equals("FSA") || source.Equals("RMA") || source.Equals("Lease"))
                {
                    By xPathRelevance = ReviewDetailsPLPage.GetAcreRelevance(count);
                    elementUtils.SetElementExistsWait(xPathRelevance);
                    if (elementUtils.GetTextFromElement(xPathRelevance).Equals("Claim Form"))
                    {
                        acresFromGrid = elementUtils.ReadTableRowData(acresFromGrid, ReviewDetailsPLPage.AcresGridCol, ReviewDetailsPLPage.GetTableXPathRowForAcresGrid(count), ReviewDetailsPLPage.AcresGridThirdPart);
                        acres.Add(new Acres() { Source = acresFromGrid[0], Relevance = acresFromGrid[1], FarmNumber = acresFromGrid[2], TractNumber = acresFromGrid[3], FieldNumber = acresFromGrid[4], MarketingYear = acresFromGrid[5], PlantingPrimCode = acresFromGrid[6], CornAcreage = acresFromGrid[7], SharePercentage = acresFromGrid[8], TotalSharePercentage = acresFromGrid[9], AdjSharePercentage = acresFromGrid[10], LinkedClaimantId = acresFromGrid[11] });                      
                        acresFromGrid.Clear();
                    }
                    count++;
                }
            }
            acres.Sort(delegate (Acres x, Acres y)
            {
                if (x.MarketingYear == null && y.MarketingYear == null) return 0;
                else if (x.MarketingYear == null) return -1;
                else if (y.MarketingYear == null) return 1;
                else return x.MarketingYear.CompareTo(y.MarketingYear);
            });
            return acres;
        }
        public List<string> GetDistinctItem(List<Acres> acres)
        {
            List<string> source = new List<string>();
            List<string> distinctSource = new List<string>();
            foreach (Acres acre in acres)
            {
                source.Add(acre.Source);
            }
            IEnumerable<string> distSource = source.Distinct();
            foreach (string item in distSource)
            {
                distinctSource.Add(item);
            }
            return distinctSource;
        }
        public List<Acres> ReviewAcres()
        {
            string sourceAD, relevanceAD, yearAD, farmNumberAD, tractNumberAD, fieldNumberAD, sharePercentageAD, stateAD, countyAD, siloAcreageAD, cornAcreageAD, failedAcreageAD;
            List<Acres> acres = new List<Acres>();
            int rowCount = 1, idCount =0;
            List<string> sources = new List<string>();
            int size = elementUtils.CountTableRows(ReviewDetailsPLPage.AcresGridRow);
            for (int i = 1; i< size; i++)
            {
                By xPathSource = ReviewDetailsPLPage.GetAcreSource(i);
                sources.Add(elementUtils.GetTextFromElement(xPathSource));
            }
            foreach(string source in sources)
            {
                if(source.Equals("Claim Form") || source.Equals("FSA") || source.Equals("RMA") || source.Equals("Lease"))
                {
                    By xPathRelevance = ReviewDetailsPLPage.GetAcreRelevance(rowCount);
                    if (elementUtils.GetTextFromElement(xPathRelevance).Equals("Claim Form"))
                    {
                        //By xPathImg = ReviewDetailsPage.GetAcresReviewImage(count);
                        // if (elementUtils.GetAttributeTitle(xPathImg).Equals("Needs Review"))
                        elementUtils.ClickElement(ReviewDetailsPLPage.GetAcreAction(idCount));
                        sourceAD = elementUtils.GetTextFromElement(ReviewDetailsPLPage.SourceAcreageDetail);
                        relevanceAD = elementUtils.GetTextFromElement(ReviewDetailsPLPage.RelevanceAcreageDetail);
                        yearAD = elementUtils.GetTextFromElement(ReviewDetailsPLPage.YearAcreageDetail);
                        farmNumberAD = elementUtils.GetTextFromElement(ReviewDetailsPLPage.FarmNumberAcreageDetail);
                        tractNumberAD = elementUtils.GetTextFromElement(ReviewDetailsPLPage.TractNumberAcreageDetail);
                        fieldNumberAD = elementUtils.GetTextFromElement(ReviewDetailsPLPage.FieldNumberAcreageDetail);
                        sharePercentageAD = elementUtils.GetTextFromElement(ReviewDetailsPLPage.ShareAcreageDetail);
                        stateAD = elementUtils.GetTextFromElement(ReviewDetailsPLPage.StateAcreageDetail);
                        countyAD = elementUtils.GetTextFromElement(ReviewDetailsPLPage.CountyAcreageDetail);
                        siloAcreageAD = elementUtils.GetTextFromElement(ReviewDetailsPLPage.SiloAcreageDetail);
                        cornAcreageAD = elementUtils.GetTextFromElement(ReviewDetailsPLPage.CornAcreageDetail);
                        failedAcreageAD = elementUtils.GetTextFromElement(ReviewDetailsPLPage.FailedAcreageDetail);
                        acres.Add(new Acres() { Source = sourceAD, Relevance = relevanceAD, MarketingYear = yearAD, FarmNumber = farmNumberAD, TractNumber = tractNumberAD, FieldNumber = fieldNumberAD, SharePercentage = sharePercentageAD, State = stateAD, County = countyAD, SiloAcreage = siloAcreageAD, CornAcreage = cornAcreageAD, FailedAcreage = failedAcreageAD });
                        elementUtils.ClickElement(ReviewDetailsPLPage.CloseAcreageDetail);
                    }
                    rowCount++;
                    idCount++;
                }
            }
            return acres;
        }
        public void ClickSavaAndNext()
        {
            elementUtils.ClickElement(ReviewDetailsPLPage.SaveAndNext);
        }

        //manual review reasons
        //deficiency section
        //q1 scenarios
        //q2 scenarios
        //claim form, overlap(claim form and other acre) - fsa/rma, lease(claim form)
        //Count acres
        //count valid and excluded acres
        //review an acre - accept or reject it
    }
}
