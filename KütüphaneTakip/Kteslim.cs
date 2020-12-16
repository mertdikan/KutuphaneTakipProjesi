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
    public partial class Kteslim : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=kütüphane.accdb");
        OleDbCommand cmd;
        OleDbCommand cmd2;
        OleDbDataReader dr;
        OleDbDataReader dr2;
        
       

        public Kteslim()
        {
            InitializeComponent();
        }

        private void Kteslim_Load(object sender, EventArgs e)
        {

            cmd = new OleDbCommand();
           
            con.Open();
            cmd.Connection = con;
           

            cmd.CommandText = "SELECT * FROM Emanet";
            
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["Mtc"]);
              //  comboBox2.Items.Add(dr["Kbarkod"]);


            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string TARIH = dateTimePicker1.Value.ToShortDateString();
            con.Open();  //Bağlantımızı açtık           
            cmd.Connection = con;//Komutumuza bağlantımızı tanımladık.
            if (comboBox1.Text == "" || comboBox2.Text == "")
            {
                DialogResult c;
                c = MessageBox.Show("Alanlar Boş Geçilemez!", "Bilgilendirme Penceresi");
                con.Close();
            }
            else
            {
                DialogResult c;
                c = MessageBox.Show("Teslim etmek istediğinize emin misiniz?", "Bilgilendirme Penceresi!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (c == DialogResult.Yes)
                {
                    string tc = comboBox1.Text.ToString();
                    string barkod = comboBox2.Text.ToString();
                    cmd.CommandText = "update   Emanet set Teslim='Teslim Edildi',TeslimDurumu='" + comboBox3.Text + "',TeslimTarihi='" + TARIH+ "'  Where  Mtc='" + tc + "' ";
                    cmd.ExecuteNonQuery();  
                    cmd.Dispose();
                    con.Close();
                    MessageBox.Show("Kayıt Başarıyla Tamamlandı!");
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    comboBox3.Text = "Sağlam";
                }
            }
        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd2 = new OleDbCommand();
            con.Open();
            cmd2.Connection = con;
            string tc = comboBox1.Text.ToString();
            cmd2.CommandText = "SELECT * FROM Emanet where Mtc='" + tc + "'";

            dr2 = cmd.ExecuteReader();

           while (dr2.Read())
           {

                comboBox2.Items.Add(dr2["Kbarkod"]);


           }
            con.Close();
        }
    }
}
