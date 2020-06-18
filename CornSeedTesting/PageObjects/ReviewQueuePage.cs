using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace CornSeedTesting.PageObjects
{
    public class ReviewQueuePage
    {
        public static By ClaimantId = By.XPath("//*[@id=\"ContentPlaceHolder1_txtClaimantId\"]");
        public static By ReviewQueueType = By.XPath("//*[@id=\"ContentPlaceHolder1_ddlReviewQType\"]");
        public static By Submit = By.XPath("//*[@id=\"ContentPlaceHolder1_btnSearch\"]");

        public static By StartReview = By.XPath("//*[@id=\"ContentPlaceHolder1_lvSearchResults_btnreview_0\"]");

        //Pending group grid
        public static By PendingGridTable = By.XPath("//*[@id=\"ContentPlaceHolder1_gdPendingGroup\"]/tbody/tr");
        public static string PendingFirstPart = "//table[@id=\"ContentPlaceHolder1_gdPendingGroup\"]/tbody/tr[";
        public static string PendingSecondPart = "]/td[";
        public static string PendingThirdPart = "]";
        public static string GetTableXPathRowForPendingGrid(int row)
        {
            return PendingFirstPart + row + PendingSecondPart;
        }

        public static string GetTableXPathColumnForPendingGrid(int column)
        {
            return PendingSecondPart + column + PendingThirdPart;
        }

        public static By GetXPathForReviewButton(int row)
        {
            string xPathString =  "//*[@id=\"ContentPlaceHolder1_gdPendingGroup_ImgReview_" + row + "\"]";
            return By.XPath(xPathString);
        }
    }
}
