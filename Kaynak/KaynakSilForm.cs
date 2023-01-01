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
    public partial class KaynakSilForm : Form
    {
        public KaynakSilForm()
        {
            InitializeComponent();
        }
        KutuphaneOtomasyonEntities db = new KutuphaneOtomasyonEntities();

        private void KaynakSilForm_Load(object sender, EventArgs e)
        {
            var kaynaklar = db.Kaynaklar.ToList();
            dataGridView1.DataSource = kaynaklar.ToList(); //datagrid'te listeleme yaptık.

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

        private void button1_Click(object sender, EventArgs e)
        {
            int secilenId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            var silinenKaynak = db.Kaynaklar.Where(x => x.kaynak_id == secilenId).FirstOrDefault(); //her satırdaki kaynakların tek farklı olduğu özellik kaynak_id old. için onu baz alarak işlem yapıyoruz.
            db.Kaynaklar.Remove(silinenKaynak); // Kaynaklar tablosuna git, silinen kaynakların içine attığın verilerin hepsini sil.
            db.SaveChanges();

            var kaynaklar = db.Kaynaklar.ToList(); //listeyi veritabanına çektik
            dataGridView1.DataSource = kaynaklar.ToList(); //sonra datagrid'te tekrar listeleme yaptık.
        }
    }
}
