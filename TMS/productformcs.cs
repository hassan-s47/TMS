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
    public partial class productformcs : Form
    {
        public productformcs()
        {
            InitializeComponent();
        }
        void clear()
        {
            searchbox.Text = "";
            namebox.Text = "";
            codebox.Text = "";
            sratebox.Text = "";
            pratebox.Text = "";
            //stockbox.Text = "";
            button2.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (namebox.Text != "" && codebox.Text != ""  && sratebox.Text != "" && pratebox.Text != "")
            {
                product p = new product();
                p.name = namebox.Text;
                p.code = codebox.Text;
                //      p.stk = Convert.ToInt32(stockbox.Text);
                p.sr = Convert.ToInt32(sratebox.Text);
                p.pr = Convert.ToInt32(pratebox.Text);
                if (p.add())
                    MessageBox.Show("Insertion Successful", "Insertion");
                else
                    MessageBox.Show("Insertion Failed", "Insertion");
                clear();
            }
            else { MessageBox.Show("PLZ FILL ALL THE TEXT BOXES", "ERROR"); }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (searchbox.Text != "")
            {
                button2.Hide();
                product p = new product();
                if (p.search(searchbox.Text))
                {
                    namebox.Text = p.name;
                    codebox.Text = p.code;
           //         stockbox.Text = p.stk.ToString();
                    sratebox.Text = p.sr.ToString();
                    pratebox.Text = p.pr.ToString();
                }
                else
                {
                    MessageBox.Show("No Item Found");
                    clear();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (searchbox.Text != "")
            {
                button2.Hide();
                product p = new product();
               if( p.del(searchbox.Text))

                MessageBox.Show("Deletion Successful", "Delete");
               else
                    MessageBox.Show("Deletion Failed", "Delete");
                clear();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (searchbox.Text != "")
            {
                button2.Hide();
                product p = new product();
                p.name = namebox.Text;
                p.code = codebox.Text;
           //     p.stk = Convert.ToInt32(stockbox.Text);
                p.sr = Convert.ToInt32(sratebox.Text);
                p.pr = Convert.ToInt32(pratebox.Text);
              if(  p.update(searchbox.Text))
                MessageBox.Show("Updation Successful", "Update");
              else
                    MessageBox.Show("Updation Failed", "Update");
                clear();
            }
        }

        private void productformcs_Load(object sender, EventArgs e)
        {

        }

        private void productformcs_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dashboard d = new Dashboard();
            d.Show();
        }
    }
}
