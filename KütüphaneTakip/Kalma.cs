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
    public partial class Kalma : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=kütüphane.accdb");
        OleDbCommand cmd;
        OleDbCommand cmd2;
        OleDbDataReader dr;
        OleDbDataReader dr2;
       
        public Kalma()
        {
            InitializeComponent();
        }

        private void Kalma_Load(object sender, EventArgs e)
        {
            
            cmd = new OleDbCommand();
            cmd2 = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd2.Connection = con;

            cmd.CommandText = "SELECT * FROM kitap";
            cmd2.CommandText = "SELECT * FROM müşteri";
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["BarkodNo"]);
               

            }
            dr2 = cmd2.ExecuteReader();

            while (dr2.Read())
            {
                comboBox2.Items.Add(dr2["TC"]);

            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string TARIH = dateTimePicker1.Value.ToShortDateString();
            con.Open();  //Bağlantımızı açtık           
            cmd.Connection = con;//Komutumuza bağlantımızı tanımladık.
            if( comboBox1.Text==""||comboBox2.Text=="")
            {
                DialogResult c;
                c = MessageBox.Show("Alanlar Boş Geçilemez!", "Bilgilendirme Penceresi");
                con.Close();
            }
            else
            {
                DialogResult c;
                c = MessageBox.Show("Almak istediğinize emin misiniz?", "Bilgilendirme Penceresi!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (c == DialogResult.Yes)
                {

                    cmd.CommandText = "INSERT into  Emanet(Mtc,Kbarkod,AlışTarihi,Teslim) Values ('" + comboBox2.Text + "','" + comboBox1.Text + "','" + TARIH + "' ,'Teslim Edilmedi')";

                    cmd.ExecuteNonQuery();  //Komutumuzu çalıştırdık.
                    cmd.Dispose();
                    con.Close();//Bağlantımızı kapattık.
                    MessageBox.Show("Kayıt Başarıyla Tamamlandı!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
