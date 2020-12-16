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
    public partial class Kguncel : Form
    {
       
        public Kguncel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" )
            {
                DialogResult c;
                c = MessageBox.Show("Alan Boş Geçilemez!", "Bilgilendirme Penceresi");
               
                
            }
            else { 
            string barkod = textBox1.Text;
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=kütüphane.accdb");
            con.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM kitap where BarkodNo='" + barkod + "'", con);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox7.Text = dr["BarkodNo"].ToString();
                textBox2.Text = dr["Kad"].ToString();
                textBox3.Text = dr["Yad"].ToString();
                textBox6.Text = dr["Yevi"].ToString();
                comboBox1.Text = dr["Ktür"].ToString();
                textBox5.Text = dr["Temin"].ToString();
                dateTimePicker1.Text = dr["TeminTarih"].ToString();
                textBox4.Text = dr["Stok"].ToString();
             


            }
            con.Close();
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string barkod = textBox1.Text;
            
            string TARIH = dateTimePicker1.Value.ToShortDateString();

            OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=kütüphane.accdb");
            OleDbCommand kmt = new OleDbCommand();
            bag.Open();  //Bağlantımızı açtık           
            kmt.Connection = bag;

            kmt.CommandText = "update kitap set BarkodNo='" + textBox7.Text + "',Kad='" + textBox2.Text + "',Yad='" + textBox3.Text + "',Yevi='" + textBox6.Text + "',Ktür='" + comboBox1.Text + "'," +"Temin='" + textBox5.Text + "',TeminTarih='" + TARIH + "',Stok='" + textBox4.Text + "' where BarkodNo='" + barkod + "'";
            kmt.ExecuteNonQuery();  //Komutumuzu çalıştırdık.
            kmt.Dispose();
            bag.Close();//Bağlantımızı kapattık.
            MessageBox.Show("Kayıt Başarıyla Tamamlandı!");

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text ="" ;
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox1.Text = "";
            textBox5.Text ="";
            textBox4.Text ="";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
