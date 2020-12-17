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
using System.Runtime.Serialization.Formatters.Binary;

namespace Revision_Csharp
{
    public partial class Form1 : Form
    {
        public static int pos;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToLongTimeString();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("TDI");
            comboBox1.Items.Add("TRI");
            comboBox1.Items.Add("TDM");
            comboBox2.Items.Add("TDI");
            comboBox2.Items.Add("TRI");
            comboBox2.Items.Add("TDM");
            comboBox3.Items.Add("TDI");
            comboBox3.Items.Add("TRI");
            comboBox3.Items.Add("TDM");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
           
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="" || textBox2.Text=="" || dateTimePicker1.Value==DateTime.Now || groupBox1.Text=="")
            {
                MessageBox.Show("Une information est vide", "Erreur");
            }
            else
            {
                //liseview
                if (checkBox1.Checked == true)
                {
                    stagaire s1 = new stagaire(int.Parse(textBox1.Text), textBox2.Text, dateTimePicker1.Value, int.Parse(numericUpDown1.Value.ToString()), comboBox1.Text);
                    Program.lstview.Add(s1);
                    listView1.Items.Clear();
                    for (int i = 0; i < Program.lstview.Count; i++)
                    {
                        string[] st = { Program.lstview[i].Num.ToString(), Program.lstview[i].nom, Program.lstview[i].Datenaissence.ToShortDateString(), Program.lstview[i].AneeBac.ToString(), Program.lstview[i].Filier };
                        ListViewItem item = new ListViewItem(st);
                        listView1.Items.Add(item);
                    }
                    
                }
 

                //lise box
                if (checkBox2.Checked == true)
                {
                    stagaire s2 = new stagaire(int.Parse(textBox1.Text), textBox2.Text, dateTimePicker1.Value, int.Parse(numericUpDown1.Value.ToString()), comboBox1.Text);
                    Program.lstbox.Add(s2);
                    listBox1.Items.Clear();
                    for (int i = 0; i < Program.lstbox.Count; i++)
                    {
                        listBox1.Items.Add("Num :"+Program.lstbox[i].Num+"  |   Nom :"+Program.lstbox[i].nom+"  |   Date Naissence :" + Program.lstbox[i].Datenaissence+"   |   Année Bac" + Program.lstbox[i].AneeBac+"    |   Filier :" + Program.lstbox[i].Filier);
                    }
                    
                }




                //datagrideview
                if (checkBox3.Checked == true)
                {
                    stagaire s3 = new stagaire(int.Parse(textBox1.Text), textBox2.Text, dateTimePicker1.Value, int.Parse(numericUpDown1.Value.ToString()), comboBox1.Text);
                    Program.dtgv.Add(s3);
                    dataGridView1.Rows.Clear();
                    for (int i = 0; i < Program.dtgv.Count; i++)
                    {
                        dataGridView1.Rows.Add(Program.dtgv[i].Num.ToString(), Program.dtgv[i].nom, Program.dtgv[i].Datenaissence.ToShortDateString(), Program.dtgv[i].AneeBac.ToString(), Program.dtgv[i].Filier);

                    }
                }


                //if checkbox1et2et3 non checked
                if(checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false)
                {
                    stagaire s = new stagaire(int.Parse(textBox1.Text), textBox2.Text, dateTimePicker1.Value, int.Parse(numericUpDown1.Value.ToString()), comboBox1.Text);
                    Program.ls.Add(s);
                    listBox2.Items.Clear();
                    for (int i = 0; i < Program.ls.Count; i++)
                    {
                        listBox2.Items.Add("Num :" + Program.ls[i].Num + "  |   Nom :" + Program.ls[i].nom + "  |   Date Naissence :" + Program.ls[i].Datenaissence.ToShortDateString() + " |   Année Bac :" + Program.ls[i].AneeBac + "  |   Filier :" + Program.ls[i].Filier);
                    }
                    
                }

                MessageBox.Show("bien ajouter :");
                textBox1.Clear();
                textBox2.Clear();
                dateTimePicker1.Value = DateTime.Now;
                numericUpDown1.Value = 2010;
                comboBox1.Text = "";
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Une information est vide", "Erreur");
            }
            else
            {
                if (radioButton3.Checked == true)
                {

                    int num = int.Parse(textBox4.Text);
                    pos = Program.chercher_num(num);
                    if (pos == -1)
                    {
                        MessageBox.Show("N'existe Pas !");
                    }
                    else
                    {
                        MessageBox.Show("Existe dans la position: " + pos);
                        Program.pNum = Program.ls[pos].Num;
                        Program.pnom = Program.ls[pos].nom;
                        Program.pdatnaissence = Program.ls[pos].Datenaissence;
                        Program.paneebac = Program.ls[pos].AneeBac;
                        Program.pfilier = Program.ls[pos].Filier;
                        Program.pos = pos;
                        Afficher_et_Modifier x = new Afficher_et_Modifier();
                        x.Show();
                    }
                }
                if (radioButton4.Checked == true)
                {
                    string nom = textBox4.Text;
                    pos = Program.chercher_nom(nom);
                    if (pos == -1)
                    {
                        MessageBox.Show("N'existe Pas !");
                    }
                    else
                    {
                        MessageBox.Show("Existe dans la position: " + pos);
                        Program.pNum = Program.ls[pos].Num;
                        Program.pnom = Program.ls[pos].nom;
                        Program.pdatnaissence = Program.ls[pos].Datenaissence;
                        Program.paneebac = Program.ls[pos].AneeBac;
                        Program.pfilier = Program.ls[pos].Filier;
                        Program.pos = pos;
                        Afficher_et_Modifier x = new Afficher_et_Modifier();
                        x.Show();
                    }
                }
            }
               
