﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane_Otomasyon_WinForm.Kaynak
{
    public partial class KaynakEkleForm : Form
    {
        public KaynakEkleForm()
        {
            InitializeComponent();
        }
        KutuphaneOtomasyonEntities db = new KutuphaneOtomasyonEntities();

        private void button1_Click(object sender, EventArgs e)
        {
            Kaynaklar kaynaklar = new Kaynaklar();
            kaynaklar.kaynak_ad = adKaynaktxt.Text;
            kaynaklar.kaynak_yazar = yazarKaynaktxt.Text;
            kaynaklar.kaynak_yayınevi = yayıneviKaynaktxt.Text;
            kaynaklar.kaynak_sayfasayisi =Convert.ToInt32(numericUpDown1.Value);
            kaynaklar.kaynak_basımtarihi = dateTimePicker1.Value; //datetime türü
            kaynaklar.kaynak_türü = türKaynaktxt.Text;
            db.Kaynaklar.Add(kaynaklar);
            db.SaveChanges();

            var kliste = db.Kaynaklar.ToList();
            dataGridView1.DataSource = kliste.ToList();
        }
        public void Listele()
        {
            var kullanicilar = db.Kullanicilar.ToList(); //kullanıcıların hepsini buraya listele
            dataGridView1.DataSource = kullanicilar.ToList(); //veritabanından datagrid veri kaynağını liste tipinde aktarır.
        }
        private void KaynakEkleForm_Load(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
