using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Paweł_Sobolewski_kolokwium2_GL2_20240514
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string plik_XML = "", plik_JSON = "", plik_CSV = "";
        string autor, tytul, rok, cena;

        public void tworzenie_XML()
        {
            plik_XML = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n" +
            "<ksiazka>\r\n\t<autor>" + autor + "</autor>\r\n\t" +
            "<tytul>" + tytul + "</tytul>\r\n\t" +
            "<rok_wydania>" + rok + "</rok_wydania>\r\n\t" +
            "<cena>" + cena + "</cena>\r\n</ksiazka>";
            plik_XML += "\r\n\r\n";

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Pliki XML (*.xml)|*.xml|Wszystkie pliki (*.*)|*.*";
            saveFileDialog.Title = "Zapisz plik XML";
            saveFileDialog.FileName = "plik_XML.xml";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, plik_XML);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił błąd podczas zapisywania pliku: " + ex.Message);
                }
            }
        }
        public void tworzenie_CSV()
        {
            plik_CSV = "Autor;Tytul;RokWydania;Cena\r\n" + autor + ";" + tytul + ";" + rok + ";" + cena;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Pliki CSV (*.csv)|*.csv|Wszystkie pliki (*.*)|*.*";
            saveFileDialog.Title = "Zapisz plik CSV";
            saveFileDialog.FileName = "plik_CSV.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, plik_CSV);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił błąd podczas zapisywania pliku: " + ex.Message);
                }
            }
        }

        public void tworzenie_JSON()
        {
            plik_JSON = "{\"autor\":\"" + autor + "\", \"tytul\":\"" + tytul + "\", \"rok_wydania\":" + rok + ", \"cena\":" + cena + "}";
            plik_JSON += "\r\n\r\n";

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Pliki JSON (*.json)|*.json|Wszystkie pliki (*.*)|*.*";
            saveFileDialog.Title = "Zapisz plik JSON";
            saveFileDialog.FileName = "plik_JSON.json";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, plik_JSON);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił błąd podczas zapisywania pliku: " + ex.Message);
                }
            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "C:\\Users\\Psob\\Desktop";
            ofd.Filter = "Pliki  (JSON*.json)|*.json|Wszytkie Pliki(*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(ofd.FileName);
            }

        }


        private void button2_Click(object sender, EventArgs e)  
        {
            if (richTextBox1.Text != "")
            {
                plik_JSON = richTextBox1.Text;
                plik_JSON = plik_JSON.Remove(0, plik_JSON.IndexOf("\"") + 1);
                plik_JSON = plik_JSON.Remove(0, plik_JSON.IndexOf(":") + 1);
                autor = plik_JSON.Substring(1, plik_JSON.IndexOf(",") -2);

                plik_JSON = plik_JSON.Remove(0, plik_JSON.IndexOf("\"") + 1);
                plik_JSON = plik_JSON.Remove(0, plik_JSON.IndexOf(":") + 1);
                tytul = plik_JSON.Substring(1, plik_JSON.IndexOf(",") -2);

                plik_JSON = plik_JSON.Remove(0, plik_JSON.IndexOf("\"") + 1);
                plik_JSON = plik_JSON.Remove(0, plik_JSON.IndexOf(":") );
                rok = plik_JSON.Substring(1, plik_JSON.IndexOf(",") -1);

                plik_JSON = plik_JSON.Remove(0, plik_JSON.IndexOf(",") + 1);
                plik_JSON = plik_JSON.Remove(0, plik_JSON.IndexOf(":") + 1);
                cena = plik_JSON.Substring(0, plik_JSON.IndexOf("}"));
                



                textBox1.Text = autor;
                textBox2.Text = tytul;
                textBox3.Text = rok;
                textBox4.Text = cena;
                plik_XML = "";
            
            }
            else
            {
                MessageBox.Show("Brak danych!");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                tworzenie_XML();
            }
            if (checkBox2.Checked)
            {
                tworzenie_CSV();
            }
            if (checkBox3.Checked)
            {
                tworzenie_JSON();
            }
            else
            {
                MessageBox.Show("Nie wybrano żadnego formatu:");
            }
        }

    }
}

