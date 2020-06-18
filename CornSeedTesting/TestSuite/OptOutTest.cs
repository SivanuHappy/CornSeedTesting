using NUnit.Framework;
using QA.Utilities.DatabaseConnectivity;
using CornSeedTesting.DataReader;
using CornSeedTesting.CornSeedDBActions;


namespace CornSeedTesting.TestSuite
{
    public class OptOutTest
    {
        OptOutActions optActions;
        public OptOutTest()
        {
            optActions = new OptOutActions(new DatabaseConnectivity());
        }

        [Test, TestCaseSource(typeof(TestDataRead), "ProducerOptOutData"), Order(1)]
        public void InsertIntoOptOutTableForProd(string optoutId, string xmlHistId, string recordNo, string admin, string attaddr1, string attaddr2, string attcity, string attFirst, string attLast, string attMiddle, string attPhone1, string attPhone2, string attPhone3, string attState, string attSuffix, string attZip, string business, string caAcres13, string caAcres13NP, string caAcres14, string caAcres14NP, string caAcres15, string caAcres15NP, string caAcres16, string caAcres16NP, string caAcres17, string caAcres17NP, string caAcresTotal, string child, string city, string cmem13, string CMem13NP, string CMem14, string CMem14NP, string CMem15, string CMem15NP, string CMem16, string CMem16NP, string CMem17, string CMem17NP, string CMemShare, string CMemShareNP, string CPhone1, string CPhone2, string CPhone3, string Day, string Deceased, string EIN, string Executor, string FarmAddress1, string FarmAddress2, string FarmCity, string FarmPhone1, string FarmPhone2, string FarmPhone3, string FarmState, string FarmZip, string FirmName, string First, string GovRecNo, string GovRecYes, string Last, string LegallyInCap, string Middle, string Minor, string Month, string OptOutInc, string OptOutNo, string OptOutYes, string Parent, string PerYear, string RelOther, string RelOtherDesc, string RepEIN, string RepFirst, string RepLast, string RepMiddle, string RepOther, string RepOtherDesc, string RepSSN, string RepSuffix, string RepTaxpayerID, string Sibling, string Signature, string SignHandWritten, string SignNotProvided, string Spouse, string SSN, string StateProvince, string StreetAddress1, string StreetAddress2, string Suffix, string TaxPayerID, string Total, string Year, string ZipCode)
        {
            optActions.InsertIntoOptOutTableForProd(optoutId, xmlHistId, recordNo, admin, attaddr1, attaddr2, attcity, attFirst, attLast, attMiddle, attPhone1, attPhone2, attPhone3, attState, attSuffix, attZip, business, caAcres13, caAcres13NP, caAcres14, caAcres14NP, caAcres15, caAcres15NP, caAcres16, caAcres16NP, caAcres17, caAcres17NP, caAcresTotal, child, city, cmem13, CMem13NP, CMem14, CMem14NP, CMem15, CMem15NP, CMem16, CMem16NP, CMem17, CMem17NP, CMemShare, CMemShareNP, CPhone1, CPhone2, CPhone3, Day, Deceased, EIN, Executor, FarmAddress1, FarmAddress2, FarmCity, FarmPhone1, FarmPhone2, FarmPhone3, FarmState, FarmZip, FirmName, First, GovRecNo, GovRecYes, Last, LegallyInCap, Middle, Minor, Month, OptOutInc, OptOutNo, OptOutYes, Parent, PerYear, RelOther, RelOtherDesc, RepEIN, RepFirst, RepLast, RepMiddle, RepOther, RepOtherDesc, RepSSN, RepSuffix, RepTaxpayerID, Sibling, Signature, SignHandWritten, SignNotProvided, Spouse, SSN, StateProvince, StreetAddress1, StreetAddress2, Suffix, TaxPayerID, Total, Year, ZipCode);
        }

