using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YilDonumKutlama.WinForm.Helper
{
   public class MailHelper
    {
        public static void sendMail(string gelenYaz)
        {
            try
            {
                SmtpClient smtpserver = new SmtpClient();
                MailMessage mail = new MailMessage();
                DateTime tarih = DateTime.Now; //string tarih aldık
                string mailadresim = ("gondericimailadresi");
                string sifre = ("gondericisifre");
                string smtpsrvr = "smtp.gmail.com";
                string konu = ("Yıl Dönümü hk.");
                string yaz = (gelenYaz);

                smtpserver.Credentials = new NetworkCredential(mailadresim, sifre);
                smtpserver.Port = 587;
                smtpserver.Host = smtpsrvr;
                smtpserver.EnableSsl = true;

                mail.From = new MailAddress(mailadresim);
                mail.To.Add("gonderilecekmailadresi");
                mail.Subject = konu;
                mail.Body = yaz;

                smtpserver.Send(mail);

                DialogResult bilgi = new DialogResult();
                LogHelper.Log(string.Concat("Girmiş olduğunuz bilgiler uyuşuyor bilgileriniz mail adresinize başarılı bir şekilde gönderilmiştir", bilgi));
            }
            catch (Exception Hata)
            {
                LogHelper.LogError(string.Concat("Mail gönderme hatası!", Hata.Message));
            }
        }

    }
}
