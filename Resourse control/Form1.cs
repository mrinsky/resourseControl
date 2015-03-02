using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Net;
using System.Diagnostics;

namespace Resourse_control
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) // кнопка выхода
        {
           Application.Exit();
            }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)//Проверка обновления через Dropbox
        {
            if (File.Exists("version.txt"))
            {
            }
            else 
            {
                File.AppendAllText("version.txt", "0");
            }
            WebClient vers = new WebClient();
            String versNet = vers.DownloadString("https://dl.dropbox.com/s/uyw05rkz6neco2w/update.txt");
            String versLocal = File.ReadAllText("version.txt");
            if(versNet != versLocal)
            MessageBox.Show("Please update your progpam! \nCurrent version "+ versLocal+"\nNew version "+versNet);
            }

        private void пробаБазыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SQLiteConnection.CreateFile(@"osnova.db");
            SQLiteConnection conn = new SQLiteConnection("Data Sourсe=osnova.db; Version=3;");
            SQLiteCommand command = new SQLiteCommand("CREATE TABLE example (id INTEGER PRIMARY KEY, value TEXT);", conn);
            conn.Open();
          //  conn.Close();
        

        }

        private void приветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Привет Андрей!";
        }

        
    }
}
