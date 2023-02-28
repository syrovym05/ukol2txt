using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace ukol2txt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();           
               

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(ofd.FileName, Encoding.GetEncoding("windows-1250"));
                StreamWriter sw1 = new StreamWriter(@"..\..\do1950.txt", false, Encoding.GetEncoding("windows-1250"));
                StreamWriter sw2 = new StreamWriter(@"..\..\po1950.txt", false, Encoding.GetEncoding("windows-1250"));

                listBox1.Items.Clear();
                bool konec = false;

                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();
                    listBox1.Items.Add(s);
                    if (s.Length > 0)
                    {                        
                        string[] slova = s.Split(';');
                        
                        if (slova[1] == textBox1.Text && !konec)
                        {
                            label1.Text = s;
                            konec = true;
                        }

                        if (Convert.ToInt32(slova[slova.Length - 1]) < 1950)sw1.WriteLine(s);                        
                        else if (Convert.ToInt32(slova[slova.Length - 1]) >= 1950)sw2.WriteLine(s);                        
                    }
                }
                sr.Close();                               
                sw1.Close();
                sw2.Close();

            }
        }
    }
}
