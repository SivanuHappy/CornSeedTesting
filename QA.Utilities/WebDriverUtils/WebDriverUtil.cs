using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ElementWait = SeleniumExtras.WaitHelpers;
using QA.Utilities.Browsers;
using QA.Utilities.TestHelpers;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Chrome;

namespace QA.Utilities.WebDriverUtils
{
    public class WebDriverUtil
    {
        protected static IWebDriver driver;
        private static string browser = "Chrome";
        public static void InitializeBrowser(string url)
        {
            driver = Browser.InitializeBrowser(driver, browser);
            MaximizeBrowser();
            SetBrowserWait(10);
            Goto(url);
        }
        public static void Goto(string url)
        {
            driver.Url = url;
        }
        public static IWebDriver GetDriver
        {
            get { return driver; }
        }
        public static String GetTitle()
        {
            return driver.Title.ToString();
        }
        public void NavigateToURL(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        public static string GetUrl()
        {
            return driver.Url.ToString();
        }
        public static void SetBrowserWait(int time)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);
        }
        public static void MaximizeBrowser()
        {
            driver.Manage().Window.Maximize();
        }
        public void SetVisibilityOfAllElementsWait(By element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ElementWait.ExpectedConditions.VisibilityOfAllElementsLocatedBy(element));
        }
        public void SetVisibilityOfElement(By element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ElementWait.ExpectedConditions.ElementIsVisible(element));
        }
        public void SetElementExistsWait(By element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            wait.Until(ElementWait.ExpectedConditions.ElementExists(element));
        }
        public void SetInvisibilityOfElementWithText(By element, String value)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50)); ;
            wait.Until(ElementWait.ExpectedConditions.InvisibilityOfElementWithText(element, value));
        }
        public void SetPresenceOfElementLocated(By element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            wait.Until(ElementWait.ExpectedConditions.PresenceOfAllElementsLocatedBy(element));
        }
        public void SetElementClickableWait(By element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            wait.Until(ElementWait.ExpectedConditions.ElementToBeClickable(element));
        }
        public void SetIFrameWait(By element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            wait.Until(ElementWait.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(element));
        }
        public void SetStaleElementWait(By element)
        {
            IWebElement iElement = driver.FindElement(element);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            wait.Until(ElementWait.ExpectedConditions.StalenessOf(iElement));
        }
        public static string Capture(string screenShotName, string projectName)
        {
            string localpath = "";
            try
            {
                ITakesScreenshot ts = (ITakesScreenshot)driver;
                Screenshot screenshot = ts.GetScreenshot();
                string TimeStamp = DateTime.Now.ToString("yyyy-MM-dd-hhmmss");
                // string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                // string screenshotPath = pth.Substring(0, pth.LastIndexOf("bin")) + "\\Defect_Screenshots\\" + screenShotName + "-" + TimeStamp + ".png";
                string screenshotPath = TestHelper.GetScreenshotDir(projectName) + "\\" + screenShotName + "-" + TimeStamp + ".png";
                localpath = new Uri(screenshotPath).LocalPath;
                screenshot.SaveAsFile(localpath);
            }
            catch (Exception e)
            {
                throw (e);
            }
            return localpath;
        }
        /*
        Window handler
        */
        public static string GetParentWindowHandle()
        {
            string parentWindowHandle = driver.CurrentWindowHandle;
            return parentWindowHandle;
        }
        public static void SwitchToParentWindow(string parentWindowHandle)
        {
            driver.SwitchTo().Window(parentWindowHandle);
        }
        public static void SwitchToChildWindow(By element)
        {
            PopupWindowFinder WindowHandler = new PopupWindowFinder(driver);
            string popupWindowHandle = WindowHandler.Click(driver.FindElement(element));
            driver.SwitchTo().Window(popupWindowHandle);
        }
        public static int GetNumberOfWindowHandles()
        {
            ReadOnlyCollection<string> windowHandles = driver.WindowHandles;
            int size = windowHandles.Count;
            return size;
        }
        /*
        Navigation Commands: Back, Forward, Refresh
         */
        public static void GoToPreviousPage()
        {
            driver.Navigate().Back();
        }
        public static void GoToNextPage()
        {
            driver.Navigate().Forward();
        }
        public static void RefreshPage()
        {
            driver.Navigate().Refresh();
        }
        /*
         * Driver close commands
         */
        public static void CloseCurrent()
        {
            driver.Close();
        }
        public static void CloseAll()
        {
            driver.Quit();
        }
        public void GoToiFrame(string id)
        {
            driver.SwitchTo().Frame(id);
        }
        public static object Execute(string script)
        {
            return ((IJavaScriptExecutor)driver).ExecuteScript(script);
        }
    }
}
