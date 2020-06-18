using CornSeedTesting.PageObjects;
using QA.Utilities.WebDriverUtils;
using System;
using System.Collections.Generic;


namespace CornSeedTesting.PageActions
{
    public class ReportActions 
    {

        WebElementUtil elementUtils;

        public ReportActions()
        {
            elementUtils = new WebElementUtil();
        }

        public void ClickReporting()
        {
            elementUtils.ClickElement(HomePage.Reporting);
        }

        public List<string> ViewAllReportsUnderCategory(string category)
        {
            List<string> rowData = new List<string>();
            switch (category)
            {
                case "General":
                    elementUtils.SelectDropDownByText(ReportTreePage.ReportingDropDown, category);
                    elementUtils.ReadTableColumnData(rowData, ReportTreePage.ReportGrid, ReportTreePage.firstPart, ReportTreePage.GetTableXPathColumn(2));
                    return rowData;

                case "Confidential":
                    elementUtils.SelectDropDownByText(ReportTreePage.ReportingDropDown, category);
                    elementUtils.ReadTableColumnData(rowData, ReportTreePage.ReportGrid, ReportTreePage.firstPart, ReportTreePage.GetTableXPathColumn(2));
                    return rowData;
            }
            return rowData;
        }

        public void ClickOnReportByName()
        {
            WebDriverUtil.SwitchToChildWindow(ReportTreePage.ReportName);
        }
    }
}
