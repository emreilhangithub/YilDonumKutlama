using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace YilDonumKutlama.WinServis.Helper
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
                string mailadresim = ("gonderici mail");
                string sifre = ("gonderici sifre");
                string smtpsrvr = "smtp.gmail.com";
                string konu = ("Yıl Dönümü hk.");
                string yaz = (gelenYaz);

                smtpserver.Credentials = new NetworkCredential(mailadresim, sifre);
                smtpserver.Port = 587;
                smtpserver.Host = smtpsrvr;
                smtpserver.EnableSsl = true;

                mail.From = new MailAddress(mailadresim);
                mail.To.Add("gonderilecek mail adresi");
                mail.Subject = konu;
                mail.Body = yaz;

                smtpserver.Send(mail);

                LogHelper.Log(string.Concat("Girmiş olduğunuz bilgiler uyuşuyor bilgileriniz mail adresinize başarılı bir şekilde gönderilmiştir",""));
            }
            catch (Exception Hata)
            {
                LogHelper.LogError(string.Concat("Mail gönderme hatası!", Hata.Message));
            }
        }

    }
}
