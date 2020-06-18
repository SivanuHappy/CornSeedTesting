using CornSeedTesting.PageObjects;
using QA.Utilities.WebDriverUtils;
using QA.Utilities.DatabaseConnectivity;
using System.Collections.Generic;

namespace CornSeedTesting.PageActions
{
    public class ReviewActions : WebDriverUtil
    {
        WebElementUtil elementUtils;
        private readonly IDatabaseConnectivity db;
        public static string ClaimantId, docId;

        public ReviewActions()
        {
            elementUtils = new WebElementUtil();
        }

        public void GoToDocCat()
        {
            elementUtils.MoveAndClickSubMenuElement(HomePage.Reviews, HomePage.DocCat);
        }

        public void GoToReview()
        {
            elementUtils.MoveAndClickSubMenuElement(HomePage.Reviews, HomePage.Review);
        }

        public void ClickOnGetNext()
        {
            elementUtils.ClickElement(DocumentIntakePage.GetNext);
            docId = elementUtils.GetTextFromElement(DocumentIntakeDetailsPage.DocId);
        }

        public void ClickOnDocLink(string docId)
        {            
           elementUtils.ClickElement(DocumentIntakePage.GetDocLink(docId));
        }

        public void AddNewClaimForm(string docType, string classType, string claimantId)
        {
             //string docId = elementUtils.GetTextFromElement(DocumentIntakeDetailsPage.DocId);
            elementUtils.SelectDropDownByText(DocumentIntakeDetailsPage.ClassMemberType, classType);
            elementUtils.SelectDropDownByText(DocumentIntakeDetailsPage.DocType, docType);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.SearchClaimantId, claimantId);
            elementUtils.SetElementClickableWait(DocumentIntakeDetailsPage.Search);
            elementUtils.ClickElement(DocumentIntakeDetailsPage.Search);
            elementUtils.ClickElement(DocumentIntakeDetailsPage.AddNewClaimant);
            // return docId;
        }

        public void LinkHardCopyDoc(string docType, string classType, string claimantId)
        {
            elementUtils.SelectDropDownByText(DocumentIntakeDetailsPage.ClassMemberType, classType);
            elementUtils.SelectDropDownByText(DocumentIntakeDetailsPage.DocType, docType);          
            elementUtils.SendKeys(DocumentIntakeDetailsPage.SearchClaimantId, claimantId);
            elementUtils.SetElementClickableWait(DocumentIntakeDetailsPage.Search);
            elementUtils.ClickElement(DocumentIntakeDetailsPage.Search);
            elementUtils.ClickElement(DocumentIntakeDetailsPage.DocLink);           
        }

        public void FillW9Form(string claimantId, string taxClassification, string taxWithholding, string taxSigned)
        {
            string query = "select c.settlementid, c.claimantid, " +
                "pii.taxpayertypeid, pii.taxpayerid " +                
                "from tblclaimant c " +
                "join tblpiidata pii on pii.foreignkeyid = c.claimantid and pii.foreignkeyrefid = 1 " +      
                "where c.settlementid =  @claimantId";
            //List<string> claimantdetails = db.GetClaimantDetails();
            //elementUtils.SelectRadioButtonByText(DocumentIntakeDetailsPage.W9TaxClassification, taxClassification);
            //elementUtils.SelectRadioButtonByValue(DocumentIntakeDetailsPage.W9TaxtypeId, claimantdetails[2]);
            //elementUtils.SendKeys(DocumentIntakeDetailsPage.W9TaxId, claimantdetails[3]);
            //elementUtils.SelectRadioButtonByText(DocumentIntakeDetailsPage.W9TaxWithHolding, taxWithholding);
            //elementUtils.SelectRadioButtonByText(DocumentIntakeDetailsPage.W9Signed, taxSigned);
            //elementUtils.ClickElement(DocumentIntakeDetailsPage.W9Submit);          
        }

        public void SwitchToIFrame()
        {
           // elementUtils.SetIFrameWait(DocumentIntakeDetailsPage.CFIFrame);
            elementUtils.GoToiFrame(DocumentIntakeDetailsPage.frameId);
        }

