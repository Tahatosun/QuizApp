namespace YazılımSınamaOdevi
{
    partial class GirisEkrani
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
            this.lblKullaniciAdi = new MetroFramework.Controls.MetroLabel();
            this.lblSifre = new MetroFramework.Controls.MetroLabel();
            this.txtBxKullaniciAdi = new MetroFramework.Controls.MetroTextBox();
            this.txtBxSifre = new MetroFramework.Controls.MetroTextBox();
            this.radioBtnOgrenci = new MetroFramework.Controls.MetroRadioButton();
            this.radioButtonOgretmen = new MetroFramework.Controls.MetroRadioButton();
            this.tileGirisYap = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // lblKullaniciAdi
            // 
            this.lblKullaniciAdi.AutoSize = true;
            this.lblKullaniciAdi.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblKullaniciAdi.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblKullaniciAdi.Location = new System.Drawing.Point(91, 142);
            this.lblKullaniciAdi.Name = "lblKullaniciAdi";
            this.lblKullaniciAdi.Size = new System.Drawing.Size(124, 25);
            this.lblKullaniciAdi.TabIndex = 0;
            this.lblKullaniciAdi.Text = "Kullanıcı Adı:";
            // 
            // lblSifre
            // 
            this.lblSifre.AutoSize = true;
            this.lblSifre.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblSifre.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblSifre.Location = new System.Drawing.Point(159, 178);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new System.Drawing.Size(56, 25);
            this.lblSifre.TabIndex = 1;
            this.lblSifre.Text = "Şifre:";
            // 
            // txtBxKullaniciAdi
            // 
            this.txtBxKullaniciAdi.Location = new System.Drawing.Point(221, 145);
            this.txtBxKullaniciAdi.Name = "txtBxKullaniciAdi";
            this.txtBxKullaniciAdi.Size = new System.Drawing.Size(142, 23);
            this.txtBxKullaniciAdi.TabIndex = 2;
            // 
            // txtBxSifre
            // 
            this.txtBxSifre.Location = new System.Drawing.Point(221, 180);
            this.txtBxSifre.Name = "txtBxSifre";
            this.txtBxSifre.PasswordChar = '*';
            this.txtBxSifre.Size = new System.Drawing.Size(142, 23);
            this.txtBxSifre.TabIndex = 3;
            // 
            // radioBtnOgrenci
            // 
            this.radioBtnOgrenci.AutoSize = true;
            this.radioBtnOgrenci.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.radioBtnOgrenci.Location = new System.Drawing.Point(112, 95);
            this.radioBtnOgrenci.Name = "radioBtnOgrenci";
            this.radioBtnOgrenci.Size = new System.Drawing.Size(103, 25);
            this.radioBtnOgrenci.TabIndex = 4;
            this.radioBtnOgrenci.TabStop = true;
            this.radioBtnOgrenci.Text = "ÖĞRENCİ";
            this.radioBtnOgrenci.UseVisualStyleBackColor = true;
            // 
            // radioButtonOgretmen
            // 
            this.radioButtonOgretmen.AutoSize = true;
            this.radioButtonOgretmen.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.radioButtonOgretmen.Location = new System.Drawing.Point(241, 95);
            this.radioButtonOgretmen.Name = "radioButtonOgretmen";
            this.radioButtonOgretmen.Size = new System.Drawing.Size(121, 25);
            this.radioButtonOgretmen.TabIndex = 5;
            this.radioButtonOgretmen.TabStop = true;
            this.radioButtonOgretmen.Text = "ÖĞRETMEN";
            this.radioButtonOgretmen.UseVisualStyleBackColor = true;
            // 
            // tileGirisYap
            // 
            this.tileGirisYap.Location = new System.Drawing.Point(91, 221);
            this.tileGirisYap.Name = "tileGirisYap";
            this.tileGirisYap.Size = new System.Drawing.Size(272, 56);
            this.tileGirisYap.TabIndex = 6;
            this.tileGirisYap.Text = "GİRİŞ YAP";
            this.tileGirisYap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tileGirisYap.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.tileGirisYap.Click += new System.EventHandler(this.tileGirisYap_Click);
            // 
            // GirisEkrani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 353);
            this.Controls.Add(this.tileGirisYap);
            this.Controls.Add(this.radioButtonOgretmen);
            this.Controls.Add(this.radioBtnOgrenci);
            this.Controls.Add(this.txtBxSifre);
            this.Controls.Add(this.txtBxKullaniciAdi);
            this.Controls.Add(this.lblSifre);
            this.Controls.Add(this.lblKullaniciAdi);
            this.Name = "GirisEkrani";
            this.Text = "Giriş Ekranı";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblKullaniciAdi;
        private MetroFramework.Controls.MetroLabel lblSifre;
        private MetroFramework.Controls.MetroTextBox txtBxKullaniciAdi;
        private MetroFramework.Controls.MetroTextBox txtBxSifre;
        private MetroFramework.Controls.MetroRadioButton radioBtnOgrenci;
        private MetroFramework.Controls.MetroRadioButton radioButtonOgretmen;
        private MetroFramework.Controls.MetroTile tileGirisYap;
    }
}

