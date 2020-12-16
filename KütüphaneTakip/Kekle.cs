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
    public partial class Kekle : Form
    {
        OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=kütüphane.accdb");
        OleDbCommand kmt = new OleDbCommand();
        public Kekle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==""||textBox2.Text=="")
            {
                DialogResult c;
                c = MessageBox.Show("Alanlar Boş Geçilemez!", "Bilgilendirme Penceresi");
                bag.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                comboBox1.Text = "";
            }
            else
            {
                string TARIH = dateTimePicker1.Value.ToShortDateString();
                bag.Open();           
                kmt.Connection = bag;

                kmt.CommandText = "INSERT into kitap(BarkodNo,Kad,Yad,Yevi,Ktür,Temin,TeminTarih,Stok) Values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','" + comboBox1.Text + "','" + textBox6.Text + "','" + TARIH + "','" + textBox4.Text + "')";

                kmt.ExecuteNonQuery();  
                kmt.Dispose();
                bag.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                comboBox1.Text = "";
                MessageBox.Show("Kayıt Başarıyla Tamamlandı!", "Bilgilendirme Penceresi");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
