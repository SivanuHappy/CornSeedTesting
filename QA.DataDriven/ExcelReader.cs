using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;
using OfficeOpenXml;

namespace QA.DataDriven
{
    public class ExcelReader
    {
       public List<TestCaseData> ReadExcelData(string filePath, string sheetName)
        {
            var testdata = new List<TestCaseData>();
            var row = new List<string>();
            FileInfo fileInfo = new FileInfo(filePath);
            ExcelPackage package = new ExcelPackage(fileInfo);
            ExcelWorksheet worksheet = package.Workbook.Worksheets[sheetName];
            int rowCount = worksheet.Dimension.End.Row;
            int colCount = worksheet.Dimension.End.Column;
            for (int i = worksheet.Dimension.Start.Row + 1; i <= rowCount; i++)
            {
                for (int j = worksheet.Dimension.Start.Column; j <= colCount; j++)
                {
                    if (worksheet.Cells[i, j].Value == null)
                        row.Add(null);
                    if (worksheet.Cells[i, j].Value != null)
                        row.Add(worksheet.Cells[i, j].Value.ToString());
                }
                testdata.Add(new TestCaseData(row.ToArray()));
                row.Clear();
            }

            package.Workbook.Dispose();
            return testdata;
        }
        public List<TestFixtureData> ReadDataForTestFixture(string filePath, string sheetName)
        {
            var testdata = new List<TestFixtureData>();
            var row = new List<string>();
            FileInfo fileInfo = new FileInfo(filePath);
            //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage package = new ExcelPackage(fileInfo);
            ExcelWorksheet worksheet = package.Workbook.Worksheets[sheetName];
            int rowCount = worksheet.Dimension.End.Row;
            int colCount = worksheet.Dimension.End.Column;
            for (int i = worksheet.Dimension.Start.Row + 1; i <= rowCount; i++)
            {
                for (int j = worksheet.Dimension.Start.Column; j <= colCount; j++)
                {
                    if (worksheet.Cells[i, j].Value == null)
                        row.Add("");
                    if (worksheet.Cells[i, j].Value != null)
                        row.Add(worksheet.Cells[i, j].Value.ToString());
                    //Console.WriteLine(" Row:" + i + " column:" + j + " Value:" + worksheet.Cells[i, j].Value);
                }
                testdata.Add(new TestFixtureData(row.ToArray()));
                row.Clear();
            }
            package.Workbook.Dispose();
            return testdata;
        }
    }
}
