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
    public partial class Form1 : Form
    {
        KutuphaneOtomasyonEntities db = new KutuphaneOtomasyonEntities();
        public Form1()
        {
            InitializeComponent();
        }
        private void personelGirisbtn_Click(object sender, EventArgs e)
        {
            string gelenAd = adGiristxt.Text;
            string gelenSifre = sifreGiristxt.Text;


            //Linq sorgusu
            var personel = db.Personeller.Where(x => x.personel_ad.Equals(gelenAd) && x.personel_sifre.Equals(gelenSifre)).FirstOrDefault();

            if (personel == null) //personel bir değer bulamadıysa
            {
                MessageBox.Show(text: "Kullanıcı adı veya şifre hatalı!");
            }
            else
            {
                MessageBox.Show(text: "Başarılı :)");
                //işlem başarılı olursa paneli açabilecek.
                IslemPaneli panel = new IslemPaneli(); //form ismimizi çağırıp nesne oluşturuyoruz.
                panel.Show();   //butona basınca paneli göster
                this.Hide();    //bu formu kapat
            }
    }
    }
}
