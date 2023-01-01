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
            var kayitlar = db.Kayitlar.Where(x => x.durum == false).ToList(); //Kayıtlar tablosundaki durumu false olanları(geri getirmeyenleri) listele
            dataGridView1.DataSource = kayitlar.ToList();
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
