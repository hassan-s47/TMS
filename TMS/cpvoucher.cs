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
    public partial class cpvoucher : Form
    {
        public cpvoucher()
        {
            InitializeComponent();
        }
        bool external = false;
        public void isexternal()
        {
            external = true;
        }

        public void loadrecord(int id)
        {
            int key = id;
            cp s = new cp();
            textBox1.Text = id.ToString();
            if (s.search(key))
            {
                comboBox1.Text = s.name;
                textBox2.Text = s.descri;
                dateTimePicker1.Text = s.date;
                textBox3.Text = s.amt.ToString();

            }
        } 
           
        public void clear()
        {
            cp s = new cp();
            textBox1.Text = s.getsaleid().ToString();
            comboBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cp c = new TMS.cp();
            c.no = Convert.ToInt32(textBox1.Text.ToString());
            c.name = comboBox1.Text.ToString();
            c.descri = textBox2.Text.ToString();
            c.date = dateTimePicker1.Text;
            c.amt = Convert.ToInt32(textBox3.Text);
            bool sucess = c.insert();
            if (sucess)
            {
                MessageBox.Show("INSERTION SUCESSFUL", "inerted");

            }
            clear();

        }


        private void cpvoucher_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'partysearch._partysearch' table. You can move, or remove it, as needed.
         
            clear();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadrecord(Convert.ToInt32(textBox1.Text));
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            cp c = new TMS.cp();
            c.no = Convert.ToInt32(textBox1.Text.ToString());
            bool sucess = c.delete();
            if (sucess)
            {
                MessageBox.Show("DELETED SUCESSFULY", "DELETE");
            }
            else
            {
                MessageBox.Show("DELETION UNSUCESSFULL", "DELETE");
            }
            clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cp c = new cp();
            c.no = Convert.ToInt32(textBox1.Text.ToString());
            c.name = comboBox1.Text.ToString();
            c.descri = textBox2.Text.ToString();
            c.date = dateTimePicker1.Text;
            c.amt = Convert.ToInt32(textBox3.Text);
            bool sucess = c.update();
            if (sucess)
            {
                MessageBox.Show("UPDATED SUCESSFULY", "DELETE");
            }
            else
            {
                MessageBox.Show("UPDATION UNSUCESSFULL", "DELETE");
            }
            clear();

        }

        private void cpvoucher_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!external)
            {
                Dashboard d = new Dashboard();
                d.Show();
            }
        }
    }
}
