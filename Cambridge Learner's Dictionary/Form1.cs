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



namespace Cambridge_Learner_s_Dictionary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\asus\Desktop\dbSozluk.mdb");
        private void Form1_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select ingilizce from sozluk", baglanti);
            OleDbDataReader tk = komut.ExecuteReader();
            while (tk.Read())
            {
                listBox1.Items.Add(tk[0].ToString());
            }
            baglanti.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select ingilizce from sozluk where ingilizce like '" + textBox1.Text + "%'", baglanti);
            OleDbDataReader tk = komut.ExecuteReader();
            while (tk.Read())
            {
                listBox1.Items.Add(tk[0]);
            }
            baglanti.Close();

        }

        private void textBox3_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            textBox2.Text = listBox1.SelectedItem.ToString();
            textBox3.Text = listBox1.SelectedItem.ToString();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select ingilizceOrnekCumle, turkceOrnekCumle from sozluk where ingilizce = '" + textBox2.Text + "'", baglanti);
            OleDbDataReader tk = komut.ExecuteReader();
            while (tk.Read())
            {
                label1.Text = tk[0].ToString();
                label2.Text = tk[1].ToString();

            }
            baglanti.Close();


        }
    }
}
