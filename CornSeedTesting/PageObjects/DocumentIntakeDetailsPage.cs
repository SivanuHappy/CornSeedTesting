using System;
using OpenQA.Selenium;

namespace CornSeedTesting.PageObjects
{
    public class DocumentIntakeDetailsPage
    {
        //Document information
        public static By DocId = By.XPath("//*[@id=\"ContentPlaceHolder1_ctl30_lblIntakeDocID\"]");
        //Search/Add New Claim form
        public static By DocType = By.XPath("//*[@id=\"ContentPlaceHolder1_ddl_DocumentTypeID\"]");
        public static By ClassMemberType = By.XPath("//*[@id=\"ContentPlaceHolder1_ddl_ClaimTypeID\"]");
        public static By SearchClaimantId = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_SettlementID\"]");

        //Buttons
        public static By Search = By.XPath("//*[@id=\"ContentPlaceHolder1_btnClaimantSearch\"]");
        public static By AddNewClaimant = By.XPath("//*[@id=\"ContentPlaceHolder1_btnAddNewCF\"]");
        public static By CFIFrame = By.XPath("//*[@id=\"ifPDFViewer\"]");
        public static string frameId = "ifPDFViewer";
        public static By Back = By.XPath("//*[@id=\"ContentPlaceHolder1_btnBack\"]");

        //Document link
        public static By DocLink = By.XPath("//*[@id=\"ContentPlaceHolder1_lvClaimantSearch_lnkLink_0\"]");

