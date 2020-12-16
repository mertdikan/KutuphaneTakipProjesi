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
    public partial class Mguncel : Form
    {
        
        
       
        
        public Mguncel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                DialogResult c;
                c = MessageBox.Show("Alan Boş Geçilemez!", "Bilgilendirme Penceresi");


            }
            else {
            string tc = textBox1.Text;
       
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=kütüphane.accdb");
            con.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM müşteri where TC='" + tc + "'", con);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox6.Text = dr["TC"].ToString();
                textBox2.Text = dr["Ad"].ToString();
                textBox3.Text = dr["Soyad"].ToString();
                dateTimePicker1.Text = dr["Dtarih"].ToString();
                textBox4.Text = dr["Tel"].ToString();
                textBox5.Text = dr["Eposta"].ToString();
                dateTimePicker2.Text = dr["ÜyelikTarih"].ToString();
                comboBox1.Text=dr["Cinsiyet"].ToString();
                richTextBox1.Text = dr["Adres"].ToString();


            }
            con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string tc = textBox1.Text;
            OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=kütüphane.accdb");
            OleDbCommand kmt = new OleDbCommand();
            string TARIH = dateTimePicker1.Value.ToShortDateString();
            string TARIH2 = dateTimePicker2.Value.ToShortDateString();
            int telefon;
            telefon = Convert.ToInt32(textBox4.Text);
            bag.Open();  //Bağlantımızı açtık           
            kmt.Connection = bag;
         
            kmt.CommandText = "update müşteri set TC='" + textBox6.Text + "',Ad='" + textBox2.Text + "',Soyad='" + textBox3.Text + "',Dtarih='" + TARIH + "',Tel='" + telefon + "',Eposta='" + textBox5.Text + "',ÜyelikTarih='" + TARIH2 + "',Cinsiyet='" + comboBox1.Text + "',Adres='" + richTextBox1.Text + "' where TC='" + tc + "'";
            kmt.ExecuteNonQuery();  //Komutumuzu çalıştırdık.
            kmt.Dispose();
            bag.Close();//Bağlantımızı kapattık.
            MessageBox.Show("Kayıt Başarıyla Tamamlandı!");
            textBox6.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            textBox4.Text = "";
            textBox5.Text = "";

            comboBox1.Text = "ERKEK";
            richTextBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
