using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Mail;
using System.Collections ;

namespace chiase
{
    public static class Gmail
    {
        public static String From = "quantri.scmct@gmail.com";
        public static String Password = "scmct1234567890";

        static public void Send(String To, String Subject, String Body)
        {
            MailMessage Mail = Gmail.CreateMailMessage(To, Subject, Body);
            Gmail.Send(Mail);
        }

        static public void Send(String To, String Cc, String Bcc, String Subject, String Body, String[] Attachments)
        {
            MailMessage Mail = Gmail.CreateMailMessage(To, Subject, Body);

            if (!String.IsNullOrEmpty(Cc))
            {
                Mail.Cc = Cc.Replace(',', ';').Replace(" ", "");
            }

            if (!String.IsNullOrEmpty(Bcc))
            {
                Mail.Bcc = Bcc.Replace(',', ';').Replace(" ", "");
            }

            if (Attachments != null)
            {
                foreach (String Attachment in Attachments)
                {
                    Mail.Attachments.Add(Attachment);
                }
            }

            Gmail.Send(Mail);
        }

        static MailMessage CreateMailMessage(String To, String Subject, String Body)
        {
            MailMessage Mail = new MailMessage();
            Mail.BodyFormat = MailFormat.Html;

            Mail.From = From;
            Mail.To = To;
            Mail.Subject = Subject;
            Mail.Body = Body;

            Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", "smtp.gmail.com");
            Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", "465");
            Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", "2");
            Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
            Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", Gmail.From);
            Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", Gmail.Password);
            Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true");

            return Mail;
        }

        static void Send(MailMessage Mail)
        {
            SmtpMail.SmtpServer = "smtp.gmail.com:465";
            SmtpMail.Send(Mail);
        }
    }
}