using OpenQA.Selenium;


namespace CornSeedTesting.PageObjects
{
    public class NCBPage
    {
        //Radio buttons
        public static By SpecificSearch = By.Id("ContentPlaceHolder1_rdlSelectSearchType_0");

        //Input fields
        public static By ClaimantId = By.XPath("//*[@id=\"ContentPlaceHolder1_txtClaimantID\"]");
        public static By ClaimType = By.XPath("//*[@id=\"ContentPlaceHolder1_ddlClaimType\"]");
        public static By LastName = By.XPath("//*[@id=\"ContentPlaceHolder1_txtLastName\"]");
        public static By FirstName = By.XPath("//*[@id=\"ContentPlaceHolder1_txtFirstName\"]");
        public static By ReviewResult = By.XPath("//*[@id=\"ContentPlaceHolder1_ddlReviewResult\"]");
        public static By NoticeType = By.XPath("//*[@id=\"ContentPlaceHolder1_ddlNoticeType\"]");
        public static By ProSeBox = By.XPath("//*[@id=\"ContentPlaceHolder1_chkProSe\"]");
        public static By FirmName = By.XPath("//*[@id=\"ContentPlaceHolder1_txtFirmName\"]");

        //Links
        public static By SearchLink = By.XPath("//*[@id=\"ContentPlaceHolder1_btnSearch\"]");

        //Page Labels
        public static By CurrentPageLabel = By.XPath("//*[@id=\"ContentPlaceHolder1_dpNtceSearch_ctl00_CurrentPageLabel\"]");

        //Search Results
        public static By SearchGrid = By.XPath("//table[@class='list-view']/tbody/tr");
        public static string FirstPart = "//table[@class='list-view']/tbody/tr[";
        public static string SecondPart = "]/td[";
        public static string ThirdPart = "]";
        public static string GetTableXPath(int column)
        {
            return SecondPart + column + ThirdPart;
        }
        public static By PageDropDown = By.XPath("//*[@id=\"ContentPlaceHolder1_dpNtceSearch_ctl00_ddlNtceGoTo\"]");
        public static By NoticePager = By.XPath("//*[@id=\"ContentPlaceHolder1_lvSearchResults_SearchNtceDataPager\"]");

        //NCB Options
        public static By NCBOptions = By.Id("ContentPlaceHolder1_ddlNoticeCnrlopti");
        public static By NCBOptionsSubmit = By.Id("ContentPlaceHolder1_btnsubmit");

        //NCBOptions Confirmation
        public static By ConfirmationBox = By.Id("ContentPlaceHolder1_Label5");
        public static By YesElement = By.Id("ContentPlaceHolder1_btnYesInfo");
        public static By PleaseWaitElement = By.Id("ContentPlaceHolder1_btnYestoPlzWait");
        public static By SubmitElement = By.CssSelector("input[type='submit']");

        //Search Results
        public static By FirstCheckbox = By.Id("ContentPlaceHolder1_lvSearchResults_chkSelect_0");
        public static By TableRows = By.CssSelector("tr.row");
    }
}
