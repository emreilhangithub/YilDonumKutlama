using System.Data.SqlClient;

namespace YilDonumKutlama.WinServis.Helper
{
    class SqlHelper
        {
            public SqlConnection mailBaglanti()  
        { 
            SqlConnection baglan = new SqlConnection
                (@"baglantiadresiniz");
            baglan.Open();
            return baglan;
        }


    }
    
}
