using System;
using MailKit.Net.Smtp;
using MimeKit;
using QA.Utilities.TestHelpers;
using QA.Utilities.ReportGenerator;

namespace QA.Utilities.EmailGenerator
{
    public class EmailGenerator
    {
        public static void SendEmailUsingMailKit(string _emailTo, string _subject, string _body, bool _attachment, string NewIndexpath)
        {
            //Read variables from appsettings
            var settings = TestHelper.GetConfig();

            //Message initialization
            MimeMessage smtpmail = new MimeMessage();

            //Mail from set up
            string from = settings["AppConfiguration:FromEmailAddress"];
            MailboxAddress fromId = new MailboxAddress("Admin", from);
            smtpmail.From.Add(fromId);

            //Mail to set up
            string[] recipients = _emailTo.Split(',');
            InternetAddressList list = new InternetAddressList();
            foreach (string recipient in recipients)
            {
                if (!string.IsNullOrEmpty(recipient))
                {
                    list.Add(new MailboxAddress(recipient.Trim()));

                }
            }
            smtpmail.To.AddRange(list);

            //Mail subject set up
            smtpmail.Subject = _subject;

            //Email body set up
            string serverName = settings["Smtp:Server"];
            int port = Int16.Parse(settings["Smtp:Port"]);
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = _body;
            if (_attachment && ReportGenerator.ReportGenerator.fCount > 0 || ReportGenerator.ReportGenerator.sCount > 0)
            {
                bodyBuilder.Attachments.Add(NewIndexpath);
            }
            smtpmail.Body = bodyBuilder.ToMessageBody();
            using (SmtpClient client = new SmtpClient())
            {
                client.Connect(serverName, port, MailKit.Security.SecureSocketOptions.StartTlsWhenAvailable);
                client.AuthenticationMechanisms.Clear();
                client.AuthenticationMechanisms.Add("NTLM");
                //var mechanisms = string.Join(", ", client.AuthenticationMechanisms);
                // Console.WriteLine("The SMTP server supports the following SASL mechanisms: {0}", mechanisms);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                //client.Authenticate(@"BROWNGREER\smtprelay", "R3l@yzm3");
                client.Send(smtpmail);
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}
