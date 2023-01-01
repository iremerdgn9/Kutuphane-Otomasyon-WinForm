using System;
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
            var kaynaklar = db.Kaynaklar.ToList(); //kullanıcıların hepsini buraya listele
            dataGridView1.DataSource = kaynaklar.ToList(); //veritabanından datagrid veri kaynağını liste tipinde aktarır.

            dataGridView1.Columns[0].Visible = false; //0.sütun yani kullanıcı_id görünmesin.(gizledik)
            dataGridView1.Columns[7].Visible = false; //7.sütun yani kayıtlar görünmesin.

            //Sütunların isimlerini değiştirdik.
            dataGridView1.Columns[1].HeaderText = "Kaynak Adı";
            dataGridView1.Columns[2].HeaderText = "Yazar";
            dataGridView1.Columns[3].HeaderText = "Yayınevi";
            dataGridView1.Columns[4].HeaderText = "Sayfa Sayısı";
            dataGridView1.Columns[5].HeaderText = "Basım Tarihi";
            dataGridView1.Columns[6].HeaderText = "Kaynak Türü";
        }
        private void KaynakEkleForm_Load(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
