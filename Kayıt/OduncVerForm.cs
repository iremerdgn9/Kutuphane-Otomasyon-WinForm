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
    public partial class OduncVerForm : Form
    {
        public OduncVerForm()
        {
            InitializeComponent();
        }
        KutuphaneOtomasyonEntities db = new KutuphaneOtomasyonEntities();

        private void OduncVerForm_Load(object sender, EventArgs e)
        {
            var kayitList = from kayit in db.Kayitlar
                            select new { kayit.Kullanicilar.kullanici_ad, kayit.Kaynaklar.kaynak_ad, kayit.alis_tarih, kayit.son_tarih, kayit.durum };
            ////kayıtlar listeledik
            //var kayitList = db.Kayitlar.ToList();
            dataGridView1.DataSource = kayitList.ToList();

            ////kaynaklar listeledik
            var kaynakList = db.Kaynaklar.ToList();
            dataGridView2.DataSource = kaynakList.ToList();


            ////listelenmeyen kaynak ve kullanıcı kolonunu gizledik
            //dataGridView1.Columns[6].Visible = false;
            //dataGridView1.Columns[7].Visible = false;
            //dataGridView2.Columns[8].Visible = false;

            ////kolon adlarını düzenledik
            //dataGridView1.Columns[1].HeaderText = "Kullanıcı";
            //dataGridView1.Columns[2].HeaderText = "Kaynak Ad";

        }

        private void button1_Click(object sender, EventArgs e) //girilen tc ile kullanıcı arama yaptık
        {
            string arananSecilen = TCBultxt.Text;
            var kullaniciVarmi = db.Kullanicilar.Where(x => x.kullanici_tc == arananSecilen).FirstOrDefault();

            if (kullaniciVarmi != null) //kullanıcı varmı diye sorgulama yapıyoruz varsa
                label2.Text = kullaniciVarmi.kullanici_ad + " " + kullaniciVarmi.kullanici_soyad;
            else //eğer yoksa 
                label2.Text = "böyle bir kullanıcı yok!...";

        }

        private void textBox1_TextChanged(object sender, EventArgs e) //filtreleme işlemini kaynak_ad'ı ile yapıp arama işlemi yapıyoruz.
        {
            string gelenAd = textBox1.Text; //kitabın ismini aldık
            var bulunanKaynaklar = db.Kaynaklar.Where(x => x.kaynak_ad.Contains(gelenAd)).ToList(); //textboxtan gelen değeri herhangi bir kitabın isminde bu değerler geçiyor mu diye dbden sorguladık.
            dataGridView2.DataSource = bulunanKaynaklar; //bulunankaynakları datagrid'te görünmesini sağladık 

        }

        private void button2_Click(object sender, EventArgs e) //ödünç ver butonu
        {
            //kişiyi aldık
            string secilenKisiTC = TCBultxt.Text; //tc'yi aldık
            var secilenKisi = db.Kullanicilar.Where(x => x.kullanici_tc.Equals(secilenKisiTC)).FirstOrDefault(); //tcsi seçilen kişinin tc'sine eşit olanı bul

            //kitabı aldık
            int secilenKitapId = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value); //idyi aldık
            var secilenKitap = db.Kaynaklar.Where(x => x.kaynak_id == secilenKitapId).FirstOrDefault();


            Kayitlar yeniKayit = new Kayitlar();
            yeniKayit.kitap_id = secilenKitap.kaynak_id;  //kitap_id secilenKitaptan gelir
            yeniKayit.kullanici_id = secilenKisi.kullanici_id;  //kullanici_id secilenkisiden gelir
            yeniKayit.Kullanicilar.kullanici_ad = secilenKisi.kullanici_ad;
            yeniKayit.alis_tarih = DateTime.Today;  //bugünün tarihi ile alsın
            yeniKayit.son_tarih = DateTime.Today.AddDays(15); //15 gün sonrası için son tarih hesaplıyor
            yeniKayit.durum = false;
            db.Kayitlar.Add(yeniKayit); //yenikayitları ekledik
            db.SaveChanges(); //değişiklikleri kaydeder

            var kayitList = db.Kayitlar.ToList();
            dataGridView1.DataSource = kayitList.ToList(); //listeledikten sonra kayıtları tekrar göster
        }
    }
}
