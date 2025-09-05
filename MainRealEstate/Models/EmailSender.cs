using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace MainRealEstate.Models
{
    public class EmailSender
    {

        public bool SendMyEmail(string SendTo, string Subject, string Message)
        {
            try
            {
                SmtpClient client = new SmtpClient();
                MailMessage msg = new MailMessage();
                NetworkCredential nc = new NetworkCredential
               ("nameprivate949@@gmail.com", "xanfodiajauyszvs");
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.UseDefaultCredentials = false;
                client.Credentials = nc;
                client.EnableSsl = true;
                // Message setting..
                MailAddress mto = new MailAddress(SendTo);
                MailAddress mfrom = new MailAddress("online.mtechnology@gmail.com");
                msg.To.Add(mto);
                msg.From = mfrom;
                msg.Subject = Subject;
                msg.Body = Message;
                client.Send(msg);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        

    }
}