        public void SetClaimantInfo(string taxType, string taxID, string firstName, string middleName, string lastName, string suffix, string businessName, string addressType, string address1, string address2, string city, string state, string zipCode, string emailAddress, string confirmEmailAddress, string homePhone, string mobilePhone, string mobileProvider, string communicatePref)
        {
            elementUtils.SelectRadioButtonByValue(DocumentIntakeDetailsPage.TaxType, taxType);
            if (taxType.Equals("1"))
            {
                elementUtils.SetStaleElementWait(DocumentIntakeDetailsPage.TaxNumberSSN);
                elementUtils.SetElementExistsWait(DocumentIntakeDetailsPage.TaxNumberSSN);
                elementUtils.SendKeys(DocumentIntakeDetailsPage.TaxNumberSSN, taxID);
            }
            else
            {
                elementUtils.SetStaleElementWait(DocumentIntakeDetailsPage.TaxNumberEIN);
                elementUtils.SetElementExistsWait(DocumentIntakeDetailsPage.TaxNumberEIN);
                elementUtils.SendKeys(DocumentIntakeDetailsPage.TaxNumberEIN, taxID);
            }
            elementUtils.SendKeys(DocumentIntakeDetailsPage.FirstName, firstName);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.MiddleName, middleName);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.LastName, lastName);
            elementUtils.SelectDropDownByText(DocumentIntakeDetailsPage.Suffix, suffix);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.BusinessName, businessName);
            elementUtils.SelectRadioButtonByValue(DocumentIntakeDetailsPage.AddressType, addressType);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.Address1, address1);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.Address2, address2);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.City, city);
            elementUtils.SelectDropDownByText(DocumentIntakeDetailsPage.State, state);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.ZipCode, zipCode);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.EmailAddress, emailAddress);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.CEmailAddress, confirmEmailAddress);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.HomePhone, homePhone);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.Mobile, mobilePhone);
            elementUtils.SelectDropDownByText(DocumentIntakeDetailsPage.MobileProvider, mobileProvider);
            elementUtils.SelectRadioButtonByValue(DocumentIntakeDetailsPage.CommPref, communicatePref);
        }

        public void SetRepClaimant(string repClaimant)
        {
            elementUtils.SelectRadioButtonByValue(DocumentIntakeDetailsPage.RepClaimant, repClaimant);
        }
        public void SetFSAConsent(string FSAConsent)
        {
            elementUtils.SelectCheckBoxOrRadioButton(DocumentIntakeDetailsPage.FSAConsent);
        }
        public void ClickPage1Next()
        {
            elementUtils.ClickElement(DocumentIntakeDetailsPage.Page1SaveAndNext);
        }
        public string SaveGenClaimantId()
        {

            string cidText = elementUtils.GetTextFromElement(DocumentIntakeDetailsPage.ClaimantId);
            ClaimantId = cidText.Substring(20, 11);
            return ClaimantId;
        }

        public void ClickPage2Next()
        {
            elementUtils.ClickElement(DocumentIntakeDetailsPage.Page2SaveAndNext);
        }

        public void CheckRepClaimant(string repClaimant, string repReasonType, string repRelation, string repTaxType, string repTaxID, string repFN, string repMN, string repLN, string repSuffix)
        {
            if (repClaimant.Equals("1"))
            {
                elementUtils.SelectRadioButtonByText(DocumentIntakeDetailsPage.RepReasonType, repReasonType);
                elementUtils.SelectRadioButtonByText(DocumentIntakeDetailsPage.RepRelationshipType, repRelation);
                elementUtils.SelectRadioButtonByValue(DocumentIntakeDetailsPage.RepTaxType, repTaxType);
                if (repTaxType.Equals("1"))
                {
                  //  elementUtils.SetStaleElementWait(DocumentIntakeDetailsPage.RepSSN);
                    elementUtils.SetElementExistsWait(DocumentIntakeDetailsPage.RepSSN);
                    elementUtils.SendKeys(DocumentIntakeDetailsPage.RepSSN, repTaxID);
                }
                else
                {
                   // elementUtils.SetStaleElementWait(DocumentIntakeDetailsPage.RepEIN);
                    elementUtils.SetElementExistsWait(DocumentIntakeDetailsPage.RepEIN);
                    elementUtils.SendKeys(DocumentIntakeDetailsPage.RepEIN, repTaxID);
                }
                elementUtils.SendKeys(DocumentIntakeDetailsPage.RepFirstName, repFN);
                elementUtils.SendKeys(DocumentIntakeDetailsPage.RepMiddleName, repMN);
                elementUtils.SendKeys(DocumentIntakeDetailsPage.RepLastName, repLN);
                elementUtils.SelectDropDownByText(DocumentIntakeDetailsPage.RepSuffix, repSuffix);
                elementUtils.ClickElement(DocumentIntakeDetailsPage.RepSaveAndNext);
            }

        }

        public void SetLawFirm(string lawFirmyn, string lawfirmname)
        {
            elementUtils.SelectRadioButtonByValue(DocumentIntakeDetailsPage.LawFirm, lawFirmyn);
            if(lawFirmyn.Equals("1"))
            {
               // elementUtils.SetElementExistsWait(DocumentIntakeDetailsPage.LawFirmName);
               // elementUtils.SetStaleElementWait(DocumentIntakeDetailsPage.LawFirmName);
                elementUtils.SetElementExistsWait(DocumentIntakeDetailsPage.LawFirmName);
                elementUtils.SelectDropDownByText(DocumentIntakeDetailsPage.LawFirmName, lawfirmname);
            }
        }

        public void ClickPage3Next()
        {
            elementUtils.SetElementClickableWait(DocumentIntakeDetailsPage.Page3SaveAndNext);
            elementUtils.ClickElement(DocumentIntakeDetailsPage.Page3SaveAndNext);
        }


        public void SetCornReportingInfo(string cropreport13to17, string cropreportplan, string cropinsurance, string landlordinterest)
        {
            elementUtils.SelectRadioButtonByValue(DocumentIntakeDetailsPage.CropReport13To17, cropreport13to17);
            elementUtils.SelectRadioButtonByValue(DocumentIntakeDetailsPage.CropReportPlan, cropreportplan);
            elementUtils.SelectRadioButtonByValue(DocumentIntakeDetailsPage.CropInsurance, cropinsurance);
            elementUtils.SelectRadioButtonByValue(DocumentIntakeDetailsPage.LandlordInterest, landlordinterest);
        }

        public void SetFacilityInfoForEthanol(string facilityType, string facilityName, string facilityAddr, string facilityCity, string facilityState, string facilityZip, string totalthroughput, string shorttons13, string shorttons14, string shorttons15, string shorttons16, string shorttons17, string facilityownership)
        {
            elementUtils.ClickElement(DocumentIntakeDetailsPage.NewFacility);
            elementUtils.SelectDropDownByText(DocumentIntakeDetailsPage.FacilityType, facilityType);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.FacilityName, facilityName);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.FacilityAddress, facilityAddr);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.FacilityCity, facilityCity);
            elementUtils.SelectDropDownByText(DocumentIntakeDetailsPage.FacilityState, facilityState);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.FacilityZip, facilityZip);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.EthanolTotalThroughput, totalthroughput);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.EShortTonDDGs13, shorttons13);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.EShortTonDDGs14, shorttons14);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.EShortTonDDGs15, shorttons15);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.EShortTonDDGs16, shorttons16);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.EShortTonDDGs17, shorttons17);
            elementUtils.ClickElement(DocumentIntakeDetailsPage.SaveFacility);
            elementUtils.SelectRadioButtonByValue(DocumentIntakeDetailsPage.FacilityOwning, facilityownership);
            elementUtils.ClickElement(DocumentIntakeDetailsPage.DoneFacility);
        }

        public void SetFacilityInfoForGrain(string facilityType, string facilityName, string facilityAddr, string facilityCity, string facilityState, string facilityZip, string storagecapacity, string bushels13, string bushels14, string bushels15, string bushels16, string bushels17, string facilityownership)
        {
            elementUtils.ClickElement(DocumentIntakeDetailsPage.NewFacility);
            elementUtils.SelectDropDownByText(DocumentIntakeDetailsPage.FacilityType, facilityType);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.FacilityName, facilityName);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.FacilityAddress, facilityAddr);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.FacilityCity, facilityCity);
            elementUtils.SelectDropDownByText(DocumentIntakeDetailsPage.FacilityState, facilityState);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.FacilityZip, facilityZip);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.GrainStorageCapacity, storagecapacity);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.GBushels13, bushels13);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.GBushels14, bushels14);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.GBushels15, bushels15);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.GBushels16, bushels16);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.GBushels17, bushels17);
            elementUtils.ClickElement(DocumentIntakeDetailsPage.SaveFacility);
            elementUtils.SelectRadioButtonByValue(DocumentIntakeDetailsPage.FacilityOwning, facilityownership);
            elementUtils.ClickElement(DocumentIntakeDetailsPage.DoneFacility);
        }

        public void ClickPage4Next()
        {
            elementUtils.ClickElement(DocumentIntakeDetailsPage.Page4SaveAndNext);
        }
        public void SetNonFSAAcresForProducer(string myear, string farmnum, string tractnum, string fieldnum, string cornacreage, string producershare, string silage, string failed, string bgstate, string bgcounty)
        {
            elementUtils.ClickElement(DocumentIntakeDetailsPage.PAddNewMY);
            elementUtils.SetElementExistsWait(DocumentIntakeDetailsPage.MarketingYear);
            elementUtils.SelectDropDownByText(DocumentIntakeDetailsPage.MarketingYear, myear);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.FarmNumber, farmnum);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.TractNumber, tractnum);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.FieldNumber, fieldnum);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.CornAcreage, cornacreage);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.ProducerShare, producershare);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.FailedAcreage, failed);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.SilageAcres, silage);
            elementUtils.SelectDropDownByText(DocumentIntakeDetailsPage.BGState, bgstate);
           // elementUtils.EnableDropdownByJS(DocumentIntakeDetailsPage.BGCounty);
            elementUtils.SetStaleElementWait(DocumentIntakeDetailsPage.BGCounty);
            elementUtils.SetPresenceOfElementLocated(DocumentIntakeDetailsPage.BGCounty);
            elementUtils.SelectDropDownByText(DocumentIntakeDetailsPage.BGCounty, bgcounty);
            elementUtils.ClickElement(DocumentIntakeDetailsPage.PSaveAndClose);
        }

        public void SetNonFSAAcresForLandlord(string myear, string farmnum, string tractnum, string fieldnum, string cornacreage, string lfname, string llname, string landlordshare, string silage, string failed, string bgstate, string bgcounty)
        {
            elementUtils.ClickElement(DocumentIntakeDetailsPage.LAddNewMY);
            elementUtils.SetElementExistsWait(DocumentIntakeDetailsPage.LMarketingYear);
            elementUtils.SelectDropDownByText(DocumentIntakeDetailsPage.LMarketingYear, myear);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.LFarmNumber, farmnum);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.LTractNumber, tractnum);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.LFieldNumber, fieldnum);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.LeasingFName, lfname);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.LeasingLName, llname);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.LandlordShare, landlordshare);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.LCornAcreage, cornacreage);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.LFailedAcreage, failed);
            elementUtils.SendKeys(DocumentIntakeDetailsPage.LSilageAcreage, silage);
            elementUtils.SelectDropDownByText(DocumentIntakeDetailsPage.LBGState, bgstate);
            elementUtils.SetStaleElementWait(DocumentIntakeDetailsPage.LBGCounty);
            elementUtils.SetElementExistsWait(DocumentIntakeDetailsPage.LBGCounty);
            elementUtils.SelectDropDownByText(DocumentIntakeDetailsPage.LBGCounty, bgcounty);
            elementUtils.ClickElement(DocumentIntakeDetailsPage.LSaveNonFSA);
            elementUtils.ClickElement(DocumentIntakeDetailsPage.LDoneNonFSA);
        }

        public void ClickPage5Next()
        {
            elementUtils.SetElementExistsWait(DocumentIntakeDetailsPage.Page5SaveAndNext);
            elementUtils.ClickElement(DocumentIntakeDetailsPage.Page5SaveAndNext);
        }

        public void ClickPage5NextWhenNoNonFSA()
        {
            elementUtils.SetStaleElementWait(DocumentIntakeDetailsPage.Page5SaveAndNext);
            elementUtils.SetPresenceOfElementLocated(DocumentIntakeDetailsPage.Page5SaveAndNext);
            elementUtils.ClickElement(DocumentIntakeDetailsPage.Page5SaveAndNext);
        }
        public void SetFedOnFarmAndViptera(string f13, string f14, string f15, string f16, string f17, string vipteraYN)
        {
            if(f13 != null)
            {
                elementUtils.SendKeys(DocumentIntakeDetailsPage.FedOnFarm13, f13);
            }
            if(f14 != null)
            {
                elementUtils.SendKeys(DocumentIntakeDetailsPage.FedOnFarm14, f14);
            }
            if(f15 != null)
            {
                elementUtils.SendKeys(DocumentIntakeDetailsPage.FedOnFarm15, f15);
            }
            if(f16 != null)
            {
                elementUtils.SendKeys(DocumentIntakeDetailsPage.FedOnFarm16, f16);
            }
            if(f17 != null)
            {
                elementUtils.SendKeys(DocumentIntakeDetailsPage.FedOnFarm17, f17);
            }           
            elementUtils.SelectRadioButtonByText(DocumentIntakeDetailsPage.VipteraYesOrNo, vipteraYN);
        }

        public void ClickPage6Next()
        {
            elementUtils.ClickElement(DocumentIntakeDetailsPage.Page6SaveAndNext);
        }

        public void EnterSignAndSubmitClaim(string sign)
        {
            elementUtils.SendKeys(DocumentIntakeDetailsPage.Sign, sign);
            elementUtils.ClickElement(DocumentIntakeDetailsPage.Submit);
        }
        public void CheckInIntakeDocument(string parentWindowHandle)
        {
            WebDriverUtil.SwitchToParentWindow(parentWindowHandle);
            elementUtils.ClickElement(DocumentIntakeDetailsPage.CheckIn);
        }

        public void ClickBack(string parentWindowHandle)
        {
            WebDriverUtil.SwitchToParentWindow(parentWindowHandle);
            elementUtils.ClickElement(DocumentIntakeDetailsPage.Back);
        }

    }
}