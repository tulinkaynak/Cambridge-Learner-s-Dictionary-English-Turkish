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
using SpeechLib;
using System.IO;

namespace Cambridge_Learner_s_Dictionary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= "+ Application.StartupPath + "\\dbSozluk.mdb");
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

        private void listBox1_Click(object sender, EventArgs e)
        {
            textBox2.Text = listBox1.SelectedItem.ToString();
            textBox3.Text = listBox1.SelectedItem.ToString();

            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select ingilizceOrnekCumle, ingilizceanlam, Dilbilgisi,  turkceOrnekCumle, turkce from sozluk where ingilizce = '" + textBox2.Text + "'", baglanti);
            OleDbDataReader tk = komut.ExecuteReader();
            while (tk.Read())
            {
                label2.Text = tk[0].ToString();
                label1.Text = tk[1].ToString();
                textBox4.Text = tk[2].ToString();
                label3.Text = tk[3].ToString();
                textBox5.Text = tk[4].ToString();
                pictureBox2.ImageLocation = Application.StartupPath + "/kelimeler/" + textBox2.Text + ".png";
        
                
            }
            baglanti.Close();
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SpVoice oku = new SpVoice();
            oku.Speak(textBox3.Text, SpeechVoiceSpeakFlags.SVSFDefault);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(baglanti.State==ConnectionState.Closed)
            baglanti.Open();

            OleDbCommand komut = new OleDbCommand("Select ingilizceOrnekCumle, ingilizceanlam, Dilbilgisi,  turkceOrnekCumle, turkce from sozluk where ingilizce = '" + textBox1.Text + "'", baglanti);
            OleDbDataReader tk = komut.ExecuteReader();
            while (tk.Read())
            {
                label2.Text = tk[0].ToString();
                label1.Text = tk[1].ToString();
                textBox4.Text = tk[2].ToString();
                label3.Text = tk[3].ToString();
                textBox5.Text = tk[4].ToString();
                textBox2.Text = textBox1.Text;
                textBox3.Text = textBox1.Text;

                pictureBox2.ImageLocation =Application.StartupPath+ "/kelimeler/"+ textBox1.Text + ".png";

            }
            baglanti.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();

                OleDbCommand komut = new OleDbCommand("Select ingilizceOrnekCumle, ingilizceanlam, Dilbilgisi,  turkceOrnekCumle, turkce from sozluk where ingilizce = '" + textBox1.Text + "'", baglanti);
            OleDbDataReader tk = komut.ExecuteReader();
                while (tk.Read())
                {
                    label2.Text = tk[0].ToString();
                    label1.Text = tk[1].ToString();
                    textBox4.Text = tk[2].ToString();
                    label3.Text = tk[3].ToString();
                    textBox5.Text = tk[4].ToString();
                    textBox2.Text = textBox1.Text;
                    textBox3.Text = textBox1.Text;

                    pictureBox2.ImageLocation = Application.StartupPath + "/kelimeler/" + textBox1.Text + ".png";

                }
                baglanti.Close();

            }
        }
    }

