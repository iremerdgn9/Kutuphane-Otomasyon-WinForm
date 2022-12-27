using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane_Otomasyon_WinForm
{
    public partial class KullaniciSilForm : Form
    {
        public KullaniciSilForm()
        {
            InitializeComponent();
        }
        KutuphaneOtomasyonEntities db = new KutuphaneOtomasyonEntities();
        public void Listele()
        {
            var kullanicilar = db.Kullanicilar.ToList(); //kullanıcıların hepsini buraya listele
            dataGridView1.DataSource = kullanicilar.ToList(); //veritabanından datagrid veri kaynağını liste tipinde aktarır.
        }

        private void KullaniciSilForm_Load(object sender, EventArgs e)
        {
            Listele(); //bütün personelleri listeler
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int secilenId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value); 
            //silmek istediğimiz herhangi bir satırın sütünuna tıklayıp sil butonuna basınca silme işlemi yapıyor.
            var kullanici = db.Kullanicilar.Where(x => x.kullanici_id == secilenId).FirstOrDefault();
            db.Kullanicilar.Remove(kullanici);
            db.SaveChanges();
            Listele();
        }
    }
}
