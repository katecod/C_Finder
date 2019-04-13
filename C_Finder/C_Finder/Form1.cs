using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace C_Finder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.ActiveControl = el_tb_WordToFind;
        }
        public bool test = false;
        string path;
        List<string> allfiles= new List<string>();
        private void TakeSource()
        {
            
            if (test)
            {
                el_tb_WordToFind.Text = "cant";
            }


            if (el_tb_WordToFind.Text == "")
            {
                MessageBox.Show("Plese enter word to find first");
                this.ActiveControl = el_tb_WordToFind;
            }
            else
            {
                if (test)
                {


                    path = "I:\\book\\[TW] Torchwood - The Official Magazine [2008-2010] PDF";
                    GetAllFiles(path);
                    GetAllDirs(path);
                }
                else { 
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        path = fbd.SelectedPath;
                        GetAllFiles(path);
                        GetAllDirs(path);
                    }
                }
                }
                if (allfiles.Count>0)
                {

                    File.WriteAllText("results.txt", string.Empty);
                    Finer fin = new Finer();
                    fin.Find(allfiles, el_tb_WordToFind.Text, path);

                }
                else
                {
                    MessageBox.Show("No result was found");
                }
            }
        }
        private void el_b_start_Click(object sender, EventArgs e)
        {

            TakeSource();
            MessageBox.Show("end");
        }
        private void GetAllFiles(string path)
        {
            string[] files = Directory.GetFiles(path);
            allfiles.AddRange(files);
        }
        private void GetAllDirs(string path)
        {
            string[] dirs = Directory.GetDirectories(path);
            foreach (var dir in dirs)
            {
                path = dir;
                GetAllFiles(path);
                GetAllDirs(path);
            }
        }

        
    }
}
