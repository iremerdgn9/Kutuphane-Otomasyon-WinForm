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
            ekleKullanicibtn.Visible = false; //ekle butonu kapalı
            silKullanicibtn.Visible = false; //sil butonu kapalı
            guncelleKullanicibtn.Visible = false;//güncelle butonu kapalı olsun demektir.
            label1.Visible = true;
            pictureBox5.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void ekleKullanicibtn_Click(object sender, EventArgs e)
        { //işlem panelinde ekle butonuna basınca kullanıcı ekle formu açılıyor ve ekleme işlemi yapıyor.
            Kullanici.KullaniciEkleForm ekleForm = new Kullanici.KullaniciEkleForm();
            ekleForm.MdiParent = this; 
            ekleForm.Show();
        }
    }
}
