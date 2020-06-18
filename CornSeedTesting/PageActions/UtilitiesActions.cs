using CornSeedTesting.PageObjects;
using QA.Utilities.WebDriverUtils;
using System;


namespace CornSeedTesting.PageActions
{
    public class UtilitiesActions :  WebDriverUtil
    {
        WebElementUtil elementUtils;
        public UtilitiesActions()
        {
            elementUtils = new WebElementUtil();
        }

        public static int count = 0;
        public static string docId = "";

        public void ClickUtilities()
        {
            elementUtils.SetPresenceOfElementLocated(HomePage.Utilties);
            elementUtils.ClickElement(HomePage.Utilties);
        }
        public void OpenBulkEventManagement()
        {
            elementUtils.ClickElement(UtilitiesPage.BultEventOpen);
        }

        public string GetPageTitle()
        {
            var title = (string)WebDriverUtil.Execute("return document.title");
            return title;
        }

        public void ApplyEventForAClaimant(string process, string action, string eventOrHold, string claimantId)
        {
            elementUtils.SelectDropDownByText(BulkEventManagementPage.Process, process);
            elementUtils.EnableDropdownByJS(BulkEventManagementPage.Action);
            elementUtils.SetStaleElementWait(BulkEventManagementPage.Action);
            elementUtils.SetElementExistsWait(BulkEventManagementPage.Action);
            elementUtils.SelectDropDownByText(BulkEventManagementPage.Action, action);
            elementUtils.SetElementExistsWait(BulkEventManagementPage.EventDate);
            elementUtils.EnableDropdownByJS(BulkEventManagementPage.EventOrHold);
            elementUtils.SelectDropDownByText(BulkEventManagementPage.EventOrHold, eventOrHold);
            elementUtils.SetPresenceOfElementLocated(BulkEventManagementPage.ClaimantId);
            elementUtils.SendKeys(BulkEventManagementPage.ClaimantId, claimantId);
            elementUtils.SendKeys(BulkEventManagementPage.Comment, claimantId);
            elementUtils.SetElementClickableWait(BulkEventManagementPage.Submit);
            elementUtils.ClickElement(BulkEventManagementPage.Submit);
            elementUtils.SetPresenceOfElementLocated(BulkEventManagementPage.PopUpSubmit);
            elementUtils.SetElementClickableWait(BulkEventManagementPage.PopUpSubmit);
            elementUtils.ClickElement(BulkEventManagementPage.PopUpSubmit);
            string message = elementUtils.GetTextFromElement(BulkEventManagementPage.EventMessage);
            Console.WriteLine(message);
            //return message;
        }
    }
}
