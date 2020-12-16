using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace KütüphaneTakip
{
    public partial class KütüphaneTakip : Form
    {
         OleDbConnection con;
        OleDbDataAdapter da;
        
        DataSet ds;
        public KütüphaneTakip()
        {
            InitializeComponent();
        }

        private void yeniKitapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kekle yeni2 = new Kekle();
            yeni2.Show();
        }

        private void yeniKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mekle yeni = new Mekle();
            yeni.Show();
        }

        private void listeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=kütüphane.accdb");
            da = new OleDbDataAdapter("SElect *from müşteri", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "müşteri");
            dataGridView1.DataSource = ds.Tables["müşteri"];
            con.Close();
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mguncel yeni3 = new Mguncel();
            yeni3.Show();
        }

        private void listeleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=kütüphane.accdb");
            da = new OleDbDataAdapter("SElect *from kitap", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "kitap");
            
            dataGridView1.DataSource = ds.Tables["kitap"];
            con.Close();
        }

        private void güncelleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Kguncel yeni4 = new Kguncel();
            yeni4.Show();
        }

        private void silToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Ksil yeni5 = new Ksil();
            yeni5.Show();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Msil yeni6 = new Msil();
            yeni6.Show();
        }

     

        private void kitapAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kalma yeni7 = new Kalma();
            yeni7.Show();
        }

        private void teslimEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kteslim yeni8 = new Kteslim();
            yeni8.Show();
        }

        private void raporlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rapor yeni9 = new Rapor();
            yeni9.Show();
        }

        private void KütüphaneTakip_Load(object sender, EventArgs e)
        {

        }
    }
}
