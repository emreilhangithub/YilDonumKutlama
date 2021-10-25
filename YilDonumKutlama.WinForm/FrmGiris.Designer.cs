
namespace YilDonumKutlama.WinForm
{
    partial class FrmGiris
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtBilgisayarAdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVeriTabani = new System.Windows.Forms.TextBox();
            this.btnBilgileriKaydet = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtBilgisayarAdi
            // 
            this.txtBilgisayarAdi.Location = new System.Drawing.Point(164, 12);
            this.txtBilgisayarAdi.Name = "txtBilgisayarAdi";
            this.txtBilgisayarAdi.Size = new System.Drawing.Size(100, 20);
            this.txtBilgisayarAdi.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bilgisayar Adı =";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Veri Tabanı =";
            // 
            // txtVeriTabani
            // 
            this.txtVeriTabani.Location = new System.Drawing.Point(164, 38);
            this.txtVeriTabani.Name = "txtVeriTabani";
            this.txtVeriTabani.Size = new System.Drawing.Size(100, 20);
            this.txtVeriTabani.TabIndex = 2;
            // 
            // btnBilgileriKaydet
            // 
            this.btnBilgileriKaydet.Location = new System.Drawing.Point(131, 126);
            this.btnBilgileriKaydet.Name = "btnBilgileriKaydet";
            this.btnBilgileriKaydet.Size = new System.Drawing.Size(133, 23);
            this.btnBilgileriKaydet.TabIndex = 4;
            this.btnBilgileriKaydet.Text = "Bilgileri Kaydet";
            this.btnBilgileriKaydet.UseVisualStyleBackColor = true;
            this.btnBilgileriKaydet.Click += new System.EventHandler(this.btnBilgileriKaydet_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Kullanıcı Adı=";
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Location = new System.Drawing.Point(164, 64);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(100, 20);
            this.txtKullaniciAdi.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Sifre =";
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(164, 90);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(100, 20);
            this.txtSifre.TabIndex = 7;
            // 
            // FrmGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 161);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtKullaniciAdi);
            this.Controls.Add(this.btnBilgileriKaydet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtVeriTabani);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBilgisayarAdi);
            this.Name = "FrmGiris";
            this.Text = "FrmGiris";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBilgisayarAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVeriTabani;
        private System.Windows.Forms.Button btnBilgileriKaydet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSifre;
    }
}