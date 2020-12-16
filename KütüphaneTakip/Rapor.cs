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
    public partial class Rapor : Form
    {

        OleDbConnection con;
        OleDbDataAdapter da;
        DataSet ds;
        public Rapor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=kütüphane.accdb");
            da = new OleDbDataAdapter("Select Mtc,Kbarkod,AlışTarihi from Emanet where Teslim='Teslim Edilmedi'  ", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Emanet");
            dataGridView1.DataSource = ds.Tables["Emanet"];
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=kütüphane.accdb");
            da = new OleDbDataAdapter("Select Mtc,Kbarkod,AlışTarihi,TeslimDurumu,TeslimTarihi from Emanet where Teslim='Teslim Edildi'  ", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Emanet");
            dataGridView1.DataSource = ds.Tables["Emanet"];
            con.Close();
        }
    }
}
