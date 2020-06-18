using System.Collections.Generic;
using NUnit.Framework;
using QA.DataDriven;
using QA.Utilities.TestHelpers;


namespace CornSeedTesting.DataReader
{
    public class TestDataRead
    {
        static IEnumerable<TestCaseData> TestSourceData(string fileName, string sheetName)
        {
            string filePath = TestHelper.TestData() + @"\" + fileName;
            List<TestCaseData> TestCaseDataList = new ExcelReader().ReadExcelData(filePath, sheetName);
            if (TestCaseDataList != null)
                foreach (TestCaseData TestCaseData in TestCaseDataList)
                    yield return TestCaseData;
        }

        public static List<TestFixtureData> TestFixtureSourceData(string fileName, string sheetName)
        {
            List<TestFixtureData> TestCaseDataList = null;
            TestCaseDataList = new ExcelReader().ReadDataForTestFixture(fileName, sheetName);
            return TestCaseDataList;
        }

    }   
}
