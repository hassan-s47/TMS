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
    public partial class crvoucher : Form
    {
         int counter=0;
        bool upd = false;
        public crvoucher()
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
            upd = true;
            dataGridView1.Rows.Clear();
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            dataGridView1.Refresh();
            int key = id;
            cr s = new cr();

            point p = s.getpoint(key);

            for (int i = p.start; i <= p.end; i++)
            {
                if (s.search(i))
                {
                    dateTimePicker1.Text = s.date;
                    dataGridView1.Rows.Add(i.ToString(), s.name, s.descri, s.amt.ToString());
                }
            }
        }
        public void clear()
        {
            cr s = new cr();
            textBox1.Text = s.getsaleid().ToString();
            comboBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            label8.Text = "0";
            counter = 0;
            upd = false;
            loadname();
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
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
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                cr c = new TMS.cr();
                bool sucess = false;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    c.no = Convert.ToInt32(dataGridView1[0, i].Value);
                    c.name = dataGridView1[1, i].Value.ToString();
                    c.descri = dataGridView1[2, i].Value.ToString();
                    c.date = dateTimePicker1.Text;
                    c.amt = Convert.ToInt32(dataGridView1[3, i].Value);
                    sucess = c.insert();

                }
                int start = Convert.ToInt32(textBox1.Text);
                int end = counter - 1 + start;
                c.points(start, end);

                if (sucess)
                {
                    MessageBox.Show("INSERTION SUCESSFUL", "inerted");

                }
                clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void crvoucher_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'partysearch._partysearch' table. You can move, or remove it, as needed.
           
            clear();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    loadrecord(Convert.ToInt32(textBox1.Text));
                }
            }
            catch(Exception x)
            {
                MessageBox.Show("Invalid Record Number","Error");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            cr c = new TMS.cr();
            c.no = Convert.ToInt32(textBox1.Text.ToString());
            bool sucess=c.delete();
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
            try
            {
                cr c = new cr();
                bool sucess = false;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    c.no = Convert.ToInt32(dataGridView1[0, i].Value);
                    c.name = dataGridView1[1, i].Value.ToString();
                    c.descri = dataGridView1[2, i].Value.ToString();
                    c.date = dateTimePicker1.Text;
                    c.amt = Convert.ToInt32(dataGridView1[3, i].Value);
                    sucess = c.update();

                }
                if (sucess)
                {
                    MessageBox.Show("UPDATED SUCESSFULY", "DELETE");
                }
                else
                {
                    MessageBox.Show("UPDATION UNSUCESSFULL", "DELETE");
                }
                clear();
            }catch(Exception x)
            {
                MessageBox.Show(x.ToString(), "Error");
            }

        }

        private void crvoucher_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!external)
            {
                Dashboard d = new Dashboard();
                d.Show();
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox2.Focus();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox3.Focus();
           
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               
                comboBox1.Focus();
              
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int amount = 0;
            for(int i=0;i<dataGridView1.Rows.Count;i++)
            {
                amount+=Convert.ToInt32(dataGridView1[3, i].Value);
            }
            label8.Text = amount.ToString();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            int amount = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                amount += Convert.ToInt32(dataGridView1[3, i].Value);
            }
            label8.Text = amount.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Text = dataGridView1[1, e.RowIndex].Value.ToString();
            textBox2.Text = dataGridView1[2, e.RowIndex].Value.ToString();
            textBox3.Text = dataGridView1[3, e.RowIndex].Value.ToString();
            textBox1.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            dataGridView1.Rows.RemoveAt(e.RowIndex);

        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            if (loadname())
                SendKeys.Send("{END}");

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == 4)
                {
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                    cr c = new TMS.cr();
                    c.no = Convert.ToInt32(dataGridView1[0, e.RowIndex].Value);
                    bool sucess = c.delete();
                    if (sucess)
                    {
                        MessageBox.Show("DELETED SUCESSFULY", "DELETE");
                    }
                    else
                    {
                        MessageBox.Show("DELETION UNSUCESSFULL", "DELETE");
                    }
                   
                }
            }
            catch(Exception x)
            {
                MessageBox.Show("Transaction Does Not Exist", "Error");
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text != "" && textBox3.Text != "")
                {
                    int num = Convert.ToInt32(textBox1.Text) + counter;
                    dataGridView1.Rows.Add(num.ToString(), comboBox1.Text, textBox2.Text, textBox3.Text);
                    comboBox1.Text = "";
                    textBox3.Text = "";
                    textBox2.Text = "";
                    if (upd == false)
                        counter++;
                }
            }
            catch(Exception x)
            {
                MessageBox.Show(x.ToString(), "Error");
            }
        }
    }
}
