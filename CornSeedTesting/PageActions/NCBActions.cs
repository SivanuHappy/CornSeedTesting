using CornSeedTesting.PageObjects;
using QA.Utilities.WebDriverUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CornSeedTesting.PageActions
{
    public class NCBActions : WebDriverUtil
    {
        private WebElementUtil elementUtils;
        public NCBActions(WebElementUtil elementUtils)
        {
            this.elementUtils = elementUtils;
        }
        public void ClickOnNCB()
        {
            elementUtils.ClickElement(HomePage.NoticeControls);
        }

        public List<string> SearchNotices(string testCase, string searchInput)
        {
            List<string> columnData = new List<string>();
            switch (testCase)
            {
                case "ClaimantId":
                    elementUtils.SendKeys(NCBPage.ClaimantId, searchInput);
                    elementUtils.ClickElement(NCBPage.SearchLink);
                    columnData = elementUtils.ReadTableColumnData(columnData, NCBPage.SearchGrid, NCBPage.FirstPart, NCBPage.GetTableXPath(2));
                    return columnData;

                case "ClaimType":
                    string claimType = "";
                    List<string> claimTypeData = new List<string>();
                    elementUtils.SelectDropDownByText(NCBPage.ClaimType, searchInput);
                    elementUtils.ClickElement(NCBPage.SearchLink);
                    columnData = elementUtils.ReadCurrentPage(columnData, NCBPage.PageDropDown, NCBPage.SearchGrid, NCBPage.FirstPart, NCBPage.GetTableXPath(2), NCBPage.CurrentPageLabel);
                    foreach (string data in columnData)
                    {
                        claimType = data.Substring(0, 1);
                        claimTypeData.Add(claimType);
                    }
                    return claimTypeData;

                case "LastName":
                    List<string> lastName = new List<string>();
                    elementUtils.SendKeys(NCBPage.LastName, searchInput);
                    elementUtils.ClickElement(NCBPage.SearchLink);
                    columnData = elementUtils.ReadCurrentPage(columnData, NCBPage.PageDropDown, NCBPage.SearchGrid, NCBPage.FirstPart, NCBPage.GetTableXPath(4), NCBPage.CurrentPageLabel);
                    lastName = elementUtils.NameSplitByComma(columnData, "LastName");
                    return lastName;

                case "FirstName":
                    List<string> firstName = new List<string>();
                    elementUtils.SendKeys(NCBPage.FirstName, searchInput);
                    elementUtils.ClickElement(NCBPage.SearchLink);
                    columnData = elementUtils.ReadCurrentPage(columnData, NCBPage.PageDropDown, NCBPage.SearchGrid, NCBPage.FirstPart, NCBPage.GetTableXPath(4), NCBPage.CurrentPageLabel);
                    firstName = elementUtils.NameSplitByComma(columnData, "FirstName");
                    return firstName;

                case "ReviewResult":
                    elementUtils.SelectDropDownByText(NCBPage.ReviewResult, searchInput);
                    elementUtils.ClickElement(NCBPage.SearchLink);
                    columnData = elementUtils.ReadCurrentPage(columnData, NCBPage.PageDropDown, NCBPage.SearchGrid, NCBPage.FirstPart, NCBPage.GetTableXPath(7), NCBPage.CurrentPageLabel);
                    return columnData;

                case "NoticeType":
                    elementUtils.SelectDropDownByText(NCBPage.NoticeType, searchInput);
                    elementUtils.ClickElement(NCBPage.SearchLink);
                    columnData = elementUtils.ReadCurrentPage(columnData, NCBPage.PageDropDown, NCBPage.SearchGrid, NCBPage.FirstPart, NCBPage.GetTableXPath(6), NCBPage.CurrentPageLabel);
                    return columnData;

                case "Pro Se":
                    elementUtils.SelectCheckBoxOrRadioButton(NCBPage.ProSeBox);
                    elementUtils.ClickElement(NCBPage.SearchLink);
                    columnData = elementUtils.ReadCurrentPage(columnData, NCBPage.PageDropDown, NCBPage.SearchGrid, NCBPage.FirstPart, NCBPage.GetTableXPath(5), NCBPage.CurrentPageLabel);
                    return columnData;

                case "FirmName":
                    elementUtils.SendKeys(NCBPage.FirmName, searchInput);
                    elementUtils.ClickElement(NCBPage.SearchLink);
                    columnData = elementUtils.ReadCurrentPage(columnData, NCBPage.PageDropDown, NCBPage.SearchGrid, NCBPage.FirstPart, NCBPage.GetTableXPath(5), NCBPage.CurrentPageLabel);
                    return columnData;
            }
            return columnData;
        }

        public void NCBOptions(String Option)
        {
            elementUtils.SelectCheckBoxOrRadioButton(NCBPage.FirstCheckbox);
            elementUtils.SelectDropDownByText(NCBPage.NCBOptions, Option);
            elementUtils.ClickElement(NCBPage.NCBOptionsSubmit);
            elementUtils.SetElementExistsWait(NCBPage.ConfirmationBox);
            elementUtils.ClickOnSubmit(NCBPage.SubmitElement);
            elementUtils.SetElementExistsWait(NCBPage.PleaseWaitElement);

            //elementUtils.SetElementExistsWait(NCBPage.PleaseWaitElement);
        }
    }
}
