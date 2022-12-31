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
            //kayıtlar listeledik
            var kayitList = db.Kayitlar.ToList();
            dataGridView1.DataSource = kayitList.ToList();

            //kaynaklar listeledik
            var kaynakList = db.Kaynaklar.ToList();
            dataGridView2.DataSource = kaynakList.ToList();


            //listelenmeyen kaynak ve kullanıcı kolonunu gizledik
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;

            //kolon adlarını düzenledik
            dataGridView1.Columns[1].HeaderText = "Kullanıcı";
            dataGridView1.Columns[2].HeaderText = "Kaynak Ad";

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
    }
}
