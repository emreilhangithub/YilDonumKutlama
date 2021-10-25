using System.Data.SqlClient;

namespace YilDonumKutlama.WinForm.Helper
{
    class SqlHelper
        {
            public SqlConnection baglanti()  //method
            { //baglan nesne
                SqlConnection baglan = new SqlConnection
                    (@"Data Source=" + Global.BilgisayarAdi + ";Initial Catalog=" + Global.VeriTabani + ";User ID=" + Global.KullaniciAdi + ";Password=" + Global.Sifre + ";");
            baglan.Open();
                return baglan;
            }
        }
    
}
