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
    public partial class KullaniciEkleForm : Form
    {
        public KullaniciEkleForm()
        {
            InitializeComponent();
        }
        KutuphaneOtomasyonEntities db = new KutuphaneOtomasyonEntities();

        public void Listele()
        {
            var kullanicilar = db.Kullanicilar.ToList(); //kullanıcıların hepsini buraya listele
            dataGridView1.DataSource = kullanicilar.ToList();
        }
        private void KullaniciEkleForm_Load(object sender, EventArgs e)
        {
            Listele(); //Kullanicilar artık formda listelenecek.

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kullanicilar kullanicilar = new Kullanicilar();  //Kullanicilar'dan yeni bir nesne oluşturduk.
            kullanicilar.kullanici_ad = kullaniciAdtxt.Text;
            kullanicilar.kullanici_soyad = kullaniciSoyadtxt.Text;
            kullanicilar.kullanici_tc = kullaniciTctxt.Text;
            kullanicilar.kullanici_tel = kullaniciTeltxt.Text;
            kullanicilar.kullanici_mail = kullaniciMailtxt.Text;
            kullanicilar.kullanici_ceza = Convert.ToDouble(kullaniciCezatxt.Text); //string olan text değerini db'de float olduğu için double'a çevirdik.
            if (radioE.Checked == true)  //radioE buttonu işaretli ise
            {
                kullanicilar.kullanici_cinsiyet = "Erkek";
            }
            else if (radioK.Checked == true) //radioK butonu işaretli ise
            {
                kullanicilar.kullanici_cinsiyet = "Kadın";
            }
            //else
            //{
            //    MessageBox.Show("Lütfen Cinsiyet Seçiniz!!"); //hiçbiri değilse mesaj gönderir.
            //}
            db.Kullanicilar.Add(kullanicilar); //verileri kullanicilar nesnemizin içine aktarıyoruz.
            db.SaveChanges(); //değişiklikleri kaydeder.
            Listele(); //listeyi yeniler gibi oldu.
        }
    }
}
