using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Uplata_Računa
{
    public partial class Form1 : Form
    {


        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        
        private const int MOUSEEVENTF_LEFTDOWN = 0x00000002;
        private const int MOUSEEVENTF_LEFTUP = 0x00000004;
        private const int MOUSEEVENTF_MOVE = 0x0001;

        public string barkod = "";
        //public static bool b = false;
        public Form1()
        {
            InitializeComponent();
        }

        public void Barkod(bool b = true)
        {
            Form2 f2 = new Form2(b);
            f2.ShowDialog();
            barkod = f2.s;
            //label1.Text = barkod;
        }

        public void IspisIznos(string racun, string pib, string iznos)
        {
            int x = 683;
            int y = 182;
            System.Threading.Thread.Sleep(20);
            Cursor.Position = new Point(x, y);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            System.Threading.Thread.Sleep(50);
            SendKeys.Send(iznos);
            SendKeys.Send("{TAB}");
            SendKeys.Send(racun);
            SendKeys.Send("{TAB}");
            x = 591;
            y = 428;
            System.Threading.Thread.Sleep(250);
            Cursor.Position = new Point(x, y);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            System.Threading.Thread.Sleep(5);
            SendKeys.Send(pib);
            System.Threading.Thread.Sleep(5);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        /*private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = Cursor.Position.X.ToString();
            label2.Text = Cursor.Position.Y.ToString();
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            //EPS
            try
            {
                Barkod();

                Decimal iznos;
                string pib, racun;
                racun = barkod.Substring(0, 9) + "\t" + barkod.Substring(9, 2);
                pib = barkod.Substring(11, 2) + "-" + barkod.Substring(13, 3) + "-" +
                    barkod.Substring(16, 11) + "-" + barkod.Substring(27, 3);
                iznos = Convert.ToDecimal(barkod.Substring(30, 11)) / 100;
                iznos = Math.Ceiling(iznos);

                EPS eps = new EPS(Convert.ToInt32(iznos));
                eps.ShowDialog();
                iznos = eps.iznospravi;

                //label2.Text = racun + "\n" + pib + "\n" + iznos.ToString();
                IspisIznos(racun, pib, iznos.ToString());
            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //MTS 170
            try
            {
                Barkod();
                string racun;
                mts170noviracun form = new mts170noviracun();
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    racun = form.ReturnValue1;
                }
                else
                {
                    throw new Exception();
                }
                /*Form3 f3 = new Form3(false);
                f3.ShowDialog();
                string pib2 = f3.pib;*/
                ulong mod97 = Convert.ToUInt64(barkod.Substring(0,13));
                mod97 = 98 - ((mod97 * 100) % 97);

                string iznos = Math.Ceiling(Convert.ToDecimal(barkod.Substring(13, 11)) / 100).ToString();
                
                string pib;
                if (mod97 < 10)
                {
                    pib = "0" + mod97 + "-" + barkod.Substring(0, 3) + "-" +
                        barkod.Substring(3, 3) + "-" + barkod.Substring(6, 7);
                }
                else
                {
                    pib = mod97 + "-" + barkod.Substring(0, 3) + "-" +
                        barkod.Substring(3, 3) + "-" + barkod.Substring(6, 7);
                }
                IspisIznos(racun, pib, iznos);
            }
            catch
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //MTS 310
            try
            {
                Barkod();
                /*Form3 f3 = new Form3(false);
                f3.ShowDialog();
                string pib2 = f3.pib;*/
                ulong mod97 = Convert.ToUInt64(barkod.Substring(0, 13));
                mod97 = 98 - ((mod97 * 100) % 97);

                string iznos = Math.Ceiling(Convert.ToDecimal(barkod.Substring(13, 11)) / 100).ToString();
                string racun = "205506102\t26";
                string pib;
                if (mod97 < 10)
                {
                    pib = "0" + mod97 + "-" + barkod.Substring(0, 3) + "-" +
                        barkod.Substring(3, 3) + "-" + barkod.Substring(6, 7);
                }
                else
                {
                    pib = mod97 + "-" + barkod.Substring(0, 3) + "-" +
                        barkod.Substring(3, 3) + "-" + barkod.Substring(6, 7);
                }
                IspisIznos(racun, pib, iznos);
            }
            catch
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //TELENOR
            try
            {
                Barkod();

                string racun = "2651040310000497\t22";
                string pib = barkod.Substring(9, 2) + "-" + barkod.Substring(11, 8) + "-" +
                    barkod.Substring(19, 4);
                string iznos = Math.Ceiling(Convert.ToDecimal(barkod.Substring(23, 11)) / 100).ToString();

                IspisIznos(racun, pib, iznos);
            }
            catch
            {

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //VIP (A1)
            try
            {
                Barkod(false);
                Form3 f3 = new Form3(true);
                f3.ShowDialog();
                string iznos = f3.i;
                IspisIznos("2651110312345678\t24", barkod, iznos);

                /*int x = 618;
                int y = 417;
                Cursor.Position = new Point(x, y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                System.Threading.Thread.Sleep(200);
                SendKeys.Send("2651110312345678\t24\t9\t" + barkod);*/
            }
            catch
            {

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //GAS
            try
            {
                 MessageBox.Show(
                    "GAS menja račune češće nego čarape.\nOva skripta važi za račun:\n\n" +
                    "200-3425950101001-62\n\n" +
                    "Obavezno proveriti da li je račun promenjen!\n" +
                    "Ukoliko je račun promenjen, ne treba koristiti ovu skriptu.",
                    "OPREZ!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning // for Warning  
                                           //MessageBoxIcon.Error // for Error 
                                           //MessageBoxIcon.Information  // for Information
                                           //MessageBoxIcon.Question // for Question
                );

                //RACUN
                int x = 440;
                int y = 560;
                Cursor.Position = new Point(x, y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                System.Threading.Thread.Sleep(50);
                SendKeys.Send("2003425950101001\t62");
                //PRIMALAC
                x = 150;
                y = 395;
                Cursor.Position = new Point(x, y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                System.Threading.Thread.Sleep(50);
                //SendKeys.Send("NOVI SAD-GAS\tNOVI SAD TEODORA MANDICA 21");

                /*SendKeys.Send("\t\t\t\t{CAPSLOCK}DP \"NOVI SAD-GAS\"");
                System.Threading.Thread.Sleep(1200);
                SendKeys.Send("\t{CAPSLOCK}TEODORA MANDICA 21 21000 NOVI SAD");*/
            }
            catch
            {

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //SBB 265
            try
            {
                int x = 440;
                int y = 560;
                Cursor.Position = new Point(x, y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                System.Threading.Thread.Sleep(200);
                SendKeys.Send("2651100310003446\t90\t\t");
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Barkod(false);
                Form3 f3 = new Form3(true);
                f3.ShowDialog();
                string iznos = f3.i;
                string pib2 = f3.pib;
                string racun = "15043445\t74";
                string pib;
                pib = pib2 + "-" + barkod.Substring(12, 2) +
                    barkod.Substring(10, 2) + barkod.Substring(0, 10);
                //label2.Text = racun + "\n" + pib + "\n" + iznos.ToString();
                IspisIznos(racun, pib, iznos);

                int x = 609;
                int y = 262;
                Cursor.Position = new Point(x, y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                System.Threading.Thread.Sleep(300);
                SendKeys.Send("12{ENTER}");
            }
            catch
            {

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                // Barkod();
                Form3 f3 = new Form3(true);
                f3.ShowDialog();
                string iznos = f3.i;
                string pib2 = f3.pib;
                string racun = "840742221843\t57";
                string pib;
                pib = pib2;
                //label2.Text = racun + "\n" + pib + "\n" + iznos.ToString();
                IspisIznos(racun, pib, iznos);

                int x = 609;
                int y = 262;
                Cursor.Position = new Point(x, y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                System.Threading.Thread.Sleep(300);
                SendKeys.Send("15{ENTER}");

                /*
                Form3 f3 = new Form3(true);
                f3.ShowDialog();
                string iznos = f3.i;
                string pib2 = f3.pib;
                System.Threading.Thread.Sleep(300);

                int x = 609;
                int y = 262;
                Cursor.Position = new Point(x, y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                System.Threading.Thread.Sleep(200);
                x = 609;
                y = 311;
                Cursor.Position = new Point(x, y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                System.Threading.Thread.Sleep(1000);

                /*x = 609;
                y = 262;
                Cursor.Position = new Point(x, y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                System.Threading.Thread.Sleep(200);*/

                //IspisIznos("840742221843\t57", pib2, iznos);
                //SendKeys.Send("\t"+iznos+"\t840742221843\t57\t9\t"+pib2);
            }
            catch
            {

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //SBB 250
            try
            {
                int x = 440;
                int y = 560;
                Cursor.Position = new Point(x, y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                System.Threading.Thread.Sleep(200);
                SendKeys.Send("2501530000415030\t18\t\t");
            }
            catch
            {

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                int x = 618;
                int y = 417;
                Cursor.Position = new Point(x, y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                System.Threading.Thread.Sleep(200);
                SendKeys.Send("3304014068\t47\t\t\t\t{CAPSLOCK}JAVNI IZVRSITELJ IVANA BUKARICA");
                System.Threading.Thread.Sleep(1200);
                SendKeys.Send("\t{CAPSLOCK}BEOGRAD");
            }
            catch
            {

            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                int x = 618;
                int y = 417;
                Cursor.Position = new Point(x, y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                System.Threading.Thread.Sleep(200);
                SendKeys.Send("160398449\t60\t\t\t\t{CAPSLOCK}JAVNI IZVRSITELJ NIKOLA NOVAKOVIC");
                System.Threading.Thread.Sleep(1200);
                SendKeys.Send("\t{CAPSLOCK}NOVI SAD");
            }
            catch
            {

            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                IspisIznos("84030413845\t91", "11-223", "600");

                int x = 609;
                int y = 262;
                Cursor.Position = new Point(x, y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                System.Threading.Thread.Sleep(300);
                SendKeys.Send("15{ENTER}");

                /*
                int x = 609;
                int y = 262;
                Cursor.Position = new Point(x, y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                System.Threading.Thread.Sleep(200);
                x = 609;
                y = 311;
                Cursor.Position = new Point(x, y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                System.Threading.Thread.Sleep(400);

                IspisIznos("84030413845\t91", "11-223", "600");*/
            }
            catch
            {

            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                IspisIznos("980333\t07", "090501", "3000");
            }
            catch
            {

            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //INFORMATIKA
            try
            {
                Barkod(false);
                Form3 f3 = new Form3(true);
                f3.ShowDialog();
                string iznos = f3.i;
                string racun = "105999\t39";
                string zamod97 = barkod.Substring(12, 2) +
                    barkod.Substring(10, 2) + barkod.Substring(0, 10);
                ulong mod97 = Convert.ToUInt64(zamod97);
                mod97 = 98 - ((mod97 * 100) % 97);
                string pib;
                if (mod97 < 10)
                {
                    pib = "0" + mod97 + "-" + zamod97;
                }
                else
                {
                    pib = mod97 + "-" + zamod97;
                }
                //label2.Text = racun + "\n" + pib + "\n" + iznos.ToString();
                IspisIznos(racun, pib, iznos);
                //PRIMALAC
                /*
                int x = 150;
                int y = 395;
                Cursor.Position = new Point(x, y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                System.Threading.Thread.Sleep(50);
                SendKeys.Send("INFORMATIKA");
                SendKeys.Send("{TAB}");
                SendKeys.Send("NOVI SAD");*/

                //MODEL
                /*
                System.Threading.Thread.Sleep(150);
                x = 440;
                y = 190;
                Cursor.Position = new Point(x, y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                System.Threading.Thread.Sleep(50);
                //121
                x = 440;
                y = 290;
                Cursor.Position = new Point(x, y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                System.Threading.Thread.Sleep(50);*/
                /*
                //MODEL
                x = 440;
                y = 575;
                Cursor.Position = new Point(x, y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                System.Threading.Thread.Sleep(50);
                //97
                x = 440;
                y = 690;
                Cursor.Position = new Point(x, y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                System.Threading.Thread.Sleep(50);*/
            }
            catch
            {

            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //SBB 330
            try
            {
                int x = 440;
                int y = 560;
                Cursor.Position = new Point(x, y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                System.Threading.Thread.Sleep(200);
                SendKeys.Send("3304011607\t58\t\t");
                //PRIMALAC
                /*
                x = 150;
                y = 395;
                Cursor.Position = new Point(x, y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                System.Threading.Thread.Sleep(50);
                SendKeys.Send("SBB");
                SendKeys.Send("{TAB}");
                SendKeys.Send("BEOGRAD");*/
            }
            catch
            {

            }
        }
    }
}
