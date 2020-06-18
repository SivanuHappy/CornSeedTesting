using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.DevTools.Network;
using OpenQA.Selenium.Chromium;
using WebDriverManager.DriverConfigs.Impl;

namespace QA.Utilities.Browsers
{
    public class Browser
    {
        public static IWebDriver InitializeBrowser(IWebDriver driver, String browser)
        {
            switch(browser)
            {
                case "Chrome":
                   // new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    return driver = new ChromeDriver();
                case "IE":
                    return driver = new InternetExplorerDriver();
                case "Firefox":
                    return driver = new FirefoxDriver();
            }
            return driver;
        }
    }
}
