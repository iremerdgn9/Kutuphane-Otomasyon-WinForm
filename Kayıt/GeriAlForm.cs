using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane_Otomasyon_WinForm.Kayıt
{
    public partial class GeriAlForm : Form
    {
        public GeriAlForm()
        {
            InitializeComponent();
        }
        KutuphaneOtomasyonEntities db = new KutuphaneOtomasyonEntities();

        private void GeriAlForm_Load(object sender, EventArgs e)
        {
            var kayitList = from kayit in db.Kayitlar
                            select new { kayit.kayıt_id,kayit.Kullanicilar.kullanici_id,kayit.Kullanicilar.kullanici_ad,kayit.kitap_id, kayit.Kaynaklar.kaynak_ad, kayit.alis_tarih, kayit.son_tarih, kayit.durum };

            var kayitlar = db.Kayitlar.Where(x => x.durum == false).ToList(); //Kayıtlar tablosundaki durumu false olanları(geri getirmeyenleri) listele
            dataGridView1.DataSource = kayitlar.ToList();

            //listelenmeyen kaynak ve kullanıcı kolonunu gizledik
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e) //geri al butonu
        {
            int secilenKayitId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            var kayit = db.Kayitlar.Where(x => x.kayıt_id == secilenKayitId).FirstOrDefault(); //kayıt id'si seçilen kayıt id olanı bul
            kayit.durum = true;
            //db.SaveChanges(); savechange burda olursa geri al butonuna basınca direk true yapıp listeden çıkarır.

            //liste tazele
            var kayitlar = db.Kayitlar.Where(x => x.durum == false).ToList(); //Kayıtlar tablosundaki durumu false olanları(geri getirmeyenleri) listele
            dataGridView1.DataSource = kayitlar.ToList(); //durumu false olanlar kitaplarını geri verdiğinde true oluyor
            db.SaveChanges();

        }
    }
}
