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
    public partial class IslemPaneli : Form
    {
        public IslemPaneli()
        {
            InitializeComponent();
        }
        KutuphaneOtomasyonEntities db = new KutuphaneOtomasyonEntities();
        private void IslemPaneli_Load(object sender, EventArgs e)
        {
            //kullanıcı butonları girişte kapalıdır. (ekle-güncelle-sil)
            ekleKullanicibtn.Visible = false; //ekle butonu kapalı
            silKullanicibtn.Visible = false; //sil butonu kapalı
            guncelleKullanicibtn.Visible = false;//güncelle butonu kapalı olsun demektir.
            //kaynak butonları girişte kapalıdır (ekle-güncelle-sil)
            ekleKaynakbtn.Visible = false;
            silKaynakbtn.Visible = false;
            guncelleKaynakbtn.Visible = false;


            label1.Visible = true;
            pictureBox5.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e) //kullanıcılar butonu
        {
            if (ekleKullanicibtn.Visible == false)
            {
                ekleKullanicibtn.Visible = true; //kullanıcılar butonuna basılınca açılacak demektir.
                silKullanicibtn.Visible = true;
                guncelleKullanicibtn.Visible = true;
                label1.Visible = true;
                pictureBox1.Visible = false;
                pictureBox5.Visible = false;
            }
            else
            {
                ekleKullanicibtn.Visible = false; //kullanıcı butonu açıksa kapanır yani basılmazsa kapalı konumda olacaklar.
                silKullanicibtn.Visible = false;
                guncelleKullanicibtn.Visible = false;
                label1.Visible = true;
                pictureBox5.Visible = true;
            }
            KullaniciListeForm kListeForm = new KullaniciListeForm();
            kListeForm.MdiParent = this; //bunun parent'i IslemPaneli'idir.
            kListeForm.Show(); //işlem panelinin içinde açılacak.
        }

        private void EkleKullanicibtn_Click(object sender, EventArgs e)
        { //işlem panelinde ekle butonuna basınca kullanıcı ekle formu açılıyor ve ekleme işlemi yapıyor.
            Kullanici.KullaniciEkleForm ekleForm= new Kullanici.KullaniciEkleForm();
            ekleForm.MdiParent = this;
            ekleForm.Show();
        }

        private void silKullanicibtn_Click(object sender, EventArgs e)
        {
            KullaniciSilForm kSil = new KullaniciSilForm(); //sil butonuna tıkladığımızda sil formu açılacak.
            kSil.MdiParent = this;
            kSil.Show();
        }

        private void guncelleKullanicibtn_Click(object sender, EventArgs e)
        {
            Kullanici.KullaniciGuncelleForm kGuncel = new Kullanici.KullaniciGuncelleForm();
            kGuncel.MdiParent = this;
            kGuncel.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ekleKaynakbtn.Visible == false) 
            {
                ekleKaynakbtn.Visible = true;
                silKaynakbtn.Visible = true;
                guncelleKaynakbtn.Visible = true;
                pictureBox5.Visible = false;

            }
            else
            {
                ekleKaynakbtn.Visible = false;
                silKaynakbtn.Visible = false;
                guncelleKaynakbtn.Visible = false;
                pictureBox5.Visible = true;

            }

            Kaynak.KaynakListeForm kliste = new Kaynak.KaynakListeForm();
            kliste.MdiParent = this;
            kliste.Show();
        }

        private void ekleKaynakbtn_Click(object sender, EventArgs e)
        { //ekle butonuna basınca kaynak ekle formundan kaynak ekleme işlemi yapılacak.
            Kaynak.KaynakEkleForm kEkle= new Kaynak.KaynakEkleForm();
            kEkle.MdiParent = this;
            kEkle.Show();

        }

        private void silKaynakbtn_Click(object sender, EventArgs e)
        {
            Kaynak.KaynakSilForm kSil = new Kaynak.KaynakSilForm();
            kSil.MdiParent = this;
            kSil.Show();
        }

        private void guncelleKaynakbtn_Click(object sender, EventArgs e)
        {
            Kaynak.KaynakGuncelleForm kGuncel = new Kaynak.KaynakGuncelleForm(); 
            kGuncel.MdiParent = this;
            kGuncel.Show();
        }

        private void button3_Click(object sender, EventArgs e) //ödünç ver butonu
        {
            pictureBox5.Visible = false;

            Kayıt.OduncVerForm odunc = new Kayıt.OduncVerForm();
            odunc.MdiParent = this;
            odunc.Show();
        }

        private void button4_Click(object sender, EventArgs e) //geri al butonu
        {
            Kayıt.GeriAlForm geri = new Kayıt.GeriAlForm();
            geri.MdiParent = this;
            geri.Show();
        }
    }
}
