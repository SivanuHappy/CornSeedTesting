using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace QA.Utilities.TestHelpers
{
    public class TestHelper
    {
        static string dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\netcoreapp3.1", "");
        public static string TestData()
        {
            string testdatalocation = dir + "\\TestData";
            return testdatalocation;
        }

        public static string GetReportFolder()
        {
            string reportFolder = dir + "\\Reports\\";
            return reportFolder;
        }
        public static string GetScreenshotDir(string projectName)
        {
            DirectoryInfo di = Directory.CreateDirectory(dir + "\\Defect_Screenshots\\" + projectName);
            string screenshotLocation = dir + "\\Defect_Screenshots\\" + projectName;
            return screenshotLocation;
        }
        public static IConfiguration GetConfig()
        {
            IConfigurationBuilder config = new ConfigurationBuilder()
                .SetBasePath(System.AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return config.Build();
        }
    }
}
