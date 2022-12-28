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
