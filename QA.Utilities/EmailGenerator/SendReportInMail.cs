using System;
using System.Collections.Generic;
using System.Text;
using QA.Utilities.ReportGenerator;
using QA.Utilities.EmailGenerator;

namespace QA.Utilities.EmailGenerator
{
    public class SendReportInMail
    {
        public static void Send_Report_In_Mail(string projectName, string reportFolder, string toEmailGroup)
        {
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualpath = pth.Substring(0, pth.LastIndexOf("bin"));
            string projectpath = new Uri(actualpath).LocalPath;

            string mailSubject = projectName + " " + "test results: Passed - " + ReportGenerator.ReportGenerator.pCount + " ; Failed - " + ReportGenerator.ReportGenerator.fCount + " ; Skipped - " + ReportGenerator.ReportGenerator.sCount;
            string mailBody, mailheader = "";

            if (ReportGenerator.ReportGenerator.fCount > 0 || ReportGenerator.ReportGenerator.sCount > 0)
            {
                mailheader = ReportGenerator.ReportGenerator.emailCss + ReportGenerator.ReportGenerator.emailHeader + ReportGenerator.ReportGenerator.emailtable;
                mailBody = mailheader + ReportGenerator.ReportGenerator.emailBody + "</table></body></html>";
            }

            else
            {
                mailheader = ReportGenerator.ReportGenerator.emailCss + ReportGenerator.ReportGenerator.emailHeader + ReportGenerator.ReportGenerator.emailtable;
                mailBody = mailheader + ReportGenerator.ReportGenerator.emailBody + "</table></body></ html>";
            }

            string TimeStamp = DateTime.Now.ToString("yyyy-MM-dd");
            string reportPath = projectpath + "Reports\\" + reportFolder + "\\" + projectName + "-" + TimeStamp + ".html";
            EmailGenerator.SendEmailUsingMailKit(toEmailGroup, mailSubject, mailBody, true, reportPath);
        }
    }
}
