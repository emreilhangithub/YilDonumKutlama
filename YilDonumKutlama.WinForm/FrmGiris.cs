using System;
using System.Windows.Forms;
using YilDonumKutlama.WinForm.Helper;

namespace YilDonumKutlama.WinForm
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void btnBilgileriKaydet_Click(object sender, EventArgs e)
        {
                Global.BilgisayarAdi = txtBilgisayarAdi.Text;
                Global.VeriTabani = txtVeriTabani.Text;
                Global.KullaniciAdi = txtKullaniciAdi.Text;
                Global.Sifre = txtSifre.Text;
                MessageBox.Show("Bilgiler Başarıyla Kayıt Edildi");
            
                FrmPersonel frm = new FrmPersonel();
                this.Hide();
                frm.Show();
        }
    }
}
