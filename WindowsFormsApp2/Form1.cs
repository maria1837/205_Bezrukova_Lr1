using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace ТекстовыйРедактор
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName == String.Empty) return;

            try
            {
                var Читатель = new System.IO.StreamReader(openFileDialog1.FileName, Encoding.GetEncoding(1251));
                textBox1.Text = Читатель.ReadToEnd();
                Читатель.Close();
            }
            catch (System.IO.FileNotFoundException Ситуация)
            {
                MessageBox.Show(Ситуация.Message + "\nНет такого файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = openFileDialog1.FileName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var Писатель = new System.IO.StreamWriter(saveFileDialog1.FileName, false, System.Text.Encoding.GetEncoding(1251));
                    Писатель.Write(textBox1.Text);
                    Писатель.Close();
                }
                catch (Exception Ситуация)
                {
                    MessageBox.Show(Ситуация.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Clear();
            openFileDialog1.FileName = @"data\Text2.txt" ;
            openFileDialog1.Filter = "Текстовые файлы(*.txt)| *.txt | All files(*.*) | *.*"; 
            saveFileDialog1.Filter = "Текстовые файлы(*.txt)| *.txt | All files(*.*) | *.*";
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }



    }
}
