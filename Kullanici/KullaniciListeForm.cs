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
    public partial class KullaniciListeForm : Form
    {
        public KullaniciListeForm()
        {
            InitializeComponent();
        }
        public void Listele() //metot oluşturduk
        {
            KutuphaneOtomasyonEntities db = new KutuphaneOtomasyonEntities();
            var kullanicilar = db.Kullanicilar.ToList(); //kullanıcıların hepsini buraya listele
            dataGridView1.DataSource = kullanicilar.ToList();

            dataGridView1.Columns[0].Visible = false; //0.sütun yani kullanıcı_id görünmesin.(gizledik)
            dataGridView1.Columns[8].Visible = false; //8.sütun yani kayıtlar görünmesin.

            //Sütunların isimlerini değiştirdik.
            dataGridView1.Columns[1].HeaderText = "Ad";
            dataGridView1.Columns[2].HeaderText = "Soyad";
            dataGridView1.Columns[3].HeaderText = "TC";
            dataGridView1.Columns[4].HeaderText = "e-Mail";
            dataGridView1.Columns[5].HeaderText = "Tel";
            dataGridView1.Columns[6].HeaderText = "Ceza";
            dataGridView1.Columns[7].HeaderText = "Cinsiyet";

        }

        private void KullaniciListeForm_Load(object sender, EventArgs e)
        {
            Listele(); //listele metoduna git ve listele

        }
    }
}