            textBox4.Clear();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Une information est vide", "Erreur");
            }
            else
            {
                if (radioButton3.Checked == true)
                {
                    int num = int.Parse(textBox4.Text);
                    pos = Program.chercher_num(num);
                    if (pos == -1)
                    {
                        MessageBox.Show("N'existe Pas !");
                    }
                    else
                    {

                        Program.pNum = Program.ls[pos].Num;
                        Program.pnom = Program.ls[pos].nom;
                        Program.pdatnaissence = Program.ls[pos].Datenaissence;
                        Program.paneebac = Program.ls[pos].AneeBac;
                        Program.pfilier = Program.ls[pos].Filier;
                        Program.pos = pos;
                        Afficher_et_Modifier x = new Afficher_et_Modifier();
                        x.Show();

                    }
                }
            
            }
            if (radioButton4.Checked == true)
            {
                string nom = textBox4.Text;
                pos = Program.chercher_nom(nom);
                if (pos == -1)
                {
                    MessageBox.Show("N'existe Pas !");
                }
                else
                {
                    
                    Program.pNum = Program.ls[pos].Num;
                    Program.pnom = Program.ls[pos].nom;
                    Program.pdatnaissence = Program.ls[pos].Datenaissence;
                    Program.paneebac = Program.ls[pos].AneeBac;
                    Program.pfilier = Program.ls[pos].Filier;
                    Program.pos = pos;
                    Afficher_et_Modifier x = new Afficher_et_Modifier();
                    x.Show();
                    
                }
            }
            textBox4.Clear();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Une information est vide", "Erreur");
            }
            else
            {
                DialogResult dr = MessageBox.Show("Voulez Vous Vraiment Supprimer !!", "Suppression", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    if (radioButton3.Checked == true)
                    {
                        int num = int.Parse(textBox4.Text);
                        pos = Program.chercher_num(num);
                        if (pos == -1)
                        {
                            MessageBox.Show("N'existe Pas!");
                        }
                        else
                        {
                            Program.ls.RemoveAt(pos);
                            MessageBox.Show("Bien supprimer");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Suppression Ignore");
                    }
                }
                if (radioButton4.Checked == true)
                {
                    if (radioButton3.Checked == true)
                    {
                        string nom = textBox4.Text;
                        pos = Program.chercher_nom(nom);
                        if (pos == -1)
                        {
                            MessageBox.Show("N'existe Pas!");
                        }
                        else
                        {
                            Program.ls.RemoveAt(pos);
                            MessageBox.Show("Bien supprimer");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Suppression Ignore");
                    }
                }
            }
           
            textBox4.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            for (int i = 0; i < Program.ls.Count; i++)
            {
                listBox2.Items.Add("Num :" + Program.ls[i].Num + "  |   Nom :" + Program.ls[i].nom + "  |   Date Naissence :" + Program.ls[i].Datenaissence + "   |   Année Bac" + Program.ls[i].AneeBac + "    |   Filier :" + Program.ls[i].Filier);
            }
            listBox1.Items.Clear();
            for (int i = 0; i < Program.lstbox.Count; i++)
            {
                listBox1.Items.Add("Num :" + Program.lstbox[i].Num + "  |   Nom :" + Program.lstbox[i].nom + "  |   Date Naissence :" + Program.lstbox[i].Datenaissence + "   |   Année Bac" + Program.lstbox[i].AneeBac + "    |   Filier :" + Program.lstbox[i].Filier);
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(listBox2.SelectedItem.ToString());
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox5.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[1].Text;
            dateTimePicker2.Value = DateTime.Parse(listView1.SelectedItems[0].SubItems[2].Text);
            numericUpDown2.Value = int.Parse(listView1.SelectedItems[0].SubItems[3].Text);
            comboBox2.Text = listView1.SelectedItems[0].SubItems[4].Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.Focus();
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox5.Text == "" || textBox3.Text == "" || dateTimePicker2.Value == DateTime.Now || groupBox2.Text == "")
                {
                    MessageBox.Show("Une information est vide", "Erreur");
                }
                else
                {
                    //ajouter sur listView
                    listView1.SelectedItems[0].SubItems[0].Text = textBox5.Text;
                    listView1.SelectedItems[0].SubItems[1].Text = textBox3.Text;
                    listView1.SelectedItems[0].SubItems[2].Text = dateTimePicker2.Value.ToString();
                    listView1.SelectedItems[0].SubItems[3].Text = numericUpDown2.Value.ToString();
                    listView1.SelectedItems[0].SubItems[4].Text = comboBox2.Text;
                    textBox5.Clear();
                    textBox3.Clear();
                    dateTimePicker2.Value = DateTime.Now;
                    numericUpDown2.Value = 2010;
                    comboBox2.Text = "";
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Selectioner un ligne dance la liste puis modifier!!!!");
            }
            
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            try
            {
                listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
            }
            catch (Exception)
            {

                MessageBox.Show("selectioner une ligne!!!!");
                
            }
           
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
         
                listView1.Items.Clear();
                MessageBox.Show("La Lise est vide!!!!");
           
        }

        private void pictureBox17_Click_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            if (listBox2.SelectedIndex != -1)
            {
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            }
                      
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res1 = new DialogResult();
                res1 = MessageBox.Show("vouler vous vider ListeBox1", "Quistion1", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res1 == DialogResult.Yes)
                {
                    listBox1.Items.Clear();
                }

                DialogResult res2 = new DialogResult();
                res2 = MessageBox.Show("vouler vous vider ListeBox2", "Quistion2", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res2 == DialogResult.Yes)
                {
                    listBox2.Items.Clear();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("une ListBox est vide");
            }
            
            
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            pos = listBox1.SelectedIndex;
            try
            {
                Program.b = true;
                Program.pNum = Program.lstbox[pos].Num;
                Program.pnom = Program.lstbox[pos].nom;
                Program.pdatnaissence = Program.lstbox[pos].Datenaissence;
                Program.paneebac = Program.lstbox[pos].AneeBac;
                Program.pfilier = Program.lstbox[pos].Filier;
                Program.pos = pos;
                Afficher_et_Modifier x = new Afficher_et_Modifier();
                x.Show();
            }
            catch (Exception)
            {

                MessageBox.Show("pas de ligne selectioner!!!!");
            }
            
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add(listBox1.SelectedItem.ToString());
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            int l = listBox2.Items.Count;
            for (int i = 0; i < l; i++)
            {
                listBox1.Items.Add(listBox2.Items[i].ToString());
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            int l = listBox1.Items.Count;
            for (int i = 0; i < l; i++)
            {
                listBox2.Items.Add(listBox1.Items[i].ToString());
            }
        }
        int index;
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            
            index = dataGridView1.CurrentRow.Index;
            textBox7.Text = this.dataGridView1.Rows[index].Cells[0].Value.ToString();
            textBox6.Text = this.dataGridView1.Rows[index].Cells[1].Value.ToString();
            dateTimePicker3.Value = DateTime.Parse(dataGridView1.Rows[index].Cells[2].Value.ToString());
            numericUpDown3.Value = int.Parse(dataGridView1.Rows[index].Cells[3].Value.ToString());
            comboBox3.Text = this.dataGridView1.Rows[index].Cells[4].Value.ToString();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = new DialogResult();
                res = MessageBox.Show("vouler vous Vider Data Grid View?????", "Quistion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    int index;
                    index = dataGridView1.CurrentRow.Index;
                    dataGridView1.Rows.Clear();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Data Grid View Vide!!!!");
            }
        }

        private void pictureBox14_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = new DialogResult();
                res = MessageBox.Show("vouler vous Supprmier??????", "Quistion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    int index;
                    index = dataGridView1.CurrentRow.Index;
                    dataGridView1.Rows.RemoveAt(index);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Data Grid View Vide!!!!");
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < Program.dtgv.Count; i++)
            {
                dataGridView1.Rows.Add(Program.dtgv[i].Num.ToString(), Program.dtgv[i].nom, Program.dtgv[i].Datenaissence.ToShortDateString(), Program.dtgv[i].AneeBac.ToString(), Program.dtgv[i].Filier);

            }
        }

        private void pictureBox20_Click_1(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            for (int i = 0; i < Program.lstview.Count; i++)
            {
                string[] st = { Program.lstview[i].Num.ToString(), Program.lstview[i].nom, Program.lstview[i].Datenaissence.ToShortDateString(), Program.lstview[i].AneeBac.ToString(), Program.lstview[i].Filier };
                ListViewItem item = new ListViewItem(st);
                listView1.Items.Add(item);
            }
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            index = dataGridView1.CurrentRow.Index;
            this.dataGridView1.Rows[index].Cells[0].Value = textBox7.Text;
            this.dataGridView1.Rows[index].Cells[1].Value = textBox6.Text;
            dataGridView1.Rows[index].Cells[2].Value = dateTimePicker3.Value;
            dataGridView1.Rows[index].Cells[3].Value = numericUpDown3.Value;
            this.dataGridView1.Rows[index].Cells[4].Value = comboBox3.Text;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            textBox7.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //enregitrer dans la liste:  
                StreamWriter sw = new StreamWriter("Fichier.txt", true);
                for (int i = 0; i < Program.ls.Count; i++)
                {
                    sw.WriteLine(Program.ls[i].Num+"|"+ Program.ls[i].nom+"|"+ Program.ls[i].Datenaissence+"|"+ Program.ls[i].AneeBac+"|"+ Program.ls[i].Filier);
                }
                sw.Close();
                MessageBox.Show("Bien enregitrer en liste...");
            

        }

        private void button6_Click(object sender, EventArgs e)
        {


            //Importer
            if (File.Exists("Fichier.txt"))
                {
                   
                    FileStream fs = new FileStream("Fichier.txt", FileMode.Open);
                        StreamReader sr = new StreamReader(fs);
                        string ligne;
                        while (sr.Peek() != -1)
                        {

                            ligne = sr.ReadLine();
                            string[] stag = ligne.Split('|');
                            stagaire s = new stagaire(int.Parse(stag[0]), stag[1], DateTime.Parse(stag[2]), int.Parse(stag[3]), stag[4]);
                            Program.ls.Add(s);
                        }
                        sr.Close();
                        fs.Close();
                        MessageBox.Show("Bien Importer...");
  
                }
                else
                {
                    MessageBox.Show("pas de fichier");
                }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //serialiser Binary
            Stream fichier = File.Create("FichierSerialiser.txt");
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(fichier, Program.ls);
            fichier.Close();
            MessageBox.Show("Bien Serialier en Binary...");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //deserialiser
            Stream st = File.OpenRead("FichierSerialiser.txt");
            BinaryFormatter fo = new BinaryFormatter();
            Program.ls = (List<stagaire>)fo.Deserialize(st);
            MessageBox.Show("Bien deserialiser...");
            st.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
