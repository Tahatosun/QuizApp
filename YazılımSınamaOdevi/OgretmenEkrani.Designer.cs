namespace YazılımSınamaOdevi
{
    partial class OgretmenEkrani
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
            this.btnKaydet = new MetroFramework.Controls.MetroTile();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.cmbBxSoruTuru = new MetroFramework.Controls.MetroComboBox();
            this.cmbBoxDogruCevap = new MetroFramework.Controls.MetroComboBox();
            this.lblDogruCevap = new MetroFramework.Controls.MetroLabel();
            this.ogretmenEkraniSoruTuru4 = new YazılımSınamaOdevi.OgretmenEkraniSoruTuru4();
            this.ogretmenEkraniSoruTuru3 = new YazılımSınamaOdevi.OgretmenEkraniSoruTuru3();
            this.ogretmenEkraniSoruTuru2 = new YazılımSınamaOdevi.OgretmenEkraniSoruTuru2();
            this.ogretmenEkraniSoruTuru1 = new YazılımSınamaOdevi.OgretmenEkraniSoruTuru1();
            this.SuspendLayout();
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(35, 878);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(1014, 46);
            this.btnKaydet.TabIndex = 23;
            this.btnKaydet.Text = "KAYDET";
            this.btnKaydet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnKaydet.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(675, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(67, 19);
            this.metroLabel1.TabIndex = 24;
            this.metroLabel1.Text = "Soru Türü:";
            // 
            // cmbBxSoruTuru
            // 
            this.cmbBxSoruTuru.FormattingEnabled = true;
            this.cmbBxSoruTuru.ItemHeight = 23;
            this.cmbBxSoruTuru.Items.AddRange(new object[] {
            "Sadece Yazı",
            "Yazı + Soru Resmi",
            "Yazı + Soru Resmi + Resimli Sık",
            "Yazı + Resimli Sık"});
            this.cmbBxSoruTuru.Location = new System.Drawing.Point(748, 50);
            this.cmbBxSoruTuru.Name = "cmbBxSoruTuru";
            this.cmbBxSoruTuru.Size = new System.Drawing.Size(248, 29);
            this.cmbBxSoruTuru.TabIndex = 25;
            this.cmbBxSoruTuru.SelectedIndexChanged += new System.EventHandler(this.cmbBxSoruTuru_SelectedIndexChanged);
            // 
            // cmbBoxDogruCevap
            // 
            this.cmbBoxDogruCevap.FormattingEnabled = true;
            this.cmbBoxDogruCevap.ItemHeight = 23;
            this.cmbBoxDogruCevap.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D"});
            this.cmbBoxDogruCevap.Location = new System.Drawing.Point(567, 50);
            this.cmbBoxDogruCevap.Name = "cmbBoxDogruCevap";
            this.cmbBoxDogruCevap.Size = new System.Drawing.Size(67, 29);
            this.cmbBoxDogruCevap.TabIndex = 31;
            // 
            // lblDogruCevap
            // 
            this.lblDogruCevap.AutoSize = true;
            this.lblDogruCevap.Location = new System.Drawing.Point(459, 60);
            this.lblDogruCevap.Name = "lblDogruCevap";
            this.lblDogruCevap.Size = new System.Drawing.Size(102, 19);
            this.lblDogruCevap.TabIndex = 30;
            this.lblDogruCevap.Text = "DOGRU CEVAP:";
            // 
            // ogretmenEkraniSoruTuru4
            // 
            this.ogretmenEkraniSoruTuru4.Location = new System.Drawing.Point(9, 100);
            this.ogretmenEkraniSoruTuru4.Name = "ogretmenEkraniSoruTuru4";
            this.ogretmenEkraniSoruTuru4.Size = new System.Drawing.Size(1055, 647);
            this.ogretmenEkraniSoruTuru4.TabIndex = 29;
            this.ogretmenEkraniSoruTuru4.Visible = false;
            // 
            // ogretmenEkraniSoruTuru3
            // 
            this.ogretmenEkraniSoruTuru3.Location = new System.Drawing.Point(24, 94);
            this.ogretmenEkraniSoruTuru3.Name = "ogretmenEkraniSoruTuru3";
            this.ogretmenEkraniSoruTuru3.Size = new System.Drawing.Size(1009, 778);
            this.ogretmenEkraniSoruTuru3.TabIndex = 28;
            this.ogretmenEkraniSoruTuru3.Visible = false;
            // 
            // ogretmenEkraniSoruTuru2
            // 
            this.ogretmenEkraniSoruTuru2.Location = new System.Drawing.Point(21, 103);
            this.ogretmenEkraniSoruTuru2.Name = "ogretmenEkraniSoruTuru2";
            this.ogretmenEkraniSoruTuru2.Size = new System.Drawing.Size(1014, 599);
            this.ogretmenEkraniSoruTuru2.TabIndex = 27;
            this.ogretmenEkraniSoruTuru2.Visible = false;
            // 
            // ogretmenEkraniSoruTuru1
            // 
            this.ogretmenEkraniSoruTuru1.Location = new System.Drawing.Point(9, 124);
            this.ogretmenEkraniSoruTuru1.Name = "ogretmenEkraniSoruTuru1";
            this.ogretmenEkraniSoruTuru1.Size = new System.Drawing.Size(1024, 486);
            this.ogretmenEkraniSoruTuru1.TabIndex = 26;
            this.ogretmenEkraniSoruTuru1.Visible = false;
            // 
            // OgretmenEkrani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 932);
            this.Controls.Add(this.cmbBoxDogruCevap);
            this.Controls.Add(this.lblDogruCevap);
            this.Controls.Add(this.ogretmenEkraniSoruTuru4);
            this.Controls.Add(this.ogretmenEkraniSoruTuru3);
            this.Controls.Add(this.ogretmenEkraniSoruTuru2);
            this.Controls.Add(this.ogretmenEkraniSoruTuru1);
            this.Controls.Add(this.cmbBxSoruTuru);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.btnKaydet);
            this.Name = "OgretmenEkrani";
            this.Text = "OgretmenEkrani";
            this.Load += new System.EventHandler(this.OgretmenEkrani_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroTile btnKaydet;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox cmbBxSoruTuru;
        private OgretmenEkraniSoruTuru1 ogretmenEkraniSoruTuru1;
        private OgretmenEkraniSoruTuru2 ogretmenEkraniSoruTuru2;
        private OgretmenEkraniSoruTuru3 ogretmenEkraniSoruTuru3;
        private OgretmenEkraniSoruTuru4 ogretmenEkraniSoruTuru4;
        private MetroFramework.Controls.MetroComboBox cmbBoxDogruCevap;
        private MetroFramework.Controls.MetroLabel lblDogruCevap;
    }
}