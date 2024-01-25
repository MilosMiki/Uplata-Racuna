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
    public partial class Form3 : Form
    {
        public string i, pib;
        public Form3(bool b)
        {
            InitializeComponent();
            if (!b)
            {
                label1.Visible = false;
                textBox1.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            i = textBox1.Text;
            pib = textBox2.Text;
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
        }
    }
}