        [Test, TestCaseSource(typeof(TestDataRead), "EGOptOutData"), Order(1)]
        public void InsertIntoOptOutTableForEG(string claimType, string optoutId, string xmlHistId, string recordNo, string Administrator, string AttAddress1, string AttAddress2, string AttCity, string AttFirst, string AttLast, string AttMiddle, string AttPhone1, string AttPhone2, string AttPhone3, string AttState, string AttSuffix, string AttZip, string BusinessName, string Child, string City, string CPhone1, string CPhone2, string CPhone3, string Day, string Deceased, string EIN, string Executor, string FirmName, string First, string Last, string LegallyInCap, string Middle, string Minor, string Month, string MY2013, string MY2013NP, string MY2014, string MY2014NP, string MY2015, string MY2015NP, string MY2016, string MY2016NP, string MY2017, string MY2017NP, string MYAfter2013, string MYAfter2013NP, string MYAfter2014, string MYAfter2014NP, string MYAfter2015, string MYAfter2015NP, string MYAfter2016, string MYAfter2016NP, string MYAfter2017, string MYAfter2017NP, string MYAfterNP, string MYAfterPerYear, string MYAfterTotal, string MYNP, string MYPerYear, string MYSTon2013, string MYSTon2013NP, string MYSTon2014, string MYSTon2014NP, string MYSTon2015, string MYSTon2015NP, string MYSTon2016, string MYSTon2016NP, string MYSTon2017, string MYSTon2017NP, string MYSTonCapacity, string MYSTonCapacityNP, string MYSTonNP, string MYSTonPerYear, string MYSTonTotal, string MYTotal, string OptOutInc, string OptOutNo, string OptOutYes, string Parent, string RelOther, string RelOtherDesc, string RepEIN, string RepFirst, string RepLast, string RepMiddle, string RepOther, string RepOtherDesc, string RepSSN, string RepSuffix, string RepTaxpayerID, string Sibling, string Signature, string SignHandWritten, string SignNotProvided, string Spouse, string SSN, string StateProvince, string StreetAddress1, string StreetAddress2, string Suffix, string TaxPayerID, string Year, string ZipCode)
        {
            optActions.InsertIntoOptOutTableForEG(claimType, optoutId, xmlHistId, recordNo, Administrator, AttAddress1, AttAddress2, AttCity, AttFirst, AttLast, AttMiddle, AttPhone1, AttPhone2, AttPhone3, AttState, AttSuffix, AttZip, BusinessName, Child, City, CPhone1, CPhone2, CPhone3, Day, Deceased, EIN, Executor, FirmName, First, Last, LegallyInCap, Middle, Minor, Month, MY2013, MY2013NP, MY2014, MY2014NP, MY2015, MY2015NP, MY2016, MY2016NP, MY2017, MY2017NP, MYAfter2013, MYAfter2013NP, MYAfter2014, MYAfter2014NP, MYAfter2015, MYAfter2015NP, MYAfter2016, MYAfter2016NP, MYAfter2017, MYAfter2017NP, MYAfterNP, MYAfterPerYear, MYAfterTotal, MYNP, MYPerYear, MYSTon2013, MYSTon2013NP, MYSTon2014, MYSTon2014NP, MYSTon2015, MYSTon2015NP, MYSTon2016, MYSTon2016NP, MYSTon2017, MYSTon2017NP, MYSTonCapacity, MYSTonCapacityNP, MYSTonNP, MYSTonPerYear, MYSTonTotal, MYTotal, OptOutInc, OptOutNo, OptOutYes, Parent, RelOther, RelOtherDesc, RepEIN, RepFirst, RepLast, RepMiddle, RepOther, RepOtherDesc, RepSSN, RepSuffix, RepTaxpayerID, Sibling, Signature, SignHandWritten, SignNotProvided, Spouse, SSN, StateProvince, StreetAddress1, StreetAddress2, Suffix, TaxPayerID, Year, ZipCode);
        }

        [TearDown]
        public void TearDown()
        {
            optActions.connection.Close();
        }
    }
}
