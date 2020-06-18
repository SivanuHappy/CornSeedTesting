using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace CornSeedTesting.PageObjects
{
    public class BulkEventManagementPage
    {
        public static By Process = By.XPath("//*[@id=\"ContentPlaceHolder1_ddl_BulkProcess\"]");
        public static By Action = By.XPath("//*[@id=\"ContentPlaceHolder1_ddl_Action\"]");
        public static By EventOrHold = By.XPath("//*[@id=\"ContentPlaceHolder1_ddl_EventType\"]");
        public static By EventDate = By.XPath("//*[@id=\"ContentPlaceHolder1_ctl30_txtFromDate\"]");
        public static By ClaimantId = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_ClaimantClaimIDs\"]");
        public static By Comment = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_Comments\"]");
        //Buttons
        public static By Submit = By.XPath("//*[@id=\"ContentPlaceHolder1_img_Submit\"]");
        //Pop-up submit
        public static By PopUpSubmit = By.XPath("//*[@id=\"ContentPlaceHolder1_img_SubmitPop\"]");
        //Message
        public static By EventMessage = By.XPath("//*[@id=\"ContentPlaceHolder1_lblErrormsg\"]");
    }
}
