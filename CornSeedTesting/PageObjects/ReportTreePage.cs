using OpenQA.Selenium;

namespace CornSeedTesting.PageObjects
{
    public class ReportTreePage
    {
        //Reporting dropdown
        public static By ReportingDropDown = By.XPath("//*[@id=\"ContentPlaceHolder1_ddl_ReportCategories\"]");

        //Report Link
        public static By ReportName = By.XPath("//*[@id=\"ContentPlaceHolder1_lvwReports_btnReportName_0\"]");
        public static By EthanolReport = By.XPath("/html/body/form/div[3]/span/div/table/tbody/tr[4]/td[3]/div/div[1]/div/table/tbody/tr/td/table/tbody/tr/td/table/tbody/tr[2]/td/table/tbody/tr[2]/td[2]/div/div/div[1]/span");

        //Report Grid
        public static By ReportGrid = By.XPath("//*[@id=\"ContentPlaceHolder1_divReports\"]/table/tbody/tr/td/table/tbody/tr");
        public static string firstPart = "//*[@id=\"ContentPlaceHolder1_divReports\"]/table/tbody/tr/td/table/tbody/tr[";
        public static string secondPart = "]/td[";
        public static string thirdPart = "]";

        public static string GetTableXPathRow(int row)
        {
            return firstPart + row + secondPart;
        }
        public static string GetTableXPathColumn(int column)
        {
            return secondPart + column + thirdPart;
        }
    }
}
