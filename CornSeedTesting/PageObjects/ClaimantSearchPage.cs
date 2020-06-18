using OpenQA.Selenium;


namespace CornSeedTesting.PageObjects
{
    public class ClaimantSearchPage
    {
        //Claimant Search Title
        public static By ClaimantSearchTitle = By.XPath("//*[@id=\"lblHeader\"]");

        //Radio button
        public static By SpecificClaimantSearch = By.Id("ContentPlaceHolder1_rdlSelectSearchType_0");
        public static By SeeAllClaimantSearch = By.Id("ContentPlaceHolder1_rdlSelectSearchType_1");

        //Input fields
        public static By ClaimantId = By.Id("ContentPlaceHolder1_txt_ClaimantID");
        public static By SSN = By.Id("ContentPlaceHolder1_txt_TaxpayerID");
        public static By LastName = By.Id("ContentPlaceHolder1_txt_LastName");
        public static By FirstName = By.Id("ContentPlaceHolder1_txt_FirstName");
        public static By MiddleName = By.Id("ContentPlaceHolder1_txt_MiddleName");
        public static By BusinessName = By.Id("ContentPlaceHolder1_txt_BusinessName");
        public static By LawFirm = By.Id("ContentPlaceHolder1_txt_LawFirm");
        public static By StreetName = By.Id("ContentPlaceHolder1_txt_StreetName");
        public static By ZipCode = By.Id("ContentPlaceHolder1_txt_ZipCode");
        public static By ClaimType = By.Id("ContentPlaceHolder1_ddl_ClaimType");
        public static By ClaimStatus = By.Id("ContentPlaceHolder1_ddl_ClaimStatus");
        public static By ClaimantStatus = By.Id("ContentPlaceHolder1_ddl_ClaimantStatus");

        //Links
        public static By SearchLink = By.LinkText("Search");
        public static By ClearLink = By.LinkText("Clear");
        public static By ClaimantLink = By.Id("ContentPlaceHolder1_lvSearchResults_lblClaimantID_0");

        //Page Labels
        public static By CurrentPageLabel = By.Id("ContentPlaceHolder1_dpSearchResults_ctl00_CurrentPageLabel");

        //Search results
        public static By SpecificSearchResults = By.Id("ContentPlaceHolder1_dpSearchResults_ctl00_TotalItemsLabel");
        public static By SeeAllSearchResults = By.Id("ContentPlaceHolder1_lblSearchResults");
        public static By SearchGrid = By.XPath("//table[@class='list-view']/tbody/tr");
        public static string FirstPart = "//table[@class='list-view']/tbody/tr[";
        public static string SecondPart = "]/td[";
        public static string ThirdPart = "]";
        public static By PageDropDown = By.Id("ContentPlaceHolder1_dpSearchResults_ctl00_ddlGoTo");
        public static string GetTableXPath(int column)
        {
            return SecondPart + column + ThirdPart;
        }

        //Error messages
        public static By AtleastOneCriteria = By.XPath("//*[@id=\"ContentPlaceHolder1_lblErrorMessage\"]");
    }
}
