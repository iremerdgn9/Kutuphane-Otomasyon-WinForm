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
        KullaniciListeForm kListeForm = new KullaniciListeForm();
        /// <summary>
        /// kullanıcı liste ve butonları açar 
        /// </summary>
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
                kListeForm.MdiParent = this; //bunun parent'i IslemPaneli'idir.
                kListeForm.Show(); //işlem panelinin içinde açılacak.
            }
            else
            {
                ekleKullanicibtn.Visible = false; //kullanıcı butonu açıksa kapanır yani basılmazsa kapalı konumda olacaklar.
                silKullanicibtn.Visible = false;
                guncelleKullanicibtn.Visible = false;
                label1.Visible = true;
                pictureBox5.Visible = true;
                kListeForm.Close(); //listeyi kapatır.
            }
        }

        private Kullanici.KullaniciEkleForm ekleForm;
        private bool ekleKullaniciDurum = false;
        private void EkleKullanicibtn_Click(object sender, EventArgs e)
        { //işlem panelinde ekle butonuna basınca kullanıcı ekle formu açılıyor ve ekleme işlemi yapıyor.
            if (ekleKullaniciDurum == false)
            {
                ekleForm = new Kullanici.KullaniciEkleForm();
                ekleForm.MdiParent = this;
                ekleForm.Show();
                ekleKullaniciDurum = true;
            }
            else
            {
                ekleForm.Close();
                ekleKullaniciDurum = false;
            }
        }
        private KullaniciSilForm kSil;
        private bool silKullaniciDurum = false;
        private void silKullanicibtn_Click(object sender, EventArgs e)
        {
            if (silKullaniciDurum == false) //her tıkladığımızda form açılmasını engelledik
            {
                kSil = new KullaniciSilForm(); //sil butonuna tıkladığımızda sil formu açılacak.
                kSil.MdiParent = this;
                kSil.Show();
                silKullaniciDurum = true;
            }
            else
            {
                kSil.Close();
                silKullaniciDurum = false;
            }
        }
        private Kullanici.KullaniciGuncelleForm kGuncel;
        private bool guncelleKullaniciDurum = false;
        private void guncelleKullanicibtn_Click(object sender, EventArgs e)
        {
            if (guncelleKullaniciDurum == false)
            {
                 kGuncel = new Kullanici.KullaniciGuncelleForm();
                 kGuncel.MdiParent = this;
                 kGuncel.Show();
                 guncelleKullaniciDurum = true;
            }
            else
            {
                kGuncel.Close();
                guncelleKullaniciDurum = false; //guncelle butonuna her tıkladığımızda sürekli form açılmasını önledik.
            }

        }

        Kaynak.KaynakListeForm kliste = new Kaynak.KaynakListeForm();
        private void button2_Click(object sender, EventArgs e) //kaynaklar butonu
        {
            if (ekleKaynakbtn.Visible == false) 
            {
                ekleKaynakbtn.Visible = true;
                silKaynakbtn.Visible = true;
                guncelleKaynakbtn.Visible = true;
                pictureBox5.Visible = false;
                kliste.MdiParent = this;
                kliste.Show();
            }
            else
            {
                ekleKaynakbtn.Visible = false;
                silKaynakbtn.Visible = false;
                guncelleKaynakbtn.Visible = false;
                pictureBox5.Visible = true;
                kliste.Close();
            }
        }
        private Kaynak.KaynakEkleForm kEkle;
        private bool ekleKaynakDurum = false;
        private void ekleKaynakbtn_Click(object sender, EventArgs e)
        { //ekle butonuna basınca kaynak ekle formundan kaynak ekleme işlemi yapılacak.
            if (ekleKaynakDurum == false)
            {
                kEkle= new Kaynak.KaynakEkleForm();
                kEkle.MdiParent = this;
                kEkle.Show();
                ekleKaynakDurum = true;
            }
            else
            {
                kEkle.Close();
                ekleKaynakDurum = false;
            }
        }

        private Kaynak.KaynakSilForm kaynakSil;
        private bool silKaynakDurum = false;
        private void silKaynakbtn_Click(object sender, EventArgs e)
        {
            if (silKaynakDurum == false)
            {
                kaynakSil = new Kaynak.KaynakSilForm();
                kaynakSil.MdiParent = this;
                kaynakSil.Show();
                silKaynakDurum = true;
            }
            else
            {
                kaynakSil.Close();
                silKaynakDurum = false;
            }
            
        }

        private Kaynak.KaynakGuncelleForm kaynakGuncel;
        private bool guncelleKaynakDurum = false;
        private void guncelleKaynakbtn_Click(object sender, EventArgs e)
        {
            if (guncelleKaynakDurum == false)
            {
                kaynakGuncel = new Kaynak.KaynakGuncelleForm(); 
                kaynakGuncel.MdiParent = this;
                kaynakGuncel.Show();
                guncelleKaynakDurum = true;
            }
            else
            {
                kaynakGuncel.Close();
                guncelleKaynakDurum = false;
            }
           
        }

        private Kayıt.OduncVerForm odunc;
        private bool oduncVerDurum = false;
        private void button3_Click(object sender, EventArgs e) //ödünç ver butonu
        {
            if (oduncVerDurum == false)
            {
                odunc= new Kayıt.OduncVerForm();
                pictureBox5.Visible = false;
                odunc.MdiParent = this;
                odunc.Show();
                oduncVerDurum = true;
            }
            else
            {
                pictureBox5.Visible = true;
                odunc.Close();
                oduncVerDurum = false;
            }
        }

        private Kayıt.GeriAlForm geri;
        private bool geriAlDurum = false;
        private void button4_Click(object sender, EventArgs e) //geri al butonu
        {
            if (geriAlDurum == false)
            {
                geri = new Kayıt.GeriAlForm();
                pictureBox5.Visible = false;
                geri.MdiParent = this;
                geri.Show();
                geriAlDurum = true;
            }
            else
            {
                pictureBox5.Visible = true;
                geri.Close();
                geriAlDurum = false;
            }
           
        }
    }
}
