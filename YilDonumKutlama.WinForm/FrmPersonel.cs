using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using YilDonumKutlama.WinForm.Helper;

namespace YilDonumKutlama.WinForm
{
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
            VerileriGetir();
        }

        SqlHelper bgl = new SqlHelper();

        private void Frm1_Load(object sender, EventArgs e)
        {

        } 
        private void btnListele_Click(object sender, EventArgs e)
        {
           VerileriGetir();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_YilDonumleri (Ad,Soyad,Bolum,DTarihi,BaslangicTarihi) values(@Ad,@Soyad,@Bolum,@DTarihi,@BaslangicTarihi)", bgl.baglanti());

            komut.Parameters.AddWithValue("@Ad", txtAd.Text);
            komut.Parameters.AddWithValue("@Soyad", txtSoyad.Text);
            komut.Parameters.AddWithValue("@Bolum", txtBolum.Text);
            komut.Parameters.AddWithValue("@DTarihi", dtDogum.Text);
            komut.Parameters.AddWithValue("@BaslangicTarihi", dtIsBaslangic.Text);
            komut.ExecuteNonQuery(); //sorguyu calıştır
            MessageBox.Show("Personel Başarıyla Eklendi");
            Temizle();
            VerileriGetir();
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand(
                "Delete From Tbl_YilDonumleri where Id = @Id", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@Id", txtId.Text);
            komutsil.ExecuteNonQuery();
            MessageBox.Show("Personel Başarıyla Silindi");
            Temizle();
            VerileriGetir();
        }
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Tbl_YilDonumleri set Ad=@Ad,Soyad=@Soyad,Bolum=@Bolum,DTarihi=@DTarihi,BaslangicTarihi=@BaslangicTarihi where Id=@Id", bgl.baglanti());

            komut.Parameters.AddWithValue("@Ad", txtAd.Text);
            komut.Parameters.AddWithValue("@Soyad", txtSoyad.Text);
            komut.Parameters.AddWithValue("@Bolum", txtBolum.Text);
            komut.Parameters.AddWithValue("@DTarihi", dtDogum.Text);
            komut.Parameters.AddWithValue("@BaslangicTarihi", dtIsBaslangic.Text);
            komut.Parameters.AddWithValue("@Id", txtId.Text);
            komut.ExecuteNonQuery(); 
            MessageBox.Show("Personel Başarıyla Güncellendi");
            Temizle();
            VerileriGetir();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("SELECT  * FROM [YilDonumKutlama].[dbo].[Tbl_YilDonumleri] where (Ad LIKE '%'+@Ad+'%')", bgl.baglanti());
            komut.Parameters.AddWithValue("@Ad",txtAranacakKelime.Text);
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
            dataGridView1.DataSource = yilDonumleri;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtBolum.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            dtDogum.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            dtIsBaslangic.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void VerileriGetir()
        {
            
            SqlCommand komut = new SqlCommand("SELECT  * FROM [YilDonumKutlama].[dbo].[Tbl_YilDonumleri]", bgl.baglanti());
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
            dataGridView1.DataSource = yilDonumleri;
        }

        private void Temizle()
        {
            txtId.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtBolum.Text = "";
            dtDogum.Text = "";
            dtIsBaslangic.Text = "";
        }

    }
}
