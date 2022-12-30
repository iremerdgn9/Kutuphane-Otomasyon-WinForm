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
    public partial class KaynakGuncelleForm : Form
    {
        public KaynakGuncelleForm()
        {
            InitializeComponent();
        }
        KutuphaneOtomasyonEntities db = new KutuphaneOtomasyonEntities();
        public void Listele()
        {
            var kullanicilar = db.Kullanicilar.ToList(); //kullanıcıların hepsini buraya listele
            dataGridView1.DataSource = kullanicilar.ToList(); //veritabanından datagrid veri kaynağını liste tipinde aktarır.
        }
        private void KaynakGuncelleForm_Load(object sender, EventArgs e)
        {
            var kaynaklar = db.Kaynaklar.ToList();
            dataGridView1.DataSource = kaynaklar.ToList(); //güncelle kaynaklar listelenecek
            Listele();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) //direkt hücreye mouse click verdik.
        {
            adKaynaktxt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString(); //obje türünde olduğu için stringe çevirdik
            yazarKaynaktxt.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            yayıneviKaynaktxt.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            numericUpDown1.Value = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[4].Value);
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[5].Value);
            türKaynaktxt.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e) //güncelle butonu 
        {
            int secilenKaynak = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value); //güncellenecek kaynağın id'sini bulduk
            var guncellenecekKaynak = db.Kaynaklar.Where(x => x.kaynak_id == secilenKaynak).FirstOrDefault(); //seçilen kaynağın id'sini bulur.
            guncellenecekKaynak.kaynak_ad = adKaynaktxt.Text;
            guncellenecekKaynak.kaynak_yazar = yazarKaynaktxt.Text;
            guncellenecekKaynak.kaynak_yayınevi = yayıneviKaynaktxt.Text;
            guncellenecekKaynak.kaynak_sayfasayisi = Convert.ToInt32(numericUpDown1.Value); //decimal değeri int'e çevirdik
            guncellenecekKaynak.kaynak_basımtarihi = dateTimePicker1.Value;
            db.SaveChanges();

            var kaynaklar = db.Kaynaklar.ToList();
            dataGridView1.DataSource = kaynaklar.ToList(); //güncelle kaynaklar listelenecek

        }
    }
}
