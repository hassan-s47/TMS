using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMS
{
    public partial class partyform : Form
    {
        void clear()
        {
            comboBox1.Text = "";
            loadname();
            richTextBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox4.Text = "";
            button2.Hide();
            button4.Hide();

        }
        public partyform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox2.Text != "")
            {

                party p = new party();
                p.address = richTextBox1.Text;
                p.name = textBox2.Text;
                try
                {
                    p.balance = Convert.ToInt32(textBox3.Text);



                    p.contact = textBox4.Text;
                    p.city = comboBox2.SelectedItem.ToString();
                
                if (p.add())
                    MessageBox.Show("Insertion Successful", "Insertion");
                else
                    MessageBox.Show("Insertion Failed", "Insertion");
                    clear();
                    textBox2.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
               
            }
            else
            {
                MessageBox.Show("PLZ ENTER DATA IN ALL TEXT BOXES", "ERROR");
            }
        }

        private void partyform_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'partysearch._partysearch' table. You can move, or remove it, as needed.
           
            clear();
         
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            party p = new party();

            if (comboBox1.Text != "")
            {
                button1.Hide();
                p.search(comboBox1.Text);
                textBox2.Text = p.name;
                richTextBox1.Text = p.address;
                textBox3.Text = p.balance.ToString();
                textBox4.Text = p.contact;
                comboBox2.Text = p.city;
                button4.Show();
                button2.Show();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Show();
            clear();
            textBox2.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                party p = new party();
                if (comboBox1.Text != "")
                {

                    p.del(comboBox1.Text);
                    clear();
                    button1.Show();
                    textBox2.Focus();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {


                if (richTextBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox2.Text != "" && comboBox1.Text != "")
                {
                    party p = new party();
                    p.address = richTextBox1.Text;
                    p.name = textBox2.Text;
                    p.balance = Convert.ToInt32(textBox3.Text);
                    p.contact = textBox4.Text;
                    p.city = comboBox2.SelectedItem.ToString();
                    if (comboBox1.Text != "")
                    {

                        p.update(comboBox1.Text);
                        clear();
                        button1.Show();
                        Focus();
                    }
                }
                else
                {
                    MessageBox.Show("PLZ ENTER DATA IN ALL TEXT BOSES", "ERROR");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void partyform_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dashboard d = new Dashboard();
            d.Show();
        }

        public bool loadname()
        {
            try
            {
                string key = comboBox1.Text;
                party p = new party();
                DataTable read = new DataTable();
                read = p.getpname(key);
                bool success = false;
                if (read.Rows.Count != 0)
                {
                    if (comboBox1.Items.Count != 0)
                        comboBox1.Items.Clear();
                    for (int i = 0; i < read.Rows.Count; i++)
                    {
                        comboBox1.Items.Add(read.Rows[i]["name"]);

                    }
                    success = true;

                }
                return success;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            return false;
        }
        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            if (loadname())
                SendKeys.Send("{END}");
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}
