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
        private void KaynakGuncelleForm_Load(object sender, EventArgs e)
        {
            var kaynaklar = db.Kaynaklar.ToList();
            dataGridView1.DataSource = kaynaklar.ToList(); //güncelle kaynaklar listelenecek

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
