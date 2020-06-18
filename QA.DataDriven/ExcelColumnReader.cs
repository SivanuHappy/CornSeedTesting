using System;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;
using NUnit.Framework;
using QA.Utilities.TestHelpers;

namespace QA.DataDriven
{
    public class ExcelColumnReader
    {
        public static int rowNum, colCount;
        public static string cellRange;
        public static ExcelWorksheet worksheet;

        public static List<TestCaseData> GetAncillaryData(string fileName, string sheetName, string claimantId)
        {
            var row = new List<string>();
            var testdata = new List<TestCaseData>();
            InitData(fileName, sheetName);
            foreach (var sheetcell in worksheet.Cells[cellRange])
            {
                if (sheetcell.Value.ToString() == claimantId)
                {
                    rowNum = sheetcell.Start.Row;
                    for (int j = worksheet.Dimension.Start.Column; j <= colCount; j++)
                    {
                        if (worksheet.Cells[rowNum, j].Value == null)
                            row.Add(null);
                        if (worksheet.Cells[rowNum, j].Value != null)
                            row.Add(worksheet.Cells[rowNum, j].Value.ToString());
                    }
                    testdata.Add(new TestCaseData(row.ToArray()));
                    row.Clear();
                }
            }
            return testdata;
        }
        public static Dictionary<string, List<string>> GetAncillaryData(string fileName, string sheetName)
        {
            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
            InitData(fileName, sheetName);
            foreach (var sheetcell in worksheet.Cells[cellRange])
            {
                rowNum = sheetcell.Start.Row;
                string key = worksheet.Cells[rowNum, 1].Value.ToString();
                if (dic.ContainsKey(key))
                {
                    List<string> value = dic[key];
                    value.Add(worksheet.Cells[rowNum, 2].Value.ToString());
                }
                else
                {
                    List<string> value = new List<string>();
                    value.Add(worksheet.Cells[rowNum, 2].Value.ToString());
                    dic.Add(key, value);
                }
            }
            return dic;
        }

        public static void InitData(string fileName, string sheetName)
        {
            int rowStart, rowEnd;
            string filePath;
            filePath = TestHelper.TestData() + fileName;
            FileInfo fileInfo = new FileInfo(filePath);
            ExcelPackage package = new ExcelPackage(fileInfo);
            worksheet = package.Workbook.Worksheets[sheetName];
            rowStart = worksheet.Dimension.Start.Column + 1;
            rowEnd = worksheet.Dimension.End.Row;
            colCount = worksheet.Dimension.End.Column;
            cellRange = "A" + rowStart.ToString() + ":" + "A" + rowEnd.ToString();
        }
    }
}
