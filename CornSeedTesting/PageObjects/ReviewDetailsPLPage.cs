using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace CornSeedTesting.PageObjects
{
    public class ReviewDetailsPLPage
    {
        public static string xPathString;
        //Question 1 - FSA and RMA response
        public static By FSAResponseQ1 = By.XPath("//*[@name=\"ctl00$ContentPlaceHolder1$gdReviewDataSource$ctl02$rdlMatchYNID\"]");
        public static By RMAResponseQ1 = By.XPath("//*[@name=\"ctl00$ContentPlaceHolder1$gdReviewDataSource$ctl03$rdlMatchYNID\"]");

        //Open acres save button
        public static By SaveButton = By.XPath("//*[@id=\"ContentPlaceHolder1_btnOpenAcres\"]");

        //Question 2 - Recommendation


        //Acres under review        
        public static string AcresGridRowString = "//*[@id=\"ContentPlaceHolder1_upFSAData\"]/div/div[3]/table/tbody/tr";
        public static By AcresGridRow = By.XPath(AcresGridRowString);
        public static By AcresGridCol = By.XPath("//table[@id=\"ContentPlaceHolder1_gdFSAData\"]/tbody/tr[1]/td");
        public static string AcresGridFirstPart = AcresGridRowString + "[";
        public static string AcresGridSecondPart = "]/td[";
        public static string AcresGridThirdPart = "]";

        public static string GetTableXPathRowForAcresGrid(int row)
        {
            return AcresGridFirstPart + row + AcresGridSecondPart;
        }

        public static string GetTableXPathColumnForAcresGrid(int column)
        {
            return AcresGridSecondPart + column + AcresGridThirdPart;
        }

        public static By GetAcreSource(int row)
        {
            xPathString = AcresGridRowString + "[" + row + "]/td[1]/span";
            return By.XPath(xPathString);
        }

        public static By GetAcresReviewImage(int row)
        {
            xPathString = "//td[@id=\"ContentPlaceHolder1_gdFSAData_imgNeedsRvw_" + row + "\"]";
            return By.XPath(xPathString);
        }

        public static By GetAcreRelevance(int row)
        {
            xPathString = AcresGridRowString + "[" + row + "]/td[2]";
            return By.XPath(xPathString);
        }

        public static By GetAcreAction(int row)
        {
            xPathString = "//*[@id=\"ContentPlaceHolder1_gdFSAData_imgFSAAction_" + row + "\"]";
            return By.XPath(xPathString);
        }
        //Acreage details
        public static By SourceAcreageDetail = By.XPath("//*[@id=\"ContentPlaceHolder1_lblSource\"]");
        public static By RelevanceAcreageDetail = By.XPath("//*[@id=\"ContentPlaceHolder1_lblRelavance\"]");
        public static By YearAcreageDetail = By.XPath("//*[@id=\"ContentPlaceHolder1_lblMarketingYear\"]");
        public static By FarmNumberAcreageDetail = By.XPath("//*[@id=\"ContentPlaceHolder1_lblFarmNbr\"]");
        public static By TractNumberAcreageDetail = By.XPath("//*[@id=\"ContentPlaceHolder1_lblTractNbr\"]");
        public static By FieldNumberAcreageDetail = By.XPath("//*[@id=\"ContentPlaceHolder1_lblCLUFieldNbr\"]");
        public static By ShareAcreageDetail = By.XPath("//*[@id=\"ContentPlaceHolder1_lblOriginalShare\"]");
        public static By StateAcreageDetail = By.XPath("//*[@id=\"ContentPlaceHolder1_lblStateAbbrev\"]");
        public static By CountyAcreageDetail = By.XPath("//*[@id=\"ContentPlaceHolder1_lblCountyName\"]");
        public static By SiloAcreageDetail = By.XPath("//*[@id=\"ContentPlaceHolder1_lblSilageAcres\"]");
        public static By CornAcreageDetail = By.XPath("//*[@id=\"ContentPlaceHolder1_lblCornAcreage\"]");
        public static By FailedAcreageDetail = By.XPath("//*[@id=\"ContentPlaceHolder1_lblFailedAcre\"]");
        public static By CloseAcreageDetail = By.XPath("//*[@id=\"ContentPlaceHolder1_btnAcreageCancel\"]");
        public static By SaveAcreageDetail = By.XPath("//*[@id=\"ContentPlaceHolder1_btnAcreageSave\"]");
        //Adjusted Acreage information
        public static By AdjSiloAcreageDetail = By.XPath("//*[@id=\"ContentPlaceHolder1_txtAdjSilageAcreage\"]");
        public static By AdjCornAcreageDetail = By.XPath("//*[@id=\"ContentPlaceHolder1_txtAdjCornAcreage\"]");
        public static By AdjFailedAcreageDetail = By.XPath("//*[@id=\"ContentPlaceHolder1_txtAdjFailedAcre\"]");
        public static By AdjShareAcreageDetail = By.XPath("//*[@id=\"ContentPlaceHolder1_txtAdjustedShare\"]");
        public static By AdjStateAcreageDetail = By.XPath("//*[@id=\"ContentPlaceHolder1_ddlAdjStateID\"]");
        public static By AdjCountyAcreageDetail = By.XPath("//*[@id=\"ContentPlaceHolder1_ddlAdjCountyID\"]");
        public static By ExcludeAcres = By.XPath("//*[@name=\"ctl00$ContentPlaceHolder1$rdlExcludeAcresYNID\"]");
        //Save and Next review details
        public static By SaveAndNext = By.XPath("//*[@id=\"ContentPlaceHolder1_btnSaveNext\"]");
    }
}
