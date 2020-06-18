using CornSeedTesting.PageObjects;
using CornSeedTesting.TestSuite;
using QA.Utilities.WebDriverUtils;
using System;
using System.Collections.Generic;

namespace CornSeedTesting.PageActions
{
    public class ClaimantSearchActions 
    {
        WebElementUtil elementUtils;
        public ClaimantSearchActions()
        {
            elementUtils = new WebElementUtil();
        }

        public void ClickClaimantSearch()
        {
            elementUtils.ClickElement(HomePage.ClaimantSearch);
        }
        public Boolean CheckSpecificSearchIsSelected()
        {
            Boolean IsSelected = elementUtils.CheckElementIsSelected(ClaimantSearchPage.SpecificClaimantSearch);
            return IsSelected;
        }

        public List<string> SearchClaimants(string testCase, string searchInput)
        {
            List<string> ColumnData = new List<string>();
            switch (testCase)
            {
                case "ClaimantId":
                    elementUtils.SendKeys(ClaimantSearchPage.ClaimantId, searchInput);
                    elementUtils.ClickElement(ClaimantSearchPage.SearchLink);
                    ColumnData = elementUtils.ReadTableColumnData(ColumnData, ClaimantSearchPage.SearchGrid, ClaimantSearchPage.FirstPart, ClaimantSearchPage.GetTableXPath(1));
                    return ColumnData;

                case "SSN/TIN":
                    elementUtils.SendKeys(ClaimantSearchPage.SSN, searchInput);
                    elementUtils.ClickElement(ClaimantSearchPage.SearchLink);
                    ColumnData = elementUtils.ReadTableColumnData(ColumnData, ClaimantSearchPage.SearchGrid, ClaimantSearchPage.FirstPart, ClaimantSearchPage.GetTableXPath(4));
                    return ColumnData;

                case "LastName":
                    elementUtils.SendKeys(ClaimantSearchPage.LastName, searchInput);
                    elementUtils.ClickElement(ClaimantSearchPage.SearchLink);
                    ColumnData = elementUtils.ReadCurrentPage(ColumnData, ClaimantSearchPage.PageDropDown, ClaimantSearchPage.SearchGrid, ClaimantSearchPage.FirstPart, ClaimantSearchPage.GetTableXPath(2), ClaimantSearchPage.CurrentPageLabel);
                    return ColumnData;

                case "FirstName":
                    elementUtils.SendKeys(ClaimantSearchPage.FirstName, searchInput);
                    elementUtils.ClickElement(ClaimantSearchPage.SearchLink);
                    ColumnData = elementUtils.ReadCurrentPage(ColumnData, ClaimantSearchPage.PageDropDown, ClaimantSearchPage.SearchGrid, ClaimantSearchPage.FirstPart, ClaimantSearchPage.GetTableXPath(2), ClaimantSearchPage.CurrentPageLabel);
                    return ColumnData;

                case "MiddleName":
                    elementUtils.SendKeys(ClaimantSearchPage.MiddleName, searchInput);
                    elementUtils.ClickElement(ClaimantSearchPage.SearchLink);
                    ColumnData = elementUtils.ReadCurrentPage(ColumnData, ClaimantSearchPage.PageDropDown, ClaimantSearchPage.SearchGrid, ClaimantSearchPage.FirstPart, ClaimantSearchPage.GetTableXPath(2), ClaimantSearchPage.CurrentPageLabel);
                    return ColumnData;

                case "BusinessName":
                    elementUtils.SendKeys(ClaimantSearchPage.BusinessName, searchInput);
                    elementUtils.ClickElement(ClaimantSearchPage.SearchLink);
                    ColumnData = elementUtils.ReadCurrentPage(ColumnData, ClaimantSearchPage.PageDropDown, ClaimantSearchPage.SearchGrid, ClaimantSearchPage.FirstPart, ClaimantSearchPage.GetTableXPath(3), ClaimantSearchPage.CurrentPageLabel);
                    return ColumnData;

                case "LawFirm":
                    elementUtils.SendKeys(ClaimantSearchPage.LawFirm, searchInput);
                    elementUtils.ClickElement(ClaimantSearchPage.SearchLink);
                    ColumnData = elementUtils.ReadCurrentPage(ColumnData, ClaimantSearchPage.PageDropDown, ClaimantSearchPage.SearchGrid, ClaimantSearchPage.FirstPart, ClaimantSearchPage.GetTableXPath(7), ClaimantSearchPage.CurrentPageLabel);
                    return ColumnData;

                case "StreetName":
                    elementUtils.SendKeys(ClaimantSearchPage.LastName, searchInput);
                    elementUtils.ClickElement(ClaimantSearchPage.SearchLink);
                    ColumnData = elementUtils.ReadCurrentPage(ColumnData, ClaimantSearchPage.PageDropDown, ClaimantSearchPage.SearchGrid, ClaimantSearchPage.FirstPart, ClaimantSearchPage.GetTableXPath(6), ClaimantSearchPage.CurrentPageLabel);
                    return ColumnData;

                case "ZipCode":
                    elementUtils.SendKeys(ClaimantSearchPage.LastName, searchInput);
                    elementUtils.ClickElement(ClaimantSearchPage.SearchLink);
                    ColumnData = elementUtils.ReadCurrentPage(ColumnData, ClaimantSearchPage.PageDropDown, ClaimantSearchPage.SearchGrid, ClaimantSearchPage.FirstPart, ClaimantSearchPage.GetTableXPath(6), ClaimantSearchPage.CurrentPageLabel);
                    return ColumnData;

                case "ClaimType":
                    elementUtils.SelectDropDownByText(ClaimantSearchPage.ClaimType, searchInput);
                    elementUtils.ClickElement(ClaimantSearchPage.SearchLink);
                    ColumnData = elementUtils.ReadCurrentPage(ColumnData, ClaimantSearchPage.PageDropDown, ClaimantSearchPage.SearchGrid, ClaimantSearchPage.FirstPart, ClaimantSearchPage.GetTableXPath(5), ClaimantSearchPage.CurrentPageLabel);
                    return ColumnData;

                case "ClaimStatus":
                    elementUtils.SelectDropDownByText(ClaimantSearchPage.ClaimStatus, searchInput);
                    elementUtils.ClickElement(ClaimantSearchPage.SearchLink);
                    ColumnData = elementUtils.ReadCurrentPage(ColumnData, ClaimantSearchPage.PageDropDown, ClaimantSearchPage.SearchGrid, ClaimantSearchPage.FirstPart, ClaimantSearchPage.GetTableXPath(9), ClaimantSearchPage.CurrentPageLabel);
                    return ColumnData;

                case "ClaimantStatus":
                    elementUtils.SelectDropDownByText(ClaimantSearchPage.ClaimantStatus, searchInput);
                    elementUtils.ClickElement(ClaimantSearchPage.SearchLink);
                    ColumnData = elementUtils.ReadCurrentPage(ColumnData, ClaimantSearchPage.PageDropDown, ClaimantSearchPage.SearchGrid, ClaimantSearchPage.FirstPart, ClaimantSearchPage.GetTableXPath(8), ClaimantSearchPage.CurrentPageLabel);
                    return ColumnData;
            }
            return ColumnData;
        }

        public void ClickSearch()
        {
            elementUtils.ClickElement(ClaimantSearchPage.SearchLink);
        }

        public void ClickClear()
        {
            elementUtils.ClickElement(ClaimantSearchPage.ClearLink);
        }

        public void SeeAllClaimantSearch()
        {
            elementUtils.SelectCheckBoxOrRadioButton(ClaimantSearchPage.SeeAllClaimantSearch);
        }
    }
}
