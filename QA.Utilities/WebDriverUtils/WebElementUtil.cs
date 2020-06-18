using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using QA.Utilities.TestHelpers;
using ElementWait = SeleniumExtras.WaitHelpers;

namespace QA.Utilities.WebDriverUtils
{
    public class WebElementUtil : WebDriverUtil
    {
        public void ClickElement(By element)
        {
            driver.FindElement(element).Click();
        }

        public void ClickElementByJS(By element)
        {
            IWebElement iElement = driver.FindElement(element);
            ((IJavaScriptExecutor)driver).ExecuteScript("argument[0].click();", iElement);
        }

        public void Clear(By element)
        {
            driver.FindElement(element).Clear();
        }

        public void SendKeys(By element, string keys)
        {
            driver.FindElement(element).Click();
            if (keys != null)
            {
                driver.FindElement(element).SendKeys(keys);
            }
            else
                driver.FindElement(element).SendKeys("");

        }

        public void SendKeysByJS(By element, string text)
        {
            IWebElement iElement = driver.FindElement(element);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].setAttribute('value', arguments[1])", iElement, text);
        }

        public String GetTextFromElement(By element)
        {
            return driver.FindElement(element).Text;
        }

        public Boolean CheckElementIsSelected(By element)
        {
            IWebElement WebElement = driver.FindElement(element);
            if (WebElement.Selected)
            {
                return true;
            }
            return true;
        }

