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
    public partial class EPS : Form
    {
        public int iznos1,iznos2,iznos3,iznospravi,iznos5,iznos200;

        private void button1_Click(object sender, EventArgs e)
        {
            iznospravi = iznos1;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            iznospravi = iznos2;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            iznospravi = iznos3;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            iznospravi = Convert.ToInt32(numericUpDown1.Value);
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            iznospravi = iznos5;
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            iznospravi = iznos200;
            this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //ne treba
        }

        public EPS(int i)
        {
            InitializeComponent();
            double temp2 = i / (double)50;
            iznos1 = Convert.ToInt32(Math.Ceiling(temp2)) * 50;
            double temp = i / (double)100;
            iznos3 = Convert.ToInt32(Math.Ceiling(temp))*100;
            temp = i / (double)10;
            iznos2 = Convert.ToInt32(Math.Ceiling(temp))*10;
            temp = i / (double)5;
            iznos5 = Convert.ToInt32(Math.Ceiling(temp)) * 5;
            temp = i / (double)200;
            iznos200 = Convert.ToInt32(Math.Ceiling(temp)) * 200;


            label1.Text = Convert.ToString(iznos1);
            label2.Text = Convert.ToString(iznos2);
            label3.Text = Convert.ToString(iznos3);
            label6.Text = Convert.ToString(iznos5);
            label7.Text = Convert.ToString(iznos200);
            numericUpDown1.Value = i;
        }

        private void EPS_Load(object sender, EventArgs e)
        {
            ActiveControl = numericUpDown1;
            numericUpDown1.Select(0, numericUpDown1.ToString().Length);
        }
    }
}
