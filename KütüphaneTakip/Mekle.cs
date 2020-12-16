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
    public partial class Mekle : Form
    {
        OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=kütüphane.accdb");
        OleDbCommand kmt = new OleDbCommand();
        public Mekle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" )
            {
                DialogResult c;
                c = MessageBox.Show("Alanlar Boş Geçilemez!", "Bilgilendirme Penceresi");
                bag.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                richTextBox1.Text = "";
                comboBox1.Text = "";
            }
            else
            {
                string TARIH = dateTimePicker1.Value.ToShortDateString();
                string TARIH2 = dateTimePicker2.Value.ToShortDateString();
                int telefon;
                telefon = Convert.ToInt32(textBox4.Text);
                bag.Open();           
                kmt.Connection = bag;
                                     
                kmt.CommandText = "INSERT into müşteri(TC,Ad,Soyad,Dtarih,Tel,Eposta,ÜyelikTarih,Cinsiyet,Adres) Values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + TARIH + "','" + telefon + "','" + textBox5.Text + "','" + TARIH2 + "','" + comboBox1.Text + "','" + richTextBox1.Text + "')";

                kmt.ExecuteNonQuery(); 
                kmt.Dispose();
                bag.Close();
                MessageBox.Show("Kayıt Başarıyla Tamamlandı!");
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
