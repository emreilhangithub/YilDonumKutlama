using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Drawing;
using YilDonumKutlama.WinServis.Helper;
using YilDonumKutlama.WinServis.Job;

namespace YilDonumKutlama.WinServis
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        private SqlHelper bgl = new SqlHelper();

        private void MailGonder()
        {
            SqlCommand komut = new SqlCommand("SELECT  * FROM [YilDonumKutlama].[dbo].[Tbl_YilDonumleri]", bgl.mailBaglanti());
            DataTable tablo = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(tablo);

            List<YilDonumleri> yilDonumleri = new List<YilDonumleri>();

            yilDonumleri = tablo.AsEnumerable().Select(s => new YilDonumleri
            {
                Id = s.Field<int>("Id"),
                Ad = s.Field<string>("Ad"),
                Soyad = s.Field<string>("Soyad"),
                Bolum = s.Field<string>("Bolum"),
                DTarihi = s.Field<DateTime>("DTarihi"),
                BaslangicTarihi = s.Field<DateTime>("BaslangicTarihi")
            }).ToList();
            //  dataGridView1.DataSource = yilDonumleri;

            List<string> mailLisetsi = new List<string>();

            //Tarihler
            int gun = DateTime.Now.Day;
            int ay = DateTime.Now.Month;
            int yil = DateTime.Now.Year;

            if (yilDonumleri.Count > 0)
            {
                foreach (var kisi in yilDonumleri)
                {
                    //İşe başlangıc Tarihi
                    var IsBasGun = kisi.BaslangicTarihi.Day;
                    var IsBasAy = kisi.BaslangicTarihi.Month;
                    var IsBasYil = kisi.BaslangicTarihi.Year;

                    //Doğum Günü Tarihi
                    var DogGun = kisi.DTarihi.Day;
                    var DogAy = kisi.DTarihi.Month;
                    var DogYil = kisi.DTarihi.Year;

                    //Kaçıncı Sene
                    var kacinciIsSenesi = yil - IsBasYil;
                    var kacinciYasi = yil - DogYil;

                    if (IsBasGun == gun && IsBasAy == ay && IsBasYil == yil)
                    {
                        MailHelper.sendMail(string.Format("Bugün " + kisi.Ad + " " + kisi.Soyad + " " + kisi.Bolum +
                                                          " Bölümünde İşe Başlamıştır Başarılar Dileriz"));
                    }
                    else
                    {
                        if (kacinciIsSenesi > 0)
                        {
                            if (IsBasGun == gun && IsBasAy == ay)
                            {
                                MailHelper.sendMail(string.Format("Bugün " + kisi.Ad + " " + kisi.Soyad + " " +
                                                                  kacinciIsSenesi +
                                                                  " . İş Senesi Başarılarının Devamını Dileriz"));
                            }

                            if (DogGun == gun && DogAy == ay)
                            {
                                MailHelper.sendMail(string.Format("Bugün " + kisi.Ad + " " + kisi.Soyad + " " + kacinciYasi +
                                                                  " . Yaş Günü Mutluluklar Dileriz Doğum Günün Kutlu Olsun"));
                            }
                        }
                    }
                }
            }
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                LogHelper.Log("<!----------------------Starting Service------------------------------!>");
                Scheduler.StartJob().GetAwaiter().GetResult();
            }
            catch (Exception exception)
            {
                LogHelper.LogError(exception.Message);
            }
        }
        public void OnDebug()
        {
            OnStart(null);
        }

        protected override void OnStop()
        {
        }
    }
}
