using OpenQA.Selenium;

namespace CornSeedTesting.PageObjects
{
    public class LoginPage
    {
        //Internal Portal Login Page
        public static By LoginUsername = By.Id("ContentPlaceHolder1_txtUserName");
        public static By LoginPassword = By.Id("ContentPlaceHolder1_txtUserPassword");
        public static By SubmitButton = By.Id("ContentPlaceHolder1_btnSignIn");

        //Invalid login
        public static By InvalidLogin = By.Id("ContentPlaceHolder1_lblErrorMsg");
    }
}

