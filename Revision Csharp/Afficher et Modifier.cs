using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Revision_Csharp
{
    public partial class Afficher_et_Modifier : Form
    {
        public Afficher_et_Modifier()
        {
            InitializeComponent();
        }
        public int pos = Program.pos;
        private void Afficher_et_Modifier_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("TDI");
            comboBox1.Items.Add("TRI");
            comboBox1.Items.Add("TDM");
            if (Program.b == true)
            {
                checkBox1.Visible = false;
                checkBox2.Checked = true;
            }
            if (Program.b == false)
            {
                checkBox2.Visible = false;
                checkBox1.Checked = true;
            }
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {
            textBox1.Text = Program.pNum.ToString();
            textBox2.Text = Program.pnom;
            dateTimePicker1.Value = Program.pdatnaissence;
            numericUpDown1.Value = Program.paneebac;
            comboBox1.Text = Program.pfilier;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (checkBox1.Checked==true)
            {
                    Program.ls[pos].Num = int.Parse(textBox1.Text.ToString());
                    Program.ls[pos].nom = textBox2.Text;
                    Program.ls[pos].Datenaissence = dateTimePicker1.Value;
                    Program.ls[pos].AneeBac = int.Parse(numericUpDown1.Value.ToString());
                    Program.ls[pos].Filier = comboBox1.Text;    
            }
            if (checkBox2.Checked==true)
            {
                Program.lstbox[pos].Num = int.Parse(textBox1.Text.ToString());
                Program.lstbox[pos].nom = textBox2.Text;
                Program.lstbox[pos].Datenaissence = dateTimePicker1.Value;
                Program.lstbox[pos].AneeBac = int.Parse(numericUpDown1.Value.ToString());
                Program.lstbox[pos].Filier = comboBox1.Text;     
            }
            Program.pos = -1;
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = Program.ls[0].Num.ToString();
            textBox2.Text = Program.ls[0].nom.ToString();
            dateTimePicker1.Value = Program.ls[0].Datenaissence;
            numericUpDown1.Value = Program.ls[0].AneeBac;
            comboBox1.Text = Program.ls[0].Filier.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Program.ls.Count; i++)
            {
                textBox1.Text = Program.ls[Program.ls.Count - 1].Num.ToString();
                textBox2.Text = Program.ls[Program.ls.Count - 1].nom.ToString();
                dateTimePicker1.Value = Program.ls[Program.ls.Count - 1].Datenaissence;
                numericUpDown1.Value = Program.ls[Program.ls.Count - 1].AneeBac;
                comboBox1.Text = Program.ls[Program.ls.Count - 1].Filier.ToString();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Program.c--;
            if (Program.c < 0)
            {
                Program.c = 0;
            }
            else
            {
                textBox1.Text = Program.ls[Program.c].Num.ToString();
                textBox2.Text = Program.ls[Program.c].nom.ToString();
                dateTimePicker1.Value = Program.ls[Program.c].Datenaissence;
                numericUpDown1.Value = Program.ls[Program.c].AneeBac;
                comboBox1.Text = Program.ls[Program.c].Filier.ToString();

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Program.c++;
            if (Program.c > Program.ls.Count -1)
            {
                Program.c = Program.ls.Count -1;
            }
            else
            {
                textBox1.Text = Program.ls[Program.c].Num.ToString();
                textBox2.Text = Program.ls[Program.c].nom.ToString();
                dateTimePicker1.Value = Program.ls[Program.c].Datenaissence;
                numericUpDown1.Value = Program.ls[Program.c].AneeBac;
                comboBox1.Text = Program.ls[Program.c].Filier.ToString();

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
