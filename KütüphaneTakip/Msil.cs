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
    public partial class Msil : Form
    {
        OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=kütüphane.accdb");
        OleDbCommand kmt = new OleDbCommand();
        public Msil()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                DialogResult a;
                a = MessageBox.Show("Alan Boş Geçilemez!", "Bilgilendirme Penceresi");


            }
            else { 
            DialogResult c;
            c = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (c == DialogResult.Yes)
            {
                kmt.Connection = bag;

                bag.Open();

                kmt.CommandText = "delete from müşteri where TC='" + textBox1.Text + "'";

                kmt.ExecuteNonQuery();

                bag.Close();
                textBox1.Text = "";
            }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