        //Claim Form fields
        public static By ClaimFormText = By.XPath("//*[@id=\"ContentPlaceHolder1_pnlMain\"]/div[1]/h3");
        public static By TaxType = By.XPath("//*[@name=\"ctl00$ContentPlaceHolder1$rdl_TaxpayerTypeID\"]");
        public static By TaxNumberSSN = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_SSN\"]");
        public static By TaxNumberEIN = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_EIN\"]");

        //Name information
        public static By FirstName = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_FirstName\"]");
        public static By MiddleName = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_MiddleName\"]");
        public static By LastName = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_LastName\"]");
        public static By Suffix = By.XPath("//*[@id=\"ContentPlaceHolder1_ddl_SuffixID\"]");
        public static By BusinessName = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_BusinessName\"]");
        //Address Information
        public static By AddressType = By.XPath("//*[@name=\"ctl00$ContentPlaceHolder1$rdlCountryTypeID\"]");
        public static By Address1 = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_Address1\"]");
        public static By Address2 = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_Address2\"]");
        public static By City = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_City\"]");
        public static By State = By.XPath("//*[@id=\"ContentPlaceHolder1_ddl_StateID\"]");
        public static By ZipCode = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_Zip\"]");
        public static By EmailAddress = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_EmailID\"]");
        public static By CEmailAddress = By.XPath("//*[@id=\"ContentPlaceHolder1_txtCEmailAddress\"]");
        public static By HomePhone = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_PhoneNo_PH\"]");
        public static By Mobile = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_CellPhoneNo_PH\"]");
        public static By MobileProvider = By.XPath("//*[@id=\"ContentPlaceHolder1_ddl_CarrierTypeID\"]");
        //Preferred communication method
        public static By CommPref = By.XPath("//*[@name=\"ctl00$ContentPlaceHolder1$rdl_ComPrefID\"]");
        //Representative claimant
        public static By RepClaimant = By.XPath("//*[@name=\"ctl00$ContentPlaceHolder1$rdl_RepYNID\"]");
        public static By RepReasonType = By.XPath("//*[@name=\"ctl00$ContentPlaceHolder1$rdl_RepReasonTypeID\"]");
        public static By RepRelationshipType = By.XPath("//*[@name=\"ctl00$ContentPlaceHolder1$rdl_RelationshipTypeID\"]");
        public static By RepTaxType = By.XPath("//*[@name=\"ctl00$ContentPlaceHolder1$rdl_TaxpayerTypeID\"]");
        public static By RepSSN = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_SSN\"]");
        public static By RepEIN = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_EIN\"]");
        public static By RepFirstName = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_FirstName\"]");
        public static By RepMiddleName = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_MiddleName\"]");
        public static By RepLastName = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_LastName\"]");
        public static By RepSuffix = By.XPath("//*[@id=\"ContentPlaceHolder1_ddl_SuffixID\"]");

        //FSA Consent
        public static By FSAConsent = By.XPath("//*[@id=\"ContentPlaceHolder1_chk_Consent\"]");
        //Save & Next Button
        public static By Page1SaveAndNext = By.XPath("//*[@id=\"ContentPlaceHolder1_btnNext\"]");
        //ClaimantID 
        public static By ClaimantId = By.XPath("//*[@id=\"ContentPlaceHolder1_lblClaimantID\"]");
        //Save & Next Button
        public static By Page2SaveAndNext = By.XPath("//*[@id=\"ContentPlaceHolder1_btnNext\"]");
        //Save & Next Representative page
        public static By RepSaveAndNext = By.XPath("//*[@id=\"ContentPlaceHolder1_btnNext\"]");
        //Law firm information
        public static By LawFirm = By.XPath("//*[@name=\"ctl00$ContentPlaceHolder1$rdl_AttorneyYNID\"]");
        public static By LawFirmName = By.XPath("//*[@id=\"ContentPlaceHolder1_ddlLawfirmID\"]");
        //Save & Next Button
        public static By Page3SaveAndNext = By.XPath("//*[@id=\"ContentPlaceHolder1_btnNext\"]");
        //Crop Reporting information
        public static By CropReport13To17 = By.XPath("//*[@name=\"ctl00$ContentPlaceHolder1$rdl_FSDA13to16YNID\"]");
        public static By CropReportPlan = By.XPath("//*[@name=\"ctl00$ContentPlaceHolder1$rdl_FSAReportPlanYNID\"]");
        public static By CropInsurance = By.XPath("//*[@name=\"ctl00$ContentPlaceHolder1$rdl_FSDAInsuranceYNID\"]");
        public static By LandlordInterest = By.XPath("//*[@name=\"ctl00$ContentPlaceHolder1$rdl_LandLordInfoID\"]");
        //Facility information for ethanol
        public static By NewFacility = By.XPath("//*[@id=\"ContentPlaceHolder1_btnAddNewFacility\"]");
        public static By FacilityType = By.XPath("//*[@id=\"ContentPlaceHolder1_ddl_FacilityTypeID\"]");
        public static By FacilityName = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_FacilityName\"]");
        public static By FacilityAddress = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_Address1\"]");
        public static By FacilityCity = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_City\"]");
        public static By FacilityState = By.XPath("//*[@id=\"ContentPlaceHolder1_ddl_StateID\"]");
        public static By FacilityZip = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_Zip\"]");
        public static By EthanolTotalThroughput = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_TotalThroughPut\"]");
        public static By GrainStorageCapacity = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_StorageCapacity\"]");
        //Ethanol
        public static By EShortTonDDGs13 = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_ShortTonsDDGS13\"]");
        public static By EShortTonDDGs14 = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_ShortTonsDDGS14\"]");
        public static By EShortTonDDGs15 = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_ShortTonsDDGS15\"]");
        public static By EShortTonDDGs16 = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_ShortTonsDDGS16\"]");
        public static By EShortTonDDGs17 = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_ShortTonsDDGS17\"]");
        //Grain
        public static By GBushels13 = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_BushelPrice13\"]");
        public static By GBushels14 = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_BushelPrice14\"]");
        public static By GBushels15 = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_BushelPrice15\"]");
        public static By GBushels16 = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_BushelPrice16\"]");
        public static By GBushels17 = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_BushelPrice17\"]");
        //Facility owning
        public static By FacilityOwning = By.XPath("//*[@name=\"ctl00$ContentPlaceHolder1$rdl_FullOwnerYNID\"]");
        //Save facility
        public static By SaveFacility = By.XPath("//*[@id=\"ContentPlaceHolder1_btnSave\"]");
        public static By DoneFacility = By.XPath("//*[@id=\"ContentPlaceHolder1_btnDone\"]");
        //Save & Next Button
        public static By Page4SaveAndNext = By.XPath("//*[@id=\"ContentPlaceHolder1_btnNext\"]");
        //Non-FSA acres for producer
        public static By PAddNewMY = By.XPath("//*[@id=\"ContentPlaceHolder1_btnAddNewFSA\"]");
        public static By MarketingYear = By.XPath("//*[@id=\"ContentPlaceHolder1_ddlMarketingYearID\"]");
        public static By FarmNumber = By.XPath("//*[@id=\"ContentPlaceHolder1_txtFarmNbr\"]");
        public static By TractNumber = By.XPath("//*[@id=\"ContentPlaceHolder1_txtTractNbr\"]");
        public static By FieldNumber = By.XPath("//*[@id=\"ContentPlaceHolder1_txtCLUFieldNbr\"]");
        public static By CornAcreage = By.XPath("//*[@id=\"ContentPlaceHolder1_txtCornAcreage\"]");
        public static By ProducerShare = By.XPath("//*[@id=\"ContentPlaceHolder1_txtProducerSharePct\"]");
        public static By FailedAcreage = By.XPath("//*[@id=\"ContentPlaceHolder1_txtFailedAcre\"]");
        public static By SilageAcres = By.XPath("//*[@id=\"ContentPlaceHolder1_txtSilageAcres\"]");
        public static By BGState = By.XPath("//*[@id=\"ContentPlaceHolder1_ddlStateID\"]");
        public static By BGCounty = By.XPath("//*[@id=\"ContentPlaceHolder1_ddlCountyID\"]");
        public static By PSaveAddNew = By.XPath("//*[@id=\"ContentPlaceHolder1_btnSaveAddFSA\"]");
        public static By PSaveAndClose = By.XPath("//*[@id=\"ContentPlaceHolder1_btnAddFSA\"]");

        //NonFSA acres for landlord
        public static By LAddNewMY = By.XPath("//*[@id=\"ContentPlaceHolder1_btnAddNew\"]");
        public static By LMarketingYear = By.XPath("//*[@id=\"ContentPlaceHolder1_ddl_MarketingYearID\"]");
        public static By LFarmNumber = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_FarmNbr\"]");
        public static By LTractNumber = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_TractNbr\"]");
        public static By LFieldNumber = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_CLUFieldNbr\"]");
        public static By LCornAcreage = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_CornAcreage\"]");
        public static By LeasingFName = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_LeasingFirstName\"]");
        public static By LeasingLName = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_LeasingLastname\"]");
        public static By LandlordShare = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_LandLordShare\"]");
        public static By LFailedAcreage = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_FailedAcre\"]");
        public static By LSilageAcreage = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_SilageAcres\"]");
        public static By LBGState = By.XPath("//*[@id=\"ContentPlaceHolder1_ddl_StateID\"]");
        public static By LBGCounty = By.XPath("//*[@id=\"ContentPlaceHolder1_ddl_CountyID\"]");
        public static By LSaveNonFSA = By.XPath("//*[@id=\"ContentPlaceHolder1_btnSave\"]");
        public static By LDoneNonFSA = By.XPath("//*[@id=\"ContentPlaceHolder1_btnDone\"]");
        //Save & Next Button
        public static By Page5SaveAndNext = By.XPath("//*[@id=\"ContentPlaceHolder1_btnNext\"]");
        //Fed-on-farm
        public static By FedOnFarm13 = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_CornDisp13ID\"]");
        public static By FedOnFarm14 = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_CornDisp14ID\"]");
        public static By FedOnFarm15 = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_CornDisp15ID\"]");
        public static By FedOnFarm16 = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_CornDisp16ID\"]");
        public static By FedOnFarm17 = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_CornDisp17ID\"]");
        //Viptera
        public static By VipteraYesOrNo = By.XPath("//*[@name=\"ctl00$ContentPlaceHolder1$rdl_AgrisureYNID\"]");
        //Save & Next Button
        public static By Page6SaveAndNext = By.XPath("//*[@id=\"ContentPlaceHolder1_btnNext\"]");
        //Signature
        public static By Sign = By.XPath("//*[@id=\"ContentPlaceHolder1_txtSignName\"]");
        //Submit claim
        public static By Submit = By.XPath("//*[@id=\"ContentPlaceHolder1_btnNext\"]");
        //Check-in intake doc
        public static By CheckIn = By.XPath("//*[@id=\"ContentPlaceHolder1_btnCheckIn\"]");
        //W-9 form
        public static By W9FirstName = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_FirstName\"]");
        public static By W9MiddleName = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_MiddleName\"]");
        public static By W9LastName = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_LastName\"]");
        public static By W9Suffix = By.XPath("//*[@id=\"ContentPlaceHolder1_ddl_SuffixID\"]");
        public static By W9BusinessName = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_BusinessName\"]");
        public static By W9TaxClassification = By.XPath("//*[@name=\"ctl00$ContentPlaceHolder1$W9TaxClassificationID\"]");
        public static By W9Address1 = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_Address1\"]");
        public static By W9Address2 = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_Address2\"]");
        public static By W9City = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_City\"]");
        public static By W9State = By.XPath("//*[@id=\"ContentPlaceHolder1_ddl_StateID\"]");
        public static By W9Zip = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_ZipCode\"]");
        public static By W9TaxtypeId = By.XPath("//*[@name=\"ctl00$ContentPlaceHolder1$rdl_TaxPayerTypeID\"]");
        public static By W9TaxId = By.XPath("//*[@id=\"ContentPlaceHolder1_txt_SSN\"]");
        public static By W9TaxWithHolding = By.XPath("//*[@name=\"ctl00$ContentPlaceHolder1$rdl_YNIDChkWdhHld\"]");
        public static By W9Signed = By.XPath("//*[@name=\"ctl00$ContentPlaceHolder1$rdl_IsSigned\"]");
        public static By W9Submit = By.XPath("//*[@id=\"ContentPlaceHolder1_btnSubmit\"]");
    }
}