        public Boolean CheckElementExists(By element)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ElementWait.ExpectedConditions.ElementIsVisible(element));
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public void MoveToElement(By element1)
        {
            Actions builder = new Actions(driver);
            builder.MoveToElement(driver.FindElement(element1)).Perform();
        }

        public void MoveAndClickSubMenuElement(By element1, By element2)
        {
            Actions builder = new Actions(driver);
            builder.MoveToElement(driver.FindElement(element1)).Perform();
            builder.MoveToElement(driver.FindElement(element2));
            builder.Click();
            builder.Perform();
        }

        public void SelectCheckBoxOrRadioButton(By element)
        {
            IWebElement WebElement = driver.FindElement(element);
            if (!WebElement.Selected)
            {
                WebElement.Click();
            }
        }
        public void SelectRadioButtonByValue(By element, string value)
        {
            IList<IWebElement> radioButtons = driver.FindElements(element);
            foreach (IWebElement button in radioButtons)
            {
                string item = button.GetAttribute("value");
                if (item.Trim() == value)
                {
                    button.Click();
                    break;
                }
            }
        }

        public void SelectRadioButtonByText(By element, string value)
        {
            IList<IWebElement> radioButtons = driver.FindElements(element);
            foreach (IWebElement button in radioButtons)
            {
                string buttonId = button.GetAttribute("id");
                IWebElement buttonLabel = driver.FindElement(By.CssSelector("label[for=" + buttonId + "]"));
                string item = buttonLabel.Text;
                if (item.Trim() == value)
                {
                    button.Click();
                    break;
                }
            }
        }

        public void SelectDropDownByText(By element, string input)
        {
            SelectElement dropDown = new SelectElement(driver.FindElement(element));
            if (input != null)
            {
                dropDown.SelectByText(input);
            }
            else
                dropDown.SelectByValue("0");
        }

        public void SelectDropDownByJS(By element, string text)
        {
            SelectElement select = new SelectElement(driver.FindElement(element));
            ((IJavaScriptExecutor)driver).ExecuteScript("var select = arguments[0]; for(var i = 0; i < select.options.length; i++){ if(select.options[i].text == arguments[1]){ select.options[i].selected = true; } }", select, text);
        }

        public void EnableDropdownByJS(By element)
        {
            SelectElement select = new SelectElement(driver.FindElement(element));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].removeAttribute('disabled'); arguments[0].removeAttribute('class')", select);
        }

        public void ClickOnSubmit(By element)
        {
            IList<IWebElement> SubmitElements = driver.FindElements(element);
            foreach (IWebElement submit in SubmitElements)
            {
                string item = submit.GetAttribute("value");
                if (item.Trim() == "Yes")
                {
                    submit.Click();
                    break;
                }
            }
        }

        public int CountTableRows(By element)
        {
            IList<IWebElement> TableRows = driver.FindElements(element);
            int count = TableRows.Count;
            return count;
        }

        public List<string> ReadTableRowData(List<string> ColumnData, By Table, string FirstPart, string SecondPart)
        {
            int size = CountTableRows(Table);
            for (int i = 1; i <= size; i++)
            {
                string ColumnXPath = FirstPart + i + SecondPart;
                By XPath = By.XPath(ColumnXPath);
                string CellValue = driver.FindElement(XPath).Text;
                ColumnData.Add(CellValue);
            }
            return ColumnData;
        }

        public List<string> ReadTableColumnData(List<string> ColumnData, By Table, string FirstPart, string SecondPart)
        {
            int size = CountTableRows(Table);
            for (int i = 2; i <= size; i++)
            {
                string ColumnXPath = FirstPart + i + SecondPart;
                By XPath = By.XPath(ColumnXPath);
                string CellValue = driver.FindElement(XPath).Text;
                ColumnData.Add(CellValue);
            }
            return ColumnData;
        }

        public List<string> ReadCurrentPage(List<string> ColumnData, By Element, By Table, String FirstPart, String SecondPart, By PageLabel)
        {
            ColumnData = ReadTableColumnData(ColumnData, Table, FirstPart, SecondPart);
            if (CheckElementExists(Element))
                GoToNextPageAndReadColumnData(ColumnData, Element, Table, FirstPart, SecondPart, PageLabel);
            return ColumnData;
        }

        public List<string> GoToNextPageAndReadColumnData(List<string> ColumnData, By element, By Table, String FirstPart, String SecondPart, By PageLabel)
        {
            SelectElement PageElement = new SelectElement(driver.FindElement(element));
            List<String> PageNumbers = new List<String>();
            IList<IWebElement> PageNumberItems = PageElement.Options;
            foreach (IWebElement PageNumber in PageNumberItems)
            {
                PageNumbers.Add(PageNumber.Text);
            }
            for (int i = 1; i < PageNumbers.Count; i++)
            {
                string value = GetTextFromElement(PageLabel);
                SetElementExistsWait(element);
                SelectElement PageElement1 = new SelectElement(driver.FindElement(element));
                PageElement1.SelectByText(PageNumbers[i]);
                SetInvisibilityOfElementWithText(PageLabel, value);
                ColumnData = ReadTableColumnData(ColumnData, Table, FirstPart, SecondPart);
            }
            return ColumnData;
        }

        public void UploadPDFDocument(By element1, By element2, string FileType)
        {
            IWebElement webElement1 = driver.FindElement(element1);
            switch (FileType)
            {
                case "PDF":
                    //SendKeys(element1, TestHelper.TestData() + @"\\test_data.pdf");
                    driver.FindElement(element1).SendKeys(TestHelper.TestData() + @"\\test_data.pdf");
                    ClickElement(element2);
                    break;
            }
        }

        public void UploadDocument(By element1, By element2, string FileType)
        {
            IWebElement webElement1 = driver.FindElement(element1);
            switch (FileType)
            {
                case "PDF":
                    driver.FindElement(element1).SendKeys(TestHelper.TestData() + @"\\test_data.pdf");
                    ClickElement(element2);
                    break;
                case "Text":
                    driver.FindElement(element1).SendKeys(TestHelper.TestData() + @"\\claimants500.txt");
                    ClickElement(element2);
                    break;
                case "WordDoc":
                    driver.FindElement(element1).SendKeys(TestHelper.TestData() + @"\\testdoc.doc");
                    ClickElement(element2);
                    break;
                case "WordDocx":
                    driver.FindElement(element1).SendKeys(TestHelper.TestData() + @"\\testdocx.docx");
                    ClickElement(element2);
                    break;
                case "PNG":
                    driver.FindElement(element1).SendKeys(TestHelper.TestData() + @"\\testpng.png");
                    ClickElement(element2);
                    break;
                case "GIF":
                    driver.FindElement(element1).SendKeys(TestHelper.TestData() + @"\\testgif.gif");
                    ClickElement(element2);
                    break;
                case "TIFF":
                    driver.FindElement(element1).SendKeys(TestHelper.TestData() + @"\\testpng.png");
                    ClickElement(element2);
                    break;
                case "JPEG":
                    driver.FindElement(element1).SendKeys(TestHelper.TestData() + @"\\testjpeg.jpg");
                    ClickElement(element2);
                    break;
                case "Excel":
                    driver.FindElement(element1).SendKeys(TestHelper.TestData() + @"\\testexcel.xlsx");
                    ClickElement(element2);
                    break;
            }
        }

        public void SwitchWindow(By element)
        {
            PopupWindowFinder WindowHandler = new PopupWindowFinder(driver);
            string popupWindowHandle = WindowHandler.Click(driver.FindElement(element));
            driver.SwitchTo().Window(popupWindowHandle);
        }

        public List<string> NameSplitByComma(List<string> names, string namePart)
        {
            List<string> splitedNames = new List<string>();
            string[] splitString = { };
            char[] delimiterChars = { ',' };
            if (namePart.Equals("FirstName"))
            {
                foreach (string name in names)
                {
                    splitString = name.Split(delimiterChars);
                    for (int i = 1; i < splitString.Length; i++)
                        splitedNames.Add(splitString[i].Trim());
                }
                return splitedNames;

            }
            else
            {
                foreach (string name in names)
                {
                    splitString = name.Split(delimiterChars);
                    for (int i = 0; i < splitString.Length - 1; i++)
                        splitedNames.Add(splitString[0].Trim());
                }
                return splitedNames;
            }
        }

        public string GetAttributeSource(By element)
        {
            string val = driver.FindElement(element).GetAttribute("src");
            return val;
        }

        public string GetAttributeTitle(By element)
        {
            string val = driver.FindElement(element).GetAttribute("title");
            return val;
        }
    }
}
