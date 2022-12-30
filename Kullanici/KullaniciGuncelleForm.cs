using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane_Otomasyon_WinForm.Kullanici
{
    public partial class KullaniciGuncelleForm : Form
    {
        public KullaniciGuncelleForm()
        {
            InitializeComponent();
        } 
        KutuphaneOtomasyonEntities db = new KutuphaneOtomasyonEntities();

        public void Listele() //metot oluşturduk
        {
            var kullanicilar = db.Kullanicilar.ToList(); //kullanıcıların hepsini buraya listele
            dataGridView1.DataSource = kullanicilar.ToList();
        }
        private void KullaniciGuncelleForm_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) //hücrenin içindeki txt contente click verdik.
        {
            kullaniciAdtxt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            kullaniciSoyadtxt.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            kullaniciTctxt.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            kullaniciMailtxt.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            kullaniciTeltxt.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            kullaniciCezatxt.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

            if (dataGridView1.CurrentRow.Cells[7].Value.ToString().Equals("E"))
            {
                var unused = radioE.Checked == true;
            }
            else
            {
                var unused1 = radioK.Checked == true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int secilenId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value); //satıra tıklayınca onun id'sini verir.
            var kullanici = db.Kullanicilar.Where(x => x.kullanici_id == secilenId).FirstOrDefault(); //seçilen id'yi bul
            kullanici.kullanici_ad = kullaniciAdtxt.Text; //text değerini al ve kullanıcı ad'a aktar.
            kullanici.kullanici_soyad = kullaniciSoyadtxt.Text;
            kullanici.kullanici_tc = kullaniciTctxt.Text;
            kullanici.kullanici_tel = kullaniciTeltxt.Text;
            kullanici.kullanici_mail = kullaniciMailtxt.Text;
            kullanici.kullanici_ceza = Convert.ToDouble(kullaniciCezatxt.Text); //string olan text değerini db'de float olduğu için double'a çevirdik.
            if (radioE.Checked == true)  //radioE buttonu işaretli ise
            {
                kullanici.kullanici_cinsiyet = "Erkek";
            }
            else if (radioK.Checked == true) //radioK butonu işaretli ise
            {
                kullanici.kullanici_cinsiyet = "Kadın";
            } 
            db.SaveChanges(); // kaydet
            Listele();  //listele
        }
    }
}
