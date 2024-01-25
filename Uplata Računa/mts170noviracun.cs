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
    public partial class mts170noviracun : Form
    {
        public string ReturnValue1 { get; set; }

        public mts170noviracun()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                this.ReturnValue1 = "17030013706003\t58";
            }
            else if (radioButton2.Checked)
            {
                this.ReturnValue1 = "17030013706231\t53";
            }
            else if (radioButton3.Checked)
            {
                uint prvi = Convert.ToUInt32(textBox1.Text);
                UInt64 drugi = Convert.ToUInt64(textBox2.Text);
                uint treci = Convert.ToUInt32(textBox3.Text);
                this.ReturnValue1 = String.Concat(prvi, drugi, "\t", treci);
            }
            else
            {
                MessageBox.Show("Niste odabrali račun. Pokušajte ponovo.", "GREŠKA",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.TextLength >= 3)
            {
                ActiveControl = textBox2;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.TextLength >= 2)
            {
                ActiveControl = button1;
            }
        }

        private void mts170noviracun_Load(object sender, EventArgs e)
        {
            ActiveControl = textBox1;
        }
    }
}
