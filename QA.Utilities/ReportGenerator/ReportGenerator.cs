using EReports = AventStack.ExtentReports.ExtentReports;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using QA.Utilities.WebDriverUtils;
using QA.Utilities.TestHelpers;


namespace QA.Utilities.ReportGenerator
{
    public class ReportGenerator
    {
        //Extent reports
        public static EReports _extent;
        public static ExtentTest _test;

        //Fields for email 
        public static string emailCss = "<html><head><style>#teststatus {  font-family: \"Trebuchet MS\", Arial, Helvetica, sans-serif;  border-collapse: collapse;  width: 100%;}#teststatus td, #teststatus th {  border: 1px solid #ddd;  padding: 8px;}#teststatus tr:nth-child(even){background-color: #f2f2f2;}#teststatus tr:hover {background-color: #ddd;}#teststatus th {  padding-top: 12px;  padding-bottom: 12px;  text-align: left;  background-color: #4CAF50;  color: white;}</style></head><body>";
        public static string emailHeader = "Hello Team, <br> Please find the test results: <br>";
        public static string emailtable = "<table id=\"teststatus\"><tr><th>Test Case</th><th>Status</th><th>Exception</th></tr>";
        public static string emailBody;

        //Test cases count variables
        public static int pCount = 0, fCount = 0, sCount = 0;

        public static void CreateReport(string projectName, string reportFolder)
        {
            //Read variables from appsettings
            var settings = TestHelper.GetConfig();
            string envName = settings["AppConfiguration:Environment"];
            string userName = settings["AppConfiguration:UserName"];

            //Report folder set up
            string TimeStamp = DateTime.Now.ToString("yyyy-MM-dd");
            string reportPath = TestHelper.GetReportFolder() + reportFolder + "\\" + projectName + "-" + TimeStamp + ".html";

            //Report configuration
            _extent = new AventStack.ExtentReports.ExtentReports();
            ExtentV3HtmlReporter htmlReporter = new ExtentV3HtmlReporter(reportPath);
            htmlReporter.Config.DocumentTitle = projectName + " - Patching test case report";
            htmlReporter.Config.ReportName = projectName + " - Patching test case report";
            _extent.AddSystemInfo("Environment", envName);
            _extent.AddSystemInfo("User Name", userName);
            _extent.AttachReporter(htmlReporter);
        }

        public static void CreateTestContext()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        public static void CreateTestStatus(string projectName)
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = "" + TestContext.CurrentContext.Result.StackTrace + "";
                var errorMessage = TestContext.CurrentContext.Result.Message;
                Status logstatus;
                switch (status)
                {
                    case TestStatus.Failed:
                        fCount++;
                        emailBody = emailBody + "<tr><td>" + TestContext.CurrentContext.Test.Name + "</td><td>Failed</td><td>" + errorMessage + "</td></tr>";
                        logstatus = Status.Fail;
                        string screenShotPath = WebDriverUtil.Capture(TestContext.CurrentContext.Test.MethodName, projectName);
                        _test.Log(logstatus, "Test ended with " + logstatus + " – " + errorMessage);
                        _test.Log(logstatus, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));
                        break;
                    case TestStatus.Skipped:
                        sCount++;
                        emailBody = emailBody + "<tr><td>" + TestContext.CurrentContext.Test.Name + "</td><td>Skipped</td><td>" + errorMessage + "</td></tr>";
                        logstatus = Status.Skip;
                        _test.Log(logstatus, "Test ended with " + logstatus + " - " + errorMessage);
                        break;
                    default:
                        pCount++;
                        emailBody = emailBody + "<tr><td>" + TestContext.CurrentContext.Test.Name + "</td><td>Passed</td><td>" + errorMessage + "</td></tr>";
                        logstatus = Status.Pass;
                        _test.Log(logstatus, "Test ended with " + logstatus + " " + errorMessage);
                        break;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        public static void FlushTestReport()
        {
            _extent.Flush();
        }

        public static void ClearTestStatus()
        {
            fCount = 0;
            pCount = 0;
            sCount = 0;
            emailBody = "";
        }
    }
}
