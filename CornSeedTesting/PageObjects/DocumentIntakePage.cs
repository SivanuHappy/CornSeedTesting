using System;
using OpenQA.Selenium;

namespace CornSeedTesting.PageObjects
{
    public class DocumentIntakePage
    {
        public static By GetNext = By.XPath("//*[@id=\"ContentPlaceHolder1_btnGetNext\"]");

        //Pending Review Queue
        public static By GetDocLink(string docId)
        {
            return By.LinkText(docId);
        }
    }
}
