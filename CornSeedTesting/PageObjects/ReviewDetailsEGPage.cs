using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace CornSeedTesting.PageObjects
{
    public class ReviewDetailsEGPage
    {
        public static string xPathString;
        //Ethanol facility grid
        public static string FacilityGridRowString = "//*[@id=\"ContentPlaceHolder1_gdFacilityInfo\"]/tbody/tr";
        public static By FacilityGridRow = By.XPath(FacilityGridRowString);
        public static By FacilityGridCol = By.XPath("//*[@id=\"ContentPlaceHolder1_gdFacilityInfo\"]/tbody/tr[1]/td");
        public static By GetFacilityAction(int row)
        {
            xPathString = FacilityGridRowString + "[" + row + "]/td[6]/a";
            return By.XPath(xPathString);
        }
        //Documents section
        public static string DocumentsGridString = "//*[@id=\"ContentPlaceHolder1_HTMLDocTable\"]/tbody/tr[2]/td[1]/table/tbody/tr[1]/td[1]/table/tbody/tr";
        public static By DocumentsGrid = By.XPath(DocumentsGridString);
        public static By DocAction = By.XPath("//*[@id=\"ContentPlaceHolder1_lvDocuments_imgViewDoc_0\"]");
        public static By GetDocumentAction(int count)
        {
            xPathString = "//*[@id=\"ContentPlaceHolder1_lvDocuments_imgViewDoc_" + count + "\"]";
            return By.XPath(xPathString);
        }

        //Facility - Q2
        public static By FacilityQ2 = By.XPath("//*[@name=\"ctl00$ContentPlaceHolder1$rdlSupportingDoc\"]");
        public static By FacilityQ2BullsEye = By.XPath("//*[@id=\"ContentPlaceHolder1_ImgBESupportingDoc_CT\"]");
        //Facility - Q2 Bulls eye pop up
        public static By FacilityQ2Comment = By.XPath("//*[@id=\"ContentPlaceHolder1_ModalPopup_Comments_txtComments\"]");
        public static By FacilityQ2Save = By.XPath("//*[@id=\"ContentPlaceHolder1_ModalPopup_Comments_imgModalPopupOK\"]");
    }
}
