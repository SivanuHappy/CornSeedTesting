using OpenQA.Selenium;

namespace CornSeedTesting.PageObjects
{
    public class HomePage
    {
        //Home text

        public static By HomeText = By.XPath("//*[@id=\"ContentPlaceHolder1_lblWelcome\"]/b");

        //Menu objects
        public static By Home = By.XPath("/html/body/form/table/tbody/tr[4]/td/table/tbody/tr/td/div[1]/div/table/tbody/tr/td[1]/table/tbody/tr/td[2]/a");
        public static By ClaimantSearch = By.CssSelector("td#ob_emItem_11");
        public static By Reviews = By.XPath("/html/body/form/table/tbody/tr[4]/td/table/tbody/tr/td/div[1]/div/table/tbody/tr/td[3]/table/tbody/tr/td[2]");
        public static By DocCat = By.LinkText("Document Categorization");
        public static By Review = By.LinkText("Review");
        public static By Utilties = By.XPath("/html/body/form/table/tbody/tr[4]/td/table/tbody/tr/td/div[1]/div/table/tbody/tr/td[5]/table/tbody/tr/td[2]");
        public static By Reporting = By.XPath("/html/body/form/table/tbody/tr[4]/td/table/tbody/tr/td/div[1]/div/table/tbody/tr/td[6]/table/tbody/tr/td[2]/a");
        public static By NoticeControls = By.LinkText("Notice Controls");
        public static By MyAccount = By.XPath("/html/body/form/table/tbody/tr[4]/td/table/tbody/tr/td/div[1]/div/table/tbody/tr/td[8]/table/tbody/tr/td[contains(text(), 'My Account')]");
        public static By ChangeCredentials = By.LinkText("Change Credentials");
        public static By LogOff = By.LinkText("Log Off");
    }
}
