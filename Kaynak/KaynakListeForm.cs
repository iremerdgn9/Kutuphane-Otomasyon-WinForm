using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane_Otomasyon_WinForm.Kaynak
{
    public partial class KaynakListeForm : Form
    {
        public KaynakListeForm()
        {
            InitializeComponent();
        }
        KutuphaneOtomasyonEntities db = new KutuphaneOtomasyonEntities();
        private void KaynakListeForm_Load(object sender, EventArgs e)
        {
            var kaynaklar = db.Kaynaklar.ToList();
            dataGridView1.DataSource = kaynaklar.ToList(); //kaynaklar tablosunu datagrid'e liste olarak atar.

            dataGridView1.Columns[0].Visible = false; //0.sütun yani kullanıcı_id görünmesin.(gizledik)
            dataGridView1.Columns[7].Visible = false; //7.sütun yani kayıtlar görünmesin.

            //Sütunların isimlerini değiştirdik.
            dataGridView1.Columns[1].HeaderText = "Kaynak Adı";
            dataGridView1.Columns[2].HeaderText = "Yazar";
            dataGridView1.Columns[3].HeaderText = "Yayınevi";
            dataGridView1.Columns[4].HeaderText = "Sayfa Sayısı";
            dataGridView1.Columns[5].HeaderText = "Basım Tarihi";
            dataGridView1.Columns[6].HeaderText = "Kaynak Türü";
        }
    }
}
