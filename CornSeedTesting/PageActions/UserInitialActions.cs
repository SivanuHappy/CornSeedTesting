using CornSeedTesting.PageObjects;
using QA.Utilities.WebDriverUtils;
using System;

namespace CornSeedTesting.PageActions
{
    public class UserInitialActions 
    {
        WebElementUtil elementUtils;
        public UserInitialActions()
        {
            elementUtils = new WebElementUtil();
        }

        public void NavigateToCornSeedInternal()
        {
            //   DriverUtils.NavigateToURL();
        }
        public void Login(String userid, String password)
        {
            elementUtils.ClickElement(LoginPage.LoginUsername);
            elementUtils.SendKeys(LoginPage.LoginUsername, userid);
            elementUtils.ClickElement(LoginPage.LoginPassword);
            elementUtils.SendKeys(LoginPage.LoginPassword, password);
            elementUtils.ClickElement(LoginPage.SubmitButton);
        }

        public void Logout()
        {
            elementUtils.MoveAndClickSubMenuElement(HomePage.MyAccount, HomePage.LogOff);
        }
        public void GoToHome()
        {
            elementUtils.ClickElement(HomePage.Home);
        }

        public void GoToHomeWithWindowHandle(string parentWindowHandle)
        {
            WebDriverUtil.SwitchToParentWindow(parentWindowHandle);
            elementUtils.ClickElement(HomePage.Home);
        }
    }
}
