using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Collections.Generic;
using QA.Utilities.WebDriverUtils;
using System.Net;

namespace QA.Utilities.Validations
{
    public class Validation : WebDriverUtil
    {
        public void ValidateScreenByUrl(string ScreenUrl)
        {
            String url = driver.Url;
            Assert.IsTrue(url.SequenceEqual(ScreenUrl));
        }

        public void ValidateTitleOfAPage(string title)
        {
            string pageTitle = driver.Title;
            Assert.IsTrue(title.Equals(pageTitle));
        }

        public void ValidateElementIsPresent(By element)
        {
            IWebElement findElement = driver.FindElement(element);
            Assert.IsTrue(findElement.Displayed);
        }
        public void ValidateTextIsPresent(string expected, By element)
        {
            String actual = driver.FindElement(element).Text;
            Assert.AreEqual(expected, actual);
        }

        public void ValidateColumnData(string expected, List<string> columnData)
        {
            Boolean Match = false;
            foreach (string data in columnData)
            {
                if (columnData.Contains(expected))
                {
                    Match = true;
                }
            }
            Assert.IsTrue(Match);
        }

        public void ValidateTableRowData(List<string> expected, List<string> actual)
        {
            Boolean match = false;
            if (expected.Equals(actual))
                match = true;
            Assert.IsTrue(match);
        }

        public void ValidateDropDownItemIsPresent(By element, String input)
        {
            Boolean IsPresent = false;
            SelectElement dropDown = new SelectElement(driver.FindElement(element));
            IList<IWebElement> options = dropDown.Options;
            for (int i = 0; i < options.Count; i++)
            {
                if (options.ElementAt(i).Text.Trim().Equals(input))
                {
                    IsPresent = true;
                    Assert.IsTrue(IsPresent);
                }
            }
            Assert.IsTrue(IsPresent);
        }

        public void ValidateObjectsAreSame(object object1, object object2)
        {
            bool IsPresent = false;
            if (object1.Equals(object2))
            {
                IsPresent = true;
            }
            Assert.IsTrue(IsPresent);
        }

        public void ValidateStatusCode200(string url)
        {
            Boolean isValid = false;
            CookieCollection cookCol = new CookieCollection();
            System.Net.Cookie netCookie = new System.Net.Cookie();
            System.Collections.ObjectModel.ReadOnlyCollection<OpenQA.Selenium.Cookie> allCookies = driver.Manage().Cookies.AllCookies;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AllowAutoRedirect = false;
            request.CookieContainer = new CookieContainer();

            foreach (OpenQA.Selenium.Cookie selCook in driver.Manage().Cookies.AllCookies)
            {
                netCookie.Name = selCook.Name;
                netCookie.Value = selCook.Value;
                netCookie.Domain = selCook.Domain;
                netCookie.Path = selCook.Path;
                cookCol.Add(netCookie);
                request.CookieContainer.Add(cookCol);
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //response.Cookies = request.CookieContainer.GetCookies(request.RequestUri);
            //if(response.Cookies != null)
            //{
            //    cookCol.Add(response.Cookies);
            //}
            //cookies.Add(cookCol);
            //foreach (System.Net.Cookie cookie in response.Cookies)
            //{
            //    cookCol.Add(response.Cookies);
            //    Console.WriteLine("Cookie:");
            //    Console.WriteLine("{0} = {1}", cookie.Name, cookie.Value);
            //    Console.WriteLine("Domain: {0}", cookie.Domain);
            //    Console.WriteLine("Path: {0}", cookie.Path);
            //    Console.WriteLine("Port: {0}", cookie.Port);
            //    Console.WriteLine("Secure: {0}", cookie.Secure);
            //}

            //cookies.Add(cookCol);
            if (response.StatusCode == HttpStatusCode.OK)
            {

                isValid = true;
                Assert.IsTrue(isValid);
            }
        }

        public void ValidateImage(By element, string expectedImgUrl)
        {
            //  Boolean isPresent = false;
            string actualImgUrl = driver.FindElement(element).GetAttribute("src");
            if (actualImgUrl.Contains(expectedImgUrl))
            {
                Assert.Pass("Test case passed with valid image result.");
            }
            else
            {
                Assert.Fail("Test case failed with invalid image result. View the attached report for details.");
            }
        }
    }
}
