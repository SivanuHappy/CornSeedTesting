using OpenQA.Selenium;

namespace CornSeedTesting.PageObjects
{
    /*
    Elements in claimant details page
    */
    public class ClaimantDetailsPage
    {
        //Banner fields
        public static By ClaimantId = By.XPath("//*[@id=\"ContentPlaceHolder1_RegBanner_lblClaimantID\"]");

        //Menu Items
        public static By Documents = By.XPath("//*[@id=\"ContentPlaceHolder1_btnDocuments\"]");
        public static By DMIReview = By.XPath("//*[@id=\"ContentPlaceHolder1_btnDMIReview\"]");

        //Documents
        public static By UploadDocument = By.XPath("//*[@id=\"ContentPlaceHolder1_btnUpload\"]");
        public static By DocumentType = By.XPath("//*[@id=\"ContentPlaceHolder1_ucFileUploadControl_ddlDocType\"]");
        public static By ChooseFile = By.XPath("//*[@id=\"ContentPlaceHolder1_ucFileUploadControl_fileUpload\"]");
        public static By Upload = By.XPath("//*[@id=\"ContentPlaceHolder1_ucFileUploadControl_btnUpload\"]");
        public static By UploadMessage = By.XPath("//*[@id=\"ContentPlaceHolder1_lblFileUploadMessage\"]");
        public static By UploadError = By.XPath("//*[@id=\"ContentPlaceHolder1_ucFileUploadControl_lblUploadError\"]");
       
        public static By DocumentGridRow = By.XPath("//*[@id=\"SecViewDocumnets\"]/tbody/tr[2]/td/table/tbody/tr[1]/td/table/tbody/tr");
        public static By DocumentGridCol = By.XPath("//*[@id=\"SecViewDocumnets\"]/tbody/tr[2]/td/table/tbody/tr[1]/td/table/tbody/tr[2]/td");
        public static string DFirstPart = "//*[@id=\"SecViewDocumnets\"]/tbody/tr[2]/td/table/tbody/tr[1]/td/table/tbody/tr[";
        public static string DSecondPart = "]/td[";
        public static string DThirdPart = "]";
        public static By DocLink = By.XPath("//*[@id=\"ContentPlaceHolder1_ucViewDocuments_lvDocuments_lnkCDocID_0\"]");
        public static string GetTableXPathColumnForDoc(int column)
        {
            return DSecondPart + column + DThirdPart;
        }

        public static string GetTableXPathRowForDoc(int row)
        {
            return DFirstPart + row + DSecondPart;
        }
        
        //Events
        public static By EventGridRow = By.XPath("//table[@id=\"ContentPlaceHolder1_gdEvents\"]/tbody/tr");
        public static By EventDetailGridRow = By.XPath("//*[@id=\"ContentPlaceHolder1_gdEventDtls\"]/tbody/tr");
        public static By EventGridCol = By.XPath("//table[@id=\"ContentPlaceHolder1_gdEvents\"]/tbody/tr[2]/td");
        public static By EventDetailGridCol = By.XPath("//*[@id=\"ContentPlaceHolder1_gdEventDtls\"]/tbody/tr[2]/td");
        public static By EventShowAll = By.XPath("//*[@id=\"ContentPlaceHolder1_lnkShowAll\"]");
        public static string EGFirstPart = "//table[@id=\"ContentPlaceHolder1_gdEventDtls\"]/tbody/tr[";
        public static string EFirstPart = "//table[@id=\"ContentPlaceHolder1_gdEvents\"]/tbody/tr[";
        public static string ESecondPart = "]/td[";
        public static string EThirdPart = "]";
        public static By EventGridClose = By.XPath("//*[@id=\"ContentPlaceHolder1_btnCancel\"]");
        //Event grid first part
        public static string GetTableXPathRowForEvent(int row)
        {
            return EFirstPart + row + ESecondPart;
        }

        //Event details grid first part
        public static string GetTableXPathRowForEventDetails(int row)
        {
            return EGFirstPart + row + ESecondPart;
        }

        //Event grid and event details grid second part
        public static string GetTableXPathColumnForEvent(int column)
        {
            return ESecondPart + column + EThirdPart;
        }

        //DMI Review
        public static By RepClaimantReason = By.XPath("//*[@name=\"ctl00$ContentPlaceHolder1$rdl_DMIRepReason\"]");
        public static By RepClaimantDocument = By.XPath("//*[@name=\"ctl00$ContentPlaceHolder1$rdlDMIQn1\"]");
        public static By RepClaimantDocSufficient = By.XPath("//*[@name=\"ctl00$ContentPlaceHolder1$rdlDMIQn2\"]");
        public static By RepDMIDocID = By.XPath("//*[@id=\"ContentPlaceHolder1_ddlDMIDocId\"]");
        public static By RepDMIDocType = By.XPath("//*[@id=\"ContentPlaceHolder1_ddlDMIDocType\"]");
        public static By RepApplyEvent = By.XPath("//*[@id=\"ContentPlaceHolder1_btnDMIEvents\"]");
        public static By RepSaveInfo = By.XPath("//*[@id=\"ContentPlaceHolder1_btnDMISave\"]");
        public static By RepCancel = By.XPath("//*[@id=\"ContentPlaceHolder1_btnDMICancel\"]");
        public static By RepApplyEventPopup = By.XPath("//*[@id=\"ContentPlaceHolder1_btnDMIEventsYes\"]");

        //Edit W-9 form
        public static By EditW9 = By.XPath("//*[@id=\"ContentPlaceHolder1_btnEditW9Form\"]");
        public static By W9TaxClassification = By.XPath("//*[@name=\"ctl00$ContentPlaceHolder1$W9TaxClassificationID\"]");
        public static By W9TaxWithHolding = By.XPath("//*[@name=\"ctl00$ContentPlaceHolder1$rdl_YNIDChkWdhHld\"]");
        public static By W9TaxSigned = By.XPath("//*[@name=\"ctl00$ContentPlaceHolder1$rdl_IsSigned\"]");
        public static By W9Signature = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_Signature\"]");
        public static By W9Submit = By.XPath("//*[@id=\"ContentPlaceHolder1_btnSubmit\"]");
        //W-9 IFrame
        public static By W9IFrame = By.XPath("//*[@id=\"ifPDFViewer\"]");
        public static string frameId = "ifPDFViewer";
    }
}
