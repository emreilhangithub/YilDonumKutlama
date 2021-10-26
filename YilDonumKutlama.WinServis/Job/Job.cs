using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Quartz;
using YilDonumKutlama.WinServis.Helper;

namespace YilDonumKutlama.WinServis.Job
{
    public class Job : IJob
    {
        private SqlHelper bgl = new SqlHelper();
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                //todo işlemler burada yapılacak

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
            catch (Exception exception)
            {
                LogHelper.Log(string.Concat("[ERROR]: ", " ", nameof(Job), " ", "Execute", " ", exception.Message, " ", exception.InnerException));
            }
            finally
            {
                LogHelper.Log(string.Concat("[INFO]: ", string.Concat(" <---Finish Job Erp Operation Executing--->", Environment.NewLine)));
            }
        }
    }
}