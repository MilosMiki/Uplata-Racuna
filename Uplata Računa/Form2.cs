using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uplata_Računa
{
    public partial class Form2 : Form
    {
        public string s;
        public Form2(bool b = true)
        {
            InitializeComponent();
            if (b)
            {
                this.Size = new Size(337, 161);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            /*s = textBox1.Text;
            if (s.Length>2 && s.Substring(s.Length - 2, 1) == "{ENTER}")
            {
                SendKeys.Send("\t{ENTER}");
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            s = textBox1.Text;
            this.Close();
        }
    }
}
