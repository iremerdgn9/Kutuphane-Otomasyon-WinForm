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
        }

        private void KullaniciListeForm_Load(object sender, EventArgs e)
        {
            Listele(); //listele metoduna git ve listele

        }
    }
}